# Online Shopping Management System (C# WinForms + MySQL, MVC)

Student: Bakwiye Massa Patience (27388) — .NET Lab 3

A simple Windows Forms desktop app where the user manages the shop database
through a GUI. It follows the MVC pattern from the lab notes.

## Project structure

```
OnlineShoppingSystem
├── Database
│   └── OnlineShoppingDB.sql      <- creates the 9 tables + sample data
├── Models                        <- data classes + repositories (all SQL is here)
│   ├── Db.cs                     <- connection string
│   ├── User.cs / UserRepository.cs
│   ├── Category.cs / CategoryRepository.cs
│   ├── Product.cs / ProductRepository.cs
│   └── Order.cs / OrderRepository.cs
├── Controllers                   <- validation, calls the repositories
│   ├── UserController.cs
│   ├── CategoryController.cs
│   ├── ProductController.cs
│   └── OrderController.cs
├── Views                         <- Windows Forms (no SQL here)
│   ├── LoginForm
│   ├── MainForm
│   ├── UserForm
│   ├── CategoryForm
│   ├── ProductForm
│   └── OrderForm
└── Program.cs
```

MVC flow (example Save Product): user clicks Save → **ProductForm (View)** reads the
controls into a `Product` object → **ProductController** validates it →
**ProductRepository (Model)** runs a parameterized `INSERT` → MySQL saves it →
the form refreshes the grid.

## Features

- Login (passwords stored as SHA-256 hash)
- Manage Users (Admin only): add, update, delete, search
- Manage Categories (Admin only): add, update, delete, search
- Manage Products: add, update, delete, search (category chosen from a drop-down)
- Manage Orders: add, update, delete, search (customer + status)
- Database: Users, Categories, Products, Cart, Cart_Items, Orders, Order_Items,
  Payments, Deliveries — with primary keys, foreign keys and unique email

## How to run

1. Open **XAMPP Control Panel** and start **MySQL** (and Apache for phpMyAdmin).
2. Go to http://localhost/phpmyadmin → **SQL** tab → paste everything from
   `OnlineShoppingSystem/Database/OnlineShoppingDB.sql` → **Go**.
3. Open `OnlineShoppingSystem.sln` in **Visual Studio 2022**.
   The NuGet package **MySqlConnector** restores automatically
   (if not: Tools → NuGet Package Manager → install `MySqlConnector`).
4. If your MySQL has a password or another port, change it in `Models/Db.cs`.
5. Press **F5**.

Login accounts:

| Email | Password | Role |
|---|---|---|
| admin@shop.com | admin123 | Admin |
| customer@shop.com | 1234 | Customer |

## Upload to GitHub

```
git init
git add .
git commit -m "Online Shopping Management System - WinForms MVC"
git branch -M main
git remote add origin https://github.com/<your-username>/OnlineShoppingSystem.git
git push -u origin main
```
