using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroDoc.Models
{
    public class LoginViewModels
    {
        [BindProperty]
        public InputModel Input { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "El campo cuenta es obligatorio.")]
            [DisplayName("Usuario")]
            public string Username { get; set; }

            [Required(ErrorMessage = "El campo contraseña es obligatorio.")]
            [DataType(DataType.Password)]
            [DisplayName("Contraseña")]
            public string Password { get; set; }

        }
    }
}
