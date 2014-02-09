﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Gallery.Default" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Photo Gallery</title>
    <link href="~/Content/style.css" rel="stylesheet" />
</head>
<body>
    <div id="container">
        <%-- Application Header --%>
        <header><h1>Photo Gallery</h1></header>
        <hr />

        <form id="form1" runat="server">
            <asp:Panel runat="server" Visible="true">
                <%-- VALIDATION SUMMARY --%>
                <asp:ValidationSummary ID="ValidationSummary" runat="server" HeaderText="Fel!!" DisplayMode="BulletList" />


                <%-- POST BUTTON --%>
                <div class="formItems">
                    <asp:Button ID="UpLoadButton" runat="server" Text="Ladda upp" OnClick="UpLoadButton_Click" />
                </div>
            </asp:Panel>
        </form>


        <div class="clear"></div>
    </div>
</body>
</html>
