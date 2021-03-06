﻿// Copyright(c) Cedita Ltd.All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the solution root for license information.
using Cedita.Payroll.Calculation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cedita.Payroll.Calculation.Paye;
using Cedita.Payroll.Calculation.NationalInsurance;
using Cedita.Payroll.Configuration.Providers;

namespace Cedita.Payroll.Tests
{
    [TestClass]
    public class EngineFactoryTests
    {
        EmbeddedTaxConfigurationDataProvider DataProvider = new EmbeddedTaxConfigurationDataProvider();

        [TestMethod]
        public void TestPayeEngineResolution()
        {
            var payeEngineFactory = new DefaultPayeCalculationEngineFactory(DataProvider);

            Assert.AreEqual(typeof(PayeVersion12), payeEngineFactory.CreatePayeCalculationEngine(2014).GetType());
            Assert.AreEqual(typeof(PayeVersion13), payeEngineFactory.CreatePayeCalculationEngine(2015).GetType());
            Assert.AreEqual(typeof(PayeVersion13), payeEngineFactory.CreatePayeCalculationEngine(2016).GetType());
            Assert.AreEqual(typeof(PayeVersion13), payeEngineFactory.CreatePayeCalculationEngine(2017).GetType());
            Assert.AreEqual(typeof(PayeVersion13), payeEngineFactory.CreatePayeCalculationEngine(2018).GetType());
        }

        [TestMethod]
        public void TestNationalInsuranceEngineResolution()
        {
            var niEngineFactory = new DefaultNiCalculationEngineFactory(DataProvider);

            Assert.AreEqual(typeof(NationalInsurance2014), niEngineFactory.CreateNiCalculationEngine(2014).GetType());
            Assert.AreEqual(typeof(NationalInsurance2015), niEngineFactory.CreateNiCalculationEngine(2015).GetType());
            Assert.AreEqual(typeof(NationalInsurance2016), niEngineFactory.CreateNiCalculationEngine(2016).GetType());
            Assert.AreEqual(typeof(NationalInsurance2017), niEngineFactory.CreateNiCalculationEngine(2017).GetType());
            Assert.AreEqual(typeof(NationalInsurance2017), niEngineFactory.CreateNiCalculationEngine(2018).GetType());
        }
    }
}
