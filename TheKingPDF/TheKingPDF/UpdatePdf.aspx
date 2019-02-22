<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdatePdf.aspx.cs" Inherits="TheKingPDF.UpdatePdf" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <!--[if lt IE 9]>
	<script src="http://html5shiv.googlecode.com/svn/trunk/html5.js"></script>
	<![endif]-->
	<meta charset="utf-8"/>
	<meta http-equiv="X-UA-Compatible" content="IE=edge"/>
	<meta name="viewport" content="width=device-width, initial-scale=1.0"/>
	<meta name="description" content="Contéudo para download de pdf's"/>
	<meta name="robots" content="index, follow"/>
	<meta name="msnbot" content="index,follow"/>
	<title>Atualização de Conteúdo</title>
	<!-- BOOTSTRAP.css -->
	<link rel="stylesheet" type="text/css" href="css/bootstrap.min.css"/>
	<!-- STYLE.css -->
	<link rel="stylesheet" type="text/css" href="css/style.css"/>
	<!-- DROPFIT-->
	<link rel="stylesheet" href="plugins/dropify/css/dropify.min.css"/>
</head>
<body class="bg-body">
		<form class="needs-validation" runat="server">
	<!-- TOP HEADER -->
	<div class="top-header">
		<div class="container">
			<div class="row">
				<div class="col s12">
					<div class="float-right">
					</div>
				</div>
			</div>
		</div>
	</div>
	<div class="container">
		<div class="row">
			<div class="py-5 col-sm-12 text-center">
		        <h2 class="text-center" style="font-weight: bold;">Atualização de Conteúdo</h2>
		    </div>
		</div>
	</div>
	<!-- FORM -->
	<div class="container bg-form">
		<div class="row">
			<div class="col-md-12 col-lg-6 order-md-1">
		            <div class="row">
		              <div class="col-md-12 col-lg-6 mb-3">
		                <label for="nome">Nome do Arquivo</label>
                          <asp:TextBox ID="NomeArquivo" class="form-control" required="required"  placeholder="Nome do Arquivo" runat="server"></asp:TextBox><br />
		              </div>
		              <div class="col-md-12 col-lg-6 mb-3">
		                <label for="autor">Autor</label>
		                <asp:TextBox ID="NomeAutor" type="text" class="form-control" runat="server" placeholder="Nome do Autor" required="required"></asp:TextBox>
		              </div>
                        <div class="col-md-12 mb-3">
                        <label for="CategoryPdf">Selecione a categoria</label>
                        <asp:DropDownList runat="server" class="form-control" name="sexo" id="CategoryPdf">
						    <asp:ListItem value="">Selecione a categoria</asp:ListItem>
							<asp:ListItem value="1">Gastronomia</asp:ListItem>
							<asp:ListItem value="2">TI</asp:ListItem>
						</asp:DropDownList>
                            </div>
		              <div class="col-md-12 mb-3">
		                <label for="descricao">Descrição</label>
		                 <textarea class="form-control classTextDescription" rows="8" id="DescricaoPdf" runat="server" placeholder="Descrição breve sobre o pdf"></textarea>
		              </div>
		            </div>
		        </div>
		        <div class="col-md-12 col-lg-6 order-md-1">
					<div class="file-field input-field">
						<p class="mg-top13">Selecione a Capa do PDF</p>
						<div class="upload">
						    <asp:FileUpload ID="UploadImage" runat="server" type="file" name="img-chamada" class="dropify"/>
						</div>
					</div>
		        	<p class="mg-top30">Selecione o PDF</p>
					<div class="file-field input-field">
						<div class="upload">
						    <asp:FileUpload ID="UploadPdf" runat="server" type="file" name="img-chamada"/>
						</div>
					</div>
				</div>
				<div class="col-md-12 col-lg-6 order-md-1">
					<asp:Button type="submit" style="width: 100% !important;" runat="server" class="mg-top30 btn btn-primary btn-login" ID="BtnCadastrar" Text="Atualizar" OnClick="BtnCadastrar_Click"></asp:Button>
				</div>
				<div class="col-md-12 col-lg-6 order-md-1">
                    <asp:Button runat="server" type="reset" style="width: 100% !important;" class="mg-top30 btn btn-primary btn-login" ID="BtnLimpar" Text="Limpar" OnClick="BtnLimpar_Click"></asp:Button>				</div>
			</div>
	</div>
	<!-- JQUERY.js -->
	<script src="js/jquery-3.3.1.js" type="text/javascript"></script>
	<script type="text/javascript" src="plugins/dropify/js/dropify.min.js"></script>
	<script type="text/javascript" src="plugins/dropify/js/funcao-dropify.js"></script>
    </form>
</body>
</html>
