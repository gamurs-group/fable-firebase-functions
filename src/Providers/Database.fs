// ts2fable 0.0.0
module rec Fable.FirebaseFunctions.Providers.Database

open Fable.Core
open Fable.Import.JS
open Fable.FirebaseAdmin
open Fable.FirebaseFunctions

type [<AllowNullLiteral>] IExports =
    /// <summary>Selects a database instance that will trigger the function.
    /// If omitted, will pick the default database for your project.</summary>
    /// <param name="instance">The Realtime Database instance to use.</param>
    abstract instance: instance: string -> InstanceBuilder
    /// Select Firebase Realtime Database Reference to listen to.
    /// 
    /// This method behaves very similarly to the method of the same name in the
    /// client and Admin Firebase SDKs. Any change to the Database that affects the
    /// data at or below the provided `path` will fire an event in Cloud Functions.
    /// 
    /// There are three important differences between listening to a Realtime
    /// Database event in Cloud Functions and using the Realtime Database in the
    /// client and Admin SDKs:
    /// 1. Cloud Functions allows wildcards in the `path` name. Any `path` component
    ///     in curly brackets (`{}`) is a wildcard that matches all strings. The value
    ///     that matched a certain invocation of a Cloud Function is returned as part
    ///     of the `context.params` object. For example, `ref("messages/{messageId}")`
    ///     matches changes at `/messages/message1` or `/messages/message2`, resulting
    ///     in  `context.params.messageId` being set to `"message1"` or `"message2"`,
    ///     respectively.
    /// 2. Cloud Functions do not fire an event for data that already existed before
    ///     the Cloud Function was deployed.
    /// 3. Cloud Function events have access to more information, including information
    ///     about the user who triggered the Cloud Function.
    abstract ref: path: string -> RefBuilder
    abstract InstanceBuilder: InstanceBuilderStatic
    abstract RefBuilder: RefBuilderStatic
    abstract DataSnapshot: DataSnapshotStatic

type [<AllowNullLiteral>] InstanceBuilder =
    abstract ref: path: string -> RefBuilder

type [<AllowNullLiteral>] InstanceBuilderStatic =
    [<Emit "new $0($1...)">] abstract Create: unit -> InstanceBuilder

/// Builder used to create Cloud Functions for Firebase Realtime Database References. 
type [<AllowNullLiteral>] RefBuilder =
    /// Respond to any write that affects a ref. 
    abstract onWrite: handler: (CloudFunctions.Change<DataSnapshot> -> CloudFunctions.EventContext -> U2<PromiseLike<obj option>, obj option>) -> CloudFunctions.CloudFunction<CloudFunctions.Change<DataSnapshot>>
    /// Respond to update on a ref. 
    abstract onUpdate: handler: (CloudFunctions.Change<DataSnapshot> -> CloudFunctions.EventContext -> U2<PromiseLike<obj option>, obj option>) -> CloudFunctions.CloudFunction<CloudFunctions.Change<DataSnapshot>>
    /// Respond to new data on a ref. 
    abstract onCreate: handler: (DataSnapshot -> CloudFunctions.EventContext -> U2<PromiseLike<obj option>, obj option>) -> CloudFunctions.CloudFunction<DataSnapshot>
    /// Respond to all data being deleted from a ref. 
    abstract onDelete: handler: (DataSnapshot -> CloudFunctions.EventContext -> U2<PromiseLike<obj option>, obj option>) -> CloudFunctions.CloudFunction<DataSnapshot>

/// Builder used to create Cloud Functions for Firebase Realtime Database References. 
type [<AllowNullLiteral>] RefBuilderStatic =
    [<Emit "new $0($1...)">] abstract Create: unit -> RefBuilder

type [<AllowNullLiteral>] DataSnapshot =
    abstract instance: string with get, set
    /// Ref returns a reference to the database with full admin access. 
    abstract ref: FirebaseAdmin.Database.Reference
    abstract key: string
    abstract ``val``: unit -> obj option
    abstract exportVal: unit -> obj option
    abstract getPriority: unit -> U2<string, float> option
    abstract exists: unit -> bool
    abstract child: childPath: string -> DataSnapshot
    abstract forEach: action: (DataSnapshot -> bool) -> bool
    abstract hasChild: childPath: string -> bool
    abstract hasChildren: unit -> bool
    abstract numChildren: unit -> float
    /// Prints the value of the snapshot; use '.previous.toJSON()' and '.current.toJSON()' to explicitly see
    /// the previous and current values of the snapshot.
    abstract toJSON: unit -> Object

type [<AllowNullLiteral>] DataSnapshotStatic =
    [<Emit "new $0($1...)">] abstract Create: data: obj option * ?path: string * ?app: FirebaseAdmin.App.App * ?instance: string -> DataSnapshot
