namespace HopFieldNetwork.Common
{
    public struct Neuron
    {
        private int[] _weights;
        private int _activation;

        public Neuron(int[] j)
        {
            _weights = j;
            _activation = 0;
        }

        public int[] Weights
        {
            get { return _weights; }
            set { _weights = value; }
        }

        public int Activation
        {
            get { return _activation; }
            set { _activation = value; }
        }

        public int Act(int[] input)
        {
            int sum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                sum += input[i] * _weights[i];
            }
            return sum;
        }
    }
}