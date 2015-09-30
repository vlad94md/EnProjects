CREATE TABLE Authors
(
Id int Identity(1,1) primary key,
First_name varchar(25),
Last_name varchar(25),
Country varchar(25)
)

CREATE TABLE Categorys
(
Id int Identity(1,1) primary key,
Name varchar(25)
)

CREATE TABLE Books
(
Id int Identity(1,1) primary key,
Title varchar(55),
Descriptn varchar(300),
Price money,
CategoryId int,
AuthorId int,
FOREIGN KEY (AuthorId) REFERENCES Authors(Id),
FOREIGN KEY (CategoryId) REFERENCES Categorys(Id),
)

INSERT INTO Authors VALUES 
('Mark','Twain','USA'),
('Jules','Verne','France'),
('Lev','Tolstoy','Russia'),
('Charles','Dickens','Great Britain')

INSERT INTO Categorys VALUES 
('Drama'),('Horror'),('Fanstasy'),('Novel')


INSERT INTO Books VALUES 
('Oliver Twist','Oliver Twist is notable for Dickenss unromantic portrayal of criminals and their sordid lives', 250, 4, 4),
('A Tale of Two Cities','The novel depicts the plight of the French peasantry demoralised by the French aristocracy in the years leading up to the revolution', 310, 4, 4),
('Anna Karenina','Widely regarded as a pinnacle in realist fiction, Tolstoy considered Anna Karenina his first true novel, after he came to consider War and Peace to be more than a novel.', 150, 1, 3),
('War and Peace','War and Peace is well known as being one of the longest novels ever written, though not the longest.', 520, 4, 3),
('The Adventures of Tom Sawyer','An novel about a young boy growing up along the Mississippi River. It is set in the fictional town of St. Petersburg, inspired by Hannibal, Missouri, where Twain lived', 450, 4, 1)

