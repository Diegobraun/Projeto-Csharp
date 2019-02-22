using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;

namespace TheKingPDF
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed1_Click1(object sender, EventArgs e)
        {
            bool CheckIfTrue = false; 
            string[] valores = new string[10];
            string Name = nome.Text;
            string EnderecoEmail = email.Text;
            string Birthday = datanascimento.Text;
            string Celphone = celular.Text;
            string SexOficial = sexo.Text;
            string Cepp = cep.Text;
            string City = cidade.Text;
            string State = estado.Text;
            string Password = senha.Text;
            string ConfirmPassword = confirmarsenha.Text;

            string EncodeMethod(string ToEncodeString)
            {

                byte[] EncodeTerm = System.Text.Encoding.UTF8.GetBytes(ToEncodeString);
                string EncodeTermAfter = System.Convert.ToBase64String(EncodeTerm);

                return EncodeTermAfter;
            }

            bool CheckPassword(string Senha, string ConfirmarSenha)
            {
                if (Senha.Equals(ConfirmarSenha))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            bool CheckEmailFound(string email)
            {
                SqlConnection SqlConexion = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ProjetoFinal;Data Source=PC-DIEGO");
                SqlCommand commandd = new SqlCommand("SELECT * FROM tb_pessoa WHERE Email = '" + email + "'", SqlConexion);
                

                try
                {
                    SqlConexion.Open();
                    SqlDataReader readContent = commandd.ExecuteReader();

                    if (readContent.HasRows)
                        CheckIfTrue = false;
                    else
                        CheckIfTrue = true;
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
                finally
                {
                    SqlConexion.Close();
                }

                return CheckIfTrue;

            }



            bool CheckFields(string[] values)
            {
                int f = 0, g = 0;
                values[0] = Name;
                values[1] = EnderecoEmail;
                values[2] = Birthday;
                values[3] = Celphone;
                values[4] = SexOficial;
                values[5] = Cepp;
                values[6] = City;
                values[7] = State;
                values[8] = Password;
                values[9] = ConfirmPassword;
                for (int i = 0; i < values.Length; i++)
                {
                    if (values[i].Trim() != null && values[i].Trim() != "")
                    {
                        f++;
                    }
                    else
                    {
                        g++;
                    }
                }
                if (g > 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }

            string SubsData(string data)
            {
                string ano, mes, dia, finalDate, barra = "-";
                ano = data.Substring(0, 4);
                mes = data.Substring(5, 2);
                dia = data.Substring(8, 2);
                finalDate = dia + barra + mes + barra + ano;

                return finalDate;
            }
            void InsertData()
            {
                SqlConnection SqlCon = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ProjetoFinal;Data Source=PC-DIEGO");
                SqlCommand command = new SqlCommand("INSERT INTO tb_pessoa(Nome_Completo,Email,DataNascimento,Celular,Sexo,CEP,Cidade,Estado,Senha) VALUES (@Nome_Completo,@Email,@DataNascimento,@Celular,@Sexo,@CEP,@Cidade,@Estado,@Senha);", SqlCon);
                command.Parameters.Add("@Nome_Completo", SqlDbType.NVarChar).Value = Name;
                command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = EnderecoEmail;
                command.Parameters.Add("@DataNascimento", SqlDbType.NVarChar).Value = SubsData(Birthday);
                command.Parameters.Add("@Celular", SqlDbType.NVarChar).Value = Celphone;
                command.Parameters.Add("@Sexo", SqlDbType.NVarChar).Value = SexOficial;
                command.Parameters.Add("@CEP", SqlDbType.NVarChar).Value = Cepp;
                command.Parameters.Add("@Cidade", SqlDbType.NVarChar).Value = City;
                command.Parameters.Add("@Estado", SqlDbType.NVarChar).Value = State;
                command.Parameters.Add("@Senha", SqlDbType.NVarChar).Value = EncodeMethod(Password);

                try
                {
                    SqlCon.Open();
                    command.ExecuteNonQuery();
                    /*string path = @"C:\Users\diego\source\repos\TheKingPDF\TheKingPDF\Example.txt";
                    TextWriter tw = new StreamWriter(path);
                    tw.WriteLine(Name);
                    tw.WriteLine(EnderecoEmail);
                    tw.WriteLine(Birthday);
                    tw.WriteLine(Celphone);
                    tw.WriteLine(SexOficial);
                    tw.WriteLine(Cepp);
                    tw.WriteLine(City);
                    tw.WriteLine(State);
                    tw.WriteLine(Password);
                    tw.WriteLine(ConfirmPassword);
                    tw.Close();*/
                    Response.Redirect("Home.aspx");
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

            if ((CheckFields(valores)) && (CheckPassword(Password, ConfirmPassword)) && (CheckEmailFound(EnderecoEmail)))
            {
                InsertData();
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('NÃO FOI POSSÍVEL REALIZAR O CADASTRO');", true);
            }
        }
    }
}