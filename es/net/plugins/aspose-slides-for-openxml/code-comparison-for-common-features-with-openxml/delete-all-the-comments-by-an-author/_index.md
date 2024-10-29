---
title: Eliminar todos los comentarios de un autor
type: docs
weight: 70
url: /es/net/delete-all-the-comments-by-an-author/
---

## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Eliminar todos los comentarios de un autor.pptx";

string author = "Zeeshan Shafqat";

DeleteCommentsByAuthorInPresentation(FileName, author);

// Eliminar todos los comentarios en las diapositivas de un autor determinado.

public static void DeleteCommentsByAuthorInPresentation(string fileName, string author)

{

if (String.IsNullOrEmpty(fileName) || String.IsNullOrEmpty(author))

    throw new ArgumentNullException("¡El nombre del archivo o el nombre del autor es NULL!");

using (PresentationDocument doc = PresentationDocument.Open(fileName, true))

{

    // Obtener el autor de comentario especificado.

    IEnumerable<CommentAuthor> commentAuthors =

        doc.PresentationPart.CommentAuthorsPart.CommentAuthorList.Elements<CommentAuthor>()

        .Where(e => e.Name.Value.Equals(author));

    // Iterar a través de todos los autores que coinciden.

    foreach (CommentAuthor commentAuthor in commentAuthors)

    {

        UInt32Value authorId = commentAuthor.Id;

        // Iterar a través de todas las diapositivas y obtener las partes de la diapositiva.

        foreach (SlidePart slide in doc.PresentationPart.SlideParts)

        {

            SlideCommentsPart slideCommentsPart = slide.SlideCommentsPart;

            // Obtener la lista de comentarios.

            if (slideCommentsPart != null && slide.SlideCommentsPart.CommentList != null)

            {

                IEnumerable<Comment> commentList =

                    slideCommentsPart.CommentList.Elements<Comment>().Where(e => e.AuthorId == authorId.Value);

                List<Comment> comments = new List<Comment>();

                comments = commentList.ToList<Comment>();

                foreach (Comment comm in comments)

                {

                    // Eliminar todos los comentarios del autor especificado.

                    slideCommentsPart.CommentList.RemoveChild<Comment>(comm);

                }

                // Si el commentPart no tiene comentario existente.

                if (slideCommentsPart.CommentList.ChildElements.Count == 0)

                    // Eliminar esta parte.

                    slide.DeletePart(slideCommentsPart);

            }

        }

        // Eliminar el autor del comentario de la parte de autores de comentarios.

        doc.PresentationPart.CommentAuthorsPart.CommentAuthorList.RemoveChild<CommentAuthor>(commentAuthor);

    }

}

}

``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Eliminar todos los comentarios de un autor.pptx";

string author = "MZ";

DeleteCommentsByAuthorInPresentation(FileName, author);

// Eliminar todos los comentarios en las diapositivas de un autor determinado.

public static void DeleteCommentsByAuthorInPresentation(string fileName, string author)

{

    if (String.IsNullOrEmpty(fileName) || String.IsNullOrEmpty(author))

        throw new ArgumentNullException("¡El nombre del archivo o el nombre del autor es NULL!");

    // Instanciar un objeto PresentationEx que representa un archivo PPTX

    using (Presentation pres = new Presentation(fileName))

    {

      ICommentAuthor[] authors=  pres.CommentAuthors.FindByName(author);

      ICommentAuthor thisAuthor = authors[0];

      for (int i = thisAuthor.Comments.Count - 1; i >= 0;i-- )

      {

          thisAuthor.Comments.RemoveAt(i);

      }

      pres.Save(fileName, Aspose.Slides.Export.SaveFormat.Pptx);  

    }

}    

``` 
## **Descargar Código de Ejemplo**
- [CodePlex](https://asposeopenxml.codeplex.com/releases/view/615920)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Eliminar%20todos%20los%20comentarios%20de%20un%20autor%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Eliminar%20todos%20los%20comentarios%20de%20un%20autor%20\(Aspose.Slides\).zip)