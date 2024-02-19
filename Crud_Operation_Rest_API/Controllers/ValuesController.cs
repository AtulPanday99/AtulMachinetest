using Crud_Operation_Rest_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Crud_Operation_Rest_API.Controllers
{
    public class ValuesController : ApiController
    {
        KSSDBEntities db = new KSSDBEntities();
        // GET : api/Values

        public IEnumerable<CodeRower> GetCodeRower()
        {
            List<CodeRower> lstp = db.CodeRowers.ToList();
            return lstp;
        }

        //GET api/Values/1

        public CodeRower GetTbl(int id)
        {
            CodeRower tp = db.CodeRowers.Find(id);
            return tp;
        }

        //POST : api/Values
        public string Post(CodeRower cr)
        {
            string msg = string.Empty;
            try
            {
                db.CodeRowers.Add(cr);
                db.SaveChanges();
                msg = "Record saved successfully.";
            }
            catch
            {
                msg = "Sorry!unable to save details.";
            }
            return msg;
        }

        // PUT api/Values/5
        public string Put(int id, [FromBody] string value)
        {
            string msg = string.Empty;
            try
            {
                CodeRower edr = db.CodeRowers.Find(id);
                edr.configname = value;
                db.Entry(edr);
                db.SaveChanges();
                msg = " Record updated successfully.";
            }
            catch
            {
                msg = "Sorry!unable to update record.";
            }
            return msg;
        }

        // DELETE api/Values/5
        public string Delete(int id)
        {
            string msg = string.Empty;
            try
            {
                CodeRower tp = db.CodeRowers.Find(id);
                db.CodeRowers.Remove(tp);
                db.SaveChanges();
                msg = "Record deleted successfully.";
            }
            catch
            {
                msg = "Sorry!unable to delete record.";
            }
            return msg;
        }
    }
}