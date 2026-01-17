using System;
using System.Collections.Generic;
using Repository;
using Repository.Models;

class Program
{
    
    static readonly Repository<School> schoolRepo = new Repository<School>();
    static readonly Repository<Student> studentRepo = new Repository<Student>();
    static readonly Repository<Teacher> teacherRepo = new Repository<Teacher>();
    static readonly Repository<Subject> subjectRepo = new Repository<Subject>();

    static void Main()
    {
        while (true)
        {
            PrintMainMenu();
            Console.Write("Tanlang (1-5): ");
            string choice = (Console.ReadLine() ?? "").Trim();

            switch (choice)
            {
                case "1": SchoolMenu(); break;
                case "2": StudentMenu(); break;
                case "3": TeacherMenu(); break;
                case "4": SubjectMenu(); break;
                case "5":
                    Console.WriteLine("Dastur yakunlandi.");
                    return;
                default:
                    Console.WriteLine("Noto'g'ri tanlov!");
                    Pause();
                    break;
            }
        }
    }

    static void PrintMainMenu()
    {
        Console.Clear();
        Console.WriteLine("====================================");
        Console.WriteLine("1. School");
        Console.WriteLine("2. Student");
        Console.WriteLine("3. Teacher");
        Console.WriteLine("4. Subject");
        Console.WriteLine("5. Exit");
        Console.WriteLine("====================================");
    }

    static void SchoolMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("============= SCHOOL MENU =============");
            Console.WriteLine("1. Create");
            Console.WriteLine("2. GetAll");
            Console.WriteLine("3. Update");
            Console.WriteLine("4. Delete");
            Console.WriteLine("5. Back");
            Console.WriteLine("=======================================");
            Console.Write("Tanlang (1-5): ");
            string choice = (Console.ReadLine() ?? "").Trim();

