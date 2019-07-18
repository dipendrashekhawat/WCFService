<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="EmployeeServiceWebClient.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="GetEmployeeData" runat="server" Text="Get Employee Data" OnClick="GetEmployeeData_Click" />
        <br />
        <asp:FileUpload ID="FileUpload1"  CssClass="button"  runat="server" />
        <asp:Button ID="ImportCSV" runat="server" Text="Upload CSV File" OnClick="ImportCSV_Click" />
        <br />
        <h2>Employee Details</h2>
        <br />
        <b>FirstName:</b> <asp:Label ID="FirstName" runat="server" Text=""></asp:Label>
        <br />
        <b>LastName:</b> <asp:Label ID="LastName" runat="server" Text=""></asp:Label>
        <br />
        <b>Department:</b> <asp:Label ID="Department" runat="server" Text=""></asp:Label>
        <br />
        <b>Designation:</b> <asp:Label ID="Designation" runat="server" Text=""></asp:Label>
        <br />
        <b>Error Message:</b> <asp:Label ID="DisplayMessage" runat="server" Text=""></asp:Label>
    </div>

        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
    </form>
</body>
</html>
