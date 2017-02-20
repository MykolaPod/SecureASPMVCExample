using System;
using WebBackgrounder;
using WebGrease;

namespace AutoLogOutSample.Services
{
    public static class WebBackgrounderSetup
    {
        private static readonly JobManager JobManager = CreateJobWorkersManager();

        public static void Start()
        {
            JobManager.Start();
        }

        public static void Shutdown()
        {
            JobManager.Dispose();
        }

        private static JobManager CreateJobWorkersManager()
        {
            var jobs = new IJob[]
            {
                new ResetPingStatusJob(interval:TimeSpan.FromSeconds(20),timeout: TimeSpan.FromSeconds(30)),
            };

            var coordinator = new SingleServerJobCoordinator();
            var host = new JobHost();
            var manager = new JobManager(jobs, host, coordinator);
            manager.Fail(ex =>
            {
               
                
            });
            return manager;
        }
    }
}