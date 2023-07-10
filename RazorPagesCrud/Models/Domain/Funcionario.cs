namespace RazorPagesCrud.Models.Domain
{
    public class Funcionario
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email  { get; set; }  

        public long Salary { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Departament { get; set; }
    }
}
