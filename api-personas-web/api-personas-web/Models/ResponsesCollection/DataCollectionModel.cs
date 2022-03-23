using api_personas_web.Models.ResponsesCollection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace api_personas_web.Models.ResponsesCollection
{
    [DataContract]
    public class DataCollectionModel
    {
        [DataMember]
        public LinksModel Links { get; set; }
        [DataMember]
        public GenericModel Data { get; set; }
        [DataMember]
        public RelationshipModel Relationships { get; set; }
    }
}
