using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DirectoryViewer.Utility;

namespace DirectoryViewer.Model
{
    public class DataModel
    {

        public List<BrowseDirectoryModel> BrowseDirectories { get; set; }

        [System.Xml.Serialization.XmlIgnore]
        public List<FileModel> FileList { get; set; }

        [System.Xml.Serialization.XmlIgnore]
        public string Allow { get; set; }

        public FileNameFilter.FilterCase AllowFilter { get; set; }

        [System.Xml.Serialization.XmlIgnore]
        public string Deny { get; set; }

        public FileNameFilter.FilterCase DenyFilter { get; set; }

        public List<string> AllowHistory { get; set; }
        public List<string> DenyHistory { get; set; }

        public bool IgnoreCase { get; set; }


        /// <summary>
        /// コンストラクタ
        /// </summary>
        public DataModel()
        {
            BrowseDirectories = new List<BrowseDirectoryModel>();
            FileList = new List<FileModel>();
            AllowHistory = new List<string>();
            DenyHistory = new List<string>();
        }

        /// <summary>
        /// BrowseDirectoryの追加
        /// すでに存在する場合はFalse, 新しく追加できた場合はTrue
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddBrowseDirectory(BrowseDirectoryModel model)
        {
            if (!BrowseDirectories.Contains(model))
            {
                BrowseDirectories.Add(model);
                return true;
            }

            return false;
        }

        public void AddAllowHistory(string text)
        {
            text = text.Trim();
            if(string.IsNullOrEmpty(text))
                return;

            if (AllowHistory.Contains(text))
            {
                // 既に存在する場合は削除して先頭にInsert
                AllowHistory.Remove(text);
            }
                AllowHistory.Insert(0, text);
        }

        public void AddDenyHistory(string text)
        {
            text = text.Trim();
            if (string.IsNullOrEmpty(text))
                return;

            if (DenyHistory.Contains(text))
            {
                // 既に存在する場合は削除して先頭にInsert
                DenyHistory.Remove(text);
            }
            DenyHistory.Insert(0, text);
        }
    }
}