using DevExpress.DashboardWeb;
using System;
using System.Configuration;

namespace DXWebApplication21 {
    public class Global_asax : System.Web.HttpApplication {
        void Application_Start(object sender, EventArgs e) {
            System.Web.Routing.RouteTable.Routes.MapPageRoute("defaultRoute", "", "~/Default.aspx");
            DevExpress.Web.ASPxWebControl.CallbackError += new EventHandler(Application_Error);

            ASPxDashboard.StaticInitialize();

            DashboardConfigurator.Default.SetConnectionStringsProvider(
              new ConnectionStringsStorage(ConfigurationManager.ConnectionStrings["ConnectionsStorage"].ConnectionString));

            DashboardFileStorage dashboardFileStorage = new DashboardFileStorage("~/App_Data/Dashboards");
            DashboardConfigurator.Default.SetDashboardStorage(dashboardFileStorage);
        }

        void Application_End(object sender, EventArgs e) {
            // Code that runs on application shutdown
        }

        void Application_Error(object sender, EventArgs e) {
            // Code that runs when an unhandled error occurs
        }
    }
}