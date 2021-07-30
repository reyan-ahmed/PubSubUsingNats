# Snow Test,
To run this application. Please run following commands.

1. dotnet restore
2. dotnet clean
3. dotnet watch run

Now you should able to see the application up and running. There is one thing which is pre-requisite which is [Nats.io] (https://nats.io) You make sure the nats server up and running locally,

In the top menu, We have two links. 

1. Send Message
2. Receive Message


## Send Message.
Using this you are able to send message using Send message service, Inside that service we are using nats and subject is coming from Appsettins. So Subject will be static throughout the application. And there is a list of history send message. Which user is sending. If you want to see this message you also can run command in your terminal make sure you already install Nats CLI as well then run this commad : nats sub SnowTest

## Receive Message.
In this menu you will able to see the message which is received by the Nats on that topic is defined inside appsettings, We have background service which keep up running and recieve message and store into a temporary store which I have created another service which just store the message and return it.



## What we can do better.
There is alot of things we can make it better. But I have to this task within 4hours that's why I couldn't able to do that. Like Nats connection right now is running on default connection, But it could be set through appsettings values. etc.


Thank you :)

