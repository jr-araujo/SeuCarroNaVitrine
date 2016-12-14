using Dapper;
using DevWeek.SeuCarroNaVitrine.Negocio.Comum;
using DevWeek.SeuCarroNaVitrine.Negocio.NucleoCompartilhado;
using System;
using System.Data.SqlClient;

namespace DevWeek.SeuCarroNaVitrine.Negocio.GerenciamentoDeAnunciante
{
    public sealed class AnuncianteRepositorioSQL
    {
        public string StringDeConexao => "Server=NB-JRA\\MSSQLEXPRESS;Database=SeuCarroNaVitrine;Trusted_Connection=True;";

        public AnuncianteRepositorioSQL()
        {

        }

        public Anunciante ObterPorId(Identidade id)
        {
            using (SqlConnection cn = new SqlConnection(StringDeConexao))
            {
                string select =
@"
    SELECT [AnuncianteId]
      ,[Nome]
      ,[Sobrenome]
      ,[Logradouro]
      ,[Bairro]
      ,[Cidade]
      ,[Estado]
      ,[Cep]
      ,[Email]
      ,[DDDTelefonePrincipal]
      ,[TelefonePrincipal]
      ,[DDDTelefoneComercial]
      ,[TelefoneComercial]
      ,[DDDCelular]
      ,[Celular]
    FROM [dbo].[Anunciante]
    WHERE AnuncianteId = @id
";

                var result = cn.QueryFirstOrDefault(select, new { id = id.ToString() });

                if (result == null)
                    return null;

                var nome = Nome.Novo(result.Nome, result.Sobrenome);

                var endereco = Endereco.Novo(result.Logradouro, result.Bairro,
                    result.Cidade, result.Estado, result.Cep);

                var email = Email.Novo(result.Email);

                var contatos = AgendaTelefonica.Nova(
                    Telefone.Novo(result.DDDTelefonePrincipal, result.TelefonePrincipal),
                    Telefone.Novo(result.DDDTelefoneComercial, result.TelefoneComercial),
                    Telefone.Novo(result.DDDCelular, result.Celular));

                Anunciante anunciante = new Anunciante(new Identidade(Guid.Parse(result.AnuncianteId.ToString())),
                    nome, endereco, email, contatos);

                return anunciante;
            }
        }

        public void Salvar(Anunciante agregado)
        {
            using (SqlConnection cn = new SqlConnection(StringDeConexao))
            {
                string insert =
@"
    INSERT INTO ANUNCIANTE([AnuncianteId], [Nome],[Sobrenome],[Logradouro],[Bairro],[Cidade],[Estado]
        ,[Cep],[Email],[DDDTelefonePrincipal],[TelefonePrincipal],[DDDTelefoneComercial]
        ,[TelefoneComercial],[DDDCelular],[Celular])
    VALUES(@anuncianteId, @nome, @sobreNome, @logradouro, @bairro, @cidade, @estado, @cep, @email,
           @dddTelefonePrincipal, @telefonePrincipal, @dddTelefoneComercial,
           @telefoneComercial, @dddCelular, @celular)
";

                var parametros = new
                {
                    anuncianteId = agregado.Id.ToString(),
                    nome = agregado.Nome.PrimeiroNome,
                    sobreNome = agregado.Nome.Sobrenome,
                    logradouro = agregado.Endereco.Logradouro,
                    bairro = agregado.Endereco.Bairro,
                    cidade = agregado.Endereco.Cidade,
                    estado = agregado.Endereco.Estado,
                    cep = agregado.Endereco.Cep,
                    email = agregado.Email.Valor,
                    dddTelefonePrincipal = agregado.AgendaTelefonica.TelefonePrincipal.DDD,
                    telefonePrincipal = agregado.AgendaTelefonica.TelefonePrincipal.Numero,
                    dddTelefoneComercial = agregado.AgendaTelefonica.TelefoneComercial.DDD,
                    telefoneComercial = agregado.AgendaTelefonica.TelefoneComercial.Numero,
                    dddCelular = agregado.AgendaTelefonica.Celular.DDD,
                    celular = agregado.AgendaTelefonica.Celular.Numero
                };

                cn.Open();
                cn.Execute(insert, parametros);
                cn.Close();
            }
        }
    }
}
