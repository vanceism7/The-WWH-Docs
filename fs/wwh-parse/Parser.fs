namespace WWH.Parsing

module Parser =
    open FParsec
    open Types

    let private parseDoc = 

        let charListToString (x:char list) = 
            System.String.Concat( List.toArray x )  

        let betweenStr str = between (pstring str) (pstring str)
        let startWith str = many1 newline >>. pstring str

        let manyUntil p endp = 
            many( notFollowedBy endp >>. p )

        let sectionStart = startWith "Section:"
        let whatStart = startWith "What:"
        let whyStart = startWith "Why:"
        let howStart = startWith "How:"

        let anySectionStart = 
            attempt sectionStart
            <|> attempt whatStart
            <|> attempt whyStart
            <|> attempt howStart

        let sectionTitle: Parser<string,unit> = 
            sectionStart >>. restOfLine false

        let escape = pstring "\\"
        let amp = pstring "&"

        let anyText = 
            let escapeText = (escape >>. (amp <|> escape)) 
            escapeText <|> anyString 1

        let readRefLink = 
            amp 
            >>. (manyTill anyText amp)
            |>> List.reduce (+)
            |>> Ref

        let textEnd = 
            (eof |>> string) <|> amp <|> anySectionStart

        let readPlainText = 
            manyUntil anyText textEnd
            |>> List.reduce (+)
            |>> Text

        let readArticle =
            readRefLink <|> readPlainText

        let articleEnd = 
            (eof |>> string) <|> anySectionStart

        let whatArticle = 
            attempt whatStart >>. manyUntil readArticle articleEnd

        let whyArticle = 
            attempt whyStart >>. manyUntil readArticle articleEnd

        let howArticle = 
            attempt howStart >>. manyUntil readArticle articleEnd

        let parseSection = 
            sectionTitle
            .>>. whatArticle
            .>>. (whyArticle <|>% List.empty )
            .>>. (howArticle <|>% List.empty )
            

        many parseSection .>> eof 

    let parseString str = 
        match run parseDoc str with
        | Success(result, _, _)   -> result
        | Failure(errorMsg, _, _) -> failwith errorMsg

    let parseFile filename = 
        match runParserOnFile parseDoc () filename System.Text.Encoding.Default with
        | Success (result, _, _) -> result
        | Failure(errorMsg, _, _) -> failwith errorMsg