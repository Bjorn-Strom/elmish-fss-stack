# Elmish-fss-stack

A simple F# elmish fullstack template.

Frontend:
- F# 5
- Fable 3
- Paket
- Fss
- Elmish

Backend:
- Suave
- Fable remoting

This template implements the basic todo sample from https://reactjs.org/ and has a route to add and complete todos.

Inspired by the [SAFE-stack](https://safe-stack.github.io/)

## Why another stack though?
While the SAFE-STACK is awesome I got tired of dealing with webpack and fake.
I find those things really annoying and I prefer simpler more lightweight alternatives.

## How to run:
Before running:
```
dotnet tool restore
dotnet paket install
```

Open two terminals:
In one:
```
cd server
dotnet run
```
In the other:
```
cd client
npm install
npm start
```

Go to localhost:1234.

## Building
I have included a super simple `Dockerfile` you can use to build the backend and have it serve the frontend as static files.
Deploy this file wherever.
