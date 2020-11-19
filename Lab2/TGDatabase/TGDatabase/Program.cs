using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Text;

namespace TGDatabase
{
    class Program
    {
        public static string cutName(string name)
        {
            char[] spearator = { '[' };
            string[] cname = name.Split(spearator, 2 , StringSplitOptions.None);
            //Console.WriteLine(cname[0]);
            return cname[0];
        }
        static void Main(string[] args)
        {
            String URLString = "https://animevost.am/rss.xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(URLString);
            XmlElement root = doc.DocumentElement;
            XmlNodeList elemListTitle = root.GetElementsByTagName("title");
            XmlNodeList elemListDate = root.GetElementsByTagName("pubDate");

            string connStr = "server=localhost;user=root;database=test database;port=3306;password=270998";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql;
                MySqlCommand cmd;
                for (int i = 0; i < elemListTitle.Count - 1; i++)
                {
                    string input = cutName(elemListTitle[i + 1].InnerXml);
                    string inputY = elemListDate[i + 1].InnerXml;
                    sql = $"INSERT INTO anime (idanime, title, year) VALUES ({i + 30}, '{input}', '{inputY}')";
                    cmd = new MySqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                }
                sql = "SELECT * FROM anime ";
                cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Console.WriteLine(rdr[0] + " -- " + rdr[1] + " -- " + rdr[2]);
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.WriteLine("Done.");
            Console.ReadKey();

        }

   
    }
}

