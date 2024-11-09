using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica
{
    public partial class Form1 : Form
    {
        private List<int> numeros = new List<int>();
        private List<string> nombres = new List<string>();

        public Form1()
        {
            InitializeComponent();
            this.Load += MainForm_Load;

            btnAgregar.Click += btnAgregar_Click;
            btnEjecutar.Click += btnEjecutar_Click;
            btnLimpiar.Click += btnLimpiar_Click;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            cmbEjercicios.Items.Add("Ejercicio 1: Números pares e impares");
            cmbEjercicios.Items.Add("Ejercicio 2: Nombres que empiezan con 'J'");
            cmbEjercicios.SelectedIndex = 0;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string selectedExercise = cmbEjercicios.SelectedItem?.ToString();
            string input = txtInput.Text.Trim();

            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Por favor, ingrese un dato válido.");
                return;
            }

            if (selectedExercise == "Ejercicio 1: Números pares e impares")
            {
                if (int.TryParse(input, out int numero))
                {
                    numeros.Add(numero);
                    txtInput.Clear();
                }
                else
                {
                    MessageBox.Show("Ingrese un número válido.");
                }
            }
            else if (selectedExercise == "Ejercicio 2: Nombres que empiezan con 'J'")
            {
                if (input.Length >= 10 && input.Length <= 60)
                {
                    nombres.Add(input);
                    txtInput.Clear();
                }
                else
                {
                    MessageBox.Show("El nombre debe tener entre 10 y 60 letras.");
                }
            }
        }

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            listBoxResultados.Items.Clear();
            string selectedExercise = cmbEjercicios.SelectedItem?.ToString();

            if (selectedExercise == "Ejercicio 1: Números pares e impares")
            {
                EjecutarEjercicio1();
            }
            else if (selectedExercise == "Ejercicio 2: Nombres que empiezan con 'J'")
            {
                EjecutarEjercicio2();
            }
        }

        private void EjecutarEjercicio1()
        {
            List<int> numerosPares = new List<int>();
            List<int> numerosImpares = new List<int>();

            foreach (var numero in numeros)
            {
                if (numero % 2 == 0)
                    numerosPares.Add(numero);
                else
                    numerosImpares.Add(numero);
            }

            listBoxResultados.Items.Add("Números pares: " + string.Join(", ", numerosPares));
            listBoxResultados.Items.Add("Números impares: " + string.Join(", ", numerosImpares));
        }

        private void EjecutarEjercicio2()
        {
            List<string> nombresConJ = new List<string>();
            List<string> otrosNombres = new List<string>();

            foreach (var nombre in nombres)
            {
                if (nombre.StartsWith("J", StringComparison.OrdinalIgnoreCase))
                    nombresConJ.Add(nombre);
                else
                    otrosNombres.Add(nombre);
            }

            listBoxResultados.Items.Add("Nombres con 'J': " + string.Join(", ", nombresConJ));
            listBoxResultados.Items.Add("Otros nombres: " + string.Join(", ", otrosNombres));
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            numeros.Clear();
            nombres.Clear();
            txtInput.Clear();
            listBoxResultados.Items.Clear();
            MessageBox.Show("Datos y resultados limpiados.");
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            string selectedExercise = cmbEjercicios.SelectedItem?.ToString();
            string input = txtInput.Text.Trim();

            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Por favor, ingrese un dato válido.");
                return;
            }

            if (selectedExercise == "Ejercicio 1: Números pares e impares")
            {
                if (int.TryParse(input, out int numero))
                {
                    numeros.Add(numero);
                    txtInput.Clear();
                    txtInput.Focus();
                }
                else
                {
                    MessageBox.Show("Ingrese un número válido.");
                }
            }
            else if (selectedExercise == "Ejercicio 2: Nombres que empiezan con 'J'")
            {
                if (input.Length <= 60)  
                {
                    nombres.Add(input);
                    txtInput.Clear();
                    txtInput.Focus();
                }
                else
                {
                    MessageBox.Show("El nombre no debe exceder las 60 letras.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un ejercicio.");
            }
        }
    }