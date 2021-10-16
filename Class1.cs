using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Touch_Slides_Optimization
{
    public class GlobalClass
    {
        public static bool active = true;
        public static bool chosed = false;
        public static bool tmode = false;
        public static string version = "2.4.1.2";

        public static IntPtr slide_show_window = IntPtr.Zero;
        public static IntPtr main_window = IntPtr.Zero;
        public static bool straight_back = false;

        public static IntPtr Other_Form = IntPtr.Zero;
        public static IntPtr dw_window = IntPtr.Zero;

        public static bool next_builing = false;
        public static bool slide_show_on = false;
    }
}
