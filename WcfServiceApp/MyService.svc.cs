using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MyService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select MyService.svc or MyService.svc.cs at the Solution Explorer and start debugging.
    public class MyService : IMyService
    {
        public void DoWork()
        {
        }
        public List<tblUserDetail> GetAllUser()
        {
            List<tblUserDetail> userlst = new List<tblUserDetail>();
            UserDetailEntities tstDb = new UserDetailEntities();
            var lstUsr = from k in tstDb.tblUserDetails select k;
            foreach (var item in lstUsr)
            {
                tblUserDetail usr = new tblUserDetail();
                usr.Id = item.Id;
                usr.Name = item.Name;
                usr.Email = item.Email;
                userlst.Add(usr);

            }

            return userlst;
        }



        public tblUserDetail GetAllUserById(int id)
        {

            UserDetailEntities tstDb = new UserDetailEntities();
            var lstUsr = from k in tstDb.tblUserDetails where k.Id == id select k;
            tblUserDetail usr = new tblUserDetail();
            foreach (var item in lstUsr)
            {

                usr.Id = item.Id;
                usr.Name = item.Name;
                usr.Email = item.Email;


            }

            return usr;
        }

        public int DeleteUserById(int Id)
        {

            UserDetailEntities tstDb = new UserDetailEntities();
            tblUserDetail usrdtl = new tblUserDetail();
            usrdtl.Id = Id;
            tstDb.Entry(usrdtl).State = EntityState.Deleted;
            int Retval = tstDb.SaveChanges();
            return Retval;
        }

        public int AddUser(string Name, string Email)
        {
            UserDetailEntities tstDb = new UserDetailEntities();
            tblUserDetail usrdtl = new tblUserDetail();
            usrdtl.Name = Name;
            usrdtl.Email = Email;
            tstDb.tblUserDetails.Add(usrdtl);
            int Retval = tstDb.SaveChanges();
            return Retval;
        }
        public int UpdateUser(int Id, string Name, string Email)
        {
            UserDetailEntities tstDb = new UserDetailEntities();
            tblUserDetail usrdtl = new tblUserDetail();
            usrdtl.Id = Id;
            usrdtl.Name = Name;
            usrdtl.Email = Email;
            tstDb.Entry(usrdtl).State = EntityState.Modified;

            int Retval = tstDb.SaveChanges();
            return Retval;
        }
    }
}
