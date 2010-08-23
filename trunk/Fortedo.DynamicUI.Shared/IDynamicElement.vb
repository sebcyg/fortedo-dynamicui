Public Interface IDynamicElement
    Property Name As String
    Property Context As Object
    Property Label As String
    Property Path As String
    Sub SetDefinition(ByVal definition As XElement)
    Function GetData() As XElement
    ReadOnly Property View() As Object
End Interface
