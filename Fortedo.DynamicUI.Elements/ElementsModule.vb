Imports Ninject.Modules
Imports Fasterflect
Imports Fasterflect.AssemblyExtensions
Imports System.Reflection
Imports Fortedo.DynamicUI.Shared

Public Class ElementsModule
    Inherits NinjectModule

    Public Overrides Sub Load()
        Debug.Print("Check")
        For Each fileInfo In My.Computer.FileSystem.FindInFiles("Elements", ".dll", True, FileIO.SearchOption.SearchAllSubDirectories)
            Debug.Print(fileInfo)
        Next
        Dim namespaces As New Dictionary(Of String, String)
        Dim ass = Me.GetType().Assembly
        For Each attr In ass.Attributes(Of XmlNamespaceAttribute)()
            For Each el In attr.ClrNamespaces
                namespaces.Add(el, attr.XmlNamespace)
            Next
        Next
        Dim types = ass.TypesWith(Of DynamicElementAttribute)()
        Dim name As String
        For Each t In types
            name = t.Attribute(Of DynamicElementAttribute)().Name
            name = If(name, t.Name.Replace("Element", ""))
            name = "{" & namespaces(t.Namespace) & "}" & name
            Bind(Of IDynamicElement).To(t).Named(name)
            Debug.Print(name)
        Next
    End Sub
End Class
