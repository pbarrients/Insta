using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Instagram.Sources;

namespace Instagram
{
    class Program
    {
        static void Main(string[] args)
        {

            InstaHelper con = new InstaHelper();
            con.GetAccessToken();
            //con.getComments();

        }
    }
}
