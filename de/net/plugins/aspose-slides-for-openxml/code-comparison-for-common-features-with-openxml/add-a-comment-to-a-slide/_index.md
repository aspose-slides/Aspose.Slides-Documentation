---
title: Füge einen Kommentar zu einer Folie hinzu
type: docs
weight: 10
url: /de/net/add-a-comment-to-a-slide/
---

## **OpenXML Präsentation:**
``` csharp

 string FilePath = @"..\..\..\..\Beispieldateien\";

string FileName = FilePath + "Füge einen Kommentar zu einer Folie hinzu.pptx"; 

AddCommentToPresentation(FileName,

"Zeeshan", "MZ",

"Dies ist mein programmgesteuert hinzugefügter Kommentar.");

// Fügt einen Kommentar zur ersten Folie des Präsentationsdokuments hinzu.

// Das Präsentationsdokument muss mindestens eine Folie enthalten.

private static void AddCommentToPresentation(string file, string initials, string name, string text)

{

using (PresentationDocument doc = PresentationDocument.Open(file, true))

{

    // Deklariere ein CommentAuthorsPart-Objekt.

    CommentAuthorsPart authorsPart;

    // Überprüfe, ob ein vorhandenes Kommentarautoren-Teil existiert.

    if (doc.PresentationPart.CommentAuthorsPart == null)

    {

        // Falls nicht, füge ein neues hinzu.

        authorsPart = doc.PresentationPart.AddNewPart<CommentAuthorsPart>();

    }

    else

    {

        authorsPart = doc.PresentationPart.CommentAuthorsPart;

    }

    // Überprüfe, ob eine Kommentator-Liste im Kommentarautoren-Teil vorhanden ist.

    if (authorsPart.CommentAuthorList == null)

    {

        // Falls nicht, füge eine neue hinzu.

        authorsPart.CommentAuthorList = new CommentAuthorList();

    }

    // Deklariere eine neue Autoren-ID.

    uint authorId = 0;

    CommentAuthor author = null;

    // Wenn es existierende Kind-Elemente in der Kommentatorenliste gibt...

    if (authorsPart.CommentAuthorList.HasChildren)

    {

        // Überprüfe, ob der übergebene Autor in der Liste ist.

        var authors = authorsPart.CommentAuthorList.Elements<CommentAuthor>().Where(a => a.Name == name && a.Initials == initials);

        // Wenn ja...

        if (authors.Any())

        {

            // Weisen Sie dem neuen Kommentator die vorhandene Autoren-ID zu.

            author = authors.First();

            authorId = author.Id;

        }

        // Wenn nicht...

        if (author == null)

        {

            // Weisen Sie dem übergebenen Autor eine neue ID zu

            authorId = authorsPart.CommentAuthorList.Elements<CommentAuthor>().Select(a => a.Id.Value).Max();

        }

    }

    // Wenn es keine existierenden Kind-Elemente in der Kommentatorenliste gibt.

    if (author == null)

    {

        authorId++;

        // Füge ein neues Kind-Element (Kommentarautor) zur Kommentatorenliste hinzu.

        author = authorsPart.CommentAuthorList.AppendChild<CommentAuthor>

        (new CommentAuthor()

        {

            Id = authorId,

            Name = name,

            Initials = initials,

            ColorIndex = 0

        });

    }

    // Hole die erste Folie mit der GetFirstSlide-Methode.

    SlidePart slidePart1 = GetFirstSlide(doc);

    // Deklariere ein Kommentare-Teil.

    SlideCommentsPart commentsPart;

    // Überprüfe, ob es ein Kommentare-Teil in der ersten Folie gibt.

    if (slidePart1.GetPartsOfType<SlideCommentsPart>().Count() == 0)

    {

        // Falls nicht, füge ein neues Kommentare-Teil hinzu.

        commentsPart = slidePart1.AddNewPart<SlideCommentsPart>();

    }

    else

    {

        // Sonst verwende das erste Kommentare-Teil im Folienteil.

        commentsPart = slidePart1.GetPartsOfType<SlideCommentsPart>().First();

    }

    // Wenn die Kommentarliste nicht existiert.

    if (commentsPart.CommentList == null)

    {

        // Füge eine neue Kommentarliste hinzu.

        commentsPart.CommentList = new CommentList();

    }

    // Hole die neue Kommentar-ID.

    uint commentIdx = author.LastIndex == null ? 1 : author.LastIndex + 1;

    author.LastIndex = commentIdx;

    // Füge einen neuen Kommentar hinzu.

    Comment comment = commentsPart.CommentList.AppendChild<Comment>(

    new Comment()

    {

        AuthorId = authorId,

        Index = commentIdx,

        DateTime = DateTime.Now

    });

    // Füge das Positions-Kindknoten-Element zum Kommentar-Element hinzu.

    comment.Append(

    new Position() { X = 100, Y = 200 },

    new Text() { Text = text });

    // Speichere das Kommentarautoren-Teil.

    authorsPart.CommentAuthorList.Save();

    // Speichere das Kommentare-Teil.

    commentsPart.CommentList.Save();

}

}

// Hole das Folienteil der ersten Folie im Präsentationsdokument.

private static SlidePart GetFirstSlide(PresentationDocument presentationDocument)

{

// Hole die Beziehungs-ID der ersten Folie

PresentationPart part = presentationDocument.PresentationPart;

SlideId slideId = part.Presentation.SlideIdList.GetFirstChild<SlideId>();

string relId = slideId.RelationshipId;

// Hole das Folienteil anhand der Beziehungs-ID.

SlidePart slidePart = (SlidePart)part.GetPartById(relId);

return slidePart;

}


``` 
## **Aspose.Slides**
In **Aspose.Slides** für .NET ist die PPT-Folienkommentarsammlung in jeder **Slide**-Klasse enthalten. Die **CommentCollection**-Klasse wird verwendet, um die Kommentare der jeweiligen Folie zu halten. Die **Comment**-Klasse enthält Informationen wie den Autor, der den Folienkommentar hinzugefügt hat, seine Initialen, die Zeit der Erstellung, die Position des Kommentars auf der Folie und den Kommentartext. Die **CommentAuthor**-Klasse wird verwendet, um die Autoren für Folienkommentare auf Präsentationsebene hinzuzufügen. Die **Presentation**-Klasse enthält die Sammlung von Autoren für die Präsentation in der **CommentAuthors**-Klasse.

