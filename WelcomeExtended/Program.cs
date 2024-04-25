using Welcome.Model;
using Welcome.Others;
using Welcome.ViewModel;
using Welcome.View;
using WelcomeExtended.Others;
using WelcomeExtended.Data;
using WelcomeExtended.Helpers;
using Microsoft.Extensions.Logging;
using System.Text;

namespace WelcomeExtended
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            ILogger il = LoggerHelper.GetFileLogger("hi");
            try
            {
                UserData userData = new UserData();

                User studentUser = new User()
                {
                    Name = "student",
                    Password = "123",
                    Role = UserRolesEnum.STUDENT
                };
                User u2 = new User()
                {
                    Name = "student2",
                    Password = "123",
                    Role = UserRolesEnum.STUDENT
                };
                User u3 = new User()
                {
                    Name = "Teacher",
                    Password = "1234",
                    Role = UserRolesEnum.PROFESSOR
                };
                User u4 = new User()
                {
                    Name = "Admin",
                    Password = "12345",
                    Role = UserRolesEnum.ADMIN
                };

                userData.AddUser(studentUser);
                userData.AddUser(u2);
                userData.AddUser(u3);
                userData.AddUser(u4);

                Console.WriteLine("Name:");
                string name = Console.ReadLine();
                Console.WriteLine("Password:");
                string pass = Console.ReadLine();

                userData.ValidateCredentials(name, pass);
                User gu = userData.GetUser(name, pass);

                Console.WriteLine(gu.ToString(true));


                il.LogInformation($"{gu.ToString(true)} - {DateTime.Now.ToString()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                il.LogError(ex.Message);
            }
        }
        }
}
