using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClienteCoreMongo.Models
{
    public class Cliente
    {
        public Guid Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Informe o nome do cliente.", AllowEmptyStrings = false)]
        public string Nome { get; set; }

        [Display(Name = "E-Mail")]
        [Required(ErrorMessage = "Informe o e-mail do cliente.", AllowEmptyStrings = false)]
        [RegularExpression(
            @"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$",
            ErrorMessage = "Informe um email válido.")]
        public string Email { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "Informe o cpf do cliente.", AllowEmptyStrings = false)]
        public string Cpf { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data de Nascimento")]
        [Required(ErrorMessage = "Informe a data de nascimento do cliente.", AllowEmptyStrings = false)]
        public DateTime DtNasc { get; set; }
    }
}
