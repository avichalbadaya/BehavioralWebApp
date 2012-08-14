using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication3;
using System.Xml;
using System.Text;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using MySql.Data;
namespace WebApplication3
{
    public partial class profile : System.Web.UI.Page
    {

        
        
          protected void Button1_Click(object sender, EventArgs e)
        {
            int ID;
            PlayerProfileEntity objEntity = (new DA()).ValidateUser(txtName.Text.Trim(), txtEmail.Text.Trim());
            if (objEntity != null)
            {
                Response.Write("<script>alert('User Already Registered');</script>");
                return;
            }
           string gender;
            if(RadioButton1.Checked==true){
                gender="Male";
            }
            else
            {
                gender="Female";
            }

            DA obj = new DA();
            ID=obj.InsertCustomer(txtName.Text, Int32.Parse(txtAge.Text), gender, DropDownList1.SelectedValue, txtEmail.Text, 0);

            Session["Name"] = txtName.Text;
            Session["ID"] = ID;
            
            Response.Redirect("Consent.aspx");


            
        }

    }
}