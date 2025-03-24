using System;
using System.Collections.Generic;

namespace MedicalLaboratory
{
    // Базовый класс для всех сущностей
    public abstract class Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Entity(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public abstract void DisplayInfo();
    }

    // Класс, представляющий пациента
    public class Patient : Entity
    {
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }

        public Patient(int id, string name, DateTime dateOfBirth, string gender)
            : base(id, name)
        {
            DateOfBirth = dateOfBirth;
            Gender = gender;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Пациент: {Name}, Дата рождения: {DateOfBirth.ToShortDateString()}, Пол: {Gender}");
            Console.WriteLine($"Добавлен новый пациент!");
        }
    }

    // Класс, представляющий врача
    public class Doctor : Entity
    {
        public string Specialization { get; set; }

        public Doctor(int id, string name, string specialization)
            : base(id, name)
        {
            Specialization = specialization;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Врач: {Name}, Специализация: {Specialization}");
        }

        public void AssignAnalysis(Patient patient, Analysis analysis)
        {
            {
                Console.WriteLine($"Врач {Name} назначил анализ {analysis.Name} пациенту {patient.Name}");
            }
        }

        // Класс, представляющий анализ
        public class Analysis : Entity
        {
            public string Description { get; set; }
            public DateTime AnalysisDate { get; set; }

            public Analysis(int id, string name, string description, DateTime analysisDate)
                : base(id, name)
            {
                Description = description;
                AnalysisDate = analysisDate;
            }

            public override void DisplayInfo()
            {
                Console.WriteLine($"Анализ: {Name}, Описание: {Description}, Дата проведения: {AnalysisDate.ToShortDateString()}");
            }
        }

        // Класс, представляющий медицинскую лабораторию
        public class MedicalLaboratory
        {
            public List<Patient> Patients { get; set; }
            public List<Doctor> Doctors { get; set; }
            public List<Analysis> Analyses { get; set; }

            public MedicalLaboratory()
            {
                Patients = new List<Patient>();
                Doctors = new List<Doctor>();
                Analyses = new List<Analysis>();
            }

            public void AddPatient(Patient patient)
            {
                Patients.Add(patient);
            }

            public void AddDoctor(Doctor doctor)
            {
                Doctors.Add(doctor);
            }

            public void AddAnalysis(Analysis analysis)
            {
                Analyses.Add(analysis);
            }

            public void DisplayAllInfo()
            {
                Console.WriteLine("Пациенты:");
                foreach (var patient in Patients)
                {
                    patient.DisplayInfo();
                }

                Console.WriteLine("\nВрачи:");
                foreach (var doctor in Doctors)
                {
                    doctor.DisplayInfo();
                }

                Console.WriteLine("\nАнализы:");
                foreach (var analysis in Analyses)
                {
                    analysis.DisplayInfo();
                }
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                // Создаем экземпляр медицинской лаборатории
                MedicalLaboratory lab = new MedicalLaboratory();

                // Создаем пациентов
                Patient patient1 = new Patient(1, "Иван Иванов", new DateTime(1985, 5, 15), "Мужской");
                Patient patient2 = new Patient(2, "Мария Петрова", new DateTime(1990, 8, 25), "Женский");

                // Создаем врачей
                Doctor doctor1 = new Doctor(1, "Доктор Смит", "Терапевт");
                Doctor doctor2 = new Doctor(2, "Доктор Джонс", "Хирург");

                // Создаем анализы
                Analysis analysis1 = new Analysis(1, "Общий анализ крови", "Анализ крови на общие показатели", DateTime.Now);
                Analysis analysis2 = new Analysis(2, "Биохимический анализ крови", "Анализ крови на биохимические показатели", DateTime.Now);

                // Добавляем пациентов, врачей и анализы в лабораторию
                lab.AddPatient(patient1);
                lab.AddPatient(patient2);
                lab.AddDoctor(doctor1);
                lab.AddDoctor(doctor2);
                lab.AddAnalysis(analysis1);
                lab.AddAnalysis(analysis2);

                // Врач назначает анализ пациенту
                doctor1.AssignAnalysis(patient1, analysis1);
                doctor2.AssignAnalysis(patient2, analysis2);

                // Выводим информацию о всех сущностях в лаборатории
                lab.DisplayAllInfo();
            }
        }
    }
}
