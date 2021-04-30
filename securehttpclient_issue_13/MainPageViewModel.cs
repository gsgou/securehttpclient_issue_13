using Refit;
using Xamarin.Forms;
using Issue13;
using Issue13.Api.Services;

namespace Issues13.ViewModel
{
    public class MainPageViewModel
    {
        public Command ApiCommand { get; }

        public MainPageViewModel()
        {
            ApiCommand = new Command(async() =>
            {
                var issue13ApiContract = RestService.For<IIssue13ApiContract>(BaseApiService.CreateHttpClient(AppConstants.ApiUrl));
                var service = new Issue13ApiService(issue13ApiContract);
                await service.GetIsAlive();
            });
        }
    }
}