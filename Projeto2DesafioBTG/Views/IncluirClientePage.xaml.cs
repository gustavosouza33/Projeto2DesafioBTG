using Projeto2DesafioBTG.Interfaces;
using Projeto2DesafioBTG.ViewModels;

namespace Projeto2DesafioBTG.Views;

public partial class IncluirClientePage : ContentPage
{
    private readonly IncluirClienteViewModel _incluirClienteViewModel;
    public IncluirClientePage(IncluirClienteViewModel incluirClienteViewModel)
    {
        InitializeComponent();
        _incluirClienteViewModel = incluirClienteViewModel;
        BindingContext = _incluirClienteViewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _incluirClienteViewModel.inicializaItens();
    }
}