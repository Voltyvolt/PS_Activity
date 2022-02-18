<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="frmIndex.aspx.cs" Inherits="PS_Activity.frmIndex" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">

    <link href="https://fonts.googleapis.com/css2?family=Prompt:wght@500&display=swap" rel="stylesheet" />
    <link href="Content/font-awesome.min.css" rel="stylesheet" />

    <script>
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("ยืนยันการทำรายการ?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>

    <style>
        .panel-body{
            font-family: 'Prompt', sans-serif;
        }

        .Search {
            font-family: 'Prompt', sans-serif;
            width: 216px;
            text-indent: 20px;
            -webkit-transition: width 0.4s ease-in-out;
            transition: width 0.4s ease-in-out;
        }

            .Search:focus {
                width: 100%;
            }


        .panel-header {
            font-family: 'Prompt', sans-serif;
        }

        table.mygridview {
            font-family: 'Prompt', sans-serif;
            text-align: center;
            border-collapse: collapse;
            width: 100%;
        }

            table.mygridview td, table.mygridview th {
                border: 1px solid #ddd;
                padding: 8px;
            }

            table.mygridview tr:nth-child(even) {
                background-color: #f2f2f2;
            }

            table.mygridview tr:hover {
                background-color: #ddd;
            }

            table.mygridview th {
                padding-top: 12px;
                padding-bottom: 12px;
                text-align: center;
                background-color: #4CAF50;
                text-shadow: 2px 2px black;
                color: white;
            }

        .btn {
            background-color: DodgerBlue; /* Blue background */
            border: none; /* Remove borders */
            color: white; /* White text */
            padding: 12px 16px; /* Some padding */
            font-size: 16px; /* Set a font size */
            cursor: pointer; /* Mouse pointer on hover */
        }

            /* Darker background on mouse-over */
            .btn:hover {
                background-color: RoyalBlue;
            }

        .input-icons i {
            position: absolute;
        }

        .input-icons {
            width: 100%;
            margin-top: 10px;
        }

        .icon {
            padding: 10px;
            min-width: 40px;
        }

        .input-field {
            width: 100%;
            padding: 10px;
            text-align: center;
        }

        .myButton {
            box-shadow: inset 0px -3px 7px 0px #29bbff;
            background: linear-gradient(to bottom, #2dabf9 5%, #0688fa 100%);
            background-color: #2dabf9;
            border-radius: 3px;
            border: 1px solid #0b0e07;
            display: inline-block;
            cursor: pointer;
            color: #ffffff;
            font-family: 'Prompt', sans-serif;
            font-size: 15px;
            padding: 9px 23px;
            text-decoration: none;
            text-shadow: 0px 1px 0px #263666;
        }

            .myButton:hover {
                background: linear-gradient(to bottom, #0688fa 5%, #2dabf9 100%);
                background-color: #0688fa;
            }

            .myButton:active {
                position: relative;
                top: 1px;
            }

        .btncancel {
            border: none;
            outline: none;
            height: 40px;
            font-size: 16px;
            color: black;
            background-color: red;
            font-family: 'Prompt', sans-serif;
            width: 100%;
            cursor: pointer;
            border-radius: 20px;
            transition: .3s ease-in-out;
        }

            .btncancel:hover {
                background-color: darkred;
            }
    </style>

    <section id="wrapper">
        <div class="col-lg-12">
            <section class="panel">
                <div class="panel-background">
                    <header class="panel-heading">
                        <div class="panel-header">
                            <div class="col-md-12 col-md-offset-4">
                                <h1>กิจกรรมการบำรุงรักษา</h1>
                            </div>
                        </div>
                    </header>

                    <br />
                    <br />
                    <br />

                    <div class="panel-body">
                        <div class="panel-user">

                            <div class="row">
                                <div class="col-md-8">
                                    <div class="input-icons">
                                         <asp:Label Text="โควต้า" runat="server"></asp:Label>
                                        <asp:TextBox ID="txtQuota" runat="server" CssClass="form-control Search" placeholder="ค้นหา.."></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-8">
                                    <div class="input-icons">
                                         <asp:Label Text="เลขที่แปลง" runat="server"></asp:Label>
                                        <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control Search" placeholder="ค้นหา.."></asp:TextBox>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-4">
                                             <asp:Label Text="เขต" runat="server"></asp:Label>
                                            <div class="form-group">
                                                <div class="dropdown">
                                                    <asp:DropDownList runat="server" placeholder="เขต" AutoPostBack="true" ID="cmbKeth" CssClass="form-control">
                                                        <asp:ListItem Value="">-- เลือก --</asp:ListItem>
                                                        <asp:ListItem Value="1">1</asp:ListItem>
                                                        <asp:ListItem Value="2">2</asp:ListItem>
                                                        <asp:ListItem Value="3">3</asp:ListItem>
                                                        <asp:ListItem Value="4">4</asp:ListItem>
                                                        <asp:ListItem Value="5">5</asp:ListItem>
                                                        <asp:ListItem Value="6">6</asp:ListItem>
                                                        <asp:ListItem Value="7">7</asp:ListItem>
                                                        <asp:ListItem Value="8">8</asp:ListItem>
                                                        <asp:ListItem Value="9">9</asp:ListItem>
                                                        <asp:ListItem Value="10">10</asp:ListItem>
                                                        <asp:ListItem Value="11">11</asp:ListItem>
                                                        <asp:ListItem Value="12">12</asp:ListItem>
                                                        <asp:ListItem Value="13">13</asp:ListItem>
                                                        <asp:ListItem Value="14">14</asp:ListItem>
                                                        <asp:ListItem Value="15">15</asp:ListItem>
                                                        <asp:ListItem Value="16">16</asp:ListItem>
                                                        <asp:ListItem Value="17">17</asp:ListItem>
                                                        <asp:ListItem Value="18">18</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <asp:Button ID="BtnSearch" runat="server" CssClass="myButton" Text="ค้นหา" OnClick="Search_Click" />
                                    </div>
                                </div>
                            </div>
                            <br />

                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <asp:GridView runat="server" ID="GridActivity" AutoGenerateColumns="false" AllowPaging="True" CssClass="mygridview" OnPageIndexChanging="GridActivity_PageIndexChanging">
                                            <Columns>
                                                <asp:BoundField ItemStyle-Width="5px" DataField="Id" HeaderText="Primary" Visible="false" />
                                                <asp:BoundField ItemStyle-Width="5px" DataField="IdShow" HeaderText="ลำดับที่" />
                                                <asp:BoundField ItemStyle-Width="30px" DataField="Quota" HeaderText="โควต้า" />
                                                <asp:BoundField ItemStyle-Width="30px" DataField="PlanId" HeaderText="เลขที่แปลง" />
                                                <asp:BoundField ItemStyle-Width="70px" DataField="PlanName" HeaderText="ชื่อแปลง" />
                                                <%--<asp:BoundField ItemStyle-Width="30px" DataField="CaneSeason" HeaderText="ประเภทอ้อย" />--%>
                                                <asp:BoundField ItemStyle-Width="30px" DataField="CaneDate" HeaderText="วันที่" />
                                                <asp:BoundField ItemStyle-Width="30px" DataField="CaneCount" HeaderText="ครั้งที่" />
                                                <asp:BoundField ItemStyle-Width="30px" DataField="SeasonYear" HeaderText="ปีการผลิต" />
                                                <asp:BoundField ItemStyle-Width="30px" DataField="CaneStatus" HeaderText="สถานะ" />
                                                <asp:TemplateField ItemStyle-Width="120px" HeaderText="จัดการ">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="BtnEdit" runat="server" CssClass="btn" CommandArgument='<%# Eval("Id") %>' OnClick="Edit_Click"><i class="fa fa-address-card fa-7x"></i></asp:LinkButton>
                                                        <asp:LinkButton ID="btnDelete" runat="server" CssClass="btn" CommandArgument='<%# Eval("Id") %>' OnClientClick="return Confirm();" OnClick="Delete_Click"><i class="fa fa-trash fa-7x"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>

                            <div class="panel-btn"> 
                                <div class="row">
                                    <div class="col-md-4 col-md-offset-4">
                                        <asp:Button runat="server" Text="กลับไปหน้าแรก" ID="btnCancel" CssClass="btncancel" OnClick="btnCancel_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
        </div>
    </section>
</asp:Content>
