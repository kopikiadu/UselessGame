namespace UselessGame
{
    public partial class Form1 : Form
    {
        private Random rand = new(DateTime.Now.Millisecond * DateTime.Now.Second.GetHashCode());
        private bool[,] buttonArray;
        private Button buttonTemplate;
        private (int, int) cellSize;
        public Form1()
        {
            InitializeComponent();
            buttonTemplate = button1;
            cellSize = new(buttonTemplate.Width + buttonTemplate.Margin.Horizontal, buttonTemplate.Height + buttonTemplate.Margin.Vertical);
            buttonArray = new bool[Width / cellSize.Item1, Height / cellSize.Item2];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RandomizePos(button1);
        }

        private void RandomizePos(Control control)
        {
            int x = rand.Next();
            int y = rand.Next();
            control.Location = new Point(x, y);
        }
    }
}
