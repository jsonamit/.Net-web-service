using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
/// <summary>
/// Summary description for CametiData
/// </summary>
public class CametiData
{
    private int _Id;
    private int _App_id;
    private string _Cameti_name; 
    private string _Start_date;
    private double _Total_amount;
    private int _Months;
    private string _Installment;
    private string _No_of_people;
    private string _Coin_one; 
    private string _Coin_two;

    public CametiData()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public CametiData(int Id)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@int_Id", Id));
        using (DataSet ds = connect.GetDataset("SELECT * FROM cameti WHERE id=@int_Id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _App_id = int.Parse(ds.Tables[0].Rows[0]["app_id"].ToString());
                _Cameti_name = ds.Tables[0].Rows[0]["cameti_name"].ToString();

                _Start_date = ds.Tables[0].Rows[0]["start_date"].ToString();
                _Total_amount = double.Parse(ds.Tables[0].Rows[0]["total_amount"].ToString());
                _Months = int.Parse(ds.Tables[0].Rows[0]["months"].ToString());
                _Installment = ds.Tables[0].Rows[0]["installment"].ToString();
                _No_of_people = ds.Tables[0].Rows[0]["no_of_peoples"].ToString();
                _Coin_one = ds.Tables[0].Rows[0]["coin_one"].ToString();
                _Coin_two = ds.Tables[0].Rows[0]["coin_two"].ToString();
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
        param.Add(new MySqlParameter("@cameti_name", _Cameti_name));
        param.Add(new MySqlParameter("@start_date", _Start_date));
        param.Add(new MySqlParameter("@total_amount", _Total_amount));
        param.Add(new MySqlParameter("@months", _Months));
        param.Add(new MySqlParameter("@installment", _Installment));
        param.Add(new MySqlParameter("@no_of_people", _No_of_people));
        param.Add(new MySqlParameter("@coin_one", _Coin_one));
        param.Add(new MySqlParameter("@coin_two", _Coin_two));

        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO cameti(app_id,cameti_name,start_date,total_amount,months,installment,no_of_peoples,coin_one,coin_two) VALUES(@app_id,@cameti_name,@start_date,@total_amount,@months,@installment,@no_of_people,@coin_one,@coin_two)", param);
        connect.Dispose();
        connect = null;
    }

    public void Update(int id)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@cameti_name", _Cameti_name));
        param.Add(new MySqlParameter("@start_date", _Start_date));
        param.Add(new MySqlParameter("@total_amount", _Total_amount));
        param.Add(new MySqlParameter("@months", _Months));
        param.Add(new MySqlParameter("@installment", _Installment));
        param.Add(new MySqlParameter("@no_of_people", _No_of_people));
        param.Add(new MySqlParameter("@coin_one", _Coin_one));
        param.Add(new MySqlParameter("@coin_two", _Coin_two));

        Connection connect = new Connection();
        connect.ExecStatement("UPDATE customer SET cameti_name=@cameti_name,start_date=@start_date,total_amount=@total_amount,months=@months,installment=@installment,no_of_people=@no_of_people,coin_one=@coin_one,coin_two=@coin_two where id=" + id, param);
        connect.Dispose();
        connect = null;
    }
    public DataSet getCameti(String query) 
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

    public string Cameti_name
    {
        get { return _Cameti_name; }
        set { _Cameti_name = value; }
    }
    public string Start_date 
    {
        get { return _Start_date; }
        set { _Start_date = value; }
    }

    public double Total_amount
    {
        get { return _Total_amount; }
        set { _Total_amount = value; }
    }
    public int Months
    {
        get { return _Months; }
        set { _Months = value; }
    }
    public string Installment
    {
        get { return _Installment; }
        set { _Installment = value; }
    }
    public string No_of_people 
    {
        get { return _No_of_people; }
        set { _No_of_people = value; }
    }
    public string Coin_one
    {
        get { return _Coin_one; }
        set { _Coin_one = value; }
    }
    public string Coin_two
    {
        get { return _Coin_two; }
        set { _Coin_two = value; }
    }
    public bool HasValue
    {
        get;
        set;
    }
}