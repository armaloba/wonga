Wonga Solution
=========================
This solution contains three Console projects: Wonga.Consumer, Wonga.Producer, and Wonga.Tests.

Wonga.Consumer is a project that simulates a consumer that listens to a RabbitMQ message queue and prints a message to the console.

Wonga.Producer is a project that simulates a producer that sends a message to a RabbitMQ message queue and prints the message to the console.

Wonga.Tests is a project that contains xUnit unit tests for the Consumer and Producer projects.

Prerequisites
=========================================
1. Visual Studio 2022 Version 17.4.4 Community (or higher)
2. .NET Core 7.0 or higher
2. Docker Desktop for Windows
3. RabbitMQ: rabbitmq:3-management listening on port: 15672:5672

Running the Solution
=========================================
1. Clone this repository to your local machine.
2. Open the Wonga.sln solution file in Visual Studio 2022 version 17.4.4 community (or higher).
3. Build the solution by selecting "Build Solution" from the "Build" menu or by pressing "Ctrl+Shift+B".
4. Start RabbitMQ by running one of the following commands in a terminal or command prompt:
   docker start <name or ID of your rabbitmq instance> or
   docker run -it rabbitmq:3-management
5. Open RabbitMQ Management by navigating to http://localhost:15672/ and use guest for both usernamme and password.
6. Run the Wonga.Consumer and Wonga.Producer projects individually to see the communication between the producer and consumer services.

Running the Tests
==========================================
1. Open a terminal or command prompt and navigate to the directory where the Wonga.Tests.csproj file is located.
2. Run the following command to execute the tests:
   dotnet test
3. Alternatively, you can run the tests from Visual Studio by opening the Test Explorer window,
   selecting the tests you want to run, and clicking the "Run" button.


Running the build script
=========================================
Instead of building the solution from the "Build" menu of Visual Studio, you can build the 
solution and run the tests by running the following commands at the root of the solution folder:
1. msbuild Wonga.sln /t:Build
2. msbuild Wonga.sln /t:Test
Alternatively, you can combine the above 2 commands in one:
msbuild Wonga.sln /t:Build;Test
