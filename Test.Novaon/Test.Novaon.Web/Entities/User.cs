using System;
using Test.Novaon.Web.Interfaces;

namespace Test.Novaon.Web.Entities
{
    public class User : BaseEntity<string>
    {
        public User()
        {
            this.OnCreated = DateTime.Now;
        }
        
        public string Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime? OnCreated { get; set; }
    }
}
