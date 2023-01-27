HapChats – Happy Chats


Realtime chat application. Like messenger or discord.

The application is created mainly in .Net MVC Core that is using Web Api to manage data in database.

App functionalities:

- User Management:
	- Create new account
	- Delete acount
	- Modify Account
	- Manage own profile

- Profile Management”
	- Set an profile image
	- Change data like first name, last name, age

- Friends Management:
	- Send friend request
	- Accept/Deny request
	- Delete friend from friend list

- Chats:
	- Open new chat with friends
	- Open new group chat with multiple users
	- Delete or modify chat properties like name of chat
	- Send messages on Public chat

App is actually gonna work on postgresql database with own user credentials management.

Api uses Token validation for allowing users to do anything.


Application is on default using postgresql, you can run containers using docker-compose
attatch to project or copy code below:

```Dockerfile
version: "3.9"
services:
  postgres:
    image: postgres
    environment:
      POSTGRES_USER: root
      POSTGRES_PASSWORD: toor
      POSTGRES_DB: chat
    ports:
      - "5432:5432/tcp"
    networks:
      - demo-net
    deploy:
      restart_policy:
        condition: on-failure
  adminer:
    image: adminer:latest
    ports:
      - "8180:8080/tcp"
    networks:
      - demo-net
    deploy:
      restart_policy:
        condition: on-failure

networks:
  demo-net:
```