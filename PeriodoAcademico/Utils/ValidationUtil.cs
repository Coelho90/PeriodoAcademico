using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding;

namespace PeriodoAcademico.Utils
{
    public class ValidationUtil
    {
        public static Hashtable GetValidationErrors(ModelStateDictionary model)
        {
            Hashtable mapa = new Hashtable();

            foreach (var m in model) 
            {
                if (m.Value.Errors.Count() > 0) 
                {
                    
                    mapa[m.Key] = m.Value.Errors.Select(s => s.ErrorMessage).ToList();
                }
            }

            return mapa;
        }
    }
}