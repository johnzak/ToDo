-- Add the DateCreated column to the ToDoItem table
ALTER TABLE ToDoItem
ADD DateCreated DATETIME NOT NULL DEFAULT GETDATE();