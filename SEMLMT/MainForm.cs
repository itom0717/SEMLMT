using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEMLMT
{
    public partial class MainForm : Form
    {
        public MainForm()
        {

            ///旧バージョンの設定値を引き継ぐ
            if (Properties.Settings.Default.UpdateRequired)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.UpdateRequired = false;
                Properties.Settings.Default.Save();
            }

            InitializeComponent();
        }

        /// <summary>
        /// Form Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            //前回の値を表示させる
            this.CollectionIDTextBox.Text = Properties.Settings.Default.CollectionID;
        }

        /// <summary>
        /// Form Closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //入力値の記憶
            Properties.Settings.Default.CollectionID = this.CollectionIDTextBox.Text;



            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// 終了
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// リスト取得
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetCollectionMODListButton_Click(object sender, EventArgs e)
        {
            string collectionID = this.CollectionIDTextBox.Text;
            if(collectionID.Trim() == "")
            {
                MessageBox.Show(this.CollectionIDLabel.Text + "を入力してください。");
                return;
            }

            var modList = new Class.ModCollection();
            modList.GetModListFromCollectionID(collectionID);
            if(modList.Count == 0)
            {
                MessageBox.Show("MOD一覧を取得できません。");
                return;
            }

            this.CollectionMODListDataGridView.DataSource = modList;






        }




















    }
}
