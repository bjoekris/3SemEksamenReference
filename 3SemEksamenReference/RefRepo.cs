using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3SemEksamenReference
{
    //Husk at ændre internal til public
    public class RefRepo
    {

        //Default liste?
        private readonly List<Reference> refe = new();

        //Sikrer nyt id 
        private int nextId = 1;

        #region 5 objekter med diverse værdier
        //Der indsættes 5 objekter med diverse værdier
        public RefRepo()
        {
            
            refe.Add(new Reference() { Id = nextId++, Name = "Bjørn", Price = 1111, Quality = 1, InStock = 111, RefTypeBrand = "Blå" });
            refe.Add(new Reference() { Id = nextId++, Name = "Magnus", Price = 2222, Quality = 2, InStock = 222, RefTypeBrand = "Grøn" });
            refe.Add(new Reference() { Id = nextId++, Name = "Karzan", Price = 3333, Quality = 3, InStock = 333, RefTypeBrand = "Gul" });
            refe.Add(new Reference() { Id = nextId++, Name = "Mathilde", Price = 4444, Quality = 4, InStock = 444, RefTypeBrand = "Lilla" });
            refe.Add(new Reference() { Id = nextId++, Name = "Khader", Price = 5555, Quality = 5, InStock = 555, RefTypeBrand = "Rød" });

        }
        #endregion


        #region Metoder


        //GetAll Metode
        //Laver en liste med alle objekter.
        public List<Reference> GetAllRef()
        {
            return new List<Reference>(refe);
        }


        //Get() Metode
        //Returnere en liste af model-klassen 
        public List<Reference> GetRef()
        {
            if (refe == null)
            {
                return null;
            }
            return new List<Reference>(refe);
        }



        //GetById metode
        //Finder et givent objekt ud fra id
        //First or default metoden finder den første med ens ID, ellers anvender den Default værdien(Default konstruktør).
        public Reference GetRefById(int id)
        {
            return refe.FirstOrDefault(refe => refe.Id == id);
        }


        //Add metode
        //Hvis fejl, husk at lave void validate i "reference" klassen.
        //re.Id sørger for nyt id (Næste i rækken)
        public Reference AddRef(Reference re)
        {
            re.Validate();
            re.Id = nextId++;
            refe.Add(re);
            return re;
        }

        //Update metode
        public Reference UpdateRef(int id, Reference refe)
        {
            refe.Validate();
            Reference oldRefe = GetRefById(id);
            if (oldRefe == null)
            {
                return null;
            }

            oldRefe.Price = refe.Price;
            oldRefe.Quality = refe.Quality;
            oldRefe.InStock = refe.InStock;
            oldRefe.RefTypeBrand = refe.RefTypeBrand;
            return oldRefe;
        }

        //Get Low Stock metode
        public Reference GetLowStock(int InStock, int stockLevel)
        {
            Reference? re = refe.Find(x => x.InStock == stockLevel);
            if (InStock < 1 || stockLevel > 4000)
            {
                throw new ArgumentException("Der er ingen Referencer hvor InStock er lavere end eller lig med tallet i 'stockLevel'");

            }
            return re;
        }




        #endregion

    }
}
