using Insurance.Model;
using System.Collections.Generic;

namespace Insurance.WebApp.Repository
{
    public interface IOccupationRepository
    {
        List<Occupation> GetAll();
        Occupation GetById(int Id);
        double CalculatePremium(double Amount, int Age, double? Factor);
    }
}
