using System;
using DevWeek.SeuCarroNaVitrine.Negocio.Comum;
using DevWeek.SeuCarroNaVitrine.Negocio.NucleoCompartilhado.Enums;
using Raven.Imports.Newtonsoft.Json;

namespace DevWeek.SeuCarroNaVitrine.Negocio.NucleoCompartilhado
{
    public sealed class DetalheDoVeiculo : ObjetoDeValor<DetalheDoVeiculo>
    {
        public string Placa { get; }
        public int Kilometragem { get; }
        public int Portas { get; }
        public TipoDoCambio Cambio { get; }
        public TipoDaCarroceria Carroceria { get; }
        public Cor Cor { get; }
        public TipoDeCombustivel Combustivel { get; }
        public decimal Preco { get; }

        [JsonConstructor]
        private DetalheDoVeiculo(string placa, int kilometragem,
            TipoDoCambio cambio, TipoDaCarroceria carroceria, Cor cor,
            TipoDeCombustivel combustivel, int portas, decimal preco)
        {
            if (string.IsNullOrWhiteSpace(placa))
                throw new InvalidOperationException("O Final da Placa não pode ser menor que '0'");

            if (kilometragem < 0)
                throw new InvalidOperationException("A Kilometragem não pode ser menor que '0'");

            if (portas < 2 || portas > 4)
                throw new InvalidOperationException("A quantidade de portas está inválida");

            if (preco <= 0)
                throw new InvalidOperationException("O preço deve ser maior que '0'");

            Placa = placa;
            Kilometragem = kilometragem;
            Cambio = cambio;
            Carroceria = carroceria;
            Cor = cor;
            Combustivel = combustivel;
            Preco = preco;
            Portas = portas;
        }

        public static DetalheDoVeiculo Novo(string placa, int kilometragem,
            TipoDoCambio cambio, TipoDaCarroceria carroceria, Cor cor,
            TipoDeCombustivel combustivel, int portas, decimal preco)
        {
            return new DetalheDoVeiculo(placa, kilometragem, cambio, carroceria,
                cor, combustivel, portas, preco);
        }

        protected override bool EqualsCore(DetalheDoVeiculo other)
        {
            return Placa == other.Placa
                && Kilometragem == other.Kilometragem
                && Portas == other.Portas
                && Cambio == other.Cambio
                && Carroceria == other.Carroceria
                && Cor == other.Cor;
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                int hashCode = Placa.GetHashCode();
                hashCode = (hashCode * 397) ^ Kilometragem.GetHashCode();
                hashCode = (hashCode * 397) ^ Portas.GetHashCode();
                hashCode = (hashCode * 397) ^ Cambio.GetHashCode();
                hashCode = (hashCode * 397) ^ Carroceria.GetHashCode();
                hashCode = (hashCode * 397) ^ Cor.GetHashCode();

                return hashCode;
            }
        }
    }
}
