using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Notifications
{
    public class Notifies
    {
        public Notifies()
        {
            NotifyList = new List<Notifies>();
        }

        [NotMapped]
        public string PropertyName { get; set; }

        [NotMapped]
        public string Message { get; set; }

        [NotMapped]
        public List<Notifies> NotifyList;


        public bool ValidateString(string valor, string propertyName)
        {

            if (!string.IsNullOrWhiteSpace(valor) && !string.IsNullOrWhiteSpace(propertyName))
            {
                return false;
            }

            NotifyList.Add(new Notifies
            {
                Message = "Field Required.",
                PropertyName = propertyName
            });

            return false;
        }

        public bool ValidateInteger(int valor, string propertyName)
        {
            if (valor > 0 && !string.IsNullOrWhiteSpace(propertyName))
            {
                return true;
            }

            NotifyList.Add(new Notifies
            {
                Message = "The field should be bigger than 0",
                PropertyName = propertyName
            });

            return false;
        }

        public bool ValidateInteger(decimal valor, string propertyName)
        {
            if (valor > 0 && !string.IsNullOrWhiteSpace(propertyName))
            {
                return true;
            }

            NotifyList.Add(new Notifies
            {
                Message = "The field should be bigger than 0",
                PropertyName = propertyName
            });

            return false;
        }
    }
}
