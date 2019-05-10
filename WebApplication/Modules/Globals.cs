using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Modules
{
    static class Globals
    {
        // global int 
        public static int counter;
        // global boolean 
        public static Boolean proceso;
        // global function
        public static string Message()
        {
            return "En proceso de actualizacion, por favor espere";
        }

        // global int using get/set
        static int _getsetcounter;
        public static int getsetcounter
        {
            set { _getsetcounter = value; }
            get { return _getsetcounter; }
        }

        // global boolean using get/set
        static Boolean _getsetproceso;
        public static Boolean getsetproceso
        {
            set { _getsetproceso = value; }
            get { return _getsetproceso; }
        }

    }
}