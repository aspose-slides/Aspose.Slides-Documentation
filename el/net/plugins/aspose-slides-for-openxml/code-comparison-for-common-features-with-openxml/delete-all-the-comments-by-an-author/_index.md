---
title: Διαγραφή όλων των σχολίων από έναν συγγραφέα
type: docs
weight: 70
url: /el/net/delete-all-the-comments-by-an-author/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Delete all the comments by an author.pptx";

string author = "Zeeshan Shafqat";

DeleteCommentsByAuthorInPresentation(FileName, author);

// Αφαίρεση όλων των σχολίων στις διαφάνειες από έναν συγκεκριμένο συγγραφέα.

public static void DeleteCommentsByAuthorInPresentation(string fileName, string author)

{

if (String.IsNullOrEmpty(fileName) || String.IsNullOrEmpty(author))

    throw new ArgumentNullException("File name or author name is NULL!");

using (PresentationDocument doc = PresentationDocument.Open(fileName, true))

{

    // Λήψη του καθορισμένου συγγραφέα σχολίου.

    IEnumerable<CommentAuthor> commentAuthors =

        doc.PresentationPart.CommentAuthorsPart.CommentAuthorList.Elements<CommentAuthor>()

        .Where(e => e.Name.Value.Equals(author));

    // Επανάληψη σε όλους τους αντίστοιχους συγγραφείς.

    foreach (CommentAuthor commentAuthor in commentAuthors)

    {

        UInt32Value authorId = commentAuthor.Id;

        // Επανάληψη σε όλες τις διαφάνειες και λήψη των τμημάτων της διαφάνειας.

        foreach (SlidePart slide in doc.PresentationPart.SlideParts)

        {

            SlideCommentsPart slideCommentsPart = slide.SlideCommentsPart;

            // Λήψη της λίστας σχολίων.

            if (slideCommentsPart != null && slide.SlideCommentsPart.CommentList != null)

            {

                IEnumerable<Comment> commentList =

                    slideCommentsPart.CommentList.Elements<Comment>().Where(e => e.AuthorId == authorId.Value);

                List<Comment> comments = new List<Comment>();

                comments = commentList.ToList<Comment>();

                foreach (Comment comm in comments)

                {

                    // Διαγραφή όλων των σχολίων από τον καθορισμένο συγγραφέα.

                    slideCommentsPart.CommentList.RemoveChild<Comment>(comm);

                }

                // Αν το commentPart δεν έχει κανένα υπάρχον σχόλιο.

                if (slideCommentsPart.CommentList.ChildElements.Count == 0)

                    // Διαγραφή αυτού του τμήματος.

                    slide.DeletePart(slideCommentsPart);

            }

        }

        // Διαγραφή του συγγραφέα σχολίου από το τμήμα συγγραφέων σχολίων.

        doc.PresentationPart.CommentAuthorsPart.CommentAuthorList.RemoveChild<CommentAuthor>(commentAuthor);

    }

}

}

``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Delete all the comments by an author.pptx";

string author = "MZ";

DeleteCommentsByAuthorInPresentation(FileName, author);

// Αφαίρεση όλων των σχολίων στις διαφάνειες από έναν συγκεκριμένο συγγραφέα.

public static void DeleteCommentsByAuthorInPresentation(string fileName, string author)

{

    if (String.IsNullOrEmpty(fileName) || String.IsNullOrEmpty(author))

        throw new ArgumentNullException("File name or author name is NULL!");

    // Δημιουργία αντικειμένου PresentationEx που αντιπροσωπεύει ένα αρχείο PPTX.

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
## **Λήψη Δειγματικού Κώδικα**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Delete%20all%20the%20comments%20by%20an%20author%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Delete%20all%20the%20comments%20by%20an%20author/)