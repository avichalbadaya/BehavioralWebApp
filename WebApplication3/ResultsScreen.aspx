<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ResultsScreen.aspx.cs" Inherits="WebApplication3.ResultsScreen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <table id = "tblVis" runat = "server">
    <tr><td>Earning For Round 1:  <asp:Label ID="lblRound1" runat="server" Text="Label"></asp:Label></td></tr>
    <tr><td>Earning For Round 2:  <asp:Label ID="lblRound2" runat="server" Text="Label"></asp:Label></td></tr>
    <tr><td>Earning For Round 3:  <asp:Label ID="lblRound3" runat="server" Text="Label"></asp:Label></td></tr>
    <tr><td>Earning For Round 4:  <asp:Label ID="lblRound4" runat="server" Text="Label"></asp:Label></td></tr>
    </table>
    <asp:GridView ID="grdvwscoredetails" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" ForeColor="#333333" BorderColor="Black" BorderWidth="1" GridLines="None">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField AccessibleHeaderText="Team ID" DataField="teamid" 
                HeaderText="Team ID" />
            <asp:BoundField DataField="intsubroundid" HeaderText="Round Id" />
            <asp:BoundField DataField="intchildroundid" HeaderText="Child round ID" />
            <asp:BoundField DataField="scoreforround" HeaderText="Spending for Round" />
            <asp:BoundField DataField="earningforround" HeaderText="Earning for Round" />
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" BorderColor="Black" BorderWidth="1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" BorderColor="Black" BorderWidth="1" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>



    <table id = "tblVis2" runat = "server">
    <tr><td>Earning For Round is :  <asp:Label ID="lblRound" runat="server" Text="Label"></asp:Label></td></tr>
    </table>

    <asp:Timer ID="UpdateTimeCheck" interval="1000" runat="server" ontick="UpdateTimer_Tick"></asp:Timer>
    <asp:UpdatePanel runat="server" id="TimedPanel" updatemode="Conditional">
            <Triggers>
                <asp:AsyncPostBackTrigger controlid="UpdateTimeCheck" eventname="Tick" />
            </Triggers>
            <ContentTemplate>
                <asp:Label ID="lblNoOfPlayers" runat="server" Text=""></asp:Label>
                <asp:HiddenField ID="hdnGameCommence" Value="ABC" runat="server" />
            </ContentTemplate>
        </asp:UpdatePanel>


</asp:Content>
