using DevWeek.SeuCarroNaVitrine.Negocio.Comum;
using Raven.Imports.Newtonsoft.Json;
using System;

namespace DevWeek.SeuCarroNaVitrine.Negocio.GerenciamentoDeAnunciante.RepositorioRaven
{
    internal class AnuncianteIdJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, $"anunciantes/{value}");
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            var original = (string)reader.Value;
            return (Identidade)original.Substring(
                original.IndexOf("/", StringComparison.Ordinal) + 1);
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Identidade);
        }
    }
}
