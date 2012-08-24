using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication3;
using System.Collections;
using System.Configuration;
using System.Data;

namespace WebApplication3
{
    public partial class Game : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            // ScriptManager1.RegisterAsyncPostBackControl(UpdateMessage);

            //round number
            round.Text = ((int)Application["CurrentRound"]).ToString();
            

            if (ConfigurationManager.AppSettings["GameMode"].ToString().Trim() == "B")
            {
                if (!((bool)Application["active"]))
                {
                    Response.Redirect("~/Consent.aspx");

                }
                int remainingtime;
                if (!Page.IsPostBack)
                {
                    //(new DA()).insertchoiceofuser(((int)Application["CurrentRound"]) + 1, ((int)(Application["ChildRoundNo"])) % (((int)Application["bnTreeLevel"]) - 1) + 1, Convert.ToInt32(Session["InGameID"]), Convert.ToInt32(Session["ID"]), (int)Session["TeamId"], 0, 0);

                    //revertAverage(((int)Application["CurrentRound"]), Int32.Parse(Session["InGameID"].ToString()), (int)Application["bnTreeLevel"]);
                }
                if (Application["CurrentRoundStartTime"] != null)
                    remainingtime = 32 - getTimeDifferenceNow(Application["CurrentRoundStartTime"].ToString());
                //lblMessage.Text = "Total Time Remaining is " + remainingtime.ToString() ;
                Application.Lock();
                Application["CurrentRoundEndTime"] = null;
                Application["NoRoundCheck"] = null;
                Application.UnLock();
            }
            else
            {
                if (!((bool)Application["active"]))
                {
                    Response.Redirect("~/Consent.aspx");

                }
                int remainingtime;
                if (!Page.IsPostBack)
                {
                    (new DA()).insertchoiceofuser(((int)Application["CurrentRound"]) + 1,1, Convert.ToInt32(Session["InGameID"]), Convert.ToInt32(Session["ID"]), (int)Session["TeamId"], 0, 0);

                    //revertAverage(((int)Application["CurrentRound"]), Int32.Parse(Session["InGameID"].ToString()), (int)Application["bnTreeLevel"]);
                }
                if (Application["CurrentRoundStartTime"] != null)
                    remainingtime = 32 - getTimeDifferenceNow(Application["CurrentRoundStartTime"].ToString());
                Application.Lock();
                Application["CurrentRoundEndTime"] = null;
                if(Application["NoRoundCheck"] != null)
                Application["NoRoundCheck"] = null;
                Application.UnLock();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Button1.Enabled = false;
            DropDownList1.Enabled = false;
            if (ConfigurationManager.AppSettings["GameMode"].ToString().Trim() == "B")
            {
                int result = 0;
                int ID = Int32.Parse(Session["ID"].ToString());
                //int Team_ID = Math.DivRem(ID, 2, out result);
                int Team_ID = (int)Session["TeamId"];

                DA obj = new DA();
                int remainingtime = 32 - getTimeDifferenceNow(Application["CurrentRoundStartTime"].ToString());
                if (remainingtime > 0)
                {
                    (new DA()).insertchoiceofuser(((int)Application["CurrentRound"]) + 1, ((int)(Application["ChildRoundNo"])) % (((int)Application["bnTreeLevel"]) - 1) + 1, Convert.ToInt32(Session["InGameID"]), Convert.ToInt32(Session["ID"]), (int)Session["TeamId"], Int16.Parse(DropDownList1.SelectedValue), 0);
                        
                }
                else
                {
                    (new DA()).insertchoiceofuser(((int)Application["CurrentRound"]) + 1, ((int)(Application["ChildRoundNo"])) % (((int)Application["bnTreeLevel"]) - 1) +1, Convert.ToInt32(Session["InGameID"]), Convert.ToInt32(Session["ID"]), (int)Session["TeamId"], 0, 0);

                }
                //if (1 == 2)
                //{

                //}
                int avg = obj.getAverage((int)Session["TeamId"], ((int)Application["CurrentRound"]) + 1, ((int)(Application["ChildRoundNo"])) % (((int)Application["bnTreeLevel"]) - 1) + 1, (int)Session["ID"]);
                if (avg != -1)
                {
                    lblAverage.Text = "Your earning for the round as of now is:- " + avg.ToString();
                }
                Button1.Enabled = false;
                DropDownList1.Enabled = false;
            }
            else
            {
                (new DA()).insertchoiceofuser(((int)Application["CurrentRound"]) + 1,  1, Convert.ToInt32(Session["InGameID"]), Convert.ToInt32(Session["ID"]), (int)Session["TeamId"], Int16.Parse(DropDownList1.SelectedValue), 0);
                       
            }

        }

