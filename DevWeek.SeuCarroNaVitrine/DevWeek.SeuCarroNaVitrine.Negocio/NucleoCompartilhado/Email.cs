using DevWeek.SeuCarroNaVitrine.Negocio.Comum;
using Raven.Imports.Newtonsoft.Json;
using System;
using System.Text.RegularExpressions;

namespace DevWeek.SeuCarroNaVitrine.Negocio.NucleoCompartilhado
{
    public sealed class Email : ObjetoDeValor<Email>
    {
        public string Valor { get; }

        [JsonConstructor]
        private Email(string valor)
        {
            if (!(ValidarEnderecoDeEmail(valor)))
                throw new InvalidOperationException("Endereço de email inválido");

            Valor = valor;
        }

        public static Email Novo(string email)
        {
            return new Email(email);
        }

        protected override bool EqualsCore(Email other)
        {
            return Valor == other.Valor;
        }

        protected override int GetHashCodeCore()
        {
            return Valor.GetHashCode();
        }

        private bool ValidarEnderecoDeEmail(string emailAddress)
        {
            string regexPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";
            Match matches = Regex.Match(emailAddress, regexPattern);
            return matches.Success;
        }
    }
}
