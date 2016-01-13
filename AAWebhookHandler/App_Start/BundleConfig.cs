using System.Web;
using System.Web.Optimization;

namespace AAWebhookHandler
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();
            
            bundles.Add(new StyleBundle("~/Content/style").Include(
                        "~/Content/css/style.css",
                        "~/Content/fonts/font-awesome-4.2.0/css/font-awesome.min.css"));

        }
    }
}