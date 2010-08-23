Imports Ninject

Public Class CollectionElementBase
    Inherits DynamicElementBase

    Private _items As List(Of IDynamicElement)

    Public Overrides Sub SetDefinition(ByVal definition As System.Xml.Linq.XElement)
        MyBase.SetDefinition(definition)
        _items = New List(Of IDynamicElement)
        Dim kernel = New StandardKernel(New ElementsModule)

        For Each element In definition.Elements
            Dim item = kernel.Get(Of IDynamicElement)(element.Name.ToString())
            item.SetDefinition(element)
            _items.Add(item)
        Next
    End Sub

    Public Overrides Property Context As Object
        Get
            Return MyBase.Context
        End Get
        Set(ByVal value As Object)
            MyBase.Context = value
            For Each item In Items
                item.Context = value
            Next
        End Set
    End Property

    Public ReadOnly Property Items() As List(Of IDynamicElement)
        Get
            Return _items
        End Get
    End Property
End Class
