using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Portafolio.Models;
using Portafolio.Servicios;

namespace Portafolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositorioProyectos repositorioProyectos;
        private readonly IConfiguration configuration;
        private readonly IServicioEmail servicioEmail;

        //private readonly ServicioDelimitado servicioDelimitado;
        //private readonly ServicioUnico servicioUnico;
        //private readonly ServicioTransitorio servicioTransitorio;
        //private readonly ServicioDelimitado servicioDelimitado2;
        //private readonly ServicioUnico servicioUnico2;
        //private readonly ServicioTransitorio servicioTransitorio2;

        public HomeController(
            ILogger<HomeController> logger,
            IRepositorioProyectos repositorioProyectos,
            IConfiguration configuration,
            IServicioEmail servicioEmail
            //ServicioDelimitado servicioDelimitado,
            //ServicioUnico servicioUnico,
            //ServicioTransitorio servicioTransitorio,
            //ServicioDelimitado servicioDelimitado2,
            //ServicioUnico servicioUnico2,
            //ServicioTransitorio servicioTransitorio2
            )
        {
            _logger = logger;
            this.repositorioProyectos = repositorioProyectos;
            this.configuration = configuration;
            this.servicioEmail = servicioEmail;
            //this.servicioDelimitado = servicioDelimitado;
            //this.servicioUnico = servicioUnico;
            //this.servicioTransitorio = servicioTransitorio;
            //this.servicioDelimitado2 = servicioDelimitado2;
            //this.servicioUnico2 = servicioUnico2;
            //this.servicioTransitorio2 = servicioTransitorio2;
        }

        public IActionResult Index()
        {
            //ViewBag.Nombre = "David Cartagena";
            //ViewBag.Edad = 26;
            //var persona = new Persona()
            //{
            //    Nombre = "David Cartagena",
            //    Edad = 19
            //};
            //return View(persona);

            //var apellido = configuration.GetValue<string>("Apellido");
            //_logger.LogTrace("Mensaje de tipo LogTrace");
            //_logger.LogDebug("Mensaje de tipo LogDebug");
            //_logger.LogInformation("Mensaje de tipo LogInformation");
            //_logger.LogWarning("Mensaje de tipo LogWarning");
            //_logger.LogError("Mensaje de tipo LogError");
            //_logger.LogCritical("Mensaje de tipo LogCritical " + apellido);

            var proyectos = repositorioProyectos.ObtenerProyectos().Take(3).ToList();

            //var guidViewModel = new EjemploGUIDViewModel()
            //{
            //    Delimitado = servicioDelimitado.ObtenerGuid,
            //    Transitorio = servicioTransitorio.ObtenerGuid,
            //    Unico = servicioUnico.ObtenerGuid,
            //};

            //var guidViewModel2 = new EjemploGUIDViewModel()
            //{
            //    Delimitado = servicioDelimitado2.ObtenerGuid,
            //    Transitorio = servicioTransitorio2.ObtenerGuid,
            //    Unico = servicioUnico2.ObtenerGuid,
            //};

            var modelo = new HomeIndexDTO()
            {
                ProyectoDTOs = proyectos,
                //EjemploGUIDView_1 = guidViewModel,
                //EjemploGUIDView_2 = guidViewModel2,
            };
            return View(modelo);
        }

        public IActionResult Proyectos()
        {
            var proyectos = repositorioProyectos.ObtenerProyectos();
            return View(proyectos);
        }

        [HttpGet]
        public IActionResult Contacto()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Contacto(ContactViewModel contactViewModel)
        {
            await servicioEmail.Enviar(contactViewModel);
            return RedirectToAction("Gracias");
        }

        public IActionResult Gracias()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
