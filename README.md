AI Chatbot Project

This is an AI-powered chatbot application built with .NET 9 for the backend and Angular for the frontend. The chatbot uses the OpenAI API (e.g., GPT-3.5-turbo) to answer user questions in real-time.
Features

    Real-time Q&A: Users can ask questions and get answers in real-time.
    OpenAI Integration: Uses OpenAI API to generate responses.
    Cache System: Implements caching to improve performance and reduce redundant API calls.
    Standalone Angular Components: Utilizes Angular's standalone component structure for a modern and modular approach.
    Responsive Design: Frontend is designed to work seamlessly across different devices.

Technologies Used
Backend:

    .NET 9
    OpenAI-DotNet SDK
    Redis (for caching)
    ASP.NET Web API

Frontend:

    Angular 15+
    Angular Standalone Components
    Angular Material (optional, for styling)
    RxJS (for API calls)

Installation and Setup
Backend

    Clone the repository:

git clone https://github.com/your-repo/ai-chatbot-backend.git
cd ai-chatbot-backend

Restore dependencies:

dotnet restore

Update appsettings.json with your OpenAI API key:

{
  "OpenAI": {
    "ApiKey": "your-openai-api-key"
  }
}

Run the project:

    dotnet run

The backend will be available at: http://localhost:5000/api/chat/ask.
Frontend

    Navigate to the frontend folder:

cd chat-mind-frontend

Install dependencies:

npm install

Start the Angular development server:

    ng serve --open

The application will open in your default browser at http://localhost:4200.
API Endpoints
POST /api/chat/ask

Request Body:

{
  "question": "What is AI?"
}

Response:

{
  "question": "What is AI?",
  "answer": "AI stands for Artificial Intelligence..."
}

Usage

    Open the application in your browser (http://localhost:4200).
    Type a question in the input box and click the Ask button.
    Wait for the AI's response to appear below the input box.

Project Structure
Backend

ai-chatbot-backend/
├── Controllers/
│   ├── ChatController.cs        # API endpoint for handling chat
├── Services/
│   ├── OpenAIChatbotService.cs  # OpenAI API integration
├── appsettings.json             # Configuration (e.g., OpenAI API key)
└── Program.cs                   # Entry point for the .NET app

Frontend

chat-mind-frontend/
├── src/
│   ├── app/
│   │   ├── components/chat/      # Chat component
│   │   ├── services/chat.service.ts  # Chat service
│   ├── main.ts                   # Angular bootstrap
│   ├── index.html                # Angular entry point
├── angular.json                  # Angular project configuration
└── package.json                  # NPM dependencies

Future Improvements

    User Authentication: Add a login system to personalize user experience.
    Conversation History: Save and display user chat history.
    Error Handling: Improve frontend and backend error-handling mechanisms.
    Multilingual Support: Allow AI to respond in multiple languages.
    Deployment: Deploy on cloud services like Azure or AWS.

Contributing

Contributions are welcome! Please fork the repository, create a feature branch, and submit a pull request.
License

This project is licensed under the MIT License. See the LICENSE file for details.
Contact

If you have any questions or suggestions, feel free to contact me:

    Email: tunahan.ali.ozturk@outlook.com
    GitHub: Moongazing
