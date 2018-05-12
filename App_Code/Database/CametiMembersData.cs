using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CametiMembersData
/// </summary>
public class CametiMembersData
{
    private int _Id;
    private int _Cameti_id;
    private int _Members_id; 
  
    public CametiMembersData() 
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public CametiMembersData(int Id)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@int_Id", Id));
        using (DataSet ds = connect.GetDataset("SELECT * FROM cameti_app WHERE id=@int_Id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _Cameti_id = int.Parse(ds.Tables[0].Rows[0]["cameti_id"].ToString());

                _Members_id = int.Parse(ds.Tables[0].Rows[0]["members_id"].ToString());               

            }
            else
            {
                HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;
    }
    public void Save()
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@cameti_id", _Cameti_id));
        param.Add(new MySqlParameter("@members_id", _Members_id));      

        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO cameti_members(cameti_id,members_id) VALUES(@cameti_id,@members_id)", param);
        connect.Dispose();
        connect = null;
    }

    public void Update(int id)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@cameti_id", _Cameti_id));
        param.Add(new MySqlParameter("@members_id", _Members_id));
      
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE cameti_members SET cameti_id=@cameti_id,members_id=@members_id where id=" + id, param);
        connect.Dispose();
        connect = null;
    }
    public DataSet getCametiMembers(String query)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>(); 

        DataSet ds = connect.GetDataset(query);
        return ds;
    }

    public int Id
    {
        get { return _Id; }
        set { _Id = value; }
    }
    public int Cameti_id
    {
        get { return _Cameti_id; }
        set { _Cameti_id = value; }
    }
     
    public int Members_id 
    {
        get { return _Members_id; }
        set { _Members_id = value; }
    }
   

    public bool HasValue
    {
        get;
        set;
    }
}