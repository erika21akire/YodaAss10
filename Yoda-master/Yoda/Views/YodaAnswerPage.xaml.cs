using Yoda.ViewModels;
namespace Yoda.Views;

public partial class YodaAnswerPage : ContentPage
{
    AnswerViewModel _viewModel;

    public YodaAnswerPage(AnswerViewModel vm)
    {
        _viewModel = vm;

        InitializeComponent();

        BindingContext = _viewModel;
    }
}