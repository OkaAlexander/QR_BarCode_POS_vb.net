Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports System.Threading
Imports ZXing

Namespace pos_test.Controllers
End Namespace
Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Dim smodel As New ServerModel()
    Dim hproduct As New handleProduct()

    Dim validation As Validation = New Validation()


    Public Function Index() As ActionResult
        Return View()
    End Function

    <HttpPost>
    <AllowAnonymous>
    Public Function Index(ByVal collection As FormCollection) As ActionResult
        Dim pmodel As ProductModel = New ProductModel()
        Dim method As String = collection("hidden").ToString()

        Select Case method

            Case "search"
                pmodel.handleID = collection("productID").ToString()
                'model.productID = "PID05";
                pmodel = hproduct.LoadProductInfo(hproduct.GetProductByProductID(pmodel))
                If pmodel.handleIsValid Then
                    ViewBag.pid = pmodel.handleID
                    ViewBag.pname = pmodel.handleName
                    ViewBag.psp = pmodel.handleSP
                    ViewBag.pcp = pmodel.handleCP
                    ViewBag.result = pmodel.handleErrorMessage
                    Return View()
                Else
                    ViewBag.result = pmodel.handleErrorMessage
                    Return View()
                End If

            Case "register"
                Dim pname As String = collection("pname").ToString()
                Dim psp As String = collection("psp").ToString()
                Dim pcp As String = collection("pcp").ToString()
                pmodel.handleName = pname
                pmodel.handleSP = psp
                pmodel.handleCP = pcp
                pmodel = validation.ValidateProductDetails(pmodel)

                If pmodel.handleIsValid Then
                    pmodel.handleID = hproduct.GenerateProductId(hproduct.GetAllProduct())
                    Dim output As String = hproduct.RegisterProduct(pmodel)
                    ViewBag.results = output
                    Dim writer As BarcodeWriter = New BarcodeWriter() With {
                        .Format = BarcodeFormat.CODE_128
                    }
                    Dim qrname As String = String.Format("{0}.PNG", pmodel.handleName)

                    Try
                        writer.Write(pmodel.handleID).Save("C:\Users\alexa\OneDrive\Desktop\BARCodeResources\" & qrname)
                    Catch ex As Exception
                        ViewBag.results = ex.Message
                        Return View()
                    End Try

                    Thread.Sleep(1000)
                    Return View()
                Else
                    ViewBag.results = pmodel.handleErrorMessage
                    Return View()
                End If

            Case Else
                Dim pnamed As String = collection("pname").ToString()
                Dim pspd As String = collection("psp").ToString()
                Dim pcpd As String = collection("pcp").ToString()
                pmodel.handleName = pnamed
                pmodel.handleSP = pspd
                pmodel.handleCP = pcpd
                pmodel = validation.ValidateProductDetails(pmodel)

                If pmodel.handleIsValid Then
                    pmodel.handleID = hproduct.GenerateProductId(hproduct.GetAllProduct())
                    Dim output As String = hproduct.RegisterProduct(pmodel)
                    ViewBag.results = output
                    Dim writer As BarcodeWriter = New BarcodeWriter() With {
                        .Format = BarcodeFormat.QR_CODE
                    }
                    Dim qrname As String = String.Format("{0}.PNG", pmodel.handleName)

                    Try
                        writer.Write(pmodel.handleID).Save("C:\Users\alexa\OneDrive\Desktop\QRCodeResources\" & qrname)
                    Catch ex As Exception
                        ViewBag.results = ex.Message
                        Return View()
                    End Try

                    Thread.Sleep(1000)
                    Return View()
                Else
                    ViewBag.results = pmodel.handleErrorMessage
                    Return View()
                End If
        End Select
    End Function

    Public Function About() As ActionResult
        ViewBag.Message = "Your application description page."
        Return View()
    End Function

    Public Function Contact() As ActionResult
        ViewBag.Message = "Your contact page."
        Return View()
    End Function
End Class
