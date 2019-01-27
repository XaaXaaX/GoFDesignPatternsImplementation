namespace GoFDesignPatternsImplementation.Models
{
    using GoFDesignPatternsImplementation.Domain.Enums;
    using GoFDesignPatternsImplementation.Domain.ModelEntities;
    using System;

    public class TaskModel
    {
        public static explicit operator TaskModel(TaskItem task)
        {
            TaskModel @this = new TaskModel();
            @this.CreationDate = task.CreationDate;
            @this.StatusTitle = task.Status.ToString();
            @this.StatusId = (byte)task.Status;
            @this.TaskId = task.TaskId;
            @this.Title = task.TaskTitle;

            return @this;
        }

        public static implicit operator TaskItem(TaskModel task)
        {
            TaskItem @this = new TaskItem();
            @this.CreationDate = task.CreationDate;
            @this.Status = (FlowStatus)task.StatusId;
            @this.TaskId = task.TaskId;
            @this.TaskTitle = task.Title;
            @this.TaskData = new TaskMetaData();
            @this.TaskData.Priority = task.priority;

            return @this;
        }

        public uint TaskId { get; set; }

        public string Title{ get; set; }

        public DateTime CreationDate { get; set; }

        public string StatusTitle { get; set; }

        public byte StatusId { get; set; }

        public Priority priority { get; set; }

    }
}