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

        }
    }
}
