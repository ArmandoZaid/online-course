﻿using Database;
using System;
using System.Windows.Forms;

namespace Online_Course
{
    public partial class FormLoginAdmin : Form
    {
        Session session = Session.Instance;
        public FormLoginAdmin()
        {
            InitializeComponent();
        }

        private void guna2ButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2ButtonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (guna2TextBoxUsername.Text != "" || guna2TextBoxPassword.Text != "")
                {
                    Login.AdminLogin(guna2TextBoxUsername.Text, guna2TextBoxPassword.Text);
                    session.SessionClear();
                    session.Name = "Admin";
                    session.Id = "Admin";
                    session.User = "Admin";
                    MessageBox.Show("Koneksi Berhasil", "Info");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Username atau Password Tidak Boleh Kosong", "Info");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show($"Gagal Login, Error : {error.Message}", "Error");
            }

        }

        private void FormLoginAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormLogin form = new FormLogin();
            form.FormLogin_Load(guna2ButtonLogin, e);
        }

        private void FormLoginAdmin_Load_1(object sender, EventArgs e)
        {
            guna2TextBoxUsername.Text = "o_course_admin";
            guna2TextBoxPassword.Text = "admin";
        }
    }
}
