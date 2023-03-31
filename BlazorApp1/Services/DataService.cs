using System.Linq.Dynamic.Core;

namespace BlazorApp1.Services{
    public class DataService{
        private List<Sample> ItemsSrc { get; set; } = new(){
            new Sample(){
                Id = 1,
                Name = "João",
                CreationTime = DateTime.Now.AddDays(6)
            },new Sample(){
                Id = 2,
                Name = "Maria",
                CreationTime = DateTime.Now.AddDays(5)
            },new Sample(){
                Id = 3,
                Name = "Antonio",
                CreationTime = DateTime.Now.AddDays(4)
            },new Sample(){
                Id = 4,
                Name = "Zezinho",
                CreationTime = DateTime.Now.AddDays(3)
            },new Sample(){
                Id = 5,
                Name = "Julieta",
                CreationTime = DateTime.Now.AddDays(2)
            },new Sample(){
                Id = 6,
                Name = "Ofelia",
                CreationTime = DateTime.Now.AddDays(1)
            },
        };

        public async Task<(int total, List<Sample> items)> GetPaged(int page, int pageSize, string sorting)
        {
            var items = ItemsSrc
            .AsQueryable()
            .OrderBy(sorting)
            .Page(page,pageSize)
            .ToList();

            await Task.Delay(300);

            return (ItemsSrc.Count, items);
        }
    }
    
    public class Sample
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationTime { get; set; }
        public int Action { get; set; }
    }
}