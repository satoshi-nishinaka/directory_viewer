using System;
using System.IO;
using System.Xml.Serialization;
using DirectoryViewer.Model;

namespace DirectoryViewer.Utility.IO {
    /// <summary>
    /// http://dobon.net/vb/dotnet/file/xmlserializer.html
    /// </summary>
    public class FileSerializer {
        public static void SerializeCondition(string filePath, SearchCondition condition) {

            try {
                //XmlSerializerオブジェクトを作成
                //オブジェクトの型を指定する
                var serializer = new XmlSerializer(typeof(SearchCondition));
                //書き込むファイルを開く
                var fs = new FileStream(filePath, FileMode.Create);
                //シリアル化し、XMLファイルに保存する
                serializer.Serialize(fs, condition);
                //ファイルを閉じる
                fs.Close();
            } catch (Exception e) {
                Console.WriteLine(e);
            }
        }

        public static SearchCondition DesirializeCondition(string filePath) {

            try {
                //保存した内容を復元する
                var serializer = new XmlSerializer(typeof(SearchCondition));
                var fs = new FileStream(filePath, FileMode.Open);
                var condition = (SearchCondition)serializer.Deserialize(fs);
                fs.Close();

                return condition;

            } catch (Exception e) {
                Console.WriteLine(e);
                return new SearchCondition();
            }
        }
    }
}
