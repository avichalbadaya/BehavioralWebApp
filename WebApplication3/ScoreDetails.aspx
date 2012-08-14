<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ScoreDetails.aspx.cs" Inherits="WebApplication3.ScoreDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<table id ="tblLoginDetails" runat="server">

<tr>
<td>User Name</td>
<td><asp:TextBox ID="txtUserName" runat="server"></asp:TextBox></td>
</tr>
<tr>
<td>Password</td>
<td><asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox></td>

</tr>
<tr>
<td colspan="2">
    <asp:Button ID="btnLoginDetails" runat="server" Text="Login" 
        onclick="btnLoginDetails_Click" />
</td>
</tr>

</table>
<table id ="tblroundDetails" runat="server">
    <tr>
    <td>
    Select Round No,:-
    </td>
        <td>
            <asp:DropDownList ID="ddlScoreDetails" runat="server" AutoPostBack="True" 
                onselectedindexchanged="ddlScoreDetails_SelectedIndexChanged">
            </asp:DropDownList>
        </td>
        </tr>
  </table>
  
  <table id= "tblView" runat = "server">      
    <tr>
        <td>
            Game Type
        </td>
        <td>
            <asp:Label ID="lblGameType" runat="server" Text=""></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            Is Active
        </td>
        <td>
            <asp:Label ID="lblIsActive" runat="server" Text=""></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            Start Time Stamp
        </td>
        <td>
            <asp:Label ID="lblTimeStamp" runat="server" Text=""></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan= "2">
            <asp:GridView ID="grdRoundDetails" runat="server" CellPadding="4" 
                ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
        </td>
    </tr>
</table>




</asp:Content>
