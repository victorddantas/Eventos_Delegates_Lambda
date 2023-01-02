using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos_Delegates_Lambda.DAL
{
     // classes parciais são uma forma para simplificar o desnvolvimento, não sendo necessário editar uma classe já criada, ao invés disso se cria uma nova 
     // que se torna parte da classe já existente.  As classes parciais são geralmente usadas com códigos gerados por alguma ferramenta, de forma a permitir
     // que o programador insira código dentro dessa classe gerada, sem ter de alterar o arquivo de código gerado. Quando o código é compilado todas as classes
     //parciais são agrupadas.

    public partial class Cliente
    {
        public override string ToString() => $"{Id} - {Nome}".Trim(); //Sobreescrevendo o método toString onde ele retorna uma interpolação de strings com o ID e o nome 
                                                                      //pois o retorno das informações do método tolist() estava retornando o Nome completo da classe ao invès da
                                                                      //das informções contidas no banco. (Adicionando um objeto complexo na variável cliente no foreach)
                                                                      //o método Trim remove espaços vazios de uma string
    }

}
