using System.Net.Http;
using System.Threading.Tasks;
using Refit;

namespace Issue13.Api.Services
{
    [Headers("User-Agent: Issue13")]
    public interface IIssue13ApiContract
    {
        [Get("")]
        Task<HttpResponseMessage> GetIsAlive();
    }
}