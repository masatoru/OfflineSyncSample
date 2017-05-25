using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using OfflineSyncSample.Models;

namespace OfflineSyncSample.Services
{
    public interface IBookSyncManager : INotifyPropertyChanged
    {
        Task<ObservableCollection<BookItem>> GetAllItems(bool syncItems = false);
	}
}
