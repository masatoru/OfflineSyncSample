using System;
namespace OfflineSyncSample.Behaviors
{
    public interface IAppearingAware
    {
        void OnAppearing();
    }
    public interface IDisappearingAware
    {
        void OnDisappearing();
    }
}
