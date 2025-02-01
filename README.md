# HiTech Management System - Inventory System for Operating Systems

This project is a Windows application built using **C#** and **Visual Studio 2019**. It is an inventory management system that supports different types of users with specific roles, such as:

- **MIS Manager**
- **Sales Manager**
- **Inventory Controller**
- **Order Clerk**

Each user type has their own tab with specific features they have access to. The application includes a login page where users can securely log in, and they can also change their password.

## Features

### General Features:
- **Login Page**: All users must log in with their credentials before accessing the system.
- **Change Password**: Users can change their passwords for added security.

### User-Specific Features:

#### MIS Manager:
- Has access to **all features** in the system.
- Can view and manage data for all users and departments.

#### Sales Manager:
- Keeps track of **clients and orders**.
- Can **search for clients** and view a list of **orders** they have made in a **ListView**.
  
#### Inventory Controller:
- Responsible for managing the inventory.
- Can view inventory details, such as stock levels, and make updates.

#### Order Clerk:
- Handles **order processing** and can view order details.
- Can **search for orders** made by clients, using the search feature.

## Technology Stack
- **C#**: The primary programming language used for the development of the application.
- **Visual Studio 2019**: The Integrated Development Environment (IDE) used for building the application.
- **Windows Forms**: Used to create the GUI (Graphical User Interface) for the application.

## Installation

1. Clone the repository to your local machine.
2. Open the project in **Visual Studio 2019**.
3. Build and run the project.

## How to Use

1. **Log In**: Enter your credentials on the login page.
2. **Navigation**: After logging in, you will be redirected to your respective tab depending on your user role.
3. **Features**: Use the features available to your user role, including managing orders, clients, and inventory.

## Conclusion

This project was developed as part of a school assignment, and I really enjoyed the process of building it. It helped me improve my skills in C# and Windows application development. I hope this application is useful for learning about inventory management systems, and it can serve as a foundation for future projects.
