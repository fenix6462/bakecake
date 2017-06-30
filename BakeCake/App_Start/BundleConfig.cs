using System.Web;
using System.Web.Optimization;

namespace BakeCake
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Content/js").Include(
                      "~/Content/js/jquery.min.js",
                      "~/Content/js/bootstrap.min.js",
                      "~/Scripts/js/custom.js"));

            bundles.Add(new ScriptBundle("~/Content/angular").Include(
                      "~/Content/js/angular.min.js",
                      "~/Content/js/angular-route.min.js",
                      "~/Content/js/ui-bootstrap-tpls-2.5.0.min.js",
                      "~/Content/ng/app.js",
                      "~/Content/ng/router.js",
                      "~/Content/ng/controllers/*.js",
                      "~/Content/ng/directives/*.js",
                      "~/Content/ng/filters/*.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/bootstrap.min.css",
                      "~/Content/css/font-awesome.min.css",
                      "~/Content/css/sb-admin.css",
                      "~/Content/css/custom.css"
                      ));
        }
    }
}
