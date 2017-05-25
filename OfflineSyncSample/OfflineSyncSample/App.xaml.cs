using Prism.Unity;
using OfflineSyncSample.Views;
using Xamarin.Forms;
using OfflineSyncSample.Services;
using Microsoft.Practices.Unity;

namespace OfflineSyncSample
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync("NavigationPage/MainPage?title=Hello%20from%20Xamarin.Forms");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<MainPage>();
			Container.RegisterType<IBookSyncManager, BookSyncManager>(new ContainerControlledLifetimeManager());

		}
    }
}
