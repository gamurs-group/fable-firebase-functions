// ts2fable 0.0.0
module rec Fable.FirebaseFunctions.Providers.Analytics

open Fable.Core
open Fable.Import.JS

open Fable.FirebaseFunctions

type [<AllowNullLiteral>] IExports =
    /// <summary>Select analytics events to listen to for events.</summary>
    /// <param name="analyticsEventType">Name of the analytics event type.</param>
    abstract ``event``: analyticsEventType: string -> AnalyticsEventBuilder
    abstract AnalyticsEventBuilder: AnalyticsEventBuilderStatic
    abstract AnalyticsEvent: AnalyticsEventStatic
    abstract UserDimensions: UserDimensionsStatic
    abstract UserPropertyValue: UserPropertyValueStatic
    abstract ExportBundleInfo: ExportBundleInfoStatic

/// The Firebase Analytics event builder interface.
/// 
/// Access via [`functions.analytics.event()`](functions.analytics#event).
type [<AllowNullLiteral>] AnalyticsEventBuilder =
    /// Event handler that fires every time a Firebase Analytics event occurs.
    abstract onLog: handler: (AnalyticsEvent -> CloudFunctions.EventContext -> U2<PromiseLike<obj option>, obj option>) -> CloudFunctions.CloudFunction<AnalyticsEvent>

/// The Firebase Analytics event builder interface.
/// 
/// Access via [`functions.analytics.event()`](functions.analytics#event).
type [<AllowNullLiteral>] AnalyticsEventBuilderStatic =
    [<Emit "new $0($1...)">] abstract Create: unit -> AnalyticsEventBuilder

/// Interface representing a Firebase Analytics event that was logged for a specific user.
type [<AllowNullLiteral>] AnalyticsEvent =
    /// The date on which the event.was logged.
    /// (`YYYYMMDD` format in the registered timezone of your app).
    abstract reportingDate: string with get, set
    /// The name of the event. 
    abstract name: string with get, set
    /// A map of parameters and their values associated with the event.
    /// 
    /// Note: Values in this map are cast to the most appropriate type. Due to
    /// the nature of JavaScript's number handling, this might entail a loss of
    /// precision in cases of very large integers.
    abstract ``params``: TypeLiteral_01 with get, set
    /// UTC client time when the event happened. 
    abstract logTime: string with get, set
    /// UTC client time when the previous event happened. 
    abstract previousLogTime: string option with get, set
    /// Value parameter in USD. 
    abstract valueInUSD: float option with get, set
    /// User-related dimensions. 
    abstract user: UserDimensions option with get, set

/// Interface representing a Firebase Analytics event that was logged for a specific user.
type [<AllowNullLiteral>] AnalyticsEventStatic =
    [<Emit "new $0($1...)">] abstract Create: unit -> AnalyticsEvent

/// Interface representing the user who triggered the events.
type [<AllowNullLiteral>] UserDimensions =
    /// The user ID set via the `setUserId` API.
    /// [Android](https://firebase.google.com/docs/reference/android/com/google/firebase/analytics/FirebaseAnalytics.html#setUserId(java.lang.String))
    /// [iOS](https://firebase.google.com/docs/reference/ios/firebaseanalytics/api/reference/Classes/FIRAnalytics#/c:objc(cs)FIRAnalytics(cm)setUserID)
    abstract userId: string option with get, set
    /// The time (in UTC) at which the user first opened the app. 
    abstract firstOpenTime: string option with get, set
    /// A map of user properties set with the
    /// [`setUserProperty`](https://firebase.google.com/docs/analytics/android/properties) API.
    /// 
    /// All values are [`UserPropertyValue`](functions.analytics.UserPropertyValue) objects.
    abstract userProperties: TypeLiteral_02 with get, set
    /// Device information. 
    abstract deviceInfo: DeviceInfo with get, set
    /// User's geographic information. 
    abstract geoInfo: GeoInfo with get, set
    /// App information. 
    abstract appInfo: AppInfo option with get, set
    /// Information regarding the bundle in which these events were uploaded. 
    abstract bundleInfo: ExportBundleInfo with get, set

/// Interface representing the user who triggered the events.
type [<AllowNullLiteral>] UserDimensionsStatic =
    [<Emit "new $0($1...)">] abstract Create: unit -> UserDimensions

/// Predefined or custom properties stored on the client side.
type [<AllowNullLiteral>] UserPropertyValue =
    /// Last set value of a user property. 
    abstract value: string with get, set
    /// UTC client time when the user property was last set. 
    abstract setTime: string with get, set

