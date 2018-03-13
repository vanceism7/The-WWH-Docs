// Learn more about F# at http://fsharp.org

open WWH.Cli

[<EntryPoint>]
let main argv =
 
    ArgsParser.parseArgs argv |> CLI.RunCommand
    0 // return an integer exit code