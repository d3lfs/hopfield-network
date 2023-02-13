using HopFieldNetwork.Common;
using System.Diagnostics;

namespace HopFieldNetwork
{
    public partial class Form1 : Form
    {
        private List<Button> _inputPixels;
        private List<Button> _outputPixels;
        private List<Label> _values;
        private Weights _weights;
        private NeuralNetwork _neuralNetwork;
        
        public Form1()
        {
            InitializeComponent();

            _inputPixels = new();
            _outputPixels = new();
            _values = new();
            
            _weights = new(new int[,] {
                { 0,0,2,-2,-2,-2,2,0,2 },
                { 0,0,0,0,0,0,0,2,0 },
                { 2,0,0,-2,-2,-2,2,0,2 },
                { 2,0,-2,0,2,2,-2,0,-2 },
                { 2,0,-2,2,0,2,-2,0,-2 },
                { 2,0,-2,2,2,0,-2,0,-2 },
                { 2,0,2,-2,-2,-2,0,0,2 },
                { 0,2,0,0,0,0,0,0,0 },
                { 2,0,2,-2,-2,-2,2,0,0 } 
            });

            _neuralNetwork = new(_weights.Matrix);

            _inputPixels.Add(button1);
            _inputPixels.Add(button2);
            _inputPixels.Add(button3);
            _inputPixels.Add(button4);
            _inputPixels.Add(button5);
            _inputPixels.Add(button6);
            _inputPixels.Add(button7);
            _inputPixels.Add(button8);
            _inputPixels.Add(button9);

            _inputPixels.ForEach(pixels =>
            {
                pixels.Click += (s, e) =>
                {
                    if (pixels.BackColor == Color.Black)
                        pixels.BackColor = Color.White;
                    else
                        pixels.BackColor = Color.Black;
                };
            });

            _outputPixels.Add(button10);
            _outputPixels.Add(button11);
            _outputPixels.Add(button12);
            _outputPixels.Add(button13);
            _outputPixels.Add(button14);
            _outputPixels.Add(button15);
            _outputPixels.Add(button16);
            _outputPixels.Add(button17);
            _outputPixels.Add(button18);

            _values.Add(label1);
            _values.Add(label2);
            _values.Add(label3);
            _values.Add(label4);
            _values.Add(label5);
            _values.Add(label6);
            _values.Add(label7);
            _values.Add(label8);
            _values.Add(label9);
        }

        private void Calculate_Click(object sender, EventArgs e)
        {
            _neuralNetwork.AsyncUpdate(GetInput(), 6);

            for (int i = 0; i < _outputPixels.Count; i++)
            {
                if (_neuralNetwork.Output[i] == -1)
                    _outputPixels[i].BackColor = Color.White;
                else
                    _outputPixels[i].BackColor = Color.Black;

                _values[i].Text = _neuralNetwork.OutputValues[i].ToString();
            }
        }

        private int[] GetInput()
        {
            int[] input = new int[9];
            for (int i = 0; i < _inputPixels.Count; i++)
            {
                if (_inputPixels[i].BackColor == Color.Black)
                    input[i] = 1;
                else
                    input[i] = -1;
            }

            return input;
        }
    }
}