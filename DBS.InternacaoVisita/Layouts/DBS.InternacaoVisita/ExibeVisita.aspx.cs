using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebControls;

namespace DBS.InternacaoVisita.Layouts.DBS.InternacaoVisita
{
    public partial class ExibeVisita : LayoutsPageBase
    {
        SPWeb web = SPContext.Current.Site.RootWeb;

        int intIDInternacao = 1;
        string strProntuario = "";
        string strPaciente = "";

        string strEspecialidade = ""; 
        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                RecuperaDadosInternacao(intIDInternacao);

                MontaListaVisita(intIDInternacao);
            }
            catch (Exception ex)
            {
                lblErro.Text = ex.ToString();
            }
        }

        public void RecuperaDadosInternacao(int varIDInternacao)
        {
            //Acessando a lista Visita
            SPList lstInternacao = web.Lists["Internações"];

            //Construindo a Query CAML
            SPQuery oQuery = new SPQuery();
            oQuery.Query = "<Where>" +
                                "<Eq>" +
                                    "<FieldRef Name='ID' /><Value Type='Number'>" + intIDInternacao + "</Value>" +
                                "</Eq>" +
                           "</Where>";

            //Criando uma coleção de itens, utilizando a Query CAML
            SPListItemCollection collListItems = lstInternacao.GetItems(oQuery);

            //Recupera o item
            foreach (SPListItem oListItem in collListItems)
            {
                //Guarda resultado nas variáveis
                strProntuario = SPEncode.HtmlEncode(oListItem["Prontu_x00e1_rio"].ToString());
                strPaciente = SPEncode.HtmlEncode(oListItem["Paciente"].ToString());
            }
        }


        public void MontaListaVisita(int varIDInternacao)
        {
            string varLinha = "";

            lblProntuario.Text = strProntuario.ToString();
            lblPaciente.Text = strPaciente.ToString();

            //Acessando a lista Visita
            SPList lstVisita = web.Lists["Visitas"];

            //Construindo a Query CAML
            SPQuery oQuery = new SPQuery();

            oQuery.Query = "<Where>" +
                                "<Eq>" +
                                    "<FieldRef Name='Registro_x0020_de_x0020_interna_' /><Value Type='Lookup'>" + intIDInternacao + "</Value>" +
                                "</Eq>" +
                            "</Where>";

            //Criando uma coleção de itens, utilizando a Query CAML
            SPListItemCollection collListItems = lstVisita.GetItems(oQuery);

            //Recupera o item
            foreach (SPListItem oListItem in collListItems)
            {
                //Busca Especialidade do médico da visita
                string strEspecMedico = RecuperaDadosMedico(SPEncode.HtmlEncode(oListItem["M_x00e9_dico_x0020_da_x0020_Visi"].ToString()));

                //Monta linha da grid com os resultados
                varLinha += "<tr><td valign='top' class='ms-formbody'>" + oListItem["M_x00e9_dico_x0020_da_x0020_Visi"] != null ? SPEncode.HtmlEncode(oListItem["M_x00e9_dico_x0020_da_x0020_Visi"].ToString()) : "" + "</td>" +
                            "<td valign='top' class='ms-formbody'>" + SPEncode.HtmlEncode(strEspecMedico.ToString()) + "</td>" +
                            "<td valign='top' class='ms-formbody'>" + oListItem["Tipo_x0020_de_x0020_Visita"] != null ? SPEncode.HtmlEncode(oListItem["Tipo_x0020_de_x0020_Visita"].ToString()) : "" + "</td>" +
                            "<td valign='top' class='ms-formbody'>" + oListItem["Hora_x0020_de_x0020_In_x00ed_cio"] != null ? SPEncode.HtmlEncode(oListItem["Hora_x0020_de_x0020_In_x00ed_cio"].ToString()) : "" + "</td>" +
                            "<td valign='top' class='ms-formbody'>" + oListItem["Hora_x0020_de_x0020_Fim_x0020_da"] != null ? SPEncode.HtmlEncode(oListItem["Hora_x0020_de_x0020_Fim_x0020_da"].ToString()) : "" + "</td>" +
                            "<td valign='top' class='ms-formbody'>" + oListItem["Observa_x00e7__x00e3_o"] != null ? SPEncode.HtmlEncode(oListItem["Observa_x00e7__x00e3_o"].ToString()) : "" + "</td></tr>";
            }

            ltrListaVisita.Text = varLinha.ToString();
        }


        public string RecuperaDadosMedico(string strMedico)
        {

            strMedico = strMedico.Substring(strMedico.IndexOf("#") + 1);

            string strEspecialidade = "";

            //Acessando a lista Visita
            SPList lstMedico = web.Lists["Medicos"];

            //Construindo a Query CAML
            SPQuery oQuery = new SPQuery();
            oQuery.Query = "<Where>" +
                                "<Eq>" +
                                    "<FieldRef Name='Title' /><Value Type='Text'>" + strMedico + "</Value>" +
                                "</Eq>" +
                           "</Where>";


            //Criando uma coleção de itens, utilizando a Query CAML
            SPListItemCollection collListItems = lstMedico.GetItems(oQuery);

            //Recupera o item
            foreach (SPListItem oListItem in collListItems)
            {
                strEspecialidade = oListItem["Especialidade"].ToString() != null ? SPEncode.HtmlEncode(oListItem["Especialidade"].ToString()) : "";
            }

            return strEspecialidade;
        }
    }
}
