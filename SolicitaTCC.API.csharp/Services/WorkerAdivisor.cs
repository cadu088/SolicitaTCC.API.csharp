using System.Data;

using System.Data.SqlClient;
using System;
using SolicitaTCC.API.csharp.Models;

namespace SolicitaTCC.API.csharp.Services
{
    public class WorkerAdivisor
    {
        string connectionStringLocalhost = @"Data Source=CARLOSRODRIGUES\SQLEXPRESS;Initial Catalog=DB_AVANCADO;User ID=USERCSHARP;Password=USERCSHARP;Integrated Security=SSPI;TrustServerCertificate=True";
        string connectionString = @"Data Source=201.62.57.93;Initial Catalog=BD042700;User ID=RA042700;Password=042700;TrustServerCertificate=True";

        public List<Workers> getAdvisor(getWorker data)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);

                DataTable dt1 = new DataTable();
                using (SqlDataAdapter adp = new SqlDataAdapter(@"EXEC PR_PEGA_PROFESSOR @ID_PESSOA", conn))
                {
                    adp.SelectCommand.CommandType = CommandType.Text;
                    adp.SelectCommand.Parameters.Add(new SqlParameter("@ID_PESSOA", Convert.ToInt32(data.ID_PESSOA)));
                    

                    adp.Fill(dt1);

                    if (dt1.Rows.Count > 0)
                    {
                        List<Workers> respo = new WorkerFunctions().DataTableListWorkers(dt1);

                        return respo;
                    }
                    else
                    {
                        throw new Exception("Nenhum professor foi encontrado para esse usuario!");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool sendRequest(postRequestWorker data)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);

                DataTable dt1 = new DataTable();
                using (SqlDataAdapter adp = new SqlDataAdapter(@"EXEC PR_SOLICITA_TRABALHO @ID_ALUNO, @ID_PROFESSOR, @NOME, @DESCRICAO", conn))
                {
                    adp.SelectCommand.CommandType = CommandType.Text;
                    adp.SelectCommand.Parameters.Add(new SqlParameter("@ID_ALUNO", Convert.ToInt32(data.ID_ALUNO)));
                    adp.SelectCommand.Parameters.Add(new SqlParameter("@ID_PROFESSOR", Convert.ToInt32(data.ID_PROFESSOR)));
                    adp.SelectCommand.Parameters.Add(new SqlParameter("@NOME", data.NOME));
                    adp.SelectCommand.Parameters.Add(new SqlParameter("@DESCRICAO", data.DESCRICAO));


                    adp.Fill(dt1);

                    if (dt1.Rows.Count > 0)
                    {
                        return true;
                    }
                    else
                    {
                        throw new Exception("Não foi possivel criar a solicitação!");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<RequestWorkers> ListRequest(getRequestsWorker data)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                DataTable dt1 = new DataTable();
                using (SqlDataAdapter adp = new SqlDataAdapter(@"EXEC PR_PEGA_SOLICITACAO @ID_ALUNO, @ID_PROFESSOR", conn))
                {
                    adp.SelectCommand.CommandType = CommandType.Text;
                    adp.SelectCommand.Parameters.Add(new SqlParameter("@ID_ALUNO", Convert.ToInt32(data.ID_ALUNO)));
                    adp.SelectCommand.Parameters.Add(new SqlParameter("@ID_PROFESSOR", Convert.ToInt32(data.ID_PROFESSOR)));


                    adp.Fill(dt1);

                    if (dt1.Rows.Count > 0)
                    {

                        List<RequestWorkers> response = new List<RequestWorkers>();
                        LoginService loginService = new LoginService();

                        foreach (DataRow row in dt1.Rows)
                        {
                            RequestWorkers request = new RequestWorkers();

                            request.ID_SOLICITACAO = Convert.ToInt32(row["ID_SOLICITACAO"]);
                            request.ALUNO = loginService.GetPeople(new Login(row["ID_ALUNO"].ToString()));
                            request.PROFESSOR = loginService.GetPeople(new Login(row["ID_PROFESSOR"].ToString()));
                            request.ID_SITUACAO = Convert.ToInt32(row["ID_SITUACAO"]);
                            request.SITUACAO = row["SITUACAO"].ToString();
                            request.NOME = row["NOME"].ToString();
                            request.DESCRICAO = row["DESCRICAO"].ToString();
                            request.DT_APROVACAO = row["DT_APROVACAO"].ToString();
                            request.DT_REPROVACAO = row["DT_REPROVACAO"].ToString();
                            request.JUSTIFICATIVA = row["JUSTIFICATIVA"].ToString();
                            request.PESSOA_REPROVACAO = row["ID_PESSOA_REPROVACAO"].ToString() != "" ? loginService.GetPeople(new Login(row["ID_PESSOA_REPROVACAO"].ToString())) : null;
                            request.DT_CADASTRO = row["DT_CADASTRO"].ToString();
                            request.FL_ATIVO = Convert.ToInt32(row["FL_ATIVO"]);

                            response.Add(request);
                        }

                        return response;
                    }
                    else
                    {
                        throw new Exception("Nenhuma solcitação para esses parametros!");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
