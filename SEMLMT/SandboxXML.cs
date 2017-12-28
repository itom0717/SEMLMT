using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SEMLMT
{
    /// <summary>
    /// Sandbox.sbcの読み書き
    /// </summary>
    public class SandboxXML
    {
        /// <summary>
        /// XMLデータ
        /// </summary>
        private XmlDocument XmlSandbox { get; set; } = null;


        /// <summary>
        /// XMLファイル名
        /// </summary>
        public string XmlFilename { get; private set; } = "";


        /// <summary>
        /// 開く
        /// </summary>
        /// <param name="fileName"></param>
        public void Open(string fileName)
        {
            this.XmlFilename = fileName;
            this.XmlSandbox = new XmlDocument();
            this.XmlSandbox.Load(fileName);
        }


        /// <summary>
        /// 保存
        /// </summary>
        public void Save()
        {
            if (!this.IsLoaded)
            {
                //読み込んでいない場合は何もしない
                return;
            }

            //backup作成
            string bakFile = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(this.XmlFilename),
                                                    System.IO.Path.GetFileNameWithoutExtension(this.XmlFilename) + ".bak");
            System.IO.File.Copy(this.XmlFilename, bakFile, true);

            //上書き保存
#if DEBUG
            this.XmlSandbox.Save(this.XmlFilename + ".txt");
#else
            this.XmlSandbox.Save(this.XmlFilename);
#endif
        }


        /// <summary>
        /// 読み込み済か？
        /// </summary>
        private bool IsLoaded
        {
            get
            {
                if (String.IsNullOrEmpty(this.XmlFilename) || this.XmlSandbox == null)
                {
                    //読み込んでいない
                    return false;
                }
                else
                {
                    //読み込み済
                    return true;
                }
            }
        }


        /// <summary>
        /// SessionName
        /// </summary>
        public string GetSessionName
        {
            get
            {
                string sessionName = "";

                XmlNodeList sessionNameList = this.XmlSandbox.SelectNodes(@"/MyObjectBuilder_Checkpoint/SessionName");
                foreach(XmlNode sessionNameText in sessionNameList)
                {
                    sessionName = sessionNameText.InnerText;
                    break;
                }
                return sessionName;
            }

        }



        /// <summary>
        /// MOD LIST
        /// </summary>
        public List<string> ModList
        {
            get
            {
                List<string> modIDList = new List<string>();

                XmlNodeList modsList = this.XmlSandbox.SelectNodes(@"/MyObjectBuilder_Checkpoint/Mods");
                foreach(XmlNode mods in modsList)
                {
                    XmlNodeList modItemList = mods.SelectNodes(@"./ModItem");
                    foreach(XmlNode modItem in modItemList)
                    {
                        XmlNodeList publishedFileIdList = modItem.SelectNodes(@"./PublishedFileId");
                        foreach(XmlNode publishedFileId in publishedFileIdList)
                        {

                            modIDList.Add(publishedFileId.InnerText);
                        }
                    }
                }
                return modIDList;
            }
            set
            {
#if false
                <ModItem>
                    <Name>440438786.sbm</Name>
                    <PublishedFileId>440438786</PublishedFileId>
                </ModItem>
#endif

                XmlNodeList nodeListMods = this.XmlSandbox.SelectNodes(@"/MyObjectBuilder_Checkpoint/Mods");
                XmlElement elmMods;

                if (nodeListMods.Count >= 1)
                {
                    //すでに存在するので一旦消去
                    elmMods = (XmlElement)nodeListMods.Item(0);
                    elmMods.RemoveAll();
                }
                else
                {
                    //存在しないので新しいデータを作成
                    elmMods = this.XmlSandbox.CreateElement(@"Mods");

                    XmlNodeList root = this.XmlSandbox.SelectNodes(@"/MyObjectBuilder_Checkpoint");
                    root.Item(0).AppendChild(elmMods);
                }

                foreach(string id in value)
                {
                    XmlElement elmModItem = this.XmlSandbox.CreateElement(@"ModItem");
                    elmMods.AppendChild(elmModItem);

                    XmlElement elmName = this.XmlSandbox.CreateElement(@"Name");
                    elmModItem.AppendChild(elmName);

                    XmlNode nodeName = this.XmlSandbox.CreateNode(XmlNodeType.Text, "", "");
                    nodeName.Value = id + ".sbm";
                    elmName.AppendChild(nodeName);

                    XmlElement elmPublishedFileId = this.XmlSandbox.CreateElement(@"PublishedFileId");
                    elmModItem.AppendChild(elmPublishedFileId);

                    XmlNode nodePublishedFileId = this.XmlSandbox.CreateNode(XmlNodeType.Text, "", "");
                    nodePublishedFileId.Value = id;
                    elmPublishedFileId.AppendChild(nodePublishedFileId);
                }

            }
        }
    }
}
