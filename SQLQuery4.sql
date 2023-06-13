-- Insert sample data into User table
INSERT INTO [User] (Id, UserName, Pass, Name)
VALUES ('1', 'john_doe', 'password123', 'John Doe'),
       ('2', 'jane_smith', 'letmein', 'Jane Smith');

-- Insert sample data into ToDoList table
INSERT INTO ToDoList (Id, UserID, Publiclist)
VALUES (1, '1', 1),
       (2, '1', 0),
       (3, '2', 1);

-- Insert sample data into ToDoItem table
INSERT INTO ToDoItem (Id, Data, ToDoListID, Priority, Checked)
VALUES (1, 'Buy groceries', 1, 'normal', 0),
       (2, 'Finish project report', 1, 'important', 0),
       (3, 'Call mom', 2, 'normal', 1),
       (4, 'Pay bills', 3, 'unimportant', 0);
