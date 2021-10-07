using Insurance.Model;
using System.Collections.Generic;
using System.Linq;

namespace Insurance.WebApp.Repository
{
    public class OccupationRepository : IOccupationRepository
    {
        public OccupationRepository() { }
        public List<Occupation> GetAll()
        {
            var items = new List<Occupation>() { 
                new Occupation() {  Id=1, Description="Cleaner", RatingId=3 },
                new Occupation() {  Id=2, Description="Doctor", RatingId=1 },
                new Occupation() {  Id=3, Description="Author", RatingId=2 },
                new Occupation() {  Id=4, Description="Farmer", RatingId=4 },
                new Occupation() {  Id=5, Description="Mechanic", RatingId=4 },
                new Occupation() {  Id=6, Description="Florist", RatingId=3 }
            };

            return items;
        }

        public Occupation GetById(int Id)
        {
            var item = GetAll()
                .Where(i => i.Id == Id)
                .FirstOrDefault();

            return item;
        }
        public double CalculatePremium(double Amount, int Age, double? Factor)
        {
            double premium = Amount * (Factor ?? 0 ) * Age / 1000 * 12;

            return premium;
        }

    }
}