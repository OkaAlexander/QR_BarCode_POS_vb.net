Imports System.Linq
Imports System.Web
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports pos_test.ServerModel

Namespace pos_test.Server
End Namespace
Public Class Server

    Dim serverModel As New ServerModel()
    Public Shared con As SqlConnection

    ''' <summary>
    ''' GET CONNECTION INSTANCE
    ''' </summary>
    ''' <returns></returns>
    Public Function Connection() As SqlConnection
        Try
            Dim constr As String = ConfigurationManager.ConnectionStrings("asp_pos").ConnectionString
            con = New SqlConnection(constr)
            Return con
        Catch ex As Exception
            Return con
        End Try
    End Function


    ''' <summary>
    ''' OPEN THE SERVER INSTANCE CONNECTION
    ''' </summary>
    Public Sub OpenConnection()
        If con.State = ConnectionState.Closed Then
            Connection.Open()
        End If
    End Sub


    ''' <summary>
    ''' CLOSE THE INSTANCE OF THE SQL CONNECTION
    ''' </summary>
    Public Sub CloseConnection()
        If con.State = ConnectionState.Open Then
            Connection.Close()
        End If
    End Sub
End Class
