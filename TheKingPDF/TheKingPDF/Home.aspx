<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="TheKingPDF.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!--[if lt IE 9]>
	<script src="http://html5shiv.googlecode.com/svn/trunk/html5.js"></script>
	<![endif]-->
	<meta charset="utf-8"/>
	<meta http-equiv="X-UA-Compatible" content="IE=edge"/>
	<meta name="viewport" content="width=device-width, initial-scale=1.0"/>
	<meta name="description" content="Contéudo para download de pdf's"/>
	<meta name="robots" content="index, follow"/>
	<meta name="msnbot" content="index,follow"/>
	<title>The King PDF</title>
	<!-- BOOTSTRAP.css -->
	<link rel="stylesheet" type="text/css" href="css/bootstrap.min.css"/>
	<!-- STYLE.css -->
	<link rel="stylesheet" type="text/css" href="css/style.css"/>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <!-- TOP HEADER -->
	<div class="top-header">
		<div class="container">
			<div class="row">
				<div class="col s12">
					<div class="float-left">
						<span><asp:Label ID="LabelSession" runat="server" Text="Label"></asp:Label></span>
					</div>
					<div class="float-right">
						<a href="PainelUser.aspx" target="_self" runat="server" id="painelAcesso">Acesse seu perfil</a>
                        <asp:Button class="ButtonTeste" ID="Button_Logout" runat="server" Text="Logout" OnClick="Button_Logout_Click" />
						<a href="Login.aspx" runat="server" id="IdLogin" target="_self" title="Clique e faça seu login">Login</a>
						<a href="Registro.aspx" runat="server" id="IdRegistre" target="_self" class="content-left" title="Clique e registre-se">Registrar-se</a>
					</div>
				</div>
			</div>
		</div>
	</div>
	<!-- HEADER -->
	<header class="header">
		<div class="container">
			<div class="row">
				<div class="col-sm-12">
					<div class="centraliza">
						<a href="Home.aspx" alt="The King PDF" title="The King PDF">
							<div class="logo">The King PDF</div>
						</a>
					</div>
				</div>
			</div>
		</div>
	</header>

	<!-- MENU -->
	<nav class="bg-menu">
		<div class="container">
			<nav class="navbar navbar-expand-lg">
			  <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#menu-header" aria-controls="menu-header" aria-expanded="false" aria-label="Toggle navigation">
			    <span class="navbar-toggler-icon"></span>
			  </button>

			  <div class="collapse navbar-collapse" id="menu-header">
			    <ul class="navbar-nav mr-auto">
			      <li class="nav-item active">
			        <a class="nav-link" href="#">Home</a>
			      </li>
			      <li class="nav-item active">
			        <a class="nav-link" href="#">Sobre nós</a>
			      </li>
			      <li class="nav-item dropdown">
			        <a class="nav-link dropdown-toggle" href="#" id="navbarCategorias" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
			          Categorias
			        </a>
			        <div class="dropdown-menu" aria-labelledby="navbarCategorias">
			          <a class="dropdown-item" href="#">Ação</a>
			          <a class="dropdown-item" href="#">Aventura</a>
			          <div class="dropdown-divider"></div>
			          <a class="dropdown-item" href="#">Outros</a>
			        </div>
			      </li>
			      <li class="nav-item active">
			        <a class="nav-link" href="#">Contato</a>
			      </li>
			    </ul>
			    <form class="form-inline my-2 my-lg-0">
			      <input class="form-control mr-sm-2 large-form" type="search" placeholder="Buscar" aria-label="Buscar">
			    </form>
			  </div>
			</nav>
		</div>
	</nav>

	
	<!-- JQUERY.js -->
	<script src="js/jquery-3.3.1.js" type="text/javascript"></script>
	<!-- BOOTSTRAP.js -->
	<script src="js/bootstrap.min.js" type="text/javascript"></script>
        </div>
    </form>
</body>
</html>
