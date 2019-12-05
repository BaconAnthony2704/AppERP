using System;
using System.Collections.Generic;
using System.Text;

namespace ConsolidaApp.Models
{
    public class Validaciones
    {
        private string reglaCorreo = "@gmail.com";
        public bool verificarCampo(string value)
        {
            if (!value.Trim().Equals(""))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool verificarCorreo(string value)
        {
            if (value.Trim().Contains(reglaCorreo))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
