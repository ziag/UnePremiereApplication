using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using clsPays;
using System.Xml;

namespace UnePremiereApplication
{
    public partial class Form1 : Form
    {
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
                ville = gw.GetWeather("New York", "United States");
                //ville = gw.GetCitiesByCountry(txtRecherche.ToString());
                    //gw.GetCitiesByCountry(txtRecherche.ToString());

                //net.webservicex.www.airport.airport  air = new net.webservicex.www.airport.airport();
                //ville = air.GetAirportInformationByCountry(txtRecherche.ToString());
                //net.webservicex.www.country ccc = new net.webservicex.www.country();
                //Pays objemp = new Pays();
                //string sss = ccc.GetCountries();


                //objemp = (Pays)CreateObject(sss, objemp);
                //string strView = CreateXML(objemp);
                //lblReponse.Text = strView;

                XmlDocument XmlDoc = new XmlDocument();

                XmlDoc.LoadXml(ville);
                XmlReader xmlFile = new XmlNodeReader(XmlDoc);
                DataSet ds = new DataSet();
                ds.ReadXml(xmlFile);
                dataGridView1.DataSource = ds.Tables[0];
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
            YourClassObject = oXmlSerializer.Deserialize(new StringReader(XMLString));
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

    }
}
