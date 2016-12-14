using DevWeek.SeuCarroNaVitrine.Negocio.Comum;
using Raven.Imports.Newtonsoft.Json;

namespace DevWeek.SeuCarroNaVitrine.Negocio.NucleoCompartilhado.Enums
{
    public class StatusPublicacao : Enumeration
    {
        public static readonly StatusPublicacao Anunciado = new StatusPublicacao(0, "Anunciado");
        public static readonly StatusPublicacao Disponivel = new StatusPublicacao(1, "Disponível");
        public static readonly StatusPublicacao NaoVistoriado = new StatusPublicacao(2, "Não Vistoriado");

        public StatusPublicacao()
        {
        }

        [JsonConstructor]
        private StatusPublicacao(int value, string displayName)
            : base(value, displayName)
        {
        }
    }
}