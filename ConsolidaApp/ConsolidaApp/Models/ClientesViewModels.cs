using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web2.ViewModels
{
    public class ClientesViewModels
    {
        
        [Key]
        [Column("clientes")]
        [StringLength(25)]
        public string Codigo { get; set; }
        [Column("nclientes")]
        [StringLength(60)]
        public string Nombre { get; set; }
        [Column("celular")]
        [StringLength(15)]
        public string Celular { get; set; }
        [Column("telefono1")]
        [StringLength(15)]
        public string Telefono { get; set; }
        [Column("email")]
        [StringLength(50)]
        public string Email { get; set; }
        [Column("contacto")]
        [StringLength(50)]
        public string Contacto { get; set; }
        [Column("registro")]
        [StringLength(15)]
        public string Registro { get; set; }
        [Column("limitecredito", TypeName = "numeric(16, 6)")]
        public decimal Limitecredito { get; set; }
        [Column("direccion")]
        [StringLength(200)]
        public string Direccion { get; set; }
        [Column("notas")]
        [StringLength(250)]
        public string Notas { get; set; }

        public string TipoCliente { get; set; }
    }
}