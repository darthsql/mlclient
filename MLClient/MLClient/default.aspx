<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="MLClient.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <meta name="viewport" content="width=device-width" />
        <title>Calling ML</title>
        <style>
            .main {
                text-align:center; 
            }
            .GFG {
                color:#009900;
                font-size:50px;
                font-weight:bold;
            }
            .geeks {
                font-style:bold;
                font-size:20px;
            }
        </style>
        <style type="text/css">
            body {
                font-family: Arial;
                font-size: 10pt;
            }
        </style>
        <style type="text/css">
            table {
                border: 1px solid #777;
                border-collapse: collapse;
            } 

            table tr th,
            table tr td {
                border: 1px solid #777;
            }
        </style>
    </head>
    <body>
        <form id="form1" runat="server">
            <div class="text-center">
                <h3>Query recommendations by User Id</h3>
            </div>
            <table>
                <tr>
                    <td>User Id :</td>
                    <td><asp:TextBox id="txtUserId" runat="server" /></td><td>
                    </td>
                    <td>
                        <asp:LinkButton ID="predictLB" runat="server" OnClick="predictLB_Click1">Predict</asp:LinkButton></td>
                </tr>
            </table>
        <hr />
        <label name="labelML"></label>
            <asp:Label ID="Label1" runat="server" Text="Recommendations: "></asp:Label><br />
            <asp:Label ID="lblResults" runat="server"></asp:Label>
        </form>
    </body>
</html>