using Insurance.Model;
using System.Collections.Generic;

namespace Insurance.WebApp.Repository
{
    public interface IRatingRepository
    {
        List<Rating> GetAll();
        Rating GetById(int Id);
    }
}
