using System.Runtime.CompilerServices;

namespace UselessGame
{
    public partial class Form1 : Form
    {
        private Random rand = new(DateTime.Now.Millisecond * DateTime.Now.Second.GetHashCode());
        private string[,] buttonArray;
        private readonly Button buttonTemplate;
        private (int, int) cellSize;
        public Form1()
        {
            InitializeComponent();
            buttonTemplate = button1;
            cellSize = new(buttonTemplate.Width + buttonTemplate.Margin.Horizontal, buttonTemplate.Height + buttonTemplate.Margin.Vertical);
            buttonArray = new string[(Width - buttonTemplate.Margin.Horizontal) / cellSize.Item1, (Height - buttonTemplate.Margin.Vertical) / cellSize.Item2];
            for (int i = 0; i < buttonArray.GetUpperBound(0); i++)
                for (int ii = 0; ii < buttonArray.GetUpperBound(1); ii++)
                    buttonArray[i, ii] = "";       
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RandomizePos(button1);
            UpdatePositions();
        }

        private void UpdatePositions()
        {
            for (int i = 0; i < buttonArray.GetUpperBound(0); i++)
                for (int ii = 0; ii < buttonArray.GetUpperBound(1); ii++)
                {
                    if (buttonArray[i, ii] == "")
                        continue;
                    if (Controls.GetCollection().Count == 0)
                        break;
                    Control? control = Controls.GetCollection().FirstOrDefault(x => x.GetType().Equals(buttonTemplate.GetType()) && x.Name == buttonArray[i, ii]);
                    if (control is null)
                        continue;
                    control.Location = new Point(i * cellSize.Item1 + buttonTemplate.Margin.Horizontal, ii * cellSize.Item2 + buttonTemplate.Margin.Vertical);
                }
        }

        private void RandomizePos(Control control)
        {
            for (int i = 0; i < buttonArray.GetUpperBound(0); i++) 
                for (int ii = 0; ii < buttonArray.GetUpperBound(1); ii++)
                    buttonArray[i, ii] = buttonArray[i, ii] == control.Name ? "" : buttonArray[i, ii];
            int x, y;
            do
            {
                x = rand.Next(buttonArray.GetUpperBound(0));
                y = rand.Next(buttonArray.GetUpperBound(1));
            }
            while (buttonArray[x, y] != "");
            buttonArray[x, y] = control.Name;
        }

        private void RandomizePos(ICollection<Control> controls)
        {
            foreach (Control control in controls)
                RandomizePos(control);
            UpdatePositions();
        }
    }
}
