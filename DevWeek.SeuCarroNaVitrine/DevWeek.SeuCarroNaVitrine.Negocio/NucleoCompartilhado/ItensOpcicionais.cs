using DevWeek.SeuCarroNaVitrine.Negocio.Comum;
using Raven.Imports.Newtonsoft.Json;
using System.Collections.Generic;

namespace DevWeek.SeuCarroNaVitrine.Negocio.NucleoCompartilhado
{
    public sealed class ItensOpcicionais : ObjetoDeValor<ItensOpcicionais>
    {
        private List<string> _opcionais;

        public string Itens { get { return UnificarItens(_opcionais); } }

        [JsonConstructor]
        private ItensOpcicionais(string itens)
        {
            _opcionais = new List<string>();

            _opcionais.AddRange(itens.Split(','));
        }

        public static ItensOpcicionais Novo(string item)
        {
            return new ItensOpcicionais(item);
        }
        
        private string UnificarItens(List<string> opcionais)
        {
            return string.Join(",", _opcionais);
        }

        protected override bool EqualsCore(ItensOpcicionais other)
        {
            return Itens == other.Itens;
        }

        protected override int GetHashCodeCore()
        {
            return Itens.GetHashCode();
        }
    }
}