/// Predefined or custom properties stored on the client side.
type [<AllowNullLiteral>] UserPropertyValueStatic =
    [<Emit "new $0($1...)">] abstract Create: unit -> UserPropertyValue

/// Interface representing the device that triggered these Firebase Analytics events.
type [<AllowNullLiteral>] DeviceInfo =
    /// Device category.
    /// Examples: "tablet" or "mobile".
    abstract deviceCategory: string option with get, set
    /// Device brand name.
    /// Examples: "Samsung", "HTC"
    abstract mobileBrandName: string option with get, set
    /// Device model name in human-readable format.
    /// Example: "iPhone 7"
    abstract mobileModelName: string option with get, set
    /// Device marketing name.
    /// Example: "Galaxy S4 Mini"
    abstract mobileMarketingName: string option with get, set
    /// Device model, as read from the OS.
    /// Example: "iPhone9,1"
    abstract deviceModel: string option with get, set
    /// Device OS version when data capture ended.
    /// Example: "4.4.2"
    abstract platformVersion: string option with get, set
    /// Vendor specific device identifier. This is IDFV on iOS. Not used for Android.
    /// Example: '599F9C00-92DC-4B5C-9464-7971F01F8370'
    abstract deviceId: string option with get, set
    /// The type of the [`resettable_device_id`](https://support.google.com/dfp_premium/answer/6238701?hl=en)
    /// is IDFA on iOS (when available) and AdId on Android.
    /// 
    /// Example: "71683BF9-FA3B-4B0D-9535-A1F05188BAF3"
    abstract resettableDeviceId: string option with get, set
    /// The user language in language-country format, where language is an ISO 639
    /// value and country is an ISO 3166 value.
    /// 
    /// Examples: "en-us", "en-za", "zh-tw", "jp"
    abstract userDefaultLanguage: string with get, set
    /// The time zone of the device when data was uploaded, as seconds skew from UTC.
    /// Use this to calculate the device's local time for [`event.timestamp`](functions.Event#timestamp)`.
    abstract deviceTimeZoneOffsetSeconds: float with get, set
    /// The device's Limit Ad Tracking setting.
    /// When `true`, you cannot use `resettableDeviceId` for remarketing, demographics or influencing ads serving
    /// behaviour. However, you can use resettableDeviceId for conversion tracking and campaign attribution.
    abstract limitedAdTracking: bool with get, set

/// Interface representing the geographic origin of the events.
type [<AllowNullLiteral>] GeoInfo =
    /// The geographic continent. Example: "Americas". 
    abstract continent: string option with get, set
    /// The geographic country. Example: "Brazil". 
    abstract country: string option with get, set
    /// The geographic region. Example: "State of Sao Paulo". 
    abstract region: string option with get, set
    /// The geographic city. Example: "Sao Paulo". 
    abstract city: string option with get, set

/// Interface representing the application that triggered these events.
type [<AllowNullLiteral>] AppInfo =
    /// The app's version name.
    /// Examples: "1.0", "4.3.1.1.213361", "2.3 (1824253)", "v1.8b22p6".
    abstract appVersion: string option with get, set
    /// Unique id for this instance of the app.
    /// Example: "71683BF9FA3B4B0D9535A1F05188BAF3".
    abstract appInstanceId: string with get, set
    /// The identifier of the store that installed the app.
    /// Examples: "com.sec.android.app.samsungapps", "com.amazon.venezia", "com.nokia.nstore".
    abstract appStore: string option with get, set
    /// The app platform. Examples: "ANDROID", "IOS". 
    abstract appPlatform: string with get, set
    /// Unique application identifier within an app store. 
    abstract appId: string option with get, set

/// Interface representing the bundle in which these events were uploaded.
type [<AllowNullLiteral>] ExportBundleInfo =
    /// Monotonically increasing index for each bundle set by the Analytics SDK. 
    abstract bundleSequenceId: float with get, set
    /// Timestamp offset (in milliseconds) between collection time and upload time. 
    abstract serverTimestampOffset: float with get, set

/// Interface representing the bundle in which these events were uploaded.
type [<AllowNullLiteral>] ExportBundleInfoStatic =
    [<Emit "new $0($1...)">] abstract Create: unit -> ExportBundleInfo

type [<AllowNullLiteral>] TypeLiteral_02 =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> UserPropertyValue with get, set

type [<AllowNullLiteral>] TypeLiteral_01 =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set