        protected void UpdateMessage_Tick(object sender, EventArgs e)
        {
            
            //Condition: tree
            if (ConfigurationManager.AppSettings["GameMode"].ToString().Trim() == "B")
            {
                int remainingtime;
                //if (Application["CurrentRoundStartTime"] == null && ((int)Application["CurrentRound"]) + 1 <= ((int)Application["bnTreeLevel"] - 1) * 2)
                //{
                //    Response.Redirect("~/WaitingPage.aspx");
                //}
                if (Application["CurrentRoundStartTime"] == null && Application["CurrentRound"] == null)
                {
                    Response.Redirect("~/consent.aspx");
                }
                if (Application["CurrentRoundStartTime"] == null && ((int)Application["ChildRoundNo"] + 1) > (((int)Application["bnTreeLevel"]) - 1) * ((int)Application["NoOfRound"]))
                {
                    Response.Redirect("~/ResultsScreen.aspx");
                }
                if (Application["CurrentRoundStartTime"] == null)
                {
                    Response.Redirect("~/WaitingPage.aspx");
                }

                //remainingtime = 31 - getTimeDifferenceNow(Application["CurrentRoundStartTime"].ToString());
                remainingtime = ConfigurationManager.AppSettings["TimerContribution"].ToString().Trim() - getTimeDifferenceNow(Application["CurrentRoundStartTime"].ToString());

                if (remainingtime > 0)
                {
                    lblMessage.Text = remainingtime.ToString() + " seconds remaining.";
                    int ID = Int32.Parse(Session["ID"].ToString());
                    int result = 0;
                    //int Team_ID = Math.DivRem(ID, 2, out result);
                    int Team_ID = (int)Session["TeamId"];
                    Team_ID = Team_ID;

                    ArrayList arr = (new DA()).getplayerschoices(Team_ID, (int)(Application["CurrentRound"]) + 1, ((int)Application["ChildRoundNo"]) % (((int)Application["bnTreeLevel"]) - 1) + 1);
                    
                    lblAverageOfUsers.Text = "";
                    foreach (PlayerProfileEntity ent in arr)
                    {
                        if (ent.Total == "-1")
                        {
                            ent.Total = "Not Choosen Anything Yet";
                        }
                        lblAverageOfUsers.Text = lblAverageOfUsers.Text + "<br />The Spending for Team Member of ID = " + ent.strId + " is = " + ent.Total;
                    }
                }
                else
                {
                    lblMessage.Text = "The time is over. Calculating earnings : Get Ready ";
                }
               
                


                if (remainingtime < -1 && remainingtime > -11)
                {
                    int Team_ID = (int)Session["TeamId"];
                    
                    //punishment logic
                    if (grdPunishMent.Visible == false || grdPunishMent.Rows.Count==0)
                    {

                        grdPunishMent.Visible = true;
                        DataTable arr = (new DA()).getplayerschoicesForDataBind(Team_ID, (int)(Application["CurrentRound"]) + 1, ((int)Application["ChildRoundNo"]) % (((int)Application["bnTreeLevel"]) - 1) + 1, Convert.ToInt32(Session["InGameID"]));
                        
                            //arr.Rows.Remove(arr.Rows.Find(Session["ID"].ToString()));
                            grdPunishMent.DataSource = arr;
                            grdPunishMent.DataBind();
                            UpdatePanel3.Update();
                        
                    }

                    
                    
                }

                if (remainingtime < -12 && remainingtime > -15)
                {
                    (new DA()).setearningsforround((int)Session["TeamId"], ((int)Application["CurrentRound"]) + 1, ((int)(Application["ChildRoundNo"])) % (((int)Application["bnTreeLevel"]) - 1) + 1, Convert.ToInt32(Session["InGameID"]));
                    //(new DA()).insertchoiceofuser(((int)Application["CurrentRound"]) + 1, (int)(Application["CurrentRound"]) + 1, Convert.ToInt32(Session["InGameID"]), Convert.ToInt32(Session["ID"]), (int)Session["TeamId"], 0, 0);


                    Button1.Enabled = false;
                    DropDownList1.Enabled = false;
                    //UpdateAverage();
                }


                if (remainingtime < -15)
                {
                    if (DropDownList1.SelectedValue == "0")
                    {
                        //insertSpending(((int)Application["CurrentRound"]), Int32.Parse(Session["InGameID"].ToString()), (int)Application["bnTreeLevel"], Int16.Parse(DropDownList1.SelectedValue));
                        (new DA()).insertchoiceofuser(((int)Application["CurrentRound"]) + 1, ((int)(Application["ChildRoundNo"])) % (((int)Application["bnTreeLevel"]) - 1) + 1, Convert.ToInt32(Session["ID"]), Convert.ToInt32(Session["ID"]), (int)Session["TeamId"], Int16.Parse(DropDownList1.SelectedValue), 0);
                        
                    }
                    
                    Application.Lock();
                    if (Application["CurrentRoundEndTime"] == null)
                    {
                        Application.Lock();
                        if ((Convert.ToInt32(Application["ChildRoundNo"]) + 1) % (((int)Application["bnTreeLevel"]) - 1) == 0)
                        {
                            Application["CurrentRound"] = (int)Application["CurrentRound"] + 1;
                        }
                        Application["ChildRoundNo"] = (int)Application["ChildRoundNo"] + 1; 
                        Application["CurrentRoundEndTime"] = DateTime.Now;
                        Application["CurrentRoundStartTime"] = null;
                        Application.UnLock();
                    }
                    Application.UnLock();
                    if ((((int)Application["ChildRoundNo"] + 1) % (((int)Application["bnTreeLevel"]) - 1)) > 0)
                        Response.Redirect("~/WaitingPage.aspx");
                    else
                        Response.Redirect("~/ResultsScreen.aspx");
                }
            }
            else
            {
                if (Application["CurrentRoundStartTime"] == null && Application["CurrentRound"] == null)
                {
                    Response.Redirect("~/consent.aspx");
                }


                int remainingtime;
                string strMsg;
                remainingtime = 31 - getTimeDifferenceNow(Application["CurrentRoundStartTime"].ToString());
                if (remainingtime > 0)
                {
                    lblMessage.Text = "Total Time Remaining is " + remainingtime.ToString() + " Seconds";

                    //DataTable arr = (new DA()).getPlayerChoices(Convert.ToInt32(Session["TeamID"]), "S");
                    ArrayList arr = (new DA()).getplayerschoices((int)Session["TeamId"], (int)(Application["CurrentRound"]) + 1, ((int)Application["ChildRoundNo"]) % (((int)Application["bnTreeLevel"]) - 1) + 1);
                    
                    lblAverageOfUsers.Text = "";
                    foreach (PlayerProfileEntity ent in arr)
                    {
                        //if (Convert.ToInt32(ent["ScoreForRound"]) < 0)
                        //{
                        //    strMsg = "Not Choosen Anything Yet";
                        //}
                        //else
                        //{
                        //    strMsg = ent["ScoreForRound"].ToString();
                        //}
                        if (ent.Total == "-1")
                        {
                            ent.Total = "Not Choosen Anything Yet";
                        }
                        lblAverageOfUsers.Text = lblAverageOfUsers.Text + "<br />The Spending for Team Member of ID = " + ent.strId + " is = " + ent.Total;
                    }
                }
                else
                {

                    if (DropDownList1.SelectedItem.Text == "0" && DropDownList1.Enabled == true)
                    {
                        DropDownList1.SelectedIndex = 0;
                        //(new DA()).updatedbDetailsS(Convert.ToInt32(Session["InGameID"]), Convert.ToInt32(Session["ID"]), 0, 0, Int32.Parse(Session["TeamId"].ToString()));
                        (new DA()).insertchoiceofuser(((int)Application["CurrentRound"]) + 1, 1, Convert.ToInt32(Session["InGameID"]), Convert.ToInt32(Session["ID"]), (int)Session["TeamId"], Int16.Parse(DropDownList1.SelectedValue), 0);
                        
                        
                        DropDownList1.Enabled = false;
                    }

                    ArrayList arr = (new DA()).getplayerschoices((int)Session["TeamId"], (int)(Application["CurrentRound"]) + 1, ((int)Application["ChildRoundNo"]) % (((int)Application["bnTreeLevel"]) - 1) + 1);

                    lblAverageOfUsers.Text = "";
                    foreach (PlayerProfileEntity ent in arr)
                    {
                        //if (Convert.ToInt32(ent["ScoreForRound"]) < 0)
                        //{
                        //    strMsg = "Not Choosen Anything Yet";
                        //}
                        //else
                        //{
                        //    strMsg = ent["ScoreForRound"].ToString();
                        //}
                        if (ent.Total == "-1")
                        {
                            ent.Total = "Not Choosen Anything Yet";
                        }
                        lblAverageOfUsers.Text = lblAverageOfUsers.Text + "<br />The Spending for Team Member of ID = " + ent.strId + " is = " + ent.Total;
                    }
                    lblMessage.Text = "Calculating Earning for this round";
                    (new DA()).setearningsforround((int)Session["TeamId"], ((int)Application["CurrentRound"]) + 1, 1, Convert.ToInt32(Session["InGameID"]));
                    //punishment
                    if (remainingtime < -1 && remainingtime > -11)
                    {
                        int Team_ID = (int)Session["TeamId"];
                        //punishment logic
                        if (grdPunishMent.Visible == false)
                        {
                            grdPunishMent.Visible = true;
                            ArrayList arr1 = (new DA()).getplayerschoices(Team_ID, (int)(Application["CurrentRound"]) + 1, ((int)Application["ChildRoundNo"]) % (((int)Application["bnTreeLevel"]) - 1) + 1);
                            
                            
                            grdPunishMent.DataSource = arr1;
                            grdPunishMent.DataBind();
                        }

                    }


                    if (remainingtime < -15)
                    {
                        Response.Redirect("~/ResultsScreen.aspx");
                    }
                }
            }
        }
        protected void UpdateAverage()
        {
            int result = 0;
            int ID = Int32.Parse(Session["ID"].ToString());

            int avg;
            int Team_ID = Math.DivRem(ID, 2, out result);
            DA obj = new DA();
            if(Team_ID !=0)
                avg = obj.getAverage(ID,Team_ID);
            else
                avg = obj.getAverage(ID,ID);
            lblAverage.Text = "Your earning for the round as of now is:- " + avg.ToString();
            
            //insertChoice(((int)Application["CurrentRound"]), ID, (int)Application["bnTreeLevel"], avg);
            insertChoice(((int)Application["CurrentRound"]), ID, (int)Application["bnTreeLevel"], avg);
        }

