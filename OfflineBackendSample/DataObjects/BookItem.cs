using Microsoft.Azure.Mobile.Server;

namespace OfflineBackendSample.DataObjects
{
    public class BookItem : EntityData
    {
        public string Title { get; set; }

        public string Company { get; set; }
    }
}