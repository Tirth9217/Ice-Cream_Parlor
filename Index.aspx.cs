using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Index : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection("Data Source=DESKTOP-K71L90F\\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=Iceparlor");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindStock();
        }

    }

    public void bindStock()
    {
        try
        {
            conn.Open();
            string str = "select im.ItemId,im.ItemName,cm1.CatId,cm1.CatName,im.Stock,im.MinQty,dm.DealerId,dm.DealerName,dm.Address,dm.Email,dm.MobileNo from Item_Master im,Category_Master cm1,Dealer_Master dm where cm1.CatId=im.CatId and dm.DealerId=im.DealerId and Stock<MinQty";
            SqlDataAdapter da = new SqlDataAdapter(str, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvstock.DataSource = ds;
                gvstock.DataBind();
            }
            conn.Close();
        }
        catch (Exception)
        {
            
            throw;
        }
    }
    protected void gvstock_Sorting(object sender, GridViewSortEventArgs e)
    {

    }
    protected void gvstock_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvstock.PageIndex = e.NewPageIndex;
        bindStock();
    }
    protected void gvstock_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        

    }
}