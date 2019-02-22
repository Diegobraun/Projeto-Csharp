using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace TheKingPDF
{
    public partial class RegisterPdf : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["UsernameComplete"] == "" || (string)Session["UsernameComplete"] == null)
                Response.Redirect("Login.aspx");
        }

        protected void BtnCadastrar_Click(object sender, EventArgs e)
        {
            string ShowSession = (string)Session["UsernameComplete"];
            string NomePdf = NomeArquivo.Text;
            string AutorPdf = NomeAutor.Text;
            string CategoriaPdf = CategoryPdf.Text;
            string DescriptionPdf = DescricaoPdf.Value;
            string NameFilePdf = UploadPdf.PostedFile.FileName;
            string NameFileImage = UploadImage.PostedFile.FileName;
            //datetime
            DateTime date = DateTime.Now;

            StringBuilder sb = new StringBuilder();
            sb.Append((date.ToShortTimeString().Replace(":", "")) + (date.ToShortDateString().Replace("/","")));
       
            string dateTimeToDate = date.ToShortDateString();//DateTime para por no date

            string dateFinalTime = sb.ToString();

            //File pdf
            string NameFinaleiraPdf = dateFinalTime + NameFilePdf; //NOME PDF FINAL
            string NameFinaleiraImage = dateFinalTime + NameFileImage;


            bool CheckImage(string FileImageName)
            {
                int TamanhoArquivo = FileImageName.Length;

                string SubsNameFile = FileImageName.Substring(TamanhoArquivo - 4);

                if (SubsNameFile.Equals(".png") || SubsNameFile.Equals("jpeg") || SubsNameFile.Equals(".jpg") || SubsNameFile.Equals(".avg"))
                    return true;
                else
                    return false;
            }


            //Método se for vazio
            bool CheckIfFieldsNull()
            {
                if (NomePdf != null && NomePdf.Trim() != "" && DescriptionPdf != null && DescriptionPdf.Trim() != "" && NameFilePdf != null && NameFilePdf.Trim() != "" && NameFileImage != null && NameFileImage.Trim() != "")
                    return true;
                else
                    return false;
            }

            //Método se arquivo é pdf
            bool CheckPdf(string FilePdfName)
            {
                int TamanhoArquivo = FilePdfName.Length;

                string SubsNameFile = FilePdfName.Substring(TamanhoArquivo - 3);

                if (SubsNameFile.Equals("pdf"))
                    return true;
                else
                    return false;
            }

            if (CheckIfFieldsNull() && CheckPdf(NameFinaleiraPdf) && CheckImage(NameFinaleiraImage))
            {
                SqlConnection SqlCon = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ProjetoFinal;Data Source=PC-DIEGO");
                SqlCommand command = new SqlCommand("INSERT INTO tb_arquivos(Nome,Descricao,Autor,UrlPDF,UrlImage,Data_Upload,Category_Id,Email) VALUES (@Nome,@Descricao,@Autor,@UrlPDF,@UrlImage,@Data_Upload,@Category_Id,@Email);", SqlCon);
                command.Parameters.Add("@Nome", SqlDbType.NVarChar).Value = NomePdf;
                command.Parameters.Add("@Descricao", SqlDbType.NVarChar).Value = DescriptionPdf;
                command.Parameters.Add("@Autor", SqlDbType.NVarChar).Value = AutorPdf;
                command.Parameters.Add("@UrlPDF", SqlDbType.NVarChar).Value = "/arquivo/" + NameFinaleiraPdf;
                command.Parameters.Add("@UrlImage", SqlDbType.NVarChar).Value = "/imagemPdfs/" + NameFinaleiraImage;
                command.Parameters.Add("@Data_Upload", SqlDbType.NVarChar).Value = dateTimeToDate;
                command.Parameters.Add("@Category_Id", SqlDbType.NVarChar).Value = CategoriaPdf;
                command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = ShowSession;

                try
                {
                    SqlCon.Open();
                    command.ExecuteNonQuery();
                    UploadPdf.PostedFile.SaveAs(@"C:\Users\diego\source\repos\TheKingPDF\TheKingPDF\arquivo\" + NameFinaleiraPdf);
                    UploadImage.PostedFile.SaveAs(@"C:\Users\diego\source\repos\TheKingPDF\TheKingPDF\imagemPdfs\" + NameFinaleiraImage);
                    Response.Write("PainelUser.aspx");
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

        protected void BtnLimpar_Click(object sender, EventArgs e)
        {
            NomeArquivo.Text = "";
            NomeAutor.Text = "";
            CategoryPdf.Text = "";
            DescricaoPdf.Value = "";
        }

       
    }
}