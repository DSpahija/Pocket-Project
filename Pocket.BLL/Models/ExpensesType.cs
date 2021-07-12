using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pocket.BLL.Models
{
    public class ExpensesType
    {
        public int IDExpensesType { get; set; }
        public string TypeCategory { get; set; }
        public string TypeName { get; set; }

        public string FullInfo
        {
            get
            {
                return $"{TypeName}";
            }
        }
        public override string ToString()
        {
            return FullInfo;
        }
    }
}
