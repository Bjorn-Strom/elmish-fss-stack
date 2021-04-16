module Client

open Elmish
open Elmish.React
open Fable.React
open Fable.React.Props
open Fable.Remoting.Client
open Fss

open Shared

// Colors
let blue = hex "0d6efd"
let darkBlue = hex "01398D"

// Font
let textFont = FontFamily.custom "Roboto"
let container =
    fss
        [
            Display.flex
            FlexDirection.column
            Padding.value(rem 0., rem 1.5)
            textFont
        ]
let header = fss [ Color' blue ]
let todoStyle =
    let fadeInAnimation =
        keyframes
            [
                frame 0
                    [
                        Opacity' 0.
                        Transforms [ Transform.translateY <| px 20 ]
                    ]
                frame 100
                    [
                        Opacity' 1.
                        Transforms [ Transform.translateY <| px 0 ]
                    ]
            ]
    let indexCounter = counterStyle []
    fss
        [
            Display.flex
            CounterIncrement' indexCounter
            FontSize' (px 20)
            AnimationName' fadeInAnimation
            AnimationDuration' (sec 0.4)
            AnimationTimingFunction.ease
            ListStyleType.none
            Width.maxContent
            MaxHeight.value(em 1.)
            Before
                [ Color.hex "48f"
                  Content.counter(indexCounter,". ")
                ]
            Hover [ Cursor.pointer ]
        ]
let formStyle =
    [
        Display.inlineBlock
        Padding.value(px 10, px 15)
        FontSize' (px 18);
        BorderRadius' (px 0)
    ]
let buttonStyle =
    fss
        [
            yield! formStyle
            Border.none
            BackgroundColor' blue
            Color.white
            Width' (em 10.)
            Hover
                [
                    Cursor.pointer
                    BackgroundColor' darkBlue
                ]
        ]
let inputStyle =
    fss
        [
            yield! formStyle
            BorderRadius' (px 0)
            BorderWidth.thin
            MarginRight' (px 25)
            Width' (px 400)
        ]

// Elmish
let todosApi =
    Remoting.createApi()
    |> Remoting.withRouteBuilder Route.builder
    |> Remoting.buildProxy<ITodosApi>

type Model = {
    Input: string
    Todos: Todo list
    }

type Msg =
    | SetInput of string
    | AddTodo of string
    | AddedTodo of Todo
    | UpdateTodo of Todo
    | UpdatedTodo of Todo
    | GotTodos of Todo list

let init() =
    { Input = ""
      Todos = [] }, Cmd.OfAsync.perform todosApi.getTodos () GotTodos

let update (msg: Msg) (model: Model) =
    match msg with
    | SetInput input ->
        { model with Input = input }, Cmd.none
    | AddTodo todo ->
        let newTodo = createTodo todo false
        { model with Input = "" }, Cmd.OfAsync.perform todosApi.addTodo newTodo AddedTodo
    | AddedTodo todo ->
        { model with Todos = model.Todos @ [todo] }, Cmd.none
    | UpdateTodo todo ->
        { model with Input = "" }, Cmd.OfAsync.perform todosApi.updateTodo todo UpdatedTodo
    | UpdatedTodo todo ->
        { model with Todos = List.map (fun x -> if x.Id = todo.Id then todo else x) model.Todos }, Cmd.none
    | GotTodos todos ->
        { model with Todos = todos }, Cmd.none

let todo todo dispatch =
    let doneStyle =
        fss [ TextDecorationLine.lineThrough
              Color.green ]

    li [ OnClick (fun _ -> dispatch (UpdateTodo { todo with Done = not todo.Done })); ClassName <| combine [ todoStyle ] [ doneStyle, todo.Done ] ]
        [
            str todo.Title
        ]

let render (model: Model) (dispatch: Msg -> unit) =
    div [ ClassName container ]
        [
            h2 [ ClassName header ] [ str "TODO" ]
            ul [] <| List.map (fun x -> todo x dispatch) model.Todos
            div []
                [
                    input
                        [
                            ClassName inputStyle
                            Placeholder "What needs to be done?"
                            Value model.Input
                            OnChange (fun e -> e.Value |> SetInput |> dispatch)
                        ]
                    button
                        [
                            ClassName buttonStyle
                            OnClick (fun _ -> model.Input |> AddTodo |> dispatch)
                        ]
                        [ str $"Add #{List.length model.Todos + 1}" ]
                ]
        ]

Program.mkProgram init update render
|> Program.withReactSynchronous "elmish-app"
|> Program.run