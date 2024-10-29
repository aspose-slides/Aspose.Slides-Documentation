---
title: Supprimer tous les commentaires d'un auteur
type: docs
weight: 70
url: /fr/net/delete-all-the-comments-by-an-author/
---

## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Supprimer tous les commentaires d'un auteur.pptx";

string author = "Zeeshan Shafqat";

DeleteCommentsByAuthorInPresentation(FileName, author);

// Supprimer tous les commentaires dans les diapositives d'un certain auteur.

public static void DeleteCommentsByAuthorInPresentation(string fileName, string author)

{

if (String.IsNullOrEmpty(fileName) || String.IsNullOrEmpty(author))

    throw new ArgumentNullException("Le nom du fichier ou le nom de l'auteur est NULL!");

using (PresentationDocument doc = PresentationDocument.Open(fileName, true))

{

    // Obtenir l'auteur de commentaire spécifié.

    IEnumerable<CommentAuthor> commentAuthors =

        doc.PresentationPart.CommentAuthorsPart.CommentAuthorList.Elements<CommentAuthor>()

        .Where(e => e.Name.Value.Equals(author));

    // Itérer à travers tous les auteurs correspondants.

    foreach (CommentAuthor commentAuthor in commentAuthors)

    {

        UInt32Value authorId = commentAuthor.Id;

        // Itérer à travers toutes les diapositives et obtenir les parties diaporama.

        foreach (SlidePart slide in doc.PresentationPart.SlideParts)

        {

            SlideCommentsPart slideCommentsPart = slide.SlideCommentsPart;

            // Obtenir la liste des commentaires.

            if (slideCommentsPart != null && slide.SlideCommentsPart.CommentList != null)

            {

                IEnumerable<Comment> commentList =

                    slideCommentsPart.CommentList.Elements<Comment>().Where(e => e.AuthorId == authorId.Value);

                List<Comment> comments = new List<Comment>();

                comments = commentList.ToList<Comment>();

                foreach (Comment comm in comments)

                {

                    // Supprimer tous les commentaires de l'auteur spécifié.

                    slideCommentsPart.CommentList.RemoveChild<Comment>(comm);

                }

                // Si la partie commentaire n'a pas de commentaire existant.

                if (slideCommentsPart.CommentList.ChildElements.Count == 0)

                    // Supprimer cette partie.

                    slide.DeletePart(slideCommentsPart);

            }

        }

        // Supprimer l'auteur de commentaire de la partie des auteurs de commentaire.

        doc.PresentationPart.CommentAuthorsPart.CommentAuthorList.RemoveChild<CommentAuthor>(commentAuthor);

    }

}

}

``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Supprimer tous les commentaires d'un auteur.pptx";

string author = "MZ";

DeleteCommentsByAuthorInPresentation(FileName, author);

// Supprimer tous les commentaires dans les diapositives d'un certain auteur.

public static void DeleteCommentsByAuthorInPresentation(string fileName, string author)

{

    if (String.IsNullOrEmpty(fileName) || String.IsNullOrEmpty(author))

        throw new ArgumentNullException("Le nom du fichier ou le nom de l'auteur est NULL!");

    //Instancier un objet PresentationEx qui représente un fichier PPTX

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
## **Télécharger le code d'exemple**
- [CodePlex](https://asposeopenxml.codeplex.com/releases/view/615920)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Supprimer%20tous%20les%20commentaires%20d'un%20auteur%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Supprimer%20tous%20les%20commentaires%20d'un%20auteur%20\(Aspose.Slides\).zip)