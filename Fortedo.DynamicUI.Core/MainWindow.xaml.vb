Imports System.Xml.XPath.Extensions
Imports <xmlns:e="http://schemas.fortedo.com/dynamicui/elements">
Imports System.Xml
Imports Ninject

Class MainWindow

    Private Sub Window_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        Debug.Print("=====" & Date.Now())
        Dim el = XElement.Load("e:\documents\visual studio 2010\Projects\WpfApplication5\WpfApplication5\DataItem.xml")

        Dim kernel = New StandardKernel(New ElementsModule)

        Dim xel = XElement.Load("e:\documents\visual studio 2010\Projects\WpfApplication5\WpfApplication5\Definition.xml")
        Dim item As IDynamicElement = kernel.Get(Of IDynamicElement)("{http://schemas.fortedo.com/dynamicui/elements}Definition")
        item.SetDefinition(xel)
        item.Context = el
    End Sub
End Class
