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
        internal GameEvents Events;
        internal MainField Field;
        public BackGammon()
        {
            Events = new GameEvents();
            Field = new MainField(Events);
        }
    }
}
