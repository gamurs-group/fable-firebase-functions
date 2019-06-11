/// Fable bindings for the 'firebase-functions' npm package.
namespace rec Fable.FirebaseFunctions

open Fable.Core
open Fable.FirebaseFunctions

module Globals =
    /// Global firebase function import
    let [<Import("*","firebase-functions")>] functions: FirebaseFunctions.IExports = jsNative

module FirebaseFunctions =
    type [<AllowNullLiteral>] IExports =
        abstract analytics: Providers.Analytics.IExports
    //    abstract app: Providers.App.IExports
        abstract auth: Providers.Auth.IExports
        abstract crashlytics: Providers.Crashlytics.IExports
        abstract database: Providers.Database.IExports
        abstract firestore: Providers.Firestore.IExports
        abstract https: Providers.Https.IExports
        abstract pubsub: Providers.Pubsub.IExports
        abstract remoteConfig: Providers.RemoteConfig.IExports
        abstract storage: Providers.Storage.IExports
