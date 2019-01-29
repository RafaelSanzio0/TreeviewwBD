<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="TreeviewBD.home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="teste">
        </div>

        <asp:TreeView ID="arvore" runat="server" OnSelectedNodeChanged="arvore_SelectedNodeChanged">
        </asp:TreeView>

    </form>
</body>
</html>
