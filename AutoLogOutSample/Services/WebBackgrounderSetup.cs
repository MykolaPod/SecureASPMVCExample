using System;
using WebBackgrounder;
using WebGrease;

namespace AutoLogOutSample.Services
{
    public static class WebBackgrounderSetup
    {
        static readonly JobManager JobManager = CreateJobWorkersManager();

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
                new ResetPingStatusJob(TimeSpan.FromSeconds(20), TimeSpan.FromSeconds(30)),
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