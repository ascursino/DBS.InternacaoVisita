<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExibeVisita.aspx.cs" Inherits="DBS.InternacaoVisita.Layouts.DBS.InternacaoVisita.ExibeVisita" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">

       <asp:Label runat="server" ID = "lblErro" ForeColor="Red"></asp:Label>

        <p class="titulo_resumo">:: Acompanhamento de Visitas</p>
        <br />

		<table border="0" cellspacing="0" width="100%">
			<tr>
				<td colspan="2" style="height: 26px">
					<span class="ms-formdescription"><b>Prontuário: </b><asp:Label runat="server" ID="lblProntuario" /></span><br /><br />
                    <span class="ms-formdescription"><b>Paciente: </b><asp:Label runat="server" ID="lblPaciente" /></span>
				</td>
			</tr>
			<tr>
				<td colspan="2">&nbsp;</td>
			</tr>
			<tr>
				<td width="100px" valign="top" class="ms-formlabel">
					<b>Médico da Visita</b>
				</td>
				<td width="100px" valign="top" class="ms-formlabel">
					<b>Especialidade</b>
				</td>
                <td width="100px" valign="top" class="ms-formlabel">
					<b>Tipo de Visita</b>
				</td>
                <td width="100px" valign="top" class="ms-formlabel">
					<b>Entrada</b>
				</td>
                <td width="100px" valign="top" class="ms-formlabel">
					<b>Saída</b>
				</td>
                <td width="100px" valign="top" class="ms-formlabel">
					<b>Observação</b>
				</td>
			</tr>
			
            <asp:Literal ID="ltrListaVisita" runat="server" />

			</table>


</asp:Content>
