using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CATANA_Week06_Work05
{
    public partial class ucProductListing : UserControl
    {
        public ucProductListing()
        {
            InitializeComponent();
        }
        string[] units = { "Piece", "Box", "Kilogram", "Liter", "cm", "ft", "g", "lb", "in", "L", "m", "oz" };

        List<string> shoppingList = new List<string>();
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblDescription_Click(object sender, EventArgs e)
        {

        }

        private void lblPrompt_Click(object sender, EventArgs e)
        {
            lblPrompt.Text = "";
            lblPrompt.Visible = false;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ucProductListing_Load(object sender, EventArgs e)
        {
            cmbUnit.Items.AddRange(units);
            cmbUnit.SelectedIndex = 0;

            updateGUI();
        }

        private void updateGUI()
        {
            lblItems.DataSource = null;
            lblItems.DataSource = shoppingList;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string item = txtDescription.Text.Trim();
            string unit = cmbUnit.SelectedItem?.ToString();

            if (!double.TryParse(txtAmount.Text, out double amount))
            {
                MessageBox.Show("Please enter a valid amount.");
                txtAmount.Focus();
                return;
            }

            if (!string.IsNullOrEmpty(unit) && !string.IsNullOrEmpty(item))
            {
                string row = $"{item}\t\t {amount} {unit}";
                shoppingList.Add(row);
                updateGUI();

                MessageBox.Show("Item Added");
                txtAmount.Clear();
                txtDescription.Clear();
                cmbUnit.SelectedIndex = 0;
                txtDescription.Focus();
            }
            else
            {
                MessageBox.Show("Please enter an item description.");
                txtDescription.Focus();
            }
        }

        private void lblItems_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int index = lblItems.SelectedIndex;

            if (index != -1)
            {
                DialogResult deleteMessage = MessageBox.Show("Are you sure you want to " +
                                            "delete?", "Delete Confirmation", MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Question);

                MessageBox.Show(shoppingList[index] + " deleted.");

                shoppingList.RemoveAt(index);
                updateGUI();

            }
            else
            {
                lblPrompt.Text = "Please select an item to delete.";
                lblPrompt.Visible = true;


            }
        }

    }
}