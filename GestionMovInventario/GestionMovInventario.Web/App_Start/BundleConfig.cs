using System.Web;
using System.Web.Optimization;

namespace GestionMovInventario
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-3.7.0.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap.bundle.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                        "~/Scripts/custom.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/bootstrap.min.css",
                        "~/Content/bootstrap-icons.css",
                         "~/Content/custom.css",
                        "~/Content/Site.css"));
        }
    }
}
