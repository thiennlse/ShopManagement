-- Tạo bảng Members
CREATE TABLE Members (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(255),
    UserName NVARCHAR(100) UNIQUE NOT NULL,
    Password NVARCHAR(255) NOT NULL,
    Role NVARCHAR(50) NOT NULL  -- Thêm cột Role
);

-- Tạo bảng Blogs với quan hệ một-nhiều tới Members
CREATE TABLE Blogs (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(255),
    MemberId INT NOT NULL,
    FOREIGN KEY (MemberId) REFERENCES Members(Id) ON DELETE CASCADE
);

-- Tạo bảng Products
CREATE TABLE Products (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(255),
    Quantity INT NOT NULL,
    Price FLOAT NOT NULL,
    MemberId INT,
    FOREIGN KEY (MemberId) REFERENCES Members(Id) ON DELETE SET NULL
);

-- Tạo bảng Orders với quan hệ một-nhiều tới Members
CREATE TABLE Orders (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Description NVARCHAR(255),
    Quantity INT NOT NULL,
    TotalPrice FLOAT,
    MemberId INT NOT NULL,
    FOREIGN KEY (MemberId) REFERENCES Members(Id) ON DELETE CASCADE
);

-- Tạo bảng trung gian cho quan hệ nhiều-nhiều giữa Orders và Products
CREATE TABLE OrderProducts (
    OrderId INT NOT NULL,
    ProductId INT NOT NULL,
    PRIMARY KEY (OrderId, ProductId),
    FOREIGN KEY (OrderId) REFERENCES Orders(Id) ON DELETE CASCADE,
    FOREIGN KEY (ProductId) REFERENCES Products(Id) ON DELETE CASCADE
);
GO
-- Thêm dữ liệu giả vào bảng Members
INSERT INTO Members (Name, Description, UserName, Password, Role)
VALUES 
('John Doe', 'Admin member', 'johndoe', 'password123', 'Admin'),
('Jane Smith', 'User member', 'janesmith', 'password123', 'User'),
('Alice Johnson', 'Moderator member', 'alicejohnson', 'password123', 'Moderator'),
('Bob Brown', 'User member', 'bobbrown', 'password123', 'User'),
('Carol White', 'User member', 'carolwhite', 'password123', 'User');

-- Thêm dữ liệu giả vào bảng Blogs
INSERT INTO Blogs (Name, Description, MemberId)
VALUES 
('Tech Trends', 'Blog about the latest in technology.', 1),
('Health Tips', 'Daily health tips and tricks.', 2),
('Travel Diaries', 'Exploring the world one city at a time.', 3),
('Foodie Fun', 'A blog for food lovers.', 4),
('Book Club', 'A community for book lovers.', 1);

-- Thêm dữ liệu giả vào bảng Products
INSERT INTO Products (Name, Description, Quantity, Price, MemberId)
VALUES 
('Laptop', 'High-end gaming laptop', 10, 1200.99, 1),
('Smartphone', 'Latest model smartphone', 25, 799.99, 2),
('Headphones', 'Noise-cancelling headphones', 15, 199.99, 3),
('Backpack', 'Stylish travel backpack', 30, 59.99, 4),
('Camera', 'DSLR camera for photography', 8, 549.99, 5);

-- Thêm dữ liệu giả vào bảng Orders
INSERT INTO Orders (Description, Quantity, TotalPrice, MemberId)
VALUES 
('First order by John', 2, 2401.98, 1),
('Order by Jane', 1, 799.99, 2),
('Order by Alice', 3, 599.97, 3),
('Second order by John', 1, 1200.99, 1),
('Order by Bob', 2, 399.98, 4);

-- Thêm dữ liệu giả vào bảng OrderProducts
INSERT INTO OrderProducts (OrderId, ProductId)
VALUES 
(1, 1),
(1, 3),
(2, 2),
(3, 3),
(4, 1),
(5, 4),
(5, 2),
(3, 4),
(2, 5),
(1, 5);
