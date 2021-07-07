using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Company.Models
{
    public class CompanyModel
    {
        [BsonId]
        public string Code { get; set; }

        public string Name { get; set; }

        public string CEO { get; set; }

        public int TurnOver { get; set; }

        public string Website { get; set; }

        public string StockExchange { get; set; }
    }
}
