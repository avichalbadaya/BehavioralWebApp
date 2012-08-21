using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace WebApplication3
{
    public partial class WaitingPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(bool)Application["active"])
            {
                Response.Redirect("~/Consent.aspx");
            }
            if (!Page.IsPostBack)
            {
                Application.Lock();
                if (Application["WaitingTime"] != null && getTimeDifferenceNow(Application["WaitingTime"].ToString()) > 10)
                {
                    Application["WaitingTime"] = null;
                }
                Application.UnLock();
                if (1 == 2)
                { }
            }
            //Label1.Text = Session["Name"].ToString() + " and your Session ID is :" + Convert.ToInt32(Session["ID"]).ToString() + " and Current Round is " + (Convert.ToInt32(Application["CurrentRound"]) + 1).ToString();
            Label1.Text = Session["Name"].ToString() + ". The current Round is " + (Convert.ToInt32(Application["CurrentRound"]) + 1).ToString();
        }
        protected void UpdateTimer_Tick(object sender, EventArgs e)
        {
            int intCurrentRound;
            int intSessionId;
            int intTreeLevel;
            DateTime startTime = DateTime.Now;
            intTreeLevel = (int)Application["bnTreeLevel"];

           // Label1.Text = Session["Name"].ToString();
            if (Application["OnlineUsers"].ToString() == ConfigurationManager.AppSettings["NoOfPlayers"])
            {
                //Random obk = new Random();
                if (ConfigurationManager.AppSettings["GameMode"].ToString().Trim() == "B")
                {


                    if (Convert.ToInt32(Application["ChildRoundNo"]) + 1 > Convert.ToInt16(ConfigurationManager.AppSettings["NoOfRound"]) * (((int)Application["bnTreeLevel"]) - 1))
                    {
                        //intCurrentRound = Convert.ToInt32(Application["CurrentRound"]) + 1;
                        Response.Redirect("ResultsScreen.aspx");
                    }

                    intCurrentRound = Convert.ToInt32(Application["ChildRoundNo"]) % (((int)Application["bnTreeLevel"]) - 1) + 1;


                    intSessionId = Convert.ToInt32(Session["ID"]);

                    if (intSessionId >= Math.Pow(2, intCurrentRound - 1) && intSessionId < Math.Pow(2, intCurrentRound + 1))
                    {
                        if (hdnGameCommence.Value == "ABC")
                        {
                            hdnGameCommence.Value = DateTime.Now.ToString();
                            Application.Lock();
                            if (Application["WaitingTime"] == null)
                            {
                                Application["WaitingTime"] = DateTime.Now.ToString();
                            }
                            Application.UnLock();
                        }
                        else
                        {
                            if (getTimeDifferenceNow(Application["WaitingTime"].ToString()) >= 20)
                            {
                                Application.Lock();
                                if (Application["CurrentRoundStartTime"] == null)
                                {
                                    Application["CurrentRoundStartTime"] = DateTime.Now;
                                }
                                Application.UnLock();
                                Response.Redirect("Game.aspx");
                            }
                            else
                            {
                                lblNoOfPlayers.Text = "Commencing round:- " + ((int)Application["CurrentRound"] + 1).ToString() + "'S Childround" + (((int)Application["ChildRoundNo"] + 1) % (((int)Application["bnTreeLevel"]) - 1) + 1).ToString() + " in " + (20 - getTimeDifferenceNow(Application["WaitingTime"].ToString())).ToString() + " seconds Get Ready for your turn ";
                                return;
                            }
                        }
                    }
                    else
                    {
                        lblNoOfPlayers.Text = "Started Round :-" + ((int)Application["CurrentRound"] + 1).ToString() + "'s Subround" + (((int)Application["ChildRoundNo"] + 1) % (((int)Application["bnTreeLevel"]) - 1) + 1).ToString() + "<br /> Get Ready for your turn ";
                        return;
                    }
                }
                else
                {
                    if (Application["WaitingTime"] == null)
                    {
                        Application["WaitingTime"] = DateTime.Now.ToString();
                    }
                    if (hdnGameCommence.Value == "ABC")
                    {
                        hdnGameCommence.Value = DateTime.Now.ToString();
                        Application.Lock();
                        if (Application["WaitingTime"] == null)
                        {
                            Application["WaitingTime"] = DateTime.Now.ToString();
                        }
                        Application.UnLock();
                    }
                    else
                    {
                        if (getTimeDifferenceNow(Application["WaitingTime"].ToString()) >= 20)
                        {
                            Application.Lock();
                            if (Application["CurrentRoundStartTime"] == null)
                                Application["CurrentRoundStartTime"] = DateTime.Now;
                            Application.UnLock();
                            Response.Redirect("Game.aspx");
                            if (1 == 2)
                            { }
                        }
                        else
                        {
                            lblNoOfPlayers.Text = "Initiating Round:- " + (((int)Application["ChildRoundNo"]) % Convert.ToInt16(ConfigurationManager.AppSettings["NoOfRound"]) + 1).ToString() + " in " + (20 - getTimeDifferenceNow(Application["WaitingTime"].ToString())).ToString() + " seconds Get Ready for your turn ";
                            return;
                        }
                    }
                }
            }
            else
            {
                lblNoOfPlayers.Text = "Waiting for " + (15-(int)Application["OnlineUsers"]).ToString() + " more players.";
            }
        }

        public int getTimeDifferenceNow(string strTime)
        {
            DateTime startTime = DateTime.Now;

            TimeSpan span = startTime.Subtract(DateTime.Parse(strTime));
            return span.Seconds;
        }
    }
}