        public int getTimeDifferenceNow(string strTime)
        {
            DateTime startTime = DateTime.Now;

            TimeSpan span = startTime.Subtract(DateTime.Parse(strTime));
            return span.Seconds;
        }
        public void insertChoice(int intCurrentRoundID, int PID, int intTreeLevel,int avg)
        {
            int intRoundNumber = 0;
            for (int i = 1; i <= intCurrentRoundID; i++)
            {
                if (PID >= Math.Pow(2, i - 1) && PID < Math.Pow(2, i+1 ))
                {
                    intRoundNumber++;
                }
                //    else if (PID >= Math.Pow(2, 2 * (intTreeLevel - 1) - intCurrentRoundID) && PID < Math.Pow(2, 2 * (intTreeLevel) - intCurrentRoundID) && intTreeLevel<=intCurrentRoundID )
                //    {
                //    intRoundNumber++;
                //}
                
            }
            (new DA()).insertAverage(Convert.ToInt32(Session["InGameID"]).ToString(), avg.ToString(), intRoundNumber.ToString());
            if (intRoundNumber > (intTreeLevel-1)*2 )
            {
                Response.Redirect("ResultsScreen.aspx");
            }
        }
        public void revertAverage(int intCurrentRoundID, int PID, int intTreeLevel)
        {
            int intRoundNumber = 0;
            for (int i = 1; i <= intCurrentRoundID; i++)
            {
                if (PID >= Math.Pow(2, i - 1) && PID < Math.Pow(2, i + 1))
                {
                    intRoundNumber++;
                }


                //else if (PID >= Math.Pow(2, 2 * (intTreeLevel - 1) - intCurrentRoundID) && PID < Math.Pow(2, 2 * (intTreeLevel) - intCurrentRoundID) && intTreeLevel <= intCurrentRoundID)
                //{
                //    intRoundNumber++;
                //}

            }
            (new DA()).revertAverage(Convert.ToInt32(Session["InGameID"]).ToString(), (intRoundNumber + 1).ToString());
        }
        public void insertSpending(int intCurrentRoundID, int PID, int intTreeLevel, int choice)
        {
            int intRoundNumber = 0;
            for (int i = 1; i <= intCurrentRoundID; i++)
            {
                if (PID >= Math.Pow(2, i - 1) && PID < Math.Pow(2, i + 1))
                {
                    intRoundNumber++;
                }
                //else if (PID >= Math.Pow(2, 2 * (intTreeLevel - 1) - intCurrentRoundID) && PID < Math.Pow(2, 2 * (intTreeLevel) - intCurrentRoundID) && intTreeLevel <= intCurrentRoundID)
                //{
                //    intRoundNumber++;
                //}

            }
            (new DA()).InsertChoice((Convert.ToInt32(Session["InGameID"])), Convert.ToInt16(choice), intRoundNumber.ToString());
            if (intRoundNumber > (intTreeLevel - 1) * 2)
            {
                Response.Redirect("ResultsScreen.aspx");
            }
        }


