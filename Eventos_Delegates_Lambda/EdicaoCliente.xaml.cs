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
using static System.Net.Mime.MediaTypeNames;

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
            //A partir do momento que eu faço o casting e defino o método como do tipo delegate o compilador passa a conceder acesso a classe abstrata Delegate. 
            //dispensando o uso do termo DELEGATE, podendo utlizar o var.



            //manipulando com operador "+" (somando os métodos)

            var okEventHandler = dialogResultTrue + Fechar;


            //manipulando com o combine. (utlizando com o operador de soma o compiladaor irá utilizar o método combine, então para reduzir o código opte por usar o operador de soma.
            var cancelarEventHandler = (RoutedEventHandler)Delegate.Combine(dialogResultFalse, (RoutedEventHandler)Fechar); // o delegate combine pode somar diferentes métodos 
                                                                                                                            //podemos fazer a chamada do Fechar mesmo ele recebendo como parêmetro EventArgs e não um RoutedEventArgs, pois essa herda de EventArgs

            btnOk.Click += okEventHandler;
            btnCancelar.Click += cancelarEventHandler; //ao invés de passar os métodos diretemante (ok e cancelar), somasse os dois passando os mesmos como delagates 


            //validação dos campos (podemos dispensar a instanciação do delegate, pois colocando só o nome proprosto, o comnpilador já entende método.
            //Utilizando o método DelegateValidacaoCampo que cria os delgates dinâmicamente

            //txtNome.TextChanged += DelegateValidacaoCampo(txtNome);
            //txtTelefone.TextChanged += DelegateValidacaoCampo(txtTelefone);
            //txtEndereco.TextChanged += DelegateValidacaoCampo(txtEndereco);
            //txtObs.TextChanged += DelegateValidacaoCampo(txtObs);

            //Nesse caso se apenas tratarmos o sender, é necessário passae apenas o método ValidarCampoNulo
            // txtTelefone.TextChanged += ValidarCampoNulo;
            //txtTelefone.TextChanged += ValidarSomenteNumero;

            //txtNome.TextChanged += ValidarCampoNulo;
            //txtEndereco.TextChanged += ValidarCampoNulo;
            //txtObs.TextChanged += ValidarCampoNulo;

            //Ao invès de utlizar o  TextChanged, utlizamos um evento criado por nós mesmo (Validacao), presente na classe ValidacaoTextBox
            txtTelefone.Validacao += ValidarCampoNulo;
            txtTelefone.Validacao += ValidarSomenteNumero;

            txtNome.Validacao += ValidarCampoNulo;
            txtEndereco.Validacao += ValidarCampoNulo;
            txtObs.Validacao += ValidarCampoNulo;

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


        //Método para alteração de cor na validação do campo 


        //private void TxtNome_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    var textoVazio = string.IsNullOrEmpty(txtNome.Text);

        //    if (textoVazio)
        //    {
        //        txtNome.Background = new SolidColorBrush(Colors.Red);
        //    }
        //    else
        //    {
        //        txtNome.Background = new SolidColorBrush(Colors.White);

        //    }
        //}



        //Método para construir delegates dinâmicamente para evitar a repetição de código para validação do campo, pois teria que criar um método para cada campo igaul o acima


        //private TextChangedEventHandler DelegateValidacaoCampo (TextBox txt) //recebe como parâmetro um textbox 
        //{
        //    return (o, e) => // o "o"  representa o sender que por sua vez representa o objeto que disparará o evento 
        //    {
        //        var textoVazio = string.IsNullOrEmpty(txt.Text);

        //        //if (textoVazio)
        //        //{
        //        //    txt.Background = new SolidColorBrush(Colors.Red);
        //        //}
        //        //else
        //        //{
        //        //    txt.Background = new SolidColorBrush(Colors.White);

        //        //}


        //        //Podemos susbtituir pelo if ternário 

        //        //se o retorno de textoVazio for true, prrencha o campo de vermelho, senão preencha de branco
        //        txt.Background = textoVazio ? txt.Background = new SolidColorBrush(Colors.Red) : txt.Background = new SolidColorBrush(Colors.White); 


        //    };
        //}


        //ao invés de se contruir umn método de contrução de delgates, podemos apenas tratar o sender ("o"),  que por sua vez representa o objeto que disparará o evento 

        private bool ValidarCampoNulo(string txt)
        {
         
            return !string.IsNullOrEmpty(txt);  //retonará se o campo édiferente de vazio ou nulo

        }

        //Um código dentro de uma expressão lambda só será excutado quando o delegate for invocado, ou sejá, no disparo do evento.



        //Método para validar campo numérico 
        private bool ValidarSomenteNumero(string txt)
        {
           
            //Criando funções
            //este delegate será utlizado para verificar o caractere digitado. O func é argumento do método de extensão ALL (esse é uma método genérico) do LINQ C#
            //Esse é um delegate Genérico que retotna TResult, que é um argumento genérico desse delegate (TResult é do Tipo bool no método ALL)

            /* Func<char, bool> verificaDigito = caractere => Char.IsDigit(caractere);*/ //caractere é o argumento que será verificado se é um digito ou não
                                                                                         //o IsDigit é um método da classe Char que retorna verdadeiro se caso o caractere passado for um digito.



            //podemos simplificar a func acima utilizando apenas o Isdigit (recebe um char e retorna um bool) 

            //Func<char, bool> verificaDigito = Char.IsDigit;

            /* var VerificaTextoEhDigito = txt.Text.All(verificaDigito);*/ //utiliznado um método de extensão do LINQ. 


            //ou podemos simplemente utlizar o Isdigit como parêmetro do Método ALL 

            return txt.All(Char.IsDigit); //retonará se o campo é válido ou não
          
        }

    }
}
