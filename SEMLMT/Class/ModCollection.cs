using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace SEMLMT.Class
{
    /// <summary>
    /// Mod Collection
    /// </summary>
    public class ModCollection : List<ModItem>
    {

        /// <summary>
        /// コレクションURL
        /// </summary>
        private const string CollectionUrl = "http://steamcommunity.com/sharedfiles/filedetails/?id={0}";


        /// <summary>
        /// CollectionIDからmod一覧取得
        /// </summary>
        /// <param name="collectionID"></param>
        public void GetModListFromCollectionID(string collectionID)
        {
            this.Clear();

            var ndb = new Class.NonDispBrowser();
            ndb.NavigateAndWait(String.Format(CollectionUrl, collectionID));
            HtmlDocument doc = ndb.Document;

            var re = new Regex(@"SharedFileBindMouseHover\d*\(\s*[^{]+({.+})\s*\)\s*;");
#if false
SharedFileBindMouseHover( "sharedfile_693253011", false, {"id":"693253011","title":"Transporter","description":"  Transporter  ・・・","user_subscribed":false,"user_favorited":false,"played":false,"appid":244850} );
#endif

            // リンク文字列とそのURLの列挙
            foreach (HtmlElement e in doc.Body.GetElementsByTagName("SCRIPT"))
            {
                string script = e.InnerHtml;
                if (!String.IsNullOrEmpty(script))
                {
                    //System.Diagnostics.Debug.WriteLine(script);
                    MatchCollection mc = re.Matches(script);
                    foreach (Match m in mc)
                    {
                        string value = m.Groups[1].Value;
                        // System.Diagnostics.Debug.WriteLine(value);
                        var modItem = JsonConvert.DeserializeObject<ModItem>(value);
                        this.Add(modItem);
                    }
                }
            }
        }





    }
}
