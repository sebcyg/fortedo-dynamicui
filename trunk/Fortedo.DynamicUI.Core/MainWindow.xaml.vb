Imports System.Xml.XPath.Extensions
Imports <xmlns:e="http://schemas.fortedo.com/dynamicui/elements">
Imports System.Xml
Imports Ninject
Imports Fortedo.DynamicUI.Elements

Class MainWindow

    Private Sub Window_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        Debug.Print("=====" & Date.Now())
        Dim el = XElement.Load("e:\documents\visual studio 2010\Projects\WpfApplication5\WpfApplication5\DataItem.xml")
        'Dim el2 = el.XPathEvaluate("/")
        'Dim el1 = CType(el.XPathEvaluate("CustomerInfo/Number/text()"), IEnumerable)
        'For Each elem In el1.Cast(Of Object)()
        '    Debug.Print(elem.ToString())
        'Next
        Dim xel = XElement.Load("e:\documents\visual studio 2010\Projects\WpfApplication5\WpfApplication5\Definition.xml")
        Dim item As IDynamicElement = New DefinitionElement()
        item.SetDefinition(xel)
        item.Context = el
    End Sub
End Class
