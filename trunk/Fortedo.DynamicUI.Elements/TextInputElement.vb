Imports Fortedo.DynamicUI.Shared

<DynamicElement(View:=GetType(Views.TextInputView))>
Public Class TextInputElement
    Inherits DynamicElementBase

    Private _text As String

    Public Property Text As String
        Get
            If _text Is Nothing Then
                If TypeOf (Context) Is XText Then
                    _text = CType(Context, XText).Value
                ElseIf TypeOf (Context) Is XElement Then
                    _text = CType(Context, XElement).Value
                Else
                    _text = ""
                End If
            End If
            Return _text
        End Get
        Set(ByVal value As String)
            _text = value
        End Set
    End Property
End Class