using System.Threading.Tasks;

namespace Issue13.Api.Services
{
    public class Issue13ApiService : BaseApiService
    {
        readonly IIssue13ApiContract _issue13ApiContract;

        public Issue13ApiService(IIssue13ApiContract issue13ApiContract) => _issue13ApiContract = issue13ApiContract;

        public async Task<bool> GetIsAlive()
        {
            var response = await _issue13ApiContract.GetIsAlive();
            return response?.IsSuccessStatusCode ?? false;
        }
    }
}