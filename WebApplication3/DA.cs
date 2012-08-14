using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using MySql.Data.MySqlClient;
using System.Web.UI.WebControls;
using System.Collections;

namespace WebApplication3
{
    public class PlayerProfileEntity
    {
        public string strName;
        public string strId;
        public string gender;
        public string Age;
        public string Email;
        public string Location;
        public string Date;
        public string Total;
    }
    public class GameProfileEntity
    {
        public string ID;
        public string  Name;
        public string  Age;
        public string  Gender;
        public string  Location;
        public string  Email;
        public string  Ethnicity;
        public string  Language;
        public string  Date;
        public string  Parent_ID;
        public string  Total ;
    }
    public class DA
    {
        int ID;
        int Parent_ID;
        //string connStr = String.Format("server={0};user id={1}; password={2};port={3};database=C82432_kuwabara; pooling=false", "mysql1009.hostexcellence.com", "C82432_kuwabara", "Kk2558","3306");
        string connStr;
        public DA()
        {
            if (ConfigurationManager.AppSettings["Enviornment"] == "D")
            {
                connStr = String.Format("server={0};user id={1}; password={2};port={3};database=bevaioralappdb; pooling=false", "localhost", "root", "MySql", "3306");
            }
            else
            {
                connStr = String.Format("server={0};user id={1}; password={2};port={3};database=C82432_kuwabara; pooling=false", "mysql1009.hostexcellence.com", "C82432_kuwabara", "Kk2558", "3306");
        
            }
        }
           
