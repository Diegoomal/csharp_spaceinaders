using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

using System.IO;

namespace FormGames
{
    public class UtilSDK
    {
        public static string pega_caminho()
        {
            // link:http://stackoverflow.com/questions/6875904/how-do-i-find-the-parent-directory-in-c

            //DirectoryInfo directoryInfo = Directory.GetParent(Environment.CurrentDirectory);
            //var p = Directory.GetParent(directoryInfo.ToString()).ToString();
            
            return Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString();
        }
    }
}
