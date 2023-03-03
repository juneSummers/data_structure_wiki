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

        //variables that store the 2d array's row and column size.
        static int rowSize = 12;
        static int columnSize = 4;

        string[,] dataStructureArray = new string[rowSize, columnSize];

        private void textBoxName_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var result = MessageBox.Show("Clear all fields for this record?", "Clear Record Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                ClearTextBoxes();
            }
        }

        private void ClearTextBoxes()
        {
            textBoxName.Clear();
            textBoxCategory.Clear();
            textBoxStructure.Clear();
            textBoxDefinition.Clear();
        }

        private void ArraySort()
        {
            for (int i = 0; i < rowSize; i++)
            {
                for (int j = i + 1; j < rowSize; j++)
                {
                    if (string.CompareOrdinal(dataStructureArray[i, 0], dataStructureArray[j, 0]) > 0)
                    {
                        ArraySwap(i, j);
                    }
                }
                
            }
        }

        private void ArraySwap(int index1, int index2)
        {
            //Loop through each element in the column of the 2d array and swap the values
            for (int i = 0; i < columnSize; i++)
            {
                string tempString = dataStructureArray[index1, i];
                dataStructureArray[index1, i] = dataStructureArray[index2, i];
                dataStructureArray[index2, i] = tempString;
            }
        }

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
                    break;
                }

                if (i == rowSize - 1)
                {
                    MessageBox.Show("There's no space left in the array.", "Full Array");
                }
            }

            ArraySort();
            DisplayDataStructureArray();
        }

        //For the edit and delete buttons, first check if there is anything selected in the ViewList before proceeding
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listViewRecords.SelectedIndices.Count > 0)
            {
                int currentRecord = listViewRecords.SelectedIndices[0];

                dataStructureArray[currentRecord, 0] = textBoxName.Text;
                dataStructureArray[currentRecord, 1] = textBoxCategory.Text;
                dataStructureArray[currentRecord, 2] = textBoxStructure.Text;
                dataStructureArray[currentRecord, 3] = textBoxDefinition.Text;

                ArraySort();
                DisplayDataStructureArray();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            //Show message asking the user if they want to delete the record in case the button is clicked accidently.
            //If they confirm, reset the record
            if (listViewRecords.SelectedIndices.Count > 0)
            {
                var result = MessageBox.Show("Are you sure you want to delete this record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    int currentRecord = listViewRecords.SelectedIndices[0];

                    dataStructureArray[currentRecord, 0] = "~";
                    dataStructureArray[currentRecord, 1] = "";
                    dataStructureArray[currentRecord, 2] = "";
                    dataStructureArray[currentRecord, 3] = "";

                    ArraySort();
                    DisplayDataStructureArray();
                }
            }
        }

        private void listViewRecords_MouseClick(object sender, MouseEventArgs e)
        {
            int currentRecord = listViewRecords.SelectedIndices[0];

            textBoxName.Text = dataStructureArray[currentRecord, 0];
            textBoxCategory.Text = dataStructureArray[currentRecord, 1];
            textBoxStructure.Text = dataStructureArray[currentRecord, 2];
            textBoxDefinition.Text = dataStructureArray[currentRecord, 3];
        }
        private void DisplayDataStructureArray()
        {
            listViewRecords.Items.Clear();

            for (int i = 0; i < rowSize; i ++)
            {
                if (dataStructureArray[i, 0] != "~")
                {
                    ListViewItem currentItem = new ListViewItem(dataStructureArray[i, 0]);
                    currentItem.SubItems.Add(dataStructureArray[i, 1]);
                    listViewRecords.Items.Add(currentItem);
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
            DisplayDataStructureArray();
        }

    }
}
