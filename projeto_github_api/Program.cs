using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Text;

namespace GitHub_Api // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string user = "";

            Console.WriteLine("Algoritmo que procura dados no github!");
            Console.Write("Por favor insira o seu usuário: ");
            user = Console.ReadLine();

            RestClient client = new RestClient($"https://api.github.com/users/{user}");
            RestRequest request = new RestRequest(Method.GET);

            IRestResponse response = client.Execute(request);

            Console.WriteLine();

            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                Console.WriteLine($"Ocorreu um problema na sua requisição!\n\n{response.Content}\n\n{response.StatusCode}\n\n{response.ContentLength}");
            }
            else
            {
                DadosRetorno dadosRetorno = new JsonDeserializer().Deserialize<DadosRetorno>(response);
                
                var sb = new System.Text.StringBuilder();

                if (dadosRetorno.login is null)
                {
                    Console.WriteLine("A api retornou um valor, mas não os dados desejados!: " + response.Content);
                }
                else
                {
                    sb.AppendLine($"Login: {dadosRetorno.login}");
                    sb.AppendLine($"Avatar Link: {dadosRetorno.avatar_url}");
                    sb.AppendLine($"Repositórios Link: {dadosRetorno.repos_url}");
                    sb.AppendLine($"Adm do Site: {dadosRetorno.site_admin}");
                    sb.AppendLine($"Local: {dadosRetorno.location}");
                    sb.AppendLine($"Bio: {dadosRetorno.bio}");
                    sb.AppendLine($"Quantidade de Seguidores: {dadosRetorno.followers}");
                    sb.AppendLine($"Seguindo: {dadosRetorno.following}");
                    sb.AppendLine($"Criado em: {dadosRetorno.ArrumarData(dadosRetorno.created_at)}");
                    sb.AppendLine($"Atualizado em: {dadosRetorno.ArrumarData(dadosRetorno.updated_at)}");

                    Console.WriteLine(sb);
                }


            }
        }
    }
}