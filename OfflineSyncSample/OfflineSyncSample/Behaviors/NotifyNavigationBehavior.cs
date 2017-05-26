using System;
using Xamarin.Forms;

namespace OfflineSyncSample.Behaviors
{
    public class NotifyNavigationBehavior : BindableBehavior<Page>
    {
        protected override void OnAttachedTo(Page bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.Appearing += OnAppearing;
            bindable.Disappearing += OnDisappearing;
        }

        protected override void OnDetachingFrom(Page bindable)
        {
            bindable.Disappearing -= OnDisappearing;
            bindable.Appearing -= OnAppearing;
            base.OnDetachingFrom(bindable);
        }

        private void OnAppearing(object sender, EventArgs eventArgs)
        {
            (AssociatedObject.BindingContext as IAppearingAware)?.OnAppearing();
        }

        private void OnDisappearing(object sender, EventArgs eventArgs)
        {
            (AssociatedObject.BindingContext as IDisappearingAware)?.OnDisappearing();
        }
    }
}
