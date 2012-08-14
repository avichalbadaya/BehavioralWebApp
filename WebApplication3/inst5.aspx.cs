using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace WebApplication3
{
    public partial class inst5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Application["OnlineUsers"].ToString() == ConfigurationManager.AppSettings["NoOfPlayers"])
            {
                Response.Write("<script>alert('The maximum number of users already reached'</script>");
                return;
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            if (Application["OnlineUsers"].ToString() == ConfigurationManager.AppSettings["NoOfPlayers"])
            {
                Response.Write("<script>alert('The maximum number of users already reached'</script>");
                return;
            }
            Application.Lock();
            if (Application["OnlineUsers"].ToString() != ConfigurationManager.AppSettings["NoOfPlayers"])
                Application["OnlineUsers"] = (int)Application["OnlineUsers"] + 1;
            Application.UnLock();
            Response.Redirect("WaitingPage.aspx");
            
            if (1 == 2)
            { }
        }
    }
}