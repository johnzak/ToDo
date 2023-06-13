-- Add the ListName column with a default value to the ToDoList table
ALTER TABLE ToDoList
ADD ListName NVARCHAR(100) NOT NULL DEFAULT 'ToDo';
   