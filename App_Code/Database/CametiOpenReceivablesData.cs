using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CametiOpenReceivablesData
/// </summary>
public class CametiOpenReceivablesData
{
    private int _Id;
    private int _Cameti_open_id;     
    private int _Members_id;
    private double _Amount;

    public CametiOpenReceivablesData()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public CametiOpenReceivablesData(int Id) 
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@int_Id", Id));
        using (DataSet ds = connect.GetDataset("SELECT * FROM cameti_open_receivables WHERE id=@int_Id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _Cameti_open_id = int.Parse(ds.Tables[0].Rows[0]["cameti_open_id"].ToString());              
                _Members_id = int.Parse(ds.Tables[0].Rows[0]["members_id"].ToString());
                _Amount = double.Parse(ds.Tables[0].Rows[0]["amount"].ToString());
              
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
        param.Add(new MySqlParameter("@cameti_open_id", _Cameti_open_id));      
        param.Add(new MySqlParameter("@members_id", _Members_id));
        param.Add(new MySqlParameter("@amount", _Amount));
    

        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO cameti_open_receivables(cameti_open_id,members_id,amount,) VALUES(@cameti_open_id,@members_id,@amount)", param);
        connect.Dispose();
        connect = null;
    }
    public void Update(int id)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@cameti_open_id", _Cameti_open_id));
        param.Add(new MySqlParameter("@members_id", _Members_id));
        param.Add(new MySqlParameter("@amount", _Amount));

        Connection connect = new Connection();
        connect.ExecStatement("UPDATE cameti_open_receivables SET cameti_open_id=@cameti_open_id,members_id=@members_id,amount=@amount where id=" + id, param);
        connect.Dispose();
        connect = null;
    }
    public DataSet getCametiReceivables(String query) 
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
   
    public int Cameti_open_id
    {
        get { return _Cameti_open_id; }
        set { _Cameti_open_id = value; }
    }

    public int Members_id
    {
        get { return _Members_id; }
        set { _Members_id = value; }
    }
    public double Amount
    {
        get { return _Amount; }
        set { _Amount = value; }
    }
   
    public bool HasValue
    {
        get;
        set;
    }
}