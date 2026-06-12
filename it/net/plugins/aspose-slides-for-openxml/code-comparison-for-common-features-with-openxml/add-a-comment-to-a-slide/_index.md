---
title: Aggiungi un commento a una diapositiva
type: docs
weight: 10
url: /it/net/add-a-comment-to-a-slide/
---
## **Presentazione OpenXML**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Add a comment to a slide.pptx"; 

AddCommentToPresentation(FileName,

"Zeeshan", "MZ",

"This is my programmatically added comment.");

// Aggiunge un commento alla prima diapositiva del documento di presentazione.

// Il documento di presentazione deve contenere almeno una diapositiva.

private static void AddCommentToPresentation(string file, string initials, string name, string text)

{

using (PresentationDocument doc = PresentationDocument.Open(file, true))

{

    // Dichiarare un oggetto CommentAuthorsPart.

    CommentAuthorsPart authorsPart;

    // Verificare che esista una parte di autori dei commenti.

    if (doc.PresentationPart.CommentAuthorsPart == null)

    {

        // Se no, aggiungerne una nuova.

        authorsPart = doc.PresentationPart.AddNewPart<CommentAuthorsPart>();

    }

    else

    {

        authorsPart = doc.PresentationPart.CommentAuthorsPart;

    }

    // Verificare che vi sia una lista di autori dei commenti nella parte degli autori.

    if (authorsPart.CommentAuthorList == null)

    {

        // Se no, aggiungerne una nuova.

        authorsPart.CommentAuthorList = new CommentAuthorList();

    }

    // Dichiarare un nuovo ID autore.

    uint authorId = 0;

    CommentAuthor author = null;

    // Se ci sono elementi figlio esistenti nella lista degli autori dei commenti...

    if (authorsPart.CommentAuthorList.HasChildren)

    {

        // Verificare che l'autore fornito sia nella lista.

        var authors = authorsPart.CommentAuthorList.Elements<CommentAuthor>().Where(a => a.Name == name && a.Initials == initials);

        // Se sì...

        if (authors.Any())

        {

            // Assegnare al nuovo autore del commento l'ID autore esistente.

            author = authors.First();

            authorId = author.Id;

        }

        // Se no...

        if (author == null)

        {

            // Assegnare all'autore fornito un nuovo ID

            authorId = authorsPart.CommentAuthorList.Elements<CommentAuthor>().Select(a => a.Id.Value).Max();

        }

    }

    // Se non ci sono elementi figlio esistenti nella lista degli autori dei commenti.

    if (author == null)

    {

        authorId++;

        // Aggiungere un nuovo elemento figlio (autore del commento) alla lista degli autori.

        author = authorsPart.CommentAuthorList.AppendChild<CommentAuthor>

        (new CommentAuthor()

        {

            Id = authorId,

            Name = name,

            Initials = initials,

            ColorIndex = 0

        });

    }

    // Ottenere la prima diapositiva, usando il metodo GetFirstSlide.

    SlidePart slidePart1 = GetFirstSlide(doc);

    // Dichiarare una parte dei commenti.

    SlideCommentsPart commentsPart;

    // Verificare che esista una parte dei commenti nella prima parte della diapositiva.

    if (slidePart1.GetPartsOfType<SlideCommentsPart>().Count() == 0)

    {

        // Se no, aggiungere una nuova parte dei commenti.

        commentsPart = slidePart1.AddNewPart<SlideCommentsPart>();

    }

    else

    {

        // Altrimenti, usare la prima parte dei commenti nella parte della diapositiva.

        commentsPart = slidePart1.GetPartsOfType<SlideCommentsPart>().First();

    }

    // Se la lista dei commenti non esiste.

    if (commentsPart.CommentList == null)

    {

        // Aggiungere una nuova lista di commenti.

        commentsPart.CommentList = new CommentList();

    }

    // Ottenere il nuovo ID del commento.

    uint commentIdx = author.LastIndex == null ? 1 : author.LastIndex + 1;

    author.LastIndex = commentIdx;

    // Aggiungere un nuovo commento.

    Comment comment = commentsPart.CommentList.AppendChild<Comment>(

    new Comment()

    {

        AuthorId = authorId,

        Index = commentIdx,

        DateTime = DateTime.Now

    });

    // Aggiungere il nodo figlio di posizione all'elemento commento.

    comment.Append(

    new Position() { X = 100, Y = 200 },

    new Text() { Text = text });

    // Salvare la parte degli autori dei commenti.

    authorsPart.CommentAuthorList.Save();

    // Salvare la parte dei commenti.

    commentsPart.CommentList.Save();

}

}

// Ottenere la parte della diapositiva della prima diapositiva nel documento di presentazione.

private static SlidePart GetFirstSlide(PresentationDocument presentationDocument)

{

// Ottenere l'ID di relazione della prima diapositiva

PresentationPart part = presentationDocument.PresentationPart;

SlideId slideId = part.Presentation.SlideIdList.GetFirstChild<SlideId>();

string relId = slideId.RelationshipId;

// Ottenere la parte della diapositiva tramite l'ID di relazione.

SlidePart slidePart = (SlidePart)part.GetPartById(relId);

return slidePart;

}


``` 
## **Aspose.Slides**
In **Aspose.Slides** per .NET, la raccolta dei commenti delle diapositive PPT è inclusa in ogni classe **Slide**. La classe **CommentCollection** viene utilizzata per contenere i commenti specifici della diapositiva. La classe **Comment** include informazioni come l’autore che ha aggiunto il commento alla diapositiva, le sue iniziali, l’ora di creazione, la posizione del commento sulla diapositiva e il testo del commento. La classe **CommentAuthor** viene utilizzata per aggiungere gli autori dei commenti delle diapositive a livello di presentazione. La classe **Presentation** contiene la raccolta degli autori per la presentazione nella classe **CommentAuthors**.

Nel seguente esempio, abbiamo aggiunto lo snippet di codice per aggiungere i commenti alle diapositive.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Add a comment to a slide.pptx";

using (Presentation pres = new Presentation())

{

    //Aggiunta diapositiva vuota

    pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

    //Aggiunta autore

    ICommentAuthor author = pres.CommentAuthors.AddAuthor("Zeeshan", "MZ");

    //Posizione dei commenti

    PointF point = new PointF();

    point.X = 1;

    point.Y = 1;

    //Aggiunta commento diapositiva per un autore sulla diapositiva

    author.Comments.AddComment("Hello Zeeshan, this is slide comment", pres.Slides[0], point, DateTime.Now);

    pres.Save(FileName, Aspose.Slides.Export.SaveFormat.Pptx);

}

``` 
## **Scarica Codice di Esempio**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Add%20a%20comment%20to%20a%20slide%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Add%20a%20comment%20to%20a%20slide/)