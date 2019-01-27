using System;

namespace GoFDesignPatternsImplementation.Domain.ModelEntities
{
    [Serializable]
    public class TaskMetaData
    {
        public Priority Priority { get; set; }
        public string Owner { get; set; }
        public TeamData Team { get; set; }
        public ApplicationData Appliction { get; set; }
    }
}