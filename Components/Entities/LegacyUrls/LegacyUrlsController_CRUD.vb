Imports System
Imports System.Data
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

Namespace Entities.LegacyUrls

 Partial Public Class LegacyUrlsController

  Public Shared Sub AddLegacyUrl(objLegacyUrl As LegacyUrlInfo)

   DataProvider.Instance().AddLegacyUrl(objLegacyUrl.ContentItemId, objLegacyUrl.EntryId, objLegacyUrl.Url)

  End Sub

 End Class
End Namespace

