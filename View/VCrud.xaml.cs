using System.Collections.ObjectModel;
using aburbanoS6A.Models;

namespace aburbanoS6A.View;

public partial class VCrud : ContentPage
{

    private const string Url = "http://127.0.0.1/moviles/wsestudiantes.php";
    private readonly HttpClient cliente = new HttpClient();
    private ObservableCollection<Estudiante> _estudiante;

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
            List<Estudiante> lista = JsonConvert.DeserializeObject<List<Estudiante>>(content);
            _estudiante = new ObservableCollection<Estudiante>(lista);
            lvEstudiante.ItemsSource = _estudiante;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
    }
}