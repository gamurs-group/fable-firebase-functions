// ts2fable 0.0.0
[<RequireQualifiedAccess>]
module rec Fable.FirebaseFunctions.CloudFunctions

open Fable.Core
open Fable.Import
open Fable.Import.JS
open Fable.FirebaseFunctions

type Request = express.Request
type Response = express.Response

type [<AllowNullLiteral>] IExports =
    abstract Change: ChangeStatic
    abstract optsToTrigger: opts: DeploymentOptions -> obj option

/// The context in which an event occurred.
/// An EventContext describes:
/// - The time an event occurred.
/// - A unique identifier of the event.
/// - The resource on which the event occurred, if applicable.
/// - Authorization of the request that triggered the event, if applicable and available.
type [<AllowNullLiteral>] EventContext =
    /// ID of the event 
    abstract eventId: string with get, set
    /// Timestamp for when the event occured (ISO string) 
    abstract timestamp: string with get, set
    /// Type of event 
    abstract eventType: string with get, set
    /// Resource that triggered the event 
    abstract resource: Resource with get, set
    /// Key-value pairs that represent the values of wildcards in a database reference 
    abstract ``params``: TypeLiteral_01 with get, set
    /// Type of authentication for the triggering action, valid value are: 'ADMIN', 'USER',
    /// 'UNAUTHENTICATED'. Only available for database functions.
    abstract authType: U3<string, string, string> option with get, set
    /// Firebase auth variable for the user whose action triggered the function. Field will be
    /// null for unauthenticated users, and will not exist for admin users. Only available
    /// for database functions.
    abstract auth: TypeLiteral_02 option with get, set

/// Change describes a change of state - "before" represents the state prior
/// to the event, "after" represents the state after the event.
type [<AllowNullLiteral>] Change<'T> =
    abstract before: 'T option with get, set
    abstract after: 'T option with get, set

/// Change describes a change of state - "before" represents the state prior
/// to the event, "after" represents the state after the event.
type [<AllowNullLiteral>] ChangeStatic =
    [<Emit "new $0($1...)">] abstract Create: ?before: 'T * ?after: 'T -> Change<'T>

/// ChangeJson is the JSON format used to construct a Change object. 
type [<AllowNullLiteral>] ChangeJson =
    /// Key-value pairs representing state of data before the change.
    /// If `fieldMask` is set, then only fields that changed are present in `before`.
    abstract before: obj option with get, set
    /// Key-value pairs representing state of data after the change. 
    abstract after: obj option with get, set
    /// Comma-separated string that represents names of field that changed. 
    abstract fieldMask: string option with get, set

module Change =

    type [<AllowNullLiteral>] IExports =
        /// Factory method for creating a Change from a `before` object and an `after` object. 
        abstract fromObjects: before: 'T * after: 'T -> Change<'T>
        /// Factory method for creating a Change from a JSON and an optional customizer function to be
        /// applied to both the `before` and the `after` fields.
        abstract fromJSON: json: ChangeJson * ?customizer: (obj option -> 'T) -> Change<'T>

/// Resource is a standard format for defining a resource (google.rpc.context.AttributeContext.Resource).
/// In Cloud Functions, it is the resource that triggered the function - such as a storage bucket.
type [<AllowNullLiteral>] Resource =
    abstract service: string with get, set
    abstract name: string with get, set
    abstract ``type``: string option with get, set
    abstract labels: TypeLiteral_03 option with get, set

/// TriggerAnnotated is used internally by the firebase CLI to understand what type of Cloud Function to deploy. 
type [<AllowNullLiteral>] TriggerAnnotated =
    abstract __trigger: TypeLiteral_07 with get, set

/// A Runnable has a `run` method which directly invokes the user-defined function - useful for unit testing. 
type [<AllowNullLiteral>] Runnable<'T> =
    abstract run: ('T -> obj option -> U2<PromiseLike<obj option>, obj option>) with get, set

type [<AllowNullLiteral>] HttpsFunction =
    interface end

type [<AllowNullLiteral>] CloudFunction<'T> =
    interface end

type [<AllowNullLiteral>] TypeLiteral_04 =
    interface end

type [<AllowNullLiteral>] TypeLiteral_05 =
    abstract eventType: string with get, set
    abstract resource: string with get, set
    abstract service: string with get, set

type [<AllowNullLiteral>] TypeLiteral_07 =
    abstract httpsTrigger: TypeLiteral_04 option with get, set
    abstract eventTrigger: TypeLiteral_05 option with get, set
    abstract labels: TypeLiteral_06 option with get, set
    abstract regions: ResizeArray<string> option with get, set
    abstract timeout: string option with get, set
    abstract availableMemoryMb: float option with get, set

type [<AllowNullLiteral>] TypeLiteral_02 =
    abstract uid: string with get, set
    abstract token: obj with get, set

type [<AllowNullLiteral>] TypeLiteral_06 =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> string with get, set

type [<AllowNullLiteral>] TypeLiteral_01 =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: option: string -> obj option with get, set

type [<AllowNullLiteral>] TypeLiteral_03 =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: tag: string -> string with get, set
