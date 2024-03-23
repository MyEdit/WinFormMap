namespace WinFormMap
{
    internal class PersonMovement
    {
        public int Id { get; set; }
        public string PersonCode { get; set; }
        public string PersonRole { get; set; }
        public int LastSecurityPointNumber { get; set; }
        public string LastSecurityPointDirection { get; set; }
        public DateTime LastSecurityPointTime { get; set; }

        public PersonMovement(int Id, string PersonCode, string PersonRole, int LastSecurityPointNumber, string LastSecurityPointDirection, DateTime LastSecurityPointTime)
        {
            this.Id = Id;
            this.PersonCode = PersonCode;
            this.PersonRole = PersonRole;
            this.LastSecurityPointNumber = LastSecurityPointNumber;
            this.LastSecurityPointDirection = LastSecurityPointDirection;
            this.LastSecurityPointTime = LastSecurityPointTime;
        }
    }
}