            switch (choice)
            {
                case "1": CreateSchool(); break;
                case "2": GetAllSchools(); break;
                case "3": UpdateSchool(); break;
                case "4": DeleteSchool(); break;
                case "5": return;
                default:
                    Console.WriteLine("Noto'g'ri tanlov!");
                    Pause();
                    break;
            }
        }
    }

    static void CreateSchool()
    {
        Console.Clear();
        Console.WriteLine("---- Create School ----");
        int id = ReadInt("ID: ");
        string name = ReadString("Name: ");
        string adress = ReadString("Adress: ");

        try
        {
            schoolRepo.Create(new School { Id = id, Name = name, Adress = adress });
            Console.WriteLine(" School qo'shildi!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Xatolik: " + ex.Message);
        }
        Pause();
    }

    static void GetAllSchools()
    {
        Console.Clear();
        Console.WriteLine("---- School List ----");
        var list = schoolRepo.GetAll();
        if (list.Count == 0)
        {
            Console.WriteLine("(bo'sh)");
            Pause();
            return;
        }

        foreach (var s in list)
            Console.WriteLine($"Id={s.Id} | Name={s.Name} | Adress={s.Adress}");

        Pause();
    }

    static void UpdateSchool()
    {
        Console.Clear();
        Console.WriteLine("---- Update School ----");
        int id = ReadInt("Qaysi ID yangilanadi: ");

        var old = schoolRepo.GetById(id);
        if (old == null)
        {
            Console.WriteLine(" Bunday ID topilmadi!");
            Pause();
            return;
        }

        string name = ReadString($"Name ({old.Name}): ", allowEmpty: true);
        string adress = ReadString($"Adress ({old.Adress}): ", allowEmpty: true);

        var updated = new School
        {
            Id = id,
            Name = string.IsNullOrWhiteSpace(name) ? old.Name : name,
            Adress = string.IsNullOrWhiteSpace(adress) ? old.Adress : adress
        };

        schoolRepo.Update(updated);
        Console.WriteLine("School yangilandi!");
        Pause();
    }

    static void DeleteSchool()
    {
        Console.Clear();
        Console.WriteLine("---- Delete School ----");
        int id = ReadInt("O'chiriladigan ID: ");

        bool ok = schoolRepo.DeleteById(id);
        Console.WriteLine(ok ? " O'chirildi!" : " Bunday ID topilmadi!");
        Pause();
    }



    static void StudentMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("============= STUDENT MENU =============");
            Console.WriteLine("1. Create");
            Console.WriteLine("2. GetAll");
            Console.WriteLine("3. Update");
            Console.WriteLine("4. Delete");
            Console.WriteLine("5. Back");
            Console.WriteLine("========================================");
            Console.Write("Tanlang (1-5): ");
            string choice = (Console.ReadLine() ?? "").Trim();

            switch (choice)
            {
                case "1": CreateStudent(); break;
                case "2": GetAllStudents(); break;
                case "3": UpdateStudent(); break;
                case "4": DeleteStudent(); break;
                case "5": return;
                default:
                    Console.WriteLine("Noto'g'ri tanlov!");
                    Pause();
                    break;
            }
        }
    }

    static void CreateStudent()
    {
        Console.Clear();
        Console.WriteLine("---- Create Student ----");
        int id = ReadInt("ID: ");
        string name = ReadString("Name: ");
        int age = ReadInt("Age: ");
        string school = ReadString("School (nomi): ");
        int grade = ReadInt("Grade: ");

        try
        {
            studentRepo.Create(new Student
            {
                Id = id,
                Name = name,
                Age = age,
                School = school,
                Grade = grade
            });
            Console.WriteLine("Student qo'shildi!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(" Xatolik: " + ex.Message);
        }

        Pause();
    }

    static void GetAllStudents()
    {
        Console.Clear();
        Console.WriteLine("---- Student List ----");
        var list = studentRepo.GetAll();
        if (list.Count == 0)
        {
            Console.WriteLine("(bo'sh)");
            Pause();
            return;
        }

        foreach (var s in list)
            Console.WriteLine($"Id={s.Id} | Name={s.Name} | Age={s.Age} | School={s.School} | Grade={s.Grade}");

        Pause();
    }

    static void UpdateStudent()
    {
        Console.Clear();
        Console.WriteLine("---- Update Student ----");
        int id = ReadInt("Qaysi ID yangilanadi: ");

        var old = studentRepo.GetById(id);
        if (old == null)
        {
            Console.WriteLine("Bunday ID topilmadi!");
            Pause();
            return;
        }

        string name = ReadString($"Name ({old.Name}): ", allowEmpty: true);
        string ageStr = ReadString($"Age ({old.Age}): ", allowEmpty: true);
        string school = ReadString($"School ({old.School}): ", allowEmpty: true);
        string gradeStr = ReadString($"Grade ({old.Grade}): ", allowEmpty: true);

        int age = old.Age;
        if (!string.IsNullOrWhiteSpace(ageStr) && int.TryParse(ageStr, out int a)) age = a;

        int grade = old.Grade;
        if (!string.IsNullOrWhiteSpace(gradeStr) && int.TryParse(gradeStr, out int g)) grade = g;

        var updated = new Student
        {
            Id = id,
            Name = string.IsNullOrWhiteSpace(name) ? old.Name : name,
            Age = age,
            School = string.IsNullOrWhiteSpace(school) ? old.School : school,
            Grade = grade
        };

        studentRepo.Update(updated);
        Console.WriteLine(" Student yangilandi!");
        Pause();
    }

    static void DeleteStudent()
    {
        Console.Clear();
        Console.WriteLine("---- Delete Student ----");
        int id = ReadInt("O'chiriladigan ID: ");

        bool ok = studentRepo.DeleteById(id);
        Console.WriteLine(ok ? "O'chirildi!" : "Bunday ID topilmadi!");
        Pause();
    }

   

    static void TeacherMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("============= TEACHER MENU =============");
            Console.WriteLine("1. Create");
            Console.WriteLine("2. GetAll");
            Console.WriteLine("3. Update");
            Console.WriteLine("4. Delete");
            Console.WriteLine("5. Back");
            Console.WriteLine("========================================");
            Console.Write("Tanlang (1-5): ");
            string choice = (Console.ReadLine() ?? "").Trim();

            switch (choice)
            {
                case "1": CreateTeacher(); break;
                case "2": GetAllTeachers(); break;
                case "3": UpdateTeacher(); break;
                case "4": DeleteTeacher(); break;
                case "5": return;
                default:
                    Console.WriteLine("Noto'g'ri tanlov!");
                    Pause();
                    break;
            }
        }
    }

    static void CreateTeacher()
    {
        Console.Clear();
        Console.WriteLine("---- Create Teacher ----");
        int id = ReadInt("ID: ");
        string name = ReadString("Name: ");
        string subject = ReadString("Subject: ");

        try
        {
            teacherRepo.Create(new Teacher { Id = id, Name = name, Subject = subject });
            Console.WriteLine("Teacher qo'shildi!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Xatolik: " + ex.Message);
        }
        Pause();
    }

    static void GetAllTeachers()
    {
        Console.Clear();
        Console.WriteLine("---- Teacher List ----");
        var list = teacherRepo.GetAll();
        if (list.Count == 0)
        {
            Console.WriteLine("(bo'sh)");
            Pause();
            return;
        }

        foreach (var t in list)
            Console.WriteLine($"Id={t.Id} | Name={t.Name} | Subject={t.Subject}");

        Pause();
    }

    static void UpdateTeacher()
    {
        Console.Clear();
        Console.WriteLine("---- Update Teacher ----");
        int id = ReadInt("Qaysi ID yangilanadi: ");

        var old = teacherRepo.GetById(id);
        if (old == null)
        {
            Console.WriteLine(" Bunday ID topilmadi!");
            Pause();
            return;
        }

        string name = ReadString($"Name ({old.Name}): ", allowEmpty: true);
        string subject = ReadString($"Subject ({old.Subject}): ", allowEmpty: true);

        var updated = new Teacher
        {
            Id = id,
            Name = string.IsNullOrWhiteSpace(name) ? old.Name : name,
            Subject = string.IsNullOrWhiteSpace(subject) ? old.Subject : subject
        };

        teacherRepo.Update(updated);
        Console.WriteLine(" Teacher yangilandi!");
        Pause();
    }

    static void DeleteTeacher()
    {
        Console.Clear();
        Console.WriteLine("---- Delete Teacher ----");
        int id = ReadInt("O'chiriladigan ID: ");

        bool ok = teacherRepo.DeleteById(id);
        Console.WriteLine(ok ? "O'chirildi!" : " Bunday ID topilmadi!!!");
        Pause();
    }



    static void SubjectMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("============= SUBJECT MENU =============");
            Console.WriteLine("1. Create");
            Console.WriteLine("2. GetAll");
            Console.WriteLine("3. Update");
            Console.WriteLine("4. Delete");
            Console.WriteLine("5. Back");
            Console.WriteLine("========================================");
            Console.Write("Tanlang (1-5): ");
            string choice = (Console.ReadLine() ?? "").Trim();

            switch (choice)
            {
                case "1": CreateSubject(); break;
                case "2": GetAllSubjects(); break;
                case "3": UpdateSubject(); break;
                case "4": DeleteSubject(); break;
                case "5": return;
                default:
                    Console.WriteLine("Noto'g'ri tanlov!");
                    Pause();
                    break;
            }
        }
    }

    static void CreateSubject()
    {
        Console.Clear();
        Console.WriteLine("---- Create Subject ----");
        int id = ReadInt("ID: ");
        string name = ReadString("Name: ");
        int gradeLevel = ReadInt("GradeLevel: ");

        try
        {
            subjectRepo.Create(new Subject { Id = id, Name = name, GradeLevel = gradeLevel });
            Console.WriteLine("Subject qo'shildi!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(" Xatolik: " + ex.Message);
        }
        Pause();
    }

    static void GetAllSubjects()
    {
        Console.Clear();
        Console.WriteLine("---- Subject List ----");
        var list = subjectRepo.GetAll();
        if (list.Count == 0)
        {
            Console.WriteLine("(bo'sh)");
            Pause();
            return;
        }
        // yangilandi
        foreach (var s in list)
            Console.WriteLine($"Id={s.Id} | Name={s.Name} | GradeLevel={s.GradeLevel}");

        Pause();
    }

    static void UpdateSubject()
    {
        Console.Clear();
        Console.WriteLine("---- Update Subject ----");
        int id = ReadInt("Qaysi ID yangilanadi: ");

        var old = subjectRepo.GetById(id);
        if (old == null)
        {
            Console.WriteLine(" Bunday ID topilmadi!");
            Pause();
            return;
        }

        string name = ReadString($"Name ({old.Name}): ", allowEmpty: true);
        string glStr = ReadString($"GradeLevel ({old.GradeLevel}): ", allowEmpty: true);

        int gradeLevel = old.GradeLevel;
        if (!string.IsNullOrWhiteSpace(glStr) && int.TryParse(glStr, out int gl)) gradeLevel = gl;

        var updated = new Subject
        {
            Id = id,
            Name = string.IsNullOrWhiteSpace(name) ? old.Name : name,
            GradeLevel = gradeLevel
        };

        subjectRepo.Update(updated);
        Console.WriteLine("Subject yangilandi!");
        Pause();
    }

    static void DeleteSubject()
    {
        Console.Clear();
        Console.WriteLine("---- Delete Subject ----");
        int id = ReadInt("O'chiriladigan ID: ");

        bool ok = subjectRepo.DeleteById(id);
        Console.WriteLine(ok ? "O'chirildi!" : "Bunday ID topilmadi!");
        Pause();
    }


    static void Pause()
    {
        Console.WriteLine();
        Console.Write("Davom etish uchun Enter bosing...");
        Console.ReadLine();
    }

    static int ReadInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string s = (Console.ReadLine() ?? "").Trim();
            if (int.TryParse(s, out int v)) return v;

            Console.WriteLine(" Iltimos, butun son kiriting!");
        }
    }

    static string ReadString(string prompt, bool allowEmpty = false)
    {
        while (true)
        {
            Console.Write(prompt);
            string s = Console.ReadLine() ?? "";
            if (allowEmpty) return s.Trim();

            s = s.Trim();
            if (!string.IsNullOrWhiteSpace(s)) return s;

            Console.WriteLine(" Bo'sh qiymat kiritmang!");
        }
    }
}
