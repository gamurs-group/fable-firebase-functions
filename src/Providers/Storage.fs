// ts2fable 0.0.0
module rec Fable.FirebaseFunctions.Providers.Storage

open Fable.Core
open Fable.Import.JS
open Fable.FirebaseFunctions

type [<AllowNullLiteral>] IExports =
    /// <summary>The optional bucket function allows you to choose which buckets' events to handle.
    /// This step can be bypassed by calling object() directly, which will use the default
    /// Cloud Storage for Firebase bucket.</summary>
    /// <param name="bucket">Name of the Google Cloud Storage bucket to listen to.</param>
    abstract bucket: ?bucket: string -> BucketBuilder
    /// Handle events related to Cloud Storage objects.
    abstract ``object``: unit -> ObjectBuilder
    abstract BucketBuilder: BucketBuilderStatic
    abstract ObjectBuilder: ObjectBuilderStatic

type [<AllowNullLiteral>] BucketBuilder =
    /// Handle events for objects in this bucket. 
    abstract ``object``: unit -> ObjectBuilder

type [<AllowNullLiteral>] BucketBuilderStatic =
    [<Emit "new $0($1...)">] abstract Create: unit -> BucketBuilder

type [<AllowNullLiteral>] ObjectBuilder =
    /// Respond to archiving of an object, this is only for buckets that enabled object versioning. 
    abstract onArchive: handler: (ObjectMetadata -> CloudFunctions.EventContext -> U2<PromiseLike<obj option>, obj option>) -> CloudFunctions.CloudFunction<ObjectMetadata>
    /// Respond to the deletion of an object (not to archiving, if object versioning is enabled). 
    abstract onDelete: handler: (ObjectMetadata -> CloudFunctions.EventContext -> U2<PromiseLike<obj option>, obj option>) -> CloudFunctions.CloudFunction<ObjectMetadata>
    /// Respond to the successful creation of an object. 
    abstract onFinalize: handler: (ObjectMetadata -> CloudFunctions.EventContext -> U2<PromiseLike<obj option>, obj option>) -> CloudFunctions.CloudFunction<ObjectMetadata>
    /// Respond to metadata updates of existing objects. 
    abstract onMetadataUpdate: handler: (ObjectMetadata -> CloudFunctions.EventContext -> U2<PromiseLike<obj option>, obj option>) -> CloudFunctions.CloudFunction<ObjectMetadata>

type [<AllowNullLiteral>] ObjectBuilderStatic =
    [<Emit "new $0($1...)">] abstract Create: unit -> ObjectBuilder

type [<AllowNullLiteral>] ObjectMetadata =
    abstract kind: string with get, set
    abstract id: string with get, set
    abstract bucket: string with get, set
    abstract storageClass: string with get, set
    abstract size: string with get, set
    abstract timeCreated: string with get, set
    abstract updated: string with get, set
    abstract selfLink: string option with get, set
    abstract name: string option with get, set
    abstract generation: string option with get, set
    abstract contentType: string option with get, set
    abstract metageneration: string option with get, set
    abstract timeDeleted: string option with get, set
    abstract timeStorageClassUpdated: string option with get, set
    abstract md5Hash: string option with get, set
    abstract mediaLink: string option with get, set
    abstract contentEncoding: string option with get, set
    abstract contentDisposition: string option with get, set
    abstract contentLanguage: string option with get, set
    abstract cacheControl: string option with get, set
    abstract metadata: TypeLiteral_01 option with get, set
    abstract acl: TypeLiteral_03 option with get, set
    abstract owner: TypeLiteral_04 option with get, set
    abstract crc32c: string option with get, set
    abstract componentCount: string option with get, set
    abstract etag: string option with get, set
    abstract customerEncryption: TypeLiteral_05 option with get, set

type [<AllowNullLiteral>] TypeLiteral_05 =
    abstract encryptionAlgorithm: string option with get, set
    abstract keySha256: string option with get, set

type [<AllowNullLiteral>] TypeLiteral_04 =
    abstract entity: string option with get, set
    abstract entityId: string option with get, set

type [<AllowNullLiteral>] TypeLiteral_03 =
    abstract kind: string option with get, set
    abstract id: string option with get, set
    abstract selfLink: string option with get, set
    abstract bucket: string option with get, set
    abstract ``object``: string option with get, set
    abstract generation: string option with get, set
    abstract entity: string option with get, set
    abstract role: string option with get, set
    abstract email: string option with get, set
    abstract entityId: string option with get, set
    abstract domain: string option with get, set
    abstract projectTeam: TypeLiteral_02 option with get, set
    abstract etag: string option with get, set

type [<AllowNullLiteral>] TypeLiteral_02 =
    abstract projectNumber: string option with get, set
    abstract team: string option with get, set

type [<AllowNullLiteral>] TypeLiteral_01 =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> string with get, set
