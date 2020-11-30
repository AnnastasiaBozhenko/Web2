using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace TGBot
{
    class Db
    {
        public static string cutName(string name)
        {
            char[] spearator = { '[' };
            string[] cname = name.Split(spearator, 2, StringSplitOptions.None);
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
            char[] spearator = { ',', '+' };
            string[] cname = date.Split(spearator, 3, StringSplitOptions.None);
            return cname[1];
        }
        public static void createList(long id, string ListAnimeId)
        {
            Console.WriteLine("id" + id);
            String[] idAnime = ListAnimeId.Substring(6).Split(' ');
            string connStr = "server=localhost;user=root;database=test database;port=3306;password=270998";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = $"SELECT idanime FROM anime WHERE idanime IN (" +
                    $"SELECT id_anime FROM user_anime  WHERE id_user = '{id}')";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    String List = "";
                    List += rdr[0];
                    idAnime = idAnime.Where(val => val != List).ToArray();
                }
                rdr.Close();
                for (int i = 0; i < idAnime.Length; i++)
                {
                    sql = $"INSERT INTO user_anime (id_user,id_anime) VALUES ('{id}', '{idAnime[i]}')";
                    cmd = new MySqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.WriteLine("Done.");
        }

        public static string printList(long id)
        {
            String List = " ";
            string connStr = "server=localhost;user=root;database=test database;port=3306;password=270998";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                String sql = $"SELECT * FROM anime WHERE idanime IN (" +                  
                    $"SELECT id_anime FROM user_anime  WHERE id_user = '{id}')";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    List += rdr[0] + " -- " + rdr[1] + " -- " + rdr[2] + "\n";
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.WriteLine("Done.");
            }
            return List;
        }
    
    public static string printAllList()
        {
            String List = " " ;
            string connStr = "server=localhost;user=root;database=test database;port=3306;password=270998";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                String sql = "SELECT * FROM anime ";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    List += rdr[0] + " -- " + rdr[1] + " -- " + rdr[2] + "\n";
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.WriteLine("Done.");
            }
            return List;
        }
    }
}
