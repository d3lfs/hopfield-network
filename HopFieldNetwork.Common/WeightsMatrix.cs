namespace HopFieldNetwork.Common
{
    public struct Weights
    {
        private int[,] _matrix;
        public Weights(int[,] m)
        {
            _matrix = m;
        }

        public int[,] Matrix
        {
            get { return _matrix; }
            set { _matrix = value; }
        }
    }
}
