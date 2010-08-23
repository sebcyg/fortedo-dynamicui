Imports System.Xml.XPath.Extensions
Imports System.Xml
Imports Ninject
Imports Fortedo.DynamicUI.Shared

Class MainWindow

    Private Sub Window_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        Debug.Print("=====" & Date.Now())
        Dim el = XElement.Load("E:\Documents\Work\Fortedo\DynamicUI\Fortedo.DynamicUI\Fortedo.DynamicUI.Core\DataItem.xml")

        Dim kernel = New StandardKernel(New ElementsModule)

        Dim xel = XElement.Load("E:\Documents\Work\Fortedo\DynamicUI\Fortedo.DynamicUI\Fortedo.DynamicUI.Core\Definition.xml")
        Dim item As IDynamicElement = kernel.Get(Of IDynamicElement)(xel.Name.ToString())
        item.SetDefinition(xel)
        item.Context = el
    End Sub
End Class
