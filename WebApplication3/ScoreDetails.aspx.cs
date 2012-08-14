using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebApplication3
{
    public partial class ScoreDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                tblView.Visible = false;
                
                tblroundDetails.Visible = false;
                    
                ddlScoreDetails.DataMember = "intheaderroundid";
                ddlScoreDetails.DataTextField = "intheaderroundid";
                ddlScoreDetails.DataSource = (new DA()).getAllRoundDetails();
                ddlScoreDetails.DataBind();
                ddlScoreDetails.Items.Add(new ListItem("Select", "N"));
                ddlScoreDetails.SelectedValue = "N";
                //ddlScoreDetails.Visible = false;
            }
        }

        protected void ddlScoreDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            tblView.Visible = true;
            DataTable dt;
            dt = (new DA()).getAllRoundDetails();

            for(int i=0;i<dt.Rows.Count;i++)
            {
                if (dt.Rows[i]["intheaderroundid"].ToString().Trim() == ddlScoreDetails.SelectedValue.ToString().Trim())
                {
                    lblGameType.Text = dt.Rows[i]["gametype"].ToString() == "B" ? "Binary" : "Sequence";
                    lblIsActive.Text = dt.Rows[i]["isactive"].ToString() == "0" ? "Inactive" : "Active";
                    lblTimeStamp.Text = dt.Rows[i]["starttimestamp"].ToString() ;
                }
            }
            grdRoundDetails.DataSource = (new DA()).getparticularRoundDetails(Convert.ToInt32(ddlScoreDetails.SelectedValue));
            grdRoundDetails.DataBind();
        }

        protected void btnLoginDetails_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text.ToString().ToUpper() == "KO123")
            {
                if (txtPassword.Text.ToString() == "Ko@123")
                {
                    tblLoginDetails.Visible = false;
                    tblroundDetails.Visible = true;
                }
                else
                {
                    tblLoginDetails.Visible = true ;
                    tblroundDetails.Visible = false;
                    Response.Write("<script>alert('Wrong User Name/Passowrd')</script>");
                }
            }
            else
            {
                tblLoginDetails.Visible = true;
                tblroundDetails.Visible = false;
                Response.Write("<script>alert('Wrong User Name/Passowrd')</script>");
            }
        }
    }
}