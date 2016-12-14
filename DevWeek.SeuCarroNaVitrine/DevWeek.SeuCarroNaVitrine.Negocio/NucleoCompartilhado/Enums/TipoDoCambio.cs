using DevWeek.SeuCarroNaVitrine.Negocio.Comum;
using Raven.Imports.Newtonsoft.Json;

namespace DevWeek.SeuCarroNaVitrine.Negocio.NucleoCompartilhado.Enums
{
    public class TipoDoCambio : Enumeration
    {
        public static readonly TipoDoCambio Manual = new TipoDoCambio(0, "Manual");
        public static readonly TipoDoCambio Automatico = new TipoDoCambio(1, "Automático");
        public static readonly TipoDoCambio AutomaticoSequencial = new TipoDoCambio(2, "Automático Sequencial");
        public static readonly TipoDoCambio SemiAutomatico = new TipoDoCambio(3, "Semi-automático");

        public TipoDoCambio()
        {
        }

        [JsonConstructor]
        private TipoDoCambio(int value, string displayName)
            : base(value, displayName)
        {
        }
    }
}