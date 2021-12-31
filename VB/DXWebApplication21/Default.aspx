<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="DXWebApplication21.Default" %>

<%@ Register Assembly="DevExpress.Dashboard.v19.2.Web.WebForms, Version=19.2.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.DashboardWeb" TagPrefix="dx" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <title>Dashboard Web Application</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <link rel="stylesheet" type="text/css" href="Content/Site.css" />
</head>
<body runat="server" id="Body">
    <form id="form1" runat="server">
        <div style="position: absolute; left: 0; top: 0; right: 0; bottom: 0;">
            <dx:ASPxDashboard ID="ASPxDashboard1" runat="server" Width="100%" Height="100%" UseDashboardConfigurator="true" AllowCreateNewJsonConnection="true" UseNeutralFilterMode="true">
            </dx:ASPxDashboard>
        </div>
    </form>
</body>
</html>