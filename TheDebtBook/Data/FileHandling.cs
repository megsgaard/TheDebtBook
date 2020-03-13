using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TheDebtBook.Model;

namespace TheDebtBook.Data
{
    class FileHandling
    {
        internal static void ReadFile(string fileName, out ObservableCollection<Debtor> debtors)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Debtor>));

            try
            {
                TextReader reader = new StreamReader(fileName);
                debtors = (ObservableCollection<Debtor>)serializer.Deserialize(reader);
                reader.Close();
            }
            catch (Exception e)
            {
                debtors = null;
            }
        }

        internal static void SaveFile(string fileName, ObservableCollection<Debtor> debtors)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Debtor>));
            TextWriter writer = new StreamWriter(fileName);
            serializer.Serialize(writer, debtors);
            writer.Close();
        }
    }
}
