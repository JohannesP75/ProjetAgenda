using Microsoft.AspNetCore.Mvc;
using ProjetAgenda.Data;
using ProjetAgenda.Models;

namespace ProjetAgenda.Controllers
{
    public class AppointmentController : Controller
    {
        readonly AgendaContext _db;
        public AppointmentController(AgendaContext db) => _db = db;
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        //[ValidateAntiForgeryToken]
        public IActionResult AddAppointment()
        {
            ViewBag.listBrokers = _db.Brokers.ToList();
            ViewBag.listCustomers = _db.Customers.ToList();
            ViewBag.broker = new Broker();
            ViewBag.customer = new Customer();
            ViewBag.IdBroker = 0;
            ViewBag.IdCustomer = 0;
            return View();
        }
        /*
        [HttpGet]
        public IActionResult AddAppointment(int idBroker)
        {
            ViewData["listCustomers"] = _db.Customers.ToList();
            var queriedBroker = _db.Brokers.Find(idBroker);

            return (queriedBroker != null) ? View(queriedBroker) : NotFound();
        }
        */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddAppointment(Appointment rdv)
        {
            ViewBag.listBrokers = _db.Brokers.ToList();
            ViewBag.listCustomers = _db.Customers.ToList();

            if (ModelState.IsValid)
            {
                _db.Appointments.Add(rdv);
                _db.SaveChanges();

                return RedirectToAction(nameof(ListAppointments));
            }
            else
                return NotFound();
        }

        public IActionResult ListAppointments()
        {
            IEnumerable<Appointment> appointments = _db.Appointments;

            return View(appointments);
        }

        public IActionResult DeleteAppointment(int id)
        {
            IActionResult S = NotFound();
            Appointment appt = _db.Appointments.Find(id);
            if (appt != null)
            {
                _db.Appointments.Remove(appt);
                _db.SaveChanges();
                S = RedirectToAction("Index", "Home");
            }
            return S;
        }
    }
}
