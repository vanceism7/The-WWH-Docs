namespace WWH.Markdown

module Convert =
    open System
    open WWH.Parsing.Types

    let private nl = Environment.NewLine

    let textToString t = 
        match t with 
        | Text s -> s
        | Ref (display,link) -> 
            match display.Length,link.Length with
            | 0,0 -> failwith "Invalid Link"
            | 0,_ -> sprintf "[%s]" (link.Trim())
            | _,_ -> sprintf "[%s][%s]" display (link.Trim())

    let articleToString = 
        List.map textToString 
        >> List.fold (+) ""

    let formatArticle header a = 
        let a' = (articleToString a).TrimStart( [|'\n'; '\r'|] ).Trim()
        match a' with
        | "" -> ""
        | _ -> header + nl + a' + nl

    let formatSection (s:Section) = 
        "## " + s.Title.Trim() + nl +
        formatArticle "### What: " s.What +
        formatArticle "### Why: " s.Why + 
        formatArticle "### How: " s.How + 
        nl + "---" + nl
        
    let sectionsToString = 
        List.map formatSection >> List.reduce (+)

    let createLinks =
        let createLink (s:string) =
            let s' = s.Trim()
            let link = s'.Replace( " ", "-" ).ToLower()
            (sprintf "[%s]:#%s" s' link) + nl 
        
        List.map createLink >> List.reduce (+)

    let createTblEntries = 
        let createEntry (s:string) = (sprintf "[%s]" (s.Trim())) + "  " + nl
        List.map createEntry >> List.reduce (+)

    let getTableOfContents (doc:Section List) = 
        let titles = List.map (fun x -> x.Title) doc
        let links = createLinks titles
        let result = createTblEntries titles
        
        links + nl + 
        "## Table of Contents" + nl +  
        result + nl

    //--Main Converter Function--//
    let toMarkdown (doc:Section List) = 
        getTableOfContents doc + 
        sectionsToString doc