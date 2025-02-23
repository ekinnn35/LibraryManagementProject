# LibraryManagementProject

## 📖 Project Overview
FenerLibrary is a **Library Management System** built using **ASP.NET Core MVC**. This application allows users to manage books and authors dynamically, performing CRUD operations without a persistent database.

## 🚀 Features
- **Book Management**: Add, edit, view, and delete books.
- **Author Management**: Add, edit, view, and delete authors.
- **Dynamic Data Handling**: Uses in-memory lists instead of a database.
- **MVC Architecture**: Follows the Model-View-Controller pattern.
- **Elegant UI**: Styled with custom CSS for a user-friendly experience.
- **Partial Views**: Uses `_Layout.cshtml` and `_NavbarPartial.cshtml` for a consistent layout.

## 📂 Project Structure
The project is organized as follows:
```
FenerLibrary
│-- wwwroot
│   │-- css/site.css       # Global styles
│   │-- js/site.js         # JavaScript file
│-- Controller
│   │-- AuthorController.cs # Handles author-related operations
│   │-- BookController.cs   # Handles book-related operations
│   │-- HomeController.cs   # Manages home and about pages
│-- Models
│   │-- Author.cs           # Author model
│   │-- AuthorViewModel.cs  # Author ViewModel
│   │-- Book.cs             # Book model
│   │-- BookViewModel.cs    # Book ViewModel
│-- Views
│   │-- Author
│   │   │-- Create.cshtml   # Add a new author
│   │   │-- Delete.cshtml   # Delete an author
│   │   │-- Details.cshtml  # View author details
│   │   │-- Edit.cshtml     # Edit an author
│   │   │-- List.cshtml     # List all authors
│   │-- Book
│   │   │-- Create.cshtml   # Add a new book
│   │   │-- Delete.cshtml   # Delete a book
│   │   │-- Details.cshtml  # View book details
│   │   │-- Edit.cshtml     # Edit a book
│   │   │-- List.cshtml     # List all books
│   │-- Home
│   │   │-- About.cshtml    # About page
│   │   │-- Index.cshtml    # Home page
│   │-- Shared
│   │   │-- _FooterPartial.cshtml  # Footer
│   │   │-- _Layout.cshtml         # Layout file
│   │   │-- _NavbarPartial.cshtml  # Navigation bar
│   │   │-- _ViewImports.cshtml
│   │   │-- _ViewStart.cshtml
│-- appsettings.json       # Configuration file
│-- Program.cs             # Entry point of the application
```

## 🎯 Getting Started
### Prerequisites
- .NET 8.0 or later
- Visual Studio / VS Code

2. Open in Visual Studio and run the project.
3. Access the application in your browser at:
   ```
   http://localhost:PORT/7187
   ```

## ✨ Technologies Used
- **ASP.NET Core MVC**
- **C#**
- **HTML/CSS/Bootstrap**
- **JavaScript**

## 🤝 Contributors
- **Ekin Öztürk** - Developer & Designer


---

🚀 **Enjoy using FenerLibrary!** If you have any questions, feel free to reach out. 🏆

