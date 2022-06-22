create database Bd_escola;

use Bd_escola;


create table Escola(
id_esc int primary key auto_increment,
nome_fantasia_esc varchar(300), 
razao_social_esc varchar(300), 
cnpj_esc varchar(300), 
insc_esc varchar(300), 
tipo_esc varchar(300), 
data_criacao_esc date, 
responsavel_esc varchar(300), 
responsavel_telefone_escola_esc varchar(100), 
email_esc varchar(300), 
telefone_esc varchar(300), 
rua_esc varchar(300), 
numero_esc int, 
bairro_esc varchar(300), 
complemento_esc varchar(300), 
cep_esc varchar(100), 
cidade_esc varchar(300), 
estado_esc varchar(300)
);

create table Curso(
id_cur int primary key auto_increment,
nome_curso_cur varchar(300),
carga_horaria_cur varchar(300),
descricao_cur varchar(400),
turno_cur varchar(300)
);

