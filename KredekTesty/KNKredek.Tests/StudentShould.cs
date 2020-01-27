using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace KNKredek.Tests
{
    public class StudentShould
    {
        private readonly ITestOutputHelper _stdOut;
        
        public StudentShould(ITestOutputHelper stdOut)
        {
            _stdOut = stdOut;
        }
        
        [Fact(Skip = "no nie wiem")]
        public void BeActiveWhenNew()
        {
            //Console.WriteLine("Checking student");

            _stdOut.WriteLine("Checking Student");

            Student sut = new Student(); //system under test

            Assert.True(sut.IsActive); //assert
        }

        [Theory]
        [InlineData("Mirek ", "Handlarz")]
        [InlineData("Mirek ", "Hanssdd")]
        [InlineData("Mwddx ", "Handlarz")]
        [InlineData("sss ", "ddd")]
        [InlineData("ss ", "  ")]
        public void CalculateFullName(string firstName, string lastName)
        {
            Student sut = new Student();

            sut.FirstName = firstName;//act
            sut.LastName = lastName;

            Assert.Equal(firstName +" "+ lastName, sut.FullName, ignoreCase: true);//assert , bez ignore jest case sensitive

        }

        [Fact]
        public void CalculateFullNameStartsWithFirstName()
        {
            Student sut = new Student();

            sut.FirstName = "Kot";//act
            sut.LastName = "Student";

            Assert.StartsWith("Kot", sut.FullName);//assert , bez ignore jest case sensitive

        }


        [Fact]
        public void CalculateFullNameEndsWithLastName()
        {
            Student sut = new Student();

            sut.FirstName = "Kot";//act
            sut.LastName = "Student";

            Assert.EndsWith("Student", sut.FullName);//assert , bez ignore jest case sensitive

        }


        [Fact]
        public void CalculateFullName_Contains()
        {
            Student sut = new Student();

            sut.FirstName = "Mirek";//act
            sut.LastName = "Handlarz";

            Assert.Contains("Mirek Ha", sut.FullName);//assert , bez ignore jest case sensitive

        }


        [Fact]
        public void CalculateStudentMotivation()
        {
            Student sut = new Student();

            Assert.Equal(100, sut.Motivation);//equal do liczb

        }


        [Fact]
        public void CalculateStudentMotivationAfterRest()
        {
            Student sut = new Student();

            sut.Rest();

            Assert.InRange(sut.CalculateMotivationAfterRest(),0, 100);//equal do liczb

        }


        [Fact]
        public void MotivationAfterParty()
        {
            Student sut = new Student();

            sut.Rest();

            Assert.InRange(sut.Motivation,101,150);//equal do liczb

        }


        [Fact]
        public void MotivationAfterPartyII()
        {
            Student sut = new Student();

            sut.Rest();

            Assert.True(sut.Motivation>=101 && sut.Motivation<=150);//equal do liczb

        }


        [Fact]
        public void IndexCheck()
        {
            Student sut = new Student();


            sut.IndexNumber = 244999;

            //sut.SetRandomIndexNumber();

            Assert.NotNull(sut.IndexNumber);//equal do liczb

        }

        [Fact]
        public void RaiseRestEvent()
        {
            Student sut = new Student();

            //eventy do property change
            Assert.Raises<EventArgs>(
                handler => sut.StudentRest += handler,
                handler => sut.StudentRest -= handler,
                () => sut.Rest());
        }

        [Fact]
        public void RaisePropertyChangeEvent()
        {
            Student sut = new Student();

            Assert.PropertyChanged(sut, "Motivation", () => sut.TakeAllTheCodeIn2Hours());
        }
    }
}
