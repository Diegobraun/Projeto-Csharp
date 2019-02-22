function limpa_formulario_cep() {
        //Limpa valores do formulario de cep.
        document.getElementById('cidade').value=("");
        document.getElementById('estado').value=("");
}

function meu_callback(conteudo) {
    if (!("erro" in conteudo)) {
        //Atualiza os campos com os valores.
        document.getElementById('cidade').value=(conteudo.localidade);
        document.getElementById('estado').value=(conteudo.uf);
    } //end if.
    else {
        //CEP não Encontrado.
        limpa_formulario_cep();
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
            script.src = 'https://viacep.com.br/ws/'+cep+'/json/?callback=meu_callback';
            //Insere script no documento e carrega o conteúdo.
            document.body.appendChild(script);
        } //end if.
        else {
            //cep é inválido.
            limpa_formulario_cep();
            alert("Formato de CEP inválido.");
        }
    } //end if.
    else {
        //cep sem valor, limpa formulário.
        limpa_formulario_cep();
    }
};

function limpa_nome(){
    document.getElementById('nome').value=("");
    document.getElementById('nome').focus();
}

function limpa_email(){
    document.getElementById('email').value= ("");
    document.getElementById('email').focus();
}

function limpa_datanascimento(){
    document.getElementById('datanascimento').value=("");
    document.getElementById('data').focus();
}

function limpa_celular(){
    document.getElementById('celular').value=("");
    document.getElementById('celular').focus();
}

function limpa_confirmarsenha(){
    document.getElementById('confirmasenha').value=("");
    document.getElementById('confirmasenha').focus();
}

function valida_nome(campo) {
    var regex = /^[a-zA-ZéúíóáÉÚÍÓÁèùìòàçÇÈÙÌÒÀõãñÕÃÑêûîôâÊÛÎÔÂëÿüïöäËYÜÏÖÄ\-\ \s]+$/;
}


function valida_datanascimento(){
}

function valida_sexo(){
}

function valida_senha(){
}

function valida_confirmarsenha(){
}

function validar_email(){
if( document.forms[0].email.value=="" || document.forms[0].email.value.indexOf('@')==-1 || document.forms[0].email.value.indexOf('.')==-1 )
    {
       alert( "Por favor, informe um E-MAIL valido!" );
    }
}

function validar_nome(){
    nome_completo = document.getElementById('nome').text;
    if (nome_completo.value == "a"){
        alert(nome_completo)
    }
}