using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DirectoryViewer.Utility.Image;

namespace DirectoryViewer.Model
{
    public class File
    {
        public string FullPath { get; set; }
        public string FileName { get; set; }
        public string Extention { get; set; }
        public long FileSize { get; set; }
        public string DirectoryPath { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        private bool? isImageFile = null;

        public ListViewItem ToListViewItem()
        {
            var listViewItem = new ListViewItem {Text = FileName};
            listViewItem.SubItems.AddRange(new string[]
                {
                    Extention,
                    FileSize.ToString("#,0"),
                    CreatedDate.ToString("yyyy/MM/dd HH:mm:ss"),
                    UpdatedDate.ToString("yyyy/MM/dd HH:mm:ss"),
                    DirectoryPath,
                });
            return listViewItem;
        }

        public bool IsImageFile
        {
            get
            {
                if (isImageFile == null)
                    isImageFile = ImageUtility.IsImageFile(FullPath);
                return isImageFile.Value;
            }
        }

        public override bool Equals(object obj)
        {
            // objがnullか、型が違うときは、等価でない
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var compareInstance = (File) obj;
            return (DirectoryPath == compareInstance.DirectoryPath && FileName == compareInstance.FileName);
        }

        public override int GetHashCode()
        {
            // XOR
            return DirectoryPath.GetHashCode() ^ FileName.GetHashCode();
        }

        public static readonly ColumnHeader[] listViewColumnHeaders =
            {
                new ColumnHeader {Text = @"ファイル名", Name = "ファイル名", TextAlign = HorizontalAlignment.Left},
                new ColumnHeader {Text = @"拡張子", Name = "拡張子", TextAlign = HorizontalAlignment.Left},
                new ColumnHeader {Text = @"ファイルサイズ", Name = "ファイルサイズ", TextAlign = HorizontalAlignment.Right},
                new ColumnHeader {Text = @"作成日時", Name = "作成日時", TextAlign = HorizontalAlignment.Left},
                new ColumnHeader {Text = @"更新日時", Name = "更新日時", TextAlign = HorizontalAlignment.Left},
                new ColumnHeader {Text = @"ディレクトリ", Name = "ディレクトリ", TextAlign = HorizontalAlignment.Left},
            };
    }
}