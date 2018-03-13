namespace WWH.Cli

module CLI = 
    open CommandBuilder
    open WWH.Parsing
    open WWH.Markdown

    //wwh convert "file" to plugin-type
    let getVersion() = 
        printf "WWH Doc Converter: Version 0.1"

    let convertDoc file format = 
        let sections = 
            Parser.parseFile file |> SectionBuilder.build
        
        sections |> 
        Convert.toMarkdown file 
        |> (printf "%s")

    let RunCommand (arg:Command) = 
        match arg with
        | VersionCmd -> getVersion()
        | ConvertCmd (file,format) -> convertDoc file format
            
