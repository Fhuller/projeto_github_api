using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHub_Api
{
    class DadosRetorno
    {
        public string login { get; set; }
        public string avatar_url { get; set; }
        public string repos_url { get; set; }
        public bool site_admin { get; set; }
        public string location { get; set; }
        public string bio { get; set; }
        public string followers { get; set; }
        public string following { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }

        public DateTime ArrumarData(string data)
        {

            DateTime dataArrumada = DateTime.ParseExact(data, "yyyy-MM-ddTHH:mm:ssZ",
                                   System.Globalization.CultureInfo.InvariantCulture);

            return dataArrumada;
        }
    }
}
