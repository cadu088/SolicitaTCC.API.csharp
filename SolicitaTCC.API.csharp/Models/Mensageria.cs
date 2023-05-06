using System.Data;

namespace SolicitaTCC.API.csharp.Models
{
    public class SendMensagem
    {
        public int ID_EMISSOR { get; set; }
        public int ID_RECEPTOR { get; set; }
        public string TIPO { get; set; }
        public string MENSAGEM { get; set; }
        public int ID_ARQUIVO { get; set; }
    }

    public class Mensagem
    {
        public int ID_MENSAGERIA { get; set; }
        public string DT_ENVIO { get; set; }
        public string TIPO { get; set; }
        public string MENSAGEM { get; set; }
        public string EXTENSÃO { get; set; }
        public string URL { get; set; }
    }

    public class Mensagens
    {
        public int ID_MENSAGERIA { get; set; }
        public int ID_EMISSOR { get; set; }
        public int ID_RECEPTOR { get; set; }
        public List<Mensagem> MENSAGEM { get; set; }

    }

    public class ChatPeople
    {
        public int ID_EMISSOR { get; set; }
        public int ID_RECEPTOR { get; set; }
    }

    public class MensageriaFunctions
    {
        public List<Mensagem> DataTableToMensagemList(DataTable dt)
        {
            List<Mensagem> msgs = new List<Mensagem>();

            foreach (DataRow row in dt.Rows)
            {
                Mensagem msg = new Mensagem();

                msg.ID_MENSAGERIA = Convert.ToInt32(row["ID_MENSAGERIA"]);
                msg.DT_ENVIO = row["DT_ENVIO"].ToString();
                msg.TIPO = row["TIPO"].ToString();
                msg.MENSAGEM = row["MENSAGEM"].ToString();
                msg.EXTENSÃO = row["EXTENSÃO"].ToString();
                msg.URL = row["URL"].ToString();
                msgs.Add(msg);
            }

            return msgs;
        }

        public Mensagens DataTableMensagensMensageriaList(DataTable dt)
        {
            Mensagens msgs = new Mensagens();

            msgs.ID_MENSAGERIA = Convert.ToInt32(dt.Rows[0]["ID_MENSAGERIA"].ToString());
            msgs.ID_RECEPTOR = Convert.ToInt32(dt.Rows[0]["ID_RECEPTOR"].ToString());
            msgs.ID_EMISSOR = Convert.ToInt32(dt.Rows[0]["ID_EMISSOR"].ToString());
            msgs.MENSAGEM = DataTableToMensagemList(dt);

            return msgs;
        }

        
    }


}
