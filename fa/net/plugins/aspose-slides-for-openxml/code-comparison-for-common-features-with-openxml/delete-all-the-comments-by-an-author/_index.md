---
title: حذف تمام نظرات توسط یک نویسنده
type: docs
weight: 70
url: /fa/net/delete-all-the-comments-by-an-author/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Delete all the comments by an author.pptx";

string author = "Zeeshan Shafqat";

DeleteCommentsByAuthorInPresentation(FileName, author);

// حذف تمام نظرات در اسلایدها توسط یک نویسنده خاص.

public static void DeleteCommentsByAuthorInPresentation(string fileName, string author)

{

if (String.IsNullOrEmpty(fileName) || String.IsNullOrEmpty(author))

    throw new ArgumentNullException("File name or author name is NULL!");

using (PresentationDocument doc = PresentationDocument.Open(fileName, true))

{

    // دریافت نویسندهٔ نظر مشخص‌شده.

    IEnumerable<CommentAuthor> commentAuthors =

        doc.PresentationPart.CommentAuthorsPart.CommentAuthorList.Elements<CommentAuthor>()

        .Where(e => e.Name.Value.Equals(author));

    // تکرار بر روی تمام نویسندگان مطابقت‌دار.

    foreach (CommentAuthor commentAuthor in commentAuthors)

    {

        UInt32Value authorId = commentAuthor.Id;

        // تکرار بر روی تمام اسلایدها و دریافت قسمت‌های اسلاید.

        foreach (SlidePart slide in doc.PresentationPart.SlideParts)

        {

            SlideCommentsPart slideCommentsPart = slide.SlideCommentsPart;

            // دریافت فهرست نظرات.

            if (slideCommentsPart != null && slide.SlideCommentsPart.CommentList != null)

            {

                IEnumerable<Comment> commentList =

                    slideCommentsPart.CommentList.Elements<Comment>().Where(e => e.AuthorId == authorId.Value);

                List<Comment> comments = new List<Comment>();

                comments = commentList.ToList<Comment>();

                foreach (Comment comm in comments)

                {

                    // حذف تمام نظرات توسط نویسندهٔ مشخص‌شده.

                    slideCommentsPart.CommentList.RemoveChild<Comment>(comm);

                }

                // اگر قسمت نظر هیچ نظری موجود نداشته باشد.

                if (slideCommentsPart.CommentList.ChildElements.Count == 0)

                    // حذف این قسمت.

                    slide.DeletePart(slideCommentsPart);

            }

        }

        // حذف نویسندهٔ نظر از قسمت نویسندگان نظرات.

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

// حذف تمام نظرات در اسلایدها توسط یک نویسنده خاص.

public static void DeleteCommentsByAuthorInPresentation(string fileName, string author)

{

    if (String.IsNullOrEmpty(fileName) || String.IsNullOrEmpty(author))

        throw new ArgumentNullException("File name or author name is NULL!");

    //یک شیء PresentationEx که نمایانگر یک فایل PPTX است را ایجاد می‌کند
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
## **دریافت کد نمونه**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Delete%20all%20the%20comments%20by%20an%20author%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Delete%20all%20the%20comments%20by%20an%20author/)