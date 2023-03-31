using System.Linq.Dynamic.Core;

namespace BlazorApp1.Services
{
    public class DataService
    {

        private List<string> Names = new List<string>() { "João", "Maria", "Antonio", "Zezinho", "Julieta", "Ofelia" };

        public DataService()
        {
            Source = ItemsSrc();
        }

        private List<Sample> Source { get; set; }

        private List<Sample> ItemsSrc()
        {
            List<Sample> samples = new List<Sample>();
            Random rnd = new Random(DateTime.Now.Millisecond);

            for (int i = 0; i < 100000; i++)
            {
                samples.Add(new Sample
                {
                    Id = i,
                    Name = Names[rnd.Next(0, Names.Count - 1)],
                    CreationTime = DateTime.Now.AddDays(rnd.Next(1,364))
                });
            }

            return samples;
        }

        public async Task<(int total, List<Sample> items)> GetPaged(int page, int pageSize, string sorting)
        {
            var items = Source
            .AsQueryable()
            .OrderBy(sorting)
            .Page(page, pageSize)
            .ToList();

            await Task.Delay(3000);

            return (Source.Count, items);
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