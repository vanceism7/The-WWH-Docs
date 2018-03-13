namespace WWH.Parsing

module Parser =
    open FParsec
    open Types

    let charListToString (x:char list) = 
        System.String.Concat( List.toArray x )  

    let startOfLine = many1 newline
    let startWith str = startOfLine >>. pstring str
    let betweenStr str = between (pstring str) (pstring str)

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

    let manyUntil p endp = 
        many( notFollowedBy endp >>. p )

    let readRefLink = 
        pstring "&" 
        >>. (manyTill anyChar (pstring "&"))
        |>> charListToString
        |>> Ref

    let textEnd = 
        (eof |>> string) <|> (pstring "&") <|> anySectionStart

    let readPlainText = 
        manyUntil anyChar textEnd
        |>> charListToString
        |>> Text

    let readArticle =
        readRefLink <|> readPlainText

    let articleEnd = 
        (eof |>> string) <|> anySectionStart

    let whatArticle = 
        whatStart >>. manyUntil readArticle articleEnd

    let whyArticle = 
        whyStart >>. manyUntil readArticle articleEnd

    let howArticle = 
        howStart >>. manyUntil readArticle articleEnd

    let tryOrDefault p d = 
        attempt p <|> d

    let parseSection = 
        sectionTitle
        .>>. whatArticle
        .>>. tryOrDefault whyArticle ( preturn List.empty )
        .>>. tryOrDefault howArticle ( preturn List.empty )

    let parseDoc = many parseSection .>> eof 

    let parseString str = 
        match run parseDoc str with
        | Success(result, _, _)   -> result
        | Failure(errorMsg, _, _) -> failwith errorMsg

    let parseFile filename = 
        match runParserOnFile parseDoc () filename System.Text.Encoding.Default with
        | Success (result, _, _) -> result
        | Failure(errorMsg, _, _) -> failwith errorMsg    