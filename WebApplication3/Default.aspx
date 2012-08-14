<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="WebApplication3._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

<table width="802" border="0" cellspacing="0" cellpadding="0" align="center">
  <tr>
    <td width="802"><div align="right"> 
        <p>&nbsp; </p>
      </div></td>
  </tr>
  <tr>
    <td class="tab_box"><img src="../graphics/welcometab.jpg" width="800" height="70"></td>
  </tr>
  <tr>
    <td class="tab_box_bottom" valign="top"> <p>&nbsp;</p>
      <p class="text">Welcome to the Behavioral Research Lab-Online at Columbia Business School. Today, you 
        and other participants will be participating in an online social decision study. 
        You are one of 30 participants who will be participating in today's 
        session. Momentarily, you will be interacting with them over the 
        Internet in a series of &quot;exchange games.&quot;</p>
      <p class="text"> The entire study lasts less than 45 minutes and takes place 
        online from your current computer terminal. </p>
      <p class="text">Next, we ask you to read the Consent Form that explains your participant rights. </p>
      <p class="text"><a href="consent1.aspx">NEXT</a>      </p>
    <p class="table_margin"></p></td>
  </tr>
  
  <tr> 
    <td class="tab_box_bottom"></td>
  </tr>
</table>

<table width="802" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr> 
    <td valign="top"><img src=<?php echo $logo?>></td>
   
  </tr>
</table>

   
</asp:Content>
