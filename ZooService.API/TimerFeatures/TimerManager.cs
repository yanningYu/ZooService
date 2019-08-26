// Copyright @Frankie Yu - All Rights Reserved
// Filename: TimerManager.cs
// Created By  :  Frankie
// Created Date:  22/08/2019  18:41
// Last Edit:
//    Author:   Frankie
//    Date:     26/08/2019  16:40

namespace ZooService.API.TimerFeatures
{
    using System;
    using System.Threading;

    using ZooService.Core;

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

            this.timer = new Timer(this.Execute, this.autoResetEvent, 1000, ZooServiceConfiguration.PassingRate * 1000);
        }

        public void Execute(object stateInfo)
        {

            if (!this.condition())
            {
                this.timer.Dispose();
            }
            this.action();
        }
    }
}