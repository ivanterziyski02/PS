using Welcome.Model;
using Welcome.Others;
using Welcome.View;
using Welcome.ViewModel;

namespace Welcome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user = new User()
            {
                Name = "Ivan",
                FakNum = "121221052",
                Mail = "vanko@gmail.com",
                Password = "12345678",
                Role = UserRolesEnum.STUDENT
            };

            UserViewModel uvm = new UserViewModel(user);
            UserView uv = new UserView(uvm);

            uv.Display();
            uv.DisplayColor();

            Console.ReadKey();
        }
    }
}

