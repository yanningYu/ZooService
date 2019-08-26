// Copyright @Frankie Yu - All Rights Reserved
// Filename: TimerManager.cs
// Created By  :  Frankie
// Created Date:  22/08/2019  18:41
// Last Edit:
//    Author:   Frankie
//    Date:     22/08/2019  18:41

namespace ZooService.API.TimerFeatures
{
    using System;
    using System.Linq;
    using System.Threading;

    using ZooService.API.DataStorage;

    public class TimerManager
    {
        private Timer timer;

        private AutoResetEvent autoResetEvent;

        private Action action;

        private Func<bool> condition;

        public TimerManager(Action action, Func<bool> condition)
        {
            this.action = action;
            this.condition = condition;
            this.autoResetEvent = new AutoResetEvent(false);
            
            this.timer = new Timer(Execute, this.autoResetEvent, 3000, 20000);
            this.TimerStarted = DateTime.Now;
        }

        public DateTime TimerStarted { get; }

        public void Execute(object stateInfo)
        {
            this.action();
            
            if (false)
            {
                this.timer.Dispose();
            }
        }
    }
}