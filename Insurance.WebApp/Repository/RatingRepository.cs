using Insurance.Model;
using System.Collections.Generic;
using System.Linq;

namespace Insurance.WebApp.Repository
{
    public class RatingRepository : IRatingRepository
    {
        public RatingRepository() { }
        public List<Rating> GetAll()
        {
            var items = new List<Rating>() { 
                new Rating() {  Id=1, Description="Professional", Factor=1.00 },
                new Rating() {  Id=2, Description="White Collar", Factor=1.25 },
                new Rating() {  Id=3, Description="light Manual", Factor=1.50 },
                new Rating() {  Id=4, Description="Heavy Manual", Factor=1.75 }
            };

            return items;
        }

        public Rating GetById(int Id)
        {
            var item = GetAll()
                .Where(i => i.Id == Id)
                .FirstOrDefault();

            return item;
        }
    }
}