using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asos.Sct.CustomerThreshold.AcceptanceTests.Models
{
    public class CustomsThresholdResponseModel
    {
        public string warehouseid { get; set; }
        public int orderValueLowerThreshold { get; set; }
        public int orderValueUpperThreshold { get; set; }
        public string currencyCode { get; set; }
        public string splitType { get; set; }
        public string thresholdType { get; set; }
        public string destinationIS03CountryCode { get; set; }
    }
}
