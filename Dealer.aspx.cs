using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class Dealer : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection("Data Source=DESKTOP-K71L90F\\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=Iceparlor");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            tbldealer.Visible = false;
            tblDealergrid.Visible = true;
            bindgrid();
            
        }

    }
    public void bindgrid()
    {
        try
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();
            string str = "select * from Dealer_Master";
            SqlDataAdapter da = new SqlDataAdapter(str, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvdealer.DataSource = ds;
                gvdealer.DataBind();
            }
            conn.Close();
        }
        catch (Exception)
        {
            
            throw;
        }
    }

    protected void gvdealer_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "D")
            {
                string strDelete = "delete from Dealer_Master where DealerId=" + e.CommandArgument;
                conn.Open();
                SqlCommand cmd = new SqlCommand(strDelete, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                bindgrid();

            }
            else if (e.CommandName == "E")
            {
                tbldealer.Visible = true;
                tblDealergrid.Visible = false;
                btnsave .Visible = false;
                btnupdate.Visible = true;
                string strselect = "select * from Dealer_Master where DealerId=" + e.CommandArgument;
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(strselect, conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                conn.Close();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtdealerid.Text = ds.Tables[0].Rows[0]["DealerId"].ToString();
                    txtdealername.Text = ds.Tables[0].Rows[0]["Dealername"].ToString();
                    txtadress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                    txtemail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                    txtmobileno.Text = ds.Tables[0].Rows[0]["MobileNo"].ToString();
                    txtdescription.Text = ds.Tables[0].Rows[0]["Description"].ToString();

                    if (ds.Tables[0].Rows[0]["Status"].ToString() == "A")
                    {
                        rdoactive.Checked = true;
                        rdoinactive.Checked = false;
                    }
                    else
                    {
                        rdoactive.Checked = false;
                        rdoinactive.Checked = true;
                    }

                }
                
            }
        }
        catch (Exception)
        {
            
            throw;
        }
    }
    protected void gvdealer_Sorting(object Sender, GridViewSortEventArgs e)
    {

    }
    protected void gvdealer_PageIndexChanging(object Sender, GridViewPageEventArgs e)
    {
        gvdealer.PageIndex = e.NewPageIndex;
        bindgrid();
    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtsearch.Text == "")
            {
                Response.Write("Not Valid");
                return;
            }
            conn.Open();
            string str = "select * from Dealer_Master where DealerId=" + txtsearch.Text;
            SqlDataAdapter da = new SqlDataAdapter(str, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvdealer.DataSource = ds;
                gvdealer.DataBind();
            }
            else
            {
                Response.Write("enter valid id");
                gvdealer.DataSource = ds;
                gvdealer.DataBind();

            }
            conn.Close();
        }
        catch (Exception)
        {
            
            throw;
        }
    }

    protected void btnupdate_Click(object sender, EventArgs e)
    {
        try
        {
            conn.Open();
            btnsave.Visible = false;
            string strStatus = string.Empty;
            if (rdoactive.Checked == true)
            {
                strStatus = "A";
            }
            else
            {
                strStatus = "I";
            }
            string str = "update Dealer_Master set DealerName='" + txtdealername.Text + "',Address='" + txtadress.Text + "',Email='" + txtemail.Text + "',MobileNo=" + txtmobileno.Text + ",Description='" + txtdescription.Text + "',Status='" + strStatus + "' where DealerId=" + txtdealerid.Text + "";
            SqlCommand cmd = new SqlCommand(str, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            bindgrid();
            tblDealergrid.Visible = true;
            tbldealer.Visible = false;
        }
        catch (Exception)
        {
            
            throw;
        }
    }

    protected void btnadd_Click(object sender, EventArgs e)
    {
        tbldealer.Visible = true;
        tblDealergrid.Visible = false;
        btnsave.Visible = true;
        btnupdate.Visible = false;
        btnsave.Visible = true;
        txtdealerid.Enabled = false;
    }

    protected void btnviewall_Click(object sender, EventArgs e)
    {
        bindgrid();
    }

    protected void btnsave_Click(object sender, EventArgs e)
    {
        try
        {
            conn.Open();
            string strmax = "select max(DealerId) as maxDealerId from Dealer_Master";
            int DealerId = 0;
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(strmax, conn);

            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["maxDealerId"].ToString() == "")
                {
                    DealerId = 1;
                }
                else
                {
                    DealerId = Convert.ToInt32(ds.Tables[0].Rows[0]["maxDealerId"].ToString()) + 1;
                }
                string strStatus = string.Empty;
                if (rdoactive.Checked == true)
                {
                    strStatus = "A";

                }
                else
                {
                    strStatus = "I";
                }
                string str = "insert into Dealer_Master(DealerId,DealerName,Address,Email,MobileNo,Description,Status,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate)" +
                "values(" + DealerId + ",'" + txtdealername.Text + "','" + txtadress.Text + "','" + txtemail.Text + "','" + txtmobileno.Text + "','" + txtdescription.Text + "','" + strStatus + "'," + Convert.ToInt32(Session["userId"].ToString()) + ",getdate()," + Convert.ToInt32(Session["UserId"].ToString()) + ",getdate())";
                SqlCommand cmd=new SqlCommand (str,conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                bindgrid();
                tbldealer.Visible=false;
                tblDealergrid.Visible=true;
            }

        }
        catch (Exception)
        {
            
            throw;
        }
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        tblDealergrid.Visible = true;
        tbldealer.Visible = false;
    }
}