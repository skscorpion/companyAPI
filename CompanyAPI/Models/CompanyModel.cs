using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CompanyAPI.Models
{
    public class CompanyModel
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public string CEO { get; set; }

        public double TurnOver { get; set; }

        public string Website { get; set; }

        public string StockExchange { get; set; }
    }
}
