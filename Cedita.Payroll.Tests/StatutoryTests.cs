﻿using Cedita.Payroll.Abstractions;
using Cedita.Payroll.Configuration.Providers;
using Cedita.Payroll.Models.Statutory;
using Cedita.Payroll.Models.Statutory.Assessments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cedita.Payroll.Tests
{
    public abstract class StatutoryTests
    {
        protected EmbeddedTaxConfigurationDataProvider DataProvider = new EmbeddedTaxConfigurationDataProvider();
        protected EmbeddedBankHolidayConfigurationProvider BankHolidayDataProvider = new EmbeddedBankHolidayConfigurationProvider();
        protected readonly IStatutoryCalculationEngineFactory statutoryFactory;

        public StatutoryTests()
        {
            statutoryFactory = new DefaultStatutoryCalculationEngineFactory(DataProvider, BankHolidayDataProvider);
        }

        protected StatutoryCalculationResult<SickPayAssessment> GetSspCalculation(int taxYear, SickPayAssessment assessment)
        {
            var sspEngine = statutoryFactory.CreateSspCalculationEngine(taxYear);
            return sspEngine.Calculate(assessment);
        }

        protected StatutoryCalculationResult<MaternityPayAssessment> GetSmpCalculation(int taxYear, MaternityPayAssessment assessment)
        {
            var smpEngine = statutoryFactory.CreateSmpCalculationEngine(taxYear);
            return smpEngine.Calculate(assessment);
        }

        protected StatutoryCalculationResult<PaternityPayAssessment> GetSppCalculation(int taxYear, PaternityPayAssessment assessment)
        {
            var sppEngine = statutoryFactory.CreateSppCalculationEngine(taxYear);
            return sppEngine.Calculate(assessment);
        }
    }
}
