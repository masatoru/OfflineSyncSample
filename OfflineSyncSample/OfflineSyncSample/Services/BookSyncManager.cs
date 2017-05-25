using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;
using OfflineSyncSample.Models;
using Prism.Mvvm;

namespace OfflineSyncSample.Services
{
    public class BookSyncManager : BindableBase, IBookSyncManager
    {
        MobileServiceClient _client;
        public MobileServiceClient CurrentClient
        {
            get { return _client; }
        }
        IMobileServiceSyncTable<BookItem> _bookTable;

        const string _offlineDbPath = @"localstore.db";
        const string _backendUrl = @"http://10.211.55.3";
        const int _backendPort = 5000;

        public BookSyncManager()
        {
            //Mobile Clientの初期化
            var url = $"{_backendUrl}:{_backendPort}";
            _client = new MobileServiceClient(url);

            //同期をおこなう準備
            InitSync().Wait();
        }

        //同期をおこなう準備
        async Task InitSync()
        {
            //TodoItemと同様の型のSQLiteのテーブルを作成する
            var store = new MobileServiceSQLiteStore(_offlineDbPath);
            store.DefineTable<BookItem>();

            //同期をおこなうローカルテーブルとバックエンドのテーブルを関連付ける
            await _client.SyncContext.InitializeAsync(store);

            //_bookTableはIMobileServiceTableではなくてIMobileServiceSyncTable型
            _bookTable = _client.GetSyncTable<BookItem>();
        }

        //同期処理をおこなう
        private async Task SyncAsync()
        {
            await _client.SyncContext.PushAsync();
            await _bookTable.PullAsync("BookItem", _bookTable.CreateQuery());
        }

        //全件を取得する
        public async Task<ObservableCollection<BookItem>> GetAllItems(bool syncItems = false)
        {
            try
            {
                if (syncItems)
                {
                    await this.SyncAsync();
                }
                var lst = await _bookTable.ToEnumerableAsync();
                return new ObservableCollection<BookItem>(lst);
            }
            catch (MobileServiceInvalidOperationException msioe)
            {
                Debug.WriteLine(@"Invalid sync operation: {0}", msioe.Message);
            }
            catch (Exception e)
            {
                Debug.WriteLine(@"Sync error: {0}", e.Message);
            }
            return null;
        }
    }
}
