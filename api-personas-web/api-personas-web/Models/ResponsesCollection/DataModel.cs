using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace api_personas_web.Models.ResponsesCollection
{
    [DataContract]
    public class DataModel
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string Type { get; set; }
    }
}
