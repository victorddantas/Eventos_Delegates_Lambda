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

    public delegate bool ValidacaoEventHandler(string txt); 

    public class ValidacaoTextBox : TextBox
    {

        public event  ValidacaoEventHandler Validacao;


        //no construtor passamoso o TextChanged para criarmos nossa própria alteração de texto  
        public ValidacaoTextBox()
        {
            TextChanged += ValidacaoTextBox_TextChanged;
        }

        private void ValidacaoTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (Validacao != null)
            {
                var validaTexto = Validacao(Text); //recebe o evento com o parâmetro Text (Valor recebido dos textbox), retornando um bool


                //if ternário: caso verdadeiro apresenta branco, caso retorno falso vermelho  
                Background = validaTexto ? new SolidColorBrush(Colors.White) : new SolidColorBrush(Colors.Red);
            }
           


        }
    }
}
