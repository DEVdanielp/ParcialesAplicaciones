using PrimerParcial.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace PrimerParcial.Clases
{
    public class clsVivienda
    {
        private bdViviendasItmEntities bdViviendas = new bdViviendasItmEntities();
        public tblVivienda vivienda { get; set; }

        public string Insertar()
        {
            try
            {
                bdViviendas.tblViviendas.Add(vivienda); //Agrega un empleado a la lista
                bdViviendas.SaveChanges(); //Guardar cambios en la base de datos
                return "Empleado guardado con exito";

            }
            catch (Exception ex)
            {
                return "Error al insertar al empleado " + ex.Message;
            }
        }

        public tblVivienda ConsultarXID(string Id)
        {
            //La expresion lambda se convierte en un objeto del tipo que se invoca
            tblVivienda emp = bdViviendas.tblViviendas.FirstOrDefault(e => e.Id == Id);
            return emp;
        }

        public List<tblVivienda> ConsultarTodasLasViviendas()
        {
            return bdViviendas.tblViviendas
                .OrderBy(e => e.NumPisos)
                .ToList();
        }

        public string Actualizar()
        {
            try
            {
                //Antes de actualizar se debe consultar si el dato ya existe 
                tblVivienda viv = ConsultarXID(vivienda.Id);
                if (viv == null)
                {
                    return "Vivienda no existe";
                }
                bdViviendas.tblViviendas.AddOrUpdate(vivienda);
                bdViviendas.SaveChanges();
                return "Vivienda actualizada con exito";
            }
            catch (Exception ex)
            {
                return "Error al actualizar vivienda" + ex.Message;
            }
        }

        public string Eliminar()
        {
            //Primero se debe consultar 
            try
            {
                tblVivienda viv = ConsultarXID(vivienda.Id);
                if (viv == null)
                {
                    return "La vivienda no existe";
                }
                bdViviendas.tblViviendas.Remove(viv);
                bdViviendas.SaveChanges();
                return "Vivienda eliminado correctamente";
            }
            catch (Exception ex)
            {
                return "No se ha podido eliminar la vivienda" + ex.Message;
            }
        }
    }
}