namespace WWH.Cli

module ArgsParser = 
    open Argu

    type ConvertAct = 
        | [<CustomCommandLineAttribute("File", "file", "-f")>]
            File of file:string
        | [<CustomCommandLineAttribute("To", "to", "-t")>]
            To of format:string
    with
        interface IArgParserTemplate with
            member s.Usage = 
                match s with
                | File _ -> "specify the file to be converted"
                | To _ -> "specify the format to convert the file to"     

    type ArgActions = 
        | [<CustomCommandLineAttribute("Convert", "convert", "-c")>] 
            Convert of ParseResults<ConvertAct>
        | Version
    with 
        interface IArgParserTemplate with
            member s.Usage =
                match s with
                | Convert _ -> "converts a given file to the specified format"
                | Version _ -> "gets app version."

    type ArgResult = 
        | Action of ArgActions
        | Error of string            

    let parseArgs args = 
        let parser = ArgumentParser.Create<ArgActions>( programName = "wwh.exe" )
        try
            let r = parser.ParseCommandLine( inputs = args, raiseOnUsage = true )
            r.GetAllResults() |> List.head |> Action
        with e ->
            Error e.Message