Imports System.Xml.XPath.Extensions
Imports Ninject
Imports Ninject.Parameters

Public MustInherit Class DynamicElementBase
    Implements IDynamicElement

    <Inject()>
    Public Property Kernel As IKernel

    Private _context As Object

    Public Overridable Property Context As Object Implements IDynamicElement.Context
        Get
            Return _context
        End Get
        Set(ByVal value As Object)
            If String.IsNullOrEmpty(Path) Then
                _context = value
            Else
                Dim el As XElement = value
                Dim result = CType(el.XPathEvaluate(Path), IEnumerable).OfType(Of Object)().ToList()
                If result.Count = 0 Then
                    _context = Nothing
                ElseIf result.Count = 1 Then
                    _context = result.First()
                Else
                    _context = result
                End If
            End If
        End Set
    End Property

    Public Property Label As String Implements IDynamicElement.Label
    Public Property Name As String Implements IDynamicElement.Name
    Public Property Path As String Implements IDynamicElement.Path

    Public Overridable Sub SetDefinition(ByVal definition As System.Xml.Linq.XElement) Implements IDynamicElement.SetDefinition
        Label = definition.@Label
        Name = definition.@Name
        Path = definition.@Path
    End Sub

    Public Overridable Function GetData() As System.Xml.Linq.XElement Implements IDynamicElement.GetData
        Return New XElement(Name)
    End Function

    Private _view As IDynamicView

    Public ReadOnly Property View() As Object Implements IDynamicElement.View
        Get
            If _view Is Nothing Then
                _view = Kernel.TryGet(Of IDynamicView)(Me.GetType().FullName, New PropertyValue("DataContext", Me))
            End If
            Return _view
        End Get
    End Property

End Class
