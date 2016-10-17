using System;
//using System.Collections.Generic;
using System.Linq;
//using System.Text;

using System.Data;
//using System.Data.SqlClient;
//using System.Data.Common;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Globalization;
using System.Collections.Generic;
using System.ServiceModel.Syndication;


namespace UnePremiereApplication
{
    public partial class Form1 : Form
    {
        

        //private string fileName;
        //private static object yourXml;

        public Form1()
        {
            InitializeComponent();
        }

      
        private void btnOk_Click(object sender, EventArgs e)
        {
           

            try
            {

                string ville = string.Empty;

                com.webservicex.www.globalweather.GlobalWeather gw = new com.webservicex.www.globalweather.GlobalWeather();
                //ville = gw.GetWeather("New York", "United States");
                //ville = gw.GetCitiesByCountry("Canada");
                string x = txtRecherche.Text.ToString();

                ville = gw.GetCitiesByCountry(x);

                //net.webservicex.www.airport.airport air = new net.webservicex.www.airport.airport();
                //ville = air.GetAirportInformationByCountry(txtRecherche.ToString());
                //net.webservicex.www.country.detail.country ccc = new net.webservicex.www.country.detail.country();
                //Pays objemp = new Pays();
                //string sss = ccc.GetCountries();


                //objemp = (Pays)CreateObject(sss, objemp);
                //string strView = CreateXML(objemp);
                //lblReponse.Text = strView;

                feedDtAvecXml(ville);

                //Pays data = new Pays();
                //data.Name = "Name";
                ////data.Value = 100;
                ////data.SubItems = new string[] { "Item1", "Item2", "Item3" };
                //XmlSerializer ser = new XmlSerializer(typeof(Pays));
                //using (FileStream file = new FileStream("C:\\TEMP\\TEST.XML", FileMode.Create, FileAccess.Write))
                //{
                //    ser.Serialize(file, data);
                //}

                //WriteXML();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private string feed()
        {
            string strURL = "http://cdn-europe1.new2.ladmedia.fr/var/exports/podcasts/sound/hondelatte-raconte.xml";
            XmlReader reader = XmlReader.Create(strURL);

            SyndicationFeed feed = SyndicationFeed.Load(reader);
            reader.Close();

            //feedDtAvecXml(feed.ToString());
            //DataSet ds = new DataSet();
            //ds.ReadXml(reader);
            //dataGridView1.DataSource = ds.Tables[0];

            foreach (SyndicationItem item in feed.Items)
            {
                string id = item.Id.ToString();
                string titre = item.Title.Text.ToString();
                dataGridView1.DataBindings.Add(item);

            }




            return "";

        }

      

        private void feedDtAvecXml(string ville)
        {
            XmlDocument XmlDoc = new XmlDocument();

            XmlDoc.LoadXml(ville);
            XmlReader xmlFile = new XmlNodeReader(XmlDoc);
            DataSet ds = new DataSet();
            ds.ReadXml(xmlFile);
            dataGridView1.DataSource = ds.Tables[0];
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
        public string CreateXML(object YourClassObject)
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

        public static void WriteXML( )
        {



            XElement xml = XElement.Load(@"testData.xml");
            XNamespace foobar = "http://foobar/webservices";
            //rien pantout
            //string personId = xml.Descendants(foobar + "person_id").First().Value;

            Pays overview = new Pays();
            overview.Table = "Serialization Overview";
            System.Xml.Serialization.XmlSerializer writer =
                new System.Xml.Serialization.XmlSerializer(typeof(Pays));

            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//SerializationOverview.xml";
            System.IO.FileStream file = System.IO.File.Create(path);

            writer.Serialize(file, overview);
            file.Close();
        }

       

        private void btnImport_Click(object sender, EventArgs e)
        {
            Auteur aut = new Auteur();
            aut.Nom = "nom3";
            aut.Prenom = "prenom3";

            using (monModele bdd = new monModele())
            {
                bdd.Auteur.Add(aut);
                bdd.SaveChanges();


                //var r = (from auteur in bdd.Auteur
                //              where auteur.Nom.Contains("Nom")
                //              select auteur).FirstOrDefault ();

                //bdd.Auteur.Remove(r) ;
                //var requete = bdd.Auteur.Where (p => p.Nom != null);

                //obj.tblA.Where(x => x.fid == i).ToList().ForEach(obj.tblA.DeleteObject);
                //obj.SaveChanges();

                //db.ProRel.RemoveRange(db.ProRel.Where(c => c.ProjectId == Project_id));

                bdd.Auteur.RemoveRange(bdd.Auteur.Where(x => x.Nom.Contains("Nom")));
                bdd.SaveChanges();



                //Définition de la requête LinQ
                var requete = from auteur in bdd.Auteur
                              select new { Id = auteur.Id, Nom = auteur.Nom, prenom = auteur.Prenom };

                dataGridView1.DataSource = requete.ToList();


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            feed();
        }
    }
}
