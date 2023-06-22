
namespace Ejercicio_3
{
    public partial class Form1 : Form
    {
        private string apiURL;
        private HttpClient httpclient;

        public Form1()
        {
            InitializeComponent();
            apiURL = "https://localhost:7012";
            httpclient = new HttpClient();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            await esperar();
            var nombre = textBox1.Text;
            var saludo = await ObtenerSaludo(nombre);
            MessageBox.Show(saludo);
            pictureBox1.Visible = false;
        }

        private async Task esperar()
        {
            await Task.Delay(5000);
        }

        private async Task<string> ObtenerSaludo(string nombre)
        {
            using (var respuesta = await httpclient.GetAsync($"{apiURL}/saludos/{nombre}"))
            {
                var saludo = await respuesta.Content.ReadAsStringAsync();
                return saludo;
            }
        }

    }
}