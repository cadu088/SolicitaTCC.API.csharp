using System.Data;

namespace SolicitaTCC.API.csharp.Models
{
    public class getWorker
    {
        public int ID_PESSOA { get; set; }

    }

    public class Workers
    {
        public int ID_PESSOA { get; set; }
        public string NOME { get; set; }
        public string IMG { get; set; }
        public string AREA { get; set; }
        public string ACEITA_TRABALHO { get; set; }
    }

    public class postRequestWorker
    {
        public int ID_ALUNO { get; set; }
        public int ID_PROFESSOR { get; set; }
        public string NOME { get; set; }
        public string DESCRICAO { get; set; }

    }



    public class WorkerFunctions
    {
        

        public List<Workers> DataTableListWorkers(DataTable dt)
        {
            List<Workers> professores = new List<Workers>();

            foreach (DataRow row in dt.Rows)
            {
                Workers professor = new Workers();

                professor.ID_PESSOA = Convert.ToInt32(row["ID_PESSOA"]);
                professor.AREA = row["AREA"].ToString();
                professor.NOME = row["NOME"].ToString();
                professor.ACEITA_TRABALHO = row["ACEITA_TRABALHO"].ToString();
                professor.IMG = row["IMG"].ToString();
                professores.Add(professor);
            }

            return professores;
        }

        
    }


}
