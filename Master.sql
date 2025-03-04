CREATE TABLE Users (
    id BIGINT PRIMARY KEY IDENTITY,
    username NVARCHAR(50) NOT NULL,
    email NVARCHAR(100) NOT NULL UNIQUE,
    password NVARCHAR(255) NOT NULL,
    role NVARCHAR(20) NOT NULL, 
    created_at DATETIME DEFAULT GETDATE()
);

CREATE TABLE Categories (
    id BIGINT PRIMARY KEY IDENTITY,
    name NVARCHAR(100) NOT NULL,
    description NVARCHAR(255)
);

CREATE TABLE Products (
    id BIGINT PRIMARY KEY IDENTITY,
    name NVARCHAR(100) NOT NULL,
    description NVARCHAR(255),
    price DECIMAL(10, 2) NOT NULL,
    category_id BIGINT FOREIGN KEY REFERENCES Categories(id),
    seller_id BIGINT FOREIGN KEY REFERENCES Users(id),
    created_at DATETIME DEFAULT GETDATE()
);

CREATE TABLE Feedback (
    id BIGINT PRIMARY KEY IDENTITY,
    user_id BIGINT FOREIGN KEY REFERENCES Users(id),
    product_id BIGINT FOREIGN KEY REFERENCES Products(id),
    rating INT CHECK (rating BETWEEN 1 AND 5),
    comment NVARCHAR(255),
    created_at DATETIME DEFAULT GETDATE()
);

CREATE TABLE ContactUs (
    id BIGINT PRIMARY KEY IDENTITY,
    user_id BIGINT FOREIGN KEY REFERENCES Users(id),
    message NVARCHAR(255) NOT NULL,
    created_at DATETIME DEFAULT GETDATE()
);

CREATE TABLE Cart (
    id BIGINT PRIMARY KEY IDENTITY,
    user_id BIGINT FOREIGN KEY REFERENCES Users(id),
    product_id BIGINT FOREIGN KEY REFERENCES Products(id),
    quantity INT NOT NULL,
    created_at DATETIME DEFAULT GETDATE()
);

CREATE TABLE Orders (
    id BIGINT PRIMARY KEY IDENTITY,
    user_id BIGINT FOREIGN KEY REFERENCES Users(id),
    total_price DECIMAL(10, 2) NOT NULL,
    status NVARCHAR(20) NOT NULL, 
    created_at DATETIME DEFAULT GETDATE()
);

CREATE TABLE OrderItems (
    id BIGINT PRIMARY KEY IDENTITY,
    order_id BIGINT FOREIGN KEY REFERENCES Orders(id),
    product_id BIGINT FOREIGN KEY REFERENCES Products(id),
    quantity INT NOT NULL,
    price DECIMAL(10, 2) NOT NULL
);

CREATE TABLE Partners (
    id BIGINT PRIMARY KEY IDENTITY,
    name NVARCHAR(100) NOT NULL,
    contact_info NVARCHAR(255)
);

CREATE TABLE Transactions (
    id BIGINT PRIMARY KEY IDENTITY,
    order_id BIGINT FOREIGN KEY REFERENCES Orders(id),
    payment_method NVARCHAR(50) NOT NULL, 
    amount DECIMAL(10, 2) NOT NULL,
    transaction_date DATETIME DEFAULT GETDATE()
);