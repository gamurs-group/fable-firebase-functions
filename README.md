# Fable.FirebaseFunctions

Fable bindings for the [firebase-functions](https://www.npmjs.com/package/firebase-functions) npm package.

### Nuget Packages

Stable | Prerelease
--- | ---
[![NuGet Badge](https://buildstats.info/nuget/Fable.FirebaseFunctions)](https://www.nuget.org/packages/Fable.FirebaseFunctions/) | [![NuGet Badge](https://buildstats.info/nuget/Fable.FirebaseFunctions?includePreReleases=true)](https://www.nuget.org/packages/Fable.FirebaseFunctions/)


## Example

### express.RequestHandler function

```
module Example.Handler

open Fable.FirebaseAdmin.Globals

open Fable.FirebaseFunctions
open Fable.FirebaseFunctions.Globals

// initialise the admin SDK
admin.initializeApp()
|> ignore

// Define a firebase function called 'test'
let test =
    let handler (request : Request) (response : Response) =
        response
            .send("Testing is fun")
            .``end``()

    functions.https.onRequest(handler)

```

### express.Application

```
module Example.Application

open Fable.FirebaseAdmin.Globals

open Fable.FirebaseFunctions
open Fable.FirebaseFunctions.Globals

open Fable.Import
open Fable.Core.JsInterop

// initialise the admin SDK
admin.initializeApp()
|> ignore



// Create an express.js application
let private app = express.Invoke()

let private nameHandler =
    fun (req : Request) (res : Response) _ ->
        res.send("Jim Bob") |> box

let private ageHandler =
    fun (req : Request) (res : Response) _ ->
        res.send("23") |> box

// Add some endpoints
app.get(!^"/name", nameHandler) |> ignore
app.get(!^"/age", ageHandler) |> ignore

// Deploy the application as a cloud function at /api
let api = Globals.functions.https.onRequest(app)
```

## Development

### Building

Make sure the following **requirements** are installed in your system:

* [dotnet SDK](https://www.microsoft.com/net/download/core) 2.0 or higher
* [node.js](https://nodejs.org) 6.11 or higher
* [yarn](https://yarnpkg.com)
* [Mono](http://www.mono-project.com/) if you're on Linux or macOS.

Then you just need to type `./build.cmd` or `./build.sh`

### Release

In order to push the package to [nuget.org](https://nuget.org) you need to add your API keys to `NUGET_KEY` environmental variable.
You can create a key [here](https://www.nuget.org/account/ApiKeys).

- Update RELEASE_NOTES with a new version, data and release notes [ReleaseNotesHelper](http://fake.build/apidocs/fake-releasenoteshelper.html).
Ex:

```
#### 0.2.0 - 30.04.2017
* FEATURE: Does cool stuff!
* BUGFIX: Fixes that silly oversight
```

- You can then use the Release target. This will:
  - make a commit bumping the version: Bump version to 0.2.0
  - publish the package to nuget
  - push a git tag

`./build.sh Release`
