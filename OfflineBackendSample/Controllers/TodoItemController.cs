using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using OfflineBackendSample.DataObjects;
using OfflineBackendSample.Models;

namespace OfflineBackendSample.Controllers
{
    public class TodoItemController : TableController<BookItem>
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
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/BookItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteTodoItem(string id)
        {
            return DeleteAsync(id);
        }
    }
}