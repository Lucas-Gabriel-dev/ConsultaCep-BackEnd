# ConsultaCep-BackEnd
![version]( https://img.shields.io/badge/version-1.0.0-Green)

## Sobre
Projeto para realizar consultas de BackEnd utilizando a API disponibilizada por "ViaCep"
<br>

# Ferramentas Utilizadas
Logo abaixo, irei descrever quais foram as ferramentas utilizadas para o desenvolvimento do BackEnd.<br>

## .NET 6
Para todo o desenvolivmento foi o utilizado o .NET 6, que oferece diversos recursos e pacotes para o desenvolvimento. Os pacotes utilizados no desenvolvimento
foram: <br> 

<b> Microsoft.AspNet.WebApi.Cors: </b> Foi o principal recurso utilizado no desenvolvimento, uma vez que o BackEnd se comunica com o Front em API's. <br>

<b> Microsoft.EntityFrameworkCore.Design: </b> Foi o ORM utilizado para realizar consultar, atualizar, apagar e enviar dados para o banco de dados. <br>  

<b> Npgsql.EntityFrameworkCore.PostgreSQL: </b> Pacote que foi utilizado para o EntityFramework poder se comunicar com o banco de dados PostgreSQL.
<br>
<br>

## C#
Linguagem de programação que foi utilizada para o desenvimento. O C# oferece diversos recursos que facilitam na hora do desenvolimento.
<br>
<br>

## PostgreSQL
Banco de dados que foi utilizado para armazenar os dados da aplicação.
<br>
<br>

# Rotas da aplicação
A aplicação oferece diversas rotas, onde na maioria é necessário estar autenticado para utilizar.<br>

## GET

### All Ceps in Region - https://localhost:7236/consultarcep/uf/{SP}
Com essa rota você pode consultar todos os ceps de uma determinada região, basta passar a UF da região que deseja consultar.
No exemplo acima, estamos consultando ceps da região de São Paulo. Vale ressaltar que a rota só vai retornar ceps que já estão cadastrados no banco
de dados.
<br>
<br>

### Get Info City - https://localhost:7236/consultarcep/:12543465
Com essa rota você pode informação sobre alguma localização. Para isso é necessário passar os cep na rota, retornando como resposta um json
com informações que estão armazenadas no banco de dados.
<br>
<br>

## POST

### Add Cep - https://localhost:7236/consultarcep/addcep/:12543465
Nesta rota você adiciona novas localizações no banco de dados. Seu funcionamento é semelhante com a rota de "Get Info City", você deve passar qual
cep deseja adicionar ao banco na rota da requisição.

<br>
<br>
 
<h4 align="center">
✅  Consulta Cep 🚀 Concluído!!!  ✅
</h4>
