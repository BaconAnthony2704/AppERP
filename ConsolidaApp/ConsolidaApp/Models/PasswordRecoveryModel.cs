using System;
using System.Collections.Generic;
using System.Text;

namespace ConsolidaApp.Models
{
    public class PasswordRecoveryModel
    {
        public string email { get; set; }
        public string client_id { get; set; }
        public string connection { get; set; }
    }
}
