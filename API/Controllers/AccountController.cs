using API.Data;
using API.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly DataContext _context;

        public AccountController(DataContext context)
        {
            _context = context;
        }


       [HttpPost("register")] // POST: api/account/register
       
       public async Task<ActionResult<AppUser>> Register(RegisterDto registerDto)
        {
            if (await UserExist(registerDto.Username)) return BadRequest("Username is exist");
            using var hmac = new HMACSHA512();
            var user = new AppUser()
            {
                UserName = registerDto.Username,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok(user);
       }
       

        private async Task<bool> UserExist(string username)
        {
            return await _context.Users.AnyAsync(x=>x.UserName.ToLower() ==username.ToLower());
        }
       
        [HttpGet]
        public ActionResult<IEnumerable<AppUser>> GetUsers()
        {
            return _context.Users.ToList();
        }
        
        [HttpGet("{id}")]
        public ActionResult<AppUser>GetUsers(int id)
        {
            return _context.Users.Find(id);
        }


    }
}