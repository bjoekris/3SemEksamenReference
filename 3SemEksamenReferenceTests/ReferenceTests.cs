using Microsoft.VisualStudio.TestTools.UnitTesting;
using _3SemEksamenReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Xml.Linq;

namespace _3SemEksamenReference.Tests
{
    [TestClass()]
    public class ReferenceTests
    {
        #region Objekter med værdier til test
        private Reference refe = new Reference { Id = 1, Name = "Bjørn", Price = 111, Quality = 1, InStock = 11, RefTypeBrand = "Blå" };

        //Priser må ikke være negative (Eller 0 ifølge opgaven)
        private Reference priceZeroRefe = new Reference { Id = 2, Name = "Bjørn", Price = 0, Quality = 1, InStock = 11, RefTypeBrand = "Blå" };
        private Reference priceNegativeRefe = new Reference { Id = 3, Name = "Bjørn", Price = -1, Quality = 1, InStock = 11, RefTypeBrand = "Blå" };

        //Kvalitet må ifølge opgaven kun være 1-5
        private Reference qualityZeroRefe = new Reference { Id = 4, Name = "Bjørn", Price = 111, Quality = 0, InStock = 11, RefTypeBrand = "Blå" };
        private Reference qualityNegativeRefe = new Reference { Id = 5, Name = "Bjørn", Price = 111, Quality = -1, InStock = 11, RefTypeBrand = "blå" };
        private Reference qualityOverRefe = new Reference { Id = 6, Name = "Bjørn", Price = 111, Quality = 6, InStock = 11, RefTypeBrand = "Blå" };

        //Der kan ikke være negativ på lager
        private Reference inStockNegativeRefe = new Reference { Id = 7, Name = "Bjørn", Price = 111, Quality = 1, InStock = -1, RefTypeBrand = "Blå" };


        //RefTypeBrand må minimum være 2 characters.
        private Reference refTypeBrandShortRefe = new Reference { Id = 9, Name = "Bjørn", Price = 111, Quality = 0, InStock = 11, RefTypeBrand = "B" };

        #endregion


        #region Unit test af validate metoder

        //Test af Price
        [TestMethod()]
        public void ValidatePriceTest()
        {
            refe.ValidatePrice();
            Assert.ThrowsException<ArgumentException>(() => priceZeroRefe.ValidatePrice());
            Assert.ThrowsException<ArgumentException>(() => priceNegativeRefe.ValidatePrice());
        }

        //Test af Quality

        [TestMethod()]
        public void ValidateQualityTest()
        {
            refe.ValidateQuality();
            Assert.ThrowsException<ArgumentException>(() => qualityZeroRefe.ValidateQuality());
            Assert.ThrowsException<ArgumentException>(() => qualityNegativeRefe.ValidateQuality());
            Assert.ThrowsException<ArgumentException>(() => qualityOverRefe.ValidateQuality());
        }


        //Test af InStock
        [TestMethod()]
        public void ValidateInStockTest()
        {
            refe.ValidateInStock();
            Assert.ThrowsException<ArgumentException>(() => inStockNegativeRefe.ValidateInStock());

        }


        //Test af RefTypeBrand
        [TestMethod()]
        public void ValidateRefTypeBrandTest()
        {
            refe.ValidateRefTypeBrand();
            Assert.ThrowsException<ArgumentException>(() => refTypeBrandShortRefe.ValidateRefTypeBrand());
        }

        #endregion

    }
}