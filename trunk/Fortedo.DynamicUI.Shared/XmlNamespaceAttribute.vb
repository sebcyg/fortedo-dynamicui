<AttributeUsage(AttributeTargets.Assembly, AllowMultiple:=True)>
Public Class XmlNamespaceAttribute
    Inherits Attribute

    Public Property XmlNamespace As String
    Public Property ClrNamespaces As String()

    Public Sub New(ByVal xmlNamespace As String, ByVal ParamArray clrNamespaces As String())
        Me.XmlNamespace = xmlNamespace
        Me.ClrNamespaces = clrNamespaces
    End Sub
End Class
