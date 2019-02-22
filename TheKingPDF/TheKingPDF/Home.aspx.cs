using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TheKingPDF
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string ShowSession = (string)Session["UsernameComplete"];
            string ShowMinimizedSession = (string)Session["UsernameSimplify"];

            if (ShowSession != null && ShowSession != "")
            {
                LabelSession.Text = "Olá, " + ShowMinimizedSession;
                LabelSession.Style.Add("color", "white");
                IdLogin.Style.Add("display", "none");
                IdRegistre.Style.Add("display", "none");
            }
            else
            {
                LabelSession.Style.Add("display", "none");
                Button_Logout.Style.Add("display", "none");
                painelAcesso.Style.Add("display", "none");
            }
        }

        protected void Button_Logout_Click(object sender, EventArgs e)
        {
            Session.Remove("UsernameComplete");
            Session.Remove("UsernameSimplify");
            Response.Redirect("Home.aspx");
        }
    }
}