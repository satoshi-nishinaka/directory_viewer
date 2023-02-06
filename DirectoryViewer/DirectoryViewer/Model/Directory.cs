using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DirectoryViewer.Model
{
    public class Directory
    {
        public string DirectoryPath { get; set; }
        public bool IsBrowse { get; set; }

        public override bool Equals(object obj)
        {

            //objがnullか、型が違うときは、等価でない
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var compareInstance = (Directory) obj;
            return (DirectoryPath == compareInstance.DirectoryPath);
        }

        public override int GetHashCode()
        {
            return DirectoryPath.GetHashCode();
        }
    }
}
