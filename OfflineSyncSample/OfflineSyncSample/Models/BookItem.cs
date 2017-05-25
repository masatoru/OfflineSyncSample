using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfflineSyncSample.Models
{
    public class BookItem
    {
        public string Id { get; set; }
        public string FileName { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Chosha { get; set; }
        public string Content { get; set; }
    }
}