using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Item_Receive : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection("Data Source=DESKTOP-K71L90F\\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=Iceparlor");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindItemCategory();
            //binditemName();
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
    public void binditemName()
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
                //  ddlitemname.DataBind();
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

                }
                conn.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }

    protected void btnrecieve_Click(object sender, EventArgs e)
    {
        try
        {
            conn.Open();
            string strSelect = "select stock + " + Convert.ToInt32(txtitemquantity.Text) + " as qty from item_master where itemid=" + Convert.ToInt32(ddlitemname.SelectedValue);
            SqlDataAdapter da = new SqlDataAdapter(strSelect, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);



            string strmax = "select max(TransId) as TransId from Item_Receive";
            int TransId = 0;
            DataSet ds1 = new DataSet();
            SqlDataAdapter da1 = new SqlDataAdapter(strmax, conn);

            da1.Fill(ds1);


            if (ds1.Tables[0].Rows[0]["TransId"].ToString() == "")
            {
                TransId = 1;
            }
            else
            {
                TransId = Convert.ToInt32(ds1.Tables[0].Rows[0]["TransId"].ToString()) + 1;
            }




            string strInsert = "insert into Item_Receive(TransId,ItemId,RecDate,Qty,CreatedBy,CreatedDate) values (" + TransId + "," + Convert.ToInt32(ddlitemname.SelectedValue) + ",getdate()," + txtitemquantity.Text + "," + Convert.ToInt32(Session["userid"].ToString()) + ",getdate())";
            SqlCommand cmd = new SqlCommand(strInsert, conn);
            cmd.ExecuteNonQuery();



            string strQty = "update item_master set stock=stock + " + Convert.ToInt32(txtitemquantity.Text) + " where itemid=" + Convert.ToInt32(ddlitemname.SelectedValue);
            SqlCommand cmd1 = new SqlCommand(strQty, conn);
            cmd1.ExecuteNonQuery();



            conn.Close();
            Response.Write("<script>alert('Item Inserted')</script>");
            txtitemquantity.Text = "";



        }
        catch (Exception)
        {

            throw;
        }
    }
}