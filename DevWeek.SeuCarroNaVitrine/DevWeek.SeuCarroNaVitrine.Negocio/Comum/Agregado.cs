using DevWeek.SeuCarroNaVitrine.Negocio.NucleoCompartilhado;
using System;

namespace DevWeek.SeuCarroNaVitrine.Negocio.Comum
{
    public class Agregado : Entidade
    {
        public Agregado(Identidade id) : base(id)
        {
            //A gestão de eventos do agregado vai aqui...
        }
    }
}