            //MySqlConnection conn = new MySqlConnection(connStr);
           
            
        public int InsertCustomer(string Name,int Age,string Gender,string Location, string Email,int Total)
        {
            string sql = "INSERT INTO Profile(Name, Age,Gender,Location,Email,Total,Ethnicity,Language,Parent_ID) "
          + "VALUES (@Name, @Age,@Gender,@Location,@Email,@Total,@Ethnicity,@Language,@Parent_ID)";

            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.Add("@Name", MySqlDbType.VarChar, 50).Value = Name;
            cmd.Parameters.Add("@Age", MySqlDbType.VarChar, 6).Value =Age;
            cmd.Parameters.Add("@Gender", MySqlDbType.VarChar, 50).Value = Gender;
            cmd.Parameters.Add("@Location", MySqlDbType.VarChar, 50).Value = Location;
            cmd.Parameters.Add("@Email", MySqlDbType.VarChar, 50).Value = Email;
            cmd.Parameters.Add("@Total", MySqlDbType.VarChar, 50).Value = Total;
            cmd.Parameters.Add("@Ethnicity", MySqlDbType.VarChar, 50).Value = "Asian";
            cmd.Parameters.Add("@Language", MySqlDbType.VarChar, 50).Value = "Hindi";
            cmd.Parameters.Add("@Parent_ID", MySqlDbType.VarChar, 50).Value = "0";
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            conn.Close();
            GetID(Email);
            SetParentID(ID);
            return ID;
        }
        public void GetID(string Email)
        {

            string sql = " Select ID,Parent_ID from Profile where Email= @Email";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.Add("@Email", MySqlDbType.VarChar, 50).Value = Email;
            cmd.Prepare();
           MySqlDataReader reader = cmd.ExecuteReader();
           while (reader.Read())
           {
               ID =Int32.Parse(reader["ID"].ToString());
               Parent_ID = Int32.Parse(reader["Parent_ID"].ToString());

           }
           reader.Close();


                  conn.Close();
        }
        public void SetParentID(int ID)
        {
            int result = 0;
            Parent_ID = Math.DivRem(ID, 2, out result);
            string sql = " Update  Profile set Parent_ID = @Parent_ID where ID=@ID";
            MySqlConnection conn = new MySqlConnection(connStr);
            
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.Add("@ID", MySqlDbType.VarChar, 50).Value = ID;
            cmd.Parameters.Add("@Parent_ID", MySqlDbType.VarChar, 50).Value = Parent_ID;
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void InsertChoice(int Game_ID, string Name, int ID, int Team_ID,int Choice)
        {

            string sql = "INSERT INTO Game(Name, Game_ID,ID,Team_ID,Choice) "
         + "VALUES (@Name, @Game,@ID,@Team_ID,@Choice)";


            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.Add("@Name", MySqlDbType.VarChar, 50).Value = Name;
            cmd.Parameters.Add("@Game", MySqlDbType.VarChar, 50).Value = Game_ID;
            cmd.Parameters.Add("@ID", MySqlDbType.VarChar, 50).Value = ID;
            cmd.Parameters.Add("@Team_ID", MySqlDbType.VarChar, 50).Value = Team_ID;
            cmd.Parameters.Add("@Choice", MySqlDbType.VarChar, 50).Value = Choice;

            cmd.Prepare();
            cmd.ExecuteNonQuery();
            conn.Close();

        }
        public PlayerProfileEntity ValidateUser(string Name, string Email)
        {
            DataSet dsUserInfo = new DataSet();

            string sql = " Select * from Profile where Email='"+ Email +"' and Name='"+Name+"'";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            //MySqlCommand cmd = new MySqlCommand(sql, conn);
            //cmd.Parameters.Add("@Email", MySqlDbType.VarChar, 50).Value = Email;
            //cmd.Parameters.Add("@Name", MySqlDbType.VarChar, 50).Value = Name;
            //cmd.Prepare();
            MySqlDataAdapter dta = new MySqlDataAdapter(sql, conn);
            dta.Fill(dsUserInfo);
            if (dsUserInfo.Tables[0].Rows.Count > 0)
            {

                PlayerProfileEntity obj = new PlayerProfileEntity();
                obj.strName = dsUserInfo.Tables[0].Rows[0]["Name"].ToString();
                obj.strId = dsUserInfo.Tables[0].Rows[0]["ID"].ToString();
                obj.gender = dsUserInfo.Tables[0].Rows[0]["Gender"].ToString();
                obj.Age = dsUserInfo.Tables[0].Rows[0]["Age"].ToString();
                obj.Email = dsUserInfo.Tables[0].Rows[0]["Email"].ToString();
                obj.Location = dsUserInfo.Tables[0].Rows[0]["Location"].ToString();
                obj.Date = dsUserInfo.Tables[0].Rows[0]["Date"].ToString();
                obj.Total = dsUserInfo.Tables[0].Rows[0]["Total"].ToString();
                return obj;

            }
            return null;
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            //MySqlDataReader reader = cmd.ExecuteReader();
            //while (reader.Read())
            //{
            //    return true;
            //}
            //reader.Close();


            //conn.Close();
            //return null;
        }
        public int getAverage(int TeamId)
        {
            int Avg;
            //string sql2 = " SELECT COUNT(*) as 'Count' FROM Game  WHERE (ID =@TeamId OR Team_ID =@TeamId) and Choice<>-1";
            string sql2 = " SELECT COUNT(*) as 'Count' FROM Profile  WHERE (ID =@TeamId OR Parent_ID =@TeamId) and TOTAL<>-1";
            
            int proceed;

            //string sql = " SELECT AVG( Choice ) as 'Average' FROM Game  WHERE (ID =@TeamId OR Team_ID =@TeamId) and Choice<>-1";
            string sql = " SELECT AVG( total ) as 'Average' FROM Profile  WHERE (ID =@TeamId OR Parent_ID =@TeamId) and TOTAL<>-1";
            
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();

            MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
            cmd2.Parameters.Add("@TeamId", MySqlDbType.Int16).Value = TeamId;
            cmd2.Prepare();
            proceed = 0;
            MySqlDataReader reader2 = cmd2.ExecuteReader();
            while (reader2.Read())
            {
                proceed = Int32.Parse((reader2["Count"]).ToString());
            }
            reader2.Close();

            if (proceed != 3)
            {
                conn.Close();
                return 0;
            }

            MySqlCommand cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.Add("@TeamId", MySqlDbType.Int16).Value = TeamId;
            cmd.Prepare();
            MySqlDataReader reader = cmd.ExecuteReader();
            Avg = 0;
            while (reader.Read())
            {
                decimal fltAvg;
                fltAvg = (decimal)(reader["Average"]);
                Avg = (int)fltAvg;
            }
            reader.Close();
            conn.Close();
            return Avg;
        }
        //SELECT AVG( TOTAL ) FROM Profile  WHERE ID =2 OR Parent_ID =2

       /* public void UpdateCustomer()
        {
            string sql = "Update Customers Set Cus_Name=@CustomerName, Cus_Gender=@CustomerGender, Cus_City=@CustomerCity, " + " Cus_State=@CustomerState, Cus_Type=@CustomerType Where Cus_Code=@CustomerCode";

            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@CustomerCode", SqlDbType.Int).Value = CustomerCode;
            cmd.Parameters.Add("@CustomerName", SqlDbType.VarChar, 50).Value = CustomerName;
            cmd.Parameters.Add("@CustomerGender", SqlDbType.VarChar, 6).Value = CustomerGender;
            cmd.Parameters.Add("@CustomerCity", SqlDbType.VarChar, 50).Value = CustomerCity;
            cmd.Parameters.Add("@CustomerState", SqlDbType.VarChar, 50).Value = CustomerState;
            cmd.Parameters.Add("@CustomerType", SqlDbType.VarChar, 50).Value = CustomerType;
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void DeleteCustomer()
        {
            string sql = "Delete From Customers Where Cus_Code=@CustomerCode";
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@CustomerCode", SqlDbType.Int).Value = CustomerCode;
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public DataTable FetchAllCustomers()
        {
            string sql = "Select * from Customers Order By Cus_Name";
            SqlDataAdapter da = new SqlDataAdapter(sql, ConnectionString);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable FetchOneCustomer()
        {
            string sql = "Select * from Customers Where Cus_Code=@CustomerCode";
            SqlDataAdapter da = new SqlDataAdapter(sql, ConnectionString);
            da.SelectCommand.Parameters.Add("@CustomerCode", SqlDbType.Int).Value = CustomerCode;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        } */

        public void insertAverage(string strPID, string strAverage,string strRoundID)
        {
            int Avg;
            string sql2 = " SELECT COUNT(*) as 'Count' FROM RoundDetails  WHERE Player_ID=@Player_ID";
            int proceed;

            string sql;//= " SELECT AVG( Choice ) as 'Average' FROM Game  WHERE (ID =@TeamId OR Team_ID =@TeamId) and Choice<>0";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();

            MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
            cmd2.Parameters.Add("@Player_ID", MySqlDbType.Int16).Value = Convert.ToInt16(strPID);
            cmd2.Prepare();
            proceed = 0;
            MySqlDataReader reader2 = cmd2.ExecuteReader();
            while (reader2.Read())
            {
                proceed = Int32.Parse((reader2["Count"]).ToString());
            }
            reader2.Close();

            if (proceed == 0)
            {
                sql = "insert into RoundDetails(Player_ID,Round" + ((Int32.Parse(strRoundID)) + 1).ToString() + ") Values(@PlayerID,@Average)";
            }
            else
            {
                sql = "Update RoundDetails set Round" + ((Int32.Parse(strRoundID)) + 1).ToString() + "= @Average where Player_ID = @PlayerID ";
            }



            MySqlCommand cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.Add("@PlayerID", MySqlDbType.Int16).Value = Convert.ToInt16(strPID);
            cmd.Parameters.Add("@Average", MySqlDbType.Int16).Value = Convert.ToInt16(strAverage);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            conn.Close();
            

        }


        public void revertAverage(int PID)
        {
            string sql = "Update Profile set Total=-1 where ID=@ID";
            MySqlConnection conn = new MySqlConnection(connStr);
            
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.Add("@ID", MySqlDbType.Int16 ).Value = PID;
            
            conn.Open();
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            conn.Close();


            sql = "Update RoundDetails set round1=-1,round2=-1,round3=-1,round4=-1 where PLAYER_ID=@ID";
            
            cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.Add("@ID", MySqlDbType.Int16).Value = PID;

            conn.Open();
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void revertAverage(string PID, string roundNo)
        {
            string sql = "Update Profile set Total=-1 where ID=@ID";
            MySqlConnection conn = new MySqlConnection(connStr);

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.Add("@ID", MySqlDbType.Int16).Value = PID;

            conn.Open();
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            conn.Close();


            sql = "Update RoundDetails set round" + roundNo + "=-1 where PLAYER_ID=@ID";

            cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.Add("@ID", MySqlDbType.Int16).Value = PID;

            conn.Open();
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void InsertChoice(int PID,int Choice)
        {

            string sql = " Update Profile Set Total = " + Choice.ToString() + " where ID = " + PID.ToString();


            MySqlConnection conn = new MySqlConnection(connStr);
            
            MySqlCommand cmd = new MySqlCommand(sql, conn); 
            conn.Open();
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            conn.Close();

        }
        public void InsertChoice(int PID, int Choice, string strRoundID)
        {
            InsertChoice(PID, Choice);
            int Avg;
            string sql2 = " SELECT COUNT(*) as 'Count' FROM Spendings  WHERE PlayerID=@Player_ID ";
            int proceed;

            string sql;//= " SELECT AVG( Choice ) as 'Average' FROM Game  WHERE (ID =@TeamId OR Team_ID =@TeamId) and Choice<>0";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();

            MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
            cmd2.Parameters.Add("@Player_ID", MySqlDbType.Int16).Value = Convert.ToInt16(PID);
            cmd2.Prepare();
            proceed = 0;
            MySqlDataReader reader2 = cmd2.ExecuteReader();
            while (reader2.Read())
            {
                proceed = Int32.Parse((reader2["Count"]).ToString());
            }
            reader2.Close();

            if (proceed == 0)
            {
                sql = "insert into Spendings(PlayerID,Round" + ((Int32.Parse(strRoundID)) + 1).ToString() + ") Values(@PlayerID,@Average)";
            }
            else
            {
                sql = "Update Spendings set Round" + ((Int32.Parse(strRoundID)) + 1).ToString() + "= @Average where PlayerID = @PlayerID ";
            }



            MySqlCommand cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.Add("@PlayerID", MySqlDbType.Int16).Value = Convert.ToInt16(PID);
            cmd.Parameters.Add("@Average", MySqlDbType.Int16).Value = Convert.ToInt16(Choice);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public ArrayList GetRoundDetails(int intPID)
        {
            int round1;
            int round2;
            int round3;
            int round4;
            ArrayList arr = new ArrayList();
            string sql = "select * from RoundDetails where Player_ID = " + intPID.ToString();
            MySqlConnection conn = new MySqlConnection(connStr);
            MySqlCommand cmd2 = new MySqlCommand(sql, conn);
            conn.Open();
            MySqlDataReader reader2 = cmd2.ExecuteReader();
            while (reader2.Read())
            {
                round1 = Int32.Parse((reader2["Round1"]).ToString());
                round2 = Int32.Parse((reader2["Round2"]).ToString());
                round3 = Int32.Parse((reader2["Round3"]).ToString());
                round4 = Int32.Parse((reader2["Round4"]).ToString());

                
                arr.Add(round1);
                arr.Add(round2);
                arr.Add(round3);
                arr.Add(round4);
                
                
            }
            conn.Close();
            return arr;
            


        }

        public int getAverage(int PID, int TeamId)
        {
            int Avg;
            if (PID == 1)
            {
            }

            MySqlConnection conn = new MySqlConnection(connStr);

            string cmdText = "spBehavioralAppGetAVG";
            MySqlCommand cmd = new MySqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlParameter param1;
            param1 = new MySqlParameter("?PID", MySqlDbType.Int32);
            param1.Value = PID;
            param1.Direction = ParameterDirection.Input;

            MySqlParameter param2;
            param2 = new MySqlParameter("?TEAM_ID", MySqlDbType.Int32);
            param2.Value = TeamId;
            param2.Direction = ParameterDirection.Input;

            MySqlParameter param3;
            param3 = new MySqlParameter("?AVG", MySqlDbType.Int32);
            param3.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(param1);
            cmd.Parameters.Add(param2);
            cmd.Parameters.Add(param3);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            return (int)param3.Value ;
        }

        public ArrayList getPlayerChoices(int TeamId)
        {
            int Avg;
            ArrayList arr = new ArrayList();
            PlayerProfileEntity player;
            int proceed;

            //string sql = " SELECT AVG( Choice ) as 'Average' FROM Game  WHERE (ID =@TeamId OR Team_ID =@TeamId) and Choice<>-1";
            string sql = " SELECT ID,TOTAL,Parent_ID as 'Average' FROM Profile  WHERE (ID =@TeamId OR Parent_ID =@TeamId) ";

            MySqlConnection conn = new MySqlConnection(connStr);
            

            
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            cmd.Parameters.Add("@TeamId", MySqlDbType.Int16).Value = TeamId;
            cmd.Prepare();
            MySqlDataReader reader = cmd.ExecuteReader();
            Avg = 0;
            while (reader.Read())
            {
                player = new PlayerProfileEntity();
                player.strId = reader["ID"].ToString();

                player.Total = reader["TOTAL"].ToString();
                //if(reader["TOTAL"].ToString() != "-1")
                //player.Total  = reader["TOTAL"].ToString();
                //else
                //    player.Total = "0";
                arr.Add(player);
            }

            reader.Close();
            conn.Close();
            return arr;
        }
        public int ReturnDbSessionID(int PID)
        {
            string sql = "Select  SessionID from Profile where ID=@ID";
            MySqlConnection conn = new MySqlConnection(connStr);



            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            cmd.Parameters.Add("@ID", MySqlDbType.Int16).Value = PID;
            cmd.Prepare();
            MySqlDataReader reader = cmd.ExecuteReader();
            int Avg = 0;
            while (reader.Read())
            {



                Avg = Convert.ToInt16( reader["SessionID"].ToString());
                //if(reader["TOTAL"].ToString() != "-1")
                //player.Total  = reader["TOTAL"].ToString();
                //else
                //    player.Total = "0";
                //arr.Add(player);
            }

            reader.Close();
            conn.Close();
            return Avg;
            
        }

        public void updateDBSession(int PID, int Choice)
        {

            int ID = Choice;
            int result = 0;
            int Team_ID = Math.DivRem(ID, 2, out result);
            if (Team_ID == 0)
                Team_ID = 1;
            string sql = " Update Profile Set SessionID = " + Choice.ToString() + ",Parent_ID = " + Team_ID.ToString() +  " where ID = " + PID.ToString();

            MySqlConnection conn = new MySqlConnection(connStr);

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            conn.Close();


            sql = " Update spendingscycle Set SessionID = " + Choice.ToString() + ",Team_ID = " + Team_ID.ToString() + ",CurrentCycleTotal=0,Total=0 where PID = " + PID.ToString();

            conn = new MySqlConnection(connStr);

            cmd = new MySqlCommand(sql, conn);
            conn.Open();
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void updatedbDetailsS(int pId, int intRoundPID ,int intEarning , int intChoice, int teamId)
        {
            MySqlConnection conn = new MySqlConnection(connStr);

            string cmdText = "k";
            MySqlCommand cmd = new MySqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlParameter param1;
            param1 = new MySqlParameter("?PID", MySqlDbType.Int32);
            param1.Value = pId;
            param1.Direction = ParameterDirection.Input;

            MySqlParameter param2;
            param2 = new MySqlParameter("?TEAM_ID", MySqlDbType.Int32);
            param2.Value = teamId;
            param2.Direction = ParameterDirection.Input;

            MySqlParameter param3;
            param3 = new MySqlParameter("?CHOICE", MySqlDbType.Int32);
            param3.Value = intChoice;
            param3.Direction = ParameterDirection.Input;

            MySqlParameter param4;
            param4 = new MySqlParameter("?Earningforround", MySqlDbType.Int32);
            param4.Value = intEarning;
            param4.Direction = ParameterDirection.Input;


            MySqlParameter param5;
            param5 = new MySqlParameter("?RoundSessionID", MySqlDbType.Int32);
            param5.Value = intRoundPID;
            param5.Direction = ParameterDirection.Input;

            //param3.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(param1);
            cmd.Parameters.Add(param2);
            cmd.Parameters.Add(param3);
            cmd.Parameters.Add(param4);
            cmd.Parameters.Add(param5);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public DataTable getPlayerChoices(int TeamId,string strType)
        {
            int Avg;
            ArrayList arr = new ArrayList();
            PlayerProfileEntity player;
            int proceed;

            //string sql = " SELECT AVG( Choice ) as 'Average' FROM Game  WHERE (ID =@TeamId OR Team_ID =@TeamId) and Choice<>-1";
            string sql = " SELECT  * FROM roundtrndetails  WHERE (TeamID = " + TeamId.ToString() + " ) ";

            MySqlConnection conn = new MySqlConnection(connStr);


            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            MySqlDataAdapter dta = new MySqlDataAdapter(sql, conn);
            dta.Fill(dt);
            Avg = 0;
            conn.Close();
            return dt;
        }

        public int CalculateEarnings(int TeamId,int pId, int intRoundPid, string strType)
        {
            int Avg;
            ArrayList arr = new ArrayList();
            PlayerProfileEntity player;
            int proceed;
            int earning;
            int spending;
            int total;
            total = 0;
            spending = 0;
            //string sql = " SELECT AVG( Choice ) as 'Average' FROM Game  WHERE (ID =@TeamId OR Team_ID =@TeamId) and Choice<>-1";
            string sql = " SELECT  * FROM roundtrndetails  WHERE (TeamID = " + TeamId.ToString() + " and  ) and RoundID = " + intRoundPid.ToString() ;

            MySqlConnection conn = new MySqlConnection(connStr);


            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            MySqlDataAdapter dta = new MySqlDataAdapter(sql, conn);
            dta.Fill(dt);
            Avg = 0;
            conn.Close();

            foreach (DataRow ent in dt.Rows)
            {
                if (ent["PlayerID"].ToString() == pId.ToString() && ent["RandomRoundSessionID"].ToString() == intRoundPid.ToString())
                {
                    spending = Convert.ToInt32(ent["ScoreForRound"].ToString());
                }
                total = total + Convert.ToInt32(ent["ScoreForRound"].ToString());
            }
            earning = (20 - spending) + (total / 2);
            updatedbDetailsS(pId, intRoundPid, earning, spending, TeamId);
            return earning;

        }
        public int StartNewRound()
        {
            int roundid= 0;
            MySqlConnection conn = new MySqlConnection(connStr);

            string cmdText = "spCreateNewRound";
            MySqlCommand cmd = new MySqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlParameter param1;
            param1 = new MySqlParameter("?roundNumber", MySqlDbType.Int32);
            //param1.Value = pId;
            param1.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(param1);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            roundid = Convert.ToInt32( param1.Value);
            return roundid;
        }

        //spsetresetbinaryscorespsetresetbinaryscore

        public void updatedbDetailsSORB(int pId, int intRoundPID, int intEarning, int intChoice, int teamId, int intchildroundid, string strgametype)
        {
            MySqlConnection conn = new MySqlConnection(connStr);

            string cmdText = "spsetresetbinaryscore";
            MySqlCommand cmd = new MySqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlParameter param1;
            param1 = new MySqlParameter("?PID", MySqlDbType.Int32);
            param1.Value = pId;
            param1.Direction = ParameterDirection.Input;

            MySqlParameter param2;
            param2 = new MySqlParameter("?TEAM_ID", MySqlDbType.Int32);
            param2.Value = teamId;
            param2.Direction = ParameterDirection.Input;

            MySqlParameter param3;
            param3 = new MySqlParameter("?CHOICE", MySqlDbType.Int32);
            param3.Value = intChoice;
            param3.Direction = ParameterDirection.Input;

            MySqlParameter param4;
            param4 = new MySqlParameter("?Earningforround", MySqlDbType.Int32);
            param4.Value = intEarning;
            param4.Direction = ParameterDirection.Input;


            MySqlParameter param5;
            param5 = new MySqlParameter("?RoundSessionID", MySqlDbType.Int32);
            param5.Value = intRoundPID;
            param5.Direction = ParameterDirection.Input;


            MySqlParameter param6;
            param6 = new MySqlParameter("?intchildroundid", MySqlDbType.Int32);
            param6.Value = intchildroundid;
            param6.Direction = ParameterDirection.Input;


            MySqlParameter param7;
            param7 = new MySqlParameter("?gametype", MySqlDbType.VarChar,1);
            param7.Value = strgametype;
            param7.Direction = ParameterDirection.Input;


            cmd.Parameters.Add(param1);
            cmd.Parameters.Add(param2);
            cmd.Parameters.Add(param3);
            cmd.Parameters.Add(param4);
            cmd.Parameters.Add(param5);
            cmd.Parameters.Add(param6);
            cmd.Parameters.Add(param7);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }


        public ArrayList getplayerschoices(int intTeamid, int parentroundid, int intChildroundid)
        {
            ArrayList arr = new ArrayList();
            PlayerProfileEntity player;
            DataSet ds = new DataSet();
            MySqlConnection conn = new MySqlConnection(connStr);
            MySqlCommand cmd = new MySqlCommand("spgetdataforchilround", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@teamidp", MySqlDbType.Int16).Value = intTeamid;
            cmd.Parameters.Add("@intsubroundidp", MySqlDbType.Int16).Value = parentroundid;
            cmd.Parameters.Add("@childroundidp", MySqlDbType.Int16).Value = intChildroundid;
            conn.Open();
            cmd.Prepare();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                player = new PlayerProfileEntity();
                player.strId = reader["randomroundsessionid"].ToString();
                player.Total = reader["scoreforround"].ToString();
                arr.Add(player);
            }
            

            reader.Close();
            conn.Close();
            return arr;


            //MySqlDataAdapter dta = new MySqlDataAdapter(
        }

        public DataTable getplayerschoicesForDataBind(int intTeamid, int parentroundid, int intChildroundid,int playerid)
        {
            //ArrayList arr = new ArrayList();
            PlayerProfileEntity player;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add("randomroundsessionid");
            dt.Columns.Add("scoreforround");

            MySqlConnection conn = new MySqlConnection(connStr);
            MySqlCommand cmd = new MySqlCommand("spgetdataforchilround", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@teamidp", MySqlDbType.Int16).Value = intTeamid;
            cmd.Parameters.Add("@intsubroundidp", MySqlDbType.Int16).Value = parentroundid;
            cmd.Parameters.Add("@childroundidp", MySqlDbType.Int16).Value = intChildroundid;
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            
            

            while (reader.Read())
            {
                DataRow dr = dt.NewRow();

                //player = new PlayerProfileEntity();
                //player.strId = reader["randomroundsessionid"].ToString();
                //player.Total = reader["scoreforround"].ToString();
                dr["randomroundsessionid"] = reader["randomroundsessionid"].ToString();
                dr["scoreforround"] = reader["scoreforround"].ToString();
                if (dr["randomroundsessionid"].ToString().Trim() != playerid.ToString().Trim())
                {
                    dt.Rows.Add(dr);
                }
                
                //arr.Add(player);
            }
            

                reader.Close();
            conn.Close();
            return dt;


            //MySqlDataAdapter dta = new MySqlDataAdapter(
        }




        public bool insertchoiceofuser(int intsubroundid, int intchildroundid, int playerid, int randomroundsessionid, int teamid,int scoreforround,int earningforround)
        {

            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {
                string cmdText = "spsetrounddetails";
                MySqlCommand cmd = new MySqlCommand(cmdText, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("intsubroundidp", MySqlDbType.Int16).Value = intsubroundid;
                cmd.Parameters.Add("intchildroundidp", MySqlDbType.Int16).Value = intchildroundid;
                cmd.Parameters.Add("playeridp", MySqlDbType.Int16).Value = playerid;
                cmd.Parameters.Add("randomroundsessionidp", MySqlDbType.Int16).Value = randomroundsessionid;
                cmd.Parameters.Add("teamidp", MySqlDbType.Int16).Value = teamid;
                cmd.Parameters.Add("scoreforroundp", MySqlDbType.Int16).Value = scoreforround;
                cmd.Parameters.Add("earningforroundp", MySqlDbType.Int16).Value = earningforround;


                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch(Exception ex)
            {
                if(conn.State == ConnectionState.Open)
                conn.Close();

                return false;
            }

        }

        public int getAverage(int intTeamid, int parentroundid, int intChildroundid,int sessionid)
        {
            int Avg;
            
            MySqlConnection conn = new MySqlConnection(connStr);

            string cmdText = "spgetaverage";
            MySqlCommand cmd = new MySqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlParameter param1;
            param1 = new MySqlParameter("?teamidp", MySqlDbType.Int32);
            param1.Value = intTeamid;
            param1.Direction = ParameterDirection.Input;

            MySqlParameter param2;
            param2 = new MySqlParameter("?childroundidp", MySqlDbType.Int32);
            param2.Value = intChildroundid;
            param2.Direction = ParameterDirection.Input;

            MySqlParameter param3;
            param3 = new MySqlParameter("?parentroundidp", MySqlDbType.Int32);
            param3.Value = parentroundid;

            MySqlParameter param4;
            param4 = new MySqlParameter("?sessionidp", MySqlDbType.Int32);
            param4.Value = sessionid;

            //param3.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(param1);
            cmd.Parameters.Add(param2);
            cmd.Parameters.Add(param3);
            cmd.Parameters.Add(param4);
            conn.Open();
            Avg = (int)cmd.ExecuteScalar();
            conn.Close();
            return Avg;
            

            //return (int)param3.Value;
        }
        public int setearningsforround(int intTeamid, int parentroundid, int intChildroundid, int sessionid)
        {
            int Avg;

            MySqlConnection conn = new MySqlConnection(connStr);

            string cmdText = "spcalculateearnings";
            MySqlCommand cmd = new MySqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlParameter param1;
            param1 = new MySqlParameter("?teamidp", MySqlDbType.Int32);
            param1.Value = intTeamid;
            param1.Direction = ParameterDirection.Input;

            MySqlParameter param2;
            param2 = new MySqlParameter("?childroundidp", MySqlDbType.Int32);
            param2.Value = intChildroundid;
            param2.Direction = ParameterDirection.Input;

            MySqlParameter param3;
            param3 = new MySqlParameter("?parentroundidp", MySqlDbType.Int32);
            param3.Value = parentroundid;


            MySqlParameter param4;
            param4 = new MySqlParameter("?sessionidp", MySqlDbType.Int32);
            param4.Value = sessionid;

            //param3.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(param1);
            cmd.Parameters.Add(param2);
            cmd.Parameters.Add(param3);
            cmd.Parameters.Add(param4);
            conn.Open();
            Avg = (int)cmd.ExecuteScalar();
            conn.Close();
            return Avg;
        }
        public void initiatenewround(string strgametype)
        {
            //int Avg;
            //if (1 == 2) { }

            MySqlConnection conn = new MySqlConnection(connStr);

            string cmdText = "spinitiatenewround";
            MySqlCommand cmd = new MySqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlParameter param1;
            param1 = new MySqlParameter("?gametypep", MySqlDbType.VarChar , 1);
            param1.Value = strgametype;
            param1.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param1);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public DataTable  getRoundDetails(int intTeamid, int playerid)
        {
            //ArrayList arr = new ArrayList();
            PlayerProfileEntity player;
            DataSet ds = new DataSet();
            MySqlConnection conn = new MySqlConnection(connStr);
            MySqlCommand cmd = new MySqlCommand("spgetdataforchilroundonid", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@teamidp", MySqlDbType.Int16).Value = intTeamid;
            cmd.Parameters.Add("@playeridp", MySqlDbType.Int16).Value = playerid;
            conn.Open();
            cmd.Prepare();
            DataTable dt = new DataTable();
            dt.Columns.Add("teamid");
            dt.Columns.Add("intsubroundid");
            dt.Columns.Add("intchildroundid");
            dt.Columns.Add("scoreforround");
            dt.Columns.Add("earningforround");


            MySqlDataReader reader = cmd.ExecuteReader();
            
            while (reader.Read())
            {
                dt.Rows.Add(reader["teamid"],reader["intsubroundid"],reader["intchildroundid"],reader["scoreforround"],reader["earningforround"]);
            }

            reader.Close();
            conn.Close();
            return dt;


            //MySqlDataAdapter dta = new MySqlDataAdapter(
        }
        public DataTable getAllRoundDetails()
        {
            string sql = "SELECT * FROM binaryroundheaderdetails";

            MySqlConnection conn = new MySqlConnection(connStr);


            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            MySqlDataAdapter dta = new MySqlDataAdapter(sql, conn);
            dta.Fill(dt);
            conn.Close();
            return dt;
        }

        public DataTable getparticularRoundDetails(int roundid)
        {
            string sql = "SELECT  * FROM binaryrounddetails where introundid = " + roundid.ToString() ;

            MySqlConnection conn = new MySqlConnection(connStr);


            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            MySqlDataAdapter dta = new MySqlDataAdapter(sql, conn);
            dta.Fill(dt);
            //Avg = 0;
            conn.Close();
            return dt;
        }
        
        public bool setpunishment(int intsubroundid, int intchildroundid, int playeridpunished, int randomroundsessionid, int teamid,int punishment)
        {
            //intsubroundidp int,
            //intchildroundidp int,
            //playeridpunished int,
            //teamidp int,
            //randomroundsessionidp int,
            //punishmentamount int

            if (1 == 2)
            {

            }
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                string cmdText = "spupdatepunishment";
                MySqlCommand cmd = new MySqlCommand(cmdText, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("intsubroundidp", MySqlDbType.Int16).Value = intsubroundid;
                cmd.Parameters.Add("intchildroundidp", MySqlDbType.Int16).Value = intchildroundid;
                cmd.Parameters.Add("playeridpunished", MySqlDbType.Int16).Value = playeridpunished;
                cmd.Parameters.Add("teamidp", MySqlDbType.Int16).Value = teamid;
                cmd.Parameters.Add("randomroundsessionidp", MySqlDbType.Int16).Value = randomroundsessionid;
                cmd.Parameters.Add("punishmentamount", MySqlDbType.Int16).Value = punishment;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;

            }
            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();

                return false;
            } 
        }
    }


}