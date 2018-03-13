namespace WWH.Markdown

module Convert =
    open System
    open WWH.Parsing.Types

    let private nl = Environment.NewLine

    let textToString t = 
        match t with 
        | Text s -> s
        | Ref s -> sprintf "[%s]" (s.Trim())

    let articleToString = 
        List.map textToString 
        >> List.fold (+) ""

    let formatArticle header a = 
        let a' = articleToString a
        match a' with
        | "" -> ""
        | _ -> header + a' + nl

    let formatSection (s:Section) = 
        "### Section: " + s.Title.Trim() + nl +
        formatArticle "### What: " s.What +
        formatArticle "### Why: " s.Why + 
        formatArticle "### How: " s.How + 
        nl + "---" + nl + nl
        
    let sectionsToString = 
        List.map formatSection >> List.reduce (+)

    let createLinks fn =
        let createLink (s:string) =
            let s' = s.Trim()
            let link = s'.Replace( " ", "-" )
            (sprintf "[%s]:(%s/%s)" s' fn link) + nl 
        
        List.map createLink >> List.reduce (+)

    let createTblEntries = 
        let createEntry (s:string) = (sprintf "[%s]" (s.Trim())) + nl
        List.map createEntry >> List.reduce (+)

    let getTableOfContents fn (doc:Section List) = 
        let titles = List.map (fun x -> x.Title) doc
        let links = createLinks fn titles
        let result = createTblEntries titles
        
        links + nl + 
        "## Table of Contents" + nl +  
        result + nl

    //--Main Converter Function--//
    let toMarkdown fn (doc:Section List) = 
        getTableOfContents fn doc + 
        sectionsToString doc