using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeRental.Contracts
{
    public interface ICSVSerializable
    {
        string ToCsvString();
    }
}
