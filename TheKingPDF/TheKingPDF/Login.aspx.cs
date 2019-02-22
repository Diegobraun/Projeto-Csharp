using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace TheKingPDF
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            string EmailInput = InputEmail.Text;
            string PasswordInput = InputPassword.Text;
            string EncodeMethod(string ToEncodeString)
            {

                byte[] EncodeTerm = System.Text.Encoding.UTF8.GetBytes(ToEncodeString);
                string EncodeTermAfter = System.Convert.ToBase64String(EncodeTerm);

                return EncodeTermAfter;
            }

            SqlConnection SqlCon = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ProjetoFinal;Data Source=PC-DIEGO");
            SqlCommand command = new SqlCommand("SELECT * FROM tb_pessoa WHERE Email = '" + EmailInput + "' and Senha = '" + EncodeMethod(PasswordInput) + "'", SqlCon);
            try
            {
                SqlCon.Open();
                command.ExecuteNonQuery();
                SqlDataReader ReaderCommand = command.ExecuteReader();
                if (ReaderCommand.Read())
                {
                    Session["UsernameComplete"] = EmailInput;
                    Session["UsernameSimplify"] = ReaderCommand["Nome_Completo"];
                    Response.Redirect("PainelUser.aspx");
                }
                else
                {
                    //Response.Write("LOGIN NÃO ENCONTRADO");
                    //Page.RegisterStartupScript(",", "<script>alert('LOGIN NÃO ENCONTRADO')</script>");
                    Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('LOGIN NÃO ENCONTRADO');", true);
                }

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                SqlCon.Close();
            }
        }
    }
}