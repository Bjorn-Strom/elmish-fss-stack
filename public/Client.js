import { combine, em, sec, counterStyle, px, frame, keyframes, rem, fss, hex } from "./.fable/Fss-lib.2.0.0/Functions.fs.js";
import { FontSize$0027, FontFamily_custom_Z721C83C5 } from "./.fable/Fss-lib.2.0.0/css/Font.fs.js";
import { Display_get_inlineBlock, Display_get_flex } from "./.fable/Fss-lib.2.0.0/css/Display.fs.js";
import { FlexDirection_get_column } from "./.fable/Fss-lib.2.0.0/css/Flex.fs.js";
import { Padding__value_Z4F83F4C0 } from "./.fable/Fss-lib.2.0.0/Types/Padding.fs.js";
import { Padding } from "./.fable/Fss-lib.2.0.0/css/Padding.fs.js";
import { length, map, append as append_1, ofSeq, empty, singleton, ofArray } from "./.fable/fable-library.3.0.0/List.js";
import { Color, Color$0027 } from "./.fable/Fss-lib.2.0.0/css/Color.fs.js";
import { Opacity_Opacity$0027 } from "./.fable/Fss-lib.2.0.0/css/Visibility.fs.js";
import { Transform_translateY_Z46FCF3BD, Transforms } from "./.fable/Fss-lib.2.0.0/css/Transform.fs.js";
import { CounterIncrement$0027 } from "./.fable/Fss-lib.2.0.0/css/CounterStyle.fs.js";
import { AnimationTimingFunction_get_ease, AnimationDuration$0027, AnimationName$0027 } from "./.fable/Fss-lib.2.0.0/css/Animation.fs.js";
import { ListStyleType_get_none } from "./.fable/Fss-lib.2.0.0/css/ListStyle.fs.js";
import { ContentSize_ContentSizeClass__value_Z46FCF3BD, ContentSize_ContentSizeClass__get_maxContent } from "./.fable/Fss-lib.2.0.0/Types/ContentSize.fs.js";
import { Width$0027, MaxHeight, Width } from "./.fable/Fss-lib.2.0.0/css/ContentSize.fs.js";
import { Before } from "./.fable/Fss-lib.2.0.0/PseudoElement.fs.js";
import { ColorBase$1__get_green, ColorBase$1__get_white, ColorBase$1__hex_Z721C83C5 } from "./.fable/Fss-lib.2.0.0/Types/Color.fs.js";
import { ContentClass__counter_Z6D206E48 } from "./.fable/Fss-lib.2.0.0/Types/Content.fs.js";
import { Content_Content } from "./.fable/Fss-lib.2.0.0/css/Content.fs.js";
import { Hover } from "./.fable/Fss-lib.2.0.0/PseudoClass.fs.js";
import { Cursor_get_pointer } from "./.fable/Fss-lib.2.0.0/css/Cursor.fs.js";
import { BorderWidth_get_thin, Border_get_none, BorderRadius$0027 } from "./.fable/Fss-lib.2.0.0/css/Border.fs.js";
import { singleton as singleton_1, append, delay } from "./.fable/fable-library.3.0.0/Seq.js";
import { Background_BackgroundColor$0027 } from "./.fable/Fss-lib.2.0.0/css/Background.fs.js";
import { MarginRight$0027 } from "./.fable/Fss-lib.2.0.0/css/Margin.fs.js";
import { RemotingModule_createApi, RemotingModule_withRouteBuilder, Remoting_buildProxy_Z15584635 } from "./.fable/Fable.Remoting.Client.7.8.0/Remoting.fs.js";
import { Todo, createTodo, Todo$reflection, ITodosApi$reflection, Route_builder } from "./shared/Shared.js";
import { Union, Record } from "./.fable/fable-library.3.0.0/Types.js";
import { union_type, record_type, list_type, string_type } from "./.fable/fable-library.3.0.0/Reflection.js";
import { Cmd_none, Cmd_OfAsync_start, Cmd_OfAsyncWith_perform } from "./.fable/Fable.Elmish.3.1.0/cmd.fs.js";
import { TextDecorationLine_get_lineThrough } from "./.fable/Fss-lib.2.0.0/css/Text.fs.js";
import * as react from "react";
import { Browser_Types_Event__Event_get_Value } from "./.fable/Fable.React.7.3.0/Fable.React.Extensions.fs.js";
import { interpolate, toText } from "./.fable/fable-library.3.0.0/String.js";
import { ProgramModule_mkProgram, ProgramModule_run } from "./.fable/Fable.Elmish.3.1.0/program.fs.js";
import { Program_withReactSynchronous } from "./.fable/Fable.Elmish.React.3.0.1/react.fs.js";

export const blue = hex("0d6efd");

export const darkBlue = hex("01398D");

export const textFont = FontFamily_custom_Z721C83C5("Roboto");

export const container = fss(ofArray([Display_get_flex(), FlexDirection_get_column(), Padding__value_Z4F83F4C0(Padding, rem(0), rem(1.5)), textFont]));

export const header = fss(singleton(Color$0027(blue)));

