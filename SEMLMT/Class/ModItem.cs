using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEMLMT.Class
{
    public class ModItem
    {

        /// <summary>
        /// コレクションURL
        /// </summary>
        private const string ModUrl = "http://steamcommunity.com/sharedfiles/filedetails/?id={0}";

        [System.ComponentModel.DisplayName("ID")]
        public string id { get; set; }

        [System.ComponentModel.DisplayName("タイトル")]
        public string title { get; set; }

        [System.ComponentModel.DisplayName("説明")]
        public string description { get; set; }

        [System.ComponentModel.DisplayName("リンク")]
        public string url
        {
            get
            {
                return String.Format(ModUrl, this.id);
            }
        }

        //[System.ComponentModel.Browsable(false)]
        //public string test { get; set; }

    }
}
