namespace Browser.Types

open System
open Fable.Core


type [<AllowNullLiteral>] ArrayBuffer =
    [<Emit "new $0($1...)">] abstract Create: size: int -> ArrayBuffer
    abstract byteLength: uint32 with get

type [<AllowNullLiteral>] ArrayBufferView =
    interface end

namespace Browser

open Fable.Core
open Browser.Types

[<AutoOpen>]
module Blob =
    let [<Global>] ArrayBuffer: ArrayBuffer = jsNative
    
    let [<Global>] ArrayBufferView: ArrayBufferView = jsNative
