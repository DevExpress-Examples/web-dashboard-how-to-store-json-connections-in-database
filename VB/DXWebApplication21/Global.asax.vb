Imports DevExpress.DashboardWeb
Imports System
Imports System.Configuration

Namespace DXWebApplication21

    Public Class Global_asax
        Inherits Web.HttpApplication

        Private Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
            Web.Routing.RouteTable.Routes.MapPageRoute("defaultRoute", "", "~/Default.aspx")
             ''' Cannot convert AssignmentExpressionSyntax, System.NullReferenceException: Object reference not set to an instance of an object.
'''    at ICSharpCode.CodeConverter.VB.NodesVisitor.VisitAssignmentExpression(AssignmentExpressionSyntax node) in D:\DXVCS\CSharpToVB\CSharpToVB\CodeConverter-master\CodeConverter\VB\NodesVisitor.cs:line 1211
'''    at Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
'''    at ICSharpCode.CodeConverter.VB.CommentConvertingVisitorWrapper`1.Accept(SyntaxNode csNode, Boolean addSourceMapping) in D:\DXVCS\CSharpToVB\CSharpToVB\CodeConverter-master\CodeConverter\VB\CommentConvertingVisitorWrapper.cs:line 26
''' 
''' Input:
'''             DevExpress.Web.ASPxWebControl.CallbackError += new System.EventHandler(this.Application_Error)
'''  ASPxDashboard.StaticInitialize()
            DashboardConfigurator.[Default].SetConnectionStringsProvider(New ConnectionStringsStorage(ConfigurationManager.ConnectionStrings("ConnectionsStorage").ConnectionString))
            Dim dashboardFileStorage As DashboardFileStorage = New DashboardFileStorage("~/App_Data/Dashboards")
            DashboardConfigurator.[Default].SetDashboardStorage(dashboardFileStorage)
        End Sub

        Private Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application shutdown
        End Sub

        Private Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when an unhandled error occurs
        End Sub
    End Class
End Namespace
