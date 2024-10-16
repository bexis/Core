﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BExIS.Dim.Entities.Mapping
{
    public class MappingPartyResultElemenet
    {
        public string Value { get; set; }
        public long PartyId { get; set; }
    }

    public class MappingEntityResultElement
    {
        public string Value { get; set; }
        public long EntityId { get; set; }
        public long EntityTypeId { get; set; }

        public string Url { get; set; }
    }
}