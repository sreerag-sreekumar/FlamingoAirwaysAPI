using FlamingoAirwaysAPI.Models.Interfaces.cs;
using Microsoft.AspNetCore.Http;
using static FlamingoAirwaysAPI.Models.FlamingoAirwaysModel;
using Microsoft.AspNetCore.Mvc;

namespace FlamingoAirwaysAPI.Controllers
{
    public class UserController : Controller
    {

        IUserRepository _repo;

        public UserController(IUserRepository userRepository)
        {
            userRepository = _repo;
        }

        // GET: UserController
        public async Task<IActionResult> Index()
        {
            var users = await _repo.GetAllUsers();
            return View(users);
        }

        // GET: UserController/Details/5
        public async Task<IActionResult> UserDetails(int id)
        {
            var user =await _repo.GetUserById(id);
            if(user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // GET: UserController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUser([FromBody] User value)
        {
            if (value == null)

            {

                return BadRequest();

            }

            await _repo.AddUser(value);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] User value)
        {

            var existingFlight = await _repo.GetUserById(id);
            if (existingFlight == null)
            {
                return NotFound();
            }

            await _repo.UpdateUser(id, value);
            return NoContent();
        }

        

        // POST: UserController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUser(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: UserController/Delete/5
        [HttpDelete("{id}")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var existingUser = await _repo.GetUserById(id);
            if (existingUser == null)
            {
                return NotFound();
            }

            await _repo.RemoveUser(id);
            return NoContent();
        }

    }
}
