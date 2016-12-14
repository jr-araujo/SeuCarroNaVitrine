using DevWeek.SeuCarroNaVitrine.Negocio.Comum;
using Raven.Client.Converters;
using System;

namespace DevWeek.SeuCarroNaVitrine.Negocio.GerenciamentoDeAnunciante.RepositorioRaven
{
    internal class AnuncioIdConverter : ITypeConverter
    {
        public bool CanConvertFrom(Type sourceType)
        {
            return sourceType == typeof(Identidade);
        }

        public string ConvertFrom(string tag, object value, bool allowNull)
        {
            return $"{tag}{value}";
        }

        public object ConvertTo(string value)
        {
            return value.IndexOf("/", StringComparison.Ordinal) != -1
                ? (Identidade)value.Split('/')[1]
                : (Identidade)value;
        }
    }
}
