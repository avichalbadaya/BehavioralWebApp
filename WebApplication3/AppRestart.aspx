<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AppRestart.aspx.cs" Inherits="WebApplication3.AppRestart" %>
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
    <asp:Button ID="btnStop" Visible="false" runat="server" Text="Stop Game" 
    onclick="btnStop_Click1" />
    

    <asp:Button ID="btnStart" v runat="server" Text="Start New Round" 
        onclick="btnStart_Click1" />


    <asp:Button Visible= "false" ID="btnStartNewRound" runat="server" Text="Start New Round" 
        onclick="btnStartNewRound_Click" />
</td>
</tr>   </table>
    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>


</asp:Content>
