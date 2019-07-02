namespace Fable.FirebaseFunctions.CloudFunctions

type [<AllowNullLiteral>] ScheduleRetryConfig =
    abstract retryCount: float option with get, set
    abstract maxRetryDuration: string option with get, set
    abstract minBackoffDuration: string option with get, set
    abstract maxBackoffDuration: string option with get, set
    abstract maxDoublings: float option with get, set

type [<AllowNullLiteral>] Schedule =
    abstract schedule: string with get, set
    abstract timeZone: string option with get, set
    abstract retryConfig: ScheduleRetryConfig option with get, set
