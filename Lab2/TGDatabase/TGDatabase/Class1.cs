////using System;
////using System.Collections.Generic;
////using System.Linq;
////using System.Text;
////using System.Threading.Tasks;
////using MySql.Data.MySqlClient;
////using System.Data.SqlTypes;

////namespace TGDatabase
////{
////    class Class1

////    {

////        MySqlConnection c = new MySqlConnection();
////        //c.C = "server=localhost;user id = root;database=test database;password=270998";
////        c.SchemaColumn();



////    }
////}
//using System;
//using System.Data;

//using MySql.Data;
//using MySql.Data.MySqlClient;

//public class Tutorial2
//{
//    public static void Main()
//    {
//        string connStr = "server=localhost;user=root;database=world;port=3306;password=******";
//        MySqlConnection conn = new MySqlConnection(connStr);
//        try
//        {
//            Console.WriteLine("Connecting to MySQL...");
//            conn.Open();

//            string sql = "SELECT Name, HeadOfState FROM Country WHERE Continent='Oceania'";
//            MySqlCommand cmd = new MySqlCommand(sql, conn);
//            MySqlDataReader rdr = cmd.ExecuteReader();

//            while (rdr.Read())
//            {
//                Console.WriteLine(rdr[0] + " -- " + rdr[1]);
//            }
//            rdr.Close();
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine(ex.ToString());
//        }

//        conn.Close();
//        Console.WriteLine("Done.");
//    }
//}
