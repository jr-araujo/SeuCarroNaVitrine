using DevWeek.SeuCarroNaVitrine.Negocio.GerenciamentoDeAnunciante.RepositorioRaven;
using Raven.Client.Document;
using Raven.Imports.Newtonsoft.Json;

namespace DevWeek.SeuCarroNaVitrine.Negocio.Utils
{
    /// <summary>
    /// Fonte do Código: https://github.com/ElemarJR/cqrses-demo
    /// </summary>
    class DocumentStoreHolder
    {
        static DocumentStoreHolder()
        {
            Instance = new DocumentStore
            {
                Url = "http://localhost:8080/",
                DefaultDatabase = "SeuCarroNaVitrineDb",
                Conventions =
                {
                    CustomizeJsonSerializer =
                        serializer =>
                        {
                            serializer.Converters.Add(new AnuncianteIdJsonConverter());
                            serializer.Converters.Add(new AnuncioIdJsonConverter());
                        }
                }
            };

            var defaultImpl = Instance.Conventions.FindTypeTagName;

            Instance.Conventions.IdentityTypeConvertors.Add(new AnuncianteIdConverter());
            Instance.Conventions.IdentityTypeConvertors.Add(new AnuncioIdConverter());

            Serializer = Instance.Conventions.CreateSerializer();
            Serializer.TypeNameHandling = TypeNameHandling.All;

            Instance.Initialize();
        }

        public static DocumentStore Instance { get; }

        public static JsonSerializer Serializer { get; }
    }
}
