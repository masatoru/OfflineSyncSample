using Foundation;
using OfflineSyncSample.iOS.Platforms;
using Xamarin.Forms;
using OfflineSyncSample.Models;

[assembly: Dependency(typeof(HtmlPath_iOS))]
namespace OfflineSyncSample.iOS.Platforms
{
    public class HtmlPath_iOS : IHtmlPath
    {
        public string GetHtmlPath()
        {
            return NSBundle.MainBundle.BundleUrl.ToString();
        }
    }
}