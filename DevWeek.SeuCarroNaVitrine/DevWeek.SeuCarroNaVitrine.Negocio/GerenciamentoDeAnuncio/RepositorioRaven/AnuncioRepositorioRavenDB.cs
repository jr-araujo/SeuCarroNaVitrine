using DevWeek.SeuCarroNaVitrine.Negocio.GerenciamentoDeAnuncio;
using DevWeek.SeuCarroNaVitrine.Negocio.Utils;

namespace DevWeek.SeuCarroNaVitrine.Negocio.GerenciamentoDeAnunciante
{
    public sealed class AnuncioRepositorioRavenDB
    {
        public AnuncioRepositorioRavenDB()
        {

        }

        public Anuncio ObterPorId(string id)
        {
            using (var session = DocumentStoreHolder.Instance.OpenSession())
            {
                return session.Load<Anuncio>($"anuncios/{id}");
            }
        }

        public void Salvar(Anuncio agregado)
        {
            using (var session = DocumentStoreHolder.Instance.OpenSession())
            {
                session.Store(agregado);
                session.SaveChanges();
            }
        }
    }
}
