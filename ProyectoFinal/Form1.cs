using System.Diagnostics;

namespace ProyectoFinal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private readonly int[] sampleSizes = { 50000, 10000, 50000 };
        private readonly Random Rnd = new Random();



        private void SelectionSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int minIndex = i;

                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[minIndex])
                    {
                        minIndex = j;
                    }
                }
                if (minIndex != i)
                {
                    int temp = arr[i];
                    arr[i] = arr[minIndex];
                    arr[minIndex] = temp;
                }
            }

        }
        private void MergeSort(int[] arr)
        {
            MergeSortRecursive(arr, 0, arr.Length - 1);
        }

        private void MergeSortRecursive(int[] arr, int left, int right)
        {

            if (left < right)
            {

                int middle = left + (right - left) / 2;

                MergeSortRecursive(arr, left, middle);
                MergeSortRecursive(arr, middle + 1, right);


                Merge(arr, left, middle, right);
            }

        }


        private void Merge(int[] arr, int left, int middle, int right)
        {
            int n1 = middle - left + 1;
            int n2 = right - middle;

            int[] L = new int[n1];
            int[] R = new int[n2];

            Array.Copy(arr, left, L, 0, n1);

            Array.Copy(arr, middle + 1, R, 0, n2);

            int i_idx = 0, j_idx = 0;
            int k = left;
            while (i_idx < n1 && j_idx < n2)
            {
                if (L[i_idx] <= R[j_idx])
                {
                    arr[k] = L[i_idx];
                    i_idx++;
                }
                else
                {
                    arr[k] = R[j_idx];
                    j_idx++;
                }
                k++;
            }
            while (i_idx < n1)
            {
                arr[k] = L[i_idx];
                i_idx++;
                k++;
            }
            while (j_idx < n2)
            {
                arr[k] = R[j_idx];
                j_idx++;
                k++;


            }
        }
        private int JumpSearch(int[] arr, int x)
        {
            int n = arr.Length;
            int STEP = (int)Math.Floor(Math.Sqrt(n));
            int prev = 0;

            while (arr[Math.Min(STEP, n) - 1] < x)
            {
                prev = STEP;
                STEP += (int)Math.Floor(Math.Sqrt(n));
                if (prev >= n)
                    return -1;
            }

            while (arr[prev] < x)
            {
                prev++;
                if (prev == Math.Min(STEP, n))
                    return -1;
            }
            if (arr[prev] == x)
                return prev;
            return -1;
        }

        private int InterpolationSearch(int[] arr, int x)
        {
            int low = 0;
            int high = arr.Length - 1;

            while (low <= high && x >= arr[low] && x <= arr[high])
            {
                if (low == high)
                {
                    return (arr[low] == x) ? low : -1;
                }
            }

            long pos = low + (((long)high - low) * (x - arr[low]) / (arr[high] - arr[low]));

            if (pos < low || pos > high) return -1;
            if (arr[pos] == x)
            {
                return (int)pos;
            }

            if (arr[pos] == x)
            {
                low = (int)pos + 1;

            }
            else
            {
                high = (int)pos - 1;
            }
            return -1;
        }

        
        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(tbMaximoRango.Text, out int minVal) || !int.TryParse(tbMaximoRango.Text, out int maxVal))
            {
                MessageBox.Show("Rango numérico inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btnEjecutar.Enabled = false;
            lbResultado.Items.Clear();
            lbResultado.Items.Add("Iniciando Pruebas...");
            lbResultado.Items.Add("ADVERTENCIA: La aplicación se congelará o irá lento durante el proceso");
            lbResultado.Items.Add(item: $"Rango de Datos: {minVal:N0} a {maxVal:N0}");
            Application.DoEvents();

            Stopwatch stopwatch = new Stopwatch();

            foreach (int size in sampleSizes)
            {
                lbResultado.Items.Add("------------------------------");
                lbResultado.Items.Add($"TAMAÑO: {size:N0} elementos");

                int[] originalData = new int[size];
                for (int i = 0; i < size; i++)
                {
                    originalData[i] = Rnd.Next(minVal, maxVal + 1);
                }

                lbResultado.Items.Add("---ORDENAMIENTO---");

                int[] dataSS = (int[])originalData.Clone();
                stopwatch.Restart();
                SelectionSort(dataSS);
                stopwatch.Stop();
                double timeSS = stopwatch.Elapsed.TotalMilliseconds;
                lbResultado.Items.Add($"-Selection Sort: {timeSS:N3} ms");

                int[] dataMS = (int[])originalData.Clone();
                stopwatch.Restart();
                MergeSort(dataMS);
                stopwatch.Stop();
                double timeMS = stopwatch.Elapsed.TotalMilliseconds;
                lbResultado.Items.Add($"-Merge Sort: {timeMS:N3} ms");
                lbResultado.Items.Add($" Diferencia: {Math.Abs(timeSS - timeSS)} ms");

                int indexToFind = Rnd.Next(0, size);
                int valueToFind = dataMS[indexToFind];

                lbResultado.Items.Add("---BÚSQUEDA---");
                lbResultado.Items.Add($"(Valor buscado: {valueToFind:N0})");

                stopwatch.Restart();
                JumpSearch(dataMS, valueToFind);
                stopwatch.Stop();
                double timeJS = stopwatch.Elapsed.TotalMilliseconds;
                lbResultado.Items.Add($"- Jump Search:       {timeJS:N5} ms");

                stopwatch.Restart();
                InterpolationSearch(dataMS, valueToFind);
                stopwatch.Stop();
                double timeIS = stopwatch.Elapsed.TotalMilliseconds;
                lbResultado.Items.Add($"-Búsqueda Interpolada: {timeIS:N5} ms");
                lbResultado.Items.Add($" Diferencia: {Math.Abs(timeJS - timeIS):N5} ms");
            }

            lbResultado.Items.Add("===============================================");
            lbResultado.Items.Add("PRUEBAS FINALIZADAS.");
            lbResultado.Enabled = true;
        }
    }
}