        protected void Row_Command_GrdPunishment(object sender, GridViewCommandEventArgs e)
        {
           
            if (e.CommandName == "UpdateTheRow")
            {
                GridViewRow grw = grdPunishMent.Rows[Convert.ToInt32(e.CommandArgument)];
                int punishmentid = Convert.ToInt32(grw.Cells[0].Text);
                int punishmentamt = Convert.ToInt32(((DropDownList)(grw.Cells[2].FindControl("ddlPunishment"))).SelectedValue);
                (new DA()).setpunishment(((int)Application["CurrentRound"]) + 1,((int)(Application["ChildRoundNo"])) % (((int)Application["bnTreeLevel"]) - 1) + 1,punishmentid,
                   Convert.ToInt32(Session["InGameID"]),(int)Session["TeamId"],punishmentamt);
                ((DropDownList)(grdPunishMent.Rows[Convert.ToInt32(e.CommandArgument)].FindControl("ddlPunishment"))).Enabled  = false;
                ((DropDownList)(grdPunishMent.Rows[Convert.ToInt32(e.CommandArgument)].FindControl("ddlPunishment"))).Enabled = false;
                ((DropDownList)(grdPunishMent.Rows[Convert.ToInt32(e.CommandArgument)].FindControl("ddlPunishment"))).Enabled = false;
                ((DropDownList)(grdPunishMent.Rows[Convert.ToInt32(e.CommandArgument)].FindControl("ddlPunishment"))).Enabled = false;


                grdPunishMent.Rows[Convert.ToInt32(e.CommandArgument)].Enabled= false;

                //grdPunishMent.Rows[Convert.ToInt32(e.CommandArgument)].Cells[3].Enabled = false;
                
                UpdatePanel3.Update();
                
            }
        }

        
    }
}