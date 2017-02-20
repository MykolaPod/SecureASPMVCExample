using System;

namespace AutoLogOutSample.ViewModels
{
    public class PingObject
    {
        private bool _isSessionAllowed;
        private DateTime _lastSessionAccessFlagModifiedDateTime;
        private DateTime _lastPingStatusModifiedDateTime;
        private bool _pingStatus;

        public bool PingStatus
        {
            get { return _pingStatus; }
            set
            {
                if (_pingStatus == false)
                {
                    _lastPingStatusModifiedDateTime = DateTime.UtcNow;

                }


                _pingStatus = value;


            }
        }

        public bool IsSessionAllowed
        {
            get { return _isSessionAllowed; }
            set
            {
                if (_isSessionAllowed == value)
                {
                    return;
                }
                else
                {
                    _isSessionAllowed = value;
                    _lastSessionAccessFlagModifiedDateTime = DateTime.UtcNow;
                }
            }
        }

        public DateTime LastSessionAccessFlagModifiedDateTime
        {
            get { return _lastSessionAccessFlagModifiedDateTime; }

        }

        public DateTime LastPingStatusModifiedDateTime
        {
            get { return _lastPingStatusModifiedDateTime; }

        }

        public static int SessionTimeoutMin { get; set; }
    }
}