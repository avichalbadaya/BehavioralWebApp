<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"  CodeBehind="inst5.aspx.cs" Inherits="WebApplication3.inst5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<table width="802" border="0" cellspacing="0" cellpadding="0" align="center">
  <tr>
    <td width="802"><div align="right"></div></td>
  </tr>
  
  <tr>
    <td class="tab_box_bottom" valign="top"><br>
      <p class="text"><strong>A Final Note</strong></p>
      <p class="text">The entire study takes place online, through your computer. Because you are interacting with another participant, 
        <em>it is important that you complete the entire session. If one person drops out, other particiapnts will be forced to quit the session as well. </em>If you encounter 
        any connection problems.... </p>
        <p>Today, you will be asked to complete a series of simple economic decision tasks over the Web. In each round, the decision tasks involves you and your partner making decisions between two options, A and B as shown below. You will earn different number of points over the course of the experiment depending on which option you and your partner each choose on your own. Specifically, you will earn 5 points and your parnter 5 points if you both choose A. You will earn 1 point and your partner 7 points if you choose A and your partner B. You will earn 7 points and your partner 1 point if you choose B and your partner A. You will both earn 3 points if you both choose B.</p>
        <p>Shortly, the server will match you with another participant. You and your partner will be identified by anonymous IDs only, in order to protect your anonymity. You will play with the same partner the entire duration of the experiment, but you will not find out who your partner is during or after the experiment.</p>
      <p class="text">We are now ready to begin the study. Next, the server will 
        prepare your experimental assignment.</p>
      <p class="next">
          <asp:Button ID="btnNext" runat="server" Text="Next" onclick="btnNext_Click" /></p>
      </td>
  </tr>
  <tr> 
    <td class="tab_box_bottom"></td>
  </tr>
</table>
</asp:Content>
