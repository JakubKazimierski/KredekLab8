using KNKredek.Abstract;
using KNKredek.Exceptions;
using System;

namespace KNKredek
{
    public class StudentFactory
    {
        public TalentedPerson Create(string talentName, bool isStudentFromKredek = false)
        {
            if (!(talentName is null))
            {
                if (isStudentFromKredek)
                {
                    if (!IsValidSuperTalentName(talentName))
                    {
                        throw new StudentWithSuperPowerCreationException(
                            $"{talentName} is not a valid name",
                            talentName);
                    }

                    return new KredekStudent { TalentName = talentName };
                }

                return new Student { TalentName = talentName };
            }

            throw new ArgumentNullException(nameof(talentName));
        }

        private bool IsValidSuperTalentName(string name)
        {
            return name.StartsWith(".Net") || name.StartsWith("xUnit");
        }
    }
}
