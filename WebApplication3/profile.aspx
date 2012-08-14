<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="profile.aspx.cs" Inherits="WebApplication3.profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server" >
    <table width="100%">
    <tr>
        
    <td colspan="2">
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    </td>
    
    </tr>
    <tr>
    <td>
    <label>Name</label>
    </td>
    <td>
   
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox><asp:RequiredFieldValidator
            ID="RequiredFieldValidator1" runat="server" 
            ErrorMessage="Kindly Enter name" ControlToValidate="txtName" 
            Display="Dynamic" ValidationGroup="V1">*</asp:RequiredFieldValidator>
   
    </td>
    </tr>
    <tr>
    <td>
     <label>Age</label>
   
    </td>
    <td>
   
        <asp:TextBox ID="txtAge" runat="server"></asp:TextBox>
   
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            Display="Dynamic" ErrorMessage="Kindly Enter Age" 
            ControlToValidate="txtAge" ValidationGroup="V1">*</asp:RequiredFieldValidator>
   
    </td>
    </tr>
    <tr>
    <td>
     <label>Sex</label>
    </td>
    <td>
        <asp:RadioButton ID="RadioButton1" runat="server" GroupName="Sex" Text="Male" />
&nbsp;&nbsp;
        <asp:RadioButton ID="RadioButton2" runat="server" GroupName="Sex" 
            Text="Female" />
    </td>
    </tr>
    <tr>
    <td>
     <label>Race</label>
    </td>
    <td>
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem>Select</asp:ListItem>
            <asp:ListItem>White</asp:ListItem>
            <asp:ListItem>African-American</asp:ListItem>
            <asp:ListItem>Latin-American</asp:ListItem>
            <asp:ListItem>Asian/Asian-American</asp:ListItem>
            <asp:ListItem>Other</asp:ListItem>
        </asp:DropDownList>
    </td>
    </tr>
    <tr>
    <td>
    <label>Language</label>
    </td>
    <td>
        <asp:DropDownList ID="DropDownList2" runat="server">
            <asp:ListItem>Select</asp:ListItem>
            <asp:ListItem>English</asp:ListItem>
            <asp:ListItem>German</asp:ListItem>
            <asp:ListItem>French</asp:ListItem>
            <asp:ListItem>Chinese</asp:ListItem>
            <asp:ListItem>Arabic</asp:ListItem>
            <asp:ListItem>Russian</asp:ListItem>
            <asp:ListItem>Hindi/Urdu</asp:ListItem>
            <asp:ListItem>Spanish</asp:ListItem>
            <asp:ListItem>Portuguese</asp:ListItem>
            <asp:ListItem>Japanese</asp:ListItem>
        </asp:DropDownList>
    </td>
    </tr>
    <tr>
    <td>
    <label>Major</label>
    </td>
    <td>
        <asp:TextBox ID="txtMajor" runat="server"></asp:TextBox>
    </td>
    </tr>
    <tr>
    <td>
    <label>Email</label>
    </td>
    <td>
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
            ControlToValidate="txtEmail" Display="Dynamic" 
            ErrorMessage="Kindly Enter Email id " ValidationGroup="V1">*</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
            ControlToValidate="txtEmail" Display="Dynamic" 
            ErrorMessage="Enter Email Id in proper format" 
            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
            ValidationGroup="V1">*</asp:RegularExpressionValidator>
    </td>
    </tr>
    <tr>
    <td>
    <label>Born</label>
    </td>
    <td>
        <asp:TextBox ID="txtBorn" runat="server"></asp:TextBox>
    </td>
    </tr>
  
    </table>
    <table width="100%">
    <tr>
    <td style="width:28%">
    
        &nbsp;</td>
    <td>
    
        <asp:Button ID="Button1" runat="server" Text="Submit" onclick="Button1_Click" 
            ValidationGroup="V1" />
    
    </td>
    </tr>
    </table>
    <div>
    
    <asp:DataList ID="dlComments" Runat="server" Width="100%">

<ItemTemplate>

<hr size=0/>

Name: <%# DataBinder.Eval(Container.DataItem, "name") %><br />

E-mail: <a href="mailto:<%# DataBinder.Eval(Container.DataItem, "email") %>"><%# DataBinder.Eval(Container.DataItem, "email") %></a><br />

Location: <%# DataBinder.Eval(Container.DataItem, "location") %><br />

Date: <%# DataBinder.Eval(Container.DataItem, "Date") %><br />

Description: <%# DataBinder.Eval(Container.DataItem, "Description") %><br />


</ItemTemplate>

</asp:DataList>
    </div>

</asp:Content>