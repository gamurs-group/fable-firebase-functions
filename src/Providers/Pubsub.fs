// ts2fable 0.0.0
module rec Fable.FirebaseFunctions.Providers.Pubsub

open Fable.Core
open Fable.Import.JS
open Fable.FirebaseFunctions

type [<AllowNullLiteral>] IExports =
    /// <summary>Select Cloud Pub/Sub topic to listen to.</summary>
    /// <param name="topic">Name of Pub/Sub topic, must belong to the same project as the function.</param>
    abstract schedule: schedule: string -> ScheduleBuilder
    abstract ScheduleBuilder: ScheduleBuilderStatic
    abstract topic: topic: string -> unit
    abstract TopicBuilder: TopicBuilderStatic
    abstract Message: MessageStatic

type [<AllowNullLiteral>] ScheduleBuilder =
    abstract retryConfig: config: CloudFunctions.ScheduleRetryConfig -> ScheduleBuilder
    abstract timeZone: timeZone: string -> ScheduleBuilder
    abstract onRun: handler: (CloudFunctions.EventContext -> U2<PromiseLike<obj option>, obj option>) -> unit

type [<AllowNullLiteral>] ScheduleBuilderStatic =
    [<Emit "new $0($1...)">] abstract Create: schedule: CloudFunctions.Schedule * opts: DeploymentOptions -> ScheduleBuilder

/// Builder used to create Cloud Functions for Google Pub/Sub topics.
type [<AllowNullLiteral>] TopicBuilder =
    /// Handle a Pub/Sub message that was published to a Cloud Pub/Sub topic
    abstract onPublish: handler: (Message -> CloudFunctions.EventContext -> U2<PromiseLike<obj option>, obj option>) -> CloudFunctions.CloudFunction<Message>

/// Builder used to create Cloud Functions for Google Pub/Sub topics.
type [<AllowNullLiteral>] TopicBuilderStatic =
    [<Emit "new $0($1...)">] abstract Create: triggerResource: (unit -> string) * opts: DeploymentOptions -> TopicBuilder

/// A Pub/Sub message.
///
/// This class has an additional .json helper which will correctly deserialize any
/// message that was a JSON object when published with the JS SDK. .json will throw
/// if the message is not a base64 encoded JSON string.
type [<AllowNullLiteral>] Message =
    abstract data: string
    abstract attributes: TypeLiteral_01
    abstract json: obj option
    abstract toJSON: unit -> obj option

/// A Pub/Sub message.
///
/// This class has an additional .json helper which will correctly deserialize any
/// message that was a JSON object when published with the JS SDK. .json will throw
/// if the message is not a base64 encoded JSON string.
type [<AllowNullLiteral>] MessageStatic =
    [<Emit "new $0($1...)">] abstract Create: data: obj option -> Message

type [<AllowNullLiteral>] TypeLiteral_01 =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> string with get, set
