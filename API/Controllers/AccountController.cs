using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.BLL;
using API.Data;
using API.DTO;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly DataContext context;
        public AccountController(DataContext context)
        {
            this.context = context;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<Response>> Register(string UserName, string Password){
            //Encription password.
            using var hmac = new HMACSHA512();
            var user = new AppUser(){
                UserName = UserName,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(Password)),
                PasswordSalt = hmac.Key
            };

            this.context.Users.Add(user);
            await this.context.SaveChangesAsync();
            return Ok(new Response(){ Code = 200, Message = "Transacción exitosa"});
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<Response>> RegisterUser(RegisterDTO data){
            return Ok(await new UserAppBLL(this.context).Register(data));
        } 

    }
}