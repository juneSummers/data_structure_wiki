using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wikiPrototype
{
    
    public partial class DataStructureWiki : Form
    {
     
        public DataStructureWiki()
        {
            InitializeComponent();
        }

        static int rowSize = 12;

        static int columnSize = 4;

        string[,] dataStructureArray = new string[rowSize, columnSize];

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void InitialiseArray()
        {
            for(int i = 0; i < rowSize; i++)
            {
                dataStructureArray[i, 0] = "~"; //Name
                dataStructureArray[i, 1] = ""; //Category
                dataStructureArray[i, 2] = ""; //Structure
                dataStructureArray[i, 3] = ""; //Definition
            }
        }
    }
}
