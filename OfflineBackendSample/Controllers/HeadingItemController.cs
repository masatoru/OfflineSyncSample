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
    public class HeadingItemController : TableController<HeadingItem>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<HeadingItem>(context, Request);
        }

        // GET tables/BookItem
        public IQueryable<HeadingItem> GetAllTodoItems(string bookId)
        {
            return Query().Where(m => m.BookId==bookId);
        }

        // GET tables/BookItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<HeadingItem> GetTodoItem(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/BookItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<HeadingItem> PatchTodoItem(string id, Delta<HeadingItem> patch)
        {
            return UpdateAsync(id, patch);
        }

        // POST tables/BookItem
        public async Task<IHttpActionResult> PostTodoItem(HeadingItem item)
        {
            HeadingItem current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/BookItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteTodoItem(string id)
        {
            return DeleteAsync(id);
        }
    }
}