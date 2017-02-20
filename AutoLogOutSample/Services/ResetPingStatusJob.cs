using System;
using System.Linq;
using System.Threading.Tasks;
using AutoLogOutSample.Controllers;
using AutoLogOutSample.ViewModels;
using WebBackgrounder;


namespace AutoLogOutSample.Services
{
    public class ResetPingStatusJob : Job
    {

        public ResetPingStatusJob(TimeSpan interval, TimeSpan timeout) : base("Sample Job", interval, timeout)
        {

        }
        public override Task Execute()
        {
            

            return new Task(() =>
            {
               
                var users = BaseController.UsersPingResult.Where(kv => !kv.Value.PingStatus && DateTime.UtcNow - kv.Value.LastPingStatusModifiedDateTime > TimeSpan.FromSeconds(30)).ToList();
                if (!users.Any())
                {
                    return;
                }
                var keysToDelete = users.Where(kv => DateTime.UtcNow - kv.Value.LastSessionAccessFlagModifiedDateTime > TimeSpan.FromMinutes(PingObject.SessionTimeoutMin));
                foreach (var keyValuePair in keysToDelete)
                {

              
                    PingObject o;
                    BaseController.UsersPingResult.TryRemove(keyValuePair.Key, out o);
                }


             

                foreach (var p in BaseController.UsersPingResult.Where(kv => !kv.Value.PingStatus && kv.Value.IsSessionAllowed))
                {
                
                    BaseController.UsersPingResult[p.Key].IsSessionAllowed = false;
                }


            });
        }
    }
}