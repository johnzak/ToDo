-- Insert dummy data into the User table
INSERT INTO [User] (UserName, Pass, Name)
VALUES ('John', '123', 'John Doe'),
       ('JaneSmith', 'qwerty456', 'Jane Smith');

-- Insert dummy data into the ToDoList table
INSERT INTO ToDoList (UserID, PublicList)
VALUES (1, 1),
       (2, 0);

-- Insert dummy data into the ToDoItem table
INSERT INTO ToDoItem (Data, ToDoListID, Priority, Checked)
VALUES ('Buy groceries', 1, 'normal', 0),
       ('Finish project', 1, 'important', 0),
       ('Call client', 2, 'unimportant', 1),
       ('Do laundry', 2, 'normal', 1);
