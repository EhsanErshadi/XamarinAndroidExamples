using System.Runtime.Remoting.Messaging;
using Android.App;
using Android.Content;
using BackgroundService.Core.Infrastructure.MvxHelpers;
using BackgroundService.Droid.Infrastructure;
using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.Droid.Platform;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.CrossCore.IoC;

namespace BackgroundService.Droid
{
    public class Setup : MvxAndroidSetup
    {
        #region CTOR
        public Setup(Context applicationContext)
            : base(applicationContext)
        {
            Android.Util.Log.Debug("NC1", "Setup->Setup");
        } 
        #endregion

        #region Override Methods
        protected override IMvxApplication CreateApp()
        {
            Android.Util.Log.Debug("NC1", "Setup->CreateApp");
            return new Core.App();
        }

        protected override IMvxTrace CreateDebugTrace()
        {
            Android.Util.Log.Debug("NC1", "setup->CreateDebugTrace");
            return new DebugTrace();
        }

        protected override void InitializeFirstChance()
        {
            Android.Util.Log.Debug("NC1", "setup->InitializeFirstChance");
            CreatableTypes().StartingWith("UiService").AsInterfaces().RegisterAsLazySingleton();
            base.InitializeFirstChance();
        }

        protected override void InitializeLastChance()
        {
            Android.Util.Log.Debug("NC1", "setup->InitializeLastChance");
            base.InitializeLastChance();
            StartBackgroundServiceMain();
        }

        protected override IMvxNameMapping CreateViewToViewModelNaming()
        {
            return new SimpleViewModelNaming();
        } 
        #endregion

        #region Methods
        private void StartBackgroundServiceMain()
        {
            var context = Application.Context;
            var intent = new Intent(Application.Context, typeof(BackgroundService.BackgroundServiceMain));
            context.StartService(intent);
        } 
        #endregion
    }
}