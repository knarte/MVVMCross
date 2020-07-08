using System;
using System.Collections.Generic;
using System.Text;
using MvvmCross.ViewModels;
using System.Threading.Tasks;
using TipCalculator.Core.Services;

namespace TipCalculator.Core.ViewModels
{
    public class TipViewModel:MvxViewModel
    {
        private readonly ICalculationService _calculationService;
        private decimal _subTotal;
        private int _generosity;
        private decimal _tip;

        public TipViewModel(ICalculationService calculationService)
        {
            _calculationService = calculationService;
        }

        public decimal Tip
        {
            get => _tip;
            set
            {
                _tip = value;
                RaisePropertyChanged(() => Tip);
            }
        }
        public int Generosity
        {
            get => _generosity;
            set
            {
                _generosity = value;
                RaisePropertyChanged(() => Generosity);
            }
        }
        public decimal SubTotal
        {
            get => _subTotal;
            set
            {
                _subTotal = value;
                RaisePropertyChanged(() => Tip);
                Recalculate();
            }
        }

        public async override Task Initialize()
        {
            await base.Initialize();

            SubTotal = 100;
            Generosity = 10;
            Recalculate();
        }

        private void Recalculate()
        {
            Tip = _calculationService.TipAmount(SubTotal,Generosity);
        }
    }
}
