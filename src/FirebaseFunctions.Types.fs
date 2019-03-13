namespace Fable.FirebaseFunctions

type [<AllowNullLiteral>] DeploymentOptions =
    abstract regions: ResizeArray<string> option with get, set
    abstract timeoutSeconds: float option with get, set
    abstract memory: string option with get, set
