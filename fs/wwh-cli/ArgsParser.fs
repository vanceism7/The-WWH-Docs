namespace WWH.Cli

module ArgsParser = 
    open Argu

    type ConvertAct = 
        | [<Mandatory>][<Unique>][<CustomCommandLineAttribute("File", "file", "-f")>]
            File of string
        | [<Mandatory>][<Unique>][<CustomCommandLineAttribute("To", "to", "-t")>]
            To of string
    with
        interface IArgParserTemplate with
            member s.Usage = 
                match s with
                | File _ -> "specify the file to be converted"
                | To _ -> "specify the format to convert the file to"

    type ArgActions = 
        | [<Unique>][<First>][<CustomCommandLineAttribute("Convert", "convert", "-c")>] 
            Convert of ParseResults<ConvertAct>
        | Version
    with 
        interface IArgParserTemplate with
            member s.Usage =
                match s with
                | Convert _ -> "converts a given file to the specified format"
                | Version _ -> "show app version."         

    let parseArgs args = 
        let parser = ArgumentParser.Create<ArgActions>( programName = "wwh.exe" )
        let r = parser.ParseCommandLine( inputs = args, raiseOnUsage = true )
        r.GetAllResults() |> List.head