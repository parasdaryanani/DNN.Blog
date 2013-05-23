Imports System
Imports System.Runtime.Serialization

Namespace Entities.LegacyUrls
  Partial Public Class LegacyUrlInfo

#Region " Private Members "
#End Region
	
#Region " Constructors "
  Public Sub New()
  End Sub

  Public Sub New(url As String, contentItemId As Int32, entryId As Int32)
   Me.ContentItemId = contentItemId
   Me.EntryId = entryId
   Me.Url = url
  End Sub
#End Region
	
#Region " Public Properties "
  <DataMember()>
  Public Property ContentItemId As Int32 = -1
  <DataMember()>
  Public Property EntryId As Int32 = -1
  <DataMember()>
  Public Property Url As String = ""
#End Region

 End Class
End Namespace


