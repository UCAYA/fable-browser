namespace rec Browser.Types

open System
open Fable.Core

type WebSocketState =
    | CONNECTING = 0
    | OPEN = 1
    | CLOSING = 2
    | CLOSED = 3

type [<AllowNullLiteral>] CloseEvent =
    inherit Event
    abstract code: int
    abstract reason: string
    abstract wasClean: bool

type [<AllowNullLiteral>] WebSocket =
    inherit EventTarget
    abstract binaryType: string with get, set
    abstract bufferedAmount: float
    abstract extensions: string
    abstract onclose: (CloseEvent -> 'Out) with get, set
    abstract onerror: (Event -> 'Out) with get, set
    abstract onmessage: (MessageEvent -> 'Out) with get, set
    abstract onopen: (Event -> 'Out) with get, set
    abstract protocol: string
    abstract readyState: WebSocketState
    abstract url: string
    abstract close: ?code: int * ?reason: string -> unit
    abstract send: data: U4<Blob,string,ArrayBuffer, ArrayBufferView> -> unit
    [<Emit("$0.addEventListener('close',$1...)")>] abstract addEventListener_close: listener: (CloseEvent -> 'Out) * ?useCapture: bool -> unit
    [<Emit("$0.addEventListener('error',$1...)")>] abstract addEventListener_error: listener: (ErrorEvent -> 'Out) * ?useCapture: bool -> unit
    [<Emit("$0.addEventListener('message',$1...)")>] abstract addEventListener_message: listener: (MessageEvent -> 'Out) * ?useCapture: bool -> unit
    [<Emit("$0.addEventListener('open',$1...)")>] abstract addEventListener_open: listener: (Event -> 'Out) * ?useCapture: bool -> unit

    [<Emit("$0.removeEventListener('close',$1...)")>] abstract removeEventListener_close: listener: (CloseEvent -> 'Out) -> unit
    [<Emit("$0.removeEventListener('error',$1...)")>] abstract removeEventListener_error: listener: (ErrorEvent -> 'Out) -> unit
    [<Emit("$0.removeEventListener('message',$1...)")>] abstract removeEventListener_message: listener: (MessageEvent -> 'Out) -> unit
    [<Emit("$0.removeEventListener('open',$1...)")>] abstract removeEventListener_open: listener: (Event -> 'Out) -> unit

type [<AllowNullLiteral>] WebSocketType =
    [<Emit("new $0($1...)")>] abstract Create: url: string * ?protocols: U2<string, string[]> -> WebSocket

namespace Browser

open Fable.Core
open Browser.Types

[<AutoOpen>]
module WebSocket =
    let [<Global>] WebSocket: WebSocketType = jsNative
