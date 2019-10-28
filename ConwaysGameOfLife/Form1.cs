using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ConwaysGameOfLife
{
    public partial class Form1 : Form
    {
        public static List<Button> buttons = new List<Button>();
        private static List<Cell> cells = new List<Cell>();
        internal static List<Cell> Cells { get => cells; set => cells = value; }
        public Form1()
        {
            InitializeComponent();
            for (int i = 1; i < 100; i++)
            {
                buttons.Add((Button)this.Controls.Find(("button" + i), true)[0]);
                Cells.Add(new Cell(i));
            }
            Random random = new Random();
            for (int i = 0; i < 50; i++)
            {
                int num = random.Next(0, cells.Count - 1);
                cells[num].status = 1;
                buttons[num].BackColor = Color.Red;
            }
            System.Windows.Forms.Timer timer = new Timer();
            timer.Interval = 2000;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < cells.Count; i++)
            {
                cells[i].checkNeighbors();
                //buttons[i].Text = cells[i].aliveNeighbors.ToString();
                cells[i].changeStatus();
                if (cells[i].status == 1)
                {
                    buttons[i].BackColor = Color.Red;
                }
                else
                {
                    buttons[i].BackColor = Color.White;
                }
            }
        }
    }
}
