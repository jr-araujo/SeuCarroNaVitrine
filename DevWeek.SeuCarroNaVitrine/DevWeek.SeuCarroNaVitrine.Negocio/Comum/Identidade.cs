using System;

namespace DevWeek.SeuCarroNaVitrine.Negocio.Comum
{
    public sealed class Identidade : ObjetoDeValor<Identidade>
    {
        public Guid Id { get; }

        public Identidade()
        {
            Id = Guid.NewGuid();
        }

        public Identidade(Guid id)
        {
            Id = id;
        }

        public Identidade(string id)
        {
            Id = Guid.Parse(id);
        }
        
        protected override bool EqualsCore(Identidade other)
        {
            return Id == other.Id;
        }

        protected override int GetHashCodeCore()
        {
            return Id.GetHashCode();
        }

        public static implicit operator string(Identidade source)
        {
            return source.Id.ToString();
        }

        public static implicit operator Identidade(string source)
        {
            return new Identidade(source);
        }

        public override string ToString()
        {
            return Id.ToString();
        }
    }
}
