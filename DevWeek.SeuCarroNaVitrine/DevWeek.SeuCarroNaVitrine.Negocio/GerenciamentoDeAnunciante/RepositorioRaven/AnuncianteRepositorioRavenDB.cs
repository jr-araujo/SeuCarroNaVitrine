using DevWeek.SeuCarroNaVitrine.Negocio.GerenciamentoDeAnunciante.RepositorioRaven;
using DevWeek.SeuCarroNaVitrine.Negocio.Utils;

namespace DevWeek.SeuCarroNaVitrine.Negocio.GerenciamentoDeAnunciante
{
    public sealed class AnuncianteRepositorioRavenDB
    {
        public AnuncianteRepositorioRavenDB()
        {

        }

        public Anunciante ObterPorId(string id)
        {
            using (var session = DocumentStoreHolder.Instance.OpenSession())
            {
                return session.Load<Anunciante>($"anunciantes/{id}");
            }
        }

        public void Salvar(Anunciante agregado)
        {
            using (var session = DocumentStoreHolder.Instance.OpenSession())
            {
                session.Store(agregado);
                session.SaveChanges();
            }
        }
    }
}
