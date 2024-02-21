using Projeto2DesafioBTG.Interfaces;
using Projeto2DesafioBTG.Models;
using Projeto2DesafioBTG.ViewModels;

namespace Projeto2DesafioBTG.Views;

public partial class EditarClientePage : ContentPage
{
	public EditarClientePage(EditarClienteViewModel editarClienteViewModel)
	{
		InitializeComponent();
		BindingContext = editarClienteViewModel;
	}
}