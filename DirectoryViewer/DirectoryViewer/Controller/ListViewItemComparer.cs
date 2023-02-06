using System;
using System.Collections;
using System.Windows.Forms;

namespace DirectoryViewer.Controll
{
    /// <summary>
    /// ListViewの項目の並び替えに使用するクラス
    /// </summary>
    public class ListViewItemComparer : IComparer {
        /// <summary>
        /// 比較する方法
        /// </summary>
        public enum ComparerMode {
            /// <summary>
            /// 文字列として比較
            /// </summary>
            String,
            /// <summary>
            /// 数値（Int32型）として比較
            /// </summary>
            Integer,
            /// <summary>
            /// 日時（DataTime型）として比較
            /// </summary>
            DateTime
        };

        private int column;
        private SortOrder sortOrder;
        private ComparerMode compareMode;
        private ComparerMode[] compareModes;

        /// <summary>
        /// 並び替えるListView列の番号
        /// </summary>
        public int Column {
            set {
                //現在と同じ列の時は、昇順降順を切り替える
                if (column == value) {
                    if (sortOrder == SortOrder.Ascending) {
                        sortOrder = SortOrder.Descending;
                    } else if (sortOrder == SortOrder.Descending) {
                        sortOrder = SortOrder.Ascending;
                    }
                }
                column = value;
            }
            get {
                return column;
            }
        }
        /// <summary>
        /// 昇順か降順か
        /// </summary>
        public SortOrder Order {
            set {
                sortOrder = value;
            }
            get {
                return sortOrder;
            }
        }
        /// <summary>
        /// 並び替えの方法
        /// </summary>
        public ComparerMode Mode {
            set {
                compareMode = value;
            }
            get {
                return compareMode;
            }
        }
        /// <summary>
        /// 列ごとの並び替えの方法
        /// </summary>
        public ComparerMode[] ColumnModes {
            set {
                compareModes = value;
            }
        }

        /// <summary>
        /// ListViewItemComparerクラスのコンストラクタ
        /// </summary>
        /// <param name="col">並び替える列の番号</param>
        /// <param name="ord">昇順か降順か</param>
        /// <param name="cmod">並び替えの方法</param>
        public ListViewItemComparer(
            int col, SortOrder ord, ComparerMode cmod) {
            column = col;
            sortOrder = ord;
            compareMode = cmod;
            }
        public ListViewItemComparer() {
            column = 0;
            sortOrder = SortOrder.Ascending;
            compareMode = ComparerMode.String;
        }

        //xがyより小さいときはマイナスの数、大きいときはプラスの数、
        //同じときは0を返す
        public int Compare(object x, object y) {
            if (sortOrder == SortOrder.None) {
                //並び替えない時
                return 0;
            }

            var result = 0;
            //ListViewItemの取得
            var itemx = (ListViewItem)x;
            var itemy = (ListViewItem)y;

            //並べ替えの方法を決定
            if (compareModes != null && compareModes.Length > column) {
                compareMode = compareModes[column];
            }

            //並び替えの方法別に、xとyを比較する
            switch (compareMode) {
                case ComparerMode.String:
                    //文字列をとして比較
                    result = string.Compare(itemx.SubItems[column].Text,
                                            itemy.SubItems[column].Text, StringComparison.Ordinal);
                    break;
                case ComparerMode.Integer:
                    //Int32に変換して比較
                    //.NET Framework 2.0からは、TryParseメソッドを使うこともできる
                    result = int.Parse(itemx.SubItems[column].Text.Replace(",", "")).CompareTo(
                        int.Parse(itemy.SubItems[column].Text.Replace(",", "")));
                    break;
                case ComparerMode.DateTime:
                    //DateTimeに変換して比較
                    //.NET Framework 2.0からは、TryParseメソッドを使うこともできる
                    result = DateTime.Compare(
                        DateTime.Parse(itemx.SubItems[column].Text),
                        DateTime.Parse(itemy.SubItems[column].Text));
                    break;
            }

            //降順の時は結果を+-逆にする
            if (sortOrder == SortOrder.Descending) {
                result = -result;
            }

            //結果を返す
            return result;
        }
    }
}