'
' Bring2mind - http://www.bring2mind.net
' Copyright (c) 2012
' by Bring2mind
'
' Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
' documentation files (the "Software"), to deal in the Software without restriction, including without limitation 
' the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and 
' to permit persons to whom the Software is furnished to do so, subject to the following conditions:
'
' The above copyright notice and this permission notice shall be included in all copies or substantial portions 
' of the Software.
'
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED 
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
' DEALINGS IN THE SOFTWARE.
'

Imports DotNetNuke.Entities.Portals
Imports DotNetNuke.Modules.Blog.Common.Globals

Namespace Templating
 Public Class TemplateManager

  Public Sub New(portalsettings As PortalSettings, template As String)
   If template.StartsWith("[G]") Then
    TemplatePath = DotNetNuke.Common.ResolveUrl(glbTemplatesPath) & Mid(template, 4) & "/"
    TemplateMapPath = HttpContext.Current.Server.MapPath(DotNetNuke.Common.ResolveUrl(glbTemplatesPath)) & Mid(template, 4) & "\"
   Else
    TemplatePath = portalsettings.HomeDirectory & "/Blog/Templates/" & Mid(template, 4) & "/"
    TemplateMapPath = portalsettings.HomeDirectoryMapPath & "\Blog\Templates\" & Mid(template, 4) & "\"
   End If
  End Sub

#Region " Properties "
  Public Property TemplatePath As String
  Public Property TemplateMapPath As String

  Public ReadOnly Property SharedResourcesFile() As String
   Get
    Return TemplatePath & "resx/SharedResources"
   End Get
  End Property
#End Region

 End Class
End Namespace
