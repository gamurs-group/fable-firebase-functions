// ts2fable 0.0.0
module rec Fable.FirebaseFunctions.Providers.Crashlytics

open Fable.Core
open Fable.Import.JS
open Fable.FirebaseFunctions

type [<AllowNullLiteral>] IExports =
    /// Handle events related to Crashlytics issues. An issue in Crashlytics is an
    /// aggregation of crashes which have a shared root cause.
    abstract issue: unit -> IssueBuilder
    abstract IssueBuilder: IssueBuilderStatic

/// Builder used to create Cloud Functions for Crashlytics issue events. 
type [<AllowNullLiteral>] IssueBuilder =
    /// Handle Crashlytics New Issue events. 
    abstract onNew: handler: (Issue -> CloudFunctions.EventContext -> U2<PromiseLike<obj option>, obj option>) -> CloudFunctions.CloudFunction<Issue>
    /// Handle Crashlytics Regressed Issue events. 
    abstract onRegressed: handler: (Issue -> CloudFunctions.EventContext -> U2<PromiseLike<obj option>, obj option>) -> CloudFunctions.CloudFunction<Issue>
    /// Handle Crashlytics Velocity Alert events. 
    abstract onVelocityAlert: handler: (Issue -> CloudFunctions.EventContext -> U2<PromiseLike<obj option>, obj option>) -> CloudFunctions.CloudFunction<Issue>

/// Builder used to create Cloud Functions for Crashlytics issue events. 
type [<AllowNullLiteral>] IssueBuilderStatic =
    [<Emit "new $0($1...)">] abstract Create: unit -> IssueBuilder

/// Interface representing a Crashlytics issue event that was logged for a specific issue.
type [<AllowNullLiteral>] Issue =
    /// Fabric Issue ID. 
    abstract issueId: string with get, set
    /// Issue title. 
    abstract issueTitle: string with get, set
    /// App information. 
    abstract appInfo: AppInfo with get, set
    /// When the issue was created (ISO8601 time stamp). 
    abstract createTime: string with get, set
    /// When the issue was resolved, if the issue has been resolved (ISO8601 time stamp). 
    abstract resolvedTime: string option with get, set
    /// Contains details about the velocity alert, if this event was triggered by a velocity alert. 
    abstract velocityAlert: VelocityAlert option with get, set

type [<AllowNullLiteral>] VelocityAlert =
    /// The percentage of sessions which have been impacted by this issue. Example: .04 
    abstract crashPercentage: float with get, set
    /// The number of crashes that this issue has caused. 
    abstract crashes: float with get, set

/// Interface representing the application where this issue occurred.
type [<AllowNullLiteral>] AppInfo =
    /// The app's name. Example: "My Awesome App". 
    abstract appName: string with get, set
    /// The app's platform. Examples: "android", "ios". 
    abstract appPlatform: string with get, set
    /// Unique application identifier within an app store, either the Android package name or the iOS bundle id. 
    abstract appId: string with get, set
    /// The latest app version which is affected by the issue.
    /// Examples: "1.0", "4.3.1.1.213361", "2.3 (1824253)", "v1.8b22p6".
    abstract latestAppVersion: string with get, set
