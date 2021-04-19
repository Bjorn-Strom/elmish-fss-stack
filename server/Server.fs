module Server

open Fable.Remoting.Server
open Fable.Remoting.Giraffe
open Saturn

open Shared

let mutable todos: Todo list = []
let addTodo (todo: Todo) (todos: Todo list) = todos @ [todo]
let updateTodo todo todos = List.map (fun x -> if x.Id = todo.Id then todo else x) todos

todos <- addTodo (createTodo "Purchase groceries" false) todos
todos <- addTodo (createTodo "Change tires on car." true) todos

let todosApi = { getTodos = fun () -> async { return todos }
                 addTodo = fun todo -> async { todos <- addTodo todo todos
                                               return todo }
                 updateTodo = fun todo -> async { todos <- updateTodo todo todos
                                                  return todo } }

let webApp =
    Remoting.createApi()
    |> Remoting.withRouteBuilder Route.builder
    |> Remoting.fromValue todosApi
    |> Remoting.buildHttpHandler

let app =
    application {
        use_router webApp
        use_static "dist"
        use_gzip
    }

run app