﻿using Database;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Online_Course
{
    public partial class FormEditCourse : Form
    {
        ArrayList list = new ArrayList();
        ArrayList listTopic = new ArrayList();
        ArrayList listInstr = new ArrayList();

        Course course = new Course();
        Topic topic = new Topic();
        Instructor instructor = new Instructor();
        public FormEditCourse()
        {
            InitializeComponent();
        }

        private void guna2TextBoxAddIdCourse_TextChanged(object sender, EventArgs e)
        {
            if(guna2TextBoxAddIdCourse.Text.Length == 5)
            {
                list = course.QueryData("course.id", guna2TextBoxAddIdCourse.Text);
                listInstr = instructor.QueryData();
                listTopic = topic.QueryData();

                if(list.Count > 0)
                {
                    //asumsikan instruktur tidak dapat diubah
                    guna2TextBoxAddNameCourse.Text = ((Course)list[0]).Name;
                    guna2TextBoxAddDescriptionCourse.Text = ((Course)list[0]).Desc;
                    guna2TextBoxAddLanguageCourse.Text = ((Course)list[0]).Lang;
                    guna2TextBoxCost.Text = ((Course)list[0]).Price.ToString();
                    guna2ComboBoxInstr.DataSource = listInstr;
                    dateTimePickerRelease.Value = ((Course)list[0]).Release;
                    guna2ComboBoxInstr.DisplayMember = "Name";
                    guna2ComboBoxTopic.DataSource = listTopic;
                    guna2ComboBoxTopic.DisplayMember = "Name";
                    guna2ComboBoxTopic.Text = ((Course)list[0]).Topic.Name;
                    guna2ComboBoxInstr.Text = ((Course)list[0]).Instructor.Name;
                }
                else
                {
                    MessageBox.Show("Data Tidak Ditemukan", "Warning");
                }
            }
        }

        private void guna2ButtonEdit_Click(object sender, EventArgs e)
        {
            try
            {
                Topic topic = (Topic)guna2ComboBoxTopic.SelectedItem;
                Instructor instructor = (Instructor)guna2ComboBoxInstr.SelectedItem;

                Course newCourse = new Course(
                    guna2TextBoxAddIdCourse.Text,
                    guna2TextBoxAddNameCourse.Text,
                    guna2TextBoxAddDescriptionCourse.Text,
                    guna2TextBoxAddLanguageCourse.Text,
                    double.Parse(guna2TextBoxCost.Text),
                    dateTimePickerRelease.Value,
                    topic,
                    instructor);

                newCourse.Update();
                MessageBox.Show("Data Berhasil Diubah", "Info");
                guna2ButtonClear_Click(guna2ButtonEdit, e);
            }
            catch(Exception error)
            {
                MessageBox.Show($"Data Gagal Diubah, Error : {error.Message}", "Error");
            }
        }

        private void guna2ButtonClear_Click(object sender, EventArgs e)
        {
            guna2TextBoxAddIdCourse.Clear();
            guna2TextBoxAddIdCourse.Focus();
            guna2TextBoxAddNameCourse.Clear();
            guna2TextBoxAddDescriptionCourse.Clear();
            dateTimePickerRelease.Value = DateTime.Now;
            guna2TextBoxCost.Clear();
            guna2ComboBoxInstr.SelectedIndex = 0;
            guna2ComboBoxTopic.SelectedIndex = 0;
            guna2TextBoxAddLanguageCourse.Clear();
        }
    }
}