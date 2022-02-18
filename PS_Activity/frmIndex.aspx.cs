using DevExpress.Data.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace PS_Activity
{
    public partial class frmIndex : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FncCheckLoginWeb();
                Page.MaintainScrollPositionOnPostBack = true; //PagePostback ไม่ต้องขึ้นมาด้านบน
                fncLoadGridActivity();
            }
            else
            {

            }
           
            FncClearLogin();
        }

        private void fncLoadGridActivity()
        {
            //โหลดข้อมูลแปลง
            DataTable DT = new DataTable();
            var lvSQL = "Select Id, Quota, PlanId, PlanName, CaneSeason, CaneDate, CaneCount, SeasonYear, CaneStatus From cane_activityheader";
            DT = GsysSQL.fncGetQueryData(lvSQL, DT);

            DataTable NewDT = new DataTable();
            NewDT.Columns.Add("Id");
            NewDT.Columns.Add("IdShow");
            NewDT.Columns.Add("Quota");
            NewDT.Columns.Add("PlanId");
            NewDT.Columns.Add("PlanName");
            NewDT.Columns.Add("CaneSeason");
            NewDT.Columns.Add("CaneDate");
            NewDT.Columns.Add("CaneCount");
            NewDT.Columns.Add("SeasonYear");
            NewDT.Columns.Add("CaneStatus");
            NewDT.Columns.Add("ActivityId");

            for (int i = 0; i < DT.Rows.Count; i++)
            {
                var Id = DT.Rows[i]["Id"].ToString();
                int IdShow = i + 1;
                var Quota = DT.Rows[i]["Quota"].ToString();
                var PlanId = DT.Rows[i]["PlanId"].ToString();
                var PlanName = DT.Rows[i]["PlanName"].ToString();
                var CaneSeason = DT.Rows[i]["CaneSeason"].ToString();
                var CaneDate = GsysFunc.fncChangeSDate(DT.Rows[i]["CaneDate"].ToString());
                var CaneCount = DT.Rows[i]["CaneCount"].ToString();
                var SeasonYear = DT.Rows[i]["SeasonYear"].ToString();
                var CaneStatus = DT.Rows[i]["CaneStatus"].ToString();
                if(CaneStatus == "0")
                {
                    CaneStatus = "ยกเลิกแปลง";
                }
                if (CaneStatus == "1")
                {
                    CaneStatus = "อ้อยปลูกใหม่";
                }
                if (CaneStatus == "2")
                {
                    CaneStatus = "ไว้ตอ";
                }
                var ActivityId = DT.Rows[i]["Id"].ToString();

                NewDT.Rows.Add(new object[] { Id, IdShow, Quota, PlanId, PlanName, CaneSeason, CaneDate, CaneCount, SeasonYear, CaneStatus, ActivityId });
            }
            
            GridActivity.DataSource = NewDT;
            GridActivity.DataBind();
        }

        private void fncLoadGridActivitySearch(string lvSearch, string lvQuotaSearch, string lvKeth)
        {
            DataTable DT = new DataTable();
            var lvSQL = "Select Id, Quota, PlanId, PlanName, CaneSeason, CaneDate, CaneCount, SeasonYear, CaneStatus From cane_activityheader Inner join cane_quota ON cane_activityheader.Quota = cane_quota.Q_ID Where 1=1 ";

            if(lvSearch != "")
            {
                lvSQL += "And PlanId = '" + lvSearch + "' ";
            }

            if(lvQuotaSearch != "")
            {
                lvSQL += "And Quota = '" + lvQuotaSearch + "' ";
            }

            if (lvKeth != "")
            {
                lvSQL += "And Q_Ket = '" + lvKeth + "'";
            }

            DT = GsysSQL.fncGetQueryData(lvSQL, DT);

            DataTable NewDT = new DataTable();
            NewDT.Columns.Add("Id");
            NewDT.Columns.Add("IdShow");
            NewDT.Columns.Add("Quota");
            NewDT.Columns.Add("PlanId");
            NewDT.Columns.Add("PlanName");
            NewDT.Columns.Add("CaneSeason");
            NewDT.Columns.Add("CaneDate");
            NewDT.Columns.Add("CaneCount");
            NewDT.Columns.Add("SeasonYear");
            NewDT.Columns.Add("CaneStatus");
            NewDT.Columns.Add("ActivityId");

            for (int i = 0; i < DT.Rows.Count; i++)
            {
                var Id = DT.Rows[i]["Id"].ToString();
                int IdShow = i + 1;
                var Quota = DT.Rows[i]["Quota"].ToString();
                var PlanId = DT.Rows[i]["PlanId"].ToString();
                var PlanName = DT.Rows[i]["PlanName"].ToString(); 
                var CaneSeason = DT.Rows[i]["CaneSeason"].ToString();
                var CaneDate = GsysFunc.fncChangeSDate(DT.Rows[i]["CaneDate"].ToString());
                var CaneCount = DT.Rows[i]["CaneCount"].ToString();
                var SeasonYear = DT.Rows[i]["SeasonYear"].ToString();
                var ActivityId = DT.Rows[i]["Id"].ToString();
                var CaneStatus = DT.Rows[i]["CaneStatus"].ToString();
                if (CaneStatus == "")
                {
                    CaneStatus = "อ้อยปลูกใหม่";
                }
                NewDT.Rows.Add(new object[] { Id, IdShow, Quota, PlanId, PlanName, CaneSeason, CaneDate, CaneCount, SeasonYear, CaneStatus, ActivityId });
            }

            GridActivity.DataSource = null;
            GridActivity.DataSource = NewDT;
            GridActivity.DataBind();
        }

        protected void Edit_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32((sender as LinkButton).CommandArgument);

            string test = id.ToString();

            Response.Redirect("frmEdit.aspx?Parameter=" + test.ToString());

        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                int id = Convert.ToInt32((sender as LinkButton).CommandArgument);


                var lvSQL = "Update cane_activityheader SET CaneStatus = 'ยกเลิกกิจกรรม' Where Id = '" + id + "'";
                var lvResult = GsysSQL.fncExecuteQueryData(lvSQL);

                if (lvResult.Equals("Success"))
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "script1", "<script>alert('ยกเลิกข้อมูลสำเร็จ');</script>");
                    fncLoadGridActivity();
                }
            }
            else
            {
                return;
            }
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            var lvSearch = txtSearch.Text;
            var lvQuotaSearch = txtQuota.Text;
            var lvKeth = cmbKeth.Text;
            if(lvSearch != "" || lvQuotaSearch != "" || lvKeth != "")
            {
                fncLoadGridActivitySearch(lvSearch, lvQuotaSearch, lvKeth);
            }
            else
            {
                fncLoadGridActivity();
            }
            
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/frmSoftware.aspx");
        }

        protected void GridActivity_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            fncLoadGridActivity();
            GridActivity.PageIndex = e.NewPageIndex;
            GridActivity.DataBind();
        }

        private void FncCheckLoginWeb()
        {
            string url = HttpContext.Current.Request.Url.AbsoluteUri;

            string lvCookieUser = "";
            string lvOnline = "";

            //ถ้าขึ้นต้นด้วยไอพี ไม่ต้อง Login
            if (url.Contains("10.104.1.9"))
            {
                //ไม่ต้อง Login
            }
            else
            {
                //ดึงข้อมูล User เพื่อนำมาเช็คสถานะออนไลน์
                lvCookieUser = FncReadCookie("Login", "Username");

                //ถ้า Login ออนไลน์ไว้อยู่แล้วก็แสดงข้อมูลต่อได้เลย ถ้าไม่ ให้ Login ใหม่
                lvOnline = GsysSQL.fncCheckOnlineStatus(lvCookieUser);

                if (lvOnline != "")
                {
                    string lvDateNow = Gstr.fncChangeTDate(DateTime.Now.ToString("dd/MM/yyyy"));
                    string lvTimeNow = DateTime.Now.ToString("HHmmss");

                    //ถ้าออนไลน์ให้บันทึก LastUpdate ไปใหม่
                    string lvSQL = "Update SysLoginTable set L_Update = '" + lvDateNow + lvTimeNow + "' Where L_UserName = '" + lvCookieUser + "' ";
                    string lvResault = GsysSQL.fncExecuteQueryData(lvSQL);
                }
                else
                {
                    //MessageboxAlert("ไม่พบข้อมูลผู้ใช้ของท่าน กรุณาเข้าสู่ระบบใหม่อีกครั้ง");

                    //สร้าง Cookie ส่งข้อมูล Url
                    FncCreateCookie("Url", "LastUrl", url);

                    //ถ้าไม่ออนไลน์ให้ Login ใหม่
                    string lvUrlNew = "/LoginMonitor.aspx";// + "?LastUrl=" + url
                    Response.Redirect(lvUrlNew);
                }
            }
        }

        private void FncClearLogin()
        {
            string lvSQL = "";
            string lvResault = "";
            string lvDateNow = Gstr.fncChangeTDate(DateTime.Now.ToString("dd/MM/yyyy"));
            string lvTimeNow = DateTime.Now.ToString("HHmmss");
            string lvDateDiff = Gstr.fncChangeTDate(DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy"));

            lvSQL = "Delete From SysLoginTable Where L_Update < '" + lvDateDiff + lvTimeNow + "' ";
            lvResault = GsysSQL.fncExecuteQueryData(lvSQL);
        }

        private string FncReadCookie(string lvKeys, string lvName)
        {
            string lvReturn = "Success";

            try
            {
                lvReturn = Request.Cookies[lvKeys][lvName];
            }
            catch (Exception ex)
            {
                lvReturn = ex.Message;
            }

            return lvReturn;
        }

        private void FncCreateCookie(string lvKeyName, string lvName, string lvData)
        {
            //*** Instance of the HttpCookies ***//
            HttpCookie newCookie = new HttpCookie(lvKeyName);
            newCookie[lvName] = lvData;
            newCookie.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(newCookie);
        }

        private void FncDeleteCookie(string lvKeyName)
        {
            HttpCookie delCookie1;
            delCookie1 = new HttpCookie(lvKeyName);
            delCookie1.Expires = DateTime.Now.AddDays(-1D);
            Response.Cookies.Add(delCookie1);
        }
    }
}