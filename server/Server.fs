module Server

open System
open Falco
open Falco.Routing
open Falco.HostBuilder
open Microsoft.AspNetCore.Cors.Infrastructure

open Shared

// In-memory "database"
let mutable todos: Todo list = []
let addTodo (todo: Todo) (todos: Todo list) = todos @ [todo]
let updateTodo todo todos = List.map (fun x -> if x.Id = todo.Id then todo else x) todos

todos <- addTodo (createTodo "Purchase groceries" false) todos
todos <- addTodo (createTodo "Change tires on car." true) todos

// HttpHandlers
type Error =
    | Internal of string * Exception
    | NotFound of string
    | Generic of string

let handleError =
    function
    | Internal (message, _)  -> Response.withStatusCode 500 >> Response.ofPlainText message
    | Generic message  -> Response.withStatusCode 400 >> Response.ofPlainText message
    | NotFound message -> Response.withStatusCode 404 >> Response.ofPlainText message

let getTodoIdFromRoute (routeCollection: RouteCollectionReader) =
    routeCollection.TryGetGuid "id"
    |> function
        | Some todoId -> Ok todoId
        | _ -> Error "No valid Todo Id found"

let handleGetTodos: HttpHandler = Response.ofJson todos
let handleGetTodo: HttpHandler =
    Request.mapRoute
        getTodoIdFromRoute (fun todoId ->
            match todoId with
            | Error error -> handleError (Error.Generic error)
            | Ok todoId ->
                todos
                |> List.tryFind (fun todo -> todo.Id = todoId)
                |> function
                    | Some foundTodo -> Response.ofJson foundTodo
                    | None -> handleError (Error.NotFound $"Unable to find Todo with Id: {todoId}")
            )
let handleCreateTodo: HttpHandler = Response.ofPlainText "NOT IMPLEMENTED"
let handleUpdateTodo: HttpHandler =
    Request.mapRoute
        getTodoIdFromRoute (fun todoId ->
            Request.mapJson (fun (todo: Todo) ->
                match todoId with
                | Error error -> handleError (Error.Generic error)
                | Ok todoId ->
                    // TODO: Update todo
                    Response.ofJson todo))
let handleDeleteTodo: HttpHandler = Response.ofPlainText "NOT IMPLEMENTED"

let corsPolicy (policyBuilder: CorsPolicyBuilder) =
    policyBuilder
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowAnyOrigin()
    |> ignore

let corsPolicyName = "corsPolicyName"
let corsOptions (options : CorsOptions) =
    options.AddPolicy(corsPolicyName, corsPolicy)

webHost [||] {
    use_cors corsPolicyName corsOptions

    endpoints [
        get "/todos" handleGetTodos
        get "/todos/{id:guid}" handleGetTodo
        post "/todos" handleCreateTodo
        put "/todos/{id:guid}" handleUpdateTodo
        delete "/todos/{id:guid}" handleDeleteTodo
    ]
}