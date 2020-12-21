using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TGBot
{
    public class Db
    {
        static string connStr = "server=mysql.local;user=root;database=anime_db;port=3306;password=270998";
        MySqlConnection connection;


        public async Task ConnectAsync()
        {
            for (int i = 1; i <= 5; i++)
            {
                try
                {
                    connection = new MySqlConnection(connStr);
                    Console.WriteLine($"Connecting to MySQL... ({i})");
                    await connection.OpenAsync();
                }
                catch (Exception ex)
                {
                    connection.Dispose();
                    connection = null;
                    Console.WriteLine(ex.ToString());
                    await Task.Delay(2000);
                } 
            }
        }

        public string cutName(string name)
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
        public string cutDate(string date)
        {
            char[] spearator = { ',', '+' };
            string[] cname = date.Split(spearator, 3, StringSplitOptions.None);
            return cname[1];
        }
        public void createList(long id, string ListAnimeId)
        {
            Console.WriteLine("id" + id);
            String[] idAnime = ListAnimeId.Substring(6).Split(' ');

            try
            {
                string sql = $"SELECT idanime FROM anime WHERE idanime IN (" +
                    $"SELECT id_anime FROM user_anime  WHERE id_user = '{id}')";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
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
                    cmd = new MySqlCommand(sql, connection);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.WriteLine("Done.");
        }

        public string printList(long id)
        {
            String List = " ";
            try
            {
                String sql = $"SELECT * FROM anime WHERE idanime IN (" +
                    $"SELECT id_anime FROM user_anime  WHERE id_user = '{id}')";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
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

        public string printAllList()
        {
            String List = " ";
            try
            {
                String sql = "SELECT * FROM anime ";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
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
