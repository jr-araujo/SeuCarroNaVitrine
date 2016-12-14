using DevWeek.SeuCarroNaVitrine.Negocio.Comum;
using DevWeek.SeuCarroNaVitrine.Negocio.NucleoCompartilhado;
using System;

namespace DevWeek.SeuCarroNaVitrine.Negocio.GerenciamentoDeAnuncio
{
    public class Proposta : Entidade
    {
        public Identidade AnuncioId { get; }
        public Nome Nome { get; }
        public Email Email { get; }
        public Telefone Telefone { get; }
        public DateTime DataDeEnvio { get; }
        public decimal Valor { get; }
        public string Mensagem { get; }

        public Proposta(Identidade id, Identidade anuncioId, Nome nome, Email email, Telefone telefone,
            decimal valor, string mensagem) : base(id)
        {
            if (valor == default(decimal))
                throw new InvalidOperationException("O Valor da Proposta é obrigatório");

            if (string.IsNullOrWhiteSpace(mensagem))
                throw new InvalidOperationException("Informe algum detalhe na proposta");

            if (nome == null)
                throw new InvalidOperationException("O Nome é obrigatório");

            if (telefone == null)
                throw new InvalidOperationException("O Telefone é obrigatório");

            if (email == null)
                throw new InvalidOperationException("O Email é obrigatório");

            AnuncioId = anuncioId;
            DataDeEnvio = DateTime.Now;
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Valor = valor;
            Mensagem = mensagem;
        }
    }
}