using Module32_MVC.Models.DB;
using System.Threading.Tasks;

namespace Module32_MVC.Repositories
{
    public interface IBlogRepository
    {
        Task AddUser(User user);
        Task<User[]> GetUsers();
    }
}
