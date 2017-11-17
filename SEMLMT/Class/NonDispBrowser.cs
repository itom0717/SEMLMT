using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;


namespace SEMLMT.Class
{
    /// <summary>
    /// Webからデータを取得する
    /// </summary>
    public class NonDispBrowser : WebBrowser
    {

        /// <summary>
        /// タイムアウト時間
        /// </summary>
        private TimeSpan Timeout { get; set; } = new TimeSpan(0, 0, 10);//10秒に設定

        /// <summary>
        /// 対象のURLページ化確認用
        /// </summary>
        private bool IsTargetpage { get; set; } = false;



        /// <summary>
        /// コンストラクタ
        /// </summary>
        public NonDispBrowser()
        {
            /// 実行エラーとなるスクリプト(Javascript)の場合
            /// エラーダイアログが表示されないように抑制する
            this.ScriptErrorsSuppressed = true;
        }

        /// <summary>
        /// ポップアップウィンドウを抑制する
        /// </summary>
        /// <param name="">なし</param>
        protected override void OnNewWindow(CancelEventArgs e)
        {
            e.Cancel = true;
        }

        /// <summary>
        /// フレームの場合はフレームごとにこのメソッドが実行されるため実際のURLを確認
        /// </summary>
        /// <param name="">なし</param>
        protected override void OnDocumentCompleted(WebBrowserDocumentCompletedEventArgs e)
        {
            if (e.Url == this.Url)
            {
                this.IsTargetpage = true;
            }
        }

        /// <summary>
        /// 指定したWEBページの取得
        /// 取得完了までWaitします
        /// </summary>
        /// <param name="">なし</param>
        public bool NavigateAndWait(string url)
        {
            base.Navigate(url); // ページの移動

            this.IsTargetpage = false;
            DateTime start = DateTime.Now;

            while (this.IsTargetpage == false)
            {
                if (DateTime.Now - start > this.Timeout)
                {
                    // タイムアウト
                    return false;
                }
                Application.DoEvents();
            }
            return true;
        }
    }






}
