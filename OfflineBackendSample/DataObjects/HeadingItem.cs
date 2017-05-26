using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Azure.Mobile.Server;

namespace OfflineBackendSample.DataObjects
{
    public class HeadingItem : EntityData
    {
        public string BookId { get; set; }
        public string Title { get; set; }
    }
}