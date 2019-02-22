<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PainelUser.aspx.cs" Inherits="TheKingPDF.PainelUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
	<meta http-equiv="X-UA-Compatible" content="IE=edge"/>
	<meta name="viewport" content="width=device-width, initial-scale=1.0"/>
	<meta name="description" content="Contéudo para download de pdf's"/>
	<meta name="robots" content="index, follow"/>
	<meta name="msnbot" content="index,follow"/>
	<title>Painel Adminstrativo</title>
	<!-- BOOTSTRAP.css -->
	<link rel="stylesheet" type="text/css" href="css/bootstrap.min.css"/>
	<!-- STYLE.css -->
	<link rel="stylesheet" type="text/css" href="css/style.css"/>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
</head>
<body>
   <form runat="server">
   <!-- TOP HEADER -->
	<div class="top-header">
		<div class="container">
			<div class="row">
				<div class="col s12">
					<div class="float-right">
                        <asp:Button ID="BtnSair" target="_self" title="Sair do Painel" runat="server" Text="Sair" OnClick="BtnSair_Click" />
					</div>
				</div>
			</div>
		</div>
	</div>
	<div class="jumbotron">
        <div class="container">
            <asp:Label class="display-3" ID="SessionNameClass" runat="server" Text=""></asp:Label>
          <p>Esse é seu painel administrativo, cadastre seu PDF é gratis!</p>
            <p><asp:Button ID="BtnRegisterPdf" class="btn btn-primary btn-lg" runat="server" role="button" Text="Cadastrar" OnClick="BtnRegisterPdf_Click"></asp:Button></p>
        </div>
    </div>
    <div class="container">
    	<div class="row">
    		<div class="col-sm-12">
    			<div class="mg-top30">
	    			<h4 class="float-left">Lista de PDF's cadastrados</h4>
	    			<h6 class="float-right" id="CountPdfCadastrado" runat="server"></h6>
    			</div>
    		</div>
    	</div>
    </div>
	<!-- PDF -->
	<main class="main mg-top30">
		<div class="album py-5 bg-light">
        <div class="container">
          <div class="row" id="server" runat="server">
 
          </div>
        </div>
      </div>
	</main> 
       </form>
</body>
</html>
