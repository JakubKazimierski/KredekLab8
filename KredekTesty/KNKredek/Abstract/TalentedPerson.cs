namespace KNKredek.Abstract
{
    public abstract class TalentedPerson
    {
        public string TalentName { get; set; }
        public abstract double SpecialPower { get; }
        public abstract double SpecialPowerUses { get; }
        public double SpecialAttackPower => SpecialPower / SpecialPowerUses;
    }
}
