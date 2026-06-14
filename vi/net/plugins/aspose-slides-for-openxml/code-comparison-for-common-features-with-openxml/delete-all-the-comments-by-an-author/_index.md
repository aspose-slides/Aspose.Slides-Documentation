---
title: Xóa tất cả các bình luận của một tác giả
type: docs
weight: 70
url: /vi/net/delete-all-the-comments-by-an-author/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Delete all the comments by an author.pptx";

string author = "Zeeshan Shafqat";

DeleteCommentsByAuthorInPresentation(FileName, author);

// Xóa tất cả các bình luận trong các slide bởi một tác giả nhất định.

public static void DeleteCommentsByAuthorInPresentation(string fileName, string author)

{

if (String.IsNullOrEmpty(fileName) || String.IsNullOrEmpty(author))

    throw new ArgumentNullException("File name or author name is NULL!");

using (PresentationDocument doc = PresentationDocument.Open(fileName, true))

{

    // Lấy tác giả bình luận được chỉ định.

    IEnumerable<CommentAuthor> commentAuthors =

        doc.PresentationPart.CommentAuthorsPart.CommentAuthorList.Elements<CommentAuthor>()

        .Where(e => e.Name.Value.Equals(author));

    // Duyệt qua tất cả các tác giả phù hợp.

    foreach (CommentAuthor commentAuthor in commentAuthors)

    {

        UInt32Value authorId = commentAuthor.Id;

        // Duyệt qua tất cả các slide và lấy các phần slide.

        foreach (SlidePart slide in doc.PresentationPart.SlideParts)

        {

            SlideCommentsPart slideCommentsPart = slide.SlideCommentsPart;

            // Lấy danh sách các bình luận.

            if (slideCommentsPart != null && slide.SlideCommentsPart.CommentList != null)

            {

                IEnumerable<Comment> commentList =

                    slideCommentsPart.CommentList.Elements<Comment>().Where(e => e.AuthorId == authorId.Value);

                List<Comment> comments = new List<Comment>();

                comments = commentList.ToList<Comment>();

                foreach (Comment comm in comments)

                {

                    // Xóa tất cả các bình luận của tác giả đã chỉ định.

                    slideCommentsPart.CommentList.RemoveChild<Comment>(comm);

                }

                // Nếu phần comment không còn bình luận nào.

                if (slideCommentsPart.CommentList.ChildElements.Count == 0)

                    // Xóa phần này.

                    slide.DeletePart(slideCommentsPart);

            }

        }

        // Xóa tác giả bình luận khỏi phần tác giả bình luận.

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

// Xóa tất cả các bình luận trong các slide bởi một tác giả nhất định.

public static void DeleteCommentsByAuthorInPresentation(string fileName, string author)

{

    if (String.IsNullOrEmpty(fileName) || String.IsNullOrEmpty(author))

        throw new ArgumentNullException("File name or author name is NULL!");

    //Tạo một đối tượng PresentationEx đại diện cho tệp PPTX

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
## **Tải mã mẫu**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Delete%20all%20the%20comments%20by%20an%20author%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Delete%20all%20the%20comments%20by%20an%20author/)