using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC340TeamProject
{
    public class storeKeys
    {
        public static string loginUserName;
        public static string loggedInfo { get => loginUserName; set => loginUserName = value; }
    }
}
