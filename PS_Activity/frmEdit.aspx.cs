using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace PS_Activity
{
    public partial class frmEdit : System.Web.UI.Page
    {
        string Id = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            
            Page.MaintainScrollPositionOnPostBack = true; //PagePostback ไม่ต้องขึ้นมาด้านบน
            
            Id = Server.UrlDecode(Request.QueryString["Parameter"].ToString());

            if (!Page.IsPostBack)
            {
                FncCheckLoginWeb();
                fncLoadDataHeader(Id);
                fncLoadDataSoil();
                fncLoadFertilizerName();
                fncLoadDataFertilizer();
                fncLoadDataWater();
                fncLoadChemicalName();
                fncLoadDataChemical();
                fncLoadDataImage1();
                fncLoadDataImage2();
            }

            FncClearLogin();
        }

        private void fncLoadFertilizerName()
        {
            DataTable DT = new DataTable();
            var lvSQL = "Select Name From ActFertilizerName";
            DT = GsysSQL.fncGetQueryDataMCSS(lvSQL, DT);
            cmbFertilizerName1.Items.Add("-- เลือก --");
            cmbFertilizerName2.Items.Add("-- เลือก --");
            cmbFertilizerName3.Items.Add("-- เลือก --");
            cmbFertilizerName4.Items.Add("-- เลือก --");

            for (int i = 0; i < DT.Rows.Count; i++)
            {
                var Data = DT.Rows[i]["Name"].ToString();
                cmbFertilizerName1.Items.Add(Data);
                cmbFertilizerName2.Items.Add(Data);
                cmbFertilizerName3.Items.Add(Data);
                cmbFertilizerName4.Items.Add(Data);
            }
        } //Load ข้อมูลสูตรปุ๋ย

        private void fncLoadChemicalName()
        {
            DataTable DT = new DataTable();
            var lvSQL = "Select Name From ActChemicalName";
            DT = GsysSQL.fncGetQueryDataMCSS(lvSQL, DT);
            cmbCaneChemicalName1.Items.Add("-- เลือก --");
            cmbCaneChemicalName2.Items.Add("-- เลือก --");
            cmbCaneChemicalName3.Items.Add("-- เลือก --");
            cmbCaneChemicalName4.Items.Add("-- เลือก --");

            for (int i = 0; i < DT.Rows.Count; i++)
            {
                var Data = DT.Rows[i]["Name"].ToString();
                cmbCaneChemicalName1.Items.Add(Data);
                cmbCaneChemicalName2.Items.Add(Data);
                cmbCaneChemicalName3.Items.Add(Data);
                cmbCaneChemicalName4.Items.Add(Data);
            }
        } //Load ข้อมูลชนิดสารเคมี

        private void fncLoadDataChemical()
        {
            var lvPlanId = txtPlanId.Text;
            var lvSeasonYear = txtSeasonYear.Text;
            var lvCount = txtCaneCount.Text;

            DataTable DT = new DataTable();
            var lvSQL = "Select * From cane_activitychemical Where PlanId = '" + lvPlanId + "' And SeasonYear = '" + lvSeasonYear + "' And CaneCount = '" + lvCount + "' ";
            DT = GsysSQL.fncGetQueryData(lvSQL, DT);

            for (int i = 0; i < DT.Rows.Count; i++)
            {
                cmbCaneChemicalName1.Text = DT.Rows[i]["CaneChemicalName1"].ToString();
                cmbCaneChemicalName2.Text = DT.Rows[i]["CaneChemicalName2"].ToString();
                cmbCaneChemicalName3.Text = DT.Rows[i]["CaneChemicalName3"].ToString();
                cmbCaneChemicalName4.Text = DT.Rows[i]["CaneChemicalName4"].ToString();
                cmbCaneChemicalUse1.Text = DT.Rows[i]["CaneChemicalUse1"].ToString();
                cmbCaneChemicalUse2.Text = DT.Rows[i]["CaneChemicalUse2"].ToString();
                cmbCaneChemicalUse3.Text = DT.Rows[i]["CaneChemicalUse3"].ToString();
                cmbCaneChemicalUse4.Text = DT.Rows[i]["CaneChemicalUse4"].ToString();
                cmbCaneChemicalMethod1.Text = DT.Rows[i]["CaneChemicalMethod1"].ToString();
                cmbCaneChemicalMethod2.Text = DT.Rows[i]["CaneChemicalMethod2"].ToString();
                cmbCaneChemicalMethod3.Text = DT.Rows[i]["CaneChemicalMethod3"].ToString();
                cmbCaneChemicalMethod4.Text = DT.Rows[i]["CaneChemicalMethod4"].ToString();
            }
        } //Load ข้อมูลสารเคมี

        private void fncLoadDataFertilizer()
        {
            var lvPlanId = txtPlanId.Text;
            var lvSeasonYear = txtSeasonYear.Text;
            var lvCount = txtCaneCount.Text;

            DataTable DT = new DataTable();
            var lvSQL = "Select * From cane_activityfertilizer Where PlanId = '" + lvPlanId + "' And SeasonYear = '" + lvSeasonYear + "' And CaneCount = '" + lvCount + "' ";
            DT = GsysSQL.fncGetQueryData(lvSQL, DT);

            for (int i = 0; i < DT.Rows.Count; i++)
            {
                cmbFertilizerMethod.Text = DT.Rows[i]["FertilizerMethod"].ToString();
                cmbFertilizerName1.Text = DT.Rows[i]["FertilizerName1"].ToString();
                cmbFertilizerName2.Text = DT.Rows[i]["FertilizerName2"].ToString();
                cmbFertilizerName3.Text = DT.Rows[i]["FertilizerName3"].ToString();
                cmbFertilizerName4.Text = DT.Rows[i]["FertilizerName4"].ToString();
                cmbFertilizerUse1.Text = DT.Rows[i]["FertilizerUse1"].ToString();
                cmbFertilizerUse2.Text = DT.Rows[i]["FertilizerUse2"].ToString();
                cmbFertilizerUse3.Text = DT.Rows[i]["FertilizerUse3"].ToString();
                cmbFertilizerUse4.Text = DT.Rows[i]["FertilizerUse4"].ToString();
            }
        } //Load ข้อมูลปุ๋ย

        private void fncLoadDataHeader(string id)
        {
            DataTable DT = new DataTable();
            var lvSQL = "Select Quota, PlanId, PlanName, CaneSeason, CaneDate, CaneCount, CaneStatus, SeasonYear From cane_activityheader Where Id = '" + id + "'";
            DT = GsysSQL.fncGetQueryData(lvSQL, DT);

            for (int i = 0; i < DT.Rows.Count; i++)
            {
                txtQuota.Text = DT.Rows[i]["Quota"].ToString();
                txtFulName.Text = fncGetFullName(txtQuota.Text);
                txtSeasonYear.Text = DT.Rows[i]["SeasonYear"].ToString();
                txtPlanId.Text = DT.Rows[i]["PlanId"].ToString();
                txtPlanName.Text = DT.Rows[i]["PlanName"].ToString();
                txtCaneSeason.Text = DT.Rows[i]["CaneSeason"].ToString();
                txtCaneDate.Text = GsysFunc.fncChangeSDate(DT.Rows[i]["CaneDate"].ToString());
                txtCaneCount.Text = DT.Rows[i]["CaneCount"].ToString();
                if(DT.Rows[i]["CaneStatus"].ToString() == "0")
                {
                    cmbCaneStatus.Text = "ยกเลิกแปลง";
                }
                if (DT.Rows[i]["CaneStatus"].ToString() == "1")
                {
                    cmbCaneStatus.Text = "อ้อยปลูกใหม่";
                }
                if (DT.Rows[i]["CaneStatus"].ToString() == "2")
                {
                    cmbCaneStatus.Text = "ไว้ตอ";
                }

            }
        } //Load ข้อมูลพื้นฐาน

        private void fncLoadDataSoil()
        {
            var lvPlanId = txtPlanId.Text;
            var lvSeasonYear = txtSeasonYear.Text;
            var lvCount = txtCaneCount.Text;

            DataTable DT = new DataTable();
            var lvSQL = "Select * From cane_activitysoil Where PlanId = '" + lvPlanId + "' And SeasonYear = '" + lvSeasonYear + "' And CaneCount = '" + lvCount + "' ";
            DT = GsysSQL.fncGetQueryData(lvSQL, DT);

            for (int i = 0; i < DT.Rows.Count; i++)
            {
                cmbCanePrepareSoilStatus1.Text = DT.Rows[i]["CanePreparesoilStat1"].ToString();
                cmbCanePrepareSoilStatus2.Text = DT.Rows[i]["CanePreparesoilStat2"].ToString();
                cmbCanePrepareSoilStatus3.Text = DT.Rows[i]["CanePreparesoilStat3"].ToString();
                cmbCanePrepareSoilStatus4.Text = DT.Rows[i]["CanePreparesoilStat4"].ToString();
                cmbCanePrepareSoilName1.Text = DT.Rows[i]["CanePrepareSoilName1"].ToString();
                cmbCanePrepareSoilName2.Text = DT.Rows[i]["CanePrepareSoilName2"].ToString();
                cmbCanePrepareSoilName3.Text = DT.Rows[i]["CanePrepareSoilName3"].ToString();
                cmbCanePrepareSoilName4.Text = DT.Rows[i]["CanePrepareSoilName4"].ToString();
                cmbCanePrepareSoilCount1.Text = DT.Rows[i]["CanePrepareSoilCount1"].ToString();
                cmbCanePrepareSoilCount2.Text = DT.Rows[i]["CanePrepareSoilCount2"].ToString();
                cmbCanePrepareSoilCount3.Text = DT.Rows[i]["CanePrepareSoilCount3"].ToString();
                cmbCanePrepareSoilCount4.Text = DT.Rows[i]["CanePrepareSoilCount4"].ToString();
                cmbCanePrepareSoilDeep1.Text = DT.Rows[i]["CanePrepareSoilDeep1"].ToString();
                cmbCanePrepareSoilDeep2.Text = DT.Rows[i]["CanePrepareSoilDeep2"].ToString();
                cmbCanePrepareSoilDeep3.Text = DT.Rows[i]["CanePrepareSoilDeep3"].ToString();
                cmbCanePrepareSoilDeep4.Text = DT.Rows[i]["CanePrepareSoilDeep4"].ToString();
            }
        } //Load ข้อมูลดินปลูก

        private void fncLoadDataWater()
        {
            var lvPlanId = txtPlanId.Text;
            var lvSeasonYear = txtSeasonYear.Text;
            var lvCount = txtCaneCount.Text;

            DataTable DT = new DataTable();
            var lvSQL = "Select * From cane_activitywater Where PlanId = '" + lvPlanId + "' And SeasonYear = '" + lvSeasonYear + "' And CaneCount = '" + lvCount + "' ";
            DT = GsysSQL.fncGetQueryData(lvSQL, DT);

            for (int i = 0; i < DT.Rows.Count; i++)
            {
                cmbCaneWaterName.Text = DT.Rows[i]["CaneWaterName"].ToString();
                var lvDateS = DT.Rows[i]["CaneWaterDate"].ToString();
                var lvDate = "";
                if (lvDateS != "")
                {
                    lvDate = GsysFunc.DateformattingS(lvDateS);
                }
                else
                {

                }
               
                txtWaterDate.Text = lvDate.ToString();
                cmbVnasAmi.Text = DT.Rows[i]["CaneVnasAmi"].ToString();
                cmbVnasUse.Text = DT.Rows[i]["CaneVnasUse"].ToString();
                cmbRepairSoil.Text = DT.Rows[i]["CaneRepairSoil"].ToString();
                cmbShovelSoil.Text = DT.Rows[i]["CaneShovelSoil"].ToString();
                cmbControlWeeds.Text = DT.Rows[i]["CaneControlWeeds"].ToString();
                cmbDestroyWeeds.Text = DT.Rows[i]["CaneDestroyWeeds"].ToString();

            }
        } //Load ข้อมูลน้ำ

        private string fncGetFullName(string lvQuota)
        {
            #region //Connect Database 
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PSConnection"].ToString());
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader dr;
            #endregion  

            string lvReturn = "";
            string lvFirstName = "";
            string lvLastName = "";

            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "SELECT Q_FirstName, Q_LastName From cane_quota Where Q_ID = '" + lvQuota + "' ";
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    lvFirstName = dr["Q_FirstName"].ToString();
                    lvLastName = dr["Q_LastName"].ToString();
                    lvReturn = lvFirstName + " " + lvLastName;
                    //GVar.gvFirstUrl = dr["us_URL"].ToString();
                    //GVar.gvKet = dr["us_Ket"].ToString();
                    //GVar.gvUserType = dr["us_Type"].ToString();
                }
            }
            dr.Close();
            con.Close();

            return lvReturn;
        } //Load ชื่อ-สกุล

        private void fncLoadDataImage1()
        {
            var lvPlanId = txtPlanId.Text;
            var lvSeasonYear = txtSeasonYear.Text;
            var lvCount = txtCaneCount.Text;

            DataTable DT = new DataTable();
            var lvSQL = "Select * From cane_activityimage Where PlanId = '" + lvPlanId + "' And SeasonYear = '" + lvSeasonYear + "' And CaneCount = '" + lvCount + "' ";
            DT = GsysSQL.fncGetQueryData(lvSQL, DT);

            for (int i = 0; i < DT.Rows.Count; i++)
            {
                txtImageName1.Text = DT.Rows[i]["ImageName1"].ToString();
                txtImageDate1.Text = GsysFunc.fncChangeSDate(DT.Rows[i]["CaneDate1"].ToString());
                txtImageTime1.Text = DT.Rows[i]["CaneTime1"].ToString();
                txtCaneLatLong1.Text = DT.Rows[i]["CaneLatLong1"].ToString();
                var ImageName = txtImageName1.Text;
                ImageShow.ImageUrl = ImageName;
            }
        }

        private void fncLoadDataImage2()
        {
            var lvPlanId = txtPlanId.Text;
            var lvSeasonYear = txtSeasonYear.Text;
            var lvCount = txtCaneCount.Text;

            DataTable DT = new DataTable();
            var lvSQL = "Select * From cane_activityimage Where PlanId = '" + lvPlanId + "' And SeasonYear = '" + lvSeasonYear + "' And CaneCount = '" + lvCount + "' ";
            DT = GsysSQL.fncGetQueryData(lvSQL, DT);

            for (int i = 0; i < DT.Rows.Count; i++)
            {
                txtImageName2.Text = DT.Rows[i]["ImageName2"].ToString();
                txtImageDate2.Text = GsysFunc.fncChangeSDate(DT.Rows[i]["CaneDate2"].ToString());
                txtImageTime2.Text = DT.Rows[i]["CaneTime2"].ToString();
                txtCaneLatLong.Text = DT.Rows[i]["CaneLatLong2"].ToString();
                var ImageName = txtImageName2.Text;
                ImageShow2.ImageUrl = ImageName;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            fncSaveData();
        }

        private void fncSaveData()
        {
            var lvSQL = "";
            var lvResult = "";
            //Header
            var Quota = txtQuota.Text;
            var SeasonYear = txtSeasonYear.Text;
            var PlanId = txtPlanId.Text;
            var PlanName = txtPlanName.Text;
            var CaneSeason = txtCaneSeason.Text;
            var CaneDate = GsysFunc.fncChangeTDate(txtCaneDate.Text);
            var CaneCount = txtCaneCount.Text;
            var CaneStatus = cmbCaneStatus.SelectedValue;

            lvSQL = "Update cane_activityheader SET CaneStatus = '" + CaneStatus + "', SeasonYear = '" + SeasonYear + "', " +
                "PlanName = '"+PlanName+"', CaneSeason = '"+CaneSeason+"', CaneDate = '"+CaneDate+"' " +
                "Where PlanId = '" + PlanId + "' And CaneCount = '" + CaneCount + "' ";
            lvResult = GsysSQL.fncExecuteQueryData(lvSQL);

            // Soil
            var CanePrepareSoilStat1 = cmbCanePrepareSoilStatus1.SelectedValue;
            var CanePrepareSoilName1 = cmbCanePrepareSoilName1.SelectedValue;
            var CanePrepareSoilCount1 = cmbCanePrepareSoilCount1.SelectedValue;
            var CanePrepareSoilDeep1 = cmbCanePrepareSoilDeep1.SelectedValue;

            var CanePrepareSoilStat2 = cmbCanePrepareSoilStatus2.SelectedValue;
            var CanePrepareSoilName2 = cmbCanePrepareSoilName2.SelectedValue;
            var CanePrepareSoilCount2 = cmbCanePrepareSoilCount2.SelectedValue;
            var CanePrepareSoilDeep2 = cmbCanePrepareSoilDeep2.SelectedValue;

            var CanePrepareSoilStat3 = cmbCanePrepareSoilStatus3.SelectedValue;
            var CanePrepareSoilName3 = cmbCanePrepareSoilName3.SelectedValue;
            var CanePrepareSoilCount3 = cmbCanePrepareSoilCount3.SelectedValue;
            var CanePrepareSoilDeep3 = cmbCanePrepareSoilDeep3.SelectedValue;

            var CanePrepareSoilStat4 = cmbCanePrepareSoilStatus4.SelectedValue;
            var CanePrepareSoilName4 = cmbCanePrepareSoilName4.SelectedValue;
            var CanePrepareSoilCount4 = cmbCanePrepareSoilCount4.SelectedValue;
            var CanePrepareSoilDeep4 = cmbCanePrepareSoilDeep4.SelectedValue;

            string lvCheckSoil = GsysSQL.fncCheckSoil(PlanId, CaneCount);
            if (lvCheckSoil != "")
            {
                lvSQL = "Update cane_activitysoil SET CanePrepareSoilStat1 = '" + CanePrepareSoilStat1 + "', CanePrepareSoilName1 = '" + CanePrepareSoilName1 + "', " +
                    "CanePrepareSoilCount1 = '" + CanePrepareSoilCount1 + "', CanePrepareSoilDeep1 = '" + CanePrepareSoilDeep1 + "', " +
                    "CanePrepareSoilStat2 = '" + CanePrepareSoilStat2 + "', CanePrepareSoilName2 = '" + CanePrepareSoilName2 + "', " +
                    "CanePrepareSoilCount2 = '" + CanePrepareSoilCount2 + "', CanePrepareSoilDeep2 = '" + CanePrepareSoilDeep2 + "', " +
                    "CanePrepareSoilStat3 = '" + CanePrepareSoilStat3 + "', CanePrepareSoilName3 = '" + CanePrepareSoilName3 + "', " +
                    "CanePrepareSoilCount3 = '" + CanePrepareSoilCount3 + "', CanePrepareSoilDeep3 = '" + CanePrepareSoilDeep3 + "', " +
                    "CanePrepareSoilStat4 = '" + CanePrepareSoilStat4 + "', CanePrepareSoilName4 = '" + CanePrepareSoilName4 + "', " +
                    "CanePrepareSoilCount4 = '" + CanePrepareSoilCount4 + "', CanePrepareSoilDeep4 = '" + CanePrepareSoilDeep4 + "', SeasonYear = '" + SeasonYear + "' " +
                    "Where PlanId = '" + PlanId + "' And CaneCount = '" + CaneCount + "' ";
                lvResult = GsysSQL.fncExecuteQueryData(lvSQL);
            }
            else
            {
                if (CaneSeason != "ตอ1" || CaneSeason != "ตอ2" || CaneSeason != "ตอ3")
                    lvSQL = "Insert Into cane_activitysoil (PlanId, SeasonYear, CaneCount, CanePrepareSoilStat1, CanePrepareSoilName1, CanePrepareSoilCount1, CanePrepareSoilDeep1, " +
                        "CanePrepareSoilStat2, CanePrepareSoilName2, CanePrepareSoilCount2, CanePrepareSoilDeep2, CanePrepareSoilStat3, CanePrepareSoilName3, CanePrepareSoilCount3, " +
                        "CanePrepareSoilDeep3, CanePrepareSoilStat4, CanePrepareSoilName4, CanePrepareSoilCount4, CanePrepareSoilDeep4) Values ('" + PlanId + "', '" + SeasonYear + "','" + CaneCount + "', " +
                        "'" + CanePrepareSoilStat1 + "', '" + CanePrepareSoilName1 + "', '" + CanePrepareSoilCount1 + "', '" + CanePrepareSoilDeep1 + "', '" + CanePrepareSoilStat2 + "','" + CanePrepareSoilName2 + "', " +
                        "'" + CanePrepareSoilCount2 + "','" + CanePrepareSoilDeep2 + "','" + CanePrepareSoilStat3 + "','" + CanePrepareSoilName3 + "','" + CanePrepareSoilCount3 + "', " +
                        "'" + CanePrepareSoilDeep3 + "','" + CanePrepareSoilStat4 + "','" + CanePrepareSoilName4 + "','" + CanePrepareSoilCount4 + "','" + CanePrepareSoilDeep4 + "')";
                lvResult = GsysSQL.fncExecuteQueryData(lvSQL);
            }

            //Fertilizer
            var FertilizerMethod = cmbFertilizerMethod.SelectedValue;
            var FertilizerName1 = cmbFertilizerName1.SelectedValue;
            if (FertilizerName1 == "-- เลือก")
            {
                FertilizerName1 = "";
            }
            var FertilizerUse1 = cmbFertilizerUse1.SelectedValue;

            var FertilizerName2 = cmbFertilizerName2.SelectedValue;
            if (FertilizerName2 == "-- เลือก")
            {
                FertilizerName2 = "";
            }
            var FertilizerUse2 = cmbFertilizerUse2.SelectedValue;

            var FertilizerName3 = cmbFertilizerName3.SelectedValue;
            if (FertilizerName3 == "-- เลือก")
            {
                FertilizerName3 = "";
            }
            var FertilizerUse3 = cmbFertilizerUse3.SelectedValue;

            var FertilizerName4 = cmbFertilizerName4.SelectedValue;
            if (FertilizerName4 == "-- เลือก")
            {
                FertilizerName4 = "";
            }
            var FertilizerUse4 = cmbFertilizerUse4.SelectedValue;

            string lvFertilizerChk = GsysSQL.fncCheckFertilizer(PlanId, CaneCount);

            if (lvFertilizerChk != "")
            {
                lvSQL = "Update cane_activityfertilizer SET FertilizerMethod = '" + FertilizerMethod + "', FertilizerName1 = '" + FertilizerName1 + "', " +
                    "FertilizerUse1 = '" + FertilizerUse1 + "', FertilizerName2 = '" + FertilizerName2 + "', FertilizerUse2 = '" + FertilizerUse2 + "', " +
                    "FertilizerName3 = '" + FertilizerName3 + "', FertilizerUse3 = '" + FertilizerUse3 + "', FertilizerName4 = '" + FertilizerName4 + "', FertilizerUse4 = '" + FertilizerUse4 + "', SeasonYear = '" + SeasonYear + "' " +
                    "Where PlanId = '" + PlanId + "' And CaneCount = '" + CaneCount + "' ";
                lvResult = GsysSQL.fncExecuteQueryData(lvSQL);
            }
            else
            {
                lvSQL = "Insert Into (PlanId, SeasonYear, CaneCount, FertilizerMethod, FertilizerName1, FertilizerUse1, FertilizerName2, FertilizerUse2, FertilizerName3, FertilizerUse3, " +
                    "FertilizerName4, FertilizerUse4) Values ('" + PlanId + "', '" + SeasonYear + "','" + CaneCount + "','" + FertilizerMethod + "','" + FertilizerName1 + "','" + FertilizerUse1 + "' " +
                    ",'" + FertilizerName2 + "','" + FertilizerUse2 + "','" + FertilizerName3 + "','" + FertilizerUse3 + "','" + FertilizerName4 + "','" + FertilizerUse4 + "')";
                lvResult = GsysSQL.fncExecuteQueryData(lvSQL);
            }

            //Water
            var CaneWaterName = cmbCaneWaterName.SelectedValue;
            var CaneWaterDate = txtWaterDate.Text;
            var CaneWaterDateUse = "";
            if (CaneWaterDate != "")
            {
                CaneWaterDateUse = GsysFunc.fncChangeTDate(GsysFunc.DateformattingT(txtWaterDate.Text));
            }
            else
            {

            }
            
            var CaneVnasAmi = cmbVnasAmi.SelectedValue;
            var CaneVnasUse = cmbVnasUse.SelectedValue;
            var CaneRepairSoil = cmbRepairSoil.SelectedValue;
            var CaneShovelSoil = cmbShovelSoil.SelectedValue;
            var CaneControlWeeds = cmbControlWeeds.SelectedValue;
            var CaneDestroyWeeds = cmbDestroyWeeds.SelectedValue;

            string lvWaterChk = GsysSQL.fncCheckWater(PlanId, CaneCount);
            if (lvWaterChk != "")
            {
                lvSQL = "Update cane_activitywater SET CaneWaterName = '" + CaneWaterName + "', CaneWaterDate '" + CaneWaterDateUse + "', CaneVnasAmi = '" + CaneVnasAmi + "', " +
                    "CaneVnasUse = '" + CaneVnasUse + "', CaneRepairSoil = '" + CaneRepairSoil + "', CaneShovelSoil = '" + CaneShovelSoil + "', CaneControlWeeds = '" + CaneControlWeeds + "', " +
                    "CaneDestroyWeeds = '" + CaneDestroyWeeds + "', SeasonYear = '" + SeasonYear + "' Where PlanId = '" + PlanId + "' And CaneCount = '" + CaneCount + "' ";
                lvResult = GsysSQL.fncExecuteQueryData(lvSQL);
            }
            else
            {
                lvSQL = "Insert Into cane_activitywater (PlanId, SeasonYear, CaneCount, CaneWaterName, CaneWaterDate, CaneVnasAmi, CaneVnasUse, CaneRepairSoil, CaneShovelSoil, CaneControlWeeds, CaneDestroyWeeds) " +
                    "Values ('" + PlanId + "', '" + SeasonYear + "','" + CaneCount + "','" + CaneWaterName + "','" + CaneWaterDateUse + "','" + CaneVnasAmi + "','" + CaneVnasUse + "','" + CaneRepairSoil + "','" + CaneShovelSoil + "'," +
                    "'" + CaneControlWeeds + "','" + CaneDestroyWeeds + "')";
                lvResult = GsysSQL.fncExecuteQueryData(lvSQL);
            }

            //Chemical
            var CaneChemicalName1 = cmbCaneChemicalName1.SelectedValue;
            if(CaneChemicalName1 == "-- เลือก --")
            {
                CaneChemicalName1 = "";
            }
            var CaneChemicalUse1 = cmbCaneChemicalUse1.SelectedValue;
            var CaneChemicalMethod1 = cmbCaneChemicalMethod1.SelectedValue;
            var CaneChemicalName2 = cmbCaneChemicalName2.SelectedValue;
            if (CaneChemicalName2 == "-- เลือก --")
            {
                CaneChemicalName2 = "";
            }
            var CaneChemicalUse2 = cmbCaneChemicalUse2.SelectedValue;
            var CaneChemicalMethod2 = cmbCaneChemicalMethod2.SelectedValue;
            var CaneChemicalName3 = cmbCaneChemicalName3.SelectedValue;
            if (CaneChemicalName3 == "-- เลือก --")
            {
                CaneChemicalName3 = "";
            }
            var CaneChemicalUse3 = cmbCaneChemicalUse3.SelectedValue;
            var CaneChemicalMethod3 = cmbCaneChemicalMethod3.SelectedValue;
            var CaneChemicalName4 = cmbCaneChemicalName4.SelectedValue;
            if (CaneChemicalName4 == "-- เลือก --")
            {
                CaneChemicalName4 = "";
            }
            var CaneChemicalUse4 = cmbCaneChemicalUse4.SelectedValue;
            var CaneChemicalMethod4 = cmbCaneChemicalMethod4.SelectedValue;

            string lvChemicalChk = GsysSQL.fncCheckChemical(PlanId, CaneCount);

            if (lvChemicalChk != "")
            {
                lvSQL = "Update cane_activitychemical SET CaneChemicalName1 = '" + CaneChemicalName1 + "', CaneChemicalUse1 = '" + CaneChemicalUse1 + "', " +
                    "CaneChemicalMethod1 = '" + CaneChemicalMethod1 + "', CaneChemicalName2 = '" + CaneChemicalName2 + "', CaneChemicalUse2 = '" + CaneChemicalUse2 + "'," +
                    "CaneChemicalMethod2 = '" + CaneChemicalMethod2 + "', CaneChemicalName3 = '" + CaneChemicalName3 + "', CaneChemicalUse3 = '" + CaneChemicalUse3 + "', " +
                    "CaneChemicalMethod3 = '" + CaneChemicalMethod3 + "', CaneChemicalName4 = '" + CaneChemicalName4 + "', CaneChemicalUse4 = '" + CaneChemicalUse4 + "', " +
                    "CaneChemicalMethod4 = '" + CaneChemicalMethod4 + "', SeasonYear = '" + SeasonYear + "' Where PlanId = '" + PlanId + "' And CaneCount = '" + CaneCount + "' ";
                lvResult = GsysSQL.fncExecuteQueryData(lvSQL);
            }
            else
            {
                lvSQL = "Insert Into cane_activitychemical (PlanId, SeasonYear, CaneCount, CaneChemicalName1, CaneChemicalUse1, CaneChemicalMethod1, CaneChemicalName2, CaneChemicalUse2, " +
                    "CaneChemicalMethod2, CaneChemicalName3, CaneChemicalUse3, CaneChemicalMethod3, CaneChemicalName4, CaneChemicalUse4, CaneChemicalMethod4) " +
                    "Values ('" + PlanId + "','" + SeasonYear + "','" + CaneCount + "','" + CaneChemicalName1 + "','" + CaneChemicalUse1 + "','" + CaneChemicalMethod1 + "','" + CaneChemicalName2 + "', " +
                    "'" + CaneChemicalUse2 + "','" + CaneChemicalMethod2 + "','" + CaneChemicalName3 + "','" + CaneChemicalUse3 + "','" + CaneChemicalMethod3 + "','" + CaneChemicalName4 + "', " +
                    "'" + CaneChemicalUse4 + "','" + CaneChemicalMethod4 + "')";
                lvResult = GsysSQL.fncExecuteQueryData(lvSQL);
            }

            string lvPlanImageChk = GsysSQL.fncCheckImage(PlanId, CaneCount);
            if (lvPlanImageChk != "")
            {
                if (FileUpload1.PostedFile != null)
                {
                    string imgFile = Path.GetFileName(FileUpload1.PostedFile.FileName);

                    if (imgFile != "")
                    {
                        FileUpload1.SaveAs("D://PSWeb/PS_Activity/Uploads/" + imgFile);
                        string lvImagePath = "/PS_Activity/Uploads/" + imgFile;
                        lvSQL = "Update cane_activityimage Set ImageName1 = '" + lvImagePath + "' Where PlanId = '" + PlanId + "' And CaneCount = '" + CaneCount + "'";
                        lvResult = GsysSQL.fncExecuteQueryData(lvSQL);
                    }

                }

                if (FileUpload2.PostedFile != null)
                {
                    string imgFile = Path.GetFileName(FileUpload2.PostedFile.FileName);
                    if (imgFile != "")
                    {
                        FileUpload2.SaveAs("D://PSWeb/PS_Activity/Uploads/" + imgFile);
                        string lvImagePath = "/PS_Activity/Uploads/" + imgFile;
                        lvSQL = "Update cane_activityimage Set ImageName2 = '" + lvImagePath + "' Where PlanId = '" + PlanId + "' And CaneCount = '" + CaneCount + "'";
                        lvResult = GsysSQL.fncExecuteQueryData(lvSQL);
                    }

                }
            }
            else
            {
                if (FileUpload1.PostedFile != null)
                {
                    string imgFile = Path.GetFileName(FileUpload1.PostedFile.FileName);

                    if (imgFile != "")
                    {
                        FileUpload1.SaveAs("D://PSWeb/PS_Activity/Uploads/" + imgFile);
                        string lvImagePath = "/PS_Activity/Uploads/" + imgFile;
                        lvSQL = "Insert Into cane_activityimage (PlanId, SeasonYear, ImageName1, ImageName2, CaneLatLong1, CaneLatLong2, CaneDate1, CaneDate2, CaneTime1, CaneTime2, CaneCount) " +
                            "Values ('" + PlanId + "','" + SeasonYear + "','" + txtImageName1.Text + "','" + txtImageName2.Text + "','" + txtCaneLatLong1.Text + "','" + txtCaneLatLong.Text + "','" + txtImageDate1.Text + "','" + txtImageDate2.Text + "','" + txtImageTime1.Text + "', " +
                            "'" + txtImageTime2.Text + "', '" + CaneCount + "')";
                        lvResult = GsysSQL.fncExecuteQueryData(lvSQL);
                    }

                }

                if (FileUpload2.PostedFile != null)
                {
                    string imgFile = Path.GetFileName(FileUpload2.PostedFile.FileName);
                    if (imgFile != "")
                    {
                        FileUpload2.SaveAs("D://PSWeb/PS_Activity/Uploads/" + imgFile);
                        string lvImagePath = "/PS_Activity/Uploads/" + imgFile;
                        lvSQL = "Update cane_activityimage Set ImageName2 = '" + txtImageName2.Text + "', CaneLatLong1 = '" + txtCaneLatLong1.Text + "', CaneLatLong2 = '" + txtCaneLatLong.Text + "', CaneDate1 = '" + txtImageDate1.Text + "', " +
                            "CaneDate2 = '" + txtImageDate2.Text + "', CaneTime1 = '" + txtImageTime1.Text + "', CaneTime2 = '" + txtImageTime2.Text + "' " +
                            "Where PlanId = '" + PlanId + "' And CaneCount = '" + CaneCount + "'";
                        lvResult = GsysSQL.fncExecuteQueryData(lvSQL);
                    }

                }
            }

            if (lvResult == "Success")
            {
                MsgBox("อัพเดทข้อมูลสำเร็จ", this.Page, this);
                //fncLoadDataHeader(Id);
                //fncLoadDataSoil();
                //fncLoadFertilizerName();
                //fncLoadDataFertilizer();
                //fncLoadDataWater();
                //fncLoadChemicalName();
                //fncLoadDataChemical();
                fncLoadDataImage1();
                fncLoadDataImage2();
            }
        }

        private void fncPrintReport()
        {
            var lvSQL = "";
            var lvResult = "";
            //Header
            var Quota = txtQuota.Text;
            var SeasonYear = txtSeasonYear.Text;
            var PlanId = txtPlanId.Text;
            var PlanName = txtPlanName.Text;
            var FullName = txtFulName.Text;
            var CaneSeason = txtCaneSeason.Text;
            var CaneDate = txtCaneDate.Text;
            var CaneCount = txtCaneCount.Text;
            var CaneStatus = cmbCaneStatus.SelectedValue; //8

            // Soil
            var CanePrepareSoilStat1 = cmbCanePrepareSoilStatus1.SelectedValue;
            var CanePrepareSoilName1 = cmbCanePrepareSoilName1.SelectedValue;
            var CanePrepareSoilCount1 = cmbCanePrepareSoilCount1.SelectedValue;
            var CanePrepareSoilDeep1 = cmbCanePrepareSoilDeep1.SelectedValue;

            var CanePrepareSoilStat2 = cmbCanePrepareSoilStatus2.SelectedValue;
            var CanePrepareSoilName2 = cmbCanePrepareSoilName2.SelectedValue;
            var CanePrepareSoilCount2 = cmbCanePrepareSoilCount2.SelectedValue;
            var CanePrepareSoilDeep2 = cmbCanePrepareSoilDeep2.SelectedValue;

            var CanePrepareSoilStat3 = cmbCanePrepareSoilStatus3.SelectedValue;
            var CanePrepareSoilName3 = cmbCanePrepareSoilName3.SelectedValue;
            var CanePrepareSoilCount3 = cmbCanePrepareSoilCount3.SelectedValue;
            var CanePrepareSoilDeep3 = cmbCanePrepareSoilDeep3.SelectedValue;

            var CanePrepareSoilStat4 = cmbCanePrepareSoilStatus4.SelectedValue;
            var CanePrepareSoilName4 = cmbCanePrepareSoilName4.SelectedValue;
            var CanePrepareSoilCount4 = cmbCanePrepareSoilCount4.SelectedValue;
            var CanePrepareSoilDeep4 = cmbCanePrepareSoilDeep4.SelectedValue; //24

            //Fertilizer
            var FertilizerMethod = cmbFertilizerMethod.SelectedValue;
            var FertilizerName1 = cmbFertilizerName1.SelectedValue;
            if(FertilizerName1 == "-- เลือก --")
            {
                FertilizerName1 = "";
            }
            var FertilizerUse1 = cmbFertilizerUse1.SelectedValue;

            var FertilizerName2 = cmbFertilizerName2.SelectedValue;
            if (FertilizerName2 == "-- เลือก --")
            {
                FertilizerName2 = "";
            }
            var FertilizerUse2 = cmbFertilizerUse2.SelectedValue;

            var FertilizerName3 = cmbFertilizerName3.SelectedValue;
            if (FertilizerName3 == "-- เลือก --")
            {
                FertilizerName3 = "";
            }
            var FertilizerUse3 = cmbFertilizerUse3.SelectedValue;

            var FertilizerName4 = cmbFertilizerName4.SelectedValue;
            if (FertilizerName4 == "-- เลือก --")
            {
                FertilizerName4 = "";
            }
            var FertilizerUse4 = cmbFertilizerUse4.SelectedValue; //33

            //Water
            var CaneWaterName = cmbCaneWaterName.SelectedValue;
            var CaneWaterDate = txtWaterDate.Text;
            var CaneWaterDateUse = "";
            if(CaneWaterDate != "")
            {
                CaneWaterDateUse = GsysFunc.DateformattingT(CaneWaterDate);
            }
            else
            {

            }
            
            var CaneVnasAmi = cmbVnasAmi.SelectedValue;
            var CaneVnasUse = cmbVnasUse.SelectedValue;
            var CaneRepairSoil = cmbRepairSoil.SelectedValue;
            var CaneShovelSoil = cmbShovelSoil.SelectedValue;
            var CaneControlWeeds = cmbControlWeeds.SelectedValue;
            var CaneDestroyWeeds = cmbDestroyWeeds.SelectedValue; //41

            //Chemical
            var CaneChemicalName1 = cmbCaneChemicalName1.SelectedValue;
            if(CaneChemicalName1 == "-- เลือก --")
            {
                CaneChemicalName1 = "";
            }
            var CaneChemicalUse1 = cmbCaneChemicalUse1.SelectedValue;
            var CaneChemicalMethod1 = cmbCaneChemicalMethod1.SelectedValue;
            var CaneChemicalName2 = cmbCaneChemicalName2.SelectedValue;
            if (CaneChemicalName2 == "-- เลือก --")
            {
                CaneChemicalName2 = "";
            }
            var CaneChemicalUse2 = cmbCaneChemicalUse2.SelectedValue;
            var CaneChemicalMethod2 = cmbCaneChemicalMethod2.SelectedValue;
            var CaneChemicalName3 = cmbCaneChemicalName3.SelectedValue;
            if (CaneChemicalName3 == "-- เลือก --")
            {
                CaneChemicalName3 = "";
            }
            var CaneChemicalUse3 = cmbCaneChemicalUse3.SelectedValue;
            var CaneChemicalMethod3 = cmbCaneChemicalMethod3.SelectedValue;
            var CaneChemicalName4 = cmbCaneChemicalName4.SelectedValue;
            if (CaneChemicalName4 == "-- เลือก --")
            {
                CaneChemicalName4 = "";
            }
            var CaneChemicalUse4 = cmbCaneChemicalUse4.SelectedValue;
            var CaneChemicalMethod4 = cmbCaneChemicalMethod4.SelectedValue; //53

            var ImageName1 = "D:/PSWeb" + txtImageName1.Text;
            var ImageName2 = "D:/PSWeb" + txtImageName2.Text;

            var GPS1 = txtCaneLatLong1.Text;
            var GPS2 = txtCaneLatLong.Text;

            var ImageShow1 = txtImageName1.Text;
            var ImageShow1Split = ImageShow1.Split('/');
            var ImageUse1 = ImageShow1Split[3];
            var ImageShow2 = txtImageName2.Text;
            var ImageShow2Split = ImageShow2.Split('/');
            var ImageUse2 = ImageShow2Split[3];

            var ImageDate1 = txtImageDate1.Text;
            var ImageDate2 = txtImageDate2.Text;

            var ImageTime1 = txtImageTime1.Text;
            var ImageTime2 = txtImageTime2.Text;

            var Project = "PS_Activity";

            lvSQL = "Delete From systemp Where S_Project = '" + Project + "'";
            lvResult = GsysSQL.fncExecuteQueryData(lvSQL);

            lvSQL = "Insert Into systemp (S_Field1, S_Field2, S_Field3, S_Field4, S_Field5, S_Field6, S_Field7, S_Field8, S_Field9, S_Field10, S_Field11, " +
                "S_Field12, S_Field13, S_Field14, S_Field15, S_Field16, S_Field17, S_Field18, S_Field19, S_Field20, S_Field21, S_Field22, S_Field23, S_Field24, " +
                "S_Field25, S_Field26, S_Field27, S_Field28, S_Field29, S_Field30, S_Field31, S_Field32, S_Field33, S_Field34, S_Field35, S_Field36, S_Field37, S_Field38, " +
                "S_Field39, S_Field40, S_Field41, S_Field42, S_Field43, S_Field44, S_Field45, S_Field46, S_Field47, S_Field48, S_Field49, S_Field50, S_Field51, S_Field52, S_Field53, S_Field54, S_Field55, S_Field56, S_Field57, S_Field58, S_Field59, S_Field60, " +
                "S_Field61, S_Field62, S_Field63, S_Field64, S_Project) " +
                "Values ('" + Quota + "', '" + SeasonYear + "', '" + PlanId + "', '" + PlanName + "', '" + CaneSeason + "', '" + CaneDate + "', '" + CaneCount + "', '" + CaneStatus + "', " +
                "'" + CanePrepareSoilStat1 + "', '" + CanePrepareSoilName1 + "', '" + CanePrepareSoilCount1 + "', '" + CanePrepareSoilDeep1 + "', '" + CanePrepareSoilStat2 + "', '" + CanePrepareSoilName2 + "', " +
                "'" + CanePrepareSoilCount2 + "', '" + CanePrepareSoilDeep2 + "', '" + CanePrepareSoilStat3 + "', '" + CanePrepareSoilName3 + "', '" + CanePrepareSoilCount3 + "', " +
                "'" + CanePrepareSoilDeep3 + "', '" + CanePrepareSoilStat4 + "', '" + CanePrepareSoilName4 + "', '" + CanePrepareSoilCount4 + "', '" + CanePrepareSoilDeep4 + "', " +
                "'" + FertilizerMethod + "', '" + FertilizerName1 + "', '" + FertilizerUse1 + "', '" + FertilizerName2 + "', '" + FertilizerUse2 + "', '" + FertilizerName3 + "', " +
                "'" + FertilizerUse3 + "', '" + FertilizerName4 + "', '" + FertilizerUse4 + "', '" + CaneWaterName + "', '" + CaneWaterDateUse + "', '" + CaneVnasAmi + "', '" + CaneVnasUse + "', '" + CaneRepairSoil + "', " +
                "'" + CaneShovelSoil + "', '" + CaneControlWeeds + "', '" + CaneDestroyWeeds + "', '" + CaneChemicalName1 + "', '" + CaneChemicalUse1 + "', '" + CaneChemicalMethod1 + "', '" + CaneChemicalName2 + "', '" + CaneChemicalUse2 + "', " +
                "'" + CaneChemicalMethod2 + "', '" + CaneChemicalName3 + "', '" + CaneChemicalUse3 + "', '" + CaneChemicalMethod3 + "', '" + CaneChemicalName4 + "', '" + CaneChemicalUse4 + "', '" + CaneChemicalMethod4 + "', '" + ImageName1 + "', " +
                "'" + ImageName2 + "', '" + FullName + "', '" + GPS1 + "', '" + GPS2 + "', '" + ImageUse1 + "', '" + ImageUse2 + "', '" + ImageDate1 + "', '" + ImageDate2 + "', '" + ImageTime1 + "', '" + ImageTime2 + "', '" + Project + "')";
            lvResult = GsysSQL.fncExecuteQueryData(lvSQL);

            if (lvResult == "Success")
            {
                MsgBox("อัพเดทข้อมูลสำเร็จ", this.Page, this);
            }
        }

        public void MsgBox(String ex, Page pg, Object obj)
        {
            string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
            Type cstype = obj.GetType();
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(cstype, s, s.ToString());
        } //MsgBox Alert

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmIndex.aspx");
        }

        protected void btnPrintReport_Click(object sender, EventArgs e)
        {
            fncPrintReport();
            Response.Redirect("frmReport.aspx");
        }

        protected void btnGoogleMap_Click(object sender, EventArgs e)
        {
            var LatLong = txtCaneLatLong.Text;
            var LatLongSplit = LatLong.Split(',');
            var Lat = LatLongSplit[0];
            var Long = LatLongSplit[1];
            var mapUrl = "http://maps.google.com/maps?z=12&t=m&q=loc:" + Lat + "+" + Long;
            Response.Redirect(mapUrl);
        }

        protected void btnGoogleMap1_Click(object sender, EventArgs e)
        {
            var LatLong = txtCaneLatLong1.Text;
            var LatLongSplit = LatLong.Split(',');
            var Lat = LatLongSplit[0];
            var Long = LatLongSplit[1];
            var mapUrl = "http://maps.google.com/maps?z=12&t=m&q=loc:" + Lat + "+" + Long;
            Response.Redirect(mapUrl);
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

            fncEnableText(lvCookieUser);
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

        void fncEnableText(string lvUsers)
        {
            if(lvUsers == "zom" || lvUsers == "admin")
            {
                txtQuota.Enabled = true;
                txtFulName.Enabled = true;
                txtSeasonYear.Enabled = true;
                txtPlanId.Enabled = true;
                txtPlanName.Enabled = true;
                txtCaneSeason.Enabled = true;
                txtCaneDate.Enabled = true;
                txtCaneCount.Enabled = true;
                cmbCaneStatus.Enabled = true;
                cmbCanePrepareSoilStatus1.Enabled = true;
                cmbCanePrepareSoilName1.Enabled = true;
                cmbCanePrepareSoilCount1.Enabled = true;
                cmbCanePrepareSoilDeep1.Enabled = true;
                cmbCanePrepareSoilStatus2.Enabled = true;
                cmbCanePrepareSoilName2.Enabled = true;
                cmbCanePrepareSoilCount2.Enabled = true;
                cmbCanePrepareSoilDeep2.Enabled = true;
                cmbCanePrepareSoilStatus3.Enabled = true;
                cmbCanePrepareSoilName3.Enabled = true;
                cmbCanePrepareSoilCount3.Enabled = true;
                cmbCanePrepareSoilDeep3.Enabled = true;
                cmbCanePrepareSoilStatus4.Enabled = true;
                cmbCanePrepareSoilName4.Enabled = true;
                cmbCanePrepareSoilCount4.Enabled = true;
                cmbCanePrepareSoilDeep4.Enabled = true;
                cmbFertilizerMethod.Enabled = true;
                cmbFertilizerName1.Enabled = true;
                cmbFertilizerUse1.Enabled = true;
                cmbFertilizerName2.Enabled = true;
                cmbFertilizerUse2.Enabled = true;
                cmbFertilizerName3.Enabled = true;
                cmbFertilizerUse3.Enabled = true;
                cmbFertilizerName4.Enabled = true;
                cmbFertilizerUse4.Enabled = true;
                cmbCaneWaterName.Enabled = true;
                txtWaterDate.Enabled = true;
                cmbVnasAmi.Enabled = true;
                cmbVnasUse.Enabled = true;
                cmbRepairSoil.Enabled = true;
                cmbShovelSoil.Enabled = true;
                cmbControlWeeds.Enabled = true;
                cmbDestroyWeeds.Enabled = true;
                cmbCaneChemicalName1.Enabled = true;
                cmbCaneChemicalUse1.Enabled = true;
                cmbCaneChemicalMethod1.Enabled = true;
                cmbCaneChemicalName2.Enabled = true;
                cmbCaneChemicalUse2.Enabled = true;
                cmbCaneChemicalMethod2.Enabled = true;
                cmbCaneChemicalName3.Enabled = true;
                cmbCaneChemicalUse3.Enabled = true;
                cmbCaneChemicalMethod3.Enabled = true;
                cmbCaneChemicalName4.Enabled = true;
                cmbCaneChemicalUse4.Enabled = true;
                cmbCaneChemicalMethod4.Enabled = true;
                txtImageName1.Enabled = true;
                txtImageName2.Enabled = true;
                txtImageDate1.Enabled = true;
                txtImageDate2.Enabled = true;
                txtImageTime1.Enabled = true;
                txtImageTime2.Enabled = true;
                txtCaneLatLong.Enabled = true;
                txtCaneLatLong1.Enabled = true;
                FileUpload1.Enabled = true;
                FileUpload2.Enabled = true;
            }
            else
            {
                txtQuota.Enabled = false;
                txtFulName.Enabled = false;
                txtSeasonYear.Enabled = false;
                txtPlanId.Enabled = false;
                txtPlanName.Enabled = false;
                txtCaneSeason.Enabled = false;
                txtCaneDate.Enabled = false;
                txtCaneCount.Enabled = false;
                cmbCaneStatus.Enabled = false;
                cmbCanePrepareSoilStatus1.Enabled = false;
                cmbCanePrepareSoilName1.Enabled = false;
                cmbCanePrepareSoilCount1.Enabled = false;
                cmbCanePrepareSoilDeep1.Enabled = false;
                cmbCanePrepareSoilStatus2.Enabled = false;
                cmbCanePrepareSoilName2.Enabled = false;
                cmbCanePrepareSoilCount2.Enabled = false;
                cmbCanePrepareSoilDeep2.Enabled = false;
                cmbCanePrepareSoilStatus3.Enabled = false;
                cmbCanePrepareSoilName3.Enabled = false;
                cmbCanePrepareSoilCount3.Enabled = false;
                cmbCanePrepareSoilDeep3.Enabled = false;
                cmbCanePrepareSoilStatus4.Enabled = false;
                cmbCanePrepareSoilName4.Enabled = false;
                cmbCanePrepareSoilCount4.Enabled = false;
                cmbCanePrepareSoilDeep4.Enabled = false;
                cmbFertilizerMethod.Enabled = false;
                cmbFertilizerName1.Enabled = false;
                cmbFertilizerUse1.Enabled = false;
                cmbFertilizerName2.Enabled = false;
                cmbFertilizerUse2.Enabled = false;
                cmbFertilizerName3.Enabled = false;
                cmbFertilizerUse3.Enabled = false;
                cmbFertilizerName4.Enabled = false;
                cmbFertilizerUse4.Enabled = false;
                cmbCaneWaterName.Enabled = false;
                txtWaterDate.Enabled = false;
                cmbVnasAmi.Enabled = false;
                cmbVnasUse.Enabled = false;
                cmbRepairSoil.Enabled = false;
                cmbShovelSoil.Enabled = false;
                cmbControlWeeds.Enabled = false;
                cmbDestroyWeeds.Enabled = false;
                cmbCaneChemicalName1.Enabled = false;
                cmbCaneChemicalUse1.Enabled = false;
                cmbCaneChemicalMethod1.Enabled = false;
                cmbCaneChemicalName2.Enabled = false;
                cmbCaneChemicalUse2.Enabled = false;
                cmbCaneChemicalMethod2.Enabled = false;
                cmbCaneChemicalName3.Enabled = false;
                cmbCaneChemicalUse3.Enabled = false;
                cmbCaneChemicalMethod3.Enabled = false;
                cmbCaneChemicalName4.Enabled = false;
                cmbCaneChemicalUse4.Enabled = false;
                cmbCaneChemicalMethod4.Enabled = false;
                txtImageName1.Enabled = false;
                txtImageName2.Enabled = false;
                txtImageDate1.Enabled = false;
                txtImageDate2.Enabled = false;
                txtImageTime1.Enabled = false;
                txtImageTime2.Enabled = false;
                txtCaneLatLong.Enabled = false;
                txtCaneLatLong1.Enabled = false;
                FileUpload1.Enabled = false;
                FileUpload2.Enabled = false;
            }
        }
    }
}