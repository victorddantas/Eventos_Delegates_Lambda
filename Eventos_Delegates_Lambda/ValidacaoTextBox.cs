using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Eventos_Delegates_Lambda
{
    //Criando nosso próprio evento de validação


    //Todo evento precisa seguir assinatura de de um método formal, disponibilizado pelo delegate

    //Criando Delegate do evento

    public delegate void ValidacaoEventHandler(object sender, ValidacaoEventArgs e); 

    public class ValidacaoTextBox : TextBox
    {

        //adicionando ou removendo comportamentos de eventos 

        private ValidacaoEventHandler _validacao; //criando campo privado para guardar o valor do delegate

        public event ValidacaoEventHandler Validacao
        {
            add 
            {
                _validacao += value; //adicionando comportamento 
                OnValidaTextBox(); //executa a validação

            }
            remove
            {
                _validacao -= value; //removendo comportamento
                OnValidaTextBox(); //executa a validação
            }
        }


        //sobreescrevendo o método OnTextChanged 
        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            base.OnTextChanged(e);
            OnValidaTextBox();
        }


        //método que será invocado no momento da validação
        protected virtual void OnValidaTextBox()
        {
            if (_validacao != null) // quando utlizamos o add e o remove no event, não podemos utilizá-lo, nesse caso utlizamos o campo privado que irá retornar o valor 
            {


                //Quando mais de um delegate é assinado em um evento o último  a ser assinado é o que tem o seu valor de retorno preservado
                //para obeter a lista de delegates assinados em nosso evento, utlizamos o GetInvocationList, que retonar uma lista dos delagates

                var listaInvocacaoValidacao =  _validacao.GetInvocationList();
                var eventArgs = new ValidacaoEventArgs(Text);
                var validaTexto = true;

                foreach (ValidacaoEventHandler InvocacaoValidacao in listaInvocacaoValidacao) //necessário o casting pois o InvocacaoValidacao precisa ser do tipo do delagate
                {

                    InvocacaoValidacao(this, eventArgs);
                    if (eventArgs.EhValido)
                    {
                        validaTexto = false;
                        break;
                    };
                } 


                //if ternário: caso verdadeiro apresenta branco, caso retorno falso vermelho  
                Background = validaTexto ? new SolidColorBrush(Colors.White) : new SolidColorBrush(Colors.Red);
            }
        }
    }
}
