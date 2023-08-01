using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment11_1
{
    public partial class Form1 : Form
    {
        CarRepository carRepository;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            carRepository = new CarRepository();
            carGrid.DataSource = carRepository.GetAll();
            carGrid.Columns[5].Visible = false;
            btnSubmit.Enabled = false;
            btnUpdate.Enabled = false;
        }

        private void Clear()
        {
            txtMake.Clear();
            txtModel.Clear();
            txtPrice.Clear();
            txtVIN.Clear();
            txtYear.Clear();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtMake.Text) && !string.IsNullOrEmpty(txtModel.Text)
                && !string.IsNullOrEmpty(txtPrice.Text) && !string.IsNullOrEmpty(txtVIN.Text) &&
                !string.IsNullOrEmpty(txtYear.Text)) 
            {
                var newCar = new Car();
                newCar.Make = txtMake.Text;
                newCar.Model = txtModel.Text;
                newCar.Price = txtPrice.Text;
                newCar.VIN = txtVIN.Text;
                newCar.Year = txtYear.Text;
                carRepository.AddRecord(newCar);
                MessageBox.Show("New car added!");
            }
            Clear();
            btnSubmit.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtMake.Clear();
            txtModel.Clear();
            txtPrice.Clear();
            txtVIN.Clear();
            txtYear.Clear();
            btnSubmit.Enabled = true;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            var id = carGrid.CurrentRow.Cells[0].Value;
            var carToUpdate = carRepository.FindCar((string)id);
            txtMake.Text = carToUpdate.Make.ToString();
            txtModel.Text = carToUpdate.Model.ToString();
            txtPrice.Text = carToUpdate.Price.ToString();
            txtVIN.Text = carToUpdate.VIN.ToString();
            txtYear.Text = carToUpdate.Year.ToString();
            btnUpdate.Enabled = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var id = txtVIN.Text;
            var carToUpdate = carRepository.FindCar(id);
            carToUpdate.VIN = txtVIN.Text;
            carToUpdate.Year = txtYear.Text;
            carToUpdate.Make = txtMake.Text;
            carToUpdate.Model = txtModel.Text;
            carToUpdate.Price = txtPrice.Text;
            carRepository.UpdateRecord(id, carToUpdate);
            MessageBox.Show("Record updated!");
            Clear();
            btnUpdate.Enabled = false;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            carGrid.DataSource = carRepository.GetAll();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var id = carGrid.CurrentRow.Cells[0].Value;
            var carToUpdate = carRepository.FindCar((string) id);
            carRepository.DeleteRecord(carToUpdate);
            MessageBox.Show("Recorded delete =/");
        }
    }
}
