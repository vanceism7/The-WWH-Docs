namespace WWH.Parsing

module SectionBuilder =
    open Types

    type SectionAST = (((string * Article) * Article) * Article) List

    let build (ast:SectionAST) = 

        let createSectionT (((title,what),why),how) = 
            createSection title what why how

        ast |> List.map createSectionT