namespace WWH.Cli

module CommandBuilder = 
    open ArgsParser

    type Command = 
        | ConvertCmd of file:string * format:string
        | VersionCmd    

    let createCommand (arg:ArgActions) = 
        match arg with
        | ArgActions.Version -> VersionCmd
        | ArgActions.Convert a -> 
            (a.GetResult File, a.GetResult To) |> ConvertCmd