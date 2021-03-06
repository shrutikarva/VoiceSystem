﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CallSystem.DataLayer
{
    public class UserVoice
    {

        String strConnString = ConfigurationManager.ConnectionStrings["DbLiveChat"].ConnectionString;
        public void insertresponse(string response)
        {
            SqlConnection con = new SqlConnection(strConnString);
            SqlCommand cmd = new SqlCommand();
           // SqlDataReader reader;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "checkresponse";
            cmd.Parameters.Add("@response", SqlDbType.Int).Value = Convert.ToInt32(response);
            cmd.Connection = con;
            try
            {
                con.Open();

                cmd.ExecuteNonQuery();

               

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            //checkresponse
        }
        public DataTable GetUserCallList(string ClientId, string UserId, string LoanGUID)
        {

            DataTable dtChatList = new DataTable();
            SqlConnection con = new SqlConnection(strConnString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetAllUserConversationList_Voice";
            cmd.Parameters.Add("@ClientId", SqlDbType.VarChar).Value = ClientId;
            cmd.Parameters.Add("@UserId", SqlDbType.VarChar).Value = UserId;
            cmd.Parameters.Add("@LoanGUID", SqlDbType.VarChar).Value = LoanGUID;
            cmd.Connection = con;
            try
            {
                con.Open();

                reader = cmd.ExecuteReader();

                dtChatList.Load(reader);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return dtChatList;
        }
    }
}