module Shared

open System

type Todo =
    { Id: Guid
      Title: string
      Done: bool
    }
let createTodo title ``done`` =
    { Id = Guid.NewGuid()
      Title = title
      Done = ``done``
    }