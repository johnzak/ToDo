-- Add a foreign key constraint to create a one-to-many relationship between User and ToDoList
ALTER TABLE ToDoList
ADD CONSTRAINT FK_ToDoList_User
FOREIGN KEY (UserID)
REFERENCES [User](Id);

-- Add a foreign key constraint to create a one-to-many relationship between ToDoList and ToDoItem
ALTER TABLE ToDoItem
ADD CONSTRAINT FK_ToDoItem_ToDoList
FOREIGN KEY (ToDoListID)
REFERENCES ToDoList(Id);