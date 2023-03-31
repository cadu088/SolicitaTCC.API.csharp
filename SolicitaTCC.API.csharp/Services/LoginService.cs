using System.Data;

using System.Data.SqlClient;
using System;

namespace SolicitaTCC.API.csharp.Services
{
    public class LoginService
    {
        string connectionStringLocalhost = @"Data Source=CARLOSRODRIGUES\SQLEXPRESS;Initial Catalog=DB_AVANCADO;User ID=USERCSHARP;Password=USERCSHARP;Integrated Security=SSPI;TrustServerCertificate=True";
        string connectionString = @"Data Source=201.62.57.93;Initial Catalog=BD042700;User ID=RA042700;Password=042700;TrustServerCertificate=True";

        public DataTable Login()
        {
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				using (SqlCommand cmd = new SqlCommand(@" 
						select * from teste
                        "))
				{
					using (SqlDataAdapter adp = new SqlDataAdapter())
					{
						cmd.Connection = conn;
						adp.SelectCommand = cmd;
						using (DataTable DtResultadoStatus = new DataTable())
						{
							adp.Fill(DtResultadoStatus);
							return DtResultadoStatus;
						}
					}
				}

			}
		}
    }
}
