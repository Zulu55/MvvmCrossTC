namespace TipCalculator.Core.ViewModels
{
    using System.Threading.Tasks;
    using MvvmCross.ViewModels;
    using Services;

    public class TipViewModel : MvxViewModel
    {
        #region Attributes
        private readonly ICalculationService _calculationService;
        private decimal _subTotal;
        private int _generosity;
        private decimal _tip;
        #endregion

        #region Properties
        public decimal SubTotal
        {
            get
            {
                return _subTotal;
            }
            set
            {
                _subTotal = value;
                RaisePropertyChanged(() => this.SubTotal);
                Recalculate();
            }
        }

        public decimal Tip
        {
            get
            {
                return _tip;
            }
            set
            {
                _tip = value;
                RaisePropertyChanged(() => this.Tip);
            }
        }

        public int Generosity
        {
            get
            {
                return _generosity;
            }
            set
            {
                _generosity = value;
                RaisePropertyChanged(() => this.Generosity);
                Recalculate();
            }
        }
        #endregion

        #region Constructors
        public TipViewModel(ICalculationService calculationService)
        {
            _calculationService = calculationService;
        }
        #endregion

        #region Methods
        public override async Task Initialize()
        {
            await base.Initialize();

            SubTotal = 100;
            Generosity = 10;
            Recalculate();
        }

        private void Recalculate()
        {
            Tip = _calculationService.TipAmount(SubTotal, Generosity);
        }
        #endregion
    }
}
