module App

open Fetch
open Thoth.Json
open Feliz
open Fss
open Shared

// Colors
let blue = hex "0d6efd"
let darkBlue = hex "01398D"

// Font
let textFont = FontFamily.value "Roboto"
let todoStyle =
    let fadeInAnimation =
        keyframes
            [
                frame 0
                    [
                        Opacity.value 0.
                        Transform.value [ Transform.translateY <| px 20 ]
                    ]
                frame 100
                    [
                        Opacity.value 1.
                        Transform.value [ Transform.translateY <| px 0 ]
                    ]
            ]
    let indexCounter = counterStyle []
    fss
        [
            CounterIncrement.value indexCounter
            FontSize.value (px 20)
            AnimationName.value fadeInAnimation
            AnimationDuration.value (sec 0.4)
            AnimationTimingFunction.ease
            ListStyleType.none
            Before
                [
                    Color.hex "48f"
                    Content.counter(indexCounter,". ")
                ]
        ]
let formStyle =
    [
        Display.inlineBlock
        Padding.value(px 10, px 15)
        FontSize.value (px 18);
        BorderRadius.value (px 0)
    ]

[<ReactComponent>]
let App () =
    let input, setInput = React.useState ""
    let todos, setTodos = React.useState<Todo list> []

    React.useEffect((fun () ->
        fetch "http://localhost:5000/todos" []
        |> Promise.bind (fun result -> result.text())
        |> Promise.map (fun result -> Decode.Auto.fromString<Todo list>(result))
        |> Promise.map (fun result ->
            match result with
            | Ok todos -> setTodos todos
            | Error e -> printfn $"Feil under dekoding av todos: {e}"
            )
        |> Promise.start)
    , [||])

    Html.div [
        prop.fss [
            Display.flex
            FlexDirection.column
            Padding.value(rem 0., rem 1.5)
            textFont
        ]
        prop.children [
            Html.h2 [
                prop.fss [
                    Color.value blue
                ]
                prop.text "TODO"
            ]
            Html.ul
                (List.map (fun (todo: Todo) ->
                    Html.li [
                        prop.className todoStyle
                        prop.text todo.Title
                    ]
                ) todos)
            Html.div [
                Html.input [
                    prop.placeholder "What needs to be done?"
                    prop.value input
                    prop.onChange setInput
                    prop.fss [
                        yield! formStyle
                        BorderRadius.value (px 0)
                        BorderWidth.thin
                        MarginRight.value (px 25)
                        Width.value (px 400)
                    ]
                ]
                Html.button [
                    prop.fss [
                        yield! formStyle
                        Border.none
                        BackgroundColor.value blue
                        Color.white
                        Width.value (em 10.)
                        Hover
                            [
                                Cursor.pointer
                                BackgroundColor.value darkBlue
                            ]
                    ]
                    prop.text $"Add #{List.length todos}"
                    prop.onClick (fun _ ->
                        // TODO: Post request her?
                        setTodos (todos @ [createTodo input false])
                        setInput "" )
                ]
            ]
        ]
    ]

open Browser.Dom

ReactDOM.render (App(), document.getElementById "app")