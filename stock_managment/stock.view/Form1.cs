using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using stock_managment.stock.model;
using stock_managment.stock.dao;

namespace stock_managment
{
    public partial class Form1 : Form
    {
        string selecteId;

        public Form1()
        {
            InitializeComponent();
        }

        private void clear_fields()
        {
            txtName.Clear();
            txtUsername.Clear();
            txtSenha.Clear();
            cbStatus.SelectedIndex = 0;
            cbRole.SelectedIndex = 0;
        }

        private void enable_fields()
        {
            txtName.Enabled = true;
            txtUsername.Enabled = true;
            txtSenha.Enabled = true;
            cbStatus.Enabled = true;
            cbRole.Enabled = true;

            btnSalvar.Enabled = true;
            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;
            btnCancelar.Enabled = true;
        }

        private void desable_fields()
        {
            //desabilita campos
            txtName.Enabled = false;
            txtUsername.Enabled = false;
            txtSenha.Enabled = false;
            cbStatus.Enabled = false;
            cbRole.Enabled = false;

            //desabilita botoes
            btnSalvar.Enabled = false;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            btnCancelar.Enabled = false;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            cbStatus.SelectedIndex = 0;
            cbRole.SelectedIndex = 0;

            UserDao userDao = new UserDao();
            Grid.DataSource = userDao.GetAll();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Confirma a exclusao?", "Excluir", MessageBoxButtons.YesNo);
            if(result == DialogResult.Yes)
            {
                UserDao userDao = new UserDao();
                userDao.Delete(this.selecteId);

                this.clear_fields();
                this.desable_fields();

                Grid.Rows.Remove(Grid.CurrentRow);
            }
            tabUsuario.SelectedTab = tabPage2;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            User user = new User
            {
                Name = txtName.Text,
                Username = txtUsername.Text,
                Status = cbStatus.Text,
                Role = cbRole.Text,
                Password = txtSenha.Text
            };

            UserDao userDao = new UserDao();    
            userDao.Create(user);

            this.clear_fields();
            this.desable_fields();

            Grid.DataSource = userDao.GetAll();

            tabUsuario.SelectedTab = tabPage2;

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            this.clear_fields();
            this.enable_fields();
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;

            tabUsuario.SelectedTab = tabPage1;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            User user = new User
            {
                Name = txtName.Text,
                Username = txtUsername.Text,
                Status = cbStatus.Text,
                Role = cbRole.Text,
                Password = txtSenha.Text
            };

            UserDao userDao = new UserDao();
            userDao.Edit(user, this.selecteId);

            this.clear_fields();
            this.desable_fields();

            Grid.DataSource = userDao.GetAll();

            tabUsuario.SelectedTab = tabPage2;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.clear_fields();
            this.desable_fields();

            tabUsuario.SelectedTab=tabPage2;
        }

        private void cbRole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            selecteId = Grid.CurrentRow.Cells[0].Value.ToString();
            txtName.Text = Grid.CurrentRow.Cells[1].Value.ToString();
            txtUsername.Text = Grid.CurrentRow.Cells[2].Value.ToString();
            cbStatus.Text = Grid.CurrentRow.Cells[3].Value.ToString();
            cbRole.Text = Grid.CurrentRow.Cells[4].Value.ToString();
            txtSenha.Text = Grid.CurrentRow.Cells[5].Value.ToString();

            tabUsuario.SelectedTab = tabPage1;
            this.enable_fields();
            btnSalvar.Enabled = false;
        }

        private void textPesquisar_TextChanged(object sender, EventArgs e)
        {
            string name = "%" +txtPesquisar.Text+ "%";
            UserDao userDao = new UserDao();
            Grid.DataSource = userDao.Search_by_name(name);
        }
    }
}
