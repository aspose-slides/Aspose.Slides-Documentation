---
title: Hapus semua komentar oleh penulis
type: docs
weight: 70
url: /id/net/delete-all-the-comments-by-an-author/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Delete all the comments by an author.pptx";

string author = "Zeeshan Shafqat";

DeleteCommentsByAuthorInPresentation(FileName, author);

// Hapus semua komentar dalam slide oleh penulis tertentu.

public static void DeleteCommentsByAuthorInPresentation(string fileName, string author)

{

if (String.IsNullOrEmpty(fileName) || String.IsNullOrEmpty(author))

    throw new ArgumentNullException("File name or author name is NULL!");

using (PresentationDocument doc = PresentationDocument.Open(fileName, true))

{

    // Dapatkan penulis komentar yang ditentukan.

    IEnumerable<CommentAuthor> commentAuthors =

        doc.PresentationPart.CommentAuthorsPart.CommentAuthorList.Elements<CommentAuthor>()

        .Where(e => e.Name.Value.Equals(author));

    // Iterasi melalui semua penulis yang cocok.

    foreach (CommentAuthor commentAuthor in commentAuthors)

    {

        UInt32Value authorId = commentAuthor.Id;

        // Iterasi melalui semua slide dan dapatkan bagian slide.

        foreach (SlidePart slide in doc.PresentationPart.SlideParts)

        {

            SlideCommentsPart slideCommentsPart = slide.SlideCommentsPart;

            // Dapatkan daftar komentar.

            if (slideCommentsPart != null && slide.SlideCommentsPart.CommentList != null)

            {

                IEnumerable<Comment> commentList =

                    slideCommentsPart.CommentList.Elements<Comment>().Where(e => e.AuthorId == authorId.Value);

                List<Comment> comments = new List<Comment>();

                comments = commentList.ToList<Comment>();

                foreach (Comment comm in comments)

                {

                    // Hapus semua komentar oleh penulis yang ditentukan.

                    slideCommentsPart.CommentList.RemoveChild<Comment>(comm);

                }

                // Jika commentPart tidak memiliki komentar yang ada.

                    // Hapus bagian ini.

                    slide.DeletePart(slideCommentsPart);

            }

        }

        // Hapus penulis komentar dari bagian penulis komentar.

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

// Hapus semua komentar dalam slide oleh penulis tertentu.

public static void DeleteCommentsByAuthorInPresentation(string fileName, string author)

{

    if (String.IsNullOrEmpty(fileName) || String.IsNullOrEmpty(author))

        throw new ArgumentNullException("File name or author name is NULL!");

    //Instansiasi objek PresentationEx yang merepresentasikan file PPTX

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
## **Unduh Kode Contoh**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Delete%20all%20the%20comments%20by%20an%20author%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Delete%20all%20the%20comments%20by%20an%20author/)