# Eventos,Delegates e Lambda em C# 

Criando um sistema básico de consulta de clientes, utilizando Entity Framework, aplicando os conceitos de Eventos,Delegates e Lambda.

Os delegates tem como função criar referência para métodos, possibilitando a chamada desse em tempo de execução, quando assim for necessário. 

Os delegates esta relacionados aos eventos. O eventos são uma maneira da aplicação retornar uma notificação ao ususário de acordo com a sua interação com o sistema.
Os eventos utilizam os delagates para realizar a comunicação entre os nosso métodos e os retornos da aplicação para o usuários

Quando um delegate é criado, automáticamente ele herda a classe Delegate do C# e assim  
passamos o nome do método (como um parâmetro para o construtor do delegate) para o qual o delegate irá referenciar.
Quando assinamos com um delegate, o método na qual iremos referênciar deverá respeitar a assinatura desse delegate.


