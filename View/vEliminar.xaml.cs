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
                // La URL para eliminar, t�picamente es DELETE en REST, pero WebClient no soporta DELETE directo
                // Por eso enviamos un POST o GET con par�metro o usamos un m�todo alternativo en el backend
                // Aqu� te pongo una forma com�n usando POST con un par�metro _method=DELETE (depende backend)

                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("id", txtId.Text);
                parametros.Add("_method", "DELETE"); // si tu backend soporta este m�todo (Spring Boot no por defecto)

                string url = $"http://localhost:8080/api/products/{txtId.Text}";

                // Si tu backend acepta DELETE propiamente, aqu� habr�a que usar HttpClient en vez de WebClient.

                cliente.UploadValues(url, "POST", parametros);
            }

           DisplayAlert("�xito", "Producto eliminado correctamente", "OK");
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