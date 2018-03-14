namespace WWH.Markdown

module mdTest = 
    open WWH.Parsing
    
        let test1() = 

            let test = 
                "Section: The Awesome Test\n\n" +
                "What:\nThis is a test used as input for the parser\n\n" + 
                "Why:\nCuz we gotta test it if we want to make this thing work\n\n" + 
                "How:\nWe send this string into the parser and see if we can get out a WWH Section object!\n" + 
                "Here's a &The Child section& section reference\n\n" + 
                "Section: The child section!\n\n" + 
                "What:\nThis section is a child, it doesnt do anything now\n\n" + 
                "Why:\nNo reason in particular, just cuz"

            let result = 
                Parser.parseString ("\n" + test)
                |> SectionBuilder.build
                |> Convert.toMarkdown "./test.md"
                
            printf "%s" result
            ()