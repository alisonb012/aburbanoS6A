using System.Collections.ObjectModel;
using aburbanoS6A.Models;
using Newtonsoft.Json;

namespace aburbanoS6A.View;

public partial class VCrud : ContentPage
{

    private const string Url = "http://localhost:8080/api/products";
    private readonly HttpClient cliente = new HttpClient();
    private ObservableCollection<Producto> _producto;

    public VCrud()
	{
		InitializeComponent();
        Mostrar();
    }
    public async void Mostrar()
    {
        try
        {
            var content = await cliente.GetStringAsync(Url);
            List<Producto> lista = JsonConvert.DeserializeObject<List<Producto>>(content);
            _producto = new ObservableCollection<Producto>(lista);
                lvProductos.ItemsSource = _producto;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
    }

    private void btnAñadir_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new vAñadir());
    }

    private void lvProductos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        /*var objProducto = (Producto)e.SelectedItem;
        Navigation.PushAsync(new vEliminar(object));*/
    }
}