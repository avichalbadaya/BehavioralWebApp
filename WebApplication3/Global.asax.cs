using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Configuration;
using System.Collections;

namespace WebApplication3
{
    public class Global : System.Web.HttpApplication
    {
        public static ArrayList arrStack = new ArrayList();
        public static ArrayList arrAssign = new ArrayList();
        
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            int noofPlayers;
            Application["OnlineUsers"] = 0;
            Application["CurrentRound"] = 0;
            
            Application["ActivePlayersRequired"] = 0;
            Application["CurrentRoundStartTime"] = null;
            Application["CurrentRoundEndTime"] = null;
            Application["bnTreeLevel"] = null;
            Application["active"] = true;
            Application["DBSessionAlloting"] = false;
            Application["DBSessionAlloted"] = false;
            Application["PlayersString"] = "";
            Application["NoOfRound"] = Convert.ToInt32(ConfigurationManager.AppSettings["NoOfRound"]);
            Application["NoRoundCheck"] = null;
            Application["ChildRoundNo"] = 0;
            Application["WaitingTime"] = null;

            //(new DA()).initiatenewround(ConfigurationManager.AppSettings["GameMode"].ToString());


            noofPlayers = Convert.ToInt32(ConfigurationManager.AppSettings["NoOfPlayers"]);
            bool blnLevelDecided = true;
            int iLevel = 0;
            Random rnd = new Random();
            while (blnLevelDecided)
            {
                if (Math.Pow(2, iLevel) -1 >= noofPlayers)
                {
                    Application["bnTreeLevel"] = iLevel;
                    blnLevelDecided = false;
                }
                else
                {
                    iLevel++;
                }
            }
            arrStack.Clear();
            for (int k = 0; k < noofPlayers; k++)
            {
                arrStack.Add(k+1);
            }
            arrAssign.Clear();
            while (arrStack.Count > 0)
            {
                iLevel = rnd.Next(arrStack.Count -1);
                arrAssign.Add(arrStack[iLevel]);
                arrStack.Remove(arrStack[iLevel]);
            }
            
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }

        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started
            //Application.Lock(); 
            //Application["OnlineUsers"] = (int)Application["OnlineUsers"] + 1;
            //Application.UnLock();
        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.
            Application.Lock();
            Application["OnlineUsers"] = (int)Application["OnlineUsers"] - 1;
            Application.UnLock();
        }

    }
}
