---
title: Přidat komentář ke snímku
type: docs
weight: 10
url: /cs/net/add-a-comment-to-a-slide/
---
## **OpenXML Prezentace**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Add a comment to a slide.pptx"; 

AddCommentToPresentation(FileName,

"Zeeshan", "MZ",

"This is my programmatically added comment.");

// Přidá komentář na první snímek prezentačního dokumentu.

// Prezentační dokument musí obsahovat alespoň jeden snímek.

private static void AddCommentToPresentation(string file, string initials, string name, string text)

{

using (PresentationDocument doc = PresentationDocument.Open(file, true))

{

    // Deklarujte objekt CommentAuthorsPart.

    CommentAuthorsPart authorsPart;

    // Ověřte, že existuje část s autory komentářů.

    if (doc.PresentationPart.CommentAuthorsPart == null)

    {

        // Pokud ne, přidejte novou.

        authorsPart = doc.PresentationPart.AddNewPart<CommentAuthorsPart>();

    }

    else

    {

        authorsPart = doc.PresentationPart.CommentAuthorsPart;

    }

    // Ověřte, že v části autorů komentářů existuje seznam autorů komentářů.

    if (authorsPart.CommentAuthorList == null)

    {

        // Pokud ne, přidejte novou.

        authorsPart.CommentAuthorList = new CommentAuthorList();

    }

    // Deklarujte nové ID autora.

    uint authorId = 0;

    CommentAuthor author = null;

    // Pokud existují podřízené elementy v seznamu autorů komentářů...

    if (authorsPart.CommentAuthorList.HasChildren)

    {

        // Ověřte, že předaný autor je v seznamu.

        var authors = authorsPart.CommentAuthorList.Elements<CommentAuthor>().Where(a => a.Name == name && a.Initials == initials);

        // Pokud ano...

        if (authors.Any())

        {

            // Přiřaďte novému autorovi komentáře existující ID autora.

            author = authors.First();

            authorId = author.Id;

        }

        // Pokud ne...

        if (author == null)

        {

            // Přiřaďte předanému autorovi nové ID

            authorId = authorsPart.CommentAuthorList.Elements<CommentAuthor>().Select(a => a.Id.Value).Max();

        }

    }

    // Pokud v seznamu autorů komentářů nejsou žádné podřízené elementy.

    if (author == null)

    {

        authorId++;

        // Přidejte nový podřízený element (autor komentáře) do seznamu autorů komentářů.

        author = authorsPart.CommentAuthorList.AppendChild<CommentAuthor>

        (new CommentAuthor()

        {

            Id = authorId,

            Name = name,

            Initials = initials,

            ColorIndex = 0

        });

    }

    // Získejte první snímek pomocí metody GetFirstSlide.

    SlidePart slidePart1 = GetFirstSlide(doc);

    // Deklarujte část komentářů.

    SlideCommentsPart commentsPart;

    // Ověřte, že v první části snímku existuje část komentářů.

    if (slidePart1.GetPartsOfType<SlideCommentsPart>().Count() == 0)

    {

        // Pokud ne, přidejte novou část komentářů.

        commentsPart = slidePart1.AddNewPart<SlideCommentsPart>();

    }

    else

    {

        // Jinak použijte první část komentářů v části snímku.

        commentsPart = slidePart1.GetPartsOfType<SlideCommentsPart>().First();

    }

    // Pokud seznam komentářů neexistuje.

    if (commentsPart.CommentList == null)

    {

        // Přidejte nový seznam komentářů.

        commentsPart.CommentList = new CommentList();

    }

    // Získejte nový ID komentáře.

    uint commentIdx = author.LastIndex == null ? 1 : author.LastIndex + 1;

    author.LastIndex = commentIdx;

    // Přidejte nový komentář.

    Comment comment = commentsPart.CommentList.AppendChild<Comment>(

    new Comment()

    {

        AuthorId = authorId,

        Index = commentIdx,

        DateTime = DateTime.Now

    });

    // Přidejte podřízený uzel pozice k elementu komentáře.

    comment.Append(

    new Position() { X = 100, Y = 200 },

    new Text() { Text = text });

    // Uložte část autorů komentářů.

    authorsPart.CommentAuthorList.Save();

    // Uložte část komentářů.

    commentsPart.CommentList.Save();

}

}

// Získejte část snímku prvního snímku v prezentačním dokumentu.

private static SlidePart GetFirstSlide(PresentationDocument presentationDocument)

{

// Získejte ID vztahu prvního snímku

PresentationPart part = presentationDocument.PresentationPart;

SlideId slideId = part.Presentation.SlideIdList.GetFirstChild<SlideId>();

string relId = slideId.RelationshipId;

// Získejte část snímku pomocí ID vztahu.

SlidePart slidePart = (SlidePart)part.GetPartById(relId);

return slidePart;

}


``` 
## **Aspose.Slides**
V **Aspose.Slides** pro .NET je kolekce komentářů PPT snímků zahrnuta v každé třídě **Slide**. Třída **CommentCollection** se používá k uchování konkrétních komentářů snímku. Třída **Comment** obsahuje informace jako autor, který přidal komentář ke snímku, jeho iniciály, čas vytvoření, pozici komentáře na snímku a text komentáře. Třída **CommentAuthor** se používá k přidání autorů komentářů snímků na úrovni prezentace. Třída **Presentation** uchovává kolekci autorů prezentace ve třídě **CommentAuthors**.

V následujícím příkladu jsme přidali úryvek kódu pro přidání komentářů ke snímku.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Add a comment to a slide.pptx";

using (Presentation pres = new Presentation())

{

    //Přidání prázdného snímku

    pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

    //Přidání autora

    ICommentAuthor author = pres.CommentAuthors.AddAuthor("Zeeshan", "MZ");

    //Pozice komentářů

    PointF point = new PointF();

    point.X = 1;

    point.Y = 1;

    //Přidání komentáře ke snímku od autora

    author.Comments.AddComment("Hello Zeeshan, this is slide comment", pres.Slides[0], point, DateTime.Now);

    pres.Save(FileName, Aspose.Slides.Export.SaveFormat.Pptx);

}

``` 
## **Stáhnout ukázkový kód**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Add%20a%20comment%20to%20a%20slide%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Add%20a%20comment%20to%20a%20slide/)