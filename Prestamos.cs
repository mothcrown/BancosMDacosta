//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BancosMDacosta
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Prestamos
    {
        [Key]
        public int IdPrestamo { get; set; }
        [ForeignKey("Clientes")]
        public int IdCliente { get; set; }
        public Nullable<decimal> Importe { get; set; }
    
        public virtual Clientes Clientes { get; set; }
    }
}
