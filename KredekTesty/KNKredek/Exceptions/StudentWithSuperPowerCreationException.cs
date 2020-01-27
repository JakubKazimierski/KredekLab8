using System;

namespace KNKredek.Exceptions
{
    class StudentWithSuperPowerCreationException : Exception
    {
        public StudentWithSuperPowerCreationException(string message, string talentName) : base(message)
        {
            RequestedTalentName = talentName;
        }

        public string RequestedTalentName { get; private set; }
    }
}
