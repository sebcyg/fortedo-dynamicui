Imports Ninject.Modules
Imports Fasterflect
Imports Fasterflect.AssemblyExtensions
Imports System.Reflection

Public Class ElementsModule
    Inherits NinjectModule

    Public Overrides Sub Load()
        Dim types = Assembly.GetExecutingAssembly().TypesWith(Of DynamicElementAttribute)()
        Dim name As String
        For Each t In types
            name = t.Attribute(Of DynamicElementAttribute).Name
            name = If(name, t.Name.Replace("Element", ""))
            name = "{http://schemas.fortedo.com/dynamicui/elements}" & name
            Bind(Of IDynamicElement).To(t).Named(name)
        Next
    End Sub
End Class
