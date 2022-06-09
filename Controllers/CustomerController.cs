using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using ProjetAgenda.Data;
using ProjetAgenda.Models;

namespace ProjetAgenda.Controllers
{
    public class CustomerController : Controller
    {
        readonly AgendaContext _db;
        public CustomerController(AgendaContext db) => _db = db;
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCustomer(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _db.Customers.Add(customer);
                _db.SaveChanges();

                return RedirectToAction(nameof(ListCustomers));
            }
            else
                return View();
        }

        public IActionResult ListCustomers()
        {
            IEnumerable<Customer> customers = _db.Customers;
            //_db.Customers.SqlQuery<Customer>("SELECT * FROM Customers RANK BY firstname").ToList(); // Faudrait voir ce qui cloche

            return View(customers);
        }

        [HttpGet]
        //[ValidateAntiForgeryToken]
        public IActionResult ProfilCustomer(int id)
        {
            var queriedCust = _db.Customers.Find(id);

            return (queriedCust == null) ? NotFound() : View(queriedCust);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditCustomer(int id, Customer customer)
        {
            IActionResult S = View();
            if (ModelState.IsValid)
            {
                _db.Customers.Update(customer);
                _db.SaveChanges();
                S = RedirectToAction("ListCustomers");
            }
            
            return S;
        }

        public IActionResult DeleteCustomer(int id)
        {
            var queriedCust=_db.Customers.Find(id);
            IActionResult S = NotFound();

            if (queriedCust != null)
            {
                _db.Customers.Remove(queriedCust);
                _db.SaveChanges();
                S = View(nameof(ListCustomers));
            }

                return S;
        }
    }
}
