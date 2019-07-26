﻿using Loading;
using PersonInfoManage.BLL.PersonInfo;
using PersonInfoManage.BLL.Utils;
using PersonInfoManage.Model;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

namespace PersonInfoManage
{
    public partial class PersonDetailForm : Form
    {
        private readonly int PersonId;
        private int FileId = -1;
        public PersonDetailForm(int personId)
        {
            InitializeComponent();
            PersonId = personId;
        }

        // 页面加载
        private void PersonDetailForm_Load(object sender, EventArgs e)
        {
            person_basic pb = new person_basic { id = PersonId };
            List<person_basic> list = new PersonBasicBLL().Query(pb);
            LblName.Text = list[0].name;
            ///
            /// ...
            ///
        }

        private void BtnAddFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog
            {
                Multiselect = false,
                Title = "请选择文件",
                Filter = "所有文件(*.*)|*.*"
            };

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFile.FileName;
                Result result = null;
                LoadingHelper.ShowLoading("文件上传中...", this, o =>
                {
                    //这里写处理耗时的代码，代码处理完成则自动关闭该窗口
                    PersonFileBLL personFileBLL = new PersonFileBLL();
                    result = personFileBLL.Add(PersonId, filePath);
                });

                FileStatus(result, "文件添加");
            }
        }
        
        private void BtnOutFile_Click(object sender, EventArgs e)
        {
            if (FileId == -1)
            {
                MessageBoxCustom.Show("请选择需要导出的文件！", "提示", this);
                return;
            }

            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择保存文件路径";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string foldPath = dialog.SelectedPath;
                Result result = null;
                LoadingHelper.ShowLoading("文件导出中...", this, o => 
                {
                    PersonFileBLL personFileBLL = new PersonFileBLL();

                    result = personFileBLL.OutFile(FileId, foldPath);
                    FileId = -1;
                });

                FileStatus(result, "文件导出");
            }
        }

        private void FileStatus(Result result, string title)
        {
            if (result?.Code == RES.OK)
            {
                MessageBoxCustom.Show(result.Message, title, this);
            }
            else if (result?.Code == RES.ERROR)
            {
                MessageBoxCustom.Show(result.Message, title, this);
            }
        }

        private void BtnUpdateFile_Click(object sender, EventArgs e)
        {
            //var frm = new UpdateFileName();
            //frm.ShowDialog();
            UpdateFileName updateFileNameForm = new UpdateFileName();
            updateFileNameForm.ShowDialog();

        }

        private void BtnDelFile_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBoxCustom.Show("确认删除", "提示", MessageBoxButtons.YesNo, this);
            if (res == DialogResult.Yes)
            {
                int id = 0;
                person_file file= new person_file();
                /*file.id = 0*/;
                file.person_id = 0;
                List<person_file> pf = new List<person_file>();
                pf = new PersonFileBLL().GetByPersonId(PersonId);
                List<int> file1 = new List<int>();

                foreach (var file2 in pf)
                {
                    file1.Add(file2.id);
                }
                Result result = new PersonFileBLL().Del(id);
                if (result.Code == RES.OK)
                {
                    MessageBoxCustom.Show("删除成功", "提示", MessageBoxButtons.OK, this);
                    Close();
                }
                else if (result.Code == RES.ERROR)
                {
                    MessageBoxCustom.Show("删除失败", "提示", MessageBoxButtons.OK, this);
                }
            }
        }
        
    }
}
