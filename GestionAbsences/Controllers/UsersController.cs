using BCrypt.Net;
using GestionAbsences.Models;
using GestionAbsences.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text.Json;
using System;
using System.IO;


using System.Text;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;

namespace GestionAbsences.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase

    {
        private const string V = "list_users.json";

        //private readonly UsersService usersService;

        /* public UsersController(UsersService usersService)
         {
             this.usersService = usersService;
         }*/



        public static Users user = new Users(1,"admin","123");
       
        
        
        

            


        private readonly IConfiguration _configuration;

        public UsersController(IConfiguration configuration)
        {
            _configuration = configuration;
            
        }

           /// <summary>
           /// Methode qui retourne les utilisateur existants
           /// </summary>
           /// <param name="id"></param>
           /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<Users> Get(int id)
        {
            var user = UsersService.Get(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
         /// <summary>
         /// methode d'enregistrement d'un nouvel utilisateur
         /// </summary>
         /// <param name="request"></param>
         /// <returns></returns>
        [HttpPost("register")]
        public ActionResult<Users> Register([FromForm][Required] UserDto request)
        {

            string jsonUser = System.Text.Json.JsonSerializer.Serialize(UsersService.GetAll()) ;
            string user_list = "F:/MS2D1/Dot_Net_Csharp/mes_notes/Csharp/GestionAbsences/GestionAbsences/user_list.json";
            System.IO.File.WriteAllText(user_list,jsonUser);

            string passwordHash
                = BCrypt.Net.BCrypt.HashPassword(request.Password);
            user.UserName = request.Username;
            user.PasswordHash = passwordHash;

            return Ok(user);
        }
        /// <summary>
        /// Methode d'authentification de l'utilisateur
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public ActionResult<Users> Login( [FromForm][Required] UserDto request) 
        {
            string list_users = System.IO.File.ReadAllText("F:/MS2D1/Dot_Net_Csharp/mes_notes/Csharp/GestionAbsences/GestionAbsences/user_list.json");
              List<Users> users = new List<Users>();
                users.Add(user);

        var Utilisateur = System.Text.Json.JsonSerializer.Deserialize<List<Users>>(list_users);

            foreach (var u in Utilisateur)
            {
                if (u.UserName == request.Username)
                {
                    if (request.Password == u.PasswordHash)
                    {
                        string token = CreateToken(user);
                        return Ok(token);
                    }
                    return BadRequest("Success Connexion");
                }

            }
            return BadRequest("User not Found");
           




        }

        /// <summary>
        /// cre&tion du token
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private string CreateToken(Users user)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim("username", user.UserName)
            };


            var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Mais pourquoi ma clé de connexion ne marche pas"));
           
            var cred = new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "",
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                audience: "3IL Test",
                signingCredentials: cred
                ) ;

            var jWt = new JwtSecurityTokenHandler().WriteToken(token);

            return jWt;
        }
    }
}
