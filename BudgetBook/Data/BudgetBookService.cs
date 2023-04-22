namespace BudgetBook.Data
{
    public class BudgetBookService
    {
        private static List<Entry> mockDB = new List<Entry>()
        {
            new Entry(){ Id = 1, Description="Test1", Amount = 50.0M },
            new Entry(){ Id = 2, Description="Test2", Amount = 50.0M },
        };

        public async Task<bool> AddEntry(Entry newEntry)
        {
            int t = 1;

            try {
                var r = mockDB.Max(x => x.Id);
                t = r + 1;
            }
            catch(Exception ex) { Console.WriteLine(ex); }

            newEntry.Id = t;
            mockDB.Add(newEntry);
            return true;
        }

        public async Task<List<Entry>> GetAllEntries()
        {
            return mockDB;
        }

        public async Task<bool> DeleteEntry(int id) 
        {
            var r = mockDB.Where(x => x.Id == id).FirstOrDefault();
            if (r != null)
            {
                mockDB.Remove(r);
            }
            return true;
        }

    }
}