using SQLite;
using SQLiteNetExtensions.Attributes;

namespace PhisilyncFinal.Models
{
    public class TreatmentDashboard
    {

        [PrimaryKey,AutoIncrement]
        public int treatmentDashID { get; set; }

        [ForeignKey(typeof(Treatment))]
        public int treatmentDashboardTreatment { get; set; }


        [ForeignKey(typeof(TreatmentAction))]
        public int treatmentActionTestID { get; set; }

        [ForeignKey(typeof(TreatmentAction))]
        public int treatmentActionReleaseID { get; set; }

        [ForeignKey(typeof(User))]
        public int UserId { get; set; }
       

        public DateTime treatmentDashDate { get; set; }
        public bool treatmentDashDone { get; set; }
    }
}