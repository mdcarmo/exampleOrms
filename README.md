Repositório Hibrido

<img src="https://github.com/mdcarmo/exampleOrms/blob/master/Api/images/arq_hibrida12.PNG" />

Neste exemplo estou utilizando O <b>Entity Framework</b> para efetuar as operações de insert, update e delete e o <b>Dapper</b> para realizar as operações de consulta.

A intenção é utilizar o que de melhor oferece os dois ORM's, a facilidade de uso do EF com a performance realizada pelo Dapper.

Para rodar esse código, faça o dowload e acerte os arquivos de configuração do projeto <b>DatabaseCreator</b> e do projeto <b>Api</b>. Nestes arquivos coloque uma string de conexão válida na chave connectionString.

Este exemplo está funcionando com o SQL SERVER na versão 2014.

Após corrigir a string de conexão rode o projeto DatabaseCreator, o mesmo deverá criar as tabelas (2 tabelas Customer e User) e criar a procedure que busca todos os customers por sobrenome.

<img src="https://github.com/mdcarmo/exampleOrms/blob/master/Api/images/arq_hibrida5.PNG" />

Depois de criado o banco, basta rodar o projeto de API. Neste estou usando o Swagger, então adicione depois da url do serviço 
"/swagger/ui" exemplo: <b>http://localhost:porta/swagger/ui/</b>

<img src="https://github.com/mdcarmo/exampleOrms/blob/master/Api/images/arq_hibrida7.PNG" />

Espero ajudar e quem puder opiniar ou melhorar o código sinta-se a vontade.

Fiz um artigo sobre este exemplo no meu blog: www.marcdias.com.br dá uma olhada lá e comenta o que achou. 

Obrigado. 

Marcelo Dias.
