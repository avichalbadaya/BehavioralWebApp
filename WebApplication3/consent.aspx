<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="consent.aspx.cs" Inherits="WebApplication3.consent" MasterPageFile="~/Site.master" %>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script language = "JavaScript" type="text/javascript">
    function checkbox_checker() {

        var consent = false;
        if (form.checkbox.checked==1)
            consent = true

        if (!consent) {
            alert("Please indicate your consent before proceeding.")
            return (false);
        }

        // TEXT BOXES //

        for (i = 0; i <= 3; i++) {
            box = document.form.elements[i];
            if (!box.value) {
                alert('Please enter your ' + box.id + '!');
                box.focus()
                return false;
            }
        }
        return true;

    }

</script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <table width="802" border="0" cellspacing="0" cellpadding="0" align="center">
  <tr>
    <td width="802"><div align="right"></div></td>
  </tr>

  <tr>
    <td class="tab_box_bottom" valign="top"> 
      <p class="text">Below is your consent form. Before agreeing to participate 
        in the study, we ask that you read this form carefully. You will receive 
        an email copy of this form to keep for your records.</p>
      <p class="consent"> <strong>Background Information and procedures:</strong> 
        The purpose of this study is to explore how people make simple economic 
        decisions. If you agree to participate in this study, you will be asked 
        to play a series of economic exchange tasks with a random partner. In 
        all, the study takes about 45 minutes to complete. </p>
      <p class="consent"><strong>Risks and Benefits of being in the Study:</strong> 
        We do not anticipate any risks for you participating in this study, other 
        than those encountered in day-to-day life. </p>
      <p class="consent"><strong>Compensation:</strong> For your full participation, you 
          will receive $5-12 in cash, depending on your performance. PLEASE NOTE that we 
          guarantee payment to only those who complete an entire session.</p>
      <p class="consent"><strong>Voluntary Nature of Participation: </strong>Your decision 
          to participate is entirely voluntary. If you participate, you may decide 
        to terminate your participation or withdraw your information at any time.</p>
      <p class="consent"><strong>Confidentiality:</strong> The records of this 
        study will be kept private. During the study, you and other participants 
        will be identified by participant IDs assigned to you by the server.  In any report we might publish, we will include no information 
        that will make it possible to identify you. Research records will be kept 
        in a private file, and only the researchers will have access to the records. 
      </p>
      <p class="consent"><strong>Contacts and Questions: </strong>Please contact Professor Kuwabara (kk2558@columbia.edu) for any questions. If 
        you have any questions or concerns regarding your rights as a subject 
        in this study, you may contact the Columbia University Committee on Human 
        Subjects (212-851-0213).</p>
      <p class="consent"><strong>Statement of Consent:</strong> You must be 18 
        years of age or older to consent to take part in this study. If you agree 
        to participate, please fill out the form below. A copy of the completed 
        form will be emailed to the email address you supply for your record. 
        (For this reason, it is very important that you submit a valid and complete 
        email address). Your personal information will NOT be shared with anyone.      </p>
      
        <table width="600" class="dottedtable" align="center">
          <tr> 
            <td class="righttext">I have read the above information. I consent to participate in the study.</td>
            <td class="smalltx" width="175"> <div align="center"> <asp:CheckBox ID="chkIAgree" runat="server" />&nbsp;</div></td>
          </tr>
          <tr> 
            <td class="righttext">First name</td>
            <td> <div align="center"> 
                <asp:TextBox runat = "server" id="first"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="first" ErrorMessage="Please enter your first name" 
                    ForeColor="Red" ValidationGroup="vldGrp1" Display="Dynamic">*</asp:RequiredFieldValidator>
              </div></td>
          </tr>
          <tr> 
            <td class="righttext">Last name</td>
            <td> <div align="center"> 
                <asp:TextBox runat = "server"  id="last"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="last" ErrorMessage="Please enter your last name" ForeColor="Red" 
                    ValidationGroup="vldGrp1" Display="Dynamic">*</asp:RequiredFieldValidator>
              </div></td>
          </tr>
          <tr> 
            <td class="righttext"><div align="right">Your full e-mail address</div></td>
            <td> <div align="center"> 
                <input type="text" name="email address" runat = "server"  id="email">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="email" ErrorMessage="Please enter a valid Email address" 
                    ForeColor="Red" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                    ValidationGroup="vldGrp1" Display="Dynamic">*</asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="email" ErrorMessage="Please enter a valid Email address" ForeColor="Red" 
                    ValidationGroup="vldGrp1" Display="Dynamic">*</asp:RequiredFieldValidator>
              </div></td>
          </tr>
          <tr>
            <td class="righttext"><asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                    ForeColor="Red" ValidationGroup="vldGrp1" /></td>
            <td><div align="center"> 
                <p> 
                  <asp:Button ID="Login" runat="server" Text="Login" onclick="Login_Click" 
                        ValidationGroup="vldGrp1" />  &nbsp;&nbsp;
                  <%--<asp:HyperLink ID="lnkNewUser" Target ="Profile.aspx" runat="server">New User</asp:HyperLink>--%>
                  <%--<a href="profile.aspx" >New User</a>--%>
                    <%--<asp:HyperLink ID="HyperLink1" runat="server">HyperLink</asp:HyperLink>--%>
                    <%--<asp:Button ID="NewUser" runat="server" Text="New User" />--%>
                  <br>
                </p>
              </div></td>
          </tr>
          </table>
          
    
      
      </td>
  </tr>
</table>

</asp:Content>