using Calculator.WindowsUi.Models;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Calculator.WindowsUi
{
    public partial class FormCalculator : Form
    {
        public FormCalculator()
        {
            InitializeComponent();
        } 

        //Inicializo las variables
        private long numeroAnterior = 0;
        private string signo = "";
        DataAccess db = new DataAccess();

        //Calculo el resultado parcial a medida que se va operando
        private void calculoParcial()
        {
            //Si la pantalla está vacía no hay nada que hacer
            if (txtValorPantalla.Text != "") { 

                //El número ingresado por pantalla
                long numeroNuevo = long.Parse(txtValorPantalla.Text);

                //El resultado a calcular
                long resultado = 0;

                //Para el primer caso donde no hay un número precargado
                if (signo == "")
                {
                    numeroAnterior = numeroNuevo;
                }
                else
                {
                    //Si el número nuevo es mayor a 0, entonces el valor cambia
                    if (numeroNuevo > 0)
                    {
                        switch (signo)
                        {
                            case "/"://Divide
                                resultado = numeroAnterior / numeroNuevo;
                                break;
                            case "*"://Multiplica
                                resultado = numeroAnterior * numeroNuevo;
                                break;
                            case "-"://Resta
                                resultado = numeroAnterior - numeroNuevo;
                                break;
                            case "+"://Suma
                                resultado = numeroAnterior + numeroNuevo;
                                break;
                            default:
                                break;
                        }

                    }
                    //Insertar operaciones en la base de datos a medida que se van calculando
                    Operaciones operacion = new Operaciones(numeroAnterior, signo, numeroNuevo, resultado);
                    db.InsertarOperaciones(operacion);
                    
                    numeroAnterior = resultado;
                }
                //Limpio la pantalla
                txtValorPantalla.Text = "";
            }
        }

        private void btnDivide_Click(object sender, System.EventArgs e)
        {
            calculoParcial();
            signo = "/";
        }

        private void btnMultiplica_Click(object sender, System.EventArgs e)
        {
            calculoParcial();
            signo = "*";
        }

        private void btnResta_Click(object sender, System.EventArgs e)
        {
            calculoParcial();
            signo = "-";
        }

        private void btnSuma_Click(object sender, System.EventArgs e)
        {
            calculoParcial();
            signo = "+";
        }
        /// <summary>
        /// Genera el resultado de la operacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnResultado_Click(object sender, System.EventArgs e)
        {
            //Calculo
            calculoParcial();
            //Muestro el resultado
            txtValorPantalla.Text = numeroAnterior.ToString();
            //Limpio las variables
            numeroAnterior = 0;
            signo = "";
        }

        private void btnSiete_Click(object sender, System.EventArgs e)
        {
            txtValorPantalla.Text += "7";
        }

        private void btnOcho_Click(object sender, System.EventArgs e)
        {
            txtValorPantalla.Text += "8";
        }

        private void btnNueve_Click(object sender, System.EventArgs e)
        {
            txtValorPantalla.Text += "9";
        }

        private void btnCuatro_Click(object sender, System.EventArgs e)
        {
            txtValorPantalla.Text += "4";
        }

        private void btnCinco_Click(object sender, System.EventArgs e)
        {
            txtValorPantalla.Text += "5";
        }

        private void btnSeis_Click(object sender, System.EventArgs e)
        {
            txtValorPantalla.Text += "6";
        }

        private void btnUno_Click(object sender, System.EventArgs e)
        {
            txtValorPantalla.Text += "1";
        }

        private void btnDos_Click(object sender, System.EventArgs e)
        {
            txtValorPantalla.Text += "2";
        }

        private void btnTres_Click(object sender, System.EventArgs e)
        {
            txtValorPantalla.Text += "3";
        }

        private void btnCero_Click(object sender, System.EventArgs e)
        {
            txtValorPantalla.Text += "0";
        }

        private void btnLimpiar_Click(object sender, System.EventArgs e)
        {
            txtValorPantalla.Text = "";
            numeroAnterior = 0;
            signo = "";
        }
    }
}
