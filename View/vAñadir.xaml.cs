using System.Net;

namespace aburbanoS6A.View;

public partial class vAñadir : ContentPage
{
    public vAñadir()
    {
        InitializeComponent();
    }

    private async void btnAñadir_Clicked(object sender, EventArgs e)
    {
        try
        {
            using (WebClient cliente = new WebClient())
            {
                var parametros = new System.Collections.Specialized.NameValueCollection();

                // Aquí cambia los nombres y los textos según tus controles y datos que quieres enviar
                parametros.Add("nombreProducto", txtNombreProducto.Text);
                parametros.Add("descripcionProducto", txtDescripcionProducto.Text);
                parametros.Add("precioUnitario", txtPrecioUnitario.Text);

                // URL del servicio para crear producto (poner la URL real)
                string url = "http://localhost:8080/api/products";

                cliente.UploadValues(url, "POST", parametros);
            }

            // Navegar a la pantalla VCrud después de añadir
            await Navigation.PushAsync(new VCrud());
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "Cerrar");
        }
    }
}
