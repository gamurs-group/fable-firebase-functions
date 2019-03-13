// ts2fable 0.0.0
module rec Fable.FirebaseFunctions.FunctionBuilder

open System
open Fable.Core

open Fable.FirebaseFunctions
open Fable.FirebaseFunctions.Providers

type [<AllowNullLiteral>] IExports =
    /// <summary>Configure the regions that the function is deployed to.</summary>
    /// <param name="regions">One of more region strings.
    /// For example: `functions.region('us-east1')` or `functions.region('us-east1', 'us-central1')`</param>
    abstract region: [<ParamArray>] regions: ResizeArray<string> -> FunctionBuilder
    /// <summary>Configure runtime options for the function.</summary>
    /// <param name="runtimeOptions">Object with 2 optional fields:
    /// 1. `timeoutSeconds`: timeout for the function in seconds, possible values are 0 to 540
    /// 2. `memory`: amount of memory to allocate to the function,
    /// possible values are:  '128MB', '256MB', '512MB', '1GB', and '2GB'.</param>
    abstract runWith: runtimeOptions: RunWithRuntimeOptions -> FunctionBuilder
    abstract FunctionBuilder: FunctionBuilderStatic

type [<AllowNullLiteral>] RunWithRuntimeOptions =
    abstract timeoutSeconds: float option with get, set
    abstract memory: U5<string, string, string, string, string> option with get, set

type [<AllowNullLiteral>] FunctionBuilder =
    /// Configure the regions that the function is deployed to.
    abstract region: (ResizeArray<string> -> FunctionBuilder) with get, set
    /// Configure runtime options for the function.
    abstract runWith: (TypeLiteral_01 -> FunctionBuilder) with get, set
    abstract https: TypeLiteral_02
    abstract database: TypeLiteral_03
    // TODO uncomment when Providers.Firstore is finished
    //abstract firestore: TypeLiteral_04
    abstract crashlytics: TypeLiteral_05
    abstract analytics: TypeLiteral_06
    abstract remoteConfig: TypeLiteral_07
    abstract storage: TypeLiteral_08
    abstract pubsub: TypeLiteral_09
    abstract auth: TypeLiteral_10

type [<AllowNullLiteral>] FunctionBuilderStatic =
    [<Emit "new $0($1...)">] abstract Create: options: DeploymentOptions -> FunctionBuilder

type [<AllowNullLiteral>] TypeLiteral_01 =
    abstract timeoutSeconds: float option with get, set
    abstract memory: U5<string, string, string, string, string> option with get, set

type [<AllowNullLiteral>] TypeLiteral_02 =
    /// Handle HTTP requests.
    // TODO orig was:
    // abstract onRequest: ((Express.Request -> Express.Response -> unit) -> obj) with get, set
    abstract onRequest: ((CloudFunctions.Request -> CloudFunctions.Response -> unit) -> obj) with get, set
    [<Emit "$0($1...)">] abstract Invoke : obj -> unit
    abstract HttpsFunction: obj with get, set
    /// Declares a callable method for clients to call using a Firebase SDK.
    abstract onCall: ((obj option -> Https.CallableContext -> obj option) -> obj) with get, set

type [<AllowNullLiteral>] TypeLiteral_07 =
    /// Handle all updates (including rollbacks) that affect a Remote Config
    /// project.
    abstract onUpdate: ((RemoteConfig.TemplateVersion -> CloudFunctions.EventContext -> obj option) -> CloudFunctions.CloudFunction<RemoteConfig.TemplateVersion>) with get, set

type [<AllowNullLiteral>] TypeLiteral_05 =
    /// Handle events related to Crashlytics issues. An issue in Crashlytics is an
    /// aggregation of crashes which have a shared root cause.
    abstract issue: (unit -> Crashlytics.IssueBuilder) with get, set

type [<AllowNullLiteral>] TypeLiteral_10 =
    /// Handle events related to Firebase authentication users.
    abstract user: (unit -> Auth.UserBuilder) with get, set

type [<AllowNullLiteral>] TypeLiteral_09 =
    /// Select Cloud Pub/Sub topic to listen to.
    abstract topic: (string -> Pubsub.TopicBuilder) with get, set

type [<AllowNullLiteral>] TypeLiteral_06 =
    /// Select analytics events to listen to for events.
    abstract ``event``: (string -> Analytics.AnalyticsEventBuilder) with get, set

// TODO uncomment when Providers.Firstore is finished
//type [<AllowNullLiteral>] TypeLiteral_04 =
//    /// Select the Firestore document to listen to for events.
//    abstract document: (string -> Firestore.DocumentBuilder) with get, set
//    abstract ``namespace``: (string -> Firestore.NamespaceBuilder) with get, set
//    abstract database: (string -> Firestore.DatabaseBuilder) with get, set

type [<AllowNullLiteral>] TypeLiteral_03 =
    /// Selects a database instance that will trigger the function.
    /// If omitted, will pick the default database for your project.
    abstract instance: (string -> Database.InstanceBuilder) with get, set
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
    abstract ref: (string -> Database.RefBuilder) with get, set

type [<AllowNullLiteral>] TypeLiteral_08 =
    /// The optional bucket function allows you to choose which buckets' events to handle.
    /// This step can be bypassed by calling object() directly, which will use the default
    /// Cloud Storage for Firebase bucket.
    abstract bucket: (string -> Storage.BucketBuilder) with get, set
    /// Handle events related to Cloud Storage objects.
    abstract ``object``: (unit -> Storage.ObjectBuilder) with get, set
