import { Record } from "../.fable/fable-library.3.0.0/Types.js";
import { lambda_type, list_type, unit_type, record_type, bool_type, string_type, class_type } from "../.fable/fable-library.3.0.0/Reflection.js";
import { printf, toText } from "../.fable/fable-library.3.0.0/String.js";
import { newGuid } from "../.fable/fable-library.3.0.0/Guid.js";

export class Todo extends Record {
    constructor(Id, Title, Done) {
        super();
        this.Id = Id;
        this.Title = Title;
        this.Done = Done;
    }
}

export function Todo$reflection() {
    return record_type("Shared.Todo", [], Todo, () => [["Id", class_type("System.Guid")], ["Title", string_type], ["Done", bool_type]]);
}

export function Route_builder(typeName, methodName) {
    return toText(printf("/api/%s/%s"))(typeName)(methodName);
}

export function createTodo(title, done) {
    return new Todo(newGuid(), title, done);
}

export class ITodosApi extends Record {
    constructor(getTodos, addTodo, updateTodo) {
        super();
        this.getTodos = getTodos;
        this.addTodo = addTodo;
        this.updateTodo = updateTodo;
    }
}

export function ITodosApi$reflection() {
    return record_type("Shared.ITodosApi", [], ITodosApi, () => [["getTodos", lambda_type(unit_type, class_type("Microsoft.FSharp.Control.FSharpAsync`1", [list_type(Todo$reflection())]))], ["addTodo", lambda_type(Todo$reflection(), class_type("Microsoft.FSharp.Control.FSharpAsync`1", [Todo$reflection()]))], ["updateTodo", lambda_type(Todo$reflection(), class_type("Microsoft.FSharp.Control.FSharpAsync`1", [Todo$reflection()]))]]);
}

