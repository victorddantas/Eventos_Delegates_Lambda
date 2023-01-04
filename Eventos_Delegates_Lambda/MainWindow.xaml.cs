using Eventos_Delegates_Lambda.DAL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Eventos_Delegates_Lambda
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //abrindo conexão com banco 
        private readonly EDLModelContainer _eDLModel = new EDLModelContainer(); //por convenção, campos privados devem iniciar com o "_" . 
        private readonly ListBox eDLListBox; //crinado o campo da listBox para adcionar os clientes

        public MainWindow()
        {
            eDLListBox = new ListBox(); //não se pode utilizar o "this" na criação de um novo campo.
            InitializeComponent();
            AtualizarDados();
            AtualizaListaDeCliente();
            
        }

        //método para atualiazação dos dados na tela 
        private void AtualizarDados()
        {
            // ------atualizando os campos do canvas para exibir os dados do método de seleção do listBox que foi sobreescrito (OnSelectionChanged)-------

            //como o listbox será gerado dinâmicamente, definimos seus atributos e adicionamos como um novo membro filho do canvas
            eDLListBox.Width = 250;
            eDLListBox.Width = 270;
            Canvas.SetTop(eDLListBox, 15);
            Canvas.SetLeft(eDLListBox, 15);

            //Eventos em C# são uma maneira de uma classe fornecer notificações aos usuários da classe quando alguma coisa ocorre com o objeto da classe.
            //O uso mais comum para os eventos são as interfaces de usuário onde normalmente as classes que representam os controles na interface
            //possuem eventos que são notificados quando o usuário realiza uma operação no controle, como clicar um botão.
            //os eventos, utilizam os delegates para fazer a comunicação entre as mensagens da aplicação e os nosso métodos.- Este por sua vez permite que você faça referência
            //a um método, possibilitando a implementação de qualquer método em tempo de execução.

            //selectionChangedEventHandler é um tipo de delegate - Para verificar como o método desse delegate deve ser criado, ctrl+f12 para verificar assinatura do delegate .


            //Adicionando o evento ao listBox (mudança de seleção) (Um evento só pode aparecer a esquerda de um operador de += pois não se pode modificar o comportamento de um evento
            //somente adicionar e remover).

            //delagate
            eDLListBox.SelectionChanged += new SelectionChangedEventHandler(lstCliente_SelectionChanged);

            container.Children.Add(eDLListBox); //Adicionando um novo membro filho ao canvas


            //evento do botão editar 
            btnEditar.Click += new RoutedEventHandler(btnEditar_Click);
        }


        //Metodo para editar as informações



        //método para limpar e atualizar lista
        private void AtualizaListaDeCliente()
        {
            eDLListBox.Items.Clear(); // utiliza-se o método clear para não duplicar os itens da lista tova vez que o método for executado. 


            //criando variável para armazenar os itens da lista do banco
            var clientes = _eDLModel.ClienteSet.ToList();


            //iterando pela lista para adicionar os itens armazenados na variável clientes no campo lstDados
            foreach (var cliente in clientes)
            {
                eDLListBox.Items.Add(cliente);
            }
        }

        //método do evento de mudança de seleção (seguindo a assinutura exigida pelo delegate definida no evento SelectionChangedEventHandler)
        private void lstCliente_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var clienteSelecionado = (Cliente)eDLListBox.SelectedItem;

            txtId.Text = Convert.ToString(clienteSelecionado.Id);
            txtNome.Text = clienteSelecionado.Nome;
            txtEndereco.Text = clienteSelecionado.Endereco;
            txtTelefone.Text = clienteSelecionado.Telefone;
            txtObs.Text = clienteSelecionado.Observacoes;
        }


        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            var clienteAtual =(Cliente)eDLListBox.SelectedItem;
            EdicaoCliente edicaoCliente = new EdicaoCliente(clienteAtual);
            var resultado =  edicaoCliente.ShowDialog().Value; //ShowDialog, diferente de show, não permite que a tela de trás seja maniplada sem que a a janela atual seja encerrada. Ele retorna um valor nulo 

            //usuário clicou em OK
            if (resultado) // valor de verdadeiro ou falso definidos no método de ok e cancelar
            {
                
            }

            //usuário clicou em cancelar
            else
            {

            }
        }

        //Exemplo de evento (click) que se inicia por fonte externa (usuário), que irá executar um código para excluir um cliente. Dispensando a necessidad de se criar uma classe 
        //especializada para esse esse botão. 
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Mensagem de confirmação
            var confirmacao = MessageBox.Show(
                "Vôcê deseja realmente excluir esse cliente?", 
                "Confirma",
                MessageBoxButton.YesNo);
            
            if(confirmacao == MessageBoxResult.Yes)
            {

            }
            else
            {

            }
        }
    }
}
