//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApiPrueba.Models.DBVehiculos
{
    using System;
    using System.Collections.Generic;
    
    public partial class CARROS
    {
        public int Id { get; set; }
        public string MODELO { get; set; }
        public string COLOR { get; set; }
        public Nullable<int> KILOMETRAJE { get; set; }
        public Nullable<int> VALOR { get; set; }
        public string IMAGEN { get; set; }
        public Nullable<System.DateTime> FECHA_REGISTRO { get; set; }
        public string TIPO { get; set; }
    }
}
