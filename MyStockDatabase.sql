CREATE Database MyStock


CREATE TABLE Cars (
    CarId INT PRIMARY KEY,
    CarName VARCHAR(50),
    Manufacturer VARCHAR(50),
    Price DECIMAL(10, 2),
    ReleaseYear INT
);

INSERT INTO Cars (CarId, CarName, Manufacturer, Price, ReleaseYear)
VALUES
    (1, 'Toyota Camry', 'Toyota', 25000.00, 2021),
    (2, 'Honda Civic', 'Honda', 22000.00, 2022),
    (3, 'Ford Mustang', 'Ford', 35000.00, 2020),
    (4, 'Chevrolet Cruze', 'Chevrolet', 18000.00, 2019),
    (5, 'BMW 3 Series', 'BMW', 40000.00, 2021),
    (6, 'Mercedes-Benz E-Class', 'Mercedes-Benz', 55000.00, 2022),
    (7, 'Audi A4', 'Audi', 45000.00, 2020),
    (8, 'Nissan Altima', 'Nissan', 23000.00, 2022),
    (9, 'Hyundai Sonata', 'Hyundai', 20000.00, 2019),
    (10, 'Kia Optima', 'Kia', 21000.00, 2021),
    (11, 'Mazda 6', 'Mazda', 24000.00, 2020),
    (12, 'Subaru Outback', 'Subaru', 28000.00, 2022),
    (13, 'Volkswagen Golf', 'Volkswagen', 26000.00, 2019),
    (14, 'Volvo S60', 'Volvo', 39000.00, 2021),
    (15, 'Lexus ES', 'Lexus', 42000.00, 2022);