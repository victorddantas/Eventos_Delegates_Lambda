# Eventos,Delegates e Lambda em C# 

Criando um sistema b�sico de consulta de clientes, utilizando Entity Framework, aplicando os conceitos de Eventos,Delegates e Lambda.

Os delegates tem como fun��o criar refer�ncia para m�todos, possibilitando a chamada desse em tempo de execu��o, quando assim for necess�rio. 

Os delegates esta relacionados aos eventos. O eventos s�o uma maneira da aplica��o retornar uma notifica��o ao usus�rio de acordo com a sua intera��o com o sistema.
Os eventos utilizam os delagates para realizar a comunica��o entre os nosso m�todos e os retornos da aplica��o para o usu�rios

Quando um delegate � criado, autom�ticamente ele herda a classe Delegate do C# e assim  
passamos o nome do m�todo (como um par�metro para o construtor do delegate) para o qual o delegate ir� referenciar.
Quando assinamos com um delegate, o m�todo na qual iremos refer�nciar dever� respeitar a assinatura desse delegate.


