using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

public partial class rptItemMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void showReport()
    {
        tblReport.Visible = true;
        ReportDocument rd = new ReportDocument();
        rd.Load(Server.MapPath("~/Reports/ItemMaster.rpt"));
        CrystalReportViewer1.ReportSource = rd;
    }

    protected void btnshow_Click(object sender, EventArgs e)
    {
        showReport();
    }
}