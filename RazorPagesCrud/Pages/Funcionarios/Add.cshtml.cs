using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesCrud.Models.ViewModels;
using RazorPagesCrud.Data;
using System.ComponentModel.DataAnnotations;
using RazorPagesCrud.Models.Domain;

namespace RazorPagesCrud.Pages.Funcionarios
{
    public class AddModel : PageModel
    {
        private readonly RazorPagesDbContext dbContext;
		public AddModel(RazorPagesDbContext dbContext) {
        this.dbContext = dbContext;
        }

        [BindProperty]
        public AddFuncionarioViewModelClass AddFuncionarioRequest { get; set;}

        public void OnGet()
        {
        }

        public void OnPost() 
        {
            var funcionarioDomainModel = new Funcionario
            {   
                Name = AddFuncionarioRequest.Name,
                Email = AddFuncionarioRequest.Email,
                Salary = AddFuncionarioRequest.Salary,  
                DateOfBirth = AddFuncionarioRequest.DateOfBirth,
                Departament = AddFuncionarioRequest.Departament
            };

            dbContext.Funcionarios.Add(funcionarioDomainModel);
            dbContext.SaveChanges();
            ViewData["Message"] = "Funcionario cadastrado com sucesso";
        }
    }
}
