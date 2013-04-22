Imports System
Imports System.Runtime.Serialization

Namespace Security.Permissions
 Partial Public Class PermissionInfo

#Region " Private Members "
#End Region

#Region " Constructors "
  Public Sub New()
  End Sub

  Public Sub New(PermissionId As Int32, PermissionKey As String)
   Me.PermissionId = PermissionId
   Me.PermissionKey = PermissionKey
  End Sub
#End Region

#Region " Public Properties "
  <DataMember()>
  Public Property PermissionId() As Int32
  <DataMember()>
  Public Property PermissionKey() As String
#End Region

 End Class
End Namespace


