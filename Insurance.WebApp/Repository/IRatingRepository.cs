using Insurance.Model;
using System.Collections.Generic;

namespace Insurance.WebApp.Repository
{
    interface IRatingRepository
    {
        List<Rating> GetAll();
        Rating GetById(int Id);
    }
}
