using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
namespace myfirstApp.App_Code
{
    public class StdBBAL
    { 

        StudDalcs dal = new StudDalcs();
        public bool insertData(StudProp p)
        {
            try
            {
                dal.insert(p);
            }
            catch
            {
                return true;
            }
            return false;
        }
        public bool updateData(StudProp p)
        {
            try
            {
                dal.update(p);
            }
            catch
            {
                return true;
            }
            return false;
        }
        public bool deleteData(StudProp p)
        {
            try
            {
                dal.delete(p);
            }
            catch
            {
                return true;
            }
            return false;
        }
        public DataTable getStudents()
        {
            return dal.select();
        }
    }
}