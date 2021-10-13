Imports System.Linq
Imports System.Web
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports pos_test.Server
Imports pos_test.ProductModel
Imports pos_test.ServerModel
Public Class handleProduct
    Dim serverModel As New ServerModel()
    Dim server As New Server()
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="model"></param>
    ''' <returns></returns>
    Public Function RegisterProduct(ByVal model As ProductModel) As String
        Server.con = New SqlConnection()
        Server.con = server.Connection()
        Try
            serverModel.handleCommand = New SqlCommand("INSERT INTO Products(ProductID,ProductName,SellingPrice,CostPrice) VALUES(@pid,@pname,@psp,@pcp)", Server.con)
            serverModel.handleCommand.Parameters.Add("@pid", SqlDbType.VarChar).Value = model.handleID
            serverModel.handleCommand.Parameters.Add("@pname", SqlDbType.VarChar).Value = model.handleName
            serverModel.handleCommand.Parameters.Add("@psp", SqlDbType.VarChar).Value = model.handleSP
            serverModel.handleCommand.Parameters.Add("@pcp", SqlDbType.VarChar).Value = model.handleCP
            Server.con.Open()
            serverModel.handleCommand.ExecuteNonQuery()
            Server.con.Close()
            Return "Item successfully added"
        Catch ex As Exception
            server.CloseConnection()
            Return ex.Message
        End Try
    End Function


    ''' <summary>
    ''' GET ALL DATA IN THE PRODUCTS TABLE
    ''' </summary>
    ''' <returns></returns>
    Public Function GetAllProduct() As DataTable
        serverModel.handleTable = New DataTable()
        serverModel.handleAdapter = New SqlDataAdapter()
        Server.con = New SqlConnection()
        Server.con = server.Connection()
        Try
            serverModel.handleCommand = New SqlCommand("SELECT * FROM Products", Server.con)
            Server.con.Open()
            serverModel.handleAdapter.SelectCommand = serverModel.handleCommand
            serverModel.handleAdapter.Fill(serverModel.handleTable)
            Server.con.Close()
            Return serverModel.handleTable
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            Server.con.Close()
            Return serverModel.handleTable
        End Try

    End Function

    Public Function GetProductByProductID(ByVal model As ProductModel) As DataTable
        serverModel.handleTable = New DataTable()
        serverModel.handleAdapter = New SqlDataAdapter()

        Try
            serverModel.handleCommand = New SqlCommand("SELECT * FROM Products WHERE ProductID=@id", server.Connection())
            serverModel.handleCommand.Parameters.Add("@id", SqlDbType.VarChar).Value = model.handleID
            serverModel.handleAdapter.SelectCommand = serverModel.handleCommand
            serverModel.handleAdapter.Fill(serverModel.handleTable)
            Return serverModel.handleTable
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            Return serverModel.handleTable
        End Try
    End Function


    ''' <summary>
    ''' LOAD PRODUCT DETAILS
    ''' </summary>
    ''' <paramname="table"></param>
    ''' <returns></returns>
    Public Function LoadProductInfo(ByVal table As DataTable) As ProductModel
        Dim model As ProductModel = New ProductModel()

        If table.Rows.Count > 0 Then

            For Each dataRow As DataRow In table.Rows
                model.handleID = dataRow("ProductID").ToString()
                model.handleName = dataRow("ProductName").ToString()
                model.handleSP = dataRow("SellingPrice").ToString()
                model.handleCP = dataRow("CostPrice").ToString()
                model.handleIsValid = True
                model.handleErrorMessage = ""
            Next

            Return model
        Else
            model.handleErrorMessage = "Product not found"
            model.handleIsValid = False
            Return model
        End If
    End Function


    ''' <summary>
    ''' GENERATE THE PRODUCT ID
    ''' </summary>
    ''' <paramname="table"></param>
    ''' <returns></returns>
    Public Function GenerateProductId(ByVal table As DataTable) As String
        If table.Rows.Count >= 10 Then
            Return String.Format("PID{0}", table.Rows.Count + 1)
        Else
            Return String.Format("PID0{0}", table.Rows.Count + 1)
        End If
    End Function



    ''' <summary>
    ''' FORMAT THE PRODUCT ID;
    ''' </summary>
    ''' <paramname="pid"></param>
    ''' <paramname="model"></param>
    ''' <returns></returns>
    Public Function FormatProductDetails(ByVal pid As String, ByVal model As ProductModel) As ProductModel
        model.handleID = pid
        Return model
    End Function
End Class
