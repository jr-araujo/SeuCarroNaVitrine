using DevWeek.SeuCarroNaVitrine.Negocio.Comum;
using DevWeek.SeuCarroNaVitrine.Negocio.GerenciamentoDeAnunciante;
using DevWeek.SeuCarroNaVitrine.Negocio.GerenciamentoDeAnuncio;
using DevWeek.SeuCarroNaVitrine.Negocio.NucleoCompartilhado;
using DevWeek.SeuCarroNaVitrine.Negocio.NucleoCompartilhado.Enums;
using System;

namespace DevWeek.SeuCarroNaVitrine.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //InserirAnunciante();

            InserirAnuncio();

            Console.ReadKey();
        }

        private static void InserirAnuncio()
        {
            //AnuncioRepositorioSQL repo = new AnuncioRepositorioSQL();
            AnuncioRepositorioRavenDB repo = new AnuncioRepositorioRavenDB();

            var veiculoId = new Identidade();
            var detalheDeFabricacao = DetalheDeFabricacao.Novo("Ford", "Focus Titanium 2.0", 2015, 2016);
            var opcionais = ItensOpcicionais.Novo("Ar Condicionado, Vidros Elétricos, Travas Elétricas, Teto Solar, Farois de Neblina, Farois de Milha");
            var detalheDoVeiculo = DetalheDoVeiculo.Novo("ABC-1234", 10000, TipoDoCambio.Automatico,
                TipoDaCarroceria.Hatch, Cor.Branco, TipoDeCombustivel.Flex, 4, 65000);
            var veiculo = new Veiculo(veiculoId, detalheDeFabricacao, opcionais, detalheDoVeiculo);

            var vigencia = Periodo.Novo(DateTime.Now, DateTime.Now.AddDays(10));

            var anuncioId = new Identidade();
            var anuncianteId = new Identidade("86e080bc-e2a4-4328-948a-04db8ee95d2e");

            var anuncio = new Anuncio(anuncioId, anuncianteId, vigencia, veiculo);

            repo.Salvar(anuncio);

            var anuncianteResult = repo.ObterPorId(anuncioId);
                        
            Console.WriteLine(anuncianteResult.Veiculo.Detalhe.Cor);
            Console.WriteLine(anuncianteResult.Veiculo.Detalhe.Combustivel);
            Console.WriteLine(anuncianteResult.Veiculo.Detalhe.Cambio);
            Console.WriteLine(anuncianteResult.Veiculo.Opcionais.Itens);
            
        }

        private static Guid InserirAnunciante()
        {
            //AnuncianteRepositorioSQL repo = new AnuncianteRepositorioSQL();
            AnuncianteRepositorioRavenDB repo = new AnuncianteRepositorioRavenDB();

            var nome = Nome.Novo("José Roberto", "Araújo");
            var endereco = Endereco.Novo("Rua do Paraíso", "Saúde", "São Paulo", "SP", 04123010);
            var email = Email.Novo("jroberto.araujo@gmail.com");
            var contatos = AgendaTelefonica.Nova(Telefone.Novo(11, "123456789"),
                Telefone.Novo(11, "123456789"), Telefone.Novo(11, "123456789"));

            var id = new Identidade();

            var anunciante = new Anunciante(id, nome, endereco, email, contatos);

            repo.Salvar(anunciante);

            var anuncianteResult = repo.ObterPorId(id);

            Console.WriteLine(anuncianteResult.Nome);

            return id.Id;
        }
    }
}
