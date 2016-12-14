using DevWeek.SeuCarroNaVitrine.Negocio.Comum;
using DevWeek.SeuCarroNaVitrine.Negocio.NucleoCompartilhado;
using System;

namespace DevWeek.SeuCarroNaVitrine.Negocio.GerenciamentoDeAnunciante
{
    public class Anunciante : Agregado
    {
        public Nome Nome { get; }
        public Endereco Endereco { get; private set; }
        public Email Email { get; private set; }
        public AgendaTelefonica AgendaTelefonica { get; }
        
        public Anunciante(Identidade id, Nome nome, Endereco endereco, Email email,
            AgendaTelefonica agendaTelefonica): base(id)
        {
            if (nome == null)
                throw new InvalidOperationException("O Nome do proprietário é obrigatório");

            if (endereco == null)
                throw new InvalidOperationException("O Endereço do proprietário é obrigatório");

            if (email == null)
                throw new InvalidOperationException("O Email do proprietário é obrigatório");

            if (agendaTelefonica == null)
                throw new InvalidOperationException("A Agenda Telefônica do proprietário é obrigatória");

            Nome = nome;
            Email = email;
            Endereco = endereco;
            AgendaTelefonica = agendaTelefonica;
        }

        public void AlterarEmail(Email novoEmail)
        {
            Email = novoEmail;
        }
    }
}