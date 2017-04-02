<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MemoryLimit.Default1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="ErrorDiv" runat="server" style="color: red; text-decoration: solid">

    </div>
    <div>
        <asp:Label ID="lblIs64Bit" runat="server"></asp:Label>
    </div>
    <div>
        <asp:Label ID="lblMemoryFillAmount" runat="server"></asp:Label>
    </div>
    <div>
        <asp:Label ID="lblIISVersion" runat="server"></asp:Label>
    </div>
    <div>
        <asp:Label ID="lblItemsInCache" runat="server"></asp:Label>
    </div>
    <div>
        <asp:Label ID="lblAvailableForCacheMB" runat="server"></asp:Label>
    </div>
    <div>
        <asp:Label ID="lblPercentageOfPhysicalMemLimit" runat="server"></asp:Label>
    </div>
    <div>
        <asp:Label ID="lblMemoryCacheLimit" runat="server"></asp:Label>
    </div>
    <div>
        <asp:Label ID="lblMemoryCachePhysicalLimitPercentage" runat="server"></asp:Label>
    </div>

    <asp:Button ID="btnGetSystemInfo" runat="server" Text="Get System Info" OnClick="btnGetSystemInfo_Click" />

    <asp:Button ID="btnGetFileContent" runat="server" Text="Get file content" OnClick="btnGetFileContent_Click" />

    <asp:Button ID="btnClearCache" runat="server" Text="Clear Cache" OnClick="btnClearCache_Click" />
</asp:Content>
