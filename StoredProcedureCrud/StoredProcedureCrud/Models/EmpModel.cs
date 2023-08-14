using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoredProcedureCrud.Models
{
    public class EmpModel
    {
        public int Id { get; set; }
        public string EmpName { get; set; }
        public string EmpCompany { get; set; }
        public int EmpSalary { get; set; }
        public string EmpDepartment { get; set; }
    }
}