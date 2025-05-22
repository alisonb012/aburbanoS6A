using System.Net;
using System.Text;

namespace aburbanoS6A.View;

public partial class vAñadir : ContentPage
{
    public vAñadir()
    {
        InitializeComponent();
    }

    private void btnAñadir_Clicked(object sender, EventArgs e)
    {
       
        try
        {
            WebClient cliente = new WebClient();
            cliente.Headers[HttpRequestHeader.ContentType] = "application/json";

            var producto = new
            {
                productName = txtNombreProducto.Text,
                productDescription = txtDescripcionProducto.Text,
                uniPrice = txtPrecioUnitario.Text
            };

            string json = System.Text.Json.JsonSerializer.Serialize(producto);
            byte[] jsonBytes = Encoding.UTF8.GetBytes(json);

            byte[] response = cliente.UploadData("http://localhost:8080/api/products", "POST", jsonBytes);

            // Puedes interpretar la respuesta si quieres
            string respuestaTexto = Encoding.UTF8.GetString(response);

            Navigation.PushAsync(new VCrud());
        }
        catch (Exception ex)
        {
            DisplayAlert("Error", ex.Message, "Cerrar");
        }
    }
}
