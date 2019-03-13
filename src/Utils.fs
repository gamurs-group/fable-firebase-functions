// ts2fable 0.0.0
module rec Fable.FirebaseFunctions.Utils

type [<AllowNullLiteral>] IExports =
    abstract normalizePath: path: string -> string
    abstract pathParts: path: string -> ResizeArray<string>
    abstract joinPath: ``base``: string * child: string -> string
    abstract applyChange: src: obj option * dest: obj option -> obj option
    abstract pruneNulls: obj: obj option -> obj option
    abstract valAt: source: obj option * ?path: string -> obj option
