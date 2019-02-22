using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace TheKingPDF
{
    public partial class PainelUser : System.Web.UI.Page
    {
        public String EncodeMethod(String ToEncodeString)
        {

            Byte[] EncodeTerm = System.Text.Encoding.UTF8.GetBytes(ToEncodeString);
            String EncodeTermAfter = System.Convert.ToBase64String(EncodeTerm);

            return EncodeTermAfter;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string ShowSession = (string)Session["UsernameComplete"];
            string ShowMinimizedSession = (string)Session["UsernameSimplify"];
            if(ShowSession != null && ShowSession != "")
            {
                string[] ShowMinimizedSessionSplit = ShowMinimizedSession.Split(' ');
                SessionNameClass.Text = "Olá, " + ShowMinimizedSessionSplit[0];
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
            //AQUI COMEÇA O WHILE VINDO DO BANCO

            SqlConnection SqlCon = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ProjetoFinal;Data Source=PC-DIEGO");
            SqlCommand command = new SqlCommand("SELECT * FROM tb_arquivos WHERE Email = '"+ ShowSession+"'",SqlCon);
            try
            {
                SqlCon.Open();
                SqlDataReader Data = command.ExecuteReader();

                string div = "";
                while (Data.Read())
                {
                    div += "<input type='hidden' name='code' id='code' value='"+ Data[0] +"'>";
                    div += "<div class='col-md-4'><div class='card mb-4 shadow-sm'>";
                    div += "<img class='card - img - top' alt='" + Data[1] + "' style='height: 225px; width: 100 %; display: block;' src='" + Data[5] + "' data-holder-rendered='true'>";
                    div += "<div class='card-body'>";
                    div += "<p class='card-text'>" + Data[1] + "</p><div class='d-flex justify-content-between align-items-center'><div class='btn-group'>";
                    div += "<a href='UpdatePdf.aspx?id="+ EncodeMethod(Data[0].ToString()) + "' class='btn btn-sm btn-outline-secondary'>Editar</a>";
                    div += "<a href='DeletePdf.aspx?id=" + EncodeMethod(Data[0].ToString()) + "' class='btn btn-sm btn-outline-secondary btn-delete'>Deletar</a>";
                    div += "</div></div/></div></div></div>";
                }
                server.InnerHtml = div;

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                SqlCon.Close();
            }

            //SELECT DO COUNT
            SqlConnection SqlConexion = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ProjetoFinal;Data Source=PC-DIEGO");
            SqlCommand comando = new SqlCommand("select count(*) from tb_arquivos WHERE Email = '"+ ShowSession + "'", SqlConexion);
            try
            {
                SqlConexion.Open();
                SqlDataReader read = comando.ExecuteReader();
                string Count = "";

                while (read.Read())
                {
                    Count = "Quantidade de PDF's cadastrados: "+read[0].ToString();
                    CountPdfCadastrado.InnerHtml = Count;

                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                SqlConexion.Close();
            }
        }

        protected void BtnSair_Click(object sender, EventArgs e)
        {
            Session.Remove("UsernameComplete");
            Session.Remove("UsernameSimplify");
            Response.Redirect("Home.aspx");
        }

        protected void BtnRegisterPdf_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegisterPdf.aspx");
        }
    }
}