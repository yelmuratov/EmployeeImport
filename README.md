# EmployeeImport

A clean, production-ready **ASP.NET Core MVC** web application to import employee data from CSV files into SQL Server and manage them via a searchable, sortable, and editable data table.

🔗 **Live Demo**: [Visit Deployed App](http://openai0305-001-site1.jtempurl.com)

---

## ✨ Features

- Upload and parse CSV files using **CsvHelper**
- Import employee records into SQL Server
- View employees in a **searchable, sortable** DataTable
- Edit employee information via a Bootstrap modal
- **Responsive UI** using Bootstrap 5 and DataTables.js
- Follows **Clean Architecture** (Services, Repositories, Interfaces)
- Unit tested with **xUnit** and **Moq**
- Deployment-ready for platforms like **SmarterASP.NET**

---

## 💻 Technologies Used

- ASP.NET Core MVC (.NET 9)
- Entity Framework Core (Code First)
- SQL Server
- CsvHelper
- Bootstrap 5
- DataTables.js
- xUnit + Moq

---

## 📁 Project Structure

```
EmployeeImport/
├── Controllers/
├── Data/
├── Interfaces/
├── Models/
├── Services/
├── Utils/
├── Views/
├── appsettings.json
├── Program.cs
└── wwwroot/
```

---

## ⚙️ Setup Instructions

### 📋 Prerequisites

- .NET 9 SDK
- SQL Server (local or hosted)
- Visual Studio or VS Code
- Git

---

### 🚀 Running Locally

#### 1. **Clone the repository**

```bash
git clone https://github.com/yourusername/EmployeeImport.git
cd EmployeeImport
```

#### 2. **Configure the connection string**

Edit the `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SQL_SERVER;Database=EmployeeImport;User Id=YOUR_USER;Password=YOUR_PASSWORD;"
}
```

#### 3. **Apply the database migration**

```bash
dotnet ef database update
```

#### 4. **Run the application**

```bash
dotnet run
```

Visit `https://localhost:{port}` in your browser.

---

## 🧪 Running Tests

```bash
cd EmployeeImport.Tests
dotnet test
```

Tests are written using `xUnit` and `Moq` and cover:
- CSV parsing
- Employee service logic
- Repository abstraction

---

## 📄 CSV Format Example

```csv
PersonnelNumber,Name,Surname,DateOfBirth,PhoneNumber,Mobile,Address,Address2,ZipCode,Email,DateHired
JACK13,Jerry,Jackson,05/11/1974,2050508,6987457,115 Spinney Road,Luton,LU33DF,gerry.jackson@bt.com,04/18/2013
```

---

## 🛠 Deployment

- Easily deployable to platforms like **SmarterASP.NET**
- Update production connection string in `appsettings.Production.json`
- Ensure `.gitignore` excludes sensitive configs