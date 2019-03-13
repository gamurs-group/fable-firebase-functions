// ts2fable 0.0.0
module rec Fable.FirebaseFunctions.Providers.RemoteConfig

open Fable.Core
open Fable.Import.JS
open Fable.FirebaseFunctions

type [<AllowNullLiteral>] IExports =
    /// <summary>Handle all updates (including rollbacks) that affect a Remote Config project.</summary>
    /// <param name="handler">A function that takes the updated Remote Config template
    /// version metadata as an argument.</param>
    abstract onUpdate: handler: (TemplateVersion -> CloudFunctions.EventContext -> U2<PromiseLike<obj option>, obj option>) -> CloudFunctions.CloudFunction<TemplateVersion>

/// Interface representing a Remote Config template version metadata object that
/// was emitted when the project was updated.
type [<AllowNullLiteral>] TemplateVersion =
    /// The version number of the updated Remote Config template. 
    abstract versionNumber: float with get, set
    /// When the template was updated in format (ISO8601 timestamp). 
    abstract updateTime: string with get, set
    /// Metadata about the account that performed the update. 
    abstract updateUser: RemoteConfigUser with get, set
    /// A description associated with the particular Remote Config template. 
    abstract description: string with get, set
    /// The origin of the caller. 
    abstract updateOrigin: string with get, set
    /// The type of update action that was performed. 
    abstract updateType: string with get, set
    /// The version number of the Remote Config template that was rolled back to,
    /// if the update was a rollback.
    abstract rollbackSource: float option with get, set

type [<AllowNullLiteral>] RemoteConfigUser =
    abstract name: string option with get, set
    abstract email: string with get, set
    abstract imageUrl: string option with get, set
