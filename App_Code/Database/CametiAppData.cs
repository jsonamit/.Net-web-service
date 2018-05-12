using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CametiAppData
/// </summary>
public class CametiAppData 
{
    private int _Id;    
    private string _Name; 
    private string _Icon;
    private string _Owner_name;
    private string _Mobile;
    private int _User_id;
    private string _Password;
    private string _Pin; 
    public CametiAppData()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public CametiAppData(int Id)
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
                _Name = ds.Tables[0].Rows[0]["name"].ToString();

                _Icon = ds.Tables[0].Rows[0]["icon"].ToString();
                _Owner_name =ds.Tables[0].Rows[0]["owner_name"].ToString();
                _Mobile = ds.Tables[0].Rows[0]["mobile"].ToString();
                _User_id = int.Parse(ds.Tables[0].Rows[0]["user_id"].ToString());
                _Password = ds.Tables[0].Rows[0]["password"].ToString();
                _Pin = ds.Tables[0].Rows[0]["pin"].ToString();
               
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
        param.Add(new MySqlParameter("@name", _Name));
        param.Add(new MySqlParameter("@icon", _Icon));
        param.Add(new MySqlParameter("@owner_name", _Owner_name));
        param.Add(new MySqlParameter("@mobile", _Mobile));
        param.Add(new MySqlParameter("@user_id", _User_id));
        param.Add(new MySqlParameter("@password", _Password));
        param.Add(new MySqlParameter("@pin", _Pin));       

        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO cameti_app(name,icon,owner_name,mobile,user_id,password,pin) VALUES(@name,@icon,@owner_name,@mobile,@user_id,@password,@pin)", param);
        connect.Dispose();
        connect = null;
    }

    public void Update(int id)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@name", _Name));
        param.Add(new MySqlParameter("@icon", _Icon));
        param.Add(new MySqlParameter("@owner_name", _Owner_name));
        param.Add(new MySqlParameter("@mobile", _Mobile));
        param.Add(new MySqlParameter("@user_id", _User_id));
        param.Add(new MySqlParameter("@password", _Password));
        param.Add(new MySqlParameter("@pin", _Pin));

        Connection connect = new Connection();
        connect.ExecStatement("UPDATE cameti_app SET name=@name,icon=@icon,owner_name=@owner_name,user_id=@user_id,password=@password,pin=@pin where id=" + id, param);
        connect.Dispose();
        connect = null;
    }
    public DataSet getCametiApp(String query) 
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
    public string Name
    {
        get { return _Name; }
        set { _Name = value; }
    }

    public string Icon
    {
        get { return _Icon; }
        set { _Icon = value; }
    }
    public string Owner_name
    {
        get { return _Owner_name; }
        set { _Owner_name = value; }
    }

    public string Mobile
    {
        get { return _Mobile; }
        set { _Mobile = value; }
    }
    public int User_id
    {
        get { return _User_id; }
        set { _User_id = value; }
    }
    public string Password
    {
        get { return _Password; }
        set { _Password = value; }
    }
    public string Pin
    {
        get { return _Pin; }
        set { _Pin = value; }
    }
  
    public bool HasValue
    {
        get;
        set;
    }
}