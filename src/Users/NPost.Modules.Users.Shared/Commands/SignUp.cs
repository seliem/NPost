using System;
using NPost.Shared.Commands;

namespace NPost.Modules.Users.Shared.Commands
{
    public class SignUp : ICommand
    {
        public Guid Id { get; }
        public string Email { get; }
        public string Password { get; }
        public string Role { get; }

        public SignUp(Guid id, string email, string password, string role)
        {
            Id = id == Guid.Empty ? Guid.NewGuid() : id;
            Email = email;
            Password = password;
            Role = role;
        }
    }
}