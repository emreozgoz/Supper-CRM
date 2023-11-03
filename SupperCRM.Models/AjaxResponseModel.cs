using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SupperCRM.Models
{
    public class AjaxResponseModel<T>
    {
        public bool Error { get;  set; }
        public string Success { get; set; }
        public List<KeyValuePair<string,string>> Errors { get; private set; }

        public T Object { get; set; }

        public void Add(string key, string message)
        {
            if(Errors == null)
                Errors = new List<KeyValuePair<string, string>>();

            Errors.Add(new KeyValuePair<string, string>(key, message));

            Error = true;
        }
    }
}
