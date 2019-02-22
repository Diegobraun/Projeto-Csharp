<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TheKingPDF.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta charset="utf-8"/>
	<meta http-equiv="X-UA-Compatible" content="IE=edge"/>
	<meta name="viewport" content="width=device-width, initial-scale=1.0"/>
	<meta name="description" content="Contéudo para download de pdf's"/>
	<meta name="robots" content="index, follow"/>
	<meta name="msnbot" content="index,follow"/>
	<title>Login</title>
	<!-- BOOTSTRAP.css -->
	<link rel="stylesheet" type="text/css" href="css/bootstrap.min.css"/>
	<!-- STYLE.css -->
	<link rel="stylesheet" type="text/css" href="css/style.css"/>
</head>
<body class="body-bg">
    <form id="form1" runat="server">
        <div>
            <div class="top-header">
		<div class="container">
			<div class="row">
				<div class="col s12">
					<div class="float-right">
						<a href="Home.aspx" target="_self" title="Clique e faça seu login">Home</a>
						<a href="Registro.aspx" target="_self" class="content-left" title="Clique e registre-se">Registrar-se</a>
					</div>
				</div>
			</div>
		</div>
	</div>
	<!-- LOGIN -->
	<section class="login-bg">
		<div class="container">
			<div class="row">
				<div class="col-sm-12">
					<div class="centraliza">
						<div class="bgcolor-login">
							<h1 class="tkpdf-logo">The King PDF</h1>
							<form method="POST" action="#" enctype="multipart/form-data" class="form-login">
							  <div class="form-group">
							    <label for="exampleInputEmail1">Email</label>
							    <asp:TextBox runat="server" type="email" class="form-control" id="InputEmail" aria-describedby="emailHelp" placeholder="Informe seu email"></asp:TextBox>
							  </div>
							  <div class="form-group">
							    <label for="exampleInputPassword1">Senha</label>
							    <asp:TextBox runat="server" type="password" class="form-control" id="InputPassword" placeholder="Informe sua senha"></asp:TextBox>
							  </div>
							  <asp:Button runat="server" class="btn btn-primary btn-login" Text="Entrar" OnClick="Unnamed1_Click"></asp:Button>
							</form>
						</div>
					</div>
				</div>
			</div>
		</div>
	</section>


	<!-- JQUERY.js -->
	<script src="js/jquery-3.3.1.js" type="text/javascript"></script>
	<!-- BOOTSTRAP.js -->
	<script src="js/bootstrap.min.js" type="text/javascript"></script>
        </div>
    </form>
</body>
</html>
