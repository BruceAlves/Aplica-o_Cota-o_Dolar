using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Aplicação_Cotação_Dolar
{
    internal class Program
    {
        static void Main(string[] args)
        {

            HttpClient cliente = new HttpClient();

            HttpResponseMessage respostaHttp;

            Console.WriteLine("Digite a Data para cotação MM-DD-YYYY");
            string data = Console.ReadLine();

            respostaHttp = cliente.GetAsync($"https://olinda.bcb.gov.br/olinda/servico/PTAX/versao/v1/odata/CotacaoDolarDia(dataCotacao=@dataCotacao)?@dataCotacao=%27{data}%27&$top=100&$format=json").Result;

            string respostaString = respostaHttp.Content.ReadAsStringAsync().Result;

            CotacaoDolar  resposta = JsonConvert.DeserializeObject<CotacaoDolar>(respostaString);

            Console.WriteLine($"Cotação Compra:{resposta.value[0].cotacaoCompra}");
            Console.WriteLine($"Cotação Venda:{resposta.value[0].cotacaoVenda}");
            Console.WriteLine($"Data da Cotação:{resposta.value[0].dataHoraCotacao}");

            Console.ReadKey();
        }
    }
}
