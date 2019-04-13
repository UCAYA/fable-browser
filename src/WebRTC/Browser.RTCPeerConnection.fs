namespace rec Browser.Types

open System
open Fable.Core

[<StringEnum>]
type RTCIceCredentialType =
    | Password
    | Token

type [<AllowNullLiteral>] RTCIceServer =
    abstract urls: U2<string, ResizeArray<string>> with get, set
    abstract credentialType: RTCIceCredentialType option with get, set
    abstract credential: string option with get, set
    abstract username: string option with get, set

[<StringEnum>]
type RTCIceTransportComponent =
    | [<CompiledName("RTP")>] RTP
    | [<CompiledName("RTSP")>] RTSP

[<StringEnum>]
type RTCIceComponent =
    | [<CompiledName("rtp")>] RTP
    | [<CompiledName("rtcp")>] RTCP


[<StringEnum>]
type RTCSdpType =
    | [<CompiledName("offer")>] Offer // An RTCSdpType of offer indicates that a description MUST be treated as an [SDP] offer.
    | [<CompiledName("pranswer")>] PRAnswer //An RTCSdpType of pranswer indicates that a description MUST be treated as an [SDP] answer, but not a final answer. A description used as an SDP pranswer may be applied as a response to an SDP offer, or an update to a previously sent SDP pranswer.
    | [<CompiledName("answer")>] Answer //An RTCSdpType of answer indicates that a description MUST be treated as an [SDP] final answer, and the offer-answer exchange MUST be considered complete. A description used as an SDP answer may be applied as a response to an SDP offer or as an update to a previously sent SDP pranswer.
    | [<CompiledName("rollback")>] Rollback // An RTCSdpType of rollback indicates that a description MUST be treated as canceling the current SDP negotiation and moving the SDP [SDP] offer and answer back to what it was in the previous stable state. Note the local or remote SDP descriptions in the previous stable state could be null if there has not yet been a successful offer-answer negotiation.
    
type [<AllowNullLiteral>] RTCSessionDescriptionInit =
    abstract ``type``: RTCSdpType  with get
    abstract sdp: string with get, set

type [<AllowNullLiteral>] RTCSessionDescription =
    abstract ``type``: RTCSdpType  with get
    abstract sdp: string with get, set
    abstract toJson: string
    [<Emit "new $0($1...)">] abstract Create: ?message: RTCSessionDescriptionInit -> RTCSessionDescription
    
    
type [<AllowNullLiteral>] RTCOfferAnswerOptions =
    abstract voiceActivityDetection: bool option with get, set

type [<AllowNullLiteral>] RTCOfferOptions =
    inherit RTCOfferAnswerOptions
    abstract iceRestart: bool option with get, set
    
type [<AllowNullLiteral>] RTCAnswerOptions =
    inherit RTCOfferAnswerOptions

type [<AllowNullLiteral>] RTCIceCandidateInit =
    abstract candidate: string with get
    abstract sdpMid: string option with get, set
    abstract sdpMLineIndex: uint16 option with get, set
    abstract usernameFragment: string with get, set
    
    
type [<AllowNullLiteral>] RTCIceParameters =
    interface end
    
type IceTransportEventHandler =
    (RTCIceTransport -> Event -> obj option) option

[<StringEnum>]
type RTCIceGatheringState =
| New
| Gathering
| Complete

[<StringEnum>]
type RTCIceProtocol =
| [<CompiledName("udp")>] UDP
| [<CompiledName("tcp")>] TCP

[<StringEnum>]
type RTCIceTcpCandidateType =
| [<CompiledName("active")>] Active
| [<CompiledName("passive")>] Passive
| [<CompiledName("so")>] SO


[<StringEnum>]
type RTCIceCandidateType =
| [<CompiledName("host")>] Host
| [<CompiledName("srflx")>] Srflx
| [<CompiledName("prflx")>] Prflx
| [<CompiledName("relay")>] Relay

type [<AllowNullLiteral>] RTCIceCandidate =
    abstract candidate: string with get
    abstract sdpMid: string option with get
    abstract sdpMLineIndex: uint16 option with get
    abstract foundation: string option with get
    abstract ``component``: RTCIceComponent option with get
    abstract priority: uint32 option with get
    abstract address: string option with get
    abstract protocol: RTCIceProtocol option with get
    abstract port: uint16 option with get
    abstract ``type``: RTCIceCandidateType option with get
    abstract tcpType: RTCIceTcpCandidateType option with get
    abstract relatedAddress: string option with get
    abstract relatedPort: uint16 option with get
    abstract usernameFragment: string option with get
    abstract toJSON : RTCIceCandidateInit

type [<AllowNullLiteral>] RTCIceCandidatePair =
    abstract local: RTCIceCandidate  with get, set
    abstract remote: RTCIceCandidate with get, set

type [<AllowNullLiteral>] RTCIceTransport =
    abstract ``component``: RTCIceTransportComponent with get
    abstract gatheringState: RTCIceGatheringState with get
    abstract getLocalCandidates: unit -> ResizeArray<RTCIceCandidate>
    abstract getRemoteCandidates: unit -> ResizeArray<RTCIceCandidate>
    abstract getSelectedCandidatePair: unit -> RTCIceCandidatePair option
    abstract getLocalParameters: unit -> RTCIceParameters option
    abstract getRemoteParameters: unit -> RTCIceParameters option
    abstract onstatechange: IceTransportEventHandler with get, set
    abstract ongatheringstatechange: IceTransportEventHandler with get, set
    abstract onselectedcandidatepairchange: IceTransportEventHandler with get, set

type DtlsTransportEventHandler =
    (RTCDtlsTransport -> Event -> obj option) option

type [<AllowNullLiteral>] RTCDtlsTransport =
    abstract transport: RTCIceTransport
    abstract getRemoteCertificates: unit -> ResizeArray<ArrayBuffer>
    abstract onstatechange: DtlsTransportEventHandler with get, set

type [<AllowNullLiteral>] RTCRtpCodecCapability =
    abstract mimeType: string with get, set

type [<AllowNullLiteral>] RTCRtpHeaderExtensionCapability =
    abstract uri: string option with get, set

type [<AllowNullLiteral>] RTCRtpCapabilities =
    interface end

type [<AllowNullLiteral>] RTCRtpRtxParameters =
    interface end

type [<AllowNullLiteral>] RTCRtpFecParameters =
    interface end

[<StringEnum>]
type RTCDtxStatus =
| [<CompiledName("disabled")>] Disabled
| [<CompiledName("enabled")>] Enabled

type [<AllowNullLiteral>] RTCRtpEncodingParameters =
    abstract dtx: RTCDtxStatus option with get, set
    abstract rid: string with get, set
    abstract scaleResolutionDownBy: float option with get, set

type [<AllowNullLiteral>] RTCRtpHeaderExtensionParameters =
    abstract encrypted: bool option with get, set

type [<AllowNullLiteral>] RTCRtcpParameters =
    interface end

type [<AllowNullLiteral>] RTCRtpCodecParameters =
    abstract mimeType: string with get, set
    abstract channels: float option with get, set
    abstract sdpFmtpLine: string option with get, set


[<StringEnum>]
type RTCDegradationPreference =
| [<CompiledName("maintain-framerate")>] MaintainFramerate
| [<CompiledName("maintain-resolution")>] MaintainResolution
| [<CompiledName("balanced")>] Balanced

type [<AllowNullLiteral>] RTCRtpParameters =
    abstract transactionId: string with get, set
    abstract degradationPreference: RTCDegradationPreference option with get, set

type [<AllowNullLiteral>] RTCRtpContributingSource =
    abstract source: float with get, set
    abstract voiceActivityFlag: bool option

type [<AllowNullLiteral>] RTCRtcCapabilities =
    abstract codecs: ResizeArray<RTCRtpCodecCapability> with get, set
    abstract headerExtensions: ResizeArray<RTCRtpHeaderExtensionCapability> with get, set

type [<AllowNullLiteral>] RTCRtpSender =
    abstract setParameters: ?parameters: RTCRtpParameters -> JS.Promise<unit>
    abstract getParameters: unit -> RTCRtpParameters
    abstract replaceTrack: withTrack: MediaStreamTrack -> JS.Promise<unit>

type [<AllowNullLiteral>] RTCRtpReceiver =
    abstract getParameters: unit -> RTCRtpParameters
    abstract getContributingSources: unit -> ResizeArray<RTCRtpContributingSource>



[<StringEnum>]
type RTCRtpTransceiverDirection =
| [<CompiledName("sendrecv")>] SendRecv
| [<CompiledName("sendonly")>] SendOnly
| [<CompiledName("recvonly")>] RecvOnly
| [<CompiledName("inactive")>] Inactive

type [<AllowNullLiteral>] RTCRtpTransceiver =
    abstract mid: string option
    abstract sender: RTCRtpSender
    abstract receiver: RTCRtpReceiver
    abstract stopped: bool
    abstract direction: RTCRtpTransceiverDirection with get, set
    abstract setDirection: direction: RTCRtpTransceiverDirection -> unit
    abstract stop: unit -> unit
    abstract setCodecPreferences: codecs: ResizeArray<RTCRtpCodecCapability> -> unit

type [<AllowNullLiteral>] RTCRtpTransceiverInit =
    abstract direction: RTCRtpTransceiverDirection option with get, set
    abstract streams: ResizeArray<MediaStream> option with get, set
    abstract sendEncodings: ResizeArray<RTCRtpEncodingParameters> option with get, set

type [<AllowNullLiteral>] RTCCertificate =
    abstract expires: float
    abstract getAlgorithm: unit -> string

[<StringEnum>]
type RTCBundlePolicy =
| Balance // On BUNDLE-aware connections, the ICE agent should gather candidates for all of the media types in use (audio, video, and data). Otherwise, the ICE agent should only negotiate one audio and video track on separate transports.
| [<CompiledName("max-compat")>] MaxCompat // The ICE agent should gather candidates for each track, using separate transports to negotiate all media tracks for connections which aren't BUNDLE-compatible.
| [<CompiledName("max-bundle")>] MaxBundle // The ICE agent should gather candidates for just one track. If the connection isn't BUNDLE-compatible, then the ICE agent should negotiate just one media track.

[<StringEnum>]
type RTCIceTransportPolicy =
| All // All ICE candidates will be considered.
| Public // Only ICE candidates with public IP addresses will be considered. Removed from the specification's May 13, 2016 working draft
| Relay // Only ICE candidates whose IP addresses are being relayed, such as those being passed through a TURN server, will be considered.

[<StringEnum>]
type RTCRtcpMuxPolicy =
| Negotiate //Instructs the ICE agent to gather both RTP and RTCP candidates. If the remote peer can multiplex RTCP, then RTCP candidates are multiplexed atop the corresponding RTP candidates. Otherwise, both the RTP and RTCP candidates are returned, separately.
| Require //Tells the ICE agent to gather ICE candidates for only RTP, and to multiplex RTCP atop them. If the remote peer doesn't support RTCP multiplexing, then session negotiation fails.

type [<AllowNullLiteral>] RTCConfiguration =
    abstract iceServers: ResizeArray<RTCIceServer> option with get, set
    abstract iceTransportPolicy: RTCIceTransportPolicy option with get, set
    abstract bundlePolicy: RTCBundlePolicy option with get, set
    abstract rtcpMuxPolicy: RTCRtcpMuxPolicy option with get, set
    abstract peerIdentity: string option with get, set
    abstract certificates: ResizeArray<RTCCertificate> option with get, set
    abstract iceCandidatePoolSize: uint16 option with get, set

[<StringEnum>]
type RTCSignalingState =
| [<CompiledName("stable")>] Stable
| [<CompiledName("have-local-offer")>] HaveLocalOffer
| [<CompiledName("have-remote-offer")>] HaveRemoteOffer
| [<CompiledName("have-local-pranswer")>] HaveLocalPRAnswer
| [<CompiledName("have-remote-pranswer")>] HaveRemotePRAnswer
| [<CompiledName("closed")>] Closed

[<StringEnum>]
type RTCPeerConnectionState =
| New
| Connecting
| Connected
| Disconnected
| Failed
| Closed


type [<AllowNullLiteral>] RTCSctpTransport =
    abstract transport: RTCDtlsTransport
    abstract maxMessageSize: float

type [<AllowNullLiteral>] RTCDataChannelInit =
    abstract ordered: bool option with get, set
    abstract maxPacketLifeTime: float option with get, set
    abstract maxRetransmits: float option with get, set
    abstract protocol: string option with get, set
    abstract negotiated: bool option with get, set
    abstract id: float option with get, set

