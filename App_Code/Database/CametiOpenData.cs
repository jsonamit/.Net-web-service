using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
/// <summary>
/// Summary description for CametiOpenData
/// </summary>
public class CametiOpenData
{
    private int _Id;
    private int _Months;
    private int _Cameti_id;
    private int _Members_id;
    private double _Amount;
    private string _Date;
    public CametiOpenData()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public CametiOpenData(int Id)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@int_Id", Id));
        using (DataSet ds = connect.GetDataset("SELECT * FROM cameti_open WHERE id=@int_Id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _Months = int.Parse(ds.Tables[0].Rows[0]["months"].ToString());
                _Cameti_id = int.Parse(ds.Tables[0].Rows[0]["cameti_id"].ToString());
                _Members_id = int.Parse(ds.Tables[0].Rows[0]["members_id"].ToString());
                _Amount = double.Parse(ds.Tables[0].Rows[0]["amount"].ToString());
                _Date = ds.Tables[0].Rows[0]["date"].ToString();

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
        param.Add(new MySqlParameter("@months", _Months));
        param.Add(new MySqlParameter("@cameti_id", _Cameti_id));
        param.Add(new MySqlParameter("@members_id", _Members_id));
        param.Add(new MySqlParameter("@amount", _Amount));
        param.Add(new MySqlParameter("@date", _Date));

        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO cameti_open(months,cameti_id,date,members_id,amount,) VALUES(@months,@cameti_id,@date,@members_id,@amount)", param);
        connect.Dispose();
        connect = null;
    }
    public void Update(int id)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@months", _Months));
        param.Add(new MySqlParameter("@cameti_id", _Cameti_id));
        param.Add(new MySqlParameter("@members_id", _Members_id));
        param.Add(new MySqlParameter("@amount", _Amount));
        param.Add(new MySqlParameter("@date", _Date));

        Connection connect = new Connection();
        connect.ExecStatement("UPDATE cameti_open SET months=@months,cameti_id=@cameti_id,date=@date,members_id=@members_id,amount=@amount where id=" + id, param);
        connect.Dispose();
        connect = null;
    }
    public DataSet getCametiOpen(String query) 
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
    public int Months
    {
        get { return _Months; }
        set { _Months = value; }
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
    public double Amount
    {
        get { return _Amount; }
        set { _Amount = value; }
    }
    public string Date
    {
        get { return _Date; }
        set { _Date = value; }
    }


    public bool HasValue
    {
        get;
        set;
    }
}