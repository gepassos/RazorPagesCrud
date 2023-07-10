using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesCrud.Data;

namespace RazorPagesCrud.Pages.Funcionarios
{
    public class ListModel : PageModel
    {
		private readonly RazorPagesDbContext dbContext;

        public List<Models.Domain.Funcionario> Funcionarios { get; set; }

        public ListModel(RazorPagesDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public void OnGet()
        {
            Funcionarios = dbContext.Funcionarios.ToList();
        }
    }
}
