using System.Data;

using System.Data.SqlClient;
using System;
using SolicitaTCC.API.csharp.Models;

namespace SolicitaTCC.API.csharp.Services
{
    public class MesageriaService
    {
        string connectionStringLocalhost = @"Data Source=CARLOSRODRIGUES\SQLEXPRESS;Initial Catalog=DB_AVANCADO;User ID=USERCSHARP;Password=USERCSHARP;Integrated Security=SSPI;TrustServerCertificate=True";
        string connectionString = @"Data Source=201.62.57.93;Initial Catalog=BD042700;User ID=RA042700;Password=042700;TrustServerCertificate=True";

        public Mensagens SendMsg(SendMensagem mensagem)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);

                DataTable dt1 = new DataTable();
                using (SqlDataAdapter adp = new SqlDataAdapter(@"EXEC PR_ENVIO_MENSAGEM @EMISSOR, @RECEPTOR, @TIPO, @MENSAGEM, @ID_ARQUIVO", conn))
                {
                    adp.SelectCommand.CommandType = CommandType.Text;
                    adp.SelectCommand.Parameters.Add(new SqlParameter("@EMISSOR", Convert.ToInt32(mensagem.ID_EMISSOR)));
                    adp.SelectCommand.Parameters.Add(new SqlParameter("@RECEPTOR", Convert.ToInt32(mensagem.ID_RECEPTOR)));
                    adp.SelectCommand.Parameters.Add(new SqlParameter("@TIPO", Convert.ToInt32(mensagem.TIPO == "TEXTO" ? 1 : 2)));
                    adp.SelectCommand.Parameters.Add(new SqlParameter("@MENSAGEM", mensagem.MENSAGEM));
                    adp.SelectCommand.Parameters.Add(new SqlParameter("@ID_ARQUIVO", Convert.ToInt32(mensagem.ID_ARQUIVO)));

                    adp.Fill(dt1);

                    if (dt1.Rows.Count > 0)
                    {
                        List<Mensagem> respo = new MensageriaFunctions().DataTableToMensagemList(dt1);
                        Mensagens Mensagens = this.GetMensagensMensageria(Convert.ToInt32(dt1.Rows[0]["ID_MENSAGERIA"].ToString()));

                        Mensagens response = new Mensagens();
                        return response;
                    }
                    else
                    {
                        throw new Exception("Nenhuma area para esse usuario foi encontrada!");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Mensagens GetMensagensMensageria(int ID_MENSAGERIA)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);

                DataTable dt1 = new DataTable();
                using (SqlDataAdapter adp = new SqlDataAdapter(@"EXEC PR_PEGA_MENSAGEM @ID_MENSAGERIA", conn))
                {
                    adp.SelectCommand.CommandType = CommandType.Text;
                    adp.SelectCommand.Parameters.Add(new SqlParameter("@ID_MENSAGERIA", ID_MENSAGERIA));

                    adp.Fill(dt1);

                    if (dt1.Rows.Count > 0)
                    {
                        Mensagens response = new MensageriaFunctions().DataTableMensagensMensageriaList(dt1);
                        return response;
                    }
                    else
                    {
                        throw new Exception("Nenhuma mensagem econtrada! GetMensagensMensageria()");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Mensagens> getChat(ChatPeople data)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);

                DataTable dt1 = new DataTable();
                using (SqlDataAdapter adp = new SqlDataAdapter(@"EXEC PR_PEGA_MENSAGERIAS @EMISSOR, @RECEPTOR", conn))
                {
                    adp.SelectCommand.CommandType = CommandType.Text;
                    adp.SelectCommand.Parameters.Add(new SqlParameter("@EMISSOR", data.ID_EMISSOR));
                    adp.SelectCommand.Parameters.Add(new SqlParameter("@RECEPTOR", data.ID_RECEPTOR));
                    adp.Fill(dt1);

                    List<Mensagens> msgs = new List<Mensagens>();

                    foreach (DataRow row in dt1.Rows)
                    {
                        Mensagens msg = this.GetMensagensMensageria(Convert.ToInt32(row["ID_MENSAGERIA"]));
                        msgs.Add(msg);
                    }

                    return msgs;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
