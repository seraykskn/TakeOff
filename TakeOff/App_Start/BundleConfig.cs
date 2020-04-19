using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Optimization;
using System.Web;

namespace TakeOff.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Tema/css").Include(
                "~/Templates/assets/css/material-dashboard.css",
                "~/Templates/assets/css/material-dashboard.min.css"
                
                ));

            bundles.Add(new ScriptBundle("~/Tema/js").Include(
               "~/Templates/assets/js/material-dashboard.js",
                "~/Templates/assets/js/material-dashboard.min.js",
                "~/Templates/assets/js/chart.js",
                "~/Templates/assets/js/misc.js",
                "~/Templates/assets/js/off-canvas.js"
                ));
            BundleTable.EnableOptimizations = true;
        }
    }
}