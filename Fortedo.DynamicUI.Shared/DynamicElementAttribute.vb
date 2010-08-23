Public Class DynamicElementAttribute
    Inherits Attribute

    Private _name As String

    Public Sub New()
    End Sub

    Public Sub New(ByVal name As String)
        _name = name
    End Sub

    Public ReadOnly Property Name() As String
        Get
            Return _name
        End Get
    End Property

    Public Property View() As Type
End Class
