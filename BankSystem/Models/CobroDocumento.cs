using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BankSystem.Models
{
    [Table("CobroDocumentos")]
    public class CobroDocumento
    {
        [Key]
        public int IdCobroDocumento { get; set; }

        [Required(ErrorMessage = "El número de Documento es un campo requerido")]
        [DisplayName("No. de Documento")]
        [Range(1000,10000,ErrorMessage = "El número del documento no está dentro del rango asignado")]
        public int Documento { get; set; }

        [Required(ErrorMessage = "La cuenta es obligatoria para realizar el cobro")]
        [Display(Name ="Cuenta a depositar")]
        public string NumeroCuenta { get; set; }

        [Required(ErrorMessage = "La cantidad a Cobrar es obligatoria")]
        [DisplayName("Cantidad a Cobrar")]
        public decimal CantidadCobro { get; set; }

        [Required(ErrorMessage = "El mes de pago es obligatorio")]
        [DisplayName("Mes de Pago")]
        public int MesDePago { get; set; }
        
        public virtual CuentaBancaria CuentaBancaria{ get; set; }
    }
}