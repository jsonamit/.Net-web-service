using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MembersData
/// </summary>
public class MembersData
{
    private int _Id;
    private int _App_id;
    private string _Name;
    private string _Mobile;    
    public MembersData()
    {
        //
        // TODO: Add constructor logic here
        //
    }
 
    public MembersData(int Id)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@int_Id", Id));        
        using (DataSet ds = connect.GetDataset("SELECT * FROM members WHERE id=@int_Id ", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _App_id = int.Parse(ds.Tables[0].Rows[0]["app_id"].ToString());
                _Name = ds.Tables[0].Rows[0]["name"].ToString();
                _Mobile = ds.Tables[0].Rows[0]["mobile"].ToString();
            }
            else
            {
                HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;
    }
    public MembersData(string mobile)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@int_Id", Id));
        param.Add(new MySqlParameter("@app_id", App_id));
        param.Add(new MySqlParameter("@name", Name));
        param.Add(new MySqlParameter("@mobile", Mobile));
        using (DataSet ds = connect.GetDataset("SELECT * FROM members WHERE mobile=@mobile", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _App_id = int.Parse(ds.Tables[0].Rows[0]["app_id"].ToString());
                _Name = ds.Tables[0].Rows[0]["name"].ToString();
                _Mobile = ds.Tables[0].Rows[0]["mobile"].ToString();
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
        param.Add(new MySqlParameter("@app_id", _App_id));
        param.Add(new MySqlParameter("@name", _Name));
        param.Add(new MySqlParameter("@mobile", _Mobile));
       
        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO members(app_id,name,mobile) VALUES(@app_id,@name,@mobile)", param);
        connect.Dispose();
        connect = null;
    }
    public void Update(int id)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@name", _Name));
        param.Add(new MySqlParameter("@mobile", _Mobile));

        Connection connect = new Connection();
        connect.ExecStatement("UPDATE members SET name=@name,mobile=@mobile where id=" + id, param);
        connect.Dispose();
        connect = null;
    }
    public DataSet getMembers(String query) 
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
    public int App_id
    {
        get { return _App_id; }
        set { _App_id = value; }
    }
    public string Name
    {
        get { return _Name; }
        set { _Name = value; }
    }
    public string Mobile
    {
        get { return _Mobile; }
        set { _Mobile = value; }
    }

    public bool HasValue
    {
        get;
        set;
    }
}