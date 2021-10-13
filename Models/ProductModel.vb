Public Class ProductModel
    Private ProductID As String
    Public Property handleID() As String
        Get
            Return ProductID
        End Get
        Set(ByVal value As String)
            ProductID = value
        End Set
    End Property
    Private ProductName As String
    Public Property handleName() As String
        Get
            Return ProductName
        End Get
        Set(ByVal value As String)
            ProductName = value
        End Set
    End Property

    Private SellingPrice As String
    Public Property handleSP() As String
        Get
            Return SellingPrice
        End Get
        Set(ByVal value As String)
            SellingPrice = value
        End Set
    End Property

    Private CostPrice As String
    Public Property handleCP() As String
        Get
            Return CostPrice
        End Get
        Set(ByVal value As String)
            CostPrice = value
        End Set
    End Property

    Private isValid As Boolean
    Public Property handleIsValid() As Boolean
        Get
            Return isValid
        End Get
        Set(ByVal value As Boolean)
            isValid = value
        End Set
    End Property

    Private ErrorMessage As String
    Public Property handleErrorMessage() As String
        Get
            Return ErrorMessage
        End Get
        Set(ByVal value As String)
            ErrorMessage = value
        End Set
    End Property
End Class
