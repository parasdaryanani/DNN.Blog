﻿Imports DotNetNuke.Services.Localization.Localization
Imports DotNetNuke.Modules.Blog.Common.Globals

Namespace Controls
 Public Class ManagementPanel
  Inherits BlogContextBase

  Public Property RssLink As String = ""

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

   LocalResourceFile = "~/DesktopModules/Blog/Controls/App_LocalResources/ManagementPanel.ascx.resx"
   If Not Me.IsPostBack Then
    cmdManageBlogs.Visible = Security.IsBlogger Or Security.CanApprovePost
    cmdBlog.Visible = Security.CanAddPost
    cmdEditPost.Visible = (Post IsNot Nothing) And Security.CanEditPost
    cmdCopyModule.Visible = Security.IsEditor
    pnlCopyModule.Visible = Security.IsEditor
    wlwlink.Title = LocalizeString("WLW")
    wlwlink.Visible = Security.CanAddPost
    If Post IsNot Nothing Then
     cmdBlog.Text = LocalizeString("cmdEdit")
    End If
    If Security.IsEditor Then
     ddTemplate.Items.Clear()
     ddTemplate.Items.Add(New ListItem("Default [System]", "[G]_default"))
     For Each d As IO.DirectoryInfo In (New IO.DirectoryInfo(HttpContext.Current.Server.MapPath(DotNetNuke.Common.ResolveUrl(glbTemplatesPath)))).GetDirectories
      If d.Name <> "_default" Then
       ddTemplate.Items.Add(New ListItem(d.Name & " [System]", "[G]" & d.Name))
      End If
     Next
     For Each d As IO.DirectoryInfo In (New IO.DirectoryInfo(Settings.PortalTemplatesMapPath)).GetDirectories
      ddTemplate.Items.Add(New ListItem(d.Name & " [Local]", "[P]" & d.Name))
     Next
     For intItem As Integer = 0 To PortalSettings.ActiveTab.Panes.Count - 1
      ddPane.Items.Add(Convert.ToString(PortalSettings.ActiveTab.Panes(intItem)))
     Next intItem
     If Not ddPane.Items.FindByValue(DotNetNuke.Common.Globals.glbDefaultPane) Is Nothing Then
      ddPane.Items.FindByValue(DotNetNuke.Common.Globals.glbDefaultPane).Selected = True
     End If
     ddPosition.Items.Clear()
     ddPosition.Items.Add(New ListItem(GetString("Top", "admin/controlpanel/App_LocalResources/iconbar"), "0"))
     ddPosition.Items.Add(New ListItem(GetString("Bottom", "admin/controlpanel/App_LocalResources/iconbar"), "-1"))
    End If
   End If
   RssLink = ResolveUrl(glbServicesPath) & "RSS/Get"
   RssLink &= String.Format("?tabid={0}&moduleid={1}", TabId, ModuleId)
   If Blog IsNot Nothing Then RssLink &= String.Format("&blog={0}", BlogId)
   If Term IsNot Nothing Then RssLink &= String.Format("&term={0}", TermId)
   If Not String.IsNullOrEmpty(SearchString) Then
    RssLink &= String.Format("&search={0}&t={1}&c={2}", HttpUtility.UrlEncode(SearchString), SearchTitle, SearchContents)
   End If
   If ShowLocale <> "" Then RssLink &= String.Format("&language={0}", ShowLocale)

  End Sub

  Private Sub cmdManageBlogs_Click(sender As Object, e As System.EventArgs) Handles cmdManageBlogs.Click
   Response.Redirect(EditUrl("Manage"), False)
  End Sub

  Private Sub cmdBlog_Click(sender As Object, e As System.EventArgs) Handles cmdBlog.Click
   If BlogId <> -1 Then
    Response.Redirect(EditUrl("Blog", BlogId.ToString, "PostEdit"), False)
   Else
    Response.Redirect(EditUrl("PostEdit"), False)
   End If
  End Sub

  Private Sub cmdEditPost_Click(sender As Object, e As System.EventArgs) Handles cmdEditPost.Click
   Response.Redirect(EditUrl("Post", ContentItemId.ToString, "PostEdit"), False)
  End Sub

 End Class
End Namespace