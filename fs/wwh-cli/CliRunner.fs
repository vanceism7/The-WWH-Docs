namespace WWH.Cli

module CLI = 
    open CommandBuilder
    open WWH.Parsing
    open WWH.Markdown

    //wwh convert "file" to plugin-type
    let getVersion() = 
        printf "WWH Doc Converter: Version 0.1"

    let convertDoc file format link = 
        let sections = 
            Parser.parseFile file |> SectionBuilder.build
        
        let fn = Option.defaultValue ("./" + (System.IO.Path.GetFileName( file ))) link

        sections |> 
        Convert.toMarkdown fn 
        |> (printf "%s")

    let RunCommand (arg:Command) = 
        match arg with
        | VersionCmd -> getVersion()
        | ConvertCmd (file,format,link) -> convertDoc file format link