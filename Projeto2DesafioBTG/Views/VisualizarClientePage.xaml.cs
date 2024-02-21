using Projeto2DesafioBTG.ViewModels;

namespace Projeto2DesafioBTG.Views;

public partial class VisualizarClientePage : ContentPage
{
    private readonly VisualizarClienteViewModel _visualizarClienteViewModel;
    public VisualizarClientePage(VisualizarClienteViewModel visualizarClienteViewModel)
    {
        InitializeComponent();
        _visualizarClienteViewModel = visualizarClienteViewModel;
        BindingContext = visualizarClienteViewModel;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        _visualizarClienteViewModel.CarregarListaClientes();
    }

    private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        _visualizarClienteViewModel.PesquisarCliente(e.NewTextValue);
    }
}