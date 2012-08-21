<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WaitingPage.aspx.cs" Inherits="WebApplication3.WaitingPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server" >

<%--<script type="text/JavaScript">
    
        setTimeout("location.reload(true);", 5000);

    
</script>--%>

<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<br/>
    You are currently in the Waiting Room.<br/>
<br/>
<br/>


    <div id="Div1" style="font-size:medium; text-align:center">Your ID is: 
 <asp:Label ID="Label1" runat="server"  style="font-size:medium; text-align:center"></asp:Label>
</div>
<br/>
    
   
  <div id="dvWait" style="font-size:medium; text-align:center">
        Waiting for 15 players to enter the waiting room...<br /><br />
    <img src="graphics/hourglass.gif"/>&nbsp;
    <asp:Timer ID="UpdateTimeCheck" interval="1000" runat="server" ontick="UpdateTimer_Tick"></asp:Timer>
    <asp:UpdatePanel runat="server" id="TimedPanel" updatemode="Conditional">
            <Triggers>
                <asp:AsyncPostBackTrigger controlid="UpdateTimeCheck" eventname="Tick" />
            </Triggers>
            <ContentTemplate>
                <asp:Label runat="server" id="lblNoOfPlayers" />
                <asp:HiddenField ID="hdnGameCommence" Value="ABC" runat="server" />
            </ContentTemplate>
        </asp:UpdatePanel>
</div>
&nbsp;<br/>
<br/>
<br/>
</asp:Content>
