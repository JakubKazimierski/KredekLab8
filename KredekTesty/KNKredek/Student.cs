using KNKredek.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace KNKredek
{
    public class Student : TalentedPerson, INotifyPropertyChanged
    {
        private int _motivation = 100;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public int? IndexNumber { get; set; }

        public bool IsActive { get; set; }

        public List<string> Skills { get; set; }

        public event EventHandler<EventArgs> StudentRest;

        public int Motivation
        {
            get => _motivation;
            set
            {
                _motivation = value;
                OnPropertyChanged();
            }
        }
        public override double SpecialPower => 0;
        public override double SpecialPowerUses => 0;

        public Student()
        {
            FirstName = CreateRandomName();
            IsActive = true;
            AddStudentSkills();
        }

        public void SetRandomIndexNumber()
        {
            var rnd = new Random();
            IndexNumber = rnd.Next(1, 900001);
        }

        private string CreateRandomName()
        {
            var randomNames = new[]
            {
                "Janusz",
                "Mariusz",
                "Halynka",
                "Sebus",
                "Dżesika"
            };

            return randomNames[
                new Random().Next(0, randomNames.Length)];
        }


        private void AddStudentSkills()
        {

        }

        public void TakeOneYearOff()
        {

        }

        public void TakeAllTheCodeIn2Hours()
        {
            var rnd = new Random();
            int IndexNumber = rnd.Next(1, 50);//method after labolatory

            Motivation -= IndexNumber;
        }

        public void Rest()
        {
            var motivationPoints = CalculateMotivationAfterRest();

            Motivation += motivationPoints;

            OnStundetRest(EventArgs.Empty);
        }

        protected virtual void OnStundetRest(EventArgs e)
        {
            StudentRest?.Invoke(this, e);
        }

        public int CalculateMotivationAfterRest()
        {
            var rnd = new Random();
            return rnd.Next(1, 51);
        }        

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
