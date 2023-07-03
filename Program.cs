using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;


    class Program
    {

 
    
    static void Main()
        {
            string inputFile = "C:/Projet/ISAE/Source/SCENTIF_OTAO/oato_originaux/export_oatao_HDR_memoire_brevet_rapport_et_autres_86_XML.xml";
            string outputFile = "C:/Projet/ISAE/Source/SCENTIF_OTAO/oato_valide/auteurs/export_auteurs_all_valide.xml";
        string groupedFile = "C:/Projet/ISAE/Source/SCENTIF_OTAO/oato_valide/auteurs/export_auteurs_all_invalide.xml";
        XDocument xmlDoc = XDocument.Load(groupedFile); // Replace with your XML file path


        var duplicateRecords = xmlDoc.Root
             .Elements("record")
             .GroupBy(x => (string)x.Attribute("id"))
             .Where(g => g.Count() > 1)
             .SelectMany(g => g.Skip(1));


        foreach (var record in duplicateRecords.ToList())
        {
            record.Remove();
        }



        xmlDoc.Save(outputFile);
        Console.WriteLine("La transformation a été effectuée avec succès.");
/*
        XmlDocument doc = new XmlDocument();
            doc.Load(inputFile);
            XmlNode root = doc.DocumentElement;
            XmlNodeList eprintNodes = root.SelectNodes("//eprint/creators/item");
        // Parcourir chaque noeud "data"
        foreach (XmlNode eprintNode in eprintNodes)
            {
                XmlNodeList childNodes = eprintNode.ChildNodes;

              
                XmlNode familyNode = eprintNode.SelectSingleNode("name/family");
                XmlNode givenNode = eprintNode.SelectSingleNode("name/given");
                XmlNode ppnNode = eprintNode.SelectSingleNode("ppn");
                if (ppnNode != null)
                {
                XmlNode recordNode = doc.CreateElement("record");

                XmlAttribute nativeIdAttribute = doc.CreateAttribute("id");

                    nativeIdAttribute.Value = ppnNode.InnerText;
                    recordNode.Attributes.Append(nativeIdAttribute);
                    recordNode.InnerXml = $"<recordtype code=\"auteur\">{"AUTEUR"}</recordtype>";

                    XmlNode auteurFieldNode = doc.CreateElement("field");
                    XmlAttribute auteurIdAttribute = doc.CreateAttribute("id");
                    auteurIdAttribute.Value = "nom";
                    auteurFieldNode.Attributes.Append(auteurIdAttribute);

                XmlNode ppnFieldNode = doc.CreateElement("field");
                XmlAttribute ppnIdAttribute = doc.CreateAttribute("id");
                ppnIdAttribute.Value = "ppn";
                ppnFieldNode.Attributes.Append(ppnIdAttribute);

                if (familyNode != null && givenNode != null)
                    {
                        auteurFieldNode.InnerText = familyNode.InnerText + " " + givenNode.InnerText;
                        

                    }
                    else if (familyNode != null)
                    {
                        auteurFieldNode.InnerText = familyNode.InnerText;

                    }
                    else
                    {
                        auteurFieldNode.InnerText = givenNode.InnerText;

                    }
                ppnFieldNode.InnerText = ppnNode.InnerText;
                recordNode.AppendChild(auteurFieldNode);
                recordNode.AppendChild(ppnFieldNode);
                root.AppendChild(recordNode);

            }
        }

        XmlNodeList eprints = root.SelectNodes("//eprint");


        // Parcourir chaque noeud "data"
        foreach (XmlNode eprintNode in eprints)
        {
            root.RemoveChild(eprintNode);
        }

        doc.Save(outputFile);

       
      */



    }

}





