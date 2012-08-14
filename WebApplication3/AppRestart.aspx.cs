using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace WebApplication3
{
    public partial class AppRestart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Page.IsPostBack)
            {
                if (ConfigurationManager.AppSettings["GameMode"].ToString().Trim() == "B")
                {
                    btnStartNewRound.Visible = false;
                    lblMessage.Visible = false;
                }
                tblLoginDetails.Visible = true;

                tblroundDetails.Visible = false;
            }

        }

        protected void btnStart_Click(object sender, EventArgs e)
        {
            int noofPlayers;
            Application.Lock();
            Application["OnlineUsers"] = 0;
            Application["CurrentRound"] = 0;
            Application["ActivePlayersRequired"] = 0;
            Application["CurrentRoundStartTime"] = null;
            Application["CurrentRoundEndTime"] = null;
            Application["bnTreeLevel"] = null;
            Application["active"] = true;
            Application["ChildRoundNo"] = 0;
            Application.UnLock();
            (new DA()).initiatenewround(ConfigurationManager.AppSettings["GameMode"].ToString());
            noofPlayers = Convert.ToInt32(ConfigurationManager.AppSettings["NoOfPlayers"]);
            bool blnLevelDecided = true;
            int iLevel = 0;
            Random rnd = new Random();
            while (blnLevelDecided)
            {
                if (Math.Pow(2, iLevel) - 1 >= noofPlayers)
                {
                    Application["bnTreeLevel"] = iLevel;
                    blnLevelDecided = false;
                }
                else
                {
                    iLevel++;
                }
            }
            Global.arrStack.Clear();
            for (int k = 0; k < noofPlayers; k++)
            {
                Global.arrStack.Add(k + 1);
            }
            Global.arrAssign.Clear();
            while (Global.arrStack.Count > 0)
            {
                iLevel = rnd.Next(Global.arrStack.Count - 1);
                Global.arrAssign.Add(Global.arrStack[iLevel]);
                Global.arrStack.Remove(Global.arrStack[iLevel]);
            }
            


        }

        protected void btnStop_Click(object sender, EventArgs e)
        {
            Application["active"] = false;
        }

        protected void btnStop_Click1(object sender, EventArgs e)
        {
            Application["active"] = false;
        }

        protected void btnStart_Click1(object sender, EventArgs e)
        {
            int noofPlayers;
            string strMessage;
            strMessage = Application["OnlineUsers"].ToString() + " TOtal Online Users <br />";
            strMessage = strMessage + Application["CurrentRound"].ToString() + " TOtal Current Round Users <br />";
            strMessage = strMessage + Application["ActivePlayersRequired"].ToString() + " ActivePlayersRequired <br />";
            strMessage = strMessage + ConfigurationManager.AppSettings["NoOfPlayers"].ToString() + " No Of players required to start games<br />";
            strMessage = strMessage + Application["bnTreeLevel"].ToString() + " bnTreeLevel <br />";
            //Response.Write(Application["OnlineUsers"].ToString() + " TOtal Online Users" );
            //Response.Write("<br />");
            //Response.Write(Application["CurrentRound"].ToString() + " TOtal Current Round Users");
            //Response.Write("<br />");
            //Response.Write(Application["ActivePlayersRequired"].ToString() + " ActivePlayersRequired");
            //Response.Write("<br />");
            //Response.Write(ConfigurationManager.AppSettings["NoOfPlayers"].ToString() + " No Of players required to start games");
            //Response.Write("<br />");
            
            //Response.Write(Application["CurrentRoundStartTime"].ToString() + " CurrentRoundStartTime");
            //Response.Write("<br />");
            //Response.Write(Application["CurrentRoundEndTime"].ToString() + " CurrentRoundEndTime");
            //Response.Write("<br />");
            //Response.Write(Application["bnTreeLevel"].ToString() + " bnTreeLevel");
            //Response.Write("<br />");
            //Response.Write(Application["active"].ToString() + " active");
            lblMessage.Text = strMessage;
            lblMessage.Visible = true;
            Application.Lock();
            Application["OnlineUsers"] = 0;
            Application["CurrentRound"] = 0;
            Application["ActivePlayersRequired"] = 0;
            Application["CurrentRoundStartTime"] = null;
            Application["CurrentRoundEndTime"] = null;
            Application["bnTreeLevel"] = null;
            Application["active"] = true;
            Application["ChildRoundNo"] = 0;
            Application.UnLock();
            (new DA()).initiatenewround(ConfigurationManager.AppSettings["GameMode"].ToString());

            noofPlayers = Convert.ToInt32(ConfigurationManager.AppSettings["NoOfPlayers"]);
            bool blnLevelDecided = true;
            int iLevel = 0;
            while (blnLevelDecided)
            {
                if (Math.Pow(2, iLevel) - 1 >= noofPlayers)
                {
                    Application["bnTreeLevel"] = iLevel;
                    blnLevelDecided = false;
                }
                else
                {
                    iLevel++;
                }
            }
            Random rnd = new Random();
            Global.arrStack.Clear();
            for (int k = 0; k < noofPlayers; k++)
            {
                Global.arrStack.Add(k + 1);
            }
            Global.arrAssign.Clear();
            while (Global.arrStack.Count > 0)
            {
                iLevel = rnd.Next(Global.arrStack.Count - 1);
                Global.arrAssign.Add(Global.arrStack[iLevel]);
                Global.arrStack.Remove(Global.arrStack[iLevel]);
            }
        }

        protected void btnStartNewRound_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "New round ID is =" + (new DA()).StartNewRound().ToString();
            int noofPlayers;
            int iLevel = 0;
            Random rnd = new Random();
            Global.arrStack.Clear();
            noofPlayers = Convert.ToInt32(ConfigurationManager.AppSettings["NoOfPlayers"]);
            for (int k = 0; k < noofPlayers; k++)
            {
                Global.arrStack.Add(k + 1);
            }
            Global.arrAssign.Clear();
            while (Global.arrStack.Count > 0)
            {
                iLevel = rnd.Next(Global.arrStack.Count - 1);
                Global.arrAssign.Add(Global.arrStack[iLevel]);
                Global.arrStack.Remove(Global.arrStack[iLevel]);
            }
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
                    tblLoginDetails.Visible = true;
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