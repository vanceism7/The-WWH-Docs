namespace WWH.Parsing

module Parser =
    open FParsec
    open Types

    module Internals = 
        let charListToString (x:char list) = 
            System.String.Concat( List.toArray x )  

        let betweenStr str = between (pstring str) (pstring str)
        let startWith str = newline >>. pstring str

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
            let escapeText = attempt (escape >>. amp) 
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

        let readManyArticles = 
            manyUntil readArticle articleEnd

        let whatArticle = 
            attempt whatStart >>. readManyArticles

        let whyArticle = 
            attempt whyStart >>. readManyArticles

        let howArticle = 
            attempt howStart >>. readManyArticles

        let header: Parser<string*string,unit> = 
            let title = pstring "Title:" >>. restOfLine false
            let author = startWith "Author:" >>. restOfLine false
            title .>>. author

        let parseSection = 
            sectionTitle
            .>>. whatArticle
            .>>. (whyArticle <|>% List.empty )
            .>>. (howArticle <|>% List.empty )

        let parseDoc = 
            many parseSection .>> eof 

        //For Testing
        let testParser p str = run p str

    let parseString str = 
        match run Internals.parseDoc str with
        | Success(result, _, _)   -> result
        | Failure(errorMsg, _, _) -> failwith errorMsg

    let parseFile filename =
        match runParserOnFile Internals.parseDoc () filename System.Text.Encoding.Default with
        | Success (result, _, _) -> result
        | Failure(errorMsg, _, _) -> failwith errorMsg