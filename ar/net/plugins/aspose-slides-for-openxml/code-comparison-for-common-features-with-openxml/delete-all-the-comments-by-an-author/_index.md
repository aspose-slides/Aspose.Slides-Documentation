---
title: حذف جميع التعليقات بواسطة مؤلف
type: docs
weight: 70
url: /ar/net/delete-all-the-comments-by-an-author/
---

## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "حذف جميع التعليقات بواسطة مؤلف.pptx";

string author = "زیشان شفقاط";

DeleteCommentsByAuthorInPresentation(FileName, author);

// أزل جميع التعليقات في الشرائح بواسطة مؤلف معين.

public static void DeleteCommentsByAuthorInPresentation(string fileName, string author)

{

if (String.IsNullOrEmpty(fileName) || String.IsNullOrEmpty(author))

    throw new ArgumentNullException("اسم الملف أو اسم المؤلف هو NULL!");

using (PresentationDocument doc = PresentationDocument.Open(fileName, true))

{

    // احصل على المؤلف المحدد للتعليق.

    IEnumerable<CommentAuthor> commentAuthors =

        doc.PresentationPart.CommentAuthorsPart.CommentAuthorList.Elements<CommentAuthor>()

        .Where(e => e.Name.Value.Equals(author));

    // تكرار عبر جميع المؤلفين المطابقين.

    foreach (CommentAuthor commentAuthor in commentAuthors)

    {

        UInt32Value authorId = commentAuthor.Id;

        // تكرار عبر جميع الشرائح واحصل على أجزاء الشريحة.

        foreach (SlidePart slide in doc.PresentationPart.SlideParts)

        {

            SlideCommentsPart slideCommentsPart = slide.SlideCommentsPart;

            // احصل على قائمة التعليقات.

            if (slideCommentsPart != null && slide.SlideCommentsPart.CommentList != null)

            {

                IEnumerable<Comment> commentList =

                    slideCommentsPart.CommentList.Elements<Comment>().Where(e => e.AuthorId == authorId.Value);

                List<Comment> comments = new List<Comment>();

                comments = commentList.ToList<Comment>();

                foreach (Comment comm in comments)

                {

                    // احذف جميع التعليقات بواسطة المؤلف المحدد.

                    slideCommentsPart.CommentList.RemoveChild<Comment>(comm);

                }

                // إذا لم يكن هناك تعليق موجود في commentPart.

                if (slideCommentsPart.CommentList.ChildElements.Count == 0)

                    // احذف هذا الجزء.

                    slide.DeletePart(slideCommentsPart);

            }

        }

        // احذف مؤلف التعليق من جزء مؤلفي التعليق.

        doc.PresentationPart.CommentAuthorsPart.CommentAuthorList.RemoveChild<CommentAuthor>(commentAuthor);

    }

}

}

``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "حذف جميع التعليقات بواسطة مؤلف.pptx";

string author = "م ز";

DeleteCommentsByAuthorInPresentation(FileName, author);

// أزل جميع التعليقات في الشرائح بواسطة مؤلف معين.

public static void DeleteCommentsByAuthorInPresentation(string fileName, string author)

{

    if (String.IsNullOrEmpty(fileName) || String.IsNullOrEmpty(author))

        throw new ArgumentNullException("اسم الملف أو اسم المؤلف هو NULL!");

    // إنشاء كائن PresentationEx الذي يمثل ملف PPTX

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
## **تحميل مثال الكود**
- [CodePlex](https://asposeopenxml.codeplex.com/releases/view/615920)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Delete%20all%20the%20comments%20by%20an%20author%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Delete%20all%20the%20comments%20by%20an%20author%20\(Aspose.Slides\).zip)