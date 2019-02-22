using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace TheKingPDF
{
    public partial class DeletePdf : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["id"])){
                Response.Redirect("PainelUser.aspx");
            }
            else
            {
                string valueInicial = Request.QueryString["id"];
                string DecodeMethod(string ToDecodeString)
                {

                    byte[] DecodeTerm = System.Convert.FromBase64String(ToDecodeString);
                    string DecodeTermAfter = System.Text.Encoding.UTF8.GetString(DecodeTerm);

                    return DecodeTermAfter;
                }

                string value = DecodeMethod(Request.QueryString["id"]);
            //////////
                SqlConnection con = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ProjetoFinal;Data Source=PC-DIEGO");
                SqlCommand command = new SqlCommand("DELETE FROM tb_arquivos WHERE ArquivoID = '" + value + "'", con);

                try
                {
                    con.Open();
                    command.ExecuteNonQuery();
                    Response.Redirect("PainelUser.aspx");
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }
    }
}