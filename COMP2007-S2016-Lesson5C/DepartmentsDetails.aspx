<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DepartmentsDetails.aspx.cs" Inherits="COMP2007_S2016_Lesson5C.DepartmentsDetails" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <div class="container">
        <div class="row">
            <div class="col-md-offset-3 col-md-6">
                <h1>Department Details</h1>
                <h5>All Fields are Required</h5>
                <br />
                <div class="form-group">
                    <label class="control-label" for="DepartmentNameTextBox">Department Name</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="DepartmenrNameTextBox" placeholder="Department Name" required="true"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label class="control-label" for="DepartmentIDTextBox">Department ID</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="DepartmentIDTextBox" placeholder="Department ID" required="true"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label class="control-label" for="BudgetTextBox">Budget</label>
                    <asp:TextBox runat="server" TextMode="Date" CssClass="form-control" ID="BudgetTextBox" required="true"></asp:TextBox>
                    
                </div>
                <div class="text-right">
                    <asp:Button Text="Cancel" ID="CancelButton" CssClass="btn btn-warning btn-lg" runat="server" 
                        UseSubmitBehavior="false" CausesValidation="false" OnClick="CancelButton_Click" />
                    <asp:Button Text="Save" ID="SaveButton" CssClass="btn btn-primary btn-lg" runat="server" OnClick="SaveButton_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
