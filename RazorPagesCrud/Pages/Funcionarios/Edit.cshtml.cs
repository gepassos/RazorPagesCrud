using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesCrud.Data;
using RazorPagesCrud.Models.Domain;
using RazorPagesCrud.Models.ViewModels;

namespace RazorPagesCrud.Pages.Funcionarios
{
    public class EditModel : PageModel
    {
		private readonly RazorPagesDbContext dbContext;

		[BindProperty]
        public EditFuncionarioViewModel EditFuncionarioViewModel { get; set; }
        public EditModel(RazorPagesDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public void OnGet(Guid id)
        {
			
			var funcionario = dbContext.Funcionarios.Find(id);

			if(funcionario != null)
			{
				 EditFuncionarioViewModel = new EditFuncionarioViewModel()
				{
					Id = funcionario.Id,
					Name = funcionario.Name,
					Email = funcionario.Email,
					DateOfBirth = funcionario.DateOfBirth,
					Departament = funcionario.Departament,
				};
			}
        }
		public void OnPostUpdate() 
		{
			if (EditFuncionarioViewModel != null )
			{
				var existingFuncionario = dbContext.Funcionarios.Find(EditFuncionarioViewModel.Id);
				if (existingFuncionario != null)
				{

						
						existingFuncionario.Name = EditFuncionarioViewModel.Name;
						existingFuncionario.Email = EditFuncionarioViewModel.Email;
						existingFuncionario.Salary = EditFuncionarioViewModel.Salary;
						existingFuncionario.DateOfBirth = EditFuncionarioViewModel.DateOfBirth;
						existingFuncionario.Departament = EditFuncionarioViewModel.Departament;

					dbContext.SaveChanges();
					ViewData["Message"] = "Funcionario atualizado com sucesso";
				}
			}
			

		} 
		public IActionResult OnPostDelete()
		{
			var existingFuncionario = dbContext.Funcionarios.Find(EditFuncionarioViewModel.Id);
			if (existingFuncionario != null)
			{
				dbContext.Funcionarios.Remove(existingFuncionario); 
				dbContext.SaveChanges();
				return RedirectToPage("/Funcionarios/List");
			}
			return Page();

			

		}
    }
}
