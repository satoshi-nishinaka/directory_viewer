using System;
using System.Linq;
using System.Collections.Generic;

namespace DirectoryViewer.Utility
{
    public class FileNameFilter
    {
        private string[] Allow { get; set; }
        private FilterCase AllowFilterCase { get; set; }
        private string[] Deny { get; set; }
        private FilterCase DenyFilterCase { get; set; }
        private bool IgnoreCase { get; set; }

        private StringComparison Comparison
        {
            get { return IgnoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal; }
        }

        public static readonly string[] filterCase = new string[]{"OR条件", "AND条件"};

        public enum FilterCase
        {
            Or = 0,
            And = 1,
        }

        public FileNameFilter(string allow, FilterCase allowFilterCase, string deny, FilterCase denyFilterCase, bool ignoreCase)
        {
            if (!string.IsNullOrEmpty(allow))
            {
                Allow = allow.Split(' ').ToArray();
            }
            if (!string.IsNullOrEmpty(deny))
            {
                Deny = deny.Split(' ').ToArray();
            }

            AllowFilterCase = allowFilterCase;
            DenyFilterCase = denyFilterCase;

            IgnoreCase = ignoreCase;
        }

        /// <summary>
        /// 文字列の中に任意の文字列が存在するかどうかを返します
        /// </summary>
        /// <param name="haystack"></param>
        /// <param name="needle"></param>
        /// <returns></returns>
        private bool Find(string haystack, string needle)
        {
            return haystack.IndexOf(needle, this.Comparison) != -1;
        }

        public bool AllowFileName(string file)
        {
            // フィルターかけますよ
            if (Allow != null && Allow.Any())
            {
                // 全部含まれていればOK
                if (AllowFilterCase == FilterCase.And)
                {
                    foreach (var allow in Allow)
                    {
                        if (!Find(file, allow))
                            return false;
                    }
                }

                // 何かしら一致していればOK
                if (AllowFilterCase == FilterCase.Or)
                {
                    var isFind = false;
                    foreach (var allow in Allow)
                    {
                        if (Find(file, allow))
                        {
                            isFind = true;
                            break;
                        }
                    }
                    if (!isFind)
                        return false;

                }

            }
            if (Deny != null && Deny.Any())
            {
                // 全部含まれていればNG
                if (DenyFilterCase == FilterCase.And)
                {
                    var isFind = true;
                    foreach (var deny in Deny)
                    {
                        if (!Find(file, deny))
                        {
                            isFind = false;
                            break;
                        }
                    }
                    if (isFind)
                        return false;
                }

                // 何かしら一致していればNG
                if (DenyFilterCase == FilterCase.Or)
                {
                    foreach (var deny in Deny)
                    {
                        if (Find(file, deny))
                            return false;
                    }
                }
            }

            return true;
        }
    }
}