export const todoStyle = (() => {
    const fadeInAnimation = keyframes(ofArray([frame(0, ofArray([Opacity_Opacity$0027(0), Transforms(singleton(Transform_translateY_Z46FCF3BD(px(20))))])), frame(100, ofArray([Opacity_Opacity$0027(1), Transforms(singleton(Transform_translateY_Z46FCF3BD(px(0))))]))]));
    const indexCounter = counterStyle(empty());
    return fss(ofArray([Display_get_flex(), CounterIncrement$0027(indexCounter), FontSize$0027(px(20)), AnimationName$0027(fadeInAnimation), AnimationDuration$0027(sec(0.4)), AnimationTimingFunction_get_ease(), ListStyleType_get_none(), ContentSize_ContentSizeClass__get_maxContent(Width), ContentSize_ContentSizeClass__value_Z46FCF3BD(MaxHeight, em(1)), Before(ofArray([ColorBase$1__hex_Z721C83C5(Color, "48f"), ContentClass__counter_Z6D206E48(Content_Content, indexCounter, ". ")])), Hover(singleton(Cursor_get_pointer()))]));
})();

export const formStyle = ofArray([Display_get_inlineBlock(), Padding__value_Z4F83F4C0(Padding, px(10), px(15)), FontSize$0027(px(18)), BorderRadius$0027(px(0))]);

export const buttonStyle = fss(ofSeq(delay(() => append(formStyle, delay(() => append(singleton_1(Border_get_none()), delay(() => append(singleton_1(Background_BackgroundColor$0027(blue)), delay(() => append(singleton_1(ColorBase$1__get_white(Color)), delay(() => append(singleton_1(Width$0027(em(10))), delay(() => singleton_1(Hover(ofArray([Cursor_get_pointer(), Background_BackgroundColor$0027(darkBlue)]))))))))))))))));

export const inputStyle = fss(ofSeq(delay(() => append(formStyle, delay(() => append(singleton_1(BorderRadius$0027(px(0))), delay(() => append(singleton_1(BorderWidth_get_thin()), delay(() => append(singleton_1(MarginRight$0027(px(25))), delay(() => singleton_1(Width$0027(px(400))))))))))))));

export const todosApi = Remoting_buildProxy_Z15584635(RemotingModule_withRouteBuilder(Route_builder, RemotingModule_createApi()), {
    ResolveType: ITodosApi$reflection,
});

export class Model extends Record {
    constructor(Input, Todos) {
        super();
        this.Input = Input;
        this.Todos = Todos;
    }
}

export function Model$reflection() {
    return record_type("Client.Model", [], Model, () => [["Input", string_type], ["Todos", list_type(Todo$reflection())]]);
}

export class Msg extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["SetInput", "AddTodo", "AddedTodo", "UpdateTodo", "UpdatedTodo", "GotTodos"];
    }
}

export function Msg$reflection() {
    return union_type("Client.Msg", [], Msg, () => [[["Item", string_type]], [["Item", string_type]], [["Item", Todo$reflection()]], [["Item", Todo$reflection()]], [["Item", Todo$reflection()]], [["Item", list_type(Todo$reflection())]]]);
}

export function init() {
    return [new Model("", empty()), Cmd_OfAsyncWith_perform((x) => {
        Cmd_OfAsync_start(x);
    }, todosApi.getTodos, void 0, (arg0) => (new Msg(5, arg0)))];
}

export function update(msg, model) {
    switch (msg.tag) {
        case 1: {
            const todo_1 = msg.fields[0];
            const newTodo = createTodo(todo_1, false);
            return [new Model("", model.Todos), Cmd_OfAsyncWith_perform((x) => {
                Cmd_OfAsync_start(x);
            }, todosApi.addTodo, newTodo, (arg0) => (new Msg(2, arg0)))];
        }
        case 2: {
            const todo_2 = msg.fields[0];
            return [new Model(model.Input, append_1(model.Todos, singleton(todo_2))), Cmd_none()];
        }
        case 3: {
            const todo_3 = msg.fields[0];
            return [new Model("", model.Todos), Cmd_OfAsyncWith_perform((x_1) => {
                Cmd_OfAsync_start(x_1);
            }, todosApi.updateTodo, todo_3, (arg0_1) => (new Msg(4, arg0_1)))];
        }
        case 4: {
            const todo_4 = msg.fields[0];
            return [new Model(model.Input, map((x_2) => ((x_2.Id === todo_4.Id) ? todo_4 : x_2), model.Todos)), Cmd_none()];
        }
        case 5: {
            const todos = msg.fields[0];
            return [new Model(model.Input, todos), Cmd_none()];
        }
        default: {
            const input = msg.fields[0];
            return [new Model(input, model.Todos), Cmd_none()];
        }
    }
}

export function todo(todo_1, dispatch) {
    const doneStyle = fss(ofArray([TextDecorationLine_get_lineThrough(), ColorBase$1__get_green(Color)]));
    return react.createElement("li", {
        onClick: (_arg1) => {
            dispatch(new Msg(3, new Todo(todo_1.Id, todo_1.Title, !todo_1.Done)));
        },
        className: combine(singleton(todoStyle), singleton([doneStyle, todo_1.Done])),
    }, todo_1.Title);
}

export function render(model, dispatch) {
    return react.createElement("div", {
        className: container,
    }, react.createElement("h2", {
        className: header,
    }, "TODO"), react.createElement("ul", {}, ...map((x) => todo(x, dispatch), model.Todos)), react.createElement("div", {}, react.createElement("input", {
        className: inputStyle,
        placeholder: "What needs to be done?",
        value: model.Input,
        onChange: (e) => {
            dispatch(new Msg(0, Browser_Types_Event__Event_get_Value(e)));
        },
    }), react.createElement("button", {
        className: buttonStyle,
        onClick: (_arg1) => {
            dispatch(new Msg(1, model.Input));
        },
    }, toText(interpolate("Add #%P()", [length(model.Todos) + 1])))));
}

ProgramModule_run(Program_withReactSynchronous("elmish-app", ProgramModule_mkProgram(init, update, render)));

