using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace SEMLMT
{
    public partial class SandboxForm : Form
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SandboxForm(string fileName)
        {
            InitializeComponent();

            this.SandboxXML = new SandboxXML();
            this.SandboxXML.Open(fileName);

            this.Text = this.SandboxXML.GetSessionName;
        }

        /// <summary>
        /// Sandbox.sbc XMLデータ
        /// </summary>
        private SandboxXML SandboxXML { get; set; } = null;

        /// <summary>
        /// ファイル名
        /// </summary>
        public string FileName
        {
            get
            {
                return this.SandboxXML.XmlFilename;
            }
        }

        /// <summary>
        /// データ保存
        /// </summary>
        /// <param name="fileName"></param>
        public void SaveData()
        {
            this.SandboxXML.Save();
        }

    }
}
