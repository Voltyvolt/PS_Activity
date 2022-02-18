<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="frmEdit.aspx.cs" Inherits="PS_Activity.frmEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">

    <link href="https://fonts.googleapis.com/css2?family=Prompt:wght@500&display=swap" rel="stylesheet" />
    <link href="Content/font-awesome.min.css" rel="stylesheet" />

    <style>
        .panel-background {
            font-family: 'Prompt', sans-serif;
            border-bottom: solid;
            border-color: black;
        }

        .btnsubmit {
            border: none;
            outline: none;
            height: 40px;
            font-size: 16px;
            color: black;
            background-color: mediumspringgreen;
            width: 100%;
            cursor: pointer;
            border-radius: 20px;
            transition: .3s ease-in-out;
        }

        .btnsubmit:hover {
            background-color: darkturquoise;
        }

        .btncancel {
            border: none;
            outline: none;
            height: 40px;
            font-size: 16px;
            color: black;
            background-color: red;
            width: 100%;
            cursor: pointer;
            border-radius: 20px;
            transition: .3s ease-in-out;
        }

        .btncancel:hover {
            background-color: darkred;
        }

        .btngps {
            border: none;
            outline: none;
            height: 40px;
            font-size: 16px;
            color: black;
            background-color: skyblue;
            width: 100%;
            cursor: pointer;
            border-radius: 20px;
            transition: .3s ease-in-out;
        }

            .btngps:hover {
                background-color: deepskyblue;
            }
    </style>

    <section id="wrapper">
        <div class="col-lg-12">
            <section class="panel">
                <div class="panel-background">
                    <header class="panel-heading">
                        <div class="col-md-12 col-md-offset-4">
                            <h1>จัดการข้อมูลการบำรุงรักษา</h1>
                        </div>
                    </header>

                    <br />
                    <br />
                    <br />

                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <h3>ข้อมูล Header</h3>
                                </div>
                            </div>
                        </div>
                        <br />

                        <div class="row">
                            <div class="col-md-3 col-md-offset-9">
                                <asp:Button runat="server" Text="พิมพ์รายงาน" ID="btnPrintReport" CssClass="btnsubmit" OnClick="btnPrintReport_Click" />
                            </div>
                        </div>


                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <asp:Label Text="โควต้า" runat="server"></asp:Label>
                                    <asp:TextBox runat="server" CssClass="form-control" placeholder="โควต้า" ID="txtQuota"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <asp:Label Text="ชื่อ-สกุล" runat="server"></asp:Label>
                                    <asp:TextBox runat="server" CssClass="form-control" placeholder="ชื่อ-สกุล" ID="txtFulName"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <asp:Label Text="ปีการผลิต" runat="server"></asp:Label>
                                    <asp:TextBox runat="server" CssClass="form-control" placeholder="ปีการผลิต" ID="txtSeasonYear"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <asp:Label Text="เลขที่แปลง" runat="server"></asp:Label>
                                    <asp:TextBox runat="server" CssClass="form-control" placeholder="เลขที่แปลง" ID="txtPlanId"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <asp:Label Text="ชื่อแปลง" runat="server"></asp:Label>
                                    <asp:TextBox runat="server" CssClass="form-control" placeholder="ชื่อแปลง" ID="txtPlanName"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="form-group">
                                    <asp:Label Text="ประเภทอ้อย" runat="server"></asp:Label>
                                    <asp:TextBox runat="server" CssClass="form-control" placeholder="ประเภทอ้อย" ID="txtCaneSeason"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <asp:Label Text="วันที่" runat="server"></asp:Label>
                                    <asp:TextBox runat="server" CssClass="form-control" placeholder="วันที่" ID="txtCaneDate"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <asp:Label Text="ครั้งที่" runat="server"></asp:Label>
                                    <asp:TextBox runat="server" CssClass="form-control" placeholder="ครั้งที่" ID="txtCaneCount"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="form-group">
                                    <asp:Label Text="สถานะ" runat="server"></asp:Label>
                                    <div class="dropdown">
                                        <asp:DropDownList runat="server" placeholder="สถานะ" AutoPostBack="true" ID="cmbCaneStatus" CssClass="form-control">
                                            <asp:ListItem Value="">-- เลือก --</asp:ListItem>
                                            <asp:ListItem Value="">อ้อยปลูกใหม่</asp:ListItem>
                                            <asp:ListItem Value="ไว้ตอ">ไว้ตอ</asp:ListItem>
                                            <asp:ListItem Value="ยกเลิกแปลง">ยกเลิกแปลง</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <h3>ข้อมูลดินปลูก</h3>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-3">
                                <div class="form-group">
                                    <asp:Label Text="การเตรียมดินปลูก #1" runat="server"></asp:Label>
                                    <div class="dropdown">
                                        <asp:DropDownList runat="server" placeholder="การเตรียมดินปลูก #1" AutoPostBack="true" ID="cmbCanePrepareSoilStatus1" CssClass="form-control">
                                            <asp:ListItem Value="">-- เลือก --</asp:ListItem>
                                            <asp:ListItem Value="การพรวนดิน">การพรวนดิน</asp:ListItem>
                                            <asp:ListItem Value="พรวนล้มร่อง">พรวนล้มร่อง</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-3">
                                <div class="form-group">
                                    <asp:Label Text="ชื่อ #1" runat="server"></asp:Label>
                                    <div class="dropdown">
                                        <asp:DropDownList runat="server" placeholder="ชื่อ #1" AutoPostBack="true" ID="cmbCanePrepareSoilName1" CssClass="form-control">
                                            <asp:ListItem Value="">-- เลือก --</asp:ListItem>
                                            <asp:ListItem Value="ผาน3">ผาน3</asp:ListItem>
                                            <asp:ListItem Value="ผาน7">ผาน7</asp:ListItem>
                                            <asp:ListItem Value="พราน24">พราน24</asp:ListItem>
                                            <asp:ListItem Value="พรวน12">พรวน12</asp:ListItem>
                                            <asp:ListItem Value="ริปเปอร์">ริปเปอร์</asp:ListItem>
                                            <asp:ListItem Value="เพาเวอร์ฮาโร่">เพาเวอร์ฮาโร่</asp:ListItem>
                                            <asp:ListItem Value="มินิคอมบาย">มินิคอมบาย</asp:ListItem>
                                            <asp:ListItem Value="อื่นๆ">อื่นๆ</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-3">
                                <div class="form-group">
                                    <asp:Label Text="จำนวนครั้ง #1" runat="server"></asp:Label>
                                    <div class="dropdown">
                                        <asp:DropDownList runat="server" placeholder="จำนวนครั้ง #1" AutoPostBack="true" ID="cmbCanePrepareSoilCount1" CssClass="form-control">
                                            <asp:ListItem Value="">-- เลือก --</asp:ListItem>
                                            <asp:ListItem Value="1 ครั้ง">1 ครั้ง</asp:ListItem>
                                            <asp:ListItem Value="2 ครั้ง">2 ครั้ง</asp:ListItem>
                                            <asp:ListItem Value="3 ครั้ง">3 ครั้ง</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-3">
                                <div class="form-group">
                                    <asp:Label Text="ลึก/ซม. #1" runat="server"></asp:Label>
                                    <div class="dropdown">
                                        <asp:DropDownList runat="server" placeholder="ลึก/ซม. #1" AutoPostBack="true" ID="cmbCanePrepareSoilDeep1" CssClass="form-control">
                                            <asp:ListItem Value="">-- เลือก --</asp:ListItem>
                                            <asp:ListItem Value="5">5</asp:ListItem>
                                            <asp:ListItem Value="10">10</asp:ListItem>
                                            <asp:ListItem Value="15">15</asp:ListItem>
                                            <asp:ListItem Value="20">20</asp:ListItem>
                                            <asp:ListItem Value="25">25</asp:ListItem>
                                            <asp:ListItem Value="30">30</asp:ListItem>
                                            <asp:ListItem Value="35">35</asp:ListItem>
                                            <asp:ListItem Value="40">40</asp:ListItem>
                                            <asp:ListItem Value="45">45</asp:ListItem>
                                            <asp:ListItem Value="50">50</asp:ListItem>
                                            <asp:ListItem Value="55">55</asp:ListItem>
                                            <asp:ListItem Value="60">60</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-3">
                                <div class="form-group">
                                    <asp:Label Text="การเตรียมดินปลูก #2" runat="server"></asp:Label>
                                    <div class="dropdown">
                                        <asp:DropDownList runat="server" placeholder="การเตรียมดินปลูก #2" AutoPostBack="true" ID="cmbCanePrepareSoilStatus2" CssClass="form-control">
                                            <asp:ListItem Value="">-- เลือก --</asp:ListItem>
                                            <asp:ListItem Value="การพรวนดิน">การพรวนดิน</asp:ListItem>
                                            <asp:ListItem Value="พรวนล้มร่อง">พรวนล้มร่อง</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-3">
                                <div class="form-group">
                                    <asp:Label Text="ชื่อ #2" runat="server"></asp:Label>
                                    <div class="dropdown">
                                        <asp:DropDownList runat="server" placeholder="ชื่อ #2" AutoPostBack="true" ID="cmbCanePrepareSoilName2" CssClass="form-control">
                                            <asp:ListItem Value="">-- เลือก --</asp:ListItem>
                                            <asp:ListItem Value="ผาน3">ผาน3</asp:ListItem>
                                            <asp:ListItem Value="ผาน7">ผาน7</asp:ListItem>
                                            <asp:ListItem Value="พราน24">พราน24</asp:ListItem>
                                            <asp:ListItem Value="พรวน12">พรวน12</asp:ListItem>
                                            <asp:ListItem Value="ริปเปอร์">ริปเปอร์</asp:ListItem>
                                            <asp:ListItem Value="เพาเวอร์ฮาโร่">เพาเวอร์ฮาโร่</asp:ListItem>
                                            <asp:ListItem Value="มินิคอมบาย">มินิคอมบาย</asp:ListItem>
                                            <asp:ListItem Value="อื่นๆ">อื่นๆ</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-3">
                                <div class="form-group">
                                    <asp:Label Text="จำนวนครั้ง #2" runat="server"></asp:Label>
                                    <div class="dropdown">
                                        <asp:DropDownList runat="server" placeholder="จำนวนครั้ง #2" AutoPostBack="true" ID="cmbCanePrepareSoilCount2" CssClass="form-control">
                                            <asp:ListItem Value="">-- เลือก --</asp:ListItem>
                                            <asp:ListItem Value="1 ครั้ง">1 ครั้ง</asp:ListItem>
                                            <asp:ListItem Value="2 ครั้ง">2 ครั้ง</asp:ListItem>
                                            <asp:ListItem Value="3 ครั้ง">3 ครั้ง</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-3">
                                <div class="form-group">
                                    <asp:Label Text="ลึก/ซม. #2" runat="server"></asp:Label>
                                    <div class="dropdown">
                                        <asp:DropDownList runat="server" placeholder="ลึก/ซม. #2" AutoPostBack="true" ID="cmbCanePrepareSoilDeep2" CssClass="form-control">
                                            <asp:ListItem Value="">-- เลือก --</asp:ListItem>
                                            <asp:ListItem Value="5">5</asp:ListItem>
                                            <asp:ListItem Value="10">10</asp:ListItem>
                                            <asp:ListItem Value="15">15</asp:ListItem>
                                            <asp:ListItem Value="20">20</asp:ListItem>
                                            <asp:ListItem Value="25">25</asp:ListItem>
                                            <asp:ListItem Value="30">30</asp:ListItem>
                                            <asp:ListItem Value="35">35</asp:ListItem>
                                            <asp:ListItem Value="40">40</asp:ListItem>
                                            <asp:ListItem Value="45">45</asp:ListItem>
                                            <asp:ListItem Value="50">50</asp:ListItem>
                                            <asp:ListItem Value="55">55</asp:ListItem>
                                            <asp:ListItem Value="60">60</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-3">
                                <div class="form-group">
                                    <asp:Label Text="การเตรียมดินปลูก #3" runat="server"></asp:Label>
                                    <div class="dropdown">
                                        <asp:DropDownList runat="server" placeholder="การเตรียมดินปลูก #3" AutoPostBack="true" ID="cmbCanePrepareSoilStatus3" CssClass="form-control">
                                            <asp:ListItem Value="">-- เลือก --</asp:ListItem>
                                            <asp:ListItem Value="การพรวนดิน">การพรวนดิน</asp:ListItem>
                                            <asp:ListItem Value="พรวนล้มร่อง">พรวนล้มร่อง</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-3">
                                <div class="form-group">
                                    <asp:Label Text="ชื่อ #3" runat="server"></asp:Label>
                                    <div class="dropdown">
                                        <asp:DropDownList runat="server" placeholder="ชื่อ #3" AutoPostBack="true" ID="cmbCanePrepareSoilName3" CssClass="form-control">
                                            <asp:ListItem Value="">-- เลือก --</asp:ListItem>
                                            <asp:ListItem Value="ผาน3">ผาน3</asp:ListItem>
                                            <asp:ListItem Value="ผาน7">ผาน7</asp:ListItem>
                                            <asp:ListItem Value="พราน24">พราน24</asp:ListItem>
                                            <asp:ListItem Value="พรวน12">พรวน12</asp:ListItem>
                                            <asp:ListItem Value="ริปเปอร์">ริปเปอร์</asp:ListItem>
                                            <asp:ListItem Value="เพาเวอร์ฮาโร่">เพาเวอร์ฮาโร่</asp:ListItem>
                                            <asp:ListItem Value="มินิคอมบาย">มินิคอมบาย</asp:ListItem>
                                            <asp:ListItem Value="อื่นๆ">อื่นๆ</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-3">
                                <div class="form-group">
                                    <asp:Label Text="จำนวนครั้ง #3" runat="server"></asp:Label>
                                    <div class="dropdown">
                                        <asp:DropDownList runat="server" placeholder="จำนวนครั้ง #3" AutoPostBack="true" ID="cmbCanePrepareSoilCount3" CssClass="form-control">
                                            <asp:ListItem Value="">-- เลือก --</asp:ListItem>
                                            <asp:ListItem Value="1 ครั้ง">1 ครั้ง</asp:ListItem>
                                            <asp:ListItem Value="2 ครั้ง">2 ครั้ง</asp:ListItem>
                                            <asp:ListItem Value="3 ครั้ง">3 ครั้ง</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-3">
                                <div class="form-group">
                                    <asp:Label Text="ลึก/ซม. #3" runat="server"></asp:Label>
                                    <div class="dropdown">
                                        <asp:DropDownList runat="server" placeholder="ลึก/ซม. #3" AutoPostBack="true" ID="cmbCanePrepareSoilDeep3" CssClass="form-control">
                                            <asp:ListItem Value="">-- เลือก --</asp:ListItem>
                                            <asp:ListItem Value="5">5</asp:ListItem>
                                            <asp:ListItem Value="10">10</asp:ListItem>
                                            <asp:ListItem Value="15">15</asp:ListItem>
                                            <asp:ListItem Value="20">20</asp:ListItem>
                                            <asp:ListItem Value="25">25</asp:ListItem>
                                            <asp:ListItem Value="30">30</asp:ListItem>
                                            <asp:ListItem Value="35">35</asp:ListItem>
                                            <asp:ListItem Value="40">40</asp:ListItem>
                                            <asp:ListItem Value="45">45</asp:ListItem>
                                            <asp:ListItem Value="50">50</asp:ListItem>
                                            <asp:ListItem Value="55">55</asp:ListItem>
                                            <asp:ListItem Value="60">60</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-3">
                                <div class="form-group">
                                    <asp:Label Text="การเตรียมดินปลูก #4" runat="server"></asp:Label>
                                    <div class="dropdown">
                                        <asp:DropDownList runat="server" placeholder="การเตรียมดินปลูก #4" AutoPostBack="true" ID="cmbCanePrepareSoilStatus4" CssClass="form-control">
                                            <asp:ListItem Value="">-- เลือก --</asp:ListItem>
                                            <asp:ListItem Value="การพรวนดิน">การพรวนดิน</asp:ListItem>
                                            <asp:ListItem Value="พรวนล้มร่อง">พรวนล้มร่อง</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-3">
                                <div class="form-group">
                                    <asp:Label Text="ชื่อ #4" runat="server"></asp:Label>
                                    <div class="dropdown">
                                        <asp:DropDownList runat="server" placeholder="ชื่อ #4" AutoPostBack="true" ID="cmbCanePrepareSoilName4" CssClass="form-control">
                                            <asp:ListItem Value="">-- เลือก --</asp:ListItem>
                                            <asp:ListItem Value="ผาน3">ผาน3</asp:ListItem>
                                            <asp:ListItem Value="ผาน7">ผาน7</asp:ListItem>
                                            <asp:ListItem Value="พราน24">พราน24</asp:ListItem>
                                            <asp:ListItem Value="พรวน12">พรวน12</asp:ListItem>
                                            <asp:ListItem Value="ริปเปอร์">ริปเปอร์</asp:ListItem>
                                            <asp:ListItem Value="เพาเวอร์ฮาโร่">เพาเวอร์ฮาโร่</asp:ListItem>
                                            <asp:ListItem Value="มินิคอมบาย">มินิคอมบาย</asp:ListItem>
                                            <asp:ListItem Value="อื่นๆ">อื่นๆ</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-3">
                                <div class="form-group">
                                    <asp:Label Text="จำนวนครั้ง #4" runat="server"></asp:Label>
                                    <div class="dropdown">
                                        <asp:DropDownList runat="server" placeholder="จำนวนครั้ง #4" AutoPostBack="true" ID="cmbCanePrepareSoilCount4" CssClass="form-control">
                                            <asp:ListItem Value="">-- เลือก --</asp:ListItem>
                                            <asp:ListItem Value="1 ครั้ง">1 ครั้ง</asp:ListItem>
                                            <asp:ListItem Value="2 ครั้ง">2 ครั้ง</asp:ListItem>
                                            <asp:ListItem Value="3 ครั้ง">3 ครั้ง</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-3">
                                <div class="form-group">
                                    <asp:Label Text="ลึก/ซม. #4" runat="server"></asp:Label>
                                    <div class="dropdown">
                                        <asp:DropDownList runat="server" placeholder="ลึก/ซม. #4" AutoPostBack="true" ID="cmbCanePrepareSoilDeep4" CssClass="form-control">
                                            <asp:ListItem Value="">-- เลือก --</asp:ListItem>
                                            <asp:ListItem Value="5">5</asp:ListItem>
                                            <asp:ListItem Value="10">10</asp:ListItem>
                                            <asp:ListItem Value="15">15</asp:ListItem>
                                            <asp:ListItem Value="20">20</asp:ListItem>
                                            <asp:ListItem Value="25">25</asp:ListItem>
                                            <asp:ListItem Value="30">30</asp:ListItem>
                                            <asp:ListItem Value="35">35</asp:ListItem>
                                            <asp:ListItem Value="40">40</asp:ListItem>
                                            <asp:ListItem Value="45">45</asp:ListItem>
                                            <asp:ListItem Value="50">50</asp:ListItem>
                                            <asp:ListItem Value="55">55</asp:ListItem>
                                            <asp:ListItem Value="60">60</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <h3>ข้อมูลปุ๋ย</h3>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Label Text="วิธีการให้ปุ๋ย" runat="server"></asp:Label>
                                    <div class="dropdown">
                                        <asp:DropDownList runat="server" placeholder="วิธีการให้ปุ๋ย" AutoPostBack="true" ID="cmbFertilizerMethod" CssClass="form-control">
                                            <asp:ListItem Value="">-- เลือก --</asp:ListItem>
                                            <asp:ListItem Value="ใช้คน">ใช้คน</asp:ListItem>
                                            <asp:ListItem Value="ใช้เครื่อง">ใช้เครื่อง</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Label Text="สูตรปุ๋ย #1" runat="server"></asp:Label>
                                    <div class="dropdown">
                                        <asp:DropDownList runat="server" placeholder="สูตรปุ๋ย #1" AutoPostBack="true" ID="cmbFertilizerName1" CssClass="form-control">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Label Text="อัตราการใส่ปุ๋ย #1" runat="server"></asp:Label>
                                    <div class="dropdown">
                                        <asp:DropDownList runat="server" placeholder="อัตราการใส่ปุ๋ย #1" AutoPostBack="true" ID="cmbFertilizerUse1" CssClass="form-control">
                                            <asp:ListItem Value="">-- เลือก --</asp:ListItem>
                                            <asp:ListItem Value="20">20</asp:ListItem>
                                            <asp:ListItem Value="30">30</asp:ListItem>
                                            <asp:ListItem Value="40">40</asp:ListItem>
                                            <asp:ListItem Value="50">50</asp:ListItem>
                                            <asp:ListItem Value="60">60</asp:ListItem>
                                            <asp:ListItem Value="70">70</asp:ListItem>
                                            <asp:ListItem Value="80">80</asp:ListItem>
                                            <asp:ListItem Value="90">90</asp:ListItem>
                                            <asp:ListItem Value="100">100-</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Label Text="สูตรปุ๋ย #2" runat="server"></asp:Label>
                                    <div class="dropdown">
                                        <asp:DropDownList runat="server" placeholder="สูตรปุ๋ย #2" AutoPostBack="true" ID="cmbFertilizerName2" CssClass="form-control">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Label Text="อัตราการใส่ปุ๋ย #2" runat="server"></asp:Label>
                                    <div class="dropdown">
                                        <asp:DropDownList runat="server" placeholder="อัตราการใส่ปุ๋ย #2" AutoPostBack="true" ID="cmbFertilizerUse2" CssClass="form-control">
                                            <asp:ListItem Value="">-- เลือก --</asp:ListItem>
                                            <asp:ListItem Value="20">20</asp:ListItem>
                                            <asp:ListItem Value="30">30</asp:ListItem>
                                            <asp:ListItem Value="40">40</asp:ListItem>
                                            <asp:ListItem Value="50">50</asp:ListItem>
                                            <asp:ListItem Value="60">60</asp:ListItem>
                                            <asp:ListItem Value="70">70</asp:ListItem>
                                            <asp:ListItem Value="80">80</asp:ListItem>
                                            <asp:ListItem Value="90">90</asp:ListItem>
                                            <asp:ListItem Value="100">100-</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Label Text="สูตรปุ๋ย #3" runat="server"></asp:Label>
                                    <div class="dropdown">
                                        <asp:DropDownList runat="server" placeholder="สูตรปุ๋ย #3" AutoPostBack="true" ID="cmbFertilizerName3" CssClass="form-control">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Label Text="อัตราการใส่ปุ๋ย #3" runat="server"></asp:Label>
                                    <div class="dropdown">
                                        <asp:DropDownList runat="server" placeholder="อัตราการใส่ปุ๋ย #3" AutoPostBack="true" ID="cmbFertilizerUse3" CssClass="form-control">
                                            <asp:ListItem Value="">-- เลือก --</asp:ListItem>
                                            <asp:ListItem Value="20">20</asp:ListItem>
                                            <asp:ListItem Value="30">30</asp:ListItem>
                                            <asp:ListItem Value="40">40</asp:ListItem>
                                            <asp:ListItem Value="50">50</asp:ListItem>
                                            <asp:ListItem Value="60">60</asp:ListItem>
                                            <asp:ListItem Value="70">70</asp:ListItem>
                                            <asp:ListItem Value="80">80</asp:ListItem>
                                            <asp:ListItem Value="90">90</asp:ListItem>
                                            <asp:ListItem Value="100">100-</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Label Text="สูตรปุ๋ย #4" runat="server"></asp:Label>
                                    <div class="dropdown">
                                        <asp:DropDownList runat="server" placeholder="สูตรปุ๋ย #4" AutoPostBack="true" ID="cmbFertilizerName4" CssClass="form-control">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Label Text="อัตราการใส่ปุ๋ย #4" runat="server"></asp:Label>
                                    <div class="dropdown">
                                        <asp:DropDownList runat="server" placeholder="อัตราการใส่ปุ๋ย #4" AutoPostBack="true" ID="cmbFertilizerUse4" CssClass="form-control">
                                            <asp:ListItem Value="">-- เลือก --</asp:ListItem>
                                            <asp:ListItem Value="20">20</asp:ListItem>
                                            <asp:ListItem Value="30">30</asp:ListItem>
                                            <asp:ListItem Value="40">40</asp:ListItem>
                                            <asp:ListItem Value="50">50</asp:ListItem>
                                            <asp:ListItem Value="60">60</asp:ListItem>
                                            <asp:ListItem Value="70">70</asp:ListItem>
                                            <asp:ListItem Value="80">80</asp:ListItem>
                                            <asp:ListItem Value="90">90</asp:ListItem>
                                            <asp:ListItem Value="100">100-</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <h3>ข้อมูลการให้น้ำ</h3>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Label Text="ประเภทการให้น้ำ" runat="server"></asp:Label>
                                    <div class="dropdown">
                                        <asp:DropDownList runat="server" placeholder="ประเภทการให้น้ำ" AutoPostBack="true" ID="cmbCaneWaterName" CssClass="form-control">
                                            <asp:ListItem Value="">-- เลือก --</asp:ListItem>
                                            <asp:ListItem Value="น้ำหยด">น้ำหยด</asp:ListItem>
                                            <asp:ListItem Value="น้ำลาด">น้ำลาด</asp:ListItem>
                                            <asp:ListItem Value="ถังบรรทุกน้ำ">ถังบรรทุกน้ำ</asp:ListItem>
                                            <asp:ListItem Value="น้ำฝน">น้ำฝน</asp:ListItem>
                                            <asp:ListItem Value="อื่นๆ">อื่นๆ</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Label Text="วันที่ให้น้ำ" runat="server"></asp:Label>
                                    <asp:TextBox runat="server" ID="txtWaterDate" placeholder="วันที่ให้น้ำ" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Label Text="การใช้วีแนส/อามิ" runat="server"></asp:Label>
                                    <div class="dropdown">
                                        <asp:DropDownList runat="server" placeholder="การใช้วีแนส/อามิ" AutoPostBack="true" ID="cmbVnasAmi" CssClass="form-control">
                                            <asp:ListItem Value="">-- เลือก --</asp:ListItem>
                                            <asp:ListItem Value="ไม่มี">ไม่มี</asp:ListItem>
                                            <asp:ListItem Value="วีแนส">วีแนส</asp:ListItem>
                                            <asp:ListItem Value="อามิ">อามิ</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Label Text="อัตราการใช้" runat="server"></asp:Label>
                                    <div class="dropdown">
                                        <asp:DropDownList runat="server" placeholder="อัตราการใช้" AutoPostBack="true" ID="cmbVnasUse" CssClass="form-control">
                                            <asp:ListItem Value="">-- เลือก --</asp:ListItem>
                                            <asp:ListItem Value="1000">1000</asp:ListItem>
                                            <asp:ListItem Value="2000">2000</asp:ListItem>
                                            <asp:ListItem Value="3000">3000</asp:ListItem>
                                            <asp:ListItem Value="4000">4000</asp:ListItem>
                                            <asp:ListItem Value="5000">5000</asp:ListItem>
                                            <asp:ListItem Value="6000">6000</asp:ListItem>
                                            <asp:ListItem Value="7000">7000</asp:ListItem>
                                            <asp:ListItem Value="8000">8000</asp:ListItem>
                                            <asp:ListItem Value="9000">9000</asp:ListItem>
                                            <asp:ListItem Value="10000">10000</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Label Text="การปรับปรุงดิน" runat="server"></asp:Label>
                                    <div class="dropdown">
                                        <asp:DropDownList runat="server" placeholder="การปรับปรุงดิน" AutoPostBack="true" ID="cmbRepairSoil" CssClass="form-control">
                                            <asp:ListItem Value="">-- เลือก --</asp:ListItem>
                                            <asp:ListItem Value="ไม่มี">ไม่มี</asp:ListItem>
                                            <asp:ListItem Value="ปุ๋ยพืชสด">ปุ๋ยพืชสด</asp:ListItem>
                                            <asp:ListItem Value="ปุ๋ยหมัก">ปุ๋ยหมัก</asp:ListItem>
                                            <asp:ListItem Value="ปุ๋ยอินทรีย์">ปุ๋ยอินทรีย์</asp:ListItem>
                                            <asp:ListItem Value="ปุ๋ยมูลสัตว์">ปุ๋ยมูลสัตว์</asp:ListItem>
                                            <asp:ListItem Value="โดโลไมท์">โดโลไมท์</asp:ListItem>
                                            <asp:ListItem Value="อื่นๆ">อื่นๆ</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Label Text="การพรวนดิน" runat="server"></asp:Label>
                                    <div class="dropdown">
                                        <asp:DropDownList runat="server" placeholder="การพรวนดิน" AutoPostBack="true" ID="cmbShovelSoil" CssClass="form-control">
                                            <asp:ListItem Value="">-- เลือก --</asp:ListItem>
                                            <asp:ListItem Value="พรวน">พรวน</asp:ListItem>
                                            <asp:ListItem Value="ไม่พรวน">ไม่พรวน</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Label Text="การคุมวัชพืช" runat="server"></asp:Label>
                                    <div class="dropdown">
                                        <asp:DropDownList runat="server" placeholder="การคุมวัชพืช" AutoPostBack="true" ID="cmbControlWeeds" CssClass="form-control">
                                            <asp:ListItem Value="">-- เลือก --</asp:ListItem>
                                            <asp:ListItem Value="ใช้สารเคมี">ใช้สารเคมี</asp:ListItem>
                                            <asp:ListItem Value="ไม่ใช้สารเคมี">ไม่ใช้สารเคมี</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Label Text="การกำจัดวัชพืช" runat="server"></asp:Label>
                                    <div class="dropdown">
                                        <asp:DropDownList runat="server" placeholder="การกำจัดวัชพืช" AutoPostBack="true" ID="cmbDestroyWeeds" CssClass="form-control">
                                            <asp:ListItem Value="">-- เลือก --</asp:ListItem>
                                            <asp:ListItem Value="คน">คน</asp:ListItem>
                                            <asp:ListItem Value="สารเคมี">สารเคมี</asp:ListItem>
                                            <asp:ListItem Value="เครื่องจักร">เครื่องจักร</asp:ListItem>
                                            <asp:ListItem Value="ไม่มีการกำจัด">ไม่มีการกำจัด</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <h3>ข้อมูลการใช้สารเคมี</h3>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <asp:Label Text="ชนิดสารเคมี #1" runat="server"></asp:Label>
                                    <div class="dropdown">
                                        <asp:DropDownList runat="server" placeholder="ชนิดสารเคมี #1" AutoPostBack="true" ID="cmbCaneChemicalName1" CssClass="form-control">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="form-group">
                                    <asp:Label Text="อัตราการใช้สารเคมี #1" runat="server"></asp:Label>
                                    <div class="dropdown">
                                        <asp:DropDownList runat="server" placeholder="อัตราการใช้สารเคมี #1" AutoPostBack="true" ID="cmbCaneChemicalUse1" CssClass="form-control">
                                            <asp:ListItem Value="">-- เลือก --</asp:ListItem>
                                            <asp:ListItem Value="20">20</asp:ListItem>
                                            <asp:ListItem Value="30">30</asp:ListItem>
                                            <asp:ListItem Value="40">40</asp:ListItem>
                                            <asp:ListItem Value="50">50</asp:ListItem>
                                            <asp:ListItem Value="60">60</asp:ListItem>
                                            <asp:ListItem Value="70">70</asp:ListItem>
                                            <asp:ListItem Value="80">80</asp:ListItem>
                                            <asp:ListItem Value="90">90</asp:ListItem>
                                            <asp:ListItem Value="100">100-</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="form-group">
                                    <asp:Label Text="วิธีการให้ #1" runat="server"></asp:Label>
                                    <div class="dropdown">
                                        <asp:DropDownList runat="server" placeholder="วิธีการให้ #1" AutoPostBack="true" ID="cmbCaneChemicalMethod1" CssClass="form-control">
                                            <asp:ListItem Value="">-- เลือก --</asp:ListItem>
                                            <asp:ListItem Value="คน">คน</asp:ListItem>
                                            <asp:ListItem Value="เครื่องจักร">เครื่องจักร</asp:ListItem>
                                            <asp:ListItem Value="คน + เครื่องจักร">คน + เครื่องจักร</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <asp:Label Text="ชนิดสารเคมี #2" runat="server"></asp:Label>
                                    <div class="dropdown">
                                        <asp:DropDownList runat="server" placeholder="ชนิดสารเคมี #2" AutoPostBack="true" ID="cmbCaneChemicalName2" CssClass="form-control">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="form-group">
                                    <asp:Label Text="อัตราการใช้สารเคมี #2" runat="server"></asp:Label>
                                    <div class="dropdown">
                                        <asp:DropDownList runat="server" placeholder="อัตราการใช้สารเคมี #2" AutoPostBack="true" ID="cmbCaneChemicalUse2" CssClass="form-control">
                                            <asp:ListItem Value="">-- เลือก --</asp:ListItem>
                                            <asp:ListItem Value="20">20</asp:ListItem>
                                            <asp:ListItem Value="30">30</asp:ListItem>
                                            <asp:ListItem Value="40">40</asp:ListItem>
                                            <asp:ListItem Value="50">50</asp:ListItem>
                                            <asp:ListItem Value="60">60</asp:ListItem>
                                            <asp:ListItem Value="70">70</asp:ListItem>
                                            <asp:ListItem Value="80">80</asp:ListItem>
                                            <asp:ListItem Value="90">90</asp:ListItem>
                                            <asp:ListItem Value="100">100-</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="form-group">
                                    <asp:Label Text="วิธีการให้ #2" runat="server"></asp:Label>
                                    <div class="dropdown">
                                        <asp:DropDownList runat="server" placeholder="วิธีการให้ #2" AutoPostBack="true" ID="cmbCaneChemicalMethod2" CssClass="form-control">
                                            <asp:ListItem Value="">-- เลือก --</asp:ListItem>
                                            <asp:ListItem Value="คน">คน</asp:ListItem>
                                            <asp:ListItem Value="เครื่องจักร">เครื่องจักร</asp:ListItem>
                                            <asp:ListItem Value="คน + เครื่องจักร">คน + เครื่องจักร</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <asp:Label Text="ชนิดสารเคมี #3" runat="server"></asp:Label>
                                    <div class="dropdown">
                                        <asp:DropDownList runat="server" placeholder="ชนิดสารเคมี #3" AutoPostBack="true" ID="cmbCaneChemicalName3" CssClass="form-control">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="form-group">
                                    <asp:Label Text="อัตราการใช้สารเคมี #3" runat="server"></asp:Label>
                                    <div class="dropdown">
                                        <asp:DropDownList runat="server" placeholder="อัตราการใช้สารเคมี #3" AutoPostBack="true" ID="cmbCaneChemicalUse3" CssClass="form-control">
                                            <asp:ListItem Value="">-- เลือก --</asp:ListItem>
                                            <asp:ListItem Value="20">20</asp:ListItem>
                                            <asp:ListItem Value="30">30</asp:ListItem>
                                            <asp:ListItem Value="40">40</asp:ListItem>
                                            <asp:ListItem Value="50">50</asp:ListItem>
                                            <asp:ListItem Value="60">60</asp:ListItem>
                                            <asp:ListItem Value="70">70</asp:ListItem>
                                            <asp:ListItem Value="80">80</asp:ListItem>
                                            <asp:ListItem Value="90">90</asp:ListItem>
                                            <asp:ListItem Value="100">100-</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="form-group">
                                    <asp:Label Text="วิธีการให้ #3" runat="server"></asp:Label>
                                    <div class="dropdown">
                                        <asp:DropDownList runat="server" placeholder="วิธีการให้ #3" AutoPostBack="true" ID="cmbCaneChemicalMethod3" CssClass="form-control">
                                            <asp:ListItem Value="">-- เลือก --</asp:ListItem>
                                            <asp:ListItem Value="คน">คน</asp:ListItem>
                                            <asp:ListItem Value="เครื่องจักร">เครื่องจักร</asp:ListItem>
                                            <asp:ListItem Value="คน + เครื่องจักร">คน + เครื่องจักร</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <asp:Label Text="ชนิดสารเคมี #4" runat="server"></asp:Label>
                                    <div class="dropdown">
                                        <asp:DropDownList runat="server" placeholder="ชนิดสารเคมี #4" AutoPostBack="true" ID="cmbCaneChemicalName4" CssClass="form-control">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="form-group">
                                    <asp:Label Text="อัตราการใช้สารเคมี #4" runat="server"></asp:Label>
                                    <div class="dropdown">
                                        <asp:DropDownList runat="server" placeholder="อัตราการใช้สารเคมี #4" AutoPostBack="true" ID="cmbCaneChemicalUse4" CssClass="form-control">
                                            <asp:ListItem Value="">-- เลือก --</asp:ListItem>
                                            <asp:ListItem Value="20">20</asp:ListItem>
                                            <asp:ListItem Value="30">30</asp:ListItem>
                                            <asp:ListItem Value="40">40</asp:ListItem>
                                            <asp:ListItem Value="50">50</asp:ListItem>
                                            <asp:ListItem Value="60">60</asp:ListItem>
                                            <asp:ListItem Value="70">70</asp:ListItem>
                                            <asp:ListItem Value="80">80</asp:ListItem>
                                            <asp:ListItem Value="90">90</asp:ListItem>
                                            <asp:ListItem Value="100">100-</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="form-group">
                                    <asp:Label Text="วิธีการให้ #4" runat="server"></asp:Label>
                                    <div class="dropdown">
                                        <asp:DropDownList runat="server" placeholder="วิธีการให้ #4" AutoPostBack="true" ID="cmbCaneChemicalMethod4" CssClass="form-control">
                                            <asp:ListItem Value="">-- เลือก --</asp:ListItem>
                                            <asp:ListItem Value="คน">คน</asp:ListItem>
                                            <asp:ListItem Value="เครื่องจักร">เครื่องจักร</asp:ListItem>
                                            <asp:ListItem Value="คน + เครื่องจักร">คน + เครื่องจักร</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <h3>ข้อมูลรูปภาพ</h3>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Label Text="ชื่อรูปสามร่อง" runat="server"></asp:Label>
                                    <asp:TextBox runat="server" CssClass="form-control" placeholder="ชื่อรูปสามร่อง" ID="txtImageName1"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Label Text="ชื่อรูปภาพรวม" runat="server"></asp:Label>
                                    <asp:TextBox runat="server" CssClass="form-control" placeholder="ชื่อรูปภาพรวม" ID="txtImageName2"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Label Text="วันที่รูปที่ 1" runat="server"></asp:Label>
                                    <asp:TextBox runat="server" CssClass="form-control" placeholder="วันที่รูปที่ 1" ID="txtImageDate1"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Label Text="วันที่รูปที่ 2" runat="server"></asp:Label>
                                    <asp:TextBox runat="server" CssClass="form-control" placeholder="วันที่รูปที่ 2" ID="txtImageDate2"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Label Text="เวลารูปที่ 1" runat="server"></asp:Label>
                                    <asp:TextBox runat="server" CssClass="form-control" placeholder="เวลารูปที่ 1" ID="txtImageTime1"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Label Text="เวลารูปที่ 2" runat="server"></asp:Label>
                                    <asp:TextBox runat="server" CssClass="form-control" placeholder="เวลารูปที่ 2" ID="txtImageTime2"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Label Text="ตำแหน่งที่ 1" runat="server"></asp:Label>
                                        <asp:TextBox runat="server" CssClass="form-control" placeholder="ตำแหน่ง" ID="txtCaneLatLong1"></asp:TextBox>
                                    <div class="col-md-5">
                                        <asp:Button runat="server" Text="ดูแผนที่" ID="btnGoogleMap1" CssClass="btngps" OnClick="btnGoogleMap1_Click" OnClientClick="target ='_blank';"/>
                                    </div>
                                    <div class="col-md-5">
                                        <asp:FileUpload ID="FileUpload1" runat="server" />
                                    </div>

                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Label Text="ตำแหน่งที่ 2" runat="server"></asp:Label>
                                        <asp:TextBox runat="server" CssClass="form-control" placeholder="ตำแหน่ง" ID="txtCaneLatLong"></asp:TextBox>
                                    <div class="col-md-5">
                                        <asp:Button runat="server" Text="ดูแผนที่" ID="btnGoogleMap" CssClass="btngps" OnClick="btnGoogleMap_Click" OnClientClick="target ='_blank';" />
                                    </div>
                                    <div class="col-md-5">
                                        <asp:FileUpload ID="FileUpload2" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <br />

                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Image runat="server" ID="ImageShow" Height="330px" Width="530px" />
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Image runat="server" ID="ImageShow2" Height="330px" Width="530px" />
                                </div>
                            </div>
                        </div>

                        <div class="panel-btn">
                            <div class="row">
                                <div class="col-md-4 col-md-offset-2">
                                    <asp:Button runat="server" Text="บันทึก" ID="btnSubmit" CssClass="btnsubmit" OnClick="btnSubmit_Click" />
                                </div>
                                <div class="col-md-4 ">
                                    <asp:Button runat="server" Text="กลับไปหน้าแรก" ID="btnCancel" CssClass="btncancel" OnClick="btnCancel_Click" />
                                </div>
                            </div>
                        </div>

                    </div>

                </div>
            </section>
        </div>
    </section>
</asp:Content>
