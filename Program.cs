using System;
using System.Threading.Tasks;
using Refit;

namespace api1
{
    class MainClass
    {
        static async Task Main(string[] args)
        {
            try
            {
                var cepClient = RestService.For<ICepApiService>("http://viacep.com.br");
                Console.WriteLine("Informe seu Cep:");

                string cepInformado = Console.ReadLine().ToString();
                Console.WriteLine("Consultando informações do CEP: " + cepInformado);

                var address = await cepClient.GetAddressAsync(cepInformado);

                Console.Write($"\nLogradouro:{address.Logradouro},\nBairro:{address.Bairro},\nCidade:{address.Localidade}");
                Console.ReadKey();

            } catch (Exception e) 
            {
                Console.WriteLine("Erro na consulta de cep: " + e.Message);
            }
            
        }
    }
}
