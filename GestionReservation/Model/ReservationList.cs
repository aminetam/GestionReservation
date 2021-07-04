using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionReservation.Model
{
    public class ReservationList
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
       
        public List<Reservation> ListRes { get; set; }

        public ReservationList()
        {
                     
            ListRes = new List<Reservation>{};
            for (int i=0; i<dc.Hotels.Count();i++)
            {
                Reservation res = new Reservation(dc.Hotels.Skip(i).First().NumChambre, dc.Hotels.Skip(i).First().Date);
                
                ListRes.Add(res);
                
            }
            Reservation res1 = new Reservation(9, new DateTime(2021, 7, 23));
            
            dc.SubmitChanges();



        }
    }
}
