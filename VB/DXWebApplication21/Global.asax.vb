Imports DevExpress.DashboardWeb
Imports System
Imports System.Configuration

Namespace DXWebApplication21
	Public Class Global_asax
		Inherits System.Web.HttpApplication

		Private Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
			System.Web.Routing.RouteTable.Routes.MapPageRoute("defaultRoute", "", "~/Default.aspx")
			AddHandler DevExpress.Web.ASPxWebControl.CallbackError, AddressOf Application_Error

			ASPxDashboard.StaticInitialize()

			DashboardConfigurator.Default.SetConnectionStringsProvider(New ConnectionStringsStorage(ConfigurationManager.ConnectionStrings("ConnectionsStorage").ConnectionString))

			Dim dashboardFileStorage As New DashboardFileStorage("~/App_Data/Dashboards")
			DashboardConfigurator.Default.SetDashboardStorage(dashboardFileStorage)
		End Sub

		Private Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
			' Code that runs on application shutdown
		End Sub

		Private Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
			' Code that runs when an unhandled error occurs
		End Sub
	End Class
End Namespace