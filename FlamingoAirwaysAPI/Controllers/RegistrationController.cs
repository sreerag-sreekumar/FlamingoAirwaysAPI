using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore; // Add this line

using FlamingoAirwaysAPI.Models;

using System.Collections.Generic;

using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using static FlamingoAirwaysAPI.Models.FlamingoAirwaysModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace FlamingoAirwaysAPI.Controllers

{

    [Route("api/[controller]")]

    [ApiController]

    [AllowAnonymous()]


    public class RegistrationController : ControllerBase

    {
        IRegistrationRepository _repo;
        public RegistrationController(IRegistrationRepository repo)
        {
            _repo = repo;
        }
        IBookingRepository _bookingrepo;

        // GET: api/Users
        [HttpGet]
        [Authorize(Roles = "Admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _repo.GetAllUsers();
            return Ok(users);
        }

        // GET: api/User/5

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _repo.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // GET: api/User/email/example@example.com
        [HttpGet("email/{email}")]
        [Authorize(Roles = "User", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<User>> GetUserEmail(string email)

        {
            var userEmailCheck = await _repo.GetUserIDbyEmail(email);

            //var userBooking = await _bookingrepo.GetByIdAsync(email);
            if (userEmailCheck == null)
            {
                return NotFound();
            }

            //Check if the current user is owner of the booking
            //var userEmailCheck=await _repo.GetUserIDbyEmail(email);
            var currentUserId = User.Claims.FirstOrDefault(c => c.Type == "UserID")?.Value;
            if (userEmailCheck.UserId.ToString() != currentUserId)
            {
                return Forbid("You are not authorized to view this data!!!");
            }
            return Ok(userEmailCheck);
        }

        // POST: api/User
        [HttpPost("register")]
        public async Task<ActionResult<User>> PostUser([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            // Hash the password before storing
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            await _repo.AddUser(user);
            return CreatedAtAction(nameof(GetUser), new { id = user.UserId }, user);    
        }

        // PUT: api/User/5

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, [FromBody] User user)
        {
            if (user == null || id <= 0)
            {
                return BadRequest("Invalid user data.");
            }

            if (id != user.UserId)
            {
                return BadRequest("User ID mismatch.");
            }

            var existingUser = await _repo.GetUserById(id);
            if (existingUser == null)
            {
                return NotFound($"User with ID {id} not found.");
            }

            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.Email = user.Email;
            existingUser.Password = user.Password;
            existingUser.PhoneNo = user.PhoneNo;
            existingUser.Role = user.Role;

            try
            {
                await _repo.UpdateUser(id,existingUser);
            }
            catch (DbUpdateException ex)
            {
                // Log the exception details and return a server error
                Console.WriteLine($"Error updating user: {ex.Message}");
                return StatusCode(500, "An error occurred while updating the user.");
            }
            return NoContent();
        }
        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _repo.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            await _repo.RemoveUser(id);
            return NoContent();
        }
    }
}
