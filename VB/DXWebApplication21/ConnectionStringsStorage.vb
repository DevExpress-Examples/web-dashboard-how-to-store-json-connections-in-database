Imports DevExpress.DashboardCommon
Imports DevExpress.DashboardWeb
Imports DevExpress.DataAccess.ConnectionParameters
Imports DevExpress.DataAccess.Json
Imports DevExpress.DataAccess.Web
Imports System
Imports System.Collections.Generic
Imports System.Configuration
Imports System.Data
Imports System.Data.Entity
Imports System.Linq

Namespace DXWebApplication21
	Public Class ConnectionStringsStorage
		Implements IDataSourceWizardConnectionStringsStorage

'INSTANT VB NOTE: The field storage was renamed since Visual Basic does not allow fields to have the same name as other class members:
		Private Shared storage_Renamed As Dictionary(Of String, DataConnectionParametersBase)
		Private connectionString As String
		Private Shared ReadOnly Property Storage() As Dictionary(Of String, DataConnectionParametersBase)
			Get
				If storage_Renamed Is Nothing Then
					storage_Renamed = New Dictionary(Of String, DataConnectionParametersBase)()
				End If
				Return storage_Renamed
			End Get
		End Property
		Public Sub New(ByVal connectionString As String)
			storage_Renamed = CreateNewStorage()
			Me.connectionString = connectionString
		End Sub

		Private Function CreateNewStorage() As Dictionary(Of String, DataConnectionParametersBase)
			Dim dictionary = New Dictionary(Of String, DataConnectionParametersBase)()

			' Load existing SQL Connection Strings from Web.config
			For Each connectionStringSettings As ConnectionStringSettings In ConfigurationManager.ConnectionStrings
				dictionary.Add(connectionStringSettings.Name, New CustomStringConnectionParameters(connectionStringSettings.ConnectionString))
			Next connectionStringSettings

			' Add predefined JSON connections
			Dim jsonConnectionParams = New JsonSourceConnectionParameters()
			jsonConnectionParams.JsonSource = New UriJsonSource(New Uri("https://raw.githubusercontent.com/DevExpress-Examples/DataSources/master/JSON/customers.json"))
			dictionary.Add("Customers_JSON", jsonConnectionParams)

			' Load JSON connections from a DB
			Using context As New JsonConnectionContext()
				context.Connections.ToList().ForEach(Sub(c)
					If Not dictionary.ContainsKey(c.Name) Then
						dictionary.Add(c.Name, New CustomStringConnectionParameters(c.ConnectionString))
					Else
						dictionary(c.Name) = New CustomStringConnectionParameters(c.ConnectionString)
					End If
				End Sub)
			End Using

			Return dictionary
		End Function

		Private Function IDataSourceWizardConnectionStringsProvider_GetConnectionDescriptions() As Dictionary(Of String, String) Implements IDataSourceWizardConnectionStringsProvider.GetConnectionDescriptions
			Return Storage.Keys.ToDictionary(Function(key) key, Function(value) value)
		End Function

		Private Function IDataSourceWizardConnectionStringsProvider_GetDataConnectionParameters(ByVal name As String) As DataConnectionParametersBase Implements IDataSourceWizardConnectionStringsProvider.GetDataConnectionParameters
			Return Storage(name)
		End Function

		' Save JSON connections to a DB
		Private Sub IDataSourceWizardConnectionStringsStorage_SaveDataConnectionParameters(ByVal name As String, ByVal connectionParameters As DataConnectionParametersBase, ByVal saveCredentials As Boolean) Implements IDataSourceWizardConnectionStringsStorage.SaveDataConnectionParameters
			Dim jsonParams As JsonSourceConnectionParameters = TryCast(connectionParameters, JsonSourceConnectionParameters)
			If jsonParams IsNot Nothing Then
				Using context As New JsonConnectionContext()
					Dim dataConnection As New JsonDataConnection(jsonParams.JsonSource)

					Dim existingConnection = context.Connections.Where(Function(c) c.Name = name).FirstOrDefault()
					If existingConnection Is Nothing Then
						Dim jsonConnection As New MyJsonConnection()
						jsonConnection.Name = name
						jsonConnection.ConnectionString = dataConnection.CreateConnectionString()
						context.Connections.Add(jsonConnection)
					Else
						existingConnection.ConnectionString = dataConnection.CreateConnectionString()
					End If
					context.SaveChanges()
				End Using

				Storage(name) = New CustomStringConnectionParameters(connectionString)
			End If
		End Sub
	End Class
End Namespace