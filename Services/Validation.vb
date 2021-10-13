Imports System
Imports System.Collections.Generic
Imports System.Web
Imports System.Linq
Imports pos_test.ProductModel
Namespace pos_test.Services
End Namespace
Public Class Validation

    Public Function ValidateProductDetails(ByVal model As ProductModel) As ProductModel
        Dim validPrice As Integer = 0

        If model.handleName.Length <= 0 Then
            model.handleIsValid = False
            model.handleErrorMessage = "Please enter the product name"
            Return model
        ElseIf Not Integer.TryParse(model.handleSP, validPrice) Then
            model.handleIsValid = False
            model.handleErrorMessage = "Invalid Selling Price only numbers required"
            Return model
        ElseIf Not Integer.TryParse(model.handleCP, validPrice) Then
            model.handleIsValid = False
            model.handleErrorMessage = "Invalid Cost Price only numbers required"
            Return model
        Else
            model.handleIsValid = True
            model.handleErrorMessage = ""
            Return model
        End If
    End Function


End Class
