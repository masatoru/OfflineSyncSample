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
using System.Windows.Input;
using OfflineSyncSample.Behaviors;
using Plugin.Connectivity;

namespace OfflineSyncSample.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware, IAppearingAware
    {
        public ObservableCollection<BookItem> BookList { get; set; }
        public ICommand SyncCommand { get; }
		public ICommand ViewHeadingCommand { get; }

		IBookSyncManager _bookmg;
        INavigationService _navigationService;

        private bool _isConnected;
        public bool IsConnected
        {
            get { return _isConnected; }
            set { SetProperty(ref _isConnected, value); }
        }
        private string _status;
        public string Status
        {
            get { return _status; }
            set { SetProperty(ref _status, value); }
        }

        private BookItem _bookSelected;
        public BookItem BookSelected
        {
            get { return this._bookSelected; }
            set { SetProperty(ref _bookSelected, value); }
        }

        public MainPageViewModel(IBookSyncManager bookmg, INavigationService navigationService)
        {
            _bookmg = bookmg;
            BookList = new ObservableCollection<BookItem>();
            _navigationService = navigationService;

            //ネットワークの接続状態が変更されたことを検知する
            CrossConnectivity.Current.ConnectivityChanged += (sender, args) =>
            {
                IsConnected = CrossConnectivity.Current.IsConnected;
                UpdateNetworkStatus();
            };

            //ネットワークの種類が変更されたことを検知する
            CrossConnectivity.Current.ConnectivityTypeChanged += (sender, args) =>
            {
                IsConnected = CrossConnectivity.Current.IsConnected;
                UpdateNetworkStatus();
            };

            //ネットワークにつながっている時だけ同期ボタンを押せる
            this.SyncCommand =
                new DelegateCommand(async () => { await DoSync(); }, CanExecuteDoSyncCommand)
                .ObservesProperty(() => IsConnected);
			this.ViewHeadingCommand = new DelegateCommand(ViewHeading);

			//起動時は同期しない（クライアントのデータを表示する）
			ViewData(false);

		}

        //ネットワークの状態を表示
        void UpdateNetworkStatus()
        {
            var connected = CrossConnectivity.Current.IsConnected ? "オンライン" : "オフライン";
            var type = CrossConnectivity.Current.IsConnected ? $"種別={ CrossConnectivity.Current.ConnectionTypes.FirstOrDefault()}" : "";
            Status = $"{connected} {type}";
        }

        /// <summary>
        /// 一覧表示する
        /// </summary>
        /// <param name="isSync">バックエンドと同期する場合はtrue</param>
        async void ViewData(bool isSync)
        {
            BookList.Clear();
            var lst = await _bookmg.GetAllItems(isSync);
            foreach (var book in lst)
                BookList.Add(book);
        }

        //画面が表示される時に初期化する
        public void OnAppearing()
        {
            IsConnected = CrossConnectivity.Current.IsConnected;
            UpdateNetworkStatus();

            ////起動時は同期しない（クライアントのデータを表示する）
            //await ViewData(false);
        }

        //バックエンドと同期する
        async Task DoSync()
        {
            ViewData(true);
        }

        private bool CanExecuteDoSyncCommand()
        {
            return IsConnected;
        }

        async void ViewHeading()
        {
            var navParameters = new NavigationParameters
            {
                {"book", BookSelected},
            };
            await _navigationService.NavigateAsync("HeadingPage", navParameters);
        }


        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
        }
    }
}
