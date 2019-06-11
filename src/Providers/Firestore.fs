// ts2fable 0.0.0
module rec Fable.FirebaseFunctions.Providers.Firestore

open Fable.Core
open Fable.Import.JS
open Fable.FirebaseAdmin
open Fable.FirebaseFunctions

type [<AllowNullLiteral>] IExports =
    /// <summary>Select the Firestore document to listen to for events.</summary>
    /// <param name="path">Full database path to listen to. This includes the name of
    /// the collection that the document is a part of. For example, if the
    /// collection is named "users" and the document is named "Ada", then the
    /// path is "/users/Ada".</param>
    abstract document: path: string -> DocumentBuilder
    abstract DatabaseBuilder: DatabaseBuilderStatic
    abstract NamespaceBuilder: NamespaceBuilderStatic
    abstract DocumentBuilder: DocumentBuilderStatic

type DocumentSnapshot =
    FirebaseAdmin.Firestore.DocumentSnapshot

type [<AllowNullLiteral>] DatabaseBuilder =
    abstract ``namespace``: ``namespace``: string -> NamespaceBuilder
    abstract document: path: string -> DocumentBuilder

type [<AllowNullLiteral>] DatabaseBuilderStatic =
    [<Emit "new $0($1...)">] abstract Create: unit -> DatabaseBuilder

type [<AllowNullLiteral>] NamespaceBuilder =
    abstract document: path: string -> DocumentBuilder

type [<AllowNullLiteral>] NamespaceBuilderStatic =
    [<Emit "new $0($1...)">] abstract Create: unit -> NamespaceBuilder

type [<AllowNullLiteral>] DocumentBuilder =
    /// Respond to all document writes (creates, updates, or deletes).
    abstract onWrite: handler: (CloudFunctions.Change<DocumentSnapshot> -> CloudFunctions.EventContext -> U2<PromiseLike<obj option>, obj option>) -> CloudFunctions.CloudFunction<CloudFunctions.Change<DocumentSnapshot>>
    /// Respond only to document updates.
    abstract onUpdate: handler: (CloudFunctions.Change<DocumentSnapshot> -> CloudFunctions.EventContext -> U2<PromiseLike<obj option>, obj option>) -> CloudFunctions.CloudFunction<CloudFunctions.Change<DocumentSnapshot>>
    /// Respond only to document creations.
    abstract onCreate: handler: (DocumentSnapshot -> CloudFunctions.EventContext -> U2<PromiseLike<obj option>, obj option>) -> CloudFunctions.CloudFunction<DocumentSnapshot>
    /// Respond only to document deletions.
    abstract onDelete: handler: (DocumentSnapshot -> CloudFunctions.EventContext -> U2<PromiseLike<obj option>, obj option>) -> CloudFunctions.CloudFunction<DocumentSnapshot>

type [<AllowNullLiteral>] DocumentBuilderStatic =
    [<Emit "new $0($1...)">] abstract Create: unit -> DocumentBuilder
