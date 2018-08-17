using System.Web;
using System.Web.Optimization;

namespace RescueNeeds
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/vendor/jquery/jquery.min.js",
                        "~/vendor/bootstrap/js/bootstrap.bundle.min.js",
                        "~/vendor/jquery-easing/jquery.easing.min.js",
                        "~/vendor/chart.js/Chart.min.js",
                        "~/vendor/datatables/jquery.dataTables.js",
                        "~/vendor/datatables/dataTables.bootstrap4.js",
                        "~/Scripts/sb-admin.min.js",
                        "~/Scripts/demo/datatables-demo.js"

                        ));

         

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/vendor/bootstrap/css/bootstrap.min.css",
                      "~/vendor/fontawesome-free/css/all.min.css",
                      "~/vendor/datatables/dataTables.bootstrap4.css",
                      "~/Content/sb-admin.css"));
        }
    }
}
