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
            btnOk.Click += new RoutedEventHandler(btnOk_Click);
            btnCancelar.Click += new RoutedEventHandler(btnCancelar_Click);
            btnOk.Click += new RoutedEventHandler(Fechar);
            btnCancelar.Click += new RoutedEventHandler(Fechar);
        }

        private void btnOk_Click(object sender, EventArgs e) => DialogResult = true; //definindo valor do click
            //Close();
        
        private void btnCancelar_Click(object sender, EventArgs e) => DialogResult = false;
            //Close();
        

        //subistitui o Close()
        private void Fechar(object sender, EventArgs e) => Close();
      
    }
}
