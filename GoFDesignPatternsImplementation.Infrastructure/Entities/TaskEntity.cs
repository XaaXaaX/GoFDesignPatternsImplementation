using System;
using System.Collections.Generic;
using System.Text;

namespace GoFDesignPatternsImplementation.Infrastructure.Entities
{
    internal class TaskEntity
    {
        internal uint TaskId { get; set; }

        internal TaskDataEntity TaskData { get; set; }

        internal DateTime CreationDate{ get; set; }

        internal TastStatusEntity Status { get; set; }
    }
}
