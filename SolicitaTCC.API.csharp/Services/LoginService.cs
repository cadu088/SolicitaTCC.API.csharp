using System.Data;

using System.Data.SqlClient;
using System;
using SolicitaTCC.API.csharp.Models;

namespace SolicitaTCC.API.csharp.Services
{
    public class LoginService
    {
        string connectionStringLocalhost = @"Data Source=CARLOSRODRIGUES\SQLEXPRESS;Initial Catalog=DB_AVANCADO;User ID=USERCSHARP;Password=USERCSHARP;Integrated Security=SSPI;TrustServerCertificate=True";
        string connectionString = @"Data Source=201.62.57.93;Initial Catalog=BD042700;User ID=RA042700;Password=042700;TrustServerCertificate=True";

        public Login Login(userLogin userLogin)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);

                DataTable dt1 = new DataTable();
                using (SqlDataAdapter adp = new SqlDataAdapter(@"EXEC PR_SR_LOGIN 1, NULL, NULL, NULL, @USER, @PSSW", conn))
                {
                    adp.SelectCommand.CommandType = CommandType.Text;
                    adp.SelectCommand.Parameters.Add(new SqlParameter("@USER", userLogin.EMAIL));
                    adp.SelectCommand.Parameters.Add(new SqlParameter("@PSSW", userLogin.SENHA));
                    adp.Fill(dt1);

                    if (dt1.Rows.Count <= 0)
                    {
                        throw new Exception("E-mail ou senha incorretos!");
                    }
                    else
                    {
                        return new Login(dt1.Rows[0]["ID_PESSOA"].ToString());
                    }
                }
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Login LoginCreate(CreateLogin user)
        {
            try
            {
                if (user.ID_TIPO_PESSOA == 1 && user.USUARIO == null)
                {
                    throw new Exception("USUARIO é obrigatorio para professores");
                }
                if (user.ID_TIPO_PESSOA == 2 && user.RA == null)
                {
                    throw new Exception("RA é obrigatorio para alunos");
                }

                SqlConnection conn = new SqlConnection(connectionString);

                DataTable dt1 = new DataTable();
                using (SqlDataAdapter adp = new SqlDataAdapter(@"EXEC PR_SR_LOGIN 2, NULL, @NOME, @ID_TIPO_PESSOA, @USER, @PSSW, @RA, @USUARIO, @IMG", conn))
                {
                    adp.SelectCommand.CommandType = CommandType.Text;
                    adp.SelectCommand.Parameters.Add(new SqlParameter("@NOME", user.NOME));
                    adp.SelectCommand.Parameters.Add(new SqlParameter("@ID_TIPO_PESSOA", user.ID_TIPO_PESSOA));
                    adp.SelectCommand.Parameters.Add(new SqlParameter("@USER", user.EMAIL));
                    adp.SelectCommand.Parameters.Add(new SqlParameter("@PSSW", user.SENHA));
                    adp.SelectCommand.Parameters.Add(new SqlParameter("@RA", user.ID_TIPO_PESSOA == 1 ? "NULL" : user.RA));
                    adp.SelectCommand.Parameters.Add(new SqlParameter("@USUARIO", user.ID_TIPO_PESSOA == 2 ? "NULL" : user.USUARIO));
                    adp.SelectCommand.Parameters.Add(new SqlParameter("@IMG", user.IMG));
                    adp.Fill(dt1);

                    if (dt1.Rows.Count > 0)
                    {
                        try
                        {
                            return new Login(dt1.Rows[0]["ID_PESSOA"].ToString());

                        }
                        catch (Exception ex)
                        {

                            throw new Exception("E-mail já utilizado!");

                        }
                    }
                    else
                    {
                        throw new Exception("Erro ao gerar cadastro!");
                    }


                    

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Pessoa GetPeople(Login user)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);

                DataTable dt1 = new DataTable();
                using (SqlDataAdapter adp = new SqlDataAdapter(@"EXEC PR_SR_LOGIN 5, @ID_PESSOA", conn))
                {
                    adp.SelectCommand.CommandType = CommandType.Text;
                    adp.SelectCommand.Parameters.Add(new SqlParameter("@ID_PESSOA", Convert.ToInt32(user.ID_PESSOA)));

                    adp.Fill(dt1);

                    if (dt1.Rows.Count == 1)
                    {
                        List<Pessoa> response = new Functions().DataTableToPessoaList(dt1);
                        return response[0];
                    }
                    else
                    {
                        throw new Exception("Nenhum usuario foi encontrado!");
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
