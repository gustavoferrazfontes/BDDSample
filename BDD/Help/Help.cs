using System;

namespace BDD.Help
{
    public class Help
    {
        public DateTime FormatDataDateTime(string dt)
        {
            return Convert.ToDateTime(dt.Insert(2, "/").Insert(5, "/"));
        }
    }
}
