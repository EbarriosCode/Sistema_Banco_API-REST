using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BankSystem.Models
{
    [Table("CuentaBancariaClientes")]
    public class CuentaBancaria
    {
        [Key]
        [Required(ErrorMessage ="Este campo es requerido")]
        [DisplayName("Número de Cuenta")]
        [StringLength(10,ErrorMessage = "Este campo solo admite 10 caracteres, corrija")]
        public string NumeroCuenta { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [DisplayName("Titular de la Cuenta")]
        public string NombreCuenta { get; set; }

    }
}