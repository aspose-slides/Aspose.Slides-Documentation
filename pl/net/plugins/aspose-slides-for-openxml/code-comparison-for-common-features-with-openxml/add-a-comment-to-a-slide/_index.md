---
title: Dodaj komentarz do slajdu
type: docs
weight: 10
url: /pl/net/add-a-comment-to-a-slide/
---
## **Prezentacja OpenXML**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Add a comment to a slide.pptx"; 

AddCommentToPresentation(FileName,

"Zeeshan", "MZ",

"This is my programmatically added comment.");

// Dodaje komentarz do pierwszego slajdu dokumentu prezentacji.

// Dokument prezentacji musi zawierać przynajmniej jeden slajd.

private static void AddCommentToPresentation(string file, string initials, string name, string text)

{

using (PresentationDocument doc = PresentationDocument.Open(file, true))

{

    // Deklaruj obiekt CommentAuthorsPart.

    CommentAuthorsPart authorsPart;

    // Sprawdź, czy istnieje część autorów komentarzy.

    if (doc.PresentationPart.CommentAuthorsPart == null)

    {

        // Jeśli nie, dodaj nową.

        authorsPart = doc.PresentationPart.AddNewPart<CommentAuthorsPart>();

    }

    else

    {

        authorsPart = doc.PresentationPart.CommentAuthorsPart;

    }

    // Sprawdź, czy w części autorów komentarzy istnieje lista autorów komentarzy.

    if (authorsPart.CommentAuthorList == null)

    {

        // Jeśli nie, dodaj nową.

        authorsPart.CommentAuthorList = new CommentAuthorList();

    }

    // Deklaruj nowy identyfikator autora.

    uint authorId = 0;

    CommentAuthor author = null;

    // Jeśli w liście autorów komentarzy istnieją istniejące elementy podrzędne...

    if (authorsPart.CommentAuthorList.HasChildren)

    {

        // Sprawdź, czy przekazany autor znajduje się na liście.

        var authors = authorsPart.CommentAuthorList.Elements<CommentAuthor>().Where(a => a.Name == name && a.Initials == initials);

        // Jeśli tak...

        if (authors.Any())

        {

            // Przypisz nowemu autorowi komentarza istniejący identyfikator autora.

            author = authors.First();

            authorId = author.Id;

        }

        // Jeśli nie...

        if (author == null)

        {

            // Przypisz przekazanemu autorowi nowy identyfikator

            authorId = authorsPart.CommentAuthorList.Elements<CommentAuthor>().Select(a => a.Id.Value).Max();

        }

    }

    // Jeśli w liście autorów komentarzy nie ma istniejących elementów podrzędnych.

    if (author == null)

    {

        authorId++;

        // Dodaj nowy element podrzędny (autora komentarza) do listy autorów komentarzy.

        author = authorsPart.CommentAuthorList.AppendChild<CommentAuthor>

        (new CommentAuthor()

        {

            Id = authorId,

            Name = name,

            Initials = initials,

            ColorIndex = 0

        });

    }

    // Pobierz pierwszy slajd, używając metody GetFirstSlide.

    SlidePart slidePart1 = GetFirstSlide(doc);

    // Deklaruj część komentarzy.

    SlideCommentsPart commentsPart;

    // Sprawdź, czy w części pierwszego slajdu istnieje część komentarzy.

    if (slidePart1.GetPartsOfType<SlideCommentsPart>().Count() == 0)

    {

        // Jeśli nie, dodaj nową część komentarzy.

        commentsPart = slidePart1.AddNewPart<SlideCommentsPart>();

    }

    else

    {

        // W przeciwnym razie użyj pierwszej części komentarzy w części slajdu.

        commentsPart = slidePart1.GetPartsOfType<SlideCommentsPart>().First();

    }

    // Jeśli lista komentarzy nie istnieje.

    if (commentsPart.CommentList == null)

    {

        // Dodaj nową listę komentarzy.

        commentsPart.CommentList = new CommentList();

    }

    // Pobierz nowy identyfikator komentarza.

    uint commentIdx = author.LastIndex == null ? 1 : author.LastIndex + 1;

    author.LastIndex = commentIdx;

    // Dodaj nowy komentarz.

    Comment comment = commentsPart.CommentList.AppendChild<Comment>(

    new Comment()

    {

        AuthorId = authorId,

        Index = commentIdx,

        DateTime = DateTime.Now

    });

    // Dodaj węzeł pozycji jako dziecko do elementu komentarza.

    comment.Append(

    new Position() { X = 100, Y = 200 },

    new Text() { Text = text });

    // Zapisz część autorów komentarzy.

    authorsPart.CommentAuthorList.Save();

    // Zapisz część komentarzy.

    commentsPart.CommentList.Save();

}

}

// Pobierz część slajdu pierwszego slajdu w dokumencie prezentacji.

private static SlidePart GetFirstSlide(PresentationDocument presentationDocument)

{

// Pobierz identyfikator relacji pierwszego slajdu

PresentationPart part = presentationDocument.PresentationPart;

SlideId slideId = part.Presentation.SlideIdList.GetFirstChild<SlideId>();

string relId = slideId.RelationshipId;

// Pobierz część slajdu po identyfikatorze relacji.

SlidePart slidePart = (SlidePart)part.GetPartById(relId);

return slidePart;

}


``` 
## **Aspose.Slides**
W **Aspose.Slides** dla .NET, kolekcja komentarzy slajdów PPT znajduje się w każdej klasie **Slide**. Klasa **CommentCollection** służy do przechowywania konkretnych komentarzy slajdów. Klasa **Comment** zawiera informacje takie jak autor dodający komentarz slajdu, jego inicjały, czas utworzenia, pozycję komentarza na slajdzie oraz tekst komentarza. Klasa **CommentAuthor** służy do dodawania autorów komentarzy slajdów na poziomie prezentacji. Klasa **Presentation** przechowuje kolekcję autorów prezentacji w klasie **CommentAuthors**.

W poniższym przykładzie dodaliśmy fragment kodu służący do dodawania komentarzy slajdów.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Add a comment to a slide.pptx";

using (Presentation pres = new Presentation())

{

    //Dodawanie pustego slajdu

    pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

    //Dodawanie autora

    ICommentAuthor author = pres.CommentAuthors.AddAuthor("Zeeshan", "MZ");

    //Pozycja komentarzy

    PointF point = new PointF();

    point.X = 1;

    point.Y = 1;

    //Dodawanie komentarza slajdu dla autora na slajdzie

    author.Comments.AddComment("Hello Zeeshan, this is slide comment", pres.Slides[0], point, DateTime.Now);

    pres.Save(FileName, Aspose.Slides.Export.SaveFormat.Pptx);

}

``` 
## **Pobierz przykładowy kod**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Add%20a%20comment%20to%20a%20slide%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Add%20a%20comment%20to%20a%20slide/)