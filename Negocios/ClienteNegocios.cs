using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcessoBancoDados;
using ObejtoTransferencia;
using System.Data;


namespace Negocios
{
    public class ClienteNegocios
    {
        AcessoDadosSqlServer acessoDadosSqlServer = new AcessoDadosSqlServer();
        public string Inserir(Cliente cliente)
        {
            try
            {
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@nome", cliente.nome);
                acessoDadosSqlServer.AdicionarParametros("@DataNascimento", cliente.DataNascimento);
                acessoDadosSqlServer.AdicionarParametros("@Sexo", cliente.Sexo);
                acessoDadosSqlServer.AdicionarParametros("@LimiteCompra", cliente.LimiteCompra);
                string IdCliente = acessoDadosSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspClienteInserir").ToString();
                return IdCliente;

            }
            catch (Exception exception)
            {
                return exception.Message;
            }

        }
        public string Alterar(Cliente cliente)
        {
            try
            {

                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@IdCliente", cliente.IdCliente);
                acessoDadosSqlServer.AdicionarParametros("@nome", cliente.nome);
                acessoDadosSqlServer.AdicionarParametros("@Sexo", cliente.Sexo);
                acessoDadosSqlServer.AdicionarParametros("@DataNascimento", cliente.DataNascimento);
                acessoDadosSqlServer.AdicionarParametros("@LimiteCompra", cliente.LimiteCompra);
                string IdCliente = acessoDadosSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspClienteAlter").ToString();
                return IdCliente;
            }

            catch (Exception exeption)
            {
                return exeption.Message;
            }
        }
        public string Excluir(Cliente cliente)
        {
            try {
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@IdCliente", cliente.IdCliente);
                string IdCliente = acessoDadosSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspClienteExcluir").ToString();
                return IdCliente;
            }
            catch (Exception ex) {
                return ex.Message;
            }
        }
        public ClienteColecao ConsultarPorNome(string nome) {
            try
            {
                ClienteColecao clientecolecao = new ClienteColecao();
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@nome", nome);
                DataTable dataTableCliente = acessoDadosSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspClienteConsultarPorNome");
                foreach (DataRow linha in dataTableCliente.Rows)
                {
                    Cliente cliente = new Cliente();

                    cliente.IdCliente = Convert.ToInt32(linha["IdCliente"]);
                    cliente.nome = Convert.ToString(linha["nome"]);
                    cliente.DataNascimento = Convert.ToDateTime(linha["DataNascimento"]);
                    cliente.Sexo = Convert.ToBoolean(linha["Sexo"]);
                    cliente.LimiteCompra = Convert.ToDecimal(linha["LimiteCompra"]);

                    clientecolecao.Add(cliente);
                }
                return clientecolecao;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possivel consultar o cliente por nome. Detalhes:" + ex.Message);
            }
        }
        public ClienteColecao ConsultarPorId(int IdCliente)
        {
            try
            {

                ClienteColecao clienteColecao = new ClienteColecao();
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@IdCliente", IdCliente);

                DataTable dataTableCliente = acessoDadosSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspClienteConsultarPorId");

                foreach (DataRow dataRowLinha in dataTableCliente.Rows)
                {
                    Cliente clienteEncontrado = new Cliente();

                    clienteEncontrado.IdCliente = Convert.ToInt32(dataRowLinha["IdCliente"]);
                    clienteEncontrado.nome = Convert.ToString(dataRowLinha["nome"]);
                    clienteEncontrado.DataNascimento = Convert.ToDateTime(dataRowLinha["DataNascimento"]);
                    clienteEncontrado.Sexo = Convert.ToBoolean(dataRowLinha["Sexo"]);
                    clienteEncontrado.LimiteCompra = Convert.ToDecimal(dataRowLinha["LimiteCompra"]);
                    clienteColecao.Add(clienteEncontrado);
                }

                return clienteColecao;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possivel consultar o cliente por código. Detalhes:" + ex.Message);
            }
        }
    }

}
