<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Gallery.Default" ViewStateMode="Disabled" %>

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

            <%-- ThumbNail Repeater --%>
            <asp:Repeater ID="ThumbNailRepeater" runat="server" ItemType="System.String" SelectMethod="ThumbNailRepeater_GetData" >
                <HeaderTemplate>
                    <div id="thumbNails">
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLink" runat="server" NavigateUrl='<%#"?name=" + Item %>' ImageUrl='<% #"~/Content/ThumbNails/" + Item %>' CssClass="" />
                    <%--</asp:HyperLink>--%>
                    <%-- NavigateUrl --%>
                </ItemTemplate>
                <FooterTemplate>
                    </div>
                </FooterTemplate>
            </asp:Repeater>
            


            <%-- PANEL FOR UPLOAD AND BROWSING --%>
            <asp:Panel runat="server" Visible="true">

                <%-- VALIDATION SUMMARY --%>
                <asp:ValidationSummary ID="ValidationSummary" runat="server" HeaderText="Fel!!" DisplayMode="BulletList" />


                <%-- UPLOAD BUTTON --%>
                <div class="formItems">
                    <asp:FileUpload ID="FileUpload" CssClass="upLoad" runat="server" />
                    <asp:Button ID="UploadButton" runat="server" Text="Ladda upp" OnClick="UploadButton_Click" />
                </div>

            </asp:Panel>
        </form>


        <div class="clear"></div>
    </div>
</body>
</html>
