using DevWeek.SeuCarroNaVitrine.Negocio.Comum;
using Raven.Imports.Newtonsoft.Json;
using System;

namespace DevWeek.SeuCarroNaVitrine.Negocio.NucleoCompartilhado
{
    public sealed class AgendaTelefonica : ObjetoDeValor<AgendaTelefonica>
    {
        public Telefone TelefonePrincipal { get; }
        public Telefone TelefoneComercial { get; }
        public Telefone Celular { get; }

        [JsonConstructor]
        private AgendaTelefonica(Telefone telefonePrincipal,
            Telefone telefoneComercial, Telefone celular)
        {
            if (telefonePrincipal == null)
                throw new InvalidOperationException("O telefone principal é obrigatório");

            if (telefoneComercial == null)
                throw new InvalidOperationException("O telefone comercial é obrigatório");

            if (celular == null)
                throw new InvalidOperationException("O celular é obrigatório");

            TelefonePrincipal = telefonePrincipal;
            TelefoneComercial = telefoneComercial;
            Celular = celular;
        }

        public static AgendaTelefonica Nova(Telefone telefonePrincipal,
            Telefone telefoneComercial, Telefone celular)
        {
            return new AgendaTelefonica(telefonePrincipal, telefoneComercial, celular);
        }

        protected override bool EqualsCore(AgendaTelefonica other)
        {
            return TelefonePrincipal == other.TelefonePrincipal
                    && TelefoneComercial == other.TelefoneComercial
                    && Celular == other.Celular;
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                int hashCode = TelefonePrincipal.GetHashCode();
                hashCode = (hashCode * 397) ^ TelefoneComercial.GetHashCode();
                hashCode = (hashCode * 397) ^ Celular.GetHashCode();

                return hashCode;
            }
        }
    }
}
