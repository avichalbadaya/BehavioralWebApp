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
    Your ID is: 
 <asp:Label ID="Label1" runat="server"  style="font-size:medium; text-align:center"></asp:Label>
<br/>
<br/>


    <div id="Div1" style="font-size:small; text-align:center">You are currently in the Waiting Room.<br/>
</div>
<br/>
    
   
  <div id="dvWait" style="font-size:small; text-align:center">
                <asp:Label runat="server" id="lblNoOfPlayers" />
                <br /><br />
    <img src="graphics/hourglass.gif"/>&nbsp;<br />
        <br />
        The next round will initiate once we have 15 players in the Waiting Room. 
    <asp:Timer ID="UpdateTimeCheck" interval="1000" runat="server" ontick="UpdateTimer_Tick"></asp:Timer>
    <asp:UpdatePanel runat="server" id="TimedPanel" updatemode="Conditional">
            <Triggers>
                <asp:AsyncPostBackTrigger controlid="UpdateTimeCheck" eventname="Tick" />
            </Triggers>
            <ContentTemplate>
                <asp:HiddenField ID="hdnGameCommence" Value="ABC" runat="server" />
            </ContentTemplate>
        </asp:UpdatePanel>
</div>
&nbsp;<br/>
<br/>
<br/>
</asp:Content>
