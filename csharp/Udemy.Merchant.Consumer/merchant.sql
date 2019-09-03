PRAGMA foreign_keys=OFF;
BEGIN TRANSACTION;
CREATE TABLE suppliers
(
Id INTEGER PRIMARY KEY NOT NULL,
Name TEXT NOT NULL,
Email TEXT NOT NULL
);
INSERT INTO suppliers VALUES(1,'the_supplier','supplier@merchant.com');
CREATE TABLE customers
(
Id INTEGER PRIMARY KEY  NOT NULL,
Name TEXT  NOT NULL,
Email TEXT  NOT NULL
);
INSERT INTO customers VALUES(1,'customer_1','customer@merchant.com');
INSERT INTO customers VALUES(2,'customer_2','customer@merchant.com');
INSERT INTO customers VALUES(3,'customer_3','customer@merchant.com');
INSERT INTO customers VALUES(42,'mclovin@test.com','mclovin');
CREATE TABLE products
(
Id Integer PRIMARY KEY NOT NULL,
SupplierId Integer NOT NULL,
Name TEXT NOT NULL,
Price INTEGER NOT NULL,
ArticleNumber TEXT NOT NULL,
FOREIGN KEY(SupplierId) REFERENCES suppliers(id)
);
INSERT INTO products VALUES(1,1,'product_1',42,'0815');
INSERT INTO products VALUES(2,1,'product_2',84,'0816');
INSERT INTO products VALUES(3,1,'product_3',21,'0817');
CREATE TABLE orderedproducts(Id INTEGER PRIMARY KEY NOT NULL, ProductId Integer Not Null, OrderId INTEGER NOT NULL);
INSERT INTO orderedproducts VALUES(1,1,1);
INSERT INTO orderedproducts VALUES(2,2,1);
INSERT INTO orderedproducts VALUES(3,3,1);
INSERT INTO orderedproducts VALUES(4,1,2);
INSERT INTO orderedproducts VALUES(5,2,2);
INSERT INTO orderedproducts VALUES(6,3,2);
INSERT INTO orderedproducts VALUES(7,1,3);
INSERT INTO orderedproducts VALUES(8,2,3);
INSERT INTO orderedproducts VALUES(9,3,3);
INSERT INTO orderedproducts VALUES(10,1,4);
INSERT INTO orderedproducts VALUES(11,2,4);
INSERT INTO orderedproducts VALUES(12,1,5);
INSERT INTO orderedproducts VALUES(13,2,5);
INSERT INTO orderedproducts VALUES(14,1,6);
INSERT INTO orderedproducts VALUES(15,2,6);
INSERT INTO orderedproducts VALUES(16,1,7);
INSERT INTO orderedproducts VALUES(17,3,7);
CREATE TABLE orders
(
Id Integer PRIMARY KEY NOT NULL,
CustomerId INTEGER NOT NULL,
SupplierId INTEGER NOT NULL,
FOREIGN KEY(CustomerId) REFERENCES customers(id),
FOREIGN KEY(SupplierId) REFERENCES suppliers(id)
);
INSERT INTO orders VALUES(1,1,1);
INSERT INTO orders VALUES(2,1,1);
INSERT INTO orders VALUES(3,1,1);
INSERT INTO orders VALUES(4,42,1);
INSERT INTO orders VALUES(5,42,1);
INSERT INTO orders VALUES(6,42,1);
INSERT INTO orders VALUES(7,42,1);
COMMIT;
