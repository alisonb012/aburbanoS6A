using aburbanoS6A.Models;
using System.Net;
using System.Text.Json;

namespace aburbanoS6A.View;

public partial class vEliminar : ContentPage
{
	public vEliminar(Producto datos)
	{
		InitializeComponent();

        txtId.Text = datos.id.ToString();
        txtNombreProducto.Text = datos.productName;
        txtDescripcionProducto.Text = datos.productDescription;
        txtPrecioUnitario.Text = datos.uniPrice.ToString("F2");
    }

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {

        try
        {
            using (WebClient cliente = new WebClient())
            {
                var id = txtId.Text;

                
                cliente.UploadValues($"http://localhost:8080/api/products/{id}", "DELETE", new System.Collections.Specialized.NameValueCollection());

                DisplayAlert("Éxito", "Producto eliminado correctamente", "OK");

                
                Navigation.PushAsync(new VCrud());

                
            }
        }
        catch (Exception ex)
        {
            DisplayAlert("Error", ex.Message, "Cerrar");
        }

    }

    private void btnActualizar_Clicked(object sender, EventArgs e)
    {
        try
        {
            using (WebClient cliente = new WebClient())
            {
                var id = txtId.Text;

                var productoParaEnviar = new
                {
                    productName = txtNombreProducto.Text,
                    productDescription = txtDescripcionProducto.Text,
                    uniPrice = double.Parse(txtPrecioUnitario.Text)
                };

                string json = JsonSerializer.Serialize(productoParaEnviar);
                cliente.Headers[HttpRequestHeader.ContentType] = "application/json";
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(json);

                byte[] responseBytes = cliente.UploadData($"http://localhost:8080/api/products/{id}", "PUT", bytes);
                string responseString = System.Text.Encoding.UTF8.GetString(responseBytes);

                DisplayAlert("Éxito", "Producto actualizado correctamente", "OK");
                Navigation.PopAsync();
            }
        }
        catch (Exception ex)
        {
            DisplayAlert("Error", ex.Message, "Cerrar");
        }
    }
}