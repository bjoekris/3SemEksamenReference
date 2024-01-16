using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _3SemEksamenReference
{
    
    public class Reference
        //Husk at ændre internal til public^^
    {
        #region Properties
        //Properties

        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public int Quality { get; set; }

        public int InStock { get; set; }

        public string RefTypeBrand { get; set; }

        #endregion


        #region Default Konstruktør
        //Sørger for at sætte default values til objektets data(Propertiesne)
        // En tom default konstruktør er OK hvis vi er OK med 0 og Null som værdier. (bool=false) 
        public Reference()
        {

        }
        #endregion


        #region ToString
        //ToString
        //Laver objektet til en læselig string
        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id.ToString()}, {nameof(Name)}={Name}, {nameof(Price)}={Price.ToString()}, {nameof(Quality)}={Quality.ToString()}, {nameof(InStock)}={InStock.ToString()}, {nameof(RefTypeBrand)}={RefTypeBrand}}}";
        }

        #endregion


        #region Validate Medtoder
        //Validate metoder med Exceptions/Contraints (Tjek om opgaven opgiver hvilke exceptions/contraints der skal bruges).

        public void ValidatePrice()
        {
            if (Price <= 0) throw new ArgumentException("Price must be a positive number " + Price);
        }

        public void ValidateQuality()
        {
            if (Quality <= 0) throw new ArgumentException("Quality must be a positive number " + Quality);

            if (Quality > 5) throw new ArgumentException("Quality must not exceed 5 " + Quality);

        }

        public void ValidateInStock()
        {
            if (InStock <= 0) throw new ArgumentException("There can not be negative stock " + InStock);

            if (InStock > 1000) throw new ArgumentException("There can no be more than 1000 in stock " + InStock);

        }

        public void ValidateRefTypeBrand()
        {
            if (RefTypeBrand.Length < 2) throw new ArgumentException("Brand/type must be atlease 2 characters " + RefTypeBrand);


        }

       
        public void Validate()
        {

            ValidatePrice();
            ValidateQuality();
            ValidateInStock();
            ValidateRefTypeBrand();
        }


        #endregion

    }




}
