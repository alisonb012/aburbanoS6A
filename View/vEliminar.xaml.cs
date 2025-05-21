using System.Net;

namespace aburbanoS6A.View;

public partial class vEliminar : ContentPage
{
	public vEliminar()
	{
		InitializeComponent();
	}

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {

        

        try
        {
            using (WebClient cliente = new WebClient())
            {
                // La URL para eliminar, típicamente es DELETE en REST, pero WebClient no soporta DELETE directo
                // Por eso enviamos un POST o GET con parámetro o usamos un método alternativo en el backend
                // Aquí te pongo una forma común usando POST con un parámetro _method=DELETE (depende backend)

                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("id", txtId.Text);
                parametros.Add("_method", "DELETE"); // si tu backend soporta este método (Spring Boot no por defecto)

                string url = $"http://localhost:8080/api/products/{txtId.Text}";

                // Si tu backend acepta DELETE propiamente, aquí habría que usar HttpClient en vez de WebClient.

                cliente.UploadValues(url, "POST", parametros);
            }

           DisplayAlert("Éxito", "Producto eliminado correctamente", "OK");
            Navigation.PopAsync(); // Volver a la lista
        }
        catch (Exception ex)
        {
            DisplayAlert("Error", ex.Message, "Cerrar");
        }
    }

    private void btnActualizar_Clicked(object sender, EventArgs e)
    {

    }
}