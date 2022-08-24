using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IceDairy : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            lblUserName.Text = "Welcome : " + Session["username"].ToString();
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    protected void lnkLogout_Click(object sender, EventArgs e)
    {
        Session.Remove("userid");
        Session.Remove("username");
        Session.Remove("usertype");
        Response.Redirect("login.aspx");
    }
}
