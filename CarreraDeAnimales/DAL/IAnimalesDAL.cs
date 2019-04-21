using CarreraDeAnimales.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarreraDeAnimales.DAL
{
    public interface IAnimalesDAL
    {
        void agregarAnimal(int distancia, Animal a);
    }
}
