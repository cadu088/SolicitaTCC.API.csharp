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

    public class RequestWorkers
    {
        public int ID_SOLICITACAO { get; set; }
        public Pessoa ALUNO { get; set; }
        public Pessoa PROFESSOR { get; set; }
        public int ID_SITUACAO { get; set; }
        public string SITUACAO { get; set; }
        public string NOME { get; set; }
        public string DESCRICAO { get; set; }
        public string DT_APROVACAO { get; set; }
        public string DT_REPROVACAO { get; set; }
        public string JUSTIFICATIVA { get; set; }
        public Pessoa PESSOA_REPROVACAO { get; set; }
        public string DT_CADASTRO { get; set; }
        public int FL_ATIVO { get; set; }

    }

    public class ProjectWorkers
    {
        public int ID_PROJETO { get; set; }
        public int ID_SOLICITACAO { get; set; }
        public Pessoa ALUNO { get; set; }
        public Pessoa PROFESSOR { get; set; }
        public int ID_SITUACAO_PROJETO { get; set; }
        public string SITUACAO_PROJETO { get; set; }
        public string DT_INICIO { get; set; }
        public string DT_FIM { get; set; }
        public string NOME { get; set; }
        public string DESCRICAO { get; set; }
        public string DT_APROVACAO { get; set; }
        public string DT_REPROVACAO { get; set; }
        public string JUSTIFICATIVA { get; set; }
        public Pessoa PESSOA_CANCELAMENTO { get; set; }
        public string DT_CADASTRO { get; set; }
        public int FL_ATIVO { get; set; }

    }

    public class postRequestWorker
    {
        public int ID_ALUNO { get; set; }
        public int ID_PROFESSOR { get; set; }
        public string NOME { get; set; }
        public string DESCRICAO { get; set; }

    }

    public class getRequestsWorker
    {
        public int ID_ALUNO { get; set; }
        public int ID_PROFESSOR { get; set; }

    }
    public class getStageTask
    {
        public int ID_ETAPA { get; set; }
        public string DESCRICAO { get; set; }

    }
    public class createTask
    {
        public int ID_PROJETO { get; set; }
        public int ID_ETAPA { get; set; }
        public string TITULO { get; set; }
        public string DESCRICAO { get; set; }
        public string DT_INICIO { get; set; }
        public string DT_PREVISTA { get; set; }

    }
    public class getTaskWorker
    {
        public int ID_PROJETO { get; set; }
    }

    public class getTask
    {
        public int ID_TAREFA { get; set; }
        public int ID_PROJETO { get; set; }
        public int ID_ETAPA { get; set; }
        public string ETAPA { get; set; }
        public string TITULO { get; set; }
        public string DESCRICAO { get; set; }
        public string DT_INICIO { get; set; }
        public string DT_PREVISTA { get; set; }
        public int FL_FINALIZADA { get; set; }
        public string DT_FINALIZADA { get; set; }
        public string DT_CADASTRO { get; set; }
        public int FL_ATIVO { get; set; }

    }
    public class updtProjectWorker
    {
        public int ID_PROJETO { get; set; }
        public int ID_STATUS { get; set; }
        public int ID_PESSOA { get; set; }
        public string JUSTIFICATIVA { get; set; }

    }
    public class cancelRequestsWorker
    {
        public int ID_PROFESSOR { get; set; }
        public string JUSTIFICATIVA { get; set; }
        public int ID_SOLICITACAO { get; set; }

    }

    public class createProjectWorker
    {
        public int ID_ALUNO { get; set; }
        public int ID_PROFESSOR { get; set; }
        public int ID_SOLICITACAO { get; set; }

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
