using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;
using OfflineSyncSample.Models;
using System.Collections.ObjectModel;
using OfflineSyncSample.Services;

namespace OfflineSyncSample.ViewModels
{
    public class HeadingPageViewModel : BindableBase, INavigationAware
    {
		public ObservableCollection<HeadingItem> HeadingList { get; set; }
        IBookSyncManager _bookmg;

		public HeadingPageViewModel(IBookSyncManager bookmg)
        {
            HeadingList = new ObservableCollection<HeadingItem>();
            _bookmg = bookmg;
        }
        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public async void OnNavigatingTo(NavigationParameters parameters)
        {
			//引数から取得
			var book = (BookItem)parameters["book"];

            HeadingList.Clear();
            var lst = await _bookmg.GetHeadingItems(book.Id);
            foreach(var head in lst){
                HeadingList.Add(head);
            }
		}

        public void OnNavigatedTo(NavigationParameters parameters)
        {
        }

    }
}
