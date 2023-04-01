using System.Data;

namespace SolicitaTCC.API.csharp.Models
{
    public class userLogin
    {
        public string EMAIL { get; set; }
        public string SENHA { get; set; }
    }

    public class Login
    {
        public string ID_PESSOA { get; set; }

        public Login(string id_pessoa)
        {
            this.ID_PESSOA = id_pessoa;
        }
    }

    public class CreateLogin
    {
        public string NOME { get; set; }
        public int ID_TIPO_PESSOA { get; set; }
        public string EMAIL { get; set; }
        public string SENHA { get; set; }
        public string? RA { get; set; }
        public string? USUARIO { get; set; }
        public string IMG { get; set; }
    }

    public class Pessoa
    {
        public int ID_PESSOA { get; set; }
        public string NOME { get; set; }
        public int ID_TIPO_PESSOA { get; set; }
        public string EMAIL { get; set; }
        public string RA { get; set; }
        public string USUARIO { get; set; }
        public string IMG { get; set; }
        public int FL_ATIVO { get; set; }

    }

    public class Functions
    {
        public List<Pessoa> DataTableToPessoaList(DataTable dt)
        {
            List<Pessoa> pessoas = new List<Pessoa>();

            foreach (DataRow row in dt.Rows)
            {
                Pessoa pessoa = new Pessoa();

                pessoa.ID_PESSOA = Convert.ToInt32(row["ID_PESSOA"]);
                pessoa.NOME = row["NOME"].ToString();
                pessoa.ID_TIPO_PESSOA = Convert.ToInt32(row["ID_TIPO_PESSOA"]);
                pessoa.EMAIL = row["EMAIL"].ToString();
                pessoa.RA = row["RA"].ToString();
                pessoa.USUARIO = row["USUARIO"].ToString();
                pessoa.IMG = row["IMG"].ToString();
                pessoa.FL_ATIVO = Convert.ToInt32(row["FL_ATIVO"]);

                pessoas.Add(pessoa);
            }

            return pessoas;
        }
    }

    


}
