Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity

Namespace DXWebApplication21
	Public Class MyJsonConnection
		<Key>
		<DatabaseGenerated(DatabaseGeneratedOption.Identity)>
		Public Property ID() As Integer
		Public Property Name() As String
		Public Property ConnectionString() As String
	End Class

	Friend Class JsonConnectionContext
		Inherits DbContext

		Public Property Connections() As DbSet(Of MyJsonConnection)
		Public Sub New()
			MyBase.New("ConnectionsStorage")
		End Sub
	End Class
End Namespace