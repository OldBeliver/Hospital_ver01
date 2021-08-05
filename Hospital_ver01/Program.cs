using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_ver01
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isOpen = true;
            string userInput = "4";

            ReceptionWard _receptionWard = new ReceptionWard();

            while (isOpen)
            {
                Console.WriteLine($"--------------------------------");
                Console.WriteLine($"Отделение особо опасных инфекций");
                Console.WriteLine($"--------------------------------");
                Console.WriteLine($"Больные поступившие за последние сутки\n");

                switch (userInput)
                {
                    case "1":
                        _receptionWard.FilteredOrderBy();
                        break;
                    case "2":
                        _receptionWard.FilteredByAge();
                        break;
                    case "3":
                        _receptionWard.FilteredByDiagnosis();
                        break;
                    case "4":
                        _receptionWard.ShowInfo();
                        break;
                    case "9":
                        isOpen = false;
                        break;
                    default:
                        Console.WriteLine($"ошибка ввода команды");
                        break;
                }
                Console.WriteLine($"--------------------------------");
                Console.WriteLine($"1 - сортировать по фамилии\n2 - сортировать по возрасту\n3 - выбрать по диагнозу\n4 - сортировать по очередности поступления\n9 - выход");
                userInput = Console.ReadLine();
                Console.Clear();
            }
        }

        class ReceptionWard
        {
            private List<Patient> _patients;
            private int _patientsCount;

            private static Random rand = new Random();

            public ReceptionWard()
            {
                _patients = new List<Patient>();
                _patientsCount = 20;

                CreateNewPatient(_patientsCount);
            }

            public void CreateNewPatient(int number)
            {
                for (int i = 0; i < number; i++)
                {
                    _patients.Add(new Patient(CreateNewSurname(), CreateNewAge(), CreateNewDiagnosis()));
                }
            }

            public void ShowInfo()
            {
                for (int i = 0; i < _patients.Count; i++)
                {
                    Console.Write($"{i + 1:d2}. ");
                    _patients[i].ShowInfo();
                }
            }

            public void FilteredOrderBy()
            {
                var filtered = _patients.OrderBy(patient => patient.Name);

                foreach (var patient in filtered)
                {
                    patient.ShowInfo();
                }
            }

            public void FilteredByAge()
            {
                var filtered = _patients.OrderBy(patient => patient.Age);

                foreach (var patient in filtered)
                {
                    patient.ShowInfo();
                }
            }

            public void FilteredByDiagnosis()
            {
                Console.Write($"Введите диагноз: ");
                string userInput = Console.ReadLine();


                switch (userInput.ToLower())
                {
                    case "чума":
                        var filtered = _patients.Where(patient => patient.Diagnosis == "чума");
                        foreach (var patient in filtered)
                        {
                            patient.ShowInfo();
                        }
                        break;
                    case "холера":
                        filtered = _patients.Where(patient => patient.Diagnosis == "холера");
                        foreach (var patient in filtered)
                        {
                            patient.ShowInfo();
                        }
                        break;
                    case "сибирская язва":
                        filtered = _patients.Where(patient => patient.Diagnosis == "сибирская язва");
                        foreach (var patient in filtered)
                        {
                            patient.ShowInfo();
                        }
                        break;
                    default:
                        Console.WriteLine($"ошибка диагноза");
                        break;
                }
            }

            private string CreateNewSurname()
            {
                string firstPart = "Лиси";
                string lastPart = "цин";
                int caseCount = 7;

                switch (rand.Next(caseCount))
                {
                    case 0:
                        firstPart = "Петр";
                        break;
                    case 1:
                        firstPart = "Иван";
                        break;
                    case 2:
                        firstPart = "Вас";
                        break;
                    case 3:
                        firstPart = "Том";
                        break;
                    case 4:
                        firstPart = "Бот";
                        break;
                    case 5:
                        firstPart = "Кот";
                        break;
                    case 6:
                        firstPart = "Крот";
                        break;
                }

                switch (rand.Next(caseCount))
                {
                    case 0:
                        lastPart = "ов";
                        break;
                    case 1:
                        lastPart = "ин";
                        break;
                    case 2:
                        lastPart = "енко";
                        break;
                    case 3:
                        lastPart = "иков";
                        break;
                    case 4:
                        lastPart = "ченко";
                        break;
                    case 5:
                        lastPart = "ищев";
                        break;
                    case 6:
                        lastPart = "овец";
                        break;
                }

                return firstPart + lastPart;
            }

            private int CreateNewAge()
            {
                int minAge = 18;
                int maxAge = 100;

                int age = rand.Next(minAge, maxAge);
                return age;
            }

            private string CreateNewDiagnosis()
            {
                int caseCount = 3;
                string diagnosis = "без диагноза";

                switch (rand.Next(caseCount))
                {
                    case 0:
                        diagnosis = "чума";
                        break;
                    case 1:
                        diagnosis = "холера";
                        break;
                    case 2:
                        diagnosis = "сибирская язва";
                        break;
                }

                return diagnosis;
            }
        }

        class Patient
        {
            public string Name { get; private set; }
            public int Age { get; private set; }
            public string Diagnosis { get; private set; }

            public Patient(string name, int age, string diagnosis)
            {
                Name = name;
                Age = age;
                Diagnosis = diagnosis;
            }

            public void ShowInfo()
            {
                Console.WriteLine($"пациент {Name}, {Age} лет, дигноз {Diagnosis}");
            }
        }
    }
}
