using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;
using OfflineSyncSample.Models;
using Plugin.Connectivity;
using Prism.Mvvm;

namespace OfflineSyncSample.Services
{
    public class BookSyncManager : BindableBase, IBookSyncManager
    {
        MobileServiceClient _client;
        IMobileServiceSyncTable<BookItem> _bookTable;
        IMobileServiceSyncTable<HeadingItem> _headingTable;

        const string _offlineDbPath = @"localstore.db";
        const string _backendUrl = @"http://10.211.55.3";
        const int _backendPort = 5000;

        public BookSyncManager()
        {
            //Mobile Clientの初期化
            var url = $"{_backendUrl}:{_backendPort}";
            _client = new MobileServiceClient(url);

            //同期をおこなう準備
            InitSync();
        }

        //同期をおこなう準備
        void InitSync()
        {
            //TodoItemと同様の型のSQLiteのテーブルを作成する
            var store = new MobileServiceSQLiteStore(_offlineDbPath);
            store.DefineTable<BookItem>();
            store.DefineTable<HeadingItem>();

            //同期をおこなうローカルテーブルとバックエンドのテーブルを関連付ける
            _client.SyncContext.InitializeAsync(store);

            //_bookTableはIMobileServiceTableではなくてIMobileServiceSyncTable型
            _bookTable = _client.GetSyncTable<BookItem>();
            _headingTable = _client.GetSyncTable<HeadingItem>();
        }

        //同期処理をおこなう
        private async Task SyncAsync()
        {
            try
            {
                await _client.SyncContext.PushAsync();
                await _bookTable.PullAsync("allBookItems", _bookTable.CreateQuery());
                await _headingTable.PullAsync("allHeadingItems", _headingTable.CreateQuery());
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"Sync error: {0}", ex.Message);

            }
        }
        public async Task<ObservableCollection<HeadingItem>> GetHeadingItems(string bookId)
        {
            try
            {
                //ローカルのストア（SQLite）からデータを取得する
                var lst = await _headingTable
                    .Where(m => m.BookId == bookId)
                    .ToEnumerableAsync();
                return new ObservableCollection<HeadingItem>(lst);
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

        //全件を取得する
        public async Task<ObservableCollection<BookItem>> GetAllItems(bool syncItems = false)
        {
            try
            {
                //バックエンドと同期する
                if (syncItems)
                {
                    await this.SyncAsync();
                }

                //ローカルのストア（SQLite）からデータを取得する
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
