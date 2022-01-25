using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.DTO;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.BLL
{
    public class UserAppBLL
    {
        private readonly DataContext dbContext;

        public UserAppBLL(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Response> Register(RegisterDTO data){
            var response = new Response(){ Code = 500,Message ="Server Error"};

            if(await UserExists(data.UserName))
                return new Response(){ Code = 200,Message ="This username exist"};
           
            var user = EncryptPassword(data.Password);
            user.FirstName = data.FirstName;
            user.LastName = data.LastName;
            user.UserName = data.UserName;
            this.dbContext.Users.Add(user);
            int responseDB = await this.dbContext.SaveChangesAsync();
            if(responseDB > 0)
                new Response(){ Code = 200,Message ="Usuario registrado exitosamente"};
                
            return response;
        }

        private async Task<bool> UserExists(string UserName){
            return await this.dbContext.Users.AnyAsync(x => x.UserName.ToLower() == UserName.ToLower());
        }

        private AppUser EncryptPassword(string Password){
            using var hmac = new HMACSHA512();
            var user = new AppUser(){
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(Password)),
                PasswordSalt = hmac.Key
            };
            return user;
        }

    }
}