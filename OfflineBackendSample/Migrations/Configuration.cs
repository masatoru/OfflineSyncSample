using Microsoft.Azure.Mobile.Server.Tables;
using OfflineBackendSample.DataObjects;

namespace OfflineBackendSample.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OfflineBackendSample.Models.MobileServiceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            SetSqlGenerator("System.Data.SqlClient", new EntityTableSqlGenerator());
            ContextKey = "OfflineBackendSample.Models.MobileServiceContext";
        }

        protected override void Seed(OfflineBackendSample.Models.MobileServiceContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.BookItems.AddOrUpdate(
              p => p.Id,
              new BookItem
              {
                  Id = "1",
                  Title = "C#によるiOS、Android、Windowsアプリケーション開発入門",
                  Company = "日経BP社"
              },
              new BookItem
              {
                  Id = "2",
                  Title = "Xamarinエキスパート養成読本",
                  Company = "技術評論社"
              },
              new BookItem
              {
                  Id = "3",
                  Title = "Xamarinではじめるスマホアプリ開発",
                  Company = "工学社"
              }, new BookItem
              {
                  Id = "4",
                  Title = "Essential Xamarin Yin/陰",
                  Company = "Xamaritans"
              }, new BookItem
              {
                  Id = "5",
                  Title = "Essential Xamarin Yang/陽",
                  Company = "Xamaritans"
              }, new BookItem
              {
                  Id = "6",
                  Title = "プログラミング Xamarin 上",
                  Company = "日経BP社"
              }
            );
            context.HeadingItems.AddOrUpdate(
                p => p.Id,
                new HeadingItem()
                {
                    Id = "001",
                    BookId = "1",
                    Title = "第１章　クロスプラットフォーム開発をC#で"
                },
                new HeadingItem()
                {
                    Id = "002",
                    BookId = "1",
                    Title = "第２章　Xamarinとは"
                },
                new HeadingItem()
                {
                    Id = "003",
                    BookId = "1",
                    Title = "第３章　開発環境を整える"
                },
                new HeadingItem()
                {
                    Id = "004",
                    BookId = "1",
                    Title = "第４章　クロスプラットフォーム開発をC#で"
                },
                new HeadingItem()
                {
                    Id = "005",
                    BookId = "1",
                    Title = "第５章　画面を作成する"
                },
                new HeadingItem()
                {
                    Id = "006",
                    BookId = "1",
                    Title = "第６章　共通ロジックを作成する"
                },
                new HeadingItem()
                {
                    Id = "007",
                    BookId = "1",
                    Title = "第７章　個別ロジックを作成する"
                },
                new HeadingItem()
                {
                    Id = "008",
                    BookId = "1",
                    Title = "第８章　ローカルファイルにアクセスする"
                },
                new HeadingItem()
                {
                    Id = "009",
                    BookId = "1",
                    Title = "第９章　モバイルサービスを使う"
                },
                new HeadingItem()
                {
                    Id = "010",
                    BookId = "1",
                    Title = "第10章　まとめ"
                }, new HeadingItem()
                {
                    Id = "011",
                    BookId = "2",
                    Title = "特集１　XamarinのためのC#入門"
                },
                new HeadingItem()
                {
                    Id = "012",
                    BookId = "2",
                    Title = "特集２　Xamarinによるクロスプラットフォーム開発"
                },
                new HeadingItem()
                {
                    Id = "013",
                    BookId = "2",
                    Title = "特集３　先人が教えるクロスプラットフォーム開発の肝"
                },
                new HeadingItem()
                {
                    Id = "014",
                    BookId = "2",
                    Title = "特集４　一歩先行く黒プラットフォーム開発のポイント"
                }

            );
        }
    }
}
