<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="winedrops_coding_challenge.frontend.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Winedrops coding challenge</title>
    <link href="../plugins/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../plugins/css/main.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
                <div class="container" style="padding: 20px; background-color: #f8f8f8">
                    <div class="row">
                        <div class="col-md-12">
                            <h1>Best selling wine</h1>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <br />
                            <div class="btn-group">
                                <asp:Button ID="btnRevenue" runat="server" Text="By revenue" CssClass="btn" Width="120px" BackColor="#ebebeb" OnClick="btnRevenue_Click" />
                                <asp:Button ID="btnBottles" runat="server" Text="By # bottles" CssClass="btn" Width="120px" BackColor="White" OnClick="btnBottles_Click" />
                                <asp:Button ID="btnOrders" runat="server" Text="By # orders" CssClass="btn" Width="120px" BackColor="White" OnClick="btnOrders_Click" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-3">
                            <br />
                           
                            <div class="input-group mb-3">
                                <span class="search-icon">&#x1F50D</span>
                                <asp:TextBox ID="txtSearch" CssClass="form-control form-control-sm search-input" placeholder="search..." runat="server" OnTextChanged="txtSearch_TextChanged"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div id="listViewer" runat="server" class="row">
                            </div>
                        </div>
                    </div>
                </div>
    </form>
</body>
<script src="../plugins/js/jquery-1.11.1.min.js"></script>
<script src="../plugins/js/bootstrap.min.js"></script>
</html>
