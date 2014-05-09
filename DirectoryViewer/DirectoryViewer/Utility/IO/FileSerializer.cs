using System;
using System.IO;
using System.Xml.Serialization;
using DirectoryViewer.Model;

namespace DirectoryViewer.Utility.IO {
    /// <summary>
    /// http://dobon.net/vb/dotnet/file/xmlserializer.html
    /// </summary>
    public class FileSerializer {
        public static void SerializeDataModel(string filePath, DataModel dataModel) {

            try {
                //XmlSerializerオブジェクトを作成
                //オブジェクトの型を指定する
                var serializer = new XmlSerializer(typeof(DataModel));
                //書き込むファイルを開く
                var fs = new FileStream(filePath, FileMode.Create);
                //シリアル化し、XMLファイルに保存する
                serializer.Serialize(fs, dataModel);
                //ファイルを閉じる
                fs.Close();
            } catch (Exception e) {
                Console.WriteLine(e);
            }
        }

        public static DataModel DesirializeDataModel(string filePath) {

            try {
                //保存した内容を復元する
                var serializer = new XmlSerializer(typeof(DataModel));
                var fs = new FileStream(filePath, FileMode.Open);
                var dataModel = (DataModel)serializer.Deserialize(fs);
                fs.Close();

                return dataModel;

            } catch (Exception e) {
                Console.WriteLine(e);
                return new DataModel();
            }
        }
    }
}
