using Cirrious.MvvmCross.ViewModels;

namespace BackgroundService.Core.Infrastructure.MvxHelpers
{
    public class  SimpleViewModelNaming:IMvxNameMapping
    {
        public string Map(string viewName)
        {
            var temp = viewName.Substring(4); // remove View from begining
            return "ViewModel" + temp;
        }
    }
}