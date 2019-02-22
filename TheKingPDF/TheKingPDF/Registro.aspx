<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="TheKingPDF.Registro" %>

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
	<title>Registrar</title>
	<!-- BOOTSTRAP.css -->
	<link rel="stylesheet" type="text/css" href="css/bootstrap.min.css"/>
	<!-- STYLE.css -->
	<link rel="stylesheet" type="text/css" href="css/style.css"/>
</head>
<body class="body-bg">
        <div class="top-header">
		<div class="container">
			<div class="row">
				<div class="col s12">
					<div class="float-right">
						<a href="Home.aspx" target="_self" title="Clique e faça seu login">Home</a>
						<a href="Login.aspx" target="_self" class="content-left" title="Clique e registre-se">Login</a>
					</div>
				</div>
			</div>
		</div>
	</div>
	<!-- FORM -->
	<section class="">
		<div class="container">
			<div class="row">
				<div class="col-sm-12">
					<div class="form-content">
						<form runat="server" enctype="multipart/form-data" class="form-login">
							<div class="row">
								<div class="col-sm-12">
									<div class="form-group">
										<h4>Registre-se e se mantenha atualizado!</h4>
									</div>
								</div>
							</div>
							<div class="row">
								<div class="col-md-6">
									<div class="form-group">
									    <label for="nome">Nome</label>
									    <asp:TextBox runat="server" type="text" name="name" class="form-control" maxlength="60" id="nome" placeholder="Nome Completo"></asp:TextBox>
									</div>
								</div>
								<div class="col-md-6">
									<div class="form-group">
									    <label for="email">Email</label>
									    <asp:TextBox runat="server" type="email" class="form-control" id="email" maxlength="120" aria-describedby="emailHelp" placeholder="Informe seu email"></asp:TextBox>
									</div>
								</div>
							</div>
							<div class="row">
								<div class="col-md-6">
									<div class="form-group">
									    <label for="datanascimento">Data de Nascimento</label>
										<asp:TextBox runat="server" id="datanascimento" name="date" type="date" class="form-control" placeholder="00/00/0000" maxlenght="8"></asp:TextBox>
									</div>
								</div>
								<div class="col-md-6">
									<div class="form-group">
									    <label for="celular">Celular</label>
									    <asp:TextBox runat="server" type="text" name="phone" class="form-control" id="celular" maxlength="12" placeholder="(00) 0 0000-0000"></asp:TextBox>
									</div>
								</div>
							</div>
							<div class="row">
								<div class="col-md-6">
									<div class="form-group">
									    <label for="sexo">Sexo</label>
									    <asp:DropDownList runat="server" class="form-control" name="sexo" id="sexo">
									    	<asp:ListItem value="">Selecione seu sexo</asp:ListItem>
									      	<asp:ListItem value="M">Masculino</asp:ListItem>
									      	<asp:ListItem value="F">Feminino</asp:ListItem>
									    </asp:DropDownList>
									</div>
								</div>
								<div class="col-md-6">
									<div class="form-group">
									    <label for="cep">CEP</label>
									    <asp:TextBox runat="server" type="text" name="cep" class="form-control" maxlength="9" id="cep" placeholder="00000-000" onblur="pesquisacep(this.value);"></asp:TextBox>
									</div>
								</div>
							</div>
							<div class="row">
								<div class="col-md-6">
									<div class="form-group">
									    <label for="cidade">Cidade</label>
									    <asp:TextBox runat="server" type="text" name="city" class="form-control" id="cidade" size="40" placeholder="Sua Cidade"></asp:TextBox>
									</div>
								</div>
								<div class="col-md-6">
									<div class="form-group">
									    <label for="estado">Estado</label>
									    <asp:TextBox runat="server" type="type" name="estado" class="form-control" id="estado" placeholder="Seu estado" size="40"></asp:TextBox>
									</div>
								</div>
							</div>
							<div class="row">
								<div class="col-md-6">
									<div class="form-group">
										<label for="senha">Senha</label>
										<asp:TextBox runat="server" type="password" name="pass1" class="form-control" id="senha" placeholder="Digite sua senha"></asp:TextBox>
									</div>
								</div>
								<div class="col-md-6">
									<div class="form-group">
										<label for="confirmarsenha">Confirmar Senha</label>
										<asp:TextBox runat="server" type="password" name="pass2" class="form-control" id="confirmarsenha" placeholder="Repita sua senha"></asp:TextBox>
									</div>
								</div>
							</div>
							<div class="row">
								<div class="col-sm-12">
									<div class="btn-form mg-top30">
										<asp:Button runat="server" class="btn btn-primary btn-login centraliza" style="width: 100% !important;" Text="Cadastrar" OnClick="Unnamed1_Click1"></asp:Button>
									</div>
								</div>
							</div>
						</form>
					</div>
				</div>
			</div>
		</div>
	</section>

	<!-- JQUERY.js -->
	<script src="js/jquery-3.3.1.js" type="text/javascript"></script>
	<!-- BOOTSTRAP.js -->
	<script src="js/bootstrap.min.js" type="text/javascript"></script>
	<script type="text/javascript">
        $(document).ready(function () {
            $('#cep').mask("00000-000");
            $('#celular').mask("(00) 0 0000-0000");
        });
    </script>
    <script type="text/javascript" >
		function limpa_formulário_cep() {
		    //Limpa valores do formulário de cep.
		    document.getElementById('cidade').value=("");
		    document.getElementById('estado').value = ("");
		    document.getElementById('cep').value = ("")
		    document.getElementById('cep').focus();

		}
		function meu_callback(conteudo) {
		    if (!("erro" in conteudo)) {
		        //Atualiza os campos com os valores.
		        document.getElementById('cidade').value=(conteudo.localidade);
		        document.getElementById('estado').value=(conteudo.uf);
		    } //end if.
		    else {
		        //CEP não Encontrado.
		        limpa_formulário_cep();
		        alert("CEP não encontrado.");
		    }
		}   
		function pesquisacep(valor) {
		    //Nova variável "cep" somente com dígitos.
		    var cep = valor.replace(/\D/g, '');
		    //Verifica se campo cep possui valor informado.
		    if (cep != "") {
		        //Expressão regular para validar o CEP.
		        var validacep = /^[0-9]{8}$/;
		        //Valida o formato do CEP.
		        if(validacep.test(cep)) {
		            //Preenche os campos com "..." enquanto consulta webservice.
		            document.getElementById('cidade').value="...";
		            document.getElementById('estado').value="...";
		            //Cria um elemento javascript.
		            var script = document.createElement('script');
		            //Sincroniza com o callback.
		            script.src = 'https://viacep.com.br/ws/'+ cep + '/json/?callback=meu_callback';
		            //Insere script no documento e carrega o conteúdo.
		            document.body.appendChild(script);
		        } //end if.
		        else {
		            //cep é inválido.
		            limpa_formulário_cep();
		            alert("Formato de CEP inválido.");
		        }
		    } //end if.
		    else {
		        //cep sem valor, limpa formulário.
		        limpa_formulário_cep();
		    }
		    };
		</script>
</body>
    <script src="js/validaform.js"></script>
</html>
