namespace CS322_PZ_V02_BojanPetrovic2745
{
    public partial class Patient_Kontrola
    {
        public int ID { get; set; }

        public int PatientID { get; set; }

        public int KontroalD { get; set; }

        public virtual Kontrola Kontrola { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
