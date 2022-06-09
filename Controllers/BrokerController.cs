using Microsoft.AspNetCore.Mvc;
using ProjetAgenda.Data;
using ProjetAgenda.Models;

namespace ProjetAgenda.Controllers
{
    public class BrokerController : Controller
    {
        readonly AgendaContext _db;
        public BrokerController(AgendaContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        //[ValidateAntiForgeryToken]
        public IActionResult AddBroker()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddBroker(Broker broker)
        {
            if (ModelState.IsValid)
            {
                _db.Brokers.Add(broker);
                _db.SaveChanges();

                return RedirectToAction(nameof(ListBrokers));
            }
            else
                return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditBroker(int id, Broker broker)
        {
            IActionResult S = View();

            if (ModelState.IsValid)
            {
                //ViewBag.http = "POST";
                //ViewBag.car = car;
                //Car car = _db.Car.Find(id);
                _db.Brokers.Update(broker);
                _db.SaveChanges();
                S = RedirectToAction("ListBrokers");
            }

            return S;
        }

        public IActionResult ListBrokers()
        {
            IEnumerable<Broker> brokers = _db.Brokers;

            return View(brokers);
        }
        
        //[HttpGet]
        //[ValidateAntiForgeryToken]
        public IActionResult ProfilBroker(int id)
        {
            Broker? queriedBroker = _db.Brokers.Find(id);

            return (queriedBroker != null) ? View(queriedBroker) : NotFound();
        }
    }
}
