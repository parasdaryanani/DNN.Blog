Imports System
Imports System.Data
Imports System.Linq
Imports System.Xml
Imports System.Xml.Schema
Imports System.Xml.Serialization

Imports DotNetNuke
Imports DotNetNuke.Common
Imports DotNetNuke.Common.Utilities
Imports DotNetNuke.Entities.Modules
Imports DotNetNuke.Entities.Portals
Imports DotNetNuke.Services.Tokens

Imports DotNetNuke.Modules.Blog.Data
Imports DotNetNuke.Entities.Content.Taxonomy

Namespace Entities.Entries

 Partial Public Class EntriesController

  Public Shared Function GetEntry(contentItemId As Int32, moduleId As Int32) As EntryInfo

   Return CType(CBO.FillObject(DataProvider.Instance().GetEntry(contentItemId, moduleId), GetType(EntryInfo)), EntryInfo)

  End Function

  Public Shared Function AddEntry(objEntry As EntryInfo, createdByUser As Integer) As Integer

   objEntry.ContentItemId = DataProvider.Instance().AddEntry(objEntry.AllowComments, objEntry.BlogID, objEntry.Content, objEntry.Copyright, objEntry.DisplayCopyright, objEntry.Image, objEntry.Published, objEntry.PublishedOnDate, objEntry.Summary, objEntry.Title, objEntry.ViewCount, createdByUser)
   Dim termController As ITermController = DotNetNuke.Entities.Content.Common.Util.GetTermController()
   For Each t As Term In objEntry.Terms
    termController.AddTermToContent(t, objEntry)
   Next
   Return objEntry.ContentItemId

  End Function

  Public Shared Sub UpdateEntry(objEntry As EntryInfo, updatedByUser As Integer)

   DataProvider.Instance().UpdateEntry(objEntry.AllowComments, objEntry.BlogID, objEntry.Content, objEntry.ContentItemId, objEntry.Copyright, objEntry.DisplayCopyright, objEntry.Image, objEntry.Published, objEntry.PublishedOnDate, objEntry.Summary, objEntry.Title, objEntry.ViewCount, updatedByUser)
   Dim termController As ITermController = DotNetNuke.Entities.Content.Common.Util.GetTermController()
   For Each t As Term In objEntry.Terms
    termController.AddTermToContent(t, objEntry)
   Next

  End Sub

  Public Shared Sub DeleteEntry(contentItemId As Int32)

   DataProvider.Instance().DeleteEntry(contentItemId)

  End Sub

 End Class
End Namespace

