using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using OfflineSyncSample.Services;
using System.Collections.ObjectModel;
using OfflineSyncSample.Models;
using System.Threading.Tasks;

namespace OfflineSyncSample.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
		public ObservableCollection<BookItem> BookList { get; set; }
        IBookSyncManager _bookmg;
        INavigationService _navigationService;

		public MainPageViewModel(IBookSyncManager bookmg, INavigationService navigationService)
        {
            _bookmg = bookmg;
            BookList = new ObservableCollection<BookItem>();
            _navigationService = navigationService;
            InitData();
        }
        async void InitData(){
            BookList.Clear();
			var lst = await _bookmg.GetAllItems(true);
			foreach (var book in lst)
				BookList.Add(book);
		}

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            //if (parameters.ContainsKey("title"))
                //Title = (string)parameters["title"] + " and Prism";
        }
    }
}