Im folgenden Beispiel haben wir den Code-Schnipsel zum Hinzufügen der Folienkommentare hinzugefügt.

``` csharp

 string FilePath = @"..\..\..\..\Beispieldateien\";

string FileName = FilePath + "Füge einen Kommentar zu einer Folie hinzu.pptx";

using (Presentation pres = new Presentation())

{

    // Leere Folie hinzufügen

    pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

    // Autor hinzufügen

    ICommentAuthor author = pres.CommentAuthors.AddAuthor("Zeeshan", "MZ");

    // Position der Kommentare

    PointF point = new PointF();

    point.X = 1;

    point.Y = 1;

    // Folienkommentar für einen Autor auf der Folie hinzufügen

    author.Comments.AddComment("Hallo Zeeshan, dies ist ein Folienkommentar", pres.Slides[0], point, DateTime.Now);

    pres.Save(FileName, Aspose.Slides.Export.SaveFormat.Pptx);

}

``` 
## **Beispielcode herunterladen**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://master.dl.sourceforge.net/project/asposeopenxml/Aspose.Slides%20Vs%20OpenXML/Add%20a%20comment%20to%20a%20slide%20%28Aspose.Slides%29.zip?viasf=1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Add%20a%20comment%20to%20a%20slide%20\(Aspose.Slides\).zip)