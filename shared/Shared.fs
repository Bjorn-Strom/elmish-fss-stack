module Shared

open System

type Todo =
    { Id: Guid
      Title: string
      Done: bool
    }

module Route =
    let builder typeName methodName =
        sprintf "/api/%s/%s" typeName methodName

let createTodo title ``done`` =
    { Id = Guid.NewGuid()
      Title = title
      Done = ``done``
    }

type ITodosApi =
    { getTodos : unit -> Async<Todo list>
      addTodo : Todo -> Async<Todo>
      updateTodo : Todo -> Async<Todo>
    }