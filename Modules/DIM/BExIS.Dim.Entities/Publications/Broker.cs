﻿using System.Collections.Generic;
using Vaiona.Entities.Common;

namespace BExIS.Dim.Entities.Publications
{
    public class Broker : BaseEntity, IBusinessVersionedEntity
    {
        public virtual string Name { get; set; }
        public virtual string Server { get; set; }
        public virtual string Type { get; set; }
        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }
        public virtual string MetadataFormat { get; set; }
        public virtual string PrimaryDataFormat { get; set; }
        public virtual string Link { get; set; }

        public virtual string Host { get; set; }
        public virtual Repository Repository { get; set; }

        public virtual List<Publication> Publications { get; set; }

    }
}
