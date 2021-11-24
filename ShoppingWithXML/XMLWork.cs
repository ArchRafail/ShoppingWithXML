using System;
using System.Collections.Generic;
using System.Xml;

namespace ShoppingWithXML
{
    class XMLWork
    {
        static string filename = "Shopping.xml";
        public static void WriterXML(Receipt[] receipts)
        {
            XmlTextWriter textWriter = null;
            try
            {
                textWriter = new XmlTextWriter(filename, System.Text.Encoding.Unicode);
                textWriter.Formatting = Formatting.Indented;
                textWriter.WriteStartDocument();
                textWriter.WriteStartElement("Receipts");
                for (int i = 0; i < receipts.Length; i++)
                {
                    textWriter.WriteStartElement($"Receipt{i + 1}");
                    textWriter.WriteAttributeString("Receipt", $"{receipts[i].ReceiptNumber}");
                    textWriter.WriteAttributeString("Date", $"{receipts[i].GetTime().ToShortDateString()}");
                    textWriter.WriteStartElement("Goods");
                    int j = 1;
                    foreach (Good good in receipts[i].GetGoods())
                    {
                        textWriter.WriteStartElement($"Good{j++}");
                        textWriter.WriteAttributeString("Article", $"{good.Article}");
                        textWriter.WriteElementString("Name", $"{good.Name}");
                        textWriter.WriteElementString("Units", $"{good.GetUnits()}");
                        textWriter.WriteElementString("Price", $"{good.Price}");
                        textWriter.WriteElementString("Quantity", $"{good.Quantity}");
                        textWriter.WriteElementString("Cost", $"{good.Cost}");
                        textWriter.WriteEndElement();
                    }
                    textWriter.WriteEndElement();
                    textWriter.WriteElementString("Total_cost", $"{receipts[i].GetCost()}");
                    textWriter.WriteEndElement();
                }
                textWriter.WriteEndElement();
                Console.WriteLine($"The file [ {filename} ] is created");
                Console.WriteLine("All information about shopping was recorded.");
                Console.WriteLine("Push Enter to go forward through the program.\n");
                Console.ReadKey();
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
            finally
            {
                if (textWriter != null)
                    textWriter.Close();
            }
        }

        static void OutputNode(XmlNode node)
        {
            Console.WriteLine($"Type = {node.NodeType}\tName = {node.Name}\tValue = {node.Value}");

            if (node.Attributes != null)
            {
                foreach (XmlAttribute attr in node.Attributes)
                    Console.WriteLine($"Type = {attr.NodeType}\tName = {attr.Name}\tValue = {attr.Value}");
            }
            if (node.HasChildNodes)
            {
                foreach (XmlNode child in node.ChildNodes)
                    OutputNode(child);
            }
        }

        public static void ReaderXMLDoc()
        {
            Console.Clear();
            Console.WriteLine($"Below information was taken from the file [ {filename} ].");
            Console.WriteLine("The class was used for this task - XmlDocument.\n");
            try
            {
                XmlDocument file = new XmlDocument();
                file.Load(filename);
                OutputNode(file.DocumentElement);
                Console.WriteLine("\nPush Enter to go forward through the program.");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void ReaderXMLTxt()
        {
            XmlTextReader textReader = null;
            Console.Clear();
            Console.WriteLine($"Below information was taken from the file [ {filename} ].");
            Console.WriteLine("The class was used for this task - XmlTextReader.\n");
            try
            {
                textReader = new XmlTextReader(filename);
                textReader.WhitespaceHandling = WhitespaceHandling.None;
                while (textReader.Read())
                {
                    Console.WriteLine($"Type = {textReader.NodeType}\t\tName = {textReader.Name}\t\t" +
                        $"Value = {textReader.Value}");
                    if (textReader.AttributeCount > 0)
                        {
                            while (textReader.MoveToNextAttribute())
                            {
                                Console.WriteLine($"Type = {textReader.NodeType}\tName ={textReader.Name}\t" +
                                    $"Value ={textReader.Value}");
                            }
                        }
                }

            }

            catch (Exception ex)
            { Console.WriteLine(ex.Message); }

            finally
            {
                if (textReader != null)
                    textReader.Close();
            }
        }
    }
}
