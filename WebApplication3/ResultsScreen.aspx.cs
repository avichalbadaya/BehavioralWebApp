using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Configuration;
using System.Data;

namespace WebApplication3
{
    public partial class ResultsScreen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ConfigurationManager.AppSettings["GameMode"].ToString().Trim() == "B")
            {
                tblVis.Visible = false;
                tblVis2.Visible = false;

                DataTable dt = (new DA()).getRoundDetails(Convert.ToInt32(Session["TeamId"].ToString()), Convert.ToInt32(Session["InGameID"]));
                grdvwscoredetails.DataSource = dt;
                grdvwscoredetails.DataBind();
                
            }
            else
            {

                int earning = 0;
                tblVis.Visible = false;
                tblVis2.Visible = false;
                DataTable dt = (new DA()).getRoundDetails(Convert.ToInt32(Session["TeamId"].ToString()), Convert.ToInt32(Session["InGameID"]));
                grdvwscoredetails.DataSource = dt;
                grdvwscoredetails.DataBind();

            }
        }

        public int getTimeDifferenceNow(string strTime)
        {
            DateTime startTime = DateTime.Now;

            TimeSpan span = startTime.Subtract(DateTime.Parse(strTime));
            return span.Seconds;
        }
        protected void UpdateTimer_Tick(object sender, EventArgs e)
        {
            if (ConfigurationManager.AppSettings["GameMode"].ToString().Trim() == "B")
            {
                if (Convert.ToInt32(Application["ChildRoundNo"]) < Convert.ToInt16(ConfigurationManager.AppSettings["NoOfRound"]) * (((int)Application["bnTreeLevel"]) - 1))
                {
                    
                    if (1 == 2)
                    { }
                    if (1 == 2)
                    { }

                    DateTime startTime = DateTime.Now;
                    if (hdnGameCommence.Value == "ABC")
                    {
                        hdnGameCommence.Value = DateTime.Now.ToString();
                    }
                    else
                    {
                        if (getTimeDifferenceNow(hdnGameCommence.Value) >= 1)
                        {
                            Application.Lock();
                            if (Application["NoRoundCheck"] == null)
                            {
                                if (Convert.ToInt32(Application["ChildRoundNo"]) >= Convert.ToInt16(ConfigurationManager.AppSettings["NoOfRound"]) * (((int)Application["bnTreeLevel"]) - 1))
                                {
                                    //intCurrentRound = Convert.ToInt32(Application["CurrentRound"]) + 1;
                                    //Response.Redirect("ResultsScreen.aspx");
                                    //New header entry to be made here
                                    //(new DA()).initiatenewround(ConfigurationManager.AppSettings["GameMode"].ToString());
                                }
                                if (1 == 2)
                                {
                                }
                                Application["NoRoundCheck"] = "Start";
                                
                            }
                            Application.UnLock();
                            if (1 == 2)
                            { }

                            Response.Redirect("WaitingPage.aspx");
                        }
                        else
                        {
                            lblNoOfPlayers.Text = "Initiating the next round:- " + ((int)Application["CurrentRound"] + 1).ToString() + " in " + (20 - getTimeDifferenceNow(hdnGameCommence.Value)).ToString() + " seconds.";
                            return;
                        }
                    }
                }
                else
                {
                    lblNoOfPlayers.Text = "The Game has finished: ";

                }
            }
            else
            {
                if (hdnGameCommence.Value == "ABC")
                {
                    hdnGameCommence.Value = DateTime.Now.ToString();
                }
                else
                {
                    if ((int)Application["CurrentRound"] + 1 <= Convert.ToInt16(ConfigurationManager.AppSettings["NoOfRound"]))
                    {
                        if (10 - getTimeDifferenceNow(hdnGameCommence.Value) <= 1)
                        {
                            Application.Lock();
                            int red = 0;
                            if (Application["NoRoundCheck"] == null)
                            {
                                Application["NoRoundCheck"] = "Start";
                                Application["CurrentRound"] = (int)Application["CurrentRound"] + 1;
                                if ((int)Application["CurrentRound"]+1 > Convert.ToInt16(ConfigurationManager.AppSettings["NoOfRound"]) )
                                {
                                    red = 1;
                                } 
                            }
                            if ((int)Application["CurrentRound"] <= Convert.ToInt16(ConfigurationManager.AppSettings["NoOfRound"]) && red != 1 )
                            {
                                Response.Redirect("WaitingPage.aspx");
                            }
                            else
                            {
                                lblNoOfPlayers.Text = "The games has finished";
                                return;
                            }
                            Application.UnLock();
                        }
                        else
                        {
                            lblNoOfPlayers.Text = "Please Wait for "  + (10 - getTimeDifferenceNow(hdnGameCommence.Value)).ToString() +" ,oUpdating the status";
                        }
                        
                        ;
                    }
                    else
                    {
                        lblNoOfPlayers.Text = "The games has finished";
                        return;
                    }
                }
            }

        }
    }
}