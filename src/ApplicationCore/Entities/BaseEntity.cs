using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    //Temel class miras alacağımız class.
    //Get ve seti override edebilmek için virtual tanımlayacağız.
    //generic repositoryde baseentitye ait olma kısıtlaması için base classı oluşturduk.

    public class BaseEntity
    {
        public virtual int Id { get; set; }
    }
}
