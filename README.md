## 📝 Quick Notes

- Added Context folder for separated entity model using `.edmx`
- Checked that blank data is not accepted
- Validation added using Data Annotations
- Add and Edit use the same form for reusability
- Success messages handled via `TempData`
- Clean, responsive UI using Bootstrap


<p align="center">
  <img src="https://upload.wikimedia.org/wikipedia/commons/4/44/Microsoft_logo.svg" alt="Microsoft Logo" width="120" style="margin-right:25px;"/>
</p>

# 📚 Book Manager - ASP.NET MVC CRUD Application

This is a simple and efficient ASP.NET MVC application for managing a list of books. It demonstrates CRUD (Create, Read, Update, Delete) operations using **Entity Framework** and **Bootstrap** styling for a user-friendly UI.

---


---

## 🚀 Key Highlights

### 1. Context Folder with `.edmx` Entity Framework File
- The `Context` folder contains the **Entity Data Model (EDMX)** file which manages the database connection and auto-generates the `Book` class.
- This structure separates the data layer from the business logic, making the project more **organized** and **scalable**.
- You can manage large and multiple models more efficiently.

### 2. Bootstrap Styling Added
- Basic **Bootstrap 4/5** styling is integrated into forms and tables.
- UI components like buttons, alerts, and tables are styled for better user experience.
- Responsive and mobile-friendly layout for clean design.

### 3. Reusable Form for Add & Edit
- A single `Index.cshtml` view is used for both **Add** and **Edit** operations.
- This reduces code duplication and makes the application **DRY (Don't Repeat Yourself)**.
- Fields are dynamically populated during edit mode.

---

## 📁 Folder Structure

**Context** ---> This folder contains the EDMX Entity Framework file  
**Controllers** ---> BookController  
**Views** --->  
1. BookList View (It shows all the added books)  
2. Index View (It contains the form for Edit and Add Book)  

---

## 🛠️ Technologies Used

- **ASP.NET MVC 5**
- **Entity Framework (Database First)**
- **C#**
- **Bootstrap (CSS Framework)**
- **Razor View Engine**
- **SQL Server**

---

## 🔍 Features

- List all books with styled Bootstrap table.
- Add new book via `Index` form.
- Edit existing book using same form (pre-populated values).
- Delete confirmation with JavaScript `confirm()` prompt.
- Server-side validation using Data Annotations (`[Required]`, `[Range]`).
- TempData used for success messages after actions.

---

## 📥 How to Run This Project

1. Clone or download this repository.
2. Open the `.sln` file in **Visual Studio**.
3. Ensure that **Entity Framework** is restored and `BookModel.edmx` is properly connected to your SQL database.
4. Update the `Web.config` connection string if needed.
5. Run the project with `F5` or `Ctrl + F5`.

---

## ✅ Validation Details

- `Title`, `Author`, and `Price` fields are marked as **Required**.
- `Price` includes a `[Range]` validator to allow only valid decimal prices.
- `PublishedDate` is optional and supports date picker UI.
