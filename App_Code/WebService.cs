using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.Script.Serialization;
using System.Web.Services;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService
{

    public WebService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public void saveCametiApp(string name, string icon, string owner_name, string mobile, int user_id, string password,string pin)
    {
        try
        {
            CametiAppData adata = new CametiAppData();            
            adata.Name = name;
            adata.Icon = icon;
            adata.Owner_name = owner_name;
            adata.Mobile = mobile;
            adata.User_id = user_id;
            adata.Password = password;
            adata.Pin = pin;            
            adata.Save();
        }
        catch (Exception ex)
        {

        }
    }
    [WebMethod]
    public void saveAddCameti(int app_id,string cameti_name, string start_date, double total_amount, int months, string installment, string no_of_people,string coin_one,string coin_two)
    {
        try   
        {
            CametiData cdata = new CametiData();
            cdata.App_id = app_id;
            cdata.Cameti_name = cameti_name;
            cdata.Start_date = start_date;
            cdata.Total_amount = total_amount;
            cdata.Months = months;
            cdata.Installment = installment;
            cdata.No_of_people = no_of_people;
            cdata.Coin_one = coin_one;
            cdata.Coin_two = coin_two;
            cdata.Save();
        }
        catch (Exception ex)
        {

        }
    }
    [WebMethod]
    public void saveMembers(string name, string mobile) 
    {
        try
        {
            MembersData mdata = new MembersData();
            mdata.Name = name;
            mdata.Mobile = mobile;
            mdata.Save();

        }
        catch (Exception ex)
        {

        }
    }
    [WebMethod]
    public void saveMembersExt(string name, string mobile,string app_id)
    {
        try
        {
            MembersData mdata = new MembersData(mobile);
            if (mdata.HasValue)
            {
               
            }
            else
            {
                mdata.App_id = 10;
                mdata.Name = name;
                mdata.Mobile = mobile;
                mdata.Save();
            }          
        }
        catch (Exception ex)
        {

        }
    }
    public void saveCametiMembers(int cameti_id, int members_id)  
    {
        try
        {
            CametiMembersData cmdata = new CametiMembersData();
            cmdata.Cameti_id = cameti_id;
            cmdata.Members_id = members_id;
            cmdata.Save();
        }
        catch (Exception ex)
        {

        }
    }
    public void saveCametiOpen(int months,double amount,int cameti_id, int members_id,string date)  
    {
        try
        {
            CametiOpenData codata = new CametiOpenData();
            codata.Months = months;
            codata.Amount = amount;
            codata.Cameti_id = cameti_id;
            codata.Members_id = members_id;
            codata.Date = date;
            codata.Save();
        }
        catch (Exception ex)
        {

        }
    }
    public void saveCametiMembersPayment(double amount, int cameti_id, int members_id, string date)
    {
        try
        {
            CametiMembersPaymentData cpdata = new CametiMembersPaymentData();           
            cpdata.Amount = amount;
            cpdata.Cameti_id = cameti_id;
            cpdata.Members_id = members_id;
            cpdata.Date = date;
            cpdata.Save();
        }
        catch (Exception ex)
        {

        }
    }
    public void saveCametiReceivables(int cameti_open_id, int members_id, double amount) 
    {
        try
        {
            CametiOpenReceivablesData crdata = new CametiOpenReceivablesData();
            crdata.Amount = amount;
            crdata.Cameti_open_id = cameti_open_id;
            crdata.Members_id = members_id;
            crdata.Amount = amount; 
            crdata.Save();
        }
        catch (Exception ex)
        {

        }
    }
    [WebMethod]
    public void getCameti(int app_id) 
    {
        //DataSet ds=null;
        string res = "";
        string responce = "";
        ResponseData rsData = new ResponseData();
        List<CametiData> clist = new List<CametiData>();
      
        
        try
        {
            CametiData cdata = new CametiData();
            DataSet  ds = cdata.getCameti("select * from cameti where app_id="+app_id);
            for (int i=0;i<ds.Tables[0].Rows.Count;i++)
            {
                int cid = int.Parse(ds.Tables[0].Rows[i][0].ToString());
                CametiData ciddata = new CametiData(cid);
                clist.Add(ciddata);
            }
           
        }
        catch (Exception ex)
        {

        }
        rsData.Message = "success";
        rsData.Description = "successfully";       
        rsData.Data = clist;
        JavaScriptSerializer js = new JavaScriptSerializer();
        responce = js.Serialize(rsData);
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";
        Context.Response.AddHeader("content-length", responce.Length.ToString());
        Context.Response.Flush();

        Context.Response.Write(responce);      
            
    }
    [WebMethod]
    public void getMembers(int app_id)
    {        
        string responce = "";
        ResponseData rsData = new ResponseData();
        List<MembersData> clist = new List<MembersData>();


        try
        {
            MembersData cdata = new MembersData();
            DataSet ds = cdata.getMembers("select * from members where app_id=" + app_id);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                int cid = int.Parse(ds.Tables[0].Rows[i][0].ToString());
                MembersData mddata = new MembersData(cid);
                clist.Add(mddata);
            }

        }
        catch (Exception ex)
        {

        }
        rsData.Message = "success";
        rsData.Description = "successfully";
        rsData.Data = clist;
        JavaScriptSerializer js = new JavaScriptSerializer();
        responce = js.Serialize(rsData);
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";
        Context.Response.AddHeader("content-length", responce.Length.ToString());
        Context.Response.Flush();
        Context.Response.Write(responce);
    }
    [WebMethod]
    public void getMembersByID(int id)
    {
        string responce = "";
        ResponseData rsData = new ResponseData();
        List<MembersData> clist = new List<MembersData>();
        try
        {
            MembersData cdata = new MembersData();
            DataSet ds = cdata.getMembers("select * from members where id=" + id);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                int cid = int.Parse(ds.Tables[0].Rows[i][0].ToString());
                MembersData mddata = new MembersData(cid);
                clist.Add(mddata);
            }

        }
        catch (Exception ex)
        {

        }
        rsData.Message = "successmembers";
        rsData.Description = "successfully";
        rsData.Data = clist;
        JavaScriptSerializer js = new JavaScriptSerializer();
        responce = js.Serialize(rsData);
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";
        Context.Response.AddHeader("content-length", responce.Length.ToString());
        Context.Response.Flush();
        Context.Response.Write(responce);
    }
    [WebMethod]
    public void getCametiMembers() 
    {
        string responce = "";
        ResponseData rsData = new ResponseData();
        List<CametiMembersData> clist = new List<CametiMembersData>();
        try
        {
            CametiMembersData cmdata = new CametiMembersData();
            DataSet ds = cmdata.getCametiMembers("select cameti_members.members_id,members.id,members.name from cameti_members join members on cameti_members.members_id=members.id ");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                int cid = int.Parse(ds.Tables[0].Rows[i][0].ToString());
                CametiMembersData mddata = new CametiMembersData(cid);
                clist.Add(mddata);
            }
        }
        catch (Exception ex)
        {

        }
        rsData.Message = "success";
        rsData.Description = "successfully";
        rsData.Data = clist;
        JavaScriptSerializer js = new JavaScriptSerializer();
        responce = js.Serialize(rsData);
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";
        Context.Response.AddHeader("content-length", responce.Length.ToString());
        Context.Response.Flush();
        Context.Response.Write(responce);
    }

}

public class MembersExtData
{
}