namespace rec Browser.Types

open System
open Fable.Core

// let [<Import("getUserMedia","webrtc/MediaStream")>] getUserMedia: NavigatorGetUserMedia = jsNative

type [<AllowNullLiteral>] ConstrainBooleanParameters =
    abstract exact: bool option with get, set
    abstract ideal: bool option with get, set

type [<AllowNullLiteral>] NumberRange =
    abstract max: float option with get, set
    abstract min: float option with get, set

type [<AllowNullLiteral>] ConstrainNumberRange =
    inherit NumberRange
    abstract exact: float option with get, set
    abstract ideal: float option with get, set

 type [<AllowNullLiteral>] ConstrainStringParameters =
     abstract exact: U2<string, ResizeArray<string>> option with get, set
     abstract ideal: U2<string, ResizeArray<string>> option with get, set

 type [<AllowNullLiteral>] MediaStreamConstraints =
     abstract video: U2<bool, MediaTrackConstraints> option with get, set
     abstract audio: U2<bool, MediaTrackConstraints> option with get, set

module W3C =

    type LongRange =
        NumberRange

    type DoubleRange =
        NumberRange

    type ConstrainBoolean =
        U2<bool, ConstrainBooleanParameters>

    [<RequireQualifiedAccess; CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
    module ConstrainBoolean =
        let ofBool v: ConstrainBoolean = v |> U2.Case1
        let isBool (v: ConstrainBoolean) = match v with U2.Case1 _ -> true | _ -> false
        let asBool (v: ConstrainBoolean) = match v with U2.Case1 o -> Some o | _ -> None
        let ofConstrainBooleanParameters v: ConstrainBoolean = v |> U2.Case2
        let isConstrainBooleanParameters (v: ConstrainBoolean) = match v with U2.Case2 _ -> true | _ -> false
        let asConstrainBooleanParameters (v: ConstrainBoolean) = match v with U2.Case2 o -> Some o | _ -> None

    type ConstrainNumber =
        U2<float, ConstrainNumberRange>

    [<RequireQualifiedAccess; CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
    module ConstrainNumber =
        let ofFloat v: ConstrainNumber = v |> U2.Case1
        let isFloat (v: ConstrainNumber) = match v with U2.Case1 _ -> true | _ -> false
        let asFloat (v: ConstrainNumber) = match v with U2.Case1 o -> Some o | _ -> None
        let ofConstrainNumberRange v: ConstrainNumber = v |> U2.Case2
        let isConstrainNumberRange (v: ConstrainNumber) = match v with U2.Case2 _ -> true | _ -> false
        let asConstrainNumberRange (v: ConstrainNumber) = match v with U2.Case2 o -> Some o | _ -> None

    type ConstrainLong =
        ConstrainNumber

    type ConstrainDouble =
        ConstrainNumber

    type ConstrainString =
        U3<string, ResizeArray<string>, ConstrainStringParameters>

    [<RequireQualifiedAccess; CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
    module ConstrainString =
        let ofString v: ConstrainString = v |> U3.Case1
        let isString (v: ConstrainString) = match v with U3.Case1 _ -> true | _ -> false
        let asString (v: ConstrainString) = match v with U3.Case1 o -> Some o | _ -> None
        let ofStringArray v: ConstrainString = v |> U3.Case2
        let isStringArray (v: ConstrainString) = match v with U3.Case2 _ -> true | _ -> false
        let asStringArray (v: ConstrainString) = match v with U3.Case2 o -> Some o | _ -> None
        let ofConstrainStringParameters v: ConstrainString = v |> U3.Case3
        let isConstrainStringParameters (v: ConstrainString) = match v with U3.Case3 _ -> true | _ -> false
        let asConstrainStringParameters (v: ConstrainString) = match v with U3.Case3 o -> Some o | _ -> None

type [<AllowNullLiteral>] MediaTrackConstraintSet =
    abstract width: W3C.ConstrainLong option with get, set
    abstract height: W3C.ConstrainLong option with get, set
    abstract aspectRatio: W3C.ConstrainDouble option with get, set
    abstract frameRate: W3C.ConstrainDouble option with get, set
    abstract facingMode: W3C.ConstrainString option with get, set
    abstract volume: W3C.ConstrainDouble option with get, set
    abstract sampleRate: W3C.ConstrainLong option with get, set
    abstract sampleSize: W3C.ConstrainLong option with get, set
    abstract echoCancellation: W3C.ConstrainBoolean option with get, set
    abstract latency: W3C.ConstrainDouble option with get, set
    abstract deviceId: W3C.ConstrainString option with get, set
    abstract groupId: W3C.ConstrainString option with get, set

type [<AllowNullLiteral>] MediaTrackConstraints =
    inherit MediaTrackConstraintSet
    abstract advanced: ResizeArray<MediaTrackConstraintSet> option with get, set

type [<AllowNullLiteral>] MediaTrackSupportedConstraints =
    abstract width: bool option with get, set
    abstract height: bool option with get, set
    abstract aspectRatio: bool option with get, set
    abstract frameRate: bool option with get, set
    abstract facingMode: bool option with get, set
    abstract volume: bool option with get, set
    abstract sampleRate: bool option with get, set
    abstract sampleSize: bool option with get, set
    abstract echoCancellation: bool option with get, set
    abstract latency: bool option with get, set
    abstract deviceId: bool option with get, set
    abstract groupId: bool option with get, set


[<StringEnum>]
type ContentHint =
| [<CompiledName("speech")>] Speech
| [<CompiledName("detail")>] Detail
| [<CompiledName("motion")>] Motion

[<StringEnum>]
type TrackReadyState =
| [<CompiledName("live")>] Live
| [<CompiledName("ended")>] Ended

type [<AllowNullLiteral>] MediaStreamTrack =
    inherit EventTarget
    abstract enabled: bool with get, set
    abstract contentHint: ContentHint option with get, set
    abstract id: string with get
    abstract isolated: bool with get
    abstract kind: string with get
    abstract label: string with get
    abstract muted: bool with get
    abstract readOnly: bool with get
    abstract readyState: TrackReadyState with get
    abstract remote: bool with get
    
    abstract clone: unit -> MediaStreamTrack
    abstract stop: unit -> unit
    abstract getCapabilities: unit -> MediaTrackCapabilities
    abstract getConstraints: unit -> MediaTrackConstraints
    abstract getSettings: unit -> MediaTrackSettings
    abstract applyConstraints: constraints: MediaTrackConstraints -> JS.Promise<unit>

    abstract onended:  (Event -> 'Out) with get, set
    abstract onmute:  (Event -> 'Out) with get, set
    abstract onisolationchange:  (Event -> 'Out) with get, set
    abstract onoverconstrained:  (Event -> 'Out) with get, set
    abstract onunmute:  (Event -> 'Out) with get, set

    [<Emit("$0.addEventListener('ended',$1...)")>] 
    abstract addEventListener_ended: listener: (Event -> 'Out) * ?useCapture: bool -> unit

    [<Emit("$0.addEventListener('mute',$1...)")>] 
    abstract addEventListener_mute: listener: (Event -> 'Out) * ?useCapture: bool -> unit
    
    [<Emit("$0.addEventListener('isolationchange',$1...)")>] 
    abstract addEventListener_isolationchange: listener: (Event -> 'Out) * ?useCapture: bool -> unit
    
    [<Emit("$0.addEventListener('overconstrained',$1...)")>] 
    abstract addEventListener_overconstrained: listener: (Event -> 'Out) * ?useCapture: bool -> unit
    
    [<Emit("$0.addEventListener('unmute',$1...)")>] 
    abstract addEventListener_unmute: listener: (Event -> 'Out) * ?useCapture: bool -> unit
    
    [<Emit("$0.removeEventListener('ended',$1...)")>] 
    abstract removeEventListener_ended: listener: (Event -> 'Out) -> unit

    [<Emit("$0.removeEventListener('mute',$1...)")>] 
    abstract removeEventListener_mute: listener: (Event -> 'Out) -> unit
    
    [<Emit("$0.removeEventListener('isolationchange',$1...)")>] 
    abstract removeEventListener_isolationchange: listener: (Event -> 'Out) -> unit
    
    [<Emit("$0.removeEventListener('overconstrained',$1...)")>] 
    abstract removeEventListener_overconstrained: listener: (Event -> 'Out) -> unit
    
    [<Emit("$0.removeEventListener('unmute',$1...)")>] 
    abstract removeEventListener_unmute: listener: (Event -> 'Out) -> unit
    

type [<AllowNullLiteral>] MediaStream =
    inherit EventTarget

    abstract id: string with get
    abstract active: bool with get
    abstract ended: string with get

    abstract onaddtrack:  (MediaStreamTrackEvent -> 'Out) with get, set
    abstract onremovetrack:  (MediaStreamTrackEvent -> 'Out) with get, set
    
    abstract clone: unit -> MediaStream
    abstract stop: unit -> unit
    abstract getAudioTracks: unit -> ResizeArray<MediaStreamTrack>
    abstract getVideoTracks: unit -> ResizeArray<MediaStreamTrack>
    abstract getTracks: unit -> ResizeArray<MediaStreamTrack>
    abstract getTrackById: trackId: string -> MediaStreamTrack
    abstract addTrack: track: MediaStreamTrack -> unit
    abstract removeTrack: track: MediaStreamTrack -> unit

    [<Emit("$0.addEventListener('addtrack',$1...)")>] 
    abstract addEventListener_addtrack: listener: (MediaStreamTrackEvent -> 'Out) * ?useCapture: bool -> unit
    
    [<Emit("$0.removeEventListener('addtrack',$1...)")>] 
    abstract removeEventListener_addtrack: listener: (MediaStreamTrackEvent -> 'Out) -> unit

    [<Emit("$0.addEventListener('removetrack',$1...)")>] 
    abstract addEventListener_removetrack: listener: (MediaStreamTrackEvent -> 'Out) * ?useCapture: bool -> unit
    
    [<Emit("$0.removeEventListener('removetrack',$1...)")>] 
    abstract removeEventListener_removetrack: listener: (MediaStreamTrackEvent -> 'Out) -> unit

type [<AllowNullLiteral>] MediaStreamTrackEvent =
    inherit Event
    abstract track: MediaStreamTrack with get



type [<AllowNullLiteral>] MediaTrackCapabilities =
    abstract latency: U2<float, W3C.DoubleRange> with get, set

type [<AllowNullLiteral>] MediaTrackSettings =
    abstract latency: float with get, set

type [<AllowNullLiteral>] MediaStreamError =
    interface end

type [<AllowNullLiteral>] NavigatorGetUserMedia =
    [<Emit "$0($1...)">] abstract Invoke: constraints: MediaStreamConstraints * successCallback: (MediaStream -> unit) * errorCallback: (MediaStreamError -> unit) -> unit

type [<AllowNullLiteral>] MediaDevices =
    abstract getSupportedConstraints: unit -> MediaTrackSupportedConstraints
    abstract getUserMedia: constraints: MediaStreamConstraints -> JS.Promise<MediaStream>
    abstract enumerateDevices: unit -> JS.Promise<ResizeArray<MediaDeviceInfo>>

type [<AllowNullLiteral>] NavigatorMediaDevices =
    inherit Navigator
    abstract mediaDevices: MediaDevices with get, set

type [<AllowNullLiteral>] MediaDeviceInfo =
    interface end

namespace Browser

open Fable.Core
open Browser.Types

[<AutoOpen>]
module Navigator =
    let [<Global>] navigator: NavigatorMediaDevices = jsNative