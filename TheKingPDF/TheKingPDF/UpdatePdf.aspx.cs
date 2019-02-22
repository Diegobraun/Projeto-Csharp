using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace TheKingPDF
{
    public partial class UpdatePdf : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

            
                string DecodeMethod(string ToDecodeString)
            {

                byte[] DecodeTerm = System.Convert.FromBase64String(ToDecodeString);
                string DecodeTermAfter = System.Text.Encoding.UTF8.GetString(DecodeTerm);

                return DecodeTermAfter;
            }
            

            string value = Request.QueryString["id"];
            
            
            if (string.IsNullOrEmpty(value))
                Response.Redirect("PainelUser.aspx");
            else
            {
                string ValueToSelect = DecodeMethod(value).ToString();
                SqlConnection conexion = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ProjetoFinal;Data Source=PC-DIEGO");
                SqlCommand comando = new SqlCommand("SELECT * FROM tb_arquivos WHERE ArquivoID = '"+ValueToSelect+"'", conexion);
                try
                {
                    conexion.Open();
                    SqlDataReader read = comando.ExecuteReader();
                    while (read.Read())
                    {
                        NomeArquivo.Text = read[1].ToString();
                        NomeAutor.Text = read[3].ToString();
                        CategoryPdf.Text = read[7].ToString();
                        DescricaoPdf.Value = read[2].ToString();
                    }       
                }
                catch(Exception ex)
                {
                    Response.Write(ex.Message);
                }
                finally
                {
                    conexion.Close();
                }
            }

            }
        }

        protected void BtnCadastrar_Click(object sender, EventArgs e)
        {
            string DecodeMethod(string ToDecodeString)
            {

                byte[] DecodeTerm = System.Convert.FromBase64String(ToDecodeString);
                string DecodeTermAfter = System.Text.Encoding.UTF8.GetString(DecodeTerm);

                return DecodeTermAfter;
            }
            string value = DecodeMethod(Request.QueryString["id"]);

            string NomePdf = NomeArquivo.Text;
            string AutorPdf = NomeAutor.Text;
            string CategoriaPdf = CategoryPdf.Text;
            string DescriptionPdf = DescricaoPdf.Value;
            string NameFilePdf = UploadPdf.PostedFile.FileName;
            string NameFileImage = UploadImage.PostedFile.FileName;
            DateTime date = DateTime.Now;

            StringBuilder sb = new StringBuilder();
            sb.Append((date.ToShortTimeString().Replace(":", "")) + (date.ToShortDateString().Replace("/", "")));

            string dateTimeToDate = date.ToShortDateString();//DateTime para por no date

            string dateFinalTime = sb.ToString();

            //File pdf
            string NameFinaleiraPdf = dateFinalTime + NameFilePdf; //NOME PDF FINAL
            string NameFinaleiraImage = dateFinalTime + NameFileImage;

            bool CheckIfNotNull()
            {
                bool check = true;
                if (NomePdf.Trim().Equals("") && NomePdf.Trim() == null)
                    check = false;
                else if (AutorPdf.Trim().Equals("") && AutorPdf.Trim() == null)
                    check = false;
                else if (CategoriaPdf.Trim().Equals("") && CategoriaPdf.Trim() == null)
                    check = false;
                else if (DescriptionPdf.Trim().Equals("") && DescriptionPdf.Trim() == null)
                    check = false;
                else if (NameFilePdf.Trim().Equals("") && NameFilePdf.Trim() == null)
                    check = false;
                else if (NameFileImage.Trim().Equals("") && NameFileImage.Trim() == null)
                    check = false;
                else
                    check = true;
                return check;
            }

            bool CheckPdf(string FilePdfName)
            {
                int TamanhoArquivo = FilePdfName.Length;

                string SubsNameFile = FilePdfName.Substring(TamanhoArquivo - 3);

                if (SubsNameFile.Equals("pdf"))
                {
                    return true;
                }
                else
                {
                    return false;
                }    
            }

            bool CheckImage(string FileImageName)
            {
                int TamanhoArquivo = FileImageName.Length;

                string SubsNameFile = FileImageName.Substring(TamanhoArquivo - 4);

                if (SubsNameFile.Equals(".png") || SubsNameFile.Equals("jpeg") || SubsNameFile.Equals(".jpg") || SubsNameFile.Equals(".avg"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
          
            if ((CheckImage(NameFinaleiraImage)) && (CheckPdf(NameFinaleiraPdf)) && CheckIfNotNull())
            {
                SqlConnection con = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ProjetoFinal;Data Source=PC-DIEGO");
                SqlCommand command = new SqlCommand("UPDATE tb_arquivos SET Nome = @Nome, Descricao = @DescricaoPdf, Autor = @AutorPdf, UrlPDF = @NameFilePdf," +
                    " UrlImage = @NameFileImage, Data_Upload = @Data_Upload, Category_Id = @CategoriaPdf WHERE ArquivoId = '"+ value + "'",con);
                command.Parameters.Add("@Nome", SqlDbType.NVarChar).Value = NomePdf;
                command.Parameters.Add("@AutorPdf", SqlDbType.NVarChar).Value = AutorPdf;
                command.Parameters.Add("@CategoriaPdf", SqlDbType.NVarChar).Value = CategoriaPdf;
                command.Parameters.Add("@DescricaoPdf", SqlDbType.NVarChar).Value = DescriptionPdf;
                command.Parameters.Add("@NameFilePdf", SqlDbType.NVarChar).Value = "/arquivo/" + NameFinaleiraPdf;
                command.Parameters.Add("@NameFileImage", SqlDbType.NVarChar).Value = "/imagemPdfs/" + NameFinaleiraImage;
                command.Parameters.Add("@Data_Upload", SqlDbType.NVarChar).Value = dateTimeToDate;

                try
                {
                    con.Open();
                    command.ExecuteNonQuery();
                    UploadPdf.PostedFile.SaveAs(@"C:\Users\diego\source\repos\TheKingPDF\TheKingPDF\arquivo\" + NameFinaleiraPdf);
                    UploadImage.PostedFile.SaveAs(@"C:\Users\diego\source\repos\TheKingPDF\TheKingPDF\imagemPdfs\" + NameFinaleiraImage);
                }
                catch(Exception ex)
                {
                    Response.Write(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }

        }

        protected void BtnLimpar_Click(object sender, EventArgs e)
        {
            NomeArquivo.Text = "";
            NomeAutor.Text = "";
            CategoryPdf.Text = "";
            DescricaoPdf.Value = "";
        }
    }
}