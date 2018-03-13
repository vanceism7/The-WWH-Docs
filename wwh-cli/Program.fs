// Learn more about F# at http://fsharp.org

open WWH.Cli

[<EntryPoint>]
let main argv =
 
    try
        ArgsParser.parseArgs argv |> CLI.RunCommand
    with e ->
        eprintf "%s" e.Message
    
    0