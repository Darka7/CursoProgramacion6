﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace Entity
{
    public partial class VehiculoEntity:EN
    {

        public VehiculoEntity()
        {

            MarcaVehiculo = MarcaVehiculo ?? new MarcaVehiculoEntity();
        }

        public int? VehiculoId { get; set; }
        public int? MarcaVehiculoId { get; set; }
        public virtual MarcaVehiculoEntity MarcaVehiculo { get; set; }
        public string Matricula { get; set; }
        public string Color { get; set; }
        public string Modelo { get; set; }
        public DateTime FechaModelo { get; set; } = DateTime.Now;
        public bool TieneDefectos { get; set; }
        public string Defectos { get; set; }


    }
}