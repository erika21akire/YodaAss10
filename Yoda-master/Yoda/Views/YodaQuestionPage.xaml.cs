using Yoda.ViewModels;
namespace Yoda.Views;
public partial class YodaQuestionPage : ContentPage
{
    QuestionViewModel _viewModel;

    public YodaQuestionPage(QuestionViewModel vm)
    {
        InitializeComponent();

        _viewModel = vm;

        BindingContext = _viewModel;
    }
}