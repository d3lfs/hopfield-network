using System.Diagnostics;

namespace HopFieldNetwork.Common
{
    public class NeuralNetwork
    {
        private Neuron[] _neurons;
        private int[] _output;
        private int[] _outputValues;

        public NeuralNetwork(int[,] j)
        {
            _output = new int[j.GetLength(0)];
            _outputValues = new int[j.GetLength(0)];
            _neurons = new Neuron[j.GetLength(0)];
            
            for (int i = 0; i < j.GetLength(0); i++)
            {
                int[] weights = new int[j.GetLength(1)];
                for (int k = 0; k < j.GetLength(1); k++)
                {
                    weights[k] = j[i, k];
                }
                _neurons[i] = new Neuron(weights);
            }
        }

        public int[] Output
        {
            get { return _output; }
            set { _output = value; }
        }

        public int[] OutputValues
        {
            get { return _outputValues; }
            set { _outputValues = value; }
        }

        public int Threshold(int k)
        {
            return k >= 0 ? 1 : -1;
        }

        public void Activation(int[] pattern)
        {
            Output = pattern;
            for (int i = 0; i < pattern.Length; i++)
            {
                _neurons[i].Activation = _neurons[i].Act(Output);
                OutputValues[i] = _neurons[i].Activation;
                Output[i] = Threshold(_neurons[i].Activation);
            }
        }
    }
}
