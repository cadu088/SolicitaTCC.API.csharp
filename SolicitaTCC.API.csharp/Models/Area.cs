using System.Data;

namespace SolicitaTCC.API.csharp.Models
{
    public class Area
    {
        public int ID_AREA { get; set; }
        public string DESCRICAO { get; set; }
    }

    public class CreateArea
    {
        public string DESCRICAO { get; set; }
    }

    public class CreateLinkArea
    {
        public int ID_PESSOA { get; set; }
        public int ID_AREA { get; set; }

    }


    public class FunctionsArea
    {
        public List<Area> DataTableToAreaList(DataTable dt)
        {
            List<Area> areas = new List<Area>();

            foreach (DataRow row in dt.Rows)
            {
                Area area = new Area();

                area.ID_AREA = Convert.ToInt32(row["ID_AREA"]);
                area.DESCRICAO = row["DESCRICAO"].ToString();

                areas.Add(area);
            }

            return areas;
        }
    }


    //Crie uma função que recebe um DataTable e converta para a seguinte classe: 


}
