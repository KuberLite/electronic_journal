﻿using electronic_journal.Forms;
using electronic_journal.Interfaces;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace electronic_journal.AdministratorForm
{
    public partial class AdminForm : Form, IConnection, IDataGridModes
    {
        private readonly string connectionString;

        public AdminForm()
        {
            InitializeComponent();
            MaximizeBox = false;
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            LoadDataGrid();
        }

        public SqlConnection ConnectionSQL()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            return sqlConnection;
        }

        public SqlDataAdapter SqlDataAdapter(string query, SqlConnection sqlConnection)
        {
            SqlDataAdapter sqlData = new SqlDataAdapter(query, ConnectionSQL());
            return sqlData;
        }

        public SqlDataAdapter SqlDataAdapter(SqlCommand sqlCommand)
        {
            SqlDataAdapter sqlData = new SqlDataAdapter(sqlCommand);
            return sqlData;
        }

        #region DataGridModes
        public void DataGridMode()
        {
            DataGridAligment(resultDataGrid);
            DataGridAllowUserToAddRows(resultDataGrid);
            DataGridAllowUserToResize(resultDataGrid);
            DataGridColumnsSize(resultDataGrid);
            DataGridReadOnly(resultDataGrid);
            DataGridRowHeadersVisible(resultDataGrid);
        }

        public void DataGridAligment(DataGridView dataGridView)
        {
            dataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        public void DataGridAllowUserToAddRows(DataGridView dataGridView)
        {
            dataGridView.AllowUserToAddRows = false;
        }

        public void DataGridAllowUserToResize(DataGridView dataGridView)
        {
            dataGridView.AllowUserToResizeColumns = false;
            dataGridView.AllowUserToResizeRows = false;
        }

        public void DataGridColumnsSize(DataGridView dataGridView)
        {
            
        }

        public void DataGridReadOnly(DataGridView dataGridView)
        {
            dataGridView.ReadOnly = true;
        }

        public void DataGridRowHeadersVisible(DataGridView dataGridView)
        {
            dataGridView.RowHeadersVisible = false;
        }
        #endregion

        private void LoadDataGrid()
        {
            DataTable dataTable = new DataTable();
            SqlCommand sqlCommand = new SqlCommand("SelectAllFromTimeUpdateForAdminForm", ConnectionSQL());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter(sqlCommand).Fill(dataTable);
            resultDataGrid.DataSource = dataTable;
            DataGridMode();
            resultDataGrid.Columns[0].Width = 200;
            resultDataGrid.Columns[1].Width = 340;
            resultDataGrid.Columns[2].Width = 95;
        }

        private void progressButton_Click(object sender, EventArgs e)
        {
            ProgressForm progress = new ProgressForm();
            progress.ShowDialog();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            EditAllForm editAllForm = new EditAllForm();
            editAllForm.ShowDialog();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm login = new LoginForm();
            login.Show();
        }

        private void showDataButton_Click(object sender, EventArgs e)
        {
            ShowDataForm showDataForm = new ShowDataForm();
            showDataForm.Show();
        }

        private void AdminForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void showRequestButton_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            SqlCommand sqlCommand = new SqlCommand("ShowAllRequest", ConnectionSQL());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter(sqlCommand).Fill(dataTable);
            resultDataGrid.DataSource = dataTable;
            DataGridMode();
            resultDataGrid.Columns[0].Width = 310;
            resultDataGrid.Columns[1].Width = 340;
        }

        private void showEditButton_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            SqlCommand sqlCommand = new SqlCommand("SelectAllFromTimeUpdateForAdminForm", ConnectionSQL());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter(sqlCommand).Fill(dataTable);
            resultDataGrid.DataSource = dataTable;
            DataGridMode();
            resultDataGrid.Columns[0].Width = 200;
            resultDataGrid.Columns[1].Width = 340;
            resultDataGrid.Columns[2].Width = 95;
        }
    }
}