namespace WWH.Cli

module CLI = 
    open ArgsParser
    open WWH.Parsing
    open WWH.Markdown

    //wwh convert "file" to plugin-type
    let getVersion() = 
        printf "WWH Doc Converter: Version 0.1"

    let writeError e = 
        printf "%s" e

    let RunCommand (arg:ArgResult) = 
        match arg with
        | Error e -> writeError e
        | Action action ->
            
            match action with
            | Version -> getVersion()
            | Convert args ->
                let file = args.GetResult File
                let format = args.GetResult To

                let sections = 
                    Parser.parseFile file
                    |> SectionBuilder.build
                
                sections
                |> Convert.toMarkdown file
                |> (printf "%s")
