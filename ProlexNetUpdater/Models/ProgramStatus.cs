﻿namespace ProlexNetUpdater.Models
{
    public class ProgramStatus
    {
        public Result Result { get; set; }
    }

    public enum Result
    {
        Success,
        Failed
    };
}