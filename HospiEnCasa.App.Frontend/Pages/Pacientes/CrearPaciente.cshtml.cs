using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;


namespace HospiEnCasa.Frontend.Pages
{
    public class CrearPacienteModel : PageModel
    {    private static IRepositorioMedico _repositorioMedico = new RepositorioMedico(new HospiEnCasa.App.Persistencia.AppContext());

        public Medico Medico { get; set; }

        private static IRepositorioEnfermera _repositorioEnfermera = new RepositorioEnfermera(new HospiEnCasa.App.Persistencia.AppContext());

        public Enfermera Enfermera { get; set; }

        public IEnumerable<Enfermera> Enfermeras { get; set; }
        public IEnumerable<Medico> Medicos { get; set; }

        private static IRepositorioPaciente _repositorioPaciente = new RepositorioPaciente(new HospiEnCasa.App.Persistencia.AppContext());
        [BindProperty]
       
       
        public Paciente Paciente { get; set; }

        public CrearPacienteModel()
        { }




        public ActionResult OnGet()
        {
            this.Medicos = _repositorioMedico.GetAllMedicos();
            this.Enfermeras = _repositorioEnfermera.GetAllEnfermeras();
            return Page();
        }

        public ActionResult OnPost()
        {
            try
            {
                Paciente pacienteAdicionado = _repositorioPaciente.AddPaciente(Paciente);
                return RedirectToPage("./ListaPacientes");
            }
            catch (System.Exception e)
            {
                ViewData["Error"] = "Error: " + e.Message;
                return Page();
            }
        }
    }
}
