---
title: Agregar un comentario a una diapositiva
type: docs
weight: 10
url: /es/net/add-a-comment-to-a-slide/
---

## **Presentación OpenXML:**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Agregar un comentario a una diapositiva.pptx"; 

AddCommentToPresentation(FileName,

"Zeeshan", "MZ",

"Este es mi comentario agregado programáticamente.");

// Agrega un comentario a la primera diapositiva del documento de presentación.

// El documento de presentación debe contener al menos una diapositiva.

private static void AddCommentToPresentation(string file, string initials, string name, string text)

{

using (PresentationDocument doc = PresentationDocument.Open(file, true))

{

    // Declarar un objeto CommentAuthorsPart.

    CommentAuthorsPart authorsPart;

    // Verificar que exista una parte de autores de comentario.

    if (doc.PresentationPart.CommentAuthorsPart == null)

    {

        // Si no, agregar una nueva.

        authorsPart = doc.PresentationPart.AddNewPart<CommentAuthorsPart>();

    }

    else

    {

        authorsPart = doc.PresentationPart.CommentAuthorsPart;

    }

    // Verificar que haya una lista de autores de comentario en la parte de autores de comentario.

    if (authorsPart.CommentAuthorList == null)

    {

        // Si no, agregar una nueva.

        authorsPart.CommentAuthorList = new CommentAuthorList();

    }

    // Declarar un nuevo ID de autor.

    uint authorId = 0;

    CommentAuthor author = null;

    // Si hay elementos hijos existentes en la lista de autores de comentarios...

    if (authorsPart.CommentAuthorList.HasChildren)

    {

        // Verificar que el autor pasado esté en la lista.

        var authors = authorsPart.CommentAuthorList.Elements<CommentAuthor>().Where(a => a.Name == name && a.Initials == initials);

        // Si es así...

        if (authors.Any())

        {

            // Asignar al nuevo autor de comentario el ID de autor existente.

            author = authors.First();

            authorId = author.Id;

        }

        // Si no...

        if (author == null)

        {

            // Asignar al autor pasado un nuevo ID

            authorId = authorsPart.CommentAuthorList.Elements<CommentAuthor>().Select(a => a.Id.Value).Max();

        }

    }

    // Si no hay elementos hijos existentes en la lista de autores de comentarios.

    if (author == null)

    {

        authorId++;

        // Agregar un nuevo elemento hijo (autor de comentario) a la lista de autores de comentario.

        author = authorsPart.CommentAuthorList.AppendChild<CommentAuthor>

        (new CommentAuthor()

        {

            Id = authorId,

            Name = name,

            Initials = initials,

            ColorIndex = 0

        });

    }

    // Obtener la primera diapositiva, usando el método GetFirstSlide.

    SlidePart slidePart1 = GetFirstSlide(doc);

    // Declarar una parte de comentarios.

    SlideCommentsPart commentsPart;

    // Verificar que haya una parte de comentarios en la primera parte de la diapositiva.

    if (slidePart1.GetPartsOfType<SlideCommentsPart>().Count() == 0)

    {

        // Si no, agregar una nueva parte de comentarios.

        commentsPart = slidePart1.AddNewPart<SlideCommentsPart>();

    }

    else

    {

        // De lo contrario, usar la primera parte de comentarios en la parte de la diapositiva.

        commentsPart = slidePart1.GetPartsOfType<SlideCommentsPart>().First();

    }

    // Si la lista de comentarios no existe.

    if (commentsPart.CommentList == null)

    {

        // Agregar una nueva lista de comentarios.

        commentsPart.CommentList = new CommentList();

    }

    // Obtener el nuevo ID de comentario.

    uint commentIdx = author.LastIndex == null ? 1 : author.LastIndex + 1;

    author.LastIndex = commentIdx;

    // Agregar un nuevo comentario.

    Comment comment = commentsPart.CommentList.AppendChild<Comment>(

    new Comment()

    {

        AuthorId = authorId,

        Index = commentIdx,

        DateTime = DateTime.Now

    });

    // Agregar el nodo hijo de posición al elemento comentario.

    comment.Append(

    new Position() { X = 100, Y = 200 },

    new Text() { Text = text });

    // Guardar la parte de autores de comentario.

    authorsPart.CommentAuthorList.Save();

    // Guardar la parte de comentarios.

    commentsPart.CommentList.Save();

}

}

// Obtener la parte de la diapositiva de la primera diapositiva en el documento de presentación.

private static SlidePart GetFirstSlide(PresentationDocument presentationDocument)

{

// Obtener el ID de relación de la primera diapositiva

PresentationPart part = presentationDocument.PresentationPart;

SlideId slideId = part.Presentation.SlideIdList.GetFirstChild<SlideId>();

string relId = slideId.RelationshipId;

// Obtener la parte de la diapositiva por el ID de relación.

SlidePart slidePart = (SlidePart)part.GetPartById(relId);

return slidePart;

}


``` 
## **Aspose.Slides**
En **Aspose.Slides** para .NET, la colección de comentarios de diapositivas de PPT está incluida en cada clase **Slide**. La clase **CommentCollection** se usa para contener los comentarios de una diapositiva particular. La clase **Comment** incluye información como el autor que agregó el comentario de la diapositiva, sus iniciales, la hora de creación, la posición del comentario en la diapositiva y el texto del comentario. La clase **CommentAuthor** se utiliza para agregar los autores de comentarios a nivel de presentación. La clase **Presentation** contiene la colección de autores para la presentación en la clase **CommentAuthors**.

En el siguiente ejemplo, hemos agregado el fragmento de código para agregar los comentarios de la diapositiva.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Agregar un comentario a una diapositiva.pptx";

using (Presentation pres = new Presentation())

{

    //Agregando diapositiva vacía

    pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

    //Agregando autor

    ICommentAuthor author = pres.CommentAuthors.AddAuthor("Zeeshan", "MZ");

    //Posición de los comentarios

    PointF point = new PointF();

    point.X = 1;

    point.Y = 1;

    //Agregando comentario de diapositiva para un autor en la diapositiva

    author.Comments.AddComment("Hola Zeeshan, este es un comentario de diapositiva", pres.Slides[0], point, DateTime.Now);

    pres.Save(FileName, Aspose.Slides.Export.SaveFormat.Pptx);

}

``` 
## **Descargar Código de Ejemplo**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://master.dl.sourceforge.net/project/asposeopenxml/Aspose.Slides%20Vs%20OpenXML/Add%20a%20comment%20to%20a%20slide%20%28Aspose.Slides%29.zip?viasf=1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Add%20a%20comment%20to%20a%20slide%20\(Aspose.Slides\).zip)