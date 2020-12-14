using Framework.Driverutilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EL.Computer.Pages
{
    public class Pages
    {
        [ThreadStatic]
        public static ListPage Lists;

        [ThreadStatic]
        public static AddProductPage ProductPage;

        public static void Init()
        {
            Lists = new ListPage(Driver.Current);
            ProductPage = new AddProductPage(Driver.Current);
        }
    }
}
