// ts2fable 0.0.0
module rec Fable.FirebaseFunctions.Config

open Fable.Core

type [<AllowNullLiteral>] IExports =
    abstract config: unit -> Config.Config

module Config =
    type [<AllowNullLiteral>] Config =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set
