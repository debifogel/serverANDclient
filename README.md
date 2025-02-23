# Task Manager Application

This repository contains a full-stack Task Manager application consisting of a Node.js server and a client application that interacts with the server API.

## Features

- Create new tasks
- Retrieve all tasks
- Update task completion status
- Delete tasks
- CORS enabled to allow access from any origin
- Swagger UI for easy API testing and documentation

## API Endpoints

### Server Endpoints

#### 1. Get All Tasks
GET /item

- **Response**: A list of all tasks.

#### 2. Create a New Task
POST /item

- **Request Body**: `json { "task": "Task name" }  
- **Response**: The created task object with an ID. 
#### 3. Update Task Completion Status ` 
PUT /item/{taskId} 
 - **Parameters**: - taskId: The unique identifier of the task. 
 - **Request Body**: `json { "IsComplete": true }  
 - **Response**: Success message if the task is found and updated, otherwise a not found error. 
 #### 4. Delete Task 
  DELETE /item/{taskId} 
  - **Parameters**: - taskId: The unique identifier of the task. 
  - **Response**: Success message if the task is found and deleted, otherwise a not found error. 
  ## Client Application The client application is designed to provide a user-friendly interface for interacting with the Task Manager API. It allows users to perform all CRUD operations on tasks directly from their web browser. ### Features - View all existing tasks in a list format - Add new tasks through a simple input form - Mark tasks as complete or incomplete - Delete tasks from the list - User-friendly interface for task management ### Installation 1. Navigate to the client directory: `bash cd client ` 2. Install client dependencies: `bash npm install ` 3. Run the client application: `bash npm start ` 4. Access the application in your web browser at http://localhost:3000 (or the port specified in your configuration). ## Getting Started with the Server ### Prerequisites - .NET 6.0 or higher - MySQL database server ### Installation 1. Clone the repository: `bash git clone https://github.com/debifogel/serverANDclient.git ` 2. Change directory to the cloned repository: `bash cd serverANDclient ` 3. Update your connection string in appsettings.json: `json { "ConnectionStrings": { "ToDoDB": "server=yourserver;database=yourdatabase;user=yourusername;password=yourpassword;" } } ` 4. Navigate to the server project directory: `bash cd server ` 5. Restore dependencies: `bash dotnet restore ` 6. Run the application: `bash dotnet run ` ## Swagger UI The API documentation is available through Swagger UI. Once the application is running, navigate to http://localhost:{port}/swagger to access it. ## License This project is licensed under the MIT License. ` ### Summary This README.md now includes information about the client application, its features, installation, and how to run it, making it comprehensive for users who wish to understand and utilize both the server and client aspects of your Task Manager application. Adjust the port and setup instructions as needed based on your actual implementation.