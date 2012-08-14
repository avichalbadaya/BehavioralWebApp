using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Collections;

namespace WebApplication3
{
    public partial class consent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ArrayList arr = Global.arrAssign;
            if (Application["OnlineUsers"].ToString() == ConfigurationManager.AppSettings["NoOfPlayers"])
            {
                Response.Write("<script>alert('The maximum number of users already reached'</script>");
            }
            
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            if (chkIAgree.Checked)
            {
                if (Application["OnlineUsers"].ToString() == ConfigurationManager.AppSettings["NoOfPlayers"])
                {
                    Response.Write("<script>alert('The maximum number of users already reached'</script>");
                    return;
                }
                string strName = first.Text + " " + last.Text;
                //bool blnValidUser = (new DA()).ValidateUser(strName.Trim(), email.Value.Trim());
               PlayerProfileEntity objEntity = (new DA()).ValidateUser(strName.Trim(), email.Value.Trim());
               if (objEntity != null)
               {
                   Session["Name"] = objEntity.strName;
                   Session["InGameID"] = Convert.ToInt32(objEntity.strId);
                   Session["ID"] = Global.arrAssign[Convert.ToInt32(objEntity.strId)-1] ;
                   int intTeamId = Convert.ToInt32(Session["ID"]) / 3;

                   if (Convert.ToInt32(Session["ID"]) % 3 != 0)
                   {
                       intTeamId = intTeamId + 1;
                   }
                   
                   Session["TeamId"] = intTeamId ;
                   Application.Lock();
                   if (Application["PlayersString"].ToString() == "")
                   {
                       Application["PlayersString"] = objEntity.strId.ToString();
                   }
                   else
                   {
                       Application["PlayersString"] = Application["PlayersString"].ToString() + ";" +  objEntity.strId.ToString();
                   }
                   Application.UnLock();
                   string strGameType = "S";

                   if (ConfigurationManager.AppSettings["GameMode"].ToString().Trim() == "B")
                   {
                       strGameType = "B";
                       //(new DA()).revertAverage(Convert.ToInt32(objEntity.strId));
                       //(new DA()).updateDBSession(Convert.ToInt32(Session["InGameID"].ToString()), Convert.ToInt32(Session["ID"].ToString()));
                   } 
                   //(new DA()).updatedbDetailsS(Convert.ToInt32(objEntity.strId), Convert.ToInt32(Session["ID"]), -1, -1, intTeamId);
                   //(new DA()).updatedbDetailsSORB(Convert.ToInt32(objEntity.strId), Convert.ToInt32(Session["ID"]), -1, -1, intTeamId, 1, strGameType);
                   Response.Redirect("Inst5.aspx");
               }
               else
               {
                   Response.Write("<script>alert('Kindly Enter Valid Details');</script>");
               }
            }
            else
            {
                Response.Write("<script>alert('Kindly Select Check the check box to Login');</script>");
            }
            
        }
    }
}