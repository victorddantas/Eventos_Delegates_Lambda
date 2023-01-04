using Eventos_Delegates_Lambda.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Eventos_Delegates_Lambda
{
    /// <summary>
    /// Interaction logic for EdicaoCliente.xaml
    /// </summary>
    public partial class EdicaoCliente : Window
    {
        private readonly Cliente _cliente;
        public EdicaoCliente(Cliente cliente) //vai receber qual cliente será editado
        {
            InitializeComponent();

            _cliente = cliente ?? throw new ArgumentNullException(nameof(cliente)); //?? é um operador de coalescência nula, ele retorna o operando esquerdo se o operando não for nulo; caso contrário, ele retornará o operando direito.
            AtualizaCamposDeTexto();                                                //O ?. é para evitar comparações do tipo obj != null ? obj.prop : null, ou seja, ele verificará se o que tem antes da interrogação é diferente de null        
            AtualizarDados();
        }

        private void AtualizaCamposDeTexto()
        {
            txtId.Text = Convert.ToString(_cliente.Id);
            txtNome.Text = _cliente.Nome;
            txtEndereco.Text = _cliente.Endereco;
            txtTelefone.Text = _cliente.Telefone;
            txtObs.Text = _cliente.Observacoes;

        }

        //adicionando eventos de atualizar e cancelar
        private void AtualizarDados()

        {
            //Utilizando os delegates por meio de  métodos anônimos, dispensamos a necessidade de criação de métodos privados fora do bloco de código, sendo que esses métodos só serão utlizados 
            //pelos delegates contidos dentro deste bloco.


            //RoutedEventHandler dialogResultTrue = delegate (object sender, RoutedEventArgs e) // ele irá criar um método privado e vai atribuir a vai atribuir a variável dialogResultTrue
            //{
            //    DialogResult = true; //definindo valor do click ok
            //};

            //RoutedEventHandler dialogResultfalse = delegate (object sender, RoutedEventArgs e)
            //{
            //    DialogResult = false;//definindo valor do click cancelar
            //};

            //Podemos simplificar o código acima utilizando expressões Lambda

            RoutedEventHandler dialogResultTrue = (o,e) => DialogResult = true;
            RoutedEventHandler dialogResultFalse = (o,e) => DialogResult = false;





            //criando um delegate manipulando os métodos 


            //utilizando os delegates podemos tratar métodos com objetos (manipuláveis), porém temos que fazer um casting explicitando que se trata de um evento (RoutedEventHandler)
            //A prtir do momento que eu faço o casting e defino o método como do tipo delegate o compilador passa a conceder acesso a classe abstrata Delegate. 
            //dispensando o uso do termo DELEGATE, podendo utlizar o var.



            //manipulando com operador "+" (somando os métodos)

            var okEventHandler = dialogResultTrue + Fechar;


            //manipulando com o combine. (utlizando com o operador de soma o compiladaor irá utilizar o método combine, então para reduzir o código opte por usar o operador de soma.
            var cancelarEventHandler = (RoutedEventHandler)Delegate.Combine(dialogResultFalse, (RoutedEventHandler)Fechar); // o delegate combine pode somar diferentes métodos 
                                                                                                                            //podemos fazer a chamada do Fechar mesmo ele recebendo como parêmetro EventArgs e não um RoutedEventArgs, pois essa herda de EventArgs

            btnOk.Click += okEventHandler;
            btnCancelar.Click += cancelarEventHandler; //ao invés de passar os métodos diretemante (ok e cancelar), somasse os dois passando os mesmos como delagates 
        }


        //Métodos que são utlizados no delegates.
        
        //Estes métodos, só serão utlizados nos delegates, desta forma, para simplificar o código podemos utlizar métodos anônimos
        //Estes por sua vez não possuem nomes e possuem uma sintaxe mais simples 

        //private void btnOk_Click(object sender, EventArgs e) => DialogResult = true; //definindo valor do click 
        //    //Close();
        
        //private void btnCancelar_Click(object sender, EventArgs e) => DialogResult = false;
        //    //Close();
        



        //subistitui o Close()
        
        private void Fechar(object sender, EventArgs e) => Close();
      
    }
}
