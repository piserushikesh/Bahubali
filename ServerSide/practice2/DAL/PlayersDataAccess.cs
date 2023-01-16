
using System.Data;

using MySql.Data.MySqlClient;
using practice1.serverSide.models;
namespace practice1.serverSide.DAL;

public class PlayersDataAccess
{
    public static string  conString=@"server=localhost;port=3306;user=root;password=root123;database= playerinfo";

    public static List<Player> GetAllPlayers()
    {
        List<Player> alllist=new List<Player>();
        MySqlConnection con=new MySqlConnection(conString);

        try
        {
                con.Open();
               string query="select * from players"; 
               DataSet ds=new DataSet();
               MySqlCommand cmd=new MySqlCommand(query,con);
               MySqlDataAdapter da=new MySqlDataAdapter(cmd);
               da.Fill(ds);

               DataTable dt=ds.Tables[0];
               DataRowCollection rows=dt.Rows;
               foreach (DataRow row in rows)
               {
                    Player player=new Player
                    {
                       // playerid=int.parse(row["playerId"].ToString()),
                       playerId=int.Parse(row["playerid"].ToString()),
                        playerName= row["playername"].ToString(),
                        country=row["country"].ToString(),
                        dob=row["DOB"].ToString()
                    };
                    alllist.Add(player);

                }
        }


        
        catch (Exception e)
        {
            
           Console.WriteLine(e.Message);
        }
        finally
        {
            con.Close();
        }
        return alllist;
    }

    public static Player GetPlayerById(int id)
    {
        Player player=null;
        MySqlConnection con = new MySqlConnection(conString);
        try
        {
            con.Open();
            string query="select * from players where playerid=" + id;
            MySqlCommand cmd= new MySqlCommand(query,con);
            MySqlDataReader reader = cmd.ExecuteReader();

            if(reader.Read())
            {
                player=new Player
                {

                     playerId=int.Parse(reader["playerid"].ToString()),
                        playerName= reader["playername"].ToString(),
                        country=reader["country"].ToString(),
                        dob=reader["DOB"].ToString()

                };
            }
        }
        catch (Exception e)
        {
            
            Console.WriteLine(e.Message);
        }
        finally
        {
            con.Close();
        }
        return player;
    }


    public static void AddNewPlayer(Player player)
    {
        MySqlConnection con = new MySqlConnection(conString);

        try
        {
            con.Open();
            string query = $"insert into players(playername,country,DOB) values ('{player.playerName}','{player.country}','{player.dob}')";
            MySqlCommand cmd = new MySqlCommand(query,con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            con.Close();

        }
    }

    public static void DeletePlayerById(int id)
    {
        MySqlConnection con= new MySqlConnection(conString);

        try
        {
            con.Open();
            string query = "delete from players where playerid = " + id;
            MySqlCommand cmd = new MySqlCommand(query,con);
            cmd.ExecuteNonQuery();
            con.Close();

        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            con.Close();
        }
    }

}