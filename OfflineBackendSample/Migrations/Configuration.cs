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
            context.HeadingItems.AddOrUpdate(
                p => p.Id,
                new HeadingItem()
                {
                    Id = "001",
                    BookId = "1",
                    Title = "��P�́@�N���X�v���b�g�t�H�[���J����C#��"
                },
                new HeadingItem()
                {
                    Id = "002",
                    BookId = "1",
                    Title = "��Q�́@Xamarin�Ƃ�"
                },
                new HeadingItem()
                {
                    Id = "003",
                    BookId = "1",
                    Title = "��R�́@�J�����𐮂���"
                },
                new HeadingItem()
                {
                    Id = "004",
                    BookId = "1",
                    Title = "��S�́@�N���X�v���b�g�t�H�[���J����C#��"
                },
                new HeadingItem()
                {
                    Id = "005",
                    BookId = "1",
                    Title = "��T�́@��ʂ��쐬����"
                },
                new HeadingItem()
                {
                    Id = "006",
                    BookId = "1",
                    Title = "��U�́@���ʃ��W�b�N���쐬����"
                },
                new HeadingItem()
                {
                    Id = "007",
                    BookId = "1",
                    Title = "��V�́@�ʃ��W�b�N���쐬����"
                },
                new HeadingItem()
                {
                    Id = "008",
                    BookId = "1",
                    Title = "��W�́@���[�J���t�@�C���ɃA�N�Z�X����"
                },
                new HeadingItem()
                {
                    Id = "009",
                    BookId = "1",
                    Title = "��X�́@���o�C���T�[�r�X���g��"
                },
                new HeadingItem()
                {
                    Id = "010",
                    BookId = "1",
                    Title = "��10�́@�܂Ƃ�"
                }, new HeadingItem()
                {
                    Id = "011",
                    BookId = "2",
                    Title = "���W�P�@Xamarin�̂��߂�C#����"
                },
                new HeadingItem()
                {
                    Id = "012",
                    BookId = "2",
                    Title = "���W�Q�@Xamarin�ɂ��N���X�v���b�g�t�H�[���J��"
                },
                new HeadingItem()
                {
                    Id = "013",
                    BookId = "2",
                    Title = "���W�R�@��l��������N���X�v���b�g�t�H�[���J���̊�"
                },
                new HeadingItem()
                {
                    Id = "014",
                    BookId = "2",
                    Title = "���W�S�@�����s�����v���b�g�t�H�[���J���̃|�C���g"
                }

            );
        }
    }
}
