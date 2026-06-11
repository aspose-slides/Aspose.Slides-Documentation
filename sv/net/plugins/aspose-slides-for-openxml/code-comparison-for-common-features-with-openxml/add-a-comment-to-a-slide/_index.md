---
title: Lägg till en kommentar till en bild
type: docs
weight: 10
url: /sv/net/add-a-comment-to-a-slide/
---
## **OpenXML-presentation**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Add a comment to a slide.pptx"; 

AddCommentToPresentation(FileName,

"Zeeshan", "MZ",

"This is my programmatically added comment.");

// Lägger till en kommentar på den första bilden i presentationsdokumentet.

// Presentationsdokumentet måste innehålla minst en bild.

private static void AddCommentToPresentation(string file, string initials, string name, string text)

{

using (PresentationDocument doc = PresentationDocument.Open(file, true))

{

    // Deklarera ett CommentAuthorsPart-objekt.

    CommentAuthorsPart authorsPart;

    // Verifiera att det finns en befintlig comment authors-del.

    if (doc.PresentationPart.CommentAuthorsPart == null)

    {

        // Om inte, lägg till en ny.

        authorsPart = doc.PresentationPart.AddNewPart<CommentAuthorsPart>();

    }

    else

    {

        authorsPart = doc.PresentationPart.CommentAuthorsPart;

    }

    // Verifiera att det finns en comment author-lista i comment authors-delen.

    if (authorsPart.CommentAuthorList == null)

    {

        // Om inte, lägg till en ny.

        authorsPart.CommentAuthorList = new CommentAuthorList();

    }

    // Deklarera ett nytt författar-ID.

    uint authorId = 0;

    CommentAuthor author = null;

    // Om det finns befintliga underordnade element i comment authors-listan...

    if (authorsPart.CommentAuthorList.HasChildren)

    {

        // Verifiera att den angivna författaren finns i listan.

        var authors = authorsPart.CommentAuthorList.Elements<CommentAuthor>().Where(a => a.Name == name && a.Initials == initials);

        // Om så...

        if (authors.Any())

        {

            // Tilldela den nya kommentarförfattaren det befintliga författar-ID:t.

            author = authors.First();

            authorId = author.Id;

        }

        // Om inte...

        if (author == null)

        {

            // Tilldela den angivna författaren ett nytt ID

            authorId = authorsPart.CommentAuthorList.Elements<CommentAuthor>().Select(a => a.Id.Value).Max();

        }

    }

    // Om det inte finns några befintliga underordnade element i comment authors-listan.

    if (author == null)

    {

        authorId++;

        // Lägg till ett nytt underordnat element (comment author) i comment author-listan.

        author = authorsPart.CommentAuthorList.AppendChild<CommentAuthor>

        (new CommentAuthor()

        {

            Id = authorId,

            Name = name,

            Initials = initials,

            ColorIndex = 0

        });

    }

    // Hämta den första bilden med metoden GetFirstSlide.

    SlidePart slidePart1 = GetFirstSlide(doc);

    // Deklarera en comments-del.

    SlideCommentsPart commentsPart;

    // Verifiera att det finns en comments-del i den första slide-delen.

    if (slidePart1.GetPartsOfType<SlideCommentsPart>().Count() == 0)

    {

        // Om inte, lägg till en ny comments-del.

        commentsPart = slidePart1.AddNewPart<SlideCommentsPart>();

    }

    else

    {

        // Annars, använd den första comments-delen i slide-delen.

        commentsPart = slidePart1.GetPartsOfType<SlideCommentsPart>().First();

    }

    // Om kommentarslistan inte finns.

    if (commentsPart.CommentList == null)

    {

        // Lägg till en ny comments-lista.

        commentsPart.CommentList = new CommentList();

    }

    // Hämta det nya kommentar-ID:t.

    uint commentIdx = author.LastIndex == null ? 1 : author.LastIndex + 1;

    author.LastIndex = commentIdx;

    // Lägg till en ny kommentar.

    Comment comment = commentsPart.CommentList.AppendChild<Comment>(

    new Comment()

    {

        AuthorId = authorId,

        Index = commentIdx,

        DateTime = DateTime.Now

    });

    // Lägg till positionens underordnade nod till kommentar-elementet.

    comment.Append(

    new Position() { X = 100, Y = 200 },

    new Text() { Text = text });

    // Spara comment authors-delen.

    authorsPart.CommentAuthorList.Save();

    // Spara comments-delen.

    commentsPart.CommentList.Save();

}

}

// Hämta relations-ID för den första bilden

private static SlidePart GetFirstSlide(PresentationDocument presentationDocument)

{

// Hämta slide-delen via relations-ID:t.

PresentationPart part = presentationDocument.PresentationPart;

SlideId slideId = part.Presentation.SlideIdList.GetFirstChild<SlideId>();

string relId = slideId.RelationshipId;

// Hämta slide-delen via relations-ID:t.

SlidePart slidePart = (SlidePart)part.GetPartById(relId);

return slidePart;

}


``` 
## **Aspose.Slides**
I **Aspose.Slides** för .NET ingår PPT-slidkommentarssamlingen i varje **Slide-klass**. **CommentCollection-klass** används för att lagra de specifika slidkommentarerna. **Comment-klass** innehåller information såsom författaren som lade till slidkommentaren, hans initialer, skapandetid, positionen för slidkommentaren på sliden och kommentartexten. **CommentAuthor-klass** används för att lägga till författare för slidkommentarer på presentationsnivå. **Presentation-klass** innehåller samlingen av författare för presentationen i **CommentAuthors-klass**.

I följande exempel har vi lagt till kodsnutten för att lägga till slidkommentarer.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Add a comment to a slide.pptx";

using (Presentation pres = new Presentation())

{

    //Lägger till en tom bild
    pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

    //Lägger till författare
    ICommentAuthor author = pres.CommentAuthors.AddAuthor("Zeeshan", "MZ");

    //Position för kommentarer
    PointF point = new PointF();

    point.X = 1;

    point.Y = 1;

    //Lägger till bildkommentar för en författare på bilden
    author.Comments.AddComment("Hello Zeeshan, this is slide comment", pres.Slides[0], point, DateTime.Now);

    pres.Save(FileName, Aspose.Slides.Export.SaveFormat.Pptx);

}

``` 
## **Ladda ner exempel på kod**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Add%20a%20comment%20to%20a%20slide%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Add%20a%20comment%20to%20a%20slide/)