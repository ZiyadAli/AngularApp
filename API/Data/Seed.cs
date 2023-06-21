using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using API.Entities;
using Microsoft.EntityFrameworkCore;


namespace API.Data
{
    public class Seed
    {
        public static async Task SeedUser(DataContext context)
        {
            if (await context.Users.AnyAsync()) return;

            var userDate = await File.ReadAllTextAsync("Data/UserSeedData.json");

            var options = new JsonSerializerOptions();
            options.PropertyNameCaseInsensitive = true;

            var users =  JsonSerializer.Deserialize<List<AppUser>>(userDate);

            foreach (var user in users)
            {
                using var hmac = new HMACSHA512();
                user.UserName = user.UserName.ToLower();
                user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("password"));
                user.PasswordSalt = hmac.Key;
               await context.Users.AddAsync(user);
            }
            await context.SaveChangesAsync();
        }
    }
}