using System.Web;
using System.Web.Optimization;

namespace WebAppGeneric
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                       
                       "~/Scripts/jquery-3.3.1.js",
                       "~/Scripts/jquery-3.3.1.min.js",
                       "~/Scripts/menu.js",
                       "~/Scripts/sweetalert2.all.min.js",
                       "~/Scripts/sweetalert2.common.min.js",
                       "~/Scripts/DataTables/jquery.dataTables.js",
                       "~/Content/Buttons-1.5.6/js/dataTables.buttons.min.js",
                       "~/Content/Buttons-1.5.6/js/buttons.html5.min.js",
                       "~/Content/Buttons-1.5.6/js/buttons.colVis.min.js",
                       "~/Content/Buttons-1.5.6/js/buttons.flash.min.js",
                       "~/Content/Buttons-1.5.6/js/buttons.print.min.js",
                        "~/Scripts/Ajax/jszip.min.js",
                        "~/Scripts/Ajax/pdfmake.min.js",
                        "~/Scripts/Ajax/vfs_fonts.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                    // "~/Content/bootstrap.css",
                     "~/Content/bootstrap-spacelab.css",
                     "~/Content/styleMenu.css",
                     "~/Content/styleTableNested.css",
                     "~/Content/sweetalert2.min.css",
                      "~/Content/side-modal.css",
                      "~/Content/DataTables/css/jquery.dataTables.css",
                     "~/Content/Buttons-1.5.6/css/buttons.dataTables.min.css",
                     "~/Content/site.css"));
        }
    }
}
