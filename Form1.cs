using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Folder_Removal_Tool
{
    public partial class MainFRT : Form
    {
        public MainFRT()
        {
            InitializeComponent();
            listBox1.MouseDoubleClick += new MouseEventHandler(listBox1_DoubleClick);

        }

        public void addItemToListBox(string item)
        {
            if (this.listBox1.Items.Contains(item))
            {
                MessageBox.Show("Selected folder is already added to the list.");
            }
            
            else
            {
                listBox1.Items.Add(item);
            }
           
        }


        public void removeItemFromList(string selectedItem)
        {
            listBox1.Items.Remove(selectedItem);
        }

        public void deleteAll()
        {

            foreach (string folderPath in listBox1.Items)
            {
                // MessageBox.Show(folderPath);
                // Create a new DirectoryInfo object.
               // string i = listBox1.Items[0] as string;
                // Delete this dir and all subdirs.
                try
                {
                    System.IO.DirectoryInfo di = new DirectoryInfo(folderPath);
                    di.Delete(true);

                }
                catch (System.IO.IOException e)
                {
                    System.Windows.Forms.MessageBox.Show(e.Message);
                }

            }

            listBox1.Items.Clear();


        }


        private void Button1_Click(object sender, EventArgs e)
        {
            using FolderBrowserDialog fldrDlg = new FolderBrowserDialog();
            if (fldrDlg.ShowDialog() == DialogResult.OK)
            {
                string selectedPath = fldrDlg.SelectedPath;
                string ptf = selectedPath;
               // System.Windows.Forms.MessageBox.Show(ptf);
                addItemToListBox(ptf);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                System.Windows.Forms.MessageBox.Show("Select the folder that you want to remove from the list.");
                return;
            }
            
            else
            {
                string selectedItem = listBox1.SelectedItem.ToString();
                removeItemFromList(selectedItem);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            deleteAll();
        }

        public void listBox1_DoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.listBox1.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                MessageBox.Show(listBox1.SelectedItem.ToString());
                string folderToOpen = listBox1.SelectedItem.ToString();
                System.Diagnostics.Process.Start(Environment.GetEnvironmentVariable("WINDIR") + @"\explorer.exe", folderToOpen);
            }
        }


    }
}