namespace ManagementSystem.Models
{
    public class Branch
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List <Employee>employees { get; set; }


    }
}
