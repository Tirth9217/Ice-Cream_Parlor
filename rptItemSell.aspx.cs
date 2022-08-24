﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
 
public partial class rptItemSell : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void showReport()
    {
        tblReport.Visible = true;
        ReportDocument rd = new ReportDocument();
        rd.Load(Server.MapPath("~/Reports/ItemSell.rpt"));
        string strFromdate = cal1.SelectedDate.ToShortDateString() + " 00:00:00";
        string strToDate = cal2.SelectedDate.ToShortDateString() + " 23:59:59";
        rd.SummaryInfo.ReportTitle = "Item Sell Report between " + cal1.SelectedDate.ToShortDateString() + " and " + cal2.SelectedDate.ToShortDateString();
        rd.SetParameterValue("pFromDate", Convert.ToDateTime(strFromdate));
        rd.SetParameterValue("pToDate",Convert.ToDateTime(strToDate));
        
        CrystalReportViewer1.ReportSource = rd;
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        showReport();
    }
}