// ts2fable 0.0.0
module rec Fable.FirebaseFunctions.Providers.Auth

open Fable.Core
open Fable.Import.JS
open Fable.FirebaseAdmin
open Fable.FirebaseFunctions

type [<AllowNullLiteral>] IExports =
    /// Handle events related to Firebase authentication users.
    abstract user: unit -> UserBuilder
    abstract UserRecordMetadata: UserRecordMetadataStatic
    abstract UserBuilder: UserBuilderStatic
    abstract userRecordConstructor: wireData: Object -> Admin.Auth.UserRecord

type [<AllowNullLiteral>] UserRecordMetadata =
    inherit Admin.Auth.UserMetadata
    abstract creationTime: string with get, set
    abstract lastSignInTime: string with get, set
    /// Returns a plain JavaScript object with the properties of UserRecordMetadata. 
    abstract toJSON: unit -> UserRecordMetadataToJSONReturn

type [<AllowNullLiteral>] UserRecordMetadataToJSONReturn =
    abstract creationTime: string with get, set
    abstract lastSignInTime: string with get, set

type [<AllowNullLiteral>] UserRecordMetadataStatic =
    [<Emit "new $0($1...)">] abstract Create: creationTime: string * lastSignInTime: string -> UserRecordMetadata

/// Builder used to create Cloud Functions for Firebase Auth user lifecycle events. 
type [<AllowNullLiteral>] UserBuilder =
    /// Respond to the creation of a Firebase Auth user. 
    abstract onCreate: handler: (UserRecord -> CloudFunctions.EventContext -> U2<PromiseLike<obj option>, obj option>) -> CloudFunctions.CloudFunction<UserRecord>
    /// Respond to the deletion of a Firebase Auth user. 
    abstract onDelete: handler: (UserRecord -> CloudFunctions.EventContext -> U2<PromiseLike<obj option>, obj option>) -> CloudFunctions.CloudFunction<UserRecord>

/// Builder used to create Cloud Functions for Firebase Auth user lifecycle events. 
type [<AllowNullLiteral>] UserBuilderStatic =
    [<Emit "new $0($1...)">] abstract Create: unit -> UserBuilder

type UserRecord =
    Admin.Auth.UserRecord
