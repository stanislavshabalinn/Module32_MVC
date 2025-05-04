using Module32_MVC.Models.DB;
using System.Threading.Tasks;

namespace Module32_MVC.Repositories
{
    public interface IRequestRepository
    {
        Task AddRequest ( Request request );
        Task<Request[]> GetRequests();
    }
}
