using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Others;

namespace Welcome.Model
{
    public class User
    {
        public virtual int Id { get; set; }
        private string _password;
        public string Name { get; set; }
        public virtual string Password
        {
            get { return Encryption.Decrypt(_password); }
            set { _password = Encryption.Encrypt(value); }
        }
        public string FakNum { get; set; }
        public string Mail { get; set; }
        public UserRolesEnum Role { get; set; }
        public DateTime Expires { get; set; }
    }
}
