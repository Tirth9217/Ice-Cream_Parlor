using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Item_Master : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection("Data Source=DESKTOP-K71L90F\\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=Iceparlor");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            tblitemmaster.Visible = false;
            tblitemgrid.Visible = true;
            bindgrid();
            catId();
        }
    }
    public void catId()
    {
        try
        {
            string str = "select CatId,CatName from Category_Master order by CatId";
            SqlDataAdapter da = new SqlDataAdapter(str, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlcategoryid.DataSource = ds;
                ddlcategoryid.DataTextField = "CatName";
                ddlcategoryid.DataValueField = "CatId";
                ddlcategoryid.DataBind();
            }
        }
        catch (Exception)
        {

            throw;
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
            string str = "select ItemId,ItemName,cm.CatId,cm.CatName,ItemDesc,Rate,Stock,MinQty,cm.CreatedBy,cm.CreatedDate,cm.UpdatedBy,cm.UpdatedDate from Item_Master im,Category_Master cm where im.catId=cm.Catid";
            SqlDataAdapter da = new SqlDataAdapter(str, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvitem.DataSource = ds;
                gvitem.DataBind();
            }
            conn.Close();
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    protected void gvitem_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "D")
            {
                string strDelete = "delete from Item_Master where ItemId=" + e.CommandArgument;
                conn.Open();
                SqlCommand cmd = new SqlCommand(strDelete, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                bindgrid();
            }

            else if (e.CommandName == "E")
            {
                txtstock.Enabled = false;
                tblitemmaster.Visible = true;
                tblitemgrid.Visible = false;
                btnsave.Visible = false;

                string strSelect = "select * from Item_Master where ItemId=" + e.CommandArgument;
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(strSelect, conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                conn.Close();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtitemid.Text = ds.Tables[0].Rows[0]["ItemId"].ToString();
                    txtitemname.Text = ds.Tables[0].Rows[0]["ItemName"].ToString();
                    ddlcategoryid.SelectedValue = ds.Tables[0].Rows[0]["CatId"].ToString();
                    txtitemdescription.Text = ds.Tables[0].Rows[0]["ItemDesc"].ToString();
                    txtrate.Text = ds.Tables[0].Rows[0]["Rate"].ToString();
                    txtstock.Text = ds.Tables[0].Rows[0]["Stock"].ToString();
                    txtminimumquantity.Text = ds.Tables[0].Rows[0]["MinQty"].ToString();

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
    protected void gvitem_Sorting(object sender, GridViewSortEventArgs e)
    {

    }
    protected void gvitem_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvitem.PageIndex = e.NewPageIndex;
        bindgrid();
    }

    protected void btnsearch_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtitemsearch.Text == "")
            {
                Response.Write("not  valid ");
                return;
            }
            conn.Open();
            string str = "select ItemId,ItemName,cm.CatId,cm.CatName,ItemDesc,Rate,Stock,MinQty,cm.CreatedBy,cm.CreatedDate,cm.UpdatedBy,cm.UpdatedDate from Item_Master im,Category_Master cm where im.catId=cm.Catid and ItemId=" + txtitemsearch.Text;
            SqlDataAdapter da = new SqlDataAdapter(str, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvitem.DataSource = ds;
                gvitem.DataBind();
            }
            else
            {
                Response.Write("enter valid id");
                gvitem.DataSource = ds;
                gvitem.DataBind();
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
            string strStatus = string.Empty;
            if (rdoactive.Checked == true)
            {
                strStatus = "A";
            }
            else
            {
                strStatus = "I";
            }
            string str = "update Item_Master set ItemName='" + txtitemname.Text + "',CatId=" + ddlcategoryid.SelectedValue + ",ItemDesc='" + txtitemdescription.Text + "',Status='" + strStatus + "',Rate=" + txtrate.Text + ",Stock=" + txtstock.Text + ",MinQty=" + txtminimumquantity.Text + ",updatedby=" + Convert.ToInt32(Session["userid"].ToString()) + ",updateddate=getdate() where Itemid=" + txtitemid.Text + "";
            SqlCommand cmd = new SqlCommand(str, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            bindgrid();
            tblitemgrid.Visible = true;
            tblitemmaster.Visible = false;
            btnupdate.Visible = true;

        }
        catch (Exception)
        {

            throw;
        }
    }

    protected void btnadd_Click(object sender, EventArgs e)
    {
        tblitemgrid.Visible = false;
        tblitemmaster.Visible = true;
        btnupdate.Visible = false;
        btnsave.Visible = true;
        txtstock.Enabled = true;
        txtitemid.Enabled = false;
        txtitemname.Text = "";
        txtitemdescription.Text = "";
        txtminimumquantity.Text = "";
        txtrate.Text = "";
        txtstock.Text = "";
    }

    protected void btnsave_Click(object sender, EventArgs e)
    {
        try
        {
            conn.Open();
            string strmax = "select max(ItemId) as maxItemId from Item_Master";
            int ItemId = 0;
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(strmax, conn);

            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["maxItemId"].ToString() == "")
                {
                    ItemId = 1;
                }
                else
                {
                    ItemId = Convert.ToInt32(ds.Tables[0].Rows[0]["maxItemId"].ToString()) + 1;
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
            string str = "insert into Item_Master(ItemId,ItemName,Catid,ItemDesc,Status,Rate,Stock,MinQty,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate)" +
             "values (" + ItemId + ",'" + txtitemname.Text + "','" + ddlcategoryid.SelectedValue + "','" + txtitemdescription.Text + "','" + strStatus + "'," + txtrate.Text + "," + txtstock.Text + "," + txtminimumquantity.Text + "," + Convert.ToInt32(Session["userid"].ToString()) + ",getdate()," + Convert.ToInt32(Session["userid"].ToString()) + ",getdate())";
            SqlCommand cmd = new SqlCommand(str, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            bindgrid();
            tblitemgrid.Visible = true;
            tblitemmaster.Visible = false;

        }
        catch (Exception)
        {

            throw;
        }
    }

    protected void btncancel_Click(object sender, EventArgs e)
    {
        tblitemmaster.Visible = false;
        tblitemgrid.Visible = true;
    }

    protected void btnviewall_Click(object sender, EventArgs e)
    {
        bindgrid();
    }
}