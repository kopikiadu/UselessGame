namespace UselessGame
{
    public partial class Form1 : Form
    {
        Random rand = new(DateTime.Now.Millisecond * DateTime.Now.Second.GetHashCode());
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RandomizePos(button1);
        }

        private void RandomizePos(Control control)
        {
            int x = rand.Next(control.Margin.Left + 3, Width - (control.Margin.Right + 3 + control.Width));
            int y = rand.Next(control.Margin.Top + 3, Height - (control.Margin.Bottom + 3 + control.Height));
            control.Location = new Point(x, y);
        }
    }
}
