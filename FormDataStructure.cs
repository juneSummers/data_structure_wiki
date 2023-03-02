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

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < rowSize; i++)
            {
                if (dataStructureArray[i, 0] == "~")
                {
                    dataStructureArray[i, 0] = textBoxName.Text;
                    dataStructureArray[i, 1] = textBoxCategory.Text;
                    dataStructureArray[i, 2] = textBoxStructure.Text;
                    dataStructureArray[i, 3] = textBoxDefinition.Text;
                }

                if (i == rowSize - 1)
                {
                    MessageBox.Show("There's no space left in the array.", "Full Array");
                }
            }
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

        private void DataStructureWiki_Load(object sender, EventArgs e)
        {
            InitialiseArray();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {

        }
    }
}
