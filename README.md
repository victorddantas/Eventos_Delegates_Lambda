# Eventos,Delegates e Lambda em C# 


Um sistema básico de  consulta de clientes, utilizando Entity Framework, aplicando os conceitos de Eventos,Delegates e Lambda
Criando um sistema básico de consulta de clientes, utilizando Entity Framework, aplicando os conceitos de Eventos,Delegates e Lambda.

Os delegates tem como função criar referência para métodos, possibilitando a chamada desse em tempo de execução, quando assim for necessário. 

Os delegates estão relacionados aos eventos. Os eventos são uma maneira da aplicação retornar uma notificação ao ususário de acordo com a sua interação com o sistema.
Os eventos utilizam os delegates para realizar a comunicação entre os nosso métodos e os retornos da aplicação para o usuários

Quando um delegate é criado, automáticamente ele herda a classe Delegate do C# e assim passamos o nome do método (como um parâmetro para o construtor do delegate) para o qual o delegate irá referenciar.
Quando "assinamos" com um delegate, o método na qual iremos referênciar deverá respeitar a assinatura desse delegate.

As expressões lambda em C# são usadas como funções anônimas, com a diferença que nas expressões lambda você não precisa especificar o tipo do valor que você insere, deixando elas muito mais flexíveis na utilização. 
O '=>' é o operador utilizado nas expressões lambda. Ela é dividida em duas partes, o lado esquerdo é a entrada e o lado direito é a expressão.
Básicamente as expressões lambda possbilitam os transporte de funções como valores. 
