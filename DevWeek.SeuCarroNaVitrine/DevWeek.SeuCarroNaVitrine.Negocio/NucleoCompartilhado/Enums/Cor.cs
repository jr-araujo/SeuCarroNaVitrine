using DevWeek.SeuCarroNaVitrine.Negocio.Comum;
using Raven.Imports.Newtonsoft.Json;

namespace DevWeek.SeuCarroNaVitrine.Negocio.NucleoCompartilhado.Enums
{
    public class Cor : Enumeration
    {
        public static readonly Cor Branco = new Cor(0, "Branco");
        public static readonly Cor Prata = new Cor(1, "Prata");
        public static readonly Cor Preto = new Cor(2, "Preto");
        public static readonly Cor Vermelho = new Cor(3, "Vermelho");
        public static readonly Cor Azul = new Cor(4, "Azul");
        public static readonly Cor Amarelo = new Cor(5, "Amarelo");
        public static readonly Cor Verde = new Cor(6, "Verde");
        public static readonly Cor Marrom = new Cor(7, "Marrom");

        public Cor()
        {
        }

        [JsonConstructor]
        private Cor(int value, string displayName)
            : base(value, displayName)
        {
        }
    }
}