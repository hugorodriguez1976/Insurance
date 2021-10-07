using Insurance.Model;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;

namespace Insurance.WebClient.Helper
{
    public class PremiumModelHelper
    {
        private readonly string webapiurl;
        public PremiumModelHelper()
        {
            webapiurl = ConfigurationManager.AppSettings["webapiurl"].ToString();
        }

        public List<SelectListItem> PopulatePremiumVM()
        {

            ClientProxy proxy = new ClientProxy(webapiurl);
            var modelTaskOccupations = proxy.GetRequest<List<Occupation>>("api/occupation/getall").Result;
            var OccupationForList = modelTaskOccupations
                                          .Select(e => new SelectListItem() { Text = e.Description, Value = e.Id.ToString() })
                                          .ToList();
            return OccupationForList;
        }

        public double CalculatePremium(int OccupationId, double Amount, int Age)
        {
            ClientProxy proxy = new ClientProxy(webapiurl);
            double premium = proxy.GetRequest<double>(string.Format("api/occupation/calculatepremium?occupationid={0}&amount={1}&age={2}",OccupationId,Amount,Age)).Result;
            return premium;
        }

    }
}