namespace BrioTest.Radio.Structs
{
    struct SignalTime
    {
        public SignalTime(double timeToFirstResiever, double timeToSecondResiever, double timeToThirdResiever)
        {
            TimeToFirstResiever = timeToFirstResiever;
            TimeToSecondResiever = timeToSecondResiever;
            TimeToThirdResiever = timeToThirdResiever;
        }
        internal double TimeToFirstResiever;
        internal double TimeToSecondResiever;
        internal double TimeToThirdResiever;
    } 
}
