using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

using System.Xml;
using System.Xml.Linq;

namespace UnePremiereApplication
{
    public partial class Form1 : Form
    {
        private string fileName;
        private static object yourXml;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
         
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

            try
            {

                string ville = string.Empty;

                com.webservicex.www.globalweather.GlobalWeather gw = new com.webservicex.www.globalweather.GlobalWeather();
                //ville = gw.GetWeather("New York", "United States");
                ville = gw.GetCitiesByCountry("Canada");
                //gw.GetCitiesByCountry(txtRecherche.ToString());

                //net.webservicex.www.airport.airport  air = new net.webservicex.www.airport.airport();
                //ville = air.GetAirportInformationByCountry(txtRecherche.ToString());
                //net.webservicex.www.country.detail.country ccc = new net.webservicex.www.country.detail.country();
                //Pays objemp = new Pays();
                //string sss = ccc.GetCountries ();


                //objemp = (Pays)CreateObject(sss, objemp);
                //string strView = CreateXML(objemp);
                //lblReponse.Text = strView;

                //XmlDocument XmlDoc = new XmlDocument();

                //XmlDoc.LoadXml(ville);
                //XmlReader xmlFile = new XmlNodeReader(XmlDoc);
                //DataSet ds = new DataSet();
                //ds.ReadXml(xmlFile);
                //dataGridView1.DataSource = ds.Tables[0];

                Pays data = new Pays();
                data.Name = "Name";
                //data.Value = 100;
                //data.SubItems = new string[] { "Item1", "Item2", "Item3" };
                XmlSerializer ser = new XmlSerializer(typeof(Pays));
                using (FileStream file = new FileStream("C:\\TEMP\\TEST.XML", FileMode.Create, FileAccess.Write))
                {
                    ser.Serialize(file, data);
                }

                WriteXML();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void btnQuitter_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public Object CreateObject(string XMLString, Object YourClassObject)
        {
            XmlSerializer oXmlSerializer = new XmlSerializer(YourClassObject.GetType());
            //The StringReader will be the stream holder for the existing XML file 
            StringReader sr = new StringReader(XMLString);

            YourClassObject = oXmlSerializer.Deserialize(sr);
            //initially deserialized, the data is represented by an object without a defined type 
            return YourClassObject;
        }
        public string CreateXML(Object YourClassObject)
        {
            XmlDocument xmlDoc = new XmlDocument();   //Represents an XML document, 
                                                      // Initializes a new instance of the XmlDocument class.          
            XmlSerializer xmlSerializer = new XmlSerializer(YourClassObject.GetType());
            // Creates a stream whose backing store is memory. 
            using (MemoryStream xmlStream = new MemoryStream())
            {
                xmlSerializer.Serialize(xmlStream, YourClassObject);
                xmlStream.Position = 0;
                //Loads the XML document from the specified string.
                xmlDoc.Load(xmlStream);
                return xmlDoc.InnerXml;
            }
        }

        public static void WriteXML( string myNamespace)
        {



            XElement xml = XElement.Load(@"testData.xml");
            XNamespace foobar = "http://foobar/webservices";
            string personId = xml.Descendants(foobar + "person_id").First().Value;

            Pays overview = new Pays();
            overview.Table = "Serialization Overview";
            System.Xml.Serialization.XmlSerializer writer =
                new System.Xml.Serialization.XmlSerializer(typeof(Pays));

            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//SerializationOverview.xml";
            System.IO.FileStream file = System.IO.File.Create(path);

            writer.Serialize(file, overview);
            file.Close();
        }

    }
}
