using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Gruas_Atlas.Modelo
{
    internal class MetodosV
    {
        public MetodosV() {
        
        }
        public bool validarCedula(string cedula, string patron)
        {
            return new Regex(patron).IsMatch(cedula) && cedula.Length == 11;
        }
        public bool validarCampos(params string[] args)
        {
            foreach (var parametro in args)
            {
                if (parametro == null || parametro == "")
                {
                    return false;
                }
            }
            return true;
        }
        public bool idIguales(string idBDD, string idtxt)
        {
            return idBDD.Equals(idtxt);
        }
    }
}
