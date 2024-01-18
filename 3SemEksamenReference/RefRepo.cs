using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace _3SemEksamenReference
{
    //Husk at ændre internal til public
    public class RefRepo
    {

        //Laver liste
        private readonly List<Reference> refe = new();

        //Sikrer nyt id 
        private int nextId = 1;

        #region 5 objekter med diverse værdier
        //Der indsættes 5 objekter til listen
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


        //3 forskellige Get() / GetAll metoder
        public List<Reference> GetAllRef()
        {
            return new List<Reference>(refe);
        }

        public List<Reference> GetRef()
        {
            if (refe == null)
            {
                return null;
            }
            return new List<Reference>(refe);
        }

        public IEnumerable<Reference> Get()
        {
            IEnumerable<Reference> re = new List<Reference>(refe);
            return re;
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
        //Laver nyt it, validere det og tilføjer til listen
        public Reference AddRef(Reference re)
        {
            re.Id = nextId++;
            re.Validate();
            refe.Add(re);
            return re;
        }

        //Update metode
        //Validere nye værdier (Ikke id, kan skabe problemer). Opdaterer derefter værdierne.
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


        //Finder objektet (Hvis det findes) og fjerner hele objektet (Sammen med resten af værdierne)
        public Reference DeleteRef(int id)
        {
            Reference re = GetRefById(id);

            if (re == null)
            {
                return null;
            }

            refe.Remove(re);
            return (re);

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


        public IEnumerable<Reference> GetLowStockAlt(int stockLevel)
        {
            return refe.FindAll(r => stockLevel > r.InStock);
        }



        #endregion

    }
}
