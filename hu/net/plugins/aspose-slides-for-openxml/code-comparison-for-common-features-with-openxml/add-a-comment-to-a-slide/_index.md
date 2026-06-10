---
title: Megjegyzés hozzáadása egy diára
type: docs
weight: 10
url: /hu/net/add-a-comment-to-a-slide/
---
## **OpenXML prezentáció**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Add a comment to a slide.pptx"; 

AddCommentToPresentation(FileName,

"Zeeshan", "MZ",

"This is my programmatically added comment.");

// Hozzáad egy megjegyzést a prezentáció dokumentum első diájához.
// A prezentáció dokumentumnak legalább egy diát kell tartalmaznia.

private static void AddCommentToPresentation(string file, string initials, string name, string text)

{

using (PresentationDocument doc = PresentationDocument.Open(file, true))

{

    // Deklarálja a CommentAuthorsPart objektumot.

    CommentAuthorsPart authorsPart;

    // Ellenőrzi, hogy létezik-e már megjegyzés szerzők rész.

    if (doc.PresentationPart.CommentAuthorsPart == null)

    {

        // Ha nem, hozzáad egy újat.

        authorsPart = doc.PresentationPart.AddNewPart<CommentAuthorsPart>();

    }

    else

    {

        authorsPart = doc.PresentationPart.CommentAuthorsPart;

    }

    // Ellenőrzi, hogy van-e megjegyzés szerző lista a megjegyzés szerzők részben.

    if (authorsPart.CommentAuthorList == null)

    {

        // Ha nem, hozzáad egy újat.

        authorsPart.CommentAuthorList = new CommentAuthorList();

    }

    // Deklarál egy új szerző azonosítót.

    uint authorId = 0;

    CommentAuthor author = null;

    // Ha vannak meglévő gyermek elemek a megjegyzés szerzők listában...

    if (authorsPart.CommentAuthorList.HasChildren)

    {

        // Ellenőrzi, hogy a megadott szerző szerepel-e a listán.

        var authors = authorsPart.CommentAuthorList.Elements<CommentAuthor>().Where(a => a.Name == name && a.Initials == initials);

        // Ha igen...

        if (authors.Any())

        {

            // Az új megjegyzés szerzőnek hozzárendeli a meglévő szerző azonosítót.

            author = authors.First();

            authorId = author.Id;

        }

        // Ha nem...

        if (author == null)

        {

            // A megadott szerzőnek új azonosítót rendel

            authorId = authorsPart.CommentAuthorList.Elements<CommentAuthor>().Select(a => a.Id.Value).Max();

        }

    }

    // Ha nincsenek meglévő gyermek elemek a megjegyzés szerzők listában.

    if (author == null)

    {

        authorId++;

        // Hozzáad egy új gyermek elemet (szerző megjegyzést) a szerzői listához.

        author = authorsPart.CommentAuthorList.AppendChild<CommentAuthor>

        (new CommentAuthor()

        {

            Id = authorId,

            Name = name,

            Initials = initials,

            ColorIndex = 0

        });

    }

    // Az első dia lekérése a GetFirstSlide metódussal.

    SlidePart slidePart1 = GetFirstSlide(doc);

    // Deklarál egy megjegyzés részt.

    SlideCommentsPart commentsPart;

    // Ellenőrzi, hogy van-e megjegyzés rész az első dia részben.

    if (slidePart1.GetPartsOfType<SlideCommentsPart>().Count() == 0)

    {

        // Ha nem, egy új megjegyzés részt ad hozzá.

        commentsPart = slidePart1.AddNewPart<SlideCommentsPart>();

    }

    else

    {

        // Egyébként az első megjegyzés részt használja a dia részben.

        commentsPart = slidePart1.GetPartsOfType<SlideCommentsPart>().First();

    }

    // Ha a megjegyzéslista nem létezik.

    if (commentsPart.CommentList == null)

    {

        // Hozzáad egy új megjegyzéslistát.

        commentsPart.CommentList = new CommentList();

    }

    // Hozzáad egy új megjegyzést.

    uint commentIdx = author.LastIndex == null ? 1 : author.LastIndex + 1;

    author.LastIndex = commentIdx;

    // Hozzáad egy új megjegyzést.

    Comment comment = commentsPart.CommentList.AppendChild<Comment>(

    new Comment()

    {

        AuthorId = authorId,

        Index = commentIdx,

        DateTime = DateTime.Now

    });

    // Hozzáadja a pozíció gyermek node-ot a megjegyzés elemhez.

    comment.Append(

    new Position() { X = 100, Y = 200 },

    new Text() { Text = text });

    // Elmenti a megjegyzés szerzők részt.

    authorsPart.CommentAuthorList.Save();

    // Elmenti a megjegyzés részt.

    commentsPart.CommentList.Save();

}

}

// Az első dia részének lekérése a prezentáció dokumentumból.

private static SlidePart GetFirstSlide(PresentationDocument presentationDocument)

{

// Az első dia kapcsolatazonosítójának lekérése

PresentationPart part = presentationDocument.PresentationPart;

SlideId slideId = part.Presentation.SlideIdList.GetFirstChild<SlideId>();

string relId = slideId.RelationshipId;

// A dia rész lekérése a kapcsolatazonosító alapján.

SlidePart slidePart = (SlidePart)part.GetPartById(relId);

return slidePart;

}


```
 
## **Aspose.Slides**
A **Aspose.Slides** .NET-hez tartalmazza a PPT dia megjegyzés gyűjteményt minden **Slide** osztályban. A **CommentCollection** osztályt a konkrét dia megjegyzések tárolására használják. A **Comment** osztály olyan információkat tartalmaz, mint a megjegyzést hozzáadó szerző, a szerző monogramja, a létrehozás időpontja, a megjegyzés pozíciója a dián és a megjegyzés szövege. A **CommentAuthor** osztályt a prezentáció szintjén a dia megjegyzések szerzőinek hozzáadására használják. A **Presentation** osztály a **CommentAuthors** osztályban tárolja a prezentáció szerzőinek gyűjteményét.

Az alábbi példában hozzáadtuk a kódrészletet a dia megjegyzések hozzáadásához.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Add a comment to a slide.pptx";

using (Presentation pres = new Presentation())

{

    //Üres dia hozzáadása

    pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

    //Szerző hozzáadása

    ICommentAuthor author = pres.CommentAuthors.AddAuthor("Zeeshan", "MZ");

    //Megjegyzések pozíciója

    PointF point = new PointF();

    point.X = 1;

    point.Y = 1;

    //Dia megjegyzés hozzáadása egy szerzőnek a dián

    author.Comments.AddComment("Hello Zeeshan, this is slide comment", pres.Slides[0], point, DateTime.Now);

    pres.Save(FileName, Aspose.Slides.Export.SaveFormat.Pptx);

}

``` 
## **Minta kód letöltése**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Add%20a%20comment%20to%20a%20slide%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Add%20a%20comment%20to%20a%20slide/)