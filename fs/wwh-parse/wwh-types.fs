namespace WWH.Parsing

module Types = 

    type SectionRef = {
        Link: string
        Display: string
    }

    type Text = 
        | Text of string
        | Ref of display:string * link:string

    type Article = Text List

    let newArticle text = 
        [Text text]

    type Section = {
        Title: string
        What: Article
        Why: Article
        How: Article
        //Children: Section List
    }

    let createSection title what why how = { 
        Title = title; 
        What = what; 
        Why = why;
        How = how; 
        //Children = children 
    }