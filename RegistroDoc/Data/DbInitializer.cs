using RegistroDoc.Context;
using RegistroDoc.Core;
using RegistroDoc.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroDoc.Data
{
    public class DbInitializer
    {

        public static void Initialize(AppDBContext context)
        {
            Hash _hash = new Hash();
            context.Database.EnsureCreated();

            if (context.Role.Any())
            {
                return;
            }

            var roles = new Role[]
            {
            new Role{RoleValue="Admin", RoleDescription="Control Total, Adiciona, Edita y Elimina"},
            new Role{RoleValue="SoloLectura", RoleDescription="Solo puede ver la informacion"},
            new Role{RoleValue="RegistraLectura", RoleDescription="Solo puede registrar Ingresos y Egresos"}
            };
            foreach (Role role in roles)
            {
                context.Role.Add(role);
            }
            context.SaveChanges();


            if (context.User.Any())
            {
                return;
            }

            var users = new User[]
            {
            new User{FirstName="Admin",LastName="Admin",SecondLastName="Admin", Email="admin@test.com", Account="Admin", Password=_hash.EncryptString("Admin123"), RoleId=1},
            new User{FirstName="User1",LastName="User1",SecondLastName="User1", Email="user1@test.com", Account="User1", Password=_hash.EncryptString("User1"), RoleId=2},
            new User{FirstName="User2",LastName="User2",SecondLastName="User2", Email="user2@test.com", Account="User2", Password=_hash.EncryptString("User2"), RoleId=3}
            };
            foreach (User user in users)
            {
                context.User.Add(user);
            }
            context.SaveChanges();
        }
    }
}
