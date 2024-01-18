using Microsoft.VisualStudio.TestTools.UnitTesting;
using _3SemEksamenReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace _3SemEksamenReference.Tests
{
    [TestClass()]
    public class RefRepoTests
    {
        //Lavet et test objekt
        private RefRepo _refeRepo;  

        //Lavet et objekt der med vilje "fejler"
        private Reference refe = new Reference { Id = 0, Name = "", Price = -1, Quality = 6, InStock = -1, RefTypeBrand = "" };


        //Laver en testliste
        private List<Reference> refs;


        [TestInitialize]
        public void TestInitialize()
        {
            _refeRepo = new RefRepo();

            //Tilføjer objekter til testlisten
            refs = new List<Reference>
            {
                new Reference {Id = 1, Name = "Bjørn", Price = 111, Quality = 1, InStock = 11, RefTypeBrand = "Blå"},
                new Reference {Id = 2, Name = "Magnus", Price = 222, Quality = 2, InStock = 22, RefTypeBrand = "Grøn"},
                new Reference {Id = 3, Name = "Karzan", Price = 333, Quality = 3, InStock = 33, RefTypeBrand = "Gul"}
            };
        }


        [TestMethod()]
        public void GetTest()
        {
            IEnumerable<Reference> refe = _refeRepo.Get();
            Assert.IsNotNull(refe);

            Assert.AreEqual(4, refe.Count());
            Assert.AreEqual("Bjørn", refe.First().Name);
            
        }


        //GetById metode test
        [TestMethod()]
        [DataRow("Bjørn", 111, 1, 11, "Blå")]
        [DataRow("Magnus", 222, 2, 22, "Grøn")]
        [DataRow("Karzan", 333, 3, 33, "Gul")]
        public void GetRefById(string name, int price, int quality, int inStock, string refTypeBrand)
        {
            //Arrange
            var rep = new RefRepo();

            var oldRef = new Reference() { Id = 1, Name = name, Price = price, Quality = quality, InStock = inStock, RefTypeBrand = refTypeBrand };
            rep.AddRef(oldRef);

            //Act
            var result = rep.GetRefById(oldRef.Id);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(oldRef.Id, result.Id);
            Assert.AreEqual(oldRef.Name, result.Name);
            Assert.AreEqual(oldRef.Price, result.Price);
            Assert.AreEqual(oldRef.Quality, result.Quality);
            Assert.AreEqual(oldRef.InStock, result.InStock);
            Assert.AreEqual(oldRef.RefTypeBrand, result.RefTypeBrand);
        }


        //Add metode test
        [TestMethod()]
        [DataRow("Bjørn", 111, 1, 11, "Blå")]
        [DataRow("Magnus", 222, 2, 22, "Grøn")]
        [DataRow("Karzan", 333, 3, 33, "Gul")]

        public void AddRef(string name, int price, int quality, int inStock, string refTypeBrand)
        {
            //Arrange
            var addRef = new Reference() { Id = 1, Name = name, Price = price, Quality = quality, InStock = inStock, RefTypeBrand = refTypeBrand };

            //Act
            var refAdded = _refeRepo.AddRef(addRef);

            //Assert
            Assert.IsNotNull(refAdded);
            Assert.AreEqual(name, refAdded.Name);
            Assert.AreEqual(price, refAdded.Price);
            Assert.AreEqual(quality, refAdded.Quality);
            Assert.AreEqual(inStock, refAdded.InStock);
            Assert.AreEqual(refTypeBrand, refAdded.RefTypeBrand);


            var RefInList = _refeRepo.GetAllRef().FirstOrDefault(b => b.Id == refAdded.Id);
            Assert.IsNotNull(RefInList);
            Assert.AreEqual(addRef.Name, RefInList.Name);
            Assert.AreEqual(addRef.Price, RefInList.Price);
            Assert.AreEqual(addRef.Quality, RefInList.Quality);
            Assert.AreEqual(addRef.RefTypeBrand, RefInList.RefTypeBrand);

        }

        //Update test, tester om 
        [TestMethod]
        public void UpdateRefTest()
        {
            Assert.AreEqual(4, _refeRepo.Get().Count());

            Reference refe = new() { Name = "Bob", Price = 1234, Quality = 5, RefTypeBrand = "Orange" };
            Assert.IsNull(_refeRepo.UpdateRef(100, refe));
            Assert.AreEqual(1, _refeRepo.UpdateRef(1, refe));

            Assert.AreEqual(5, _refeRepo.Get().Count());

        }

        //Test af Delete
        [TestMethod()]
        public void DeleteTest()
        { 
            Assert.IsNull(_refeRepo.DeleteRef(100));

            Assert.AreEqual(1, _refeRepo.DeleteRef(1).Id);
            Assert.AreEqual(11, _refeRepo.Get().Count());
        }

        [TestMethod]
        [DataRow(1500)]
        [DataRow(4500)]
        public void GetLowStockTest(int stockLevel)
        {
            IEnumerable<Reference> tClasses = _refeRepo.GetLowStockAlt(stockLevel);

            switch (stockLevel)
            {
                case 2000:
                    Assert.AreEqual(4, _refeRepo.GetLowStockAlt(stockLevel).Count());
                    break;
                case 4500:
                    Assert.AreEqual(10, _refeRepo.GetLowStockAlt(stockLevel).Count());
                    break;
            }

        }








    }
}