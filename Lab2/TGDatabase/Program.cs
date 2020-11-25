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
        //public static string cutEpisode(string name)
        //{
        //    char[] spearator = { '[' };
        //    string[] cname = name.Split(spearator, 2, StringSplitOptions.None);
        //    //Console.WriteLine(cname[0]);
        //    return cname[1];
        //}
        public static string cutDate(string date)
        {
            char[] spearator = { ',','+' };
            string[] cname = date.Split(spearator, 3 , StringSplitOptions.None);
            //Console.WriteLine(cname[1]);
            return cname[1];
        }
        static void Main(string[] args)
        {
            printList();
            //String URLString = "https://animevost.am/rss.xml";
            //XmlDocument doc = new XmlDocument();
            //doc.Load(URLString);
            //XmlElement root = doc.DocumentElement;
            //XmlNodeList elemListTitle = root.GetElementsByTagName("title");
            //XmlNodeList elemListDate = root.GetElementsByTagName("pubDate");

            //string connStr = "server=localhost;user=root;database=test database;port=3306;password=270998";
            //MySqlConnection conn = new MySqlConnection(connStr);
            //try
            //{
            //    Console.WriteLine("Connecting to MySQL...");
            //    conn.Open();
            //    string sql;
            //    MySqlCommand cmd;
            //    for (int i = 0; i < elemListTitle.Count - 1; i++)
            //    {
            //        string inputName = cutName(elemListTitle[i + 1].InnerXml);
            //        string inputDate =  cutDate( elemListDate[i].InnerXml);
            //         sql = $"INSERT INTO anime (idanime, title, date) VALUES ({i + 5}, '{inputName}', '{inputDate}')";
            //        cmd = new MySqlCommand(sql, conn);
            //       cmd.ExecuteNonQuery();
            //    }
            //    sql = "SELECT * FROM anime ";
            //    cmd = new MySqlCommand(sql, conn);
            //    MySqlDataReader rdr = cmd.ExecuteReader();
            //    while (rdr.Read())
            //    {
            //        Console.WriteLine(rdr[0] + " -- " + rdr[1] + " -- " + rdr[2]);
            //    }
            //    rdr.Close();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.ToString());
            //}
            //Console.WriteLine("Done.");
            //Console.ReadKey();

        }
        static void printList()
        {
            String URLString = "https://animevost.am/rss.xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(URLString);
            XmlElement root = doc.DocumentElement;
            string connStr = "server=localhost;user=root;database=test database;port=3306;password=270998";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql;
                MySqlCommand cmd;
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

