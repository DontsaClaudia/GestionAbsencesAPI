using GestionAbsences.Models;

namespace GestionAbsences.Services
{
    public class UsersService
    {
        static List<Users> User { get;}
        static int nextId = nextId++;

        static UsersService()
        {
            User = new List<Users>
            {
                new() {Id = 1, PasswordHash = "admin", UserName = "admin"},
                new() {Id = 2, PasswordHash = "user", UserName = "user"},
            };
        }
        public static List<Users> GetAll() => User;

        public static void Add(Users u)
        {
            u.Id = nextId++;
            User.Add(u);
        }

        public static Users Get(int id) => User.FirstOrDefault(u => u.Id == id);

        public static void Update(Users users)
        {
            var index = User.FindIndex(u => u.Id == users.Id);
            if (index == -1)
            {
                return;
            }
            User[index] = users;
        }

        public  Users Login(string username, string password)
        {
            return User.SingleOrDefault(u => u.UserName == username && u.PasswordHash == password);
        }

    }
}
