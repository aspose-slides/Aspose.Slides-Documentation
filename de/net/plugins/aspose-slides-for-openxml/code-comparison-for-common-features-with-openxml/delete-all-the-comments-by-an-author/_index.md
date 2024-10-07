---
title: Alle Kommentare eines Autors löschen
type: docs
weight: 70
url: /net/delete-all-the-comments-by-an-author/
---

## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Alle Kommentare eines Autors löschen.pptx";

string author = "Zeeshan Shafqat";

DeleteCommentsByAuthorInPresentation(FileName, author);

// Alle Kommentare in den Folien eines bestimmten Autors entfernen.

public static void DeleteCommentsByAuthorInPresentation(string fileName, string author)

{

if (String.IsNullOrEmpty(fileName) || String.IsNullOrEmpty(author))

    throw new ArgumentNullException("Dateiname oder Autorenname ist NULL!");

using (PresentationDocument doc = PresentationDocument.Open(fileName, true))

{

    // Den angegebenen Kommentarautor abrufen.

    IEnumerable<CommentAuthor> commentAuthors =

        doc.PresentationPart.CommentAuthorsPart.CommentAuthorList.Elements<CommentAuthor>()

        .Where(e => e.Name.Value.Equals(author));

    // Durch alle übereinstimmenden Autoren iterieren.

    foreach (CommentAuthor commentAuthor in commentAuthors)

    {

        UInt32Value authorId = commentAuthor.Id;

        // Durch alle Folien iterieren und die Folienteile abrufen.

        foreach (SlidePart slide in doc.PresentationPart.SlideParts)

        {

            SlideCommentsPart slideCommentsPart = slide.SlideCommentsPart;

            // Die Liste der Kommentare abrufen.

            if (slideCommentsPart != null && slide.SlideCommentsPart.CommentList != null)

            {

                IEnumerable<Comment> commentList =

                    slideCommentsPart.CommentList.Elements<Comment>().Where(e => e.AuthorId == authorId.Value);

                List<Comment> comments = new List<Comment>();

                comments = commentList.ToList<Comment>();

                foreach (Comment comm in comments)

                {

                    // Alle Kommentare des angegebenen Autors löschen.

                    slideCommentsPart.CommentList.RemoveChild<Comment>(comm);

                }

                // Wenn die commentPart keine bestehenden Kommentare hat.

                if (slideCommentsPart.CommentList.ChildElements.Count == 0)

                    // Dieses Teil löschen.

                    slide.DeletePart(slideCommentsPart);

            }

        }

        // Den Kommentarautor aus dem Kommentarauszug löschen.

        doc.PresentationPart.CommentAuthorsPart.CommentAuthorList.RemoveChild<CommentAuthor>(commentAuthor);

    }

}

}

``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Alle Kommentare eines Autors löschen.pptx";

string author = "MZ";

DeleteCommentsByAuthorInPresentation(FileName, author);

// Alle Kommentare in den Folien eines bestimmten Autors entfernen.

public static void DeleteCommentsByAuthorInPresentation(string fileName, string author)

{

    if (String.IsNullOrEmpty(fileName) || String.IsNullOrEmpty(author))

        throw new ArgumentNullException("Dateiname oder Autorenname ist NULL!");

    //Ein PresentationEx-Objekt instanziieren, das eine PPTX-Datei darstellt

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
## **Beispielcode herunterladen**
- [CodePlex](https://asposeopenxml.codeplex.com/releases/view/615920)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Delete%20alle%20Kommentare%20eines%20Autors%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Alle%20Kommentare%20eines%20Autors%20löschen%20\(Aspose.Slides\).zip)