using GestionReservation.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionReservation.UC
{
    public partial class ucRoom : UserControl
    {
        public int Num { get; set; }
        DataClasses1DataContext dc = new DataClasses1DataContext();
        public void ShowStatus(DateTime dateRes) {
            foreach (Reservation res in ucHotel.DB.ListRes)
            {
                if(res.Num == this.Num && res.DateRes == dateRes.Date )
                {
                    this.BackColor = Color.Red;
                    return;
                }
            }
            this.BackColor = Color.Yellow;
        }
        public ucRoom()
        {
            InitializeComponent();
        }

        private void ucRoom_Load(object sender, EventArgs e)
        {
            lbNum.Text = Num.ToString();
        }

        private void libérerMenuItem_Click(object sender, EventArgs e)
        {

            var hotel = (from b in dc.Hotels where b.NumChambre == this.Num select b).First();
            dc.Hotels.DeleteOnSubmit(hotel);
            dc.SubmitChanges();
            foreach (Reservation res in ucHotel.DB.ListRes )
            {
                
                if (this.BackColor == Color.Red)
                {
                    this.BackColor = Color.Yellow;
                    return;
                }
            }
            this.BackColor = Color.Red;
        }

        private void réserverMenuItem_Click(object sender, EventArgs e)
        {
            Hotel a = new Hotel();
            a.Date = new DateTime(2021,07,23);
            a.NumChambre = this.Num;
            dc.Hotels.InsertOnSubmit(a);
            dc.SubmitChanges();
            
            foreach (Reservation res in ucHotel.DB.ListRes)
            {
                
                if (this.BackColor == Color.Yellow)
                {
                    this.BackColor = Color.Red;
                    return;
                }
            }
            this.BackColor = Color.Yellow;
        }
    }
}
