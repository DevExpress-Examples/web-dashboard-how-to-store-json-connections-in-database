<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/223372590/19.2.5%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T835184)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

# Dashboard for Web Forms - How to store JSON connections in a database

This example demonstrates how to create new JSON connections in Web Dashboard's Data Source wizard and store them in a database.

<!-- default file list -->
## Files to Look At

* [ConnectionStringsStorage.cs](./CS/DXWebApplication21/ConnectionStringsStorage.cs) (VB: [ConnectionStringsStorage.vb](./VB/DXWebApplication21/ConnectionStringsStorage.vb))
* [MyJsonConnection.cs](./CS/DXWebApplication21/MyJsonConnection.cs) (VB: [MyJsonConnection.vb](./VB/DXWebApplication21/MyJsonConnection.vb))
* [Global.asax.cs](./CS/DXWebApplication21/Global.asax.cs) (VB: [Global.asax.vb](./VB/DXWebApplication21/Global.asax.vb))
<!-- default file list end -->

Set the [ASPxDashboard.AllowCreateNewJsonConnection](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWeb.ASPxDashboard.AllowCreateNewJsonConnection) property to True to allow creating new JSON connections. Implement the [IDataSourceWizardConnectionStringsStorage](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWeb.IDataSourceWizardConnectionStringsStorage) interface to create custom connection string storage, and use the ASPxDashboard or DashboardConfigurator's [SetConnectionStringsProvider](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWeb.DashboardConfigurator.SetConnectionStringsProvider.overloads) method to assign it to the Web Dashboard.

In this example, connections are stored in a database using Entity Framework. To run the example, modify the "ConnectionStorage" connection string in [Web.config](./CS/DXWebApplication21/Web.config#L26).

## Documentation

- [Dashboard Data Source Wizard](https://docs.devexpress.com/Dashboard/117680/web-dashboard/ui-elements-and-customization/dialogs-and-wizards/dashboard-data-source-wizard)
- [Specify Data Source Settings (JSON)](https://docs.devexpress.com/Dashboard/401401/web-dashboard/ui-elements-and-customization/dialogs-and-wizards/dashboard-data-source-wizard/specify-data-source-settings-json)

## More Examples

- [Dashboard for MVC - How to store JSON connections in a database](https://github.com/DevExpress-Examples/mvc-dashboard-how-to-store-connections-in-database/)
