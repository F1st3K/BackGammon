using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BackGammon
{

    public partial class BackGammon 
    {
        internal MainField Field;
        public BackGammon()
        {
            Field = new MainField();
        }
    }
}
