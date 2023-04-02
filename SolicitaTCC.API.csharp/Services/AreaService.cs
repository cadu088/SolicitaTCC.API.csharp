using System.Data;

using System.Data.SqlClient;
using System;
using SolicitaTCC.API.csharp.Models;

namespace SolicitaTCC.API.csharp.Services
{
    public class AreaService
    {
        string connectionStringLocalhost = @"Data Source=CARLOSRODRIGUES\SQLEXPRESS;Initial Catalog=DB_AVANCADO;User ID=USERCSHARP;Password=USERCSHARP;Integrated Security=SSPI;TrustServerCertificate=True";
        string connectionString = @"Data Source=201.62.57.93;Initial Catalog=BD042700;User ID=RA042700;Password=042700;TrustServerCertificate=True";

        public List<Area> GetAreas()
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);

                DataTable dt1 = new DataTable();
                using (SqlDataAdapter adp = new SqlDataAdapter(@"EXEC PR_SR_AREA_ATUACAO 1", conn))
                {
                    adp.SelectCommand.CommandType = CommandType.Text;

                    adp.Fill(dt1);

                    if (dt1.Rows.Count > 0)
                    {
                        List<Area> response = new FunctionsArea().DataTableToAreaList(dt1);
                        return response;
                    }
                    else
                    {
                        throw new Exception("Nenhuma area foi encontrada!");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Area> GetAreasPeople(Login user)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);

                DataTable dt1 = new DataTable();
                using (SqlDataAdapter adp = new SqlDataAdapter(@"EXEC PR_SR_AREA_ATUACAO 2, @ID_PESSOA", conn))
                {
                    adp.SelectCommand.CommandType = CommandType.Text;
                    adp.SelectCommand.Parameters.Add(new SqlParameter("@ID_PESSOA", Convert.ToInt32(user.ID_PESSOA)));

                    adp.Fill(dt1);

                    if (dt1.Rows.Count > 0)
                    {
                        List<Area> response = new FunctionsArea().DataTableToAreaList(dt1);
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

        public void CreateArea(CreateArea data)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);

                DataTable dt1 = new DataTable();
                using (SqlDataAdapter adp = new SqlDataAdapter(@"EXEC PR_SR_AREA_ATUACAO 3, null, @DESCRICAO", conn))
                {
                    adp.SelectCommand.CommandType = CommandType.Text;
                    adp.SelectCommand.Parameters.Add(new SqlParameter("@DESCRICAO", data.DESCRICAO));
                    adp.Fill(dt1);

                    
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Area> CreateLinkArea(CreateLinkArea data)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);

                DataTable dt1 = new DataTable();
                using (SqlDataAdapter adp = new SqlDataAdapter(@"EXEC PR_SR_AREA_ATUACAO 4, @ID_PESSOA, NULL, @ID_AREA", conn))
                {
                    adp.SelectCommand.CommandType = CommandType.Text;
                    adp.SelectCommand.Parameters.Add(new SqlParameter("@ID_PESSOA", Convert.ToInt32(data.ID_PESSOA)));
                    adp.SelectCommand.Parameters.Add(new SqlParameter("@ID_AREA", Convert.ToInt32(data.ID_AREA)));

                    adp.Fill(dt1);

                    if (dt1.Rows.Count > 0)
                    {
                        List<Area> response = new FunctionsArea().DataTableToAreaList(dt1);
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

    }
}
