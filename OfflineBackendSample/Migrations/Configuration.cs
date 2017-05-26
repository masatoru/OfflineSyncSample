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
                  Title = "C#�ɂ��iOS�AAndroid�AWindows�A�v���P�[�V�����J������",
                  Company = "���oBP��"
              },
              new BookItem
              {
                  Id = "2",
                  Title = "Xamarin�G�L�X�p�[�g�{���ǖ{",
                  Company = "�Z�p�]�_��"
              },
              new BookItem
              {
                  Id = "3",
                  Title = "Xamarin�ł͂��߂�X�}�z�A�v���J��",
                  Company = "�H�w��"
              }, new BookItem
              {
                  Id = "4",
                  Title = "Essential Xamarin Yin/�A",
                  Company = "Xamaritans"
              }, new BookItem
              {
                  Id = "5",
                  Title = "Essential Xamarin Yang/�z",
                  Company = "Xamaritans"
              }, new BookItem
              {
                  Id = "6",
                  Title = "�v���O���~���O Xamarin ��",
                  Company = "���oBP��"
              }
            );

        }
    }
}
