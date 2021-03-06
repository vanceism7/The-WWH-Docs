namespace WWH.Parsing.Tests

open System
open Microsoft.VisualStudio.TestTools.UnitTesting
open WWH.Parsing.Parser.Internals
open FParsec

[<TestClass>]
type TestClass () =

    let unwrap v = 
        match v with
        | Success (r,_,_) -> r
        | Failure (r,_,_) -> r

    let unwrapText v = 
        match v with
        | WWH.Parsing.Types.Text r' -> r'
        | WWH.Parsing.Types.Ref (d,s) -> 
            if d.Length > 0 then d + ":" + s
            else s

    let unwrapParserText v = 
        match v with
        | Success (r,_,_) -> unwrapText r
        | Failure (r,_,_) -> r

    let textListToString = 
        List.map unwrapText >> List.reduce (+)

    let isSuccess v = 
        match v with
        | Success (_) -> true
        | Failure (_) -> false

    //Section Tests
    [<DataRow("\nSection:")>]
    [<DataRow("\nSection: ")>]
    [<TestMethod>]
    member this.MatchForSectionPass text =
        let result = testParser sectionStart text
        Assert.IsTrue( isSuccess result )

    [<DataRow("\n\nSection:")>]
    [<DataRow("\nSection :")>]
    [<DataRow("\nsection:")>]
    [<DataRow("\n Section:")>]
    [<DataRow("\n section:")>]
    [<TestMethod>]
    member this.MatchForSectionFails text =
        let result = testParser sectionStart text
        Assert.IsFalse( isSuccess result )

    [<TestMethod>]
    member this.GetSectionTitlePassTest() =
        let title = "Test Title"
        let result = testParser sectionTitle ("\nSection:" + title) |> unwrap
        Assert.AreEqual( title, result )

    [<TestMethod>]
    member this.GetSectionTitleFailTest() =
        let title = "Test Title"
        let result = testParser sectionTitle ("\nSection: " + title) |> unwrap
        Assert.AreNotEqual( title, result )

    //What Tests
    [<DataRow("\nWhat:")>]
    [<DataRow("\nWhat: ")>]
    [<TestMethod>]
    member this.MatchForWhatPass text =
        let result = testParser whatStart text
        Assert.IsTrue( isSuccess result )

    [<DataRow("\n\nWhat:")>]
    [<DataRow("\nwhat:")>]
    [<DataRow("\nWhat :")>]
    [<DataRow("\n What:")>]
    [<DataRow("\n what:")>]
    [<TestMethod>]
    member this.MatchForWhatFails text =
        let result = testParser whatStart text
        Assert.IsFalse( isSuccess result )

    //Why Tests
    [<DataRow("\nWhy:")>]
    [<DataRow("\nWhy: ")>]
    [<TestMethod>]
    member this.MatchForWhyPass text =
        let result = testParser whyStart text
        Assert.IsTrue( isSuccess result )

    [<DataRow("\n\nWhy:")>]
    [<DataRow("\nwhy:")>]
    [<DataRow("\nWhy :")>]
    [<DataRow("\n Why:")>]
    [<DataRow("\n why:")>]
    [<TestMethod>]
    member this.MatchForWhyFails text =
        let result = testParser whyStart text
        Assert.IsFalse( isSuccess result )

    //How Tests
    [<DataRow("\nHow:")>]
    [<DataRow("\nHow: ")>]
    [<TestMethod>]
    member this.MatchForHowPass text =
        let result = testParser howStart text
        Assert.IsTrue( isSuccess result )

    [<DataRow("\n\nHow:")>]
    [<DataRow("\nhow:")>]
    [<DataRow("\nHow :")>]
    [<DataRow("\n How:")>]
    [<DataRow("\n how:")>]
    [<TestMethod>]
    member this.MatchForHowFails text =
        let result = testParser howStart text
        Assert.IsFalse( isSuccess result )

    //
    //The rest of the tests
    //
    [<DataRow("\nSection:")>]
    [<DataRow("\nWhat:")>]
    [<DataRow("\nWhy:")>]
    [<DataRow("\nHow:")>]
    [<TestMethod>]
    member this.AnySectionStartPass text =
        let result = testParser anySectionStart text
        Assert.IsTrue( isSuccess result )

    [<DataRow("\\&")>]
    [<DataRow("\\\\\\")>] //Need an extra \\ for the escape from fs
    [<TestMethod>]
    member this.AnyTextMatchesEscapedChars text =
        let result = testParser anyText text
        Assert.IsTrue( isSuccess result )

    [<DataRow("&The Cool Link&")>]
    [<DataRow("&Another Cool Link&")>]
    [<DataRow("&Link With \\& symbol in it&")>]
    [<DataRow("&Display:Link&")>]
    [<TestMethod>]
    member this.ReadRefLinkTest text =
        let result = testParser readRefLink text |> unwrapParserText
        let expected = text.Trim( '&' ).Replace( "\\&", "&" )
        
        Assert.AreEqual( expected, result )

    [<DataRow("")>]
    [<DataRow("&")>]
    [<DataRow("\nSection:")>]
    [<DataRow("\nWhat:")>]
    [<DataRow("\nWhy:")>]
    [<DataRow("\nHow:")>]
    [<TestMethod>]
    member this.TextEndTest text =
        let result = testParser textEnd text
        Assert.IsTrue( isSuccess result )

    [<DataRow("Some plain text to the end\nSection:New Stuff","Some plain text to the end" )>]
    [<DataRow("Heres some test with a &Reference&", "Heres some test with a ")>]
    [<DataRow("More test stuff \nWhy:", "More test stuff ")>]
    [<DataRow("Plain text with an \\& in it\nHow:", "Plain text with an & in it")>]
    [<DataRow("Plain text with eof as ending", "Plain text with eof as ending")>]
    [<TestMethod>]
    member this.ReadPlainTextTest text (expected:string) =
        let result = testParser readPlainText text |> unwrapParserText
        Assert.AreEqual( expected, result )

    [<DataRow("")>]
    [<DataRow("\nSection:")>]
    [<DataRow("\nWhat:")>]
    [<DataRow("\nWhy:")>]
    [<DataRow("\nHow:")>]
    [<TestMethod>]
    member this.IsArticleEndTest text =
        let result = testParser articleEnd text
        Assert.IsTrue( isSuccess result )

    [<DataRow("&")>]
    [<DataRow("\nSection :")>]
    [<TestMethod>]
    member this.NotArticleEndTest text =
        let result = testParser articleEnd text
        Assert.IsFalse( isSuccess result )

    [<DataRow("This is a what article test\nWhy:","This is a what article test" )>]
    [<DataRow("This is a test why\nHow:", "This is a test why")>]
    [<DataRow("Test how with &Reference&", "Test how with Reference")>]
    [<DataRow("Test with &Ref1:Reference& and &Reference&", "Test with Ref1:Reference and Reference")>]
    [<TestMethod>]
    member this.XArticleTestPass text (expected: String) =
        let result = testParser readManyArticles text

        match result with
        | Success (a,_,_) ->
            let txt = textListToString a 
            Assert.AreEqual( expected, txt )
        | _ -> Assert.Fail()

    [<DataRow("This is &Incomplete Reference")>]
    [<TestMethod>]
    member this.XArticleTestFail text =
        let result = testParser readManyArticles text

        match result with
        | Success (_) -> Assert.Fail()//Assert.AreEqual( expected, textListToString a )
        | _ -> ()

    [<DataRow("\nSection: Test1\nWhat:Test\nWhy:Test\nHow:Test")>]
    [<DataRow("\nSection: Test2\nWhat:Test\nWhy:How Optional")>]
    [<DataRow("\nSection: Test3\nWhat:Test\nHow:Why Optional")>]
    [<DataRow("\nSection: Test4\nWhat:How and Why Optional")>]
    [<TestMethod>]
    member this.ParseDocPass text =
        let result = testParser parseSection text
        Assert.IsTrue( isSuccess result )

    [<DataRow("\nSection: What Not Optional")>]
    [<DataRow("\nSection: Test2\nWhy:What not Optional")>]
    [<DataRow("\nSection: Test3\nWhy:Out of order invalid\nWhat:Test")>]
    [<DataRow("\nSection: Test4\nWhat:Test\nHow:Out of order invalid\nWhy:Test")>]
    [<TestMethod>]
    member this.ParseDocFails text =
        let result = testParser parseDoc text
        printf "%A" result
        Assert.IsFalse( isSuccess result )    