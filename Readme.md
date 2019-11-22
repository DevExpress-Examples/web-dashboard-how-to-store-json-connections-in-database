<!-- default file list -->
*Files to look at*:

* [ConnectionStringsStorage.cs](./CS/DXWebApplication21/ConnectionStringsStorage.cs) (VB: [ConnectionStringsStorage.vb](./VB/DXWebApplication21/ConnectionStringsStorage.vb))
* [MyJsonConnection.cs](./CS/DXWebApplication21/MyJsonConnection.cs) (VB: [MyJsonConnection.vb](./VB/DXWebApplication21/MyJsonConnection.vb))
* [Global.asax.cs](./CS/DXWebApplication21/Global.asax.cs) (VB: [Global.asax.vb](./VB/DXWebApplication21/Global.asax.vb))

<!-- default file list end -->
# Web Dashboard - How to store JSON connections in a database

This example demonstrates how to create new JSON connections in Web Dashboard's Data Source wizard and store them in a database.

Implement the [IDataSourceWizardConnectionStringsStorage](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWeb.IDataSourceWizardConnectionStringsStorage) interface to create custom connection string storage, and use the ASPxDashboard or DashboardConfigurator's [SetConnectionStringsProvider](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWeb.DashboardConfigurator.SetConnectionStringsProvider.overloads) method to assign it to the Web Dashboard.

In this example, connections are stored in a database using Entity Framework. To run the example, modify the "ConnectionStorage" connection string in [Web.config](./CS/DXWebApplication21/Web.config#L26).
