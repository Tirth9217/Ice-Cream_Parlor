using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Customer_Master : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection("Data Source=DESKTOP-K71L90F\\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=Iceparlor");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            tblcustomergrid.Visible = true;
            tblcustomer.Visible = false;
            bindgrid();
            bindCust();

        }
    }
    public void bindCust()
    {
        try
        {
            conn.Open();
            string str = "select custid from customer_master order by custid";
            SqlDataAdapter da = new SqlDataAdapter(str, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlCust.DataSource = ds;
                ddlCust.DataTextField = "custid";
                ddlCust.DataValueField = "custid";
                ddlCust.DataBind();
            }
            conn.Close();

        }
        catch (Exception ex)
        {

            throw ex;
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
            string str = "select * from Customer_Master";
            SqlDataAdapter da = new SqlDataAdapter(str, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvcustomer.DataSource = ds;
                gvcustomer.DataBind();
            }
            conn.Close();

        }
        catch (Exception)
        {

            throw;
        }
    }
    protected void gvcustomer_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "D")
            {
                string strDelete = "delete from Customer_Master where CustId=" + e.CommandArgument;
                conn.Open();
                SqlCommand cmd = new SqlCommand(strDelete, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                bindgrid();
            }
            else if (e.CommandName == "E")
            {
                tblcustomer.Visible = true;
                tblcustomergrid.Visible = false;
                btnsave.Visible = false;
                btnupdate.Visible = true;
                string strSelect = "select * from Customer_Master where CustId=" + e.CommandArgument;
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(strSelect, conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                conn.Close();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtcustomerid.Text = ds.Tables[0].Rows[0]["CustId"].ToString();
                    txtcustomername.Text = ds.Tables[0].Rows[0]["CustName"].ToString();
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
    protected void gvcustomer_Sorting(object sender, GridViewSortEventArgs e)
    {

    }
    protected void gvcustomer_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvcustomer.PageIndex = e.NewPageIndex;
        bindgrid();
    }

    protected void btnsearch_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtcustomersearch.Text == " ")
            {
                Response.Write("invalid");
                return;
            }
            conn.Open();
            string str = string.Empty;
            if (ddlSearchBy.SelectedValue == "CustId")
            {
                str = "select * from Customer_Master where CustId=" + ddlCust.SelectedValue;
            }
            else if (ddlSearchBy.SelectedValue == "Name")
            {
                str = "select * from Customer_Master where Custname like '" + txtcustomersearch.Text + "%'";
            }
            else if (ddlSearchBy.SelectedValue == "Mobile")
            {
                str = "select * from Customer_Master where MobileNo like '" + txtcustomersearch.Text + "%'";
            }
            SqlDataAdapter da = new SqlDataAdapter(str, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvcustomer.DataSource = ds;
                gvcustomer.DataBind();
            }
            else
            {
                Response.Write("enter valid id");
                gvcustomer.DataSource = ds;
                gvcustomer.DataBind();
            }
            conn.Close();

        }
        catch (Exception)
        {

            throw;
        }
    }





    protected void btnsave_Click(object sender, EventArgs e)
    {
        try
        {
            conn.Open();
            string strmax = "select max(CustId) as maxCustId from Customer_Master";
            int CustId = 0;
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(strmax, conn);

            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["maxCustId"].ToString() == "")
                {
                    CustId = 1;
                }
                else
                {
                    CustId = Convert.ToInt32(ds.Tables[0].Rows[0]["maxCustId"].ToString()) + 1;
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
                string str = "insert into Customer_Master(CustId,CustName,Address,Email,MObileNo,Description,Status,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate)" +
                    "values(" + CustId + ",'" + txtcustomername.Text + "','" + txtadress.Text + "','" + txtemail.Text + "'," + txtmobileno.Text + ",'" + txtdescription.Text + "','" + strStatus + "'," + Convert.ToInt32(Session["userid"].ToString()) + ",getdate()," + Convert.ToInt32(Session["userid"].ToString()) + ",getdate())";
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                bindgrid();
                tblcustomer.Visible = false;
                tblcustomergrid.Visible = true;

            }
        }
        catch (Exception)
        {

            throw;
        }
    }

    protected void btncancel_Click(object sender, EventArgs e)
    {
        tblcustomer.Visible = false;
        tblcustomergrid.Visible = true;
    }

    protected void btnviewall_Click(object sender, EventArgs e)
    {
        bindgrid();
    }

    protected void btnadd_Click(object sender, EventArgs e)
    {
        tblcustomer.Visible = true;
        tblcustomergrid.Visible = false;
        btnsave.Visible = true;
        btnupdate.Visible = false;
        btnsave.Visible = true;
        txtcustomerid.Enabled = false;
    }

    protected void btnupdate_Click(object sender, EventArgs e)
    {
        try
        {
            conn.Open();
            string strStatus = string.Empty;
            if (rdoactive.Checked == true)
            {
                strStatus = "A";
            }
            else
            {
                strStatus = "I";
            }
            string str = "update Customer_Master set CustName='" + txtcustomername.Text + "',Address='" + txtadress.Text + "',Email='" + txtemail.Text + "',MobileNo=" + txtmobileno.Text + ",Description='" + txtdescription.Text + "',Status='" + strStatus + "' where CustId=" + txtcustomerid.Text + "";
            SqlCommand cmd = new SqlCommand(str, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            bindgrid();
            tblcustomergrid.Visible = true;
            tblcustomer.Visible = false;
        }
        catch (Exception)
        {

            throw;
        }
    }

    protected void ddlSearchBy_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSearchBy.SelectedValue == "CustId")
        {
            ddlCust.Visible = true;
            txtcustomersearch.Visible = false;
        }
        else
        {
            ddlCust.Visible = false;
            txtcustomersearch.Visible = true;
        }
    }






}