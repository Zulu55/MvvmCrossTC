namespace TipCalculator.Core
{
    using MvvmCross.IoC;
    using MvvmCross.ViewModels;
    using ViewModels;

    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterAppStart<TipViewModel>();
        }
    }
}
