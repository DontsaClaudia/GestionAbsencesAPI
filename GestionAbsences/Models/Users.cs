
namespace GestionAbsences.Models
{
    /// <summary>
    /// Represente un Utilisateur
    /// </summary>
    public class Users
    {
        /// <summary>
        /// Identifiant utnique de l'utilisateur
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Username de l'utilisateur
        /// </summary>
        public string UserName { get; set; } = string.Empty;
        /// <summary>
        /// Mot de passe de l'utilisateur
        /// </summary>
        public string PasswordHash { get; set; } = string.Empty;

        /// <summary>
        /// contructeur de definition de l'utilisateur
        /// </summary>
        /// <param name="id"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public Users(int id, string username, string password)
        { 
            this.Id = id;   
            this.UserName = username;
            this.PasswordHash = password;
        }

        public Users()
        {
        }

        public static implicit operator List<object>(Users v)
        {
            throw new NotImplementedException();
        }
    }
}
