---
title: Voeg een opmerking toe aan een dia
type: docs
weight: 10
url: /nl/net/add-a-comment-to-a-slide/
---
## **OpenXML-presentatie**
```csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Add a comment to a slide.pptx"; 

AddCommentToPresentation(FileName,

"Zeeshan", "MZ",

"This is my programmatically added comment.");

// Voeg een opmerking toe aan de eerste dia van het presentatiedocument.
// Het presentatiedocument moet minstens één dia bevatten.

private static void AddCommentToPresentation(string file, string initials, string name, string text)

{

using (PresentationDocument doc = PresentationDocument.Open(file, true))

{

    // Declareer een CommentAuthorsPart-object.

    CommentAuthorsPart authorsPart;

    // Controleer of er een bestaand comment-authors-onderdeel bestaat.

    if (doc.PresentationPart.CommentAuthorsPart == null)

    {

        // Zo niet, voeg een nieuw onderdeel toe.

        authorsPart = doc.PresentationPart.AddNewPart<CommentAuthorsPart>();

    }

    else

    {

        authorsPart = doc.PresentationPart.CommentAuthorsPart;

    }

    // Controleer of er een comment-author-lijst aanwezig is in het comment-authors-onderdeel.

    if (authorsPart.CommentAuthorList == null)

    {

        // Zo niet, voeg een nieuw onderdeel toe.

        authorsPart.CommentAuthorList = new CommentAuthorList();

    }

    // Declareer een nieuwe auteur-ID.

    uint authorId = 0;

    CommentAuthor author = null;

    // Als er bestaande kind-elementen in de comment-authors-lijst zijn...

    if (authorsPart.CommentAuthorList.HasChildren)

    {

        // Controleer of de meegegeven auteur in de lijst staat.

        var authors = authorsPart.CommentAuthorList.Elements<CommentAuthor>().Where(a => a.Name == name && a.Initials == initials);

        // Indien ja...

        if (authors.Any())

        {

            // Ken de bestaande auteur-ID toe aan de nieuwe comment-author.

            author = authors.First();

            authorId = author.Id;

        }

        // Indien niet...

        if (author == null)

        {

            // Ken de meegegeven auteur een nieuwe ID toe

            authorId = authorsPart.CommentAuthorList.Elements<CommentAuthor>().Select(a => a.Id.Value).Max();

        }

    }

    // Als er geen bestaande kind-elementen in de comment-authors-lijst zijn.

    if (author == null)

    {

        authorId++;

        // Voeg een nieuw kind-element (comment author) toe aan de comment-author-lijst.

        author = authorsPart.CommentAuthorList.AppendChild<CommentAuthor>

        (new CommentAuthor()

        {

            Id = authorId,

            Name = name,

            Initials = initials,

            ColorIndex = 0

        });

    }

    // Haal de eerste dia op met de GetFirstSlide-methode.

    SlidePart slidePart1 = GetFirstSlide(doc);

    // Declareer een SlideCommentsPart-onderdeel.

    SlideCommentsPart commentsPart;

    // Controleer of er een comments-onderdeel aanwezig is in het eerste slide-onderdeel.

    if (slidePart1.GetPartsOfType<SlideCommentsPart>().Count() == 0)

    {

        // Zo niet, voeg een nieuw comments-onderdeel toe.

        commentsPart = slidePart1.AddNewPart<SlideCommentsPart>();

    }

    else

    {

        // Anders, gebruik het eerste comments-onderdeel in het slide-onderdeel.

        commentsPart = slidePart1.GetPartsOfType<SlideCommentsPart>().First();

    }

    // Als de comment-lijst niet bestaat.

    if (commentsPart.CommentList == null)

    {

        // Voeg een nieuwe comments-lijst toe.

        commentsPart.CommentList = new CommentList();

    }

    // Haal de nieuwe comment-ID op.

    uint commentIdx = author.LastIndex == null ? 1 : author.LastIndex + 1;

    author.LastIndex = commentIdx;

    // Voeg een nieuwe comment toe.

    Comment comment = commentsPart.CommentList.AppendChild<Comment>(

    new Comment()

    {

        AuthorId = authorId,

        Index = commentIdx,

        DateTime = DateTime.Now

    });

    // Voeg het position-kindknooppunt toe aan het comment-element.

    comment.Append(

    new Position() { X = 100, Y = 200 },

    new Text() { Text = text });

    // Sla het comment-authors-onderdeel op.

    authorsPart.CommentAuthorList.Save();

    // Sla het comments-onderdeel op.

    commentsPart.CommentList.Save();

}

}

// Haal het slide-onderdeel van de eerste dia in het presentatiedocument op.

private static SlidePart GetFirstSlide(PresentationDocument presentationDocument)

{

    // Haal de relationship-ID van de eerste dia op

    PresentationPart part = presentationDocument.PresentationPart;

    SlideId slideId = part.Presentation.SlideIdList.GetFirstChild<SlideId>();

    string relId = slideId.RelationshipId;

    // Haal het slide-onderdeel op via de relationship-ID.

    SlidePart slidePart = (SlidePart)part.GetPartById(relId);

    return slidePart;

}
``` 
## **Aspose.Slides**
In **Aspose.Slides** voor .NET is de PPT‑diaopmerkingenverzameling opgenomen in elke **Slide**‑klasse. De **CommentCollection**‑klasse wordt gebruikt om de specifieke diaopmerkingen op te slaan. De **Comment**‑klasse bevat informatie zoals de auteur die de opmerking heeft toegevoegd, zijn initialen, aanmaaktijd, de positie van de opmerking op de dia en de opmerkingtekst. De **CommentAuthor**‑klasse wordt gebruikt om de auteurs van diaopmerkingen op presentatieniveau toe te voegen. De **Presentation**‑klasse bevat de verzameling van auteurs voor de presentatie in de **CommentAuthors**‑klasse.

In het volgende voorbeeld hebben we het codefragment toegevoegd om diaopmerkingen toe te voegen.

```csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Add a comment to a slide.pptx";

using (Presentation pres = new Presentation())

{

    //Lege dia toevoegen

    pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

    //Auteur toevoegen

    ICommentAuthor author = pres.CommentAuthors.AddAuthor("Zeeshan", "MZ");

    //Positie van opmerkingen

    PointF point = new PointF();

    point.X = 1;

    point.Y = 1;

    //Slide-opmerking toevoegen voor een auteur op de dia

    author.Comments.AddComment("Hello Zeeshan, this is slide comment", pres.Slides[0], point, DateTime.Now);

    pres.Save(FileName, Aspose.Slides.Export.SaveFormat.Pptx);

}

``` 
## **Voorbeeldcode downloaden**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Add%20a%20comment%20to%20a%20slide%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Add%20a%20comment%20to%20a%20slide/)