type DataChannelEventHandler<'E> =
    (RTCDataChannel -> 'E -> obj option) option


[<StringEnum>]
type RTCDataChannelState =
| [<CompiledName("connecting")>] Connecting
| [<CompiledName("open")>] Open
| [<CompiledName("closing")>] Closing
| [<CompiledName("closed")>] Closed

type [<AllowNullLiteral>] RTCErrorEvent =
    inherit Event
    abstract error:  obj with get //RTCError option with get


type [<AllowNullLiteral>] RTCDataChannel =
    inherit EventTarget
    abstract label: string
    abstract ordered: bool
    abstract maxPacketLifeTime: float option
    abstract maxRetransmits: float option
    abstract protocol: string
    abstract negotiated: bool
    abstract id: float option
    abstract readyState: RTCDataChannelState
    abstract bufferedAmount: float
    abstract bufferedAmountLowThreshold: float with get, set
    abstract binaryType: string with get, set
    abstract close: unit -> unit
    abstract send: data: U4<string, Blob, ArrayBuffer, ArrayBufferView> -> unit
    abstract onopen: DataChannelEventHandler<Event> with get, set
    abstract onmessage: DataChannelEventHandler<MessageEvent> with get, set
    abstract onbufferedamountlow: DataChannelEventHandler<Event> with get, set
    abstract onerror: DataChannelEventHandler<RTCErrorEvent> with get, set
    abstract onclose: DataChannelEventHandler<Event> with get, set
    [<Emit("$0.addEventListener('close',$1...)")>] abstract addEventListener_close: listener: (Event -> 'Out) * ?useCapture: bool -> unit
    [<Emit("$0.addEventListener('error',$1...)")>] abstract addEventListener_error: listener: (RTCErrorEvent -> 'Out) * ?useCapture: bool -> unit
    [<Emit("$0.addEventListener('message',$1...)")>] abstract addEventListener_message: listener: (MessageEvent -> 'Out) * ?useCapture: bool -> unit
    [<Emit("$0.addEventListener('open',$1...)")>] abstract addEventListener_open: listener: (Event -> 'Out) * ?useCapture: bool -> unit
    [<Emit("$0.addEventListener('bufferedamountlow',$1...)")>] abstract addEventListener_bufferedamountlow: listener: (Event -> 'Out) * ?useCapture: bool -> unit
    

type [<AllowNullLiteral>] RTCTrackEvent =
    inherit Event
    abstract receiver: RTCRtpReceiver
    abstract track: MediaStreamTrack
    abstract streams: MediaStream []
    abstract transceiver: RTCRtpTransceiver

type [<AllowNullLiteral>] RTCPeerConnectionIceEvent =
    inherit Event
    abstract candidate: RTCIceCandidate


type [<AllowNullLiteral>] RTCDataChannelEvent =
    abstract channel: RTCDataChannel

type PeerConnectionEventHandler<'E> =
    (RTCPeerConnection -> 'E -> obj option) option


type [<AllowNullLiteral>] RTCPeerConnection =
    inherit EventTarget
    [<Emit "new $0($1...)">] abstract Create: ?configuration: RTCConfiguration -> RTCPeerConnection
    abstract createOffer: ?options: RTCOfferOptions -> JS.Promise<RTCSessionDescriptionInit>
    abstract createAnswer: ?options: RTCAnswerOptions -> JS.Promise<RTCSessionDescriptionInit>
    abstract setLocalDescription: description: RTCSessionDescriptionInit -> JS.Promise<unit>
    abstract localDescription: RTCSessionDescription option with get
    abstract currentLocalDescription: RTCSessionDescription option with get
    abstract pendingLocalDescription: RTCSessionDescription option with get
    abstract setRemoteDescription: description: RTCSessionDescriptionInit -> JS.Promise<unit>
    abstract remoteDescription: RTCSessionDescription option with get
    abstract currentRemoteDescription: RTCSessionDescription option with get
    abstract pendingRemoteDescription: RTCSessionDescription option with get
    abstract addIceCandidate: candidate: RTCIceCandidateInit -> JS.Promise<unit>
    abstract signalingState: RTCSignalingState with get
    abstract connectionState: RTCPeerConnectionState with get
    abstract getConfiguration: unit -> RTCConfiguration
    abstract setConfiguration: configuration: RTCConfiguration -> unit
    abstract close: unit -> unit
    abstract getSenders: unit -> ResizeArray<RTCRtpSender>
    abstract getReceivers: unit -> ResizeArray<RTCRtpReceiver>
    abstract getTransceivers: unit -> ResizeArray<RTCRtpTransceiver>
    abstract addTrack: track: MediaStreamTrack * [<ParamArray>] streams: ResizeArray<MediaStream> -> RTCRtpSender
    abstract removeTrack: sender: RTCRtpSender -> unit
    abstract addTransceiver: trackOrKind: U2<MediaStreamTrack, string> * ?init: RTCRtpTransceiverInit -> RTCRtpTransceiver
    abstract sctp: RTCSctpTransport option
    abstract createDataChannel: label: string option * ?dataChannelDict: RTCDataChannelInit -> RTCDataChannel
    
    abstract onconnectionstatechange: (Event -> 'Out) with get, set
    abstract ondatachannel: (RTCDataChannelEvent -> 'Out) with get, set
    abstract onicecandidate: (RTCPeerConnectionIceEvent -> 'Out) with get, set
    abstract oniceconnectionstatechange: (Event -> 'Out) with get, set
    //abstract onidentityresult: PeerConnectionEventHandler<Event > with get, set
    abstract onnegotiationneeded: (Event -> 'Out) with get, set
    abstract onsignalingstatechange: (Event -> 'Out) with get, set
    abstract ontrack: (RTCTrackEvent -> 'Out) with get, set

    abstract getStats: ?selector: MediaStreamTrack -> JS.Promise<obj> //JS.Promise<RTCStatsReport>
    
    [<Emit("$0.addEventListener('connectionstatechange',$1...)")>] 
    abstract addEventListener_connectionstatechange: listener: (Event -> 'Out) * ?useCapture: bool -> unit
    
    [<Emit("$0.addEventListener('datachannel',$1...)")>] 
    abstract addEventListener_datachannel: listener: (RTCDataChannelEvent -> 'Out) * ?useCapture: bool -> unit

    [<Emit("$0.addEventListener('icecandidate',$1...)")>] 
    abstract addEventListener_icecandidate: listener: (RTCPeerConnectionIceEvent -> 'Out) * ?useCapture: bool -> unit

    [<Emit("$0.addEventListener('iceconnectionstatechange',$1...)")>] 
    abstract addEventListener_iceconnectionstatechange: listener: (Event -> 'Out) * ?useCapture: bool -> unit

    [<Emit("$0.addEventListener('negotiationneeded',$1...)")>] 
    abstract addEventListener_negotiationneeded: listener: (Event -> 'Out) * ?useCapture: bool -> unit

    [<Emit("$0.addEventListener('signalingstatechange',$1...)")>] 
    abstract addEventListener_signalingstatechange: listener: (Event -> 'Out) * ?useCapture: bool -> unit

    [<Emit("$0.addEventListener('track',$1...)")>] 
    abstract addEventListener_track: listener: (RTCTrackEvent -> 'Out) * ?useCapture: bool -> unit
    


    [<Emit("$0.removeEventListener('connectionstatechange',$1...)")>] 
    abstract removeEventListener_connectionstatechange: listener: (Event -> 'Out) -> unit
    
    [<Emit("$0.removeEventListener('datachannel',$1...)")>] 
    abstract removeEventListener_datachannel: listener: (RTCDataChannelEvent -> 'Out) -> unit

    [<Emit("$0.removeEventListener('icecandidate',$1...)")>] 
    abstract removeEventListener_icecandidate: listener: (RTCPeerConnectionIceEvent -> 'Out) -> unit

    [<Emit("$0.removeEventListener('iceconnectionstatechange',$1...)")>] 
    abstract removeEventListener_iceconnectionstatechange: listener: (Event -> 'Out) -> unit

    [<Emit("$0.removeEventListener('negotiationneeded',$1...)")>] 
    abstract removeEventListener_negotiationneeded: listener: (Event -> 'Out) -> unit

    [<Emit("$0.removeEventListener('signalingstatechange',$1...)")>] 
    abstract removeEventListener_signalingstatechange: listener: (Event -> 'Out) -> unit

    [<Emit("$0.removeEventListener('track',$1...)")>] 
    abstract removeEventListener_track: listener: (RTCTrackEvent -> 'Out) -> unit

module RTCPeerConnection =    
    [<Emit("RTCPeerConnection.generateCertificate($0...)")>]
    let generateCertificate: keygenAlgorithm: string -> JS.Promise<RTCCertificate> = jsNative
    


namespace Browser

open Fable.Core
open Browser.Types

[<AutoOpen>]
module WebSocket =
    let [<Global>] RTCPeerConnection: RTCPeerConnection = jsNative
