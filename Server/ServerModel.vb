Imports System.Linq
Imports System.Web
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Namespace pos_test.ServerModel
End Namespace
Public Class ServerModel
    Private con As SqlConnection
    Public Property handleCon() As SqlConnection
        Get
            Return con
        End Get
        Set(ByVal value As SqlConnection)
            con = value
        End Set
    End Property

    Private command As New SqlCommand()
    Public Property handleCommand() As SqlCommand
        Get
            Return command
        End Get
        Set(ByVal value As SqlCommand)
            command = value
        End Set
    End Property

    Private table As New DataTable()
    Public Property handleTable() As DataTable
        Get
            Return table
        End Get
        Set(ByVal value As DataTable)
            table = value
        End Set
    End Property
    Private adatpter As SqlDataAdapter
    Public Property handleAdapter() As SqlDataAdapter
        Get
            Return adatpter
        End Get
        Set(ByVal value As SqlDataAdapter)
            adatpter = value
        End Set
    End Property
End Class
