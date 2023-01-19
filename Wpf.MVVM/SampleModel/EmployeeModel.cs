using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf.MVVM.SampleModel
{
    public class EmployeeModel
    {
        public int Empno { get; set; }
        public string Ename { get; set; }
        public string Job { get; set; }
        public int Mgr { get; set; }
        public int Salary { get; set; }

        public int Comm { get; set; }

        public DateTime Hiredate { get; set; }

        public int Deptno { get; set; }

    }
}
