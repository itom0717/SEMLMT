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
    public partial class MainMDIParent : Form
    {

        /// <summary>
        /// Sandboxファイル名
        /// </summary>
        private const string SandboxFileName = "Sandbox.sbc";

        /// <summary>
        /// basePath
        /// </summary>
        private const string SavesPath = @"SpaceEngineers\Saves";



        /// <summary>
        /// コンストラクター
        /// </summary>
        public MainMDIParent()
        {
            InitializeComponent();

            this.Text = Application.ProductName;
            
        }

        /// <summary>
        /// 終了
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 重ねて表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        /// <summary>
        /// 左右に並べて表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        /// <summary>
        /// 上下に並べて表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        /// <summary>
        /// アイコンの整列
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.ArrangeIcons);
        }

        /// <summary>
        /// すべて閉じる
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        /// <summary>
        /// バージョン情報
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new AboutBox();
            form.ShowDialog();
        }


        /// <summary>
        /// 開く
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenFile(object sender, EventArgs e)
        {
            string filename = this.ShowOpenDialog(SandboxFileName,
                                                  this.GetSaveDirectory(),
                                                  SandboxFileName + "|" + SandboxFileName,
                                                  "");
            if (String.IsNullOrEmpty(filename))
            {
                return;
            }

            //同じファイルは開かない
            foreach (Form childForm in MdiChildren)
            {
                if (childForm.GetType().Equals(typeof(SandboxForm)))
                {
                    if (System.IO.Path.GetFullPath(((SandboxForm)childForm).FileName).ToLower()
                            == System.IO.Path.GetFullPath(filename).ToLower())
                    {
                        //同じファイルなので、これをアクティブにする
                        childForm.Activate();
                    }
                }
            }


            //データ読み込み
            {
                var childForm = new SandboxForm(filename);
                childForm.MdiParent = this;
                childForm.Show();
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveFile(object sender, EventArgs e)
        {
            var activeMdiChild = this.ActiveMdiChild;
            if (activeMdiChild == null)
            {
                return;
            }
            if (!activeMdiChild.GetType().Equals(typeof(SandboxForm)))
            {
                return;
            }

            if (MessageBox.Show("上書き保存しますか？", "", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                return;
            }

            //保存処理
            ((SandboxForm)activeMdiChild).SaveData();

            MessageBox.Show("データを保存しました。");
        }


        /// <summary>
        /// 開くダイアログを表示
        /// </summary>
        /// <returns></returns>
        private string ShowOpenDialog(string defaultFilename,
                                          string defaultlDirectory,
                                          string filter,
                                          string title)
        {

            var openFileDialog = new OpenFileDialog();
            openFileDialog.FileName = defaultFilename;
            openFileDialog.InitialDirectory = defaultlDirectory;
            openFileDialog.Filter = filter;
            openFileDialog.FilterIndex = 1;
            openFileDialog.Title = title;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.CheckPathExists = true;

            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                return openFileDialog.FileName;
            }
            else
            {
                return null;
            }

        }

        /// <summary>
        /// Saveフォルダを返す
        /// </summary>
        /// <returns></returns>
        private string GetSaveDirectory()
        {
            string applicationDataPath = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string savePath = System.IO.Path.Combine(applicationDataPath, SavesPath);
            if (System.IO.Directory.Exists(savePath))
            {
                return savePath;
            }
            else
            {
                return applicationDataPath;
            }
        }

        /// <summary>
        /// MdiChildActivate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainMDIParent_MdiChildActivate(object sender, EventArgs e)
        {
            //アクティブな子フォームのタイトルを親フォームのタイトルに追加する
            if (this.ActiveMdiChild != null)
            {
                this.Text = this.ActiveMdiChild.Text + " - " + Application.ProductName;
            }
            else
            {
                this.Text = Application.ProductName;
            }
        }
    }
}
