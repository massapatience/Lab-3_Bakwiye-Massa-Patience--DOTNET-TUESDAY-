-- Online Shopping Management System database
-- Run this in phpMyAdmin (XAMPP) -> SQL tab

CREATE DATABASE IF NOT EXISTS OnlineShoppingDB
  DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE OnlineShoppingDB;

CREATE TABLE Users (
    user_id INT NOT NULL AUTO_INCREMENT,
    full_name VARCHAR(100) NOT NULL,
    email VARCHAR(100) NOT NULL,
    password VARCHAR(255) NOT NULL,
    phone VARCHAR(20),
    address VARCHAR(200),
    role VARCHAR(20) NOT NULL DEFAULT 'Customer',
    PRIMARY KEY (user_id),
    UNIQUE (email)
) ENGINE=InnoDB;

CREATE TABLE Categories (
    category_id INT NOT NULL AUTO_INCREMENT,
    category_name VARCHAR(100) NOT NULL,
    description VARCHAR(255),
    PRIMARY KEY (category_id),
    UNIQUE (category_name)
) ENGINE=InnoDB;

CREATE TABLE Products (
    product_id INT NOT NULL AUTO_INCREMENT,
    category_id INT NOT NULL,
    product_name VARCHAR(100) NOT NULL,
    description VARCHAR(255),
    price DECIMAL(10,2) NOT NULL,
    quantity INT NOT NULL DEFAULT 0,
    image VARCHAR(255),
    PRIMARY KEY (product_id),
    FOREIGN KEY (category_id) REFERENCES Categories(category_id)
) ENGINE=InnoDB;

CREATE TABLE Cart (
    cart_id INT NOT NULL AUTO_INCREMENT,
    user_id INT NOT NULL,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY (cart_id),
    UNIQUE (user_id),
    FOREIGN KEY (user_id) REFERENCES Users(user_id)
) ENGINE=InnoDB;

CREATE TABLE Cart_Items (
    cart_item_id INT NOT NULL AUTO_INCREMENT,
    cart_id INT NOT NULL,
    product_id INT NOT NULL,
    quantity INT NOT NULL DEFAULT 1,
    PRIMARY KEY (cart_item_id),
    FOREIGN KEY (cart_id) REFERENCES Cart(cart_id),
    FOREIGN KEY (product_id) REFERENCES Products(product_id)
) ENGINE=InnoDB;

CREATE TABLE Orders (
    order_id INT NOT NULL AUTO_INCREMENT,
    user_id INT NOT NULL,
    order_date DATETIME DEFAULT CURRENT_TIMESTAMP,
    total_amount DECIMAL(10,2) NOT NULL,
    order_status VARCHAR(30) NOT NULL DEFAULT 'Pending',
    PRIMARY KEY (order_id),
    FOREIGN KEY (user_id) REFERENCES Users(user_id)
) ENGINE=InnoDB;

CREATE TABLE Order_Items (
    order_item_id INT NOT NULL AUTO_INCREMENT,
    order_id INT NOT NULL,
    product_id INT NOT NULL,
    quantity INT NOT NULL,
    unit_price DECIMAL(10,2) NOT NULL,
    PRIMARY KEY (order_item_id),
    FOREIGN KEY (order_id) REFERENCES Orders(order_id),
    FOREIGN KEY (product_id) REFERENCES Products(product_id)
) ENGINE=InnoDB;

CREATE TABLE Payments (
    payment_id INT NOT NULL AUTO_INCREMENT,
    order_id INT NOT NULL,
    payment_method VARCHAR(50) NOT NULL,
    amount DECIMAL(10,2) NOT NULL,
    payment_date DATETIME DEFAULT CURRENT_TIMESTAMP,
    payment_status VARCHAR(30) NOT NULL DEFAULT 'Pending',
    PRIMARY KEY (payment_id),
    UNIQUE (order_id),
    FOREIGN KEY (order_id) REFERENCES Orders(order_id)
) ENGINE=InnoDB;

CREATE TABLE Deliveries (
    delivery_id INT NOT NULL AUTO_INCREMENT,
    order_id INT NOT NULL,
    delivery_address VARCHAR(200) NOT NULL,
    delivery_date DATETIME,
    delivery_status VARCHAR(30) NOT NULL DEFAULT 'Pending',
    PRIMARY KEY (delivery_id),
    UNIQUE (order_id),
    FOREIGN KEY (order_id) REFERENCES Orders(order_id)
) ENGINE=InnoDB;

-- Sample data (passwords are stored as SHA-256 hashes)
-- admin@shop.com / admin123     customer@shop.com / 1234
INSERT INTO Users (full_name, email, password, phone, address, role) VALUES
('System Admin', 'admin@shop.com', SHA2('admin123', 256), '0788000000', 'Kigali', 'Admin'),
('Aline Uwase', 'customer@shop.com', SHA2('1234', 256), '0788111111', 'Huye', 'Customer');

INSERT INTO Categories (category_name, description) VALUES
('Electronics', 'Phones, laptops and accessories'),
('Clothes', 'Men and women clothes'),
('Food', 'Groceries and drinks');

INSERT INTO Products (category_id, product_name, description, price, quantity, image) VALUES
(1, 'Smartphone', 'Android phone 128GB', 250000, 10, ''),
(1, 'Headphones', 'Wireless headphones', 30000, 25, ''),
(2, 'T-Shirt', 'Cotton t-shirt', 8000, 50, ''),
(3, 'Rice 5kg', 'Local rice', 7500, 40, '');

INSERT INTO Orders (user_id, order_date, total_amount, order_status) VALUES
(2, NOW(), 38000, 'Pending');

INSERT INTO Order_Items (order_id, product_id, quantity, unit_price) VALUES
(1, 2, 1, 30000), (1, 3, 1, 8000);

INSERT INTO Payments (order_id, payment_method, amount, payment_status) VALUES
(1, 'Mobile Money', 38000, 'Pending');

INSERT INTO Deliveries (order_id, delivery_address, delivery_status) VALUES
(1, 'Huye', 'Pending');
