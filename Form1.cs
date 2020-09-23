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
            string pathToDelete = listBox1.SelectedItem.ToString();
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(pathToDelete);
            // Delete this dir and all subdirs.
            try
            {
                di.Delete(true);
            }
            catch (System.IO.IOException e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
            }
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
    }
}