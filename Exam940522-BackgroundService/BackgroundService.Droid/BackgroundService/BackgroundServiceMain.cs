using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace BackgroundService.Droid.BackgroundService
{
    [Service]
    internal class BackgroundServiceMain : Android.App.Service
    {
        #region Constants
        private const int MainThreadDelaySeconds = 10;
        #endregion

        #region Fields
        private Thread _bgServiceThread;
        #endregion

        #region Android.App.Service
        public override IBinder OnBind(Intent intent)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Override Mathods
        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {
            return StartCommandResult.Sticky;
        }
        public override void OnDestroy()
        {
            if (_bgServiceThread != null)
            {
                if (_bgServiceThread.IsAlive)
                    _bgServiceThread.Abort();
                _bgServiceThread = null;
            }
        }
        public override void OnCreate()
        {
            _bgServiceThread = new Thread(() =>
            {
                do
                {
                    try
                    {
                        Android.Util.Log.Debug("NC1", "BackgroundService Thread Loop ...");
                        //var myWorkerObject = Mvx.Resolve<IMyWorkerObject>();
                        //myWorkerObject.ShowNotificationIcon();
                    }
                    catch (Exception ex)
                    {
                        //Android.Util.Log.Debug("NC1", "Error 1: " /*+ ex*/);

                        //try
                        //{
                        //    Android.Util.Log.Debug("NC1", "Call EnsureSingletonAvailable ...");
                        //    var setupSingleton = MvxAndroidSetupSingleton.EnsureSingletonAvailable(ApplicationContext);
                        //    setupSingleton.EnsureInitialized();
                        //    Android.Util.Log.Debug("NC1", "Call EnsureSingletonAvailable done.");
                        //}
                        //catch (Exception ex2)
                        //{
                        //    Android.Util.Log.Debug("NC1", "Error 2 : " + ex2);
                        //}
                    }
                    Thread.Sleep(MainThreadDelaySeconds * 1000);
                } while (true);
            });
            _bgServiceThread.IsBackground = true;
            _bgServiceThread.Start();
            base.OnCreate();
        }
        #endregion
    }
}