using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Category_Master : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection("Data Source=DESKTOP-K71L90F\\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=Iceparlor");

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            tblcategory.Visible = false;
            tblgrid.Visible = true;
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
            string str = "select * from Category_Master";
            SqlDataAdapter da = new SqlDataAdapter(str, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvcategory.DataSource = ds;
                gvcategory.DataBind();
            }
            conn.Close();
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    protected void gvcategory_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "D")
            {
                string strDelete = "delete from Category_Master where CatId=" + e.CommandArgument;
                conn.Open();
                SqlCommand cmd = new SqlCommand(strDelete, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                bindgrid();
            }
            else if (e.CommandName == "E")
            {
                tblcategory.Visible = true;
                tblgrid.Visible = false;
                btnsave.Visible = false;
                string strSelect = "select * from Category_Master where CatId=" + e.CommandArgument;
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(strSelect, conn);
                DataSet ds = new DataSet();

                da.Fill(ds);
                conn.Close();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtcategoryid.Text = ds.Tables[0].Rows[0]["CatId"].ToString();
                    txtcategoryname.Text = ds.Tables[0].Rows[0]["CatName"].ToString();
                    txtcategorydescription.Text = ds.Tables[0].Rows[0]["CatDesc"].ToString();
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
    protected void gvcategory_Sorting(object Sender, GridViewSortEventArgs e)
    {

    }
    protected void gvcategory_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvcategory.PageIndex = e.NewPageIndex;
        bindgrid();
    }

    protected void btnsearch_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtsearch.Text == "")
            {
                Response.Write("not  valid ");
                return;
            }
            conn.Open();
            string str = "select * from Category_Master where CatId=" + txtsearch.Text;
            SqlDataAdapter da = new SqlDataAdapter(str, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvcategory.DataSource = ds;
                gvcategory.DataBind();
            }
            else
            {
                Response.Write("enter valid id");
                gvcategory.DataSource = ds;
                gvcategory.DataBind();
            }

            conn.Close();
        }
        catch (Exception ex)
        {

            throw ex;
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

            string str = "update Category_Master set CatName='" + txtcategoryname.Text + "',CatDesc='" + txtcategorydescription.Text + "',Status='" + strStatus + "',updatedby=" + Convert.ToInt32(Session["userid"].ToString()) + ",updateddate=getdate() where catid=" + txtcategoryid.Text + "";
            SqlCommand cmd = new SqlCommand(str, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            tblcategory.Visible = false;
            tblgrid.Visible = true;
            bindgrid();


        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    protected void btnadd_Click(object sender, EventArgs e)
    {
        tblgrid.Visible = false;
        tblcategory.Visible = true;
        btnupdate.Visible = false;
        btnsave.Visible = true;
        txtcategoryid.Enabled = false;
    }

    protected void btnsave_Click(object sender, EventArgs e)
    {
        try
        {
            conn.Open();
            string strmax = "select max(CatId) as maxCatId from Category_Master";
            int CatId = 0;
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(strmax, conn);

            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["maxCatId"].ToString() == "")
                {
                    CatId = 1;
                }
                else
                {
                    CatId = Convert.ToInt32(ds.Tables[0].Rows[0]["maxCatId"].ToString()) + 1;
                }
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

            string str = "insert into Category_Master(CatId,CatName,CatDesc,Status,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate) " +
                "values(" + CatId + ",'" + txtcategoryname.Text + "','" + txtcategorydescription.Text + "','" + strStatus + "'," + Convert.ToInt32(Session["userid"].ToString()) + ",getdate()," + Convert.ToInt32(Session["userid"].ToString()) + ",getdate())";
            SqlCommand cmd = new SqlCommand(str, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            tblcategory.Visible = false;
            tblgrid.Visible = true;
            bindgrid();

        }
        catch (Exception)
        {

            throw;
        }
    }

    protected void btncancel_Click(object sender, EventArgs e)
    {
        tblcategory.Visible = false;
        tblgrid.Visible = true;
    }

    protected void btnviewall_Click(object sender, EventArgs e)
    {
        bindgrid();
    }
    protected void gvcategory_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}