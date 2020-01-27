using KNKredek.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace KNKredek.Tests
{
    public class StudentFactoryShould
    {
        [Fact]
        public void CreateStudent_NotInKredek()
        {
            StudentFactory sut = new StudentFactory();

            TalentedPerson student = sut.Create("StudentWithoutSuperPowe");

            Assert.IsType<Student>(student);
        }

        [Fact]
        public void CreateSeparateObjects()
        {
            StudentFactory sut = new StudentFactory();

            TalentedPerson student1 = sut.Create("StudentWithoutSuperPower");
            TalentedPerson student2 = sut.Create("StudentWithoutSuperPower");

            Assert.NotSame(student1, student2);
        }


        [Fact]
        public void NotAllowFullNames()
        {
            StudentFactory sut = new StudentFactory();

            
            Assert.Throws<ArgumentNullException>(() => sut.Create(null));
        }


    }
}
