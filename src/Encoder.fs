// ts2fable 0.0.0
module rec Fable.FirebaseFunctions.Encoder

type [<AllowNullLiteral>] IExports =
    abstract dateToTimestampProto: ?timeString: string -> DateToTimestampProtoReturn

type [<AllowNullLiteral>] DateToTimestampProtoReturn =
    abstract seconds: float with get, set
    abstract nanos: float with get, set
