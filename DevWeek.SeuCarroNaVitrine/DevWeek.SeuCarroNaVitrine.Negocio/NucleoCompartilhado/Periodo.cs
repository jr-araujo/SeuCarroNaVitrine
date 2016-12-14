using DevWeek.SeuCarroNaVitrine.Negocio.Comum;
using Raven.Imports.Newtonsoft.Json;
using System;

namespace DevWeek.SeuCarroNaVitrine.Negocio.NucleoCompartilhado
{
    public sealed class Periodo : ObjetoDeValor<Periodo>
    {
        public DateTime Inicial { get; }
        public DateTime Final { get; }

        [JsonConstructor]
        private Periodo(DateTime inicial, DateTime final)
        {
            if (inicial == DateTime.MinValue)
                throw new InvalidOperationException("O Período Inicial é obrigatório");

            if (final == DateTime.MinValue)
                throw new InvalidOperationException("O Período Final é obrigatório");

            if (inicial > final)
                throw new InvalidOperationException("O Período Inicial não pode ser maior que o Período Final");

            Inicial = inicial;
            Final = final;
        }

        public static Periodo Novo(DateTime inicial, DateTime final)
        {
            return new Periodo(inicial, final);
        }

        protected override bool EqualsCore(Periodo other)
        {
            return Inicial == other.Inicial
                && Final == other.Final;
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                int hashCode = Inicial.GetHashCode();
                hashCode = (hashCode * 397) ^ Final.GetHashCode();

                return hashCode;
            }
        }
    }
}
