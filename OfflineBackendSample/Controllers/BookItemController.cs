using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using Microsoft.Azure.Mobile.Server.Config;
using Microsoft.Azure.NotificationHubs;
using OfflineBackendSample.DataObjects;
using OfflineBackendSample.Models;



namespace OfflineBackendSample.Controllers
{
    public class BookItemController : TableController<BookItem>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<BookItem>(context, Request);
        }

        // GET tables/BookItem
        public IQueryable<BookItem> GetAllTodoItems()
        {
            return Query();
        }

        // GET tables/BookItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<BookItem> GetTodoItem(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/BookItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<BookItem> PatchTodoItem(string id, Delta<BookItem> patch)
        {
            return UpdateAsync(id, patch);
        }

        // POST tables/BookItem
        public async Task<IHttpActionResult> PostTodoItem(BookItem item)
        {
            BookItem current = await InsertAsync(item);

            // Get the settings for the server project.
            HttpConfiguration config = this.Configuration;
            MobileAppSettingsDictionary settings =
                this.Configuration.GetMobileAppSettingsProvider().GetMobileAppSettings();

            // Get the Notification Hubs credentials for the Mobile App.
            string notificationHubName = settings.NotificationHubName;
            string notificationHubConnection = settings
                .Connections[MobileAppSettingsKeys.NotificationHubConnectionString].ConnectionString;

            // Create a new Notification Hub client.
            NotificationHubClient hub = NotificationHubClient
                .CreateClientFromConnectionString(notificationHubConnection, notificationHubName);

            // Sending the message so that all template registrations that contain "messageParam"
            // will receive the notifications. This includes APNS, GCM, WNS, and MPNS template registrations.
            Dictionary<string, string> templateParams = new Dictionary<string, string>();
            templateParams["messageParam"] = item.Title + " was added to the list.";

            try
            {
                // Send the push notification and log the results.
                var result = await hub.SendTemplateNotificationAsync(templateParams);

                // Write the success result to the logs.
                config.Services.GetTraceWriter().Info(result.State.ToString());
            }
            catch (System.Exception ex)
            {
                // Write the failure result to the logs.
                config.Services.GetTraceWriter()
                    .Error(ex.Message, null, "Push.SendAsync Error");
            }



            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/BookItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteTodoItem(string id)
        {
            return DeleteAsync(id);
        }
    }
}