using Moksnes.WhereisIt.Business.Models;
using System.Threading.Tasks;

namespace Moksnes.WhereisIt.Business
{
    public interface ITitleSearcher
    {
        Task<Rootobject> SearchAsync(string query);

    }
}