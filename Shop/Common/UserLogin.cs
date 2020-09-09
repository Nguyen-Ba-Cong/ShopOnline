using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Common
{
    [Serializable]
    public class UserLogin
    {
 
        public long UserID { get; set; }
        public String UserName { get; set; }
        public String GroupID { get; set; }
    }
}