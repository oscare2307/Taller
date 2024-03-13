namespace Salarios
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void ButtonCalculate_Clicked(object sender, EventArgs e)
        {

            // Validar el salario
            double salario;
            if (!double.TryParse(EntrySalario.Text, out salario) || salario <= 0)
            {
                DisplayAlert("Error", "Ingrese un valor positivo para el salario", "OK");
                return;
            }

            // Calcular los aportes
            double AporteSalud = salario * 0.04;
            double AportePension = salario * 0.04;
            double fpsContribucion = GetFpsContribucion(salario);
            double SalarioNeto = salario - AporteSalud - AportePension - fpsContribucion;

            // Mostrar los resultados
            BindingContext = this;
            EntryAporteSalud.Text = AporteSalud.ToString("C");
            EntryAportePension.Text = AportePension.ToString("C");
            EntryFpsAporteContribucion.Text = fpsContribucion.ToString("C");
            EntrySalarioNeto.Text = SalarioNeto.ToString("C");

        }

        private double GetFpsContribucion(double salario)
        {
            if (salario < 4)
            {
                return 0;
            }
            else if (salario >= 4 && salario < 16)
            {
                return salario * 0.01;
            }
            else if (salario >= 16 && salario < 17)
            {
                return salario * 0.012;
            }
            else if (salario >= 17 && salario < 18)
            {
                return salario * 0.014;
            }
            else if (salario >= 18 && salario < 19)
            {
                return salario * 0.016;
            }
            else if (salario >= 19 && salario < 20)
            {
                return salario * 0.018;
            }
            else
            {
                return salario * 0.02;
            }
        }
    }

}

