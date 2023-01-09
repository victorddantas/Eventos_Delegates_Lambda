using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Eventos_Delegates_Lambda
{
    //crinado nosso próprio arguemto de evento
    public class ValidacaoEventArgs : EventArgs
    {
        public string Texto { get; private set; }
        public  bool EhValido { get; set; }

        public ValidacaoEventArgs(string txt)
        {
            Texto = txt;    
            EhValido = true;    
        }

    }
}
