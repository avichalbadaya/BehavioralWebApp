<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Game.aspx.cs" Inherits="WebApplication3.Game" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>Choose the amount you want to spend and click ok</div>
    
    <asp:DropDownList ID="DropDownList1" runat="server" Width="100px">
        <asp:ListItem>0</asp:ListItem>
        <asp:ListItem>1</asp:ListItem>
        <asp:ListItem>2</asp:ListItem>
        <asp:ListItem>3</asp:ListItem>
        <asp:ListItem>4</asp:ListItem>
        <asp:ListItem>5</asp:ListItem>
        <asp:ListItem>6</asp:ListItem>
        <asp:ListItem>7</asp:ListItem>
        <asp:ListItem>8</asp:ListItem>
        <asp:ListItem>9</asp:ListItem>
        <asp:ListItem>10</asp:ListItem>
        <asp:ListItem>11</asp:ListItem>
        <asp:ListItem>12</asp:ListItem>
        <asp:ListItem>13</asp:ListItem>
        <asp:ListItem>14</asp:ListItem>
        <asp:ListItem>15</asp:ListItem>
        <asp:ListItem>16</asp:ListItem>
        <asp:ListItem>17</asp:ListItem>
        <asp:ListItem>18</asp:ListItem>
        <asp:ListItem>19</asp:ListItem>
        <asp:ListItem>20</asp:ListItem>
    </asp:DropDownList>

    <br />
    <br />
    
    <br />
    <br />
    <asp:Button ID="Button1" UseSubmitBehavior= "true" runat="server" onclick="Button1_Click" Text="Ok" />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <%--<asp:Timer ID="UpdateTimeCheck" interval="2000" runat="server" ontick="UpdateTimer_Tick"></asp:Timer>
   --%> <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Always" runat="server">
      
    <ContentTemplate>
    

    <br />
    <asp:Label ID="lblAverage" runat="server" Text="Average is"></asp:Label>
    <br />
    </ContentTemplate>
    </asp:UpdatePanel>

     <asp:Timer ID="UpdateMessage" interval="500"  runat="server" ontick="UpdateMessage_Tick"></asp:Timer>
<asp:UpdatePanel ID="UpdatePanel2" UpdateMode="Always" runat="server">
    <Triggers>
                <asp:AsyncPostBackTrigger controlid="UpdateMessage" eventname="Tick" />
            </Triggers>

    <ContentTemplate>

    <asp:Label ID="lblMessage" runat="server" Text="Message"></asp:Label>
    <asp:Label ID="lblAverageOfUsers" runat="server" Text=""></asp:Label>
    <br />
    <br />
    <br />
        
        <br />
    <%--<asp:Button runat="server" id= "btnPunish" Text="Punish" 
            onclick="btnPunish_Click" />--%>
    

    </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID = "UpdatePanel3" UpdateMode ="Conditional" runat= "server">
        <ContentTemplate>
        <asp:GridView ID="grdPunishMent" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" 
            CellPadding="3" GridLines="Vertical" Visible="False"
            OnRowCommand= "Row_Command_GrdPunishment">
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <Columns>
                <asp:BoundField AccessibleHeaderText="PlayerID" DataField="randomroundsessionid" 
                    HeaderText="PlayerID" />
                <asp:BoundField AccessibleHeaderText="Spending" DataField="scoreforround" 
                    HeaderText="Spending" />
                <asp:TemplateField AccessibleHeaderText="Punishment" HeaderText="Punishment">
                <ItemTemplate>
                    <asp:DropDownList ID ="ddlPunishment" runat= "server">
                         <asp:ListItem>0</asp:ListItem>
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>
                        <asp:ListItem>9</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                    </asp:DropDownList>
                </ItemTemplate>
                </asp:TemplateField>
                                
                <asp:ButtonField ButtonType="Button" HeaderText="Punish"  CommandName="UpdateTheRow"
                    Text="Click To Punish"  />
                                
            </Columns>
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#0000A9" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#000065" />
        </asp:GridView>
        
        </ContentTemplate>
    </asp:UpdatePanel>


    <br />
    <br />
    <asp:Label ID="Label1" runat="server" 
        Text="Waiting for your team mates response..."></asp:Label>


</asp:Content>
