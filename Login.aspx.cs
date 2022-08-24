using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Login : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection("Data Source=DESKTOP-K71L90F\\SQLEXPRESS;Initial Catalog=Iceparlor;Integrated Security=True");


    protected void Page_Load(object sender, EventArgs e)
    {
        // conn.Open();
        // Response.Write(conn.State);
    }

    protected void btnlogin_Click(object sender, EventArgs e)
    {
        try
        {
            conn.Open();
            string str = "select userid,username,password,usertype  from user_mast where userid=" + txtuserid.Text + " and password='" + txtpassword.Text.ToString() + "'";
            SqlDataAdapter da = new SqlDataAdapter(str, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {

                Session.Add("userid", txtuserid.Text.ToString());
                Session.Add("username", ds.Tables[0].Rows[0]["username"].ToString());
                Session.Add("usertype", ds.Tables[0].Rows[0]["usertype"].ToString());
                Response.Redirect("Index.aspx");
            }
            else
            {
                Response.Write("<script>alert('Invalid')</script>");
            }


            conn.Close();
        }
        catch (Exception ex)
        {

            throw ex;
        }

    }
}