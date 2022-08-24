using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Item_Sell : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection("Data Source=DESKTOP-K71L90F\\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=Iceparlor");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindCustomerName();
            bindItemCategory();
            // bindItemName();
        }
    }
    public void bindCustomerName()
    {
        try
        {
            conn.Open();
            string str = "select CustId,CustName from Customer_Master where Status='A' order by CustName";
            SqlDataAdapter da = new SqlDataAdapter(str, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlcustomername.DataSource = ds;
                ddlcustomername.DataTextField = "CustName";
                ddlcustomername.DataValueField = "CustId";
                ddlcustomername.DataBind();
            }
            conn.Close();
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    public void bindItemCategory()
    {
        try
        {
            conn.Open();
            string str = "select CatId,CatName from Category_Master where Status='A' order by CatName";
            SqlDataAdapter da = new SqlDataAdapter(str, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlitemcategory.DataSource = ds;
                ddlitemcategory.DataTextField = "CatName";
                ddlitemcategory.DataValueField = "CatId";
                ddlitemcategory.DataBind();
            }
            conn.Close();
        }
        catch (Exception)
        {

            throw;
        }
    }


    public void bindItemName()
    {
        try
        {
            conn.Open();
            string str = "select ItemId,ItemName from Item_Master where Status='A' order by ItemName";
            SqlDataAdapter da = new SqlDataAdapter(str, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlitemname.DataSource = ds;
                ddlitemname.DataTextField = "ItemName";
                ddlitemname.DataValueField = "ItemId";
            }
            conn.Close();
        }
        catch (Exception)
        {

            throw;
        }
    }

    protected void ddlitemcategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlitemcategory.SelectedValue != " ")
        {
            try
            {
                conn.Open();
                string str = "select ItemId,ItemName from Item_Master where Status='A' and catid=" + ddlitemcategory.SelectedValue + " order by ItemName";
                SqlDataAdapter da = new SqlDataAdapter(str, conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlitemname.DataSource = ds;
                    ddlitemname.DataTextField = "ItemName";
                    ddlitemname.DataValueField = "ItemId";
                    ddlitemname.DataBind();
                    // txtitemrate.Text = ds.Tables[0].Rows[0]["rate"].ToString();
                }
                conn.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }

    protected void ddlitemname_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string str = "select rate from item_master where itemid=" + ddlitemname.SelectedValue + "";
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(str, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtitemrate.Text = ds.Tables[0].Rows[0]["rate"].ToString();
            }
            conn.Close();
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    protected void btnsell_Click(object sender, EventArgs e)
    {
        try
        {
            conn.Open();
            string strSelect = "select stock - " + Convert.ToInt32(txtitemqty.Text) + " as qty from item_master where itemid=" + Convert.ToInt32(ddlitemname.SelectedValue);
            SqlDataAdapter da1 = new SqlDataAdapter(strSelect, conn);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);

            if (Convert.ToInt32(ds1.Tables[0].Rows[0]["qty"].ToString()) < 0)
            {
                Response.Write("<script>alert('Stock less then entered qty')</script>");
               return;
                //if(Convert.ToInt32(ds1.Tables[0].Rows[0]["stock"].ToString()
            }






            string strmax = "select max(SalesId) as SalesId from item_sell";
            int SaleId = 0;
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(strmax, conn);

            da.Fill(ds);


            if (ds.Tables[0].Rows[0]["SalesId"].ToString() == "")
            {
                SaleId = 1;
            }
            else
            {
                SaleId = Convert.ToInt32(ds.Tables[0].Rows[0]["SalesId"].ToString()) + 1;
            }

            string strInsert = "insert into item_sell(salesid,itemid,custid,sell_qty,itemrate,selldate,createdby,createddate) values (" + SaleId + "," + Convert.ToInt32(ddlitemname.SelectedValue) + "," + Convert.ToInt32(ddlcustomername.SelectedValue) + "," + Convert.ToInt32(txtitemqty.Text) + "," + Convert.ToInt32(txtitemrate.Text) + ",getdate()," + Convert.ToInt32(Session["userid"].ToString()) + ",getdate())";
            SqlCommand cmd = new SqlCommand(strInsert, conn);
            cmd.ExecuteNonQuery();

            string strQty = "update item_master set stock=stock - " + Convert.ToInt32(txtitemqty.Text) + " where itemid=" + Convert.ToInt32(ddlitemname.SelectedValue);
            SqlCommand cmd1 = new SqlCommand(strQty, conn);
            cmd1.ExecuteNonQuery();

            conn.Close();
            Response.Write("<script>alert('Item Sold')</script>");
            txtitemqty.Text = "";
            txtitemrate.Text = "";
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

       


}