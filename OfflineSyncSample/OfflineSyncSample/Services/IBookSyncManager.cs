using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using OfflineSyncSample.Models;

namespace OfflineSyncSample.Services
{
    public interface IBookSyncManager
    {
        Task<ObservableCollection<BookItem>> GetAllItems(bool syncItems = false);
	}
}
