# 🗂️ Generic Repository CRUD Console App (C#)

Bu loyiha **C# Console Application** bo‘lib, unda **Generic Repository pattern** asosida
CRUD (Create, Read, Update, Delete) amallari amalga oshirilgan.

Loyiha **List<T>** orqali vaqtinchalik ma’lumot saqlaydi va
arxitektura, OOP hamda generics tushunchalarini o‘rganish uchun mo‘ljallangan.

---

## 🚀 Loyihaning imkoniyatlari

- Generic Repository (`Repository<T>`)
- CRUD amallari:
  - Create
  - GetAll
  - Update
  - Delete
- Console menyu orqali boshqarish
- Quyidagi modellarda CRUD:
  - 🏫 School
  - 🎓 Student
  - 👨‍🏫 Teacher
  - 📘 Subject
- `IEntity` va `IRepository<T>` interfeyslari
- Toza va tushunarli arxitektura

---

## 🧱 Arxitektura tuzilishi
Repository
│
├── Models
│ ├── School.cs
│ ├── Student.cs
│ ├── Teacher.cs
│ └── Subject.cs
│
├── IEntity.cs
├── IRepository.cs
├── Repository.cs
│
└── Program.cs


