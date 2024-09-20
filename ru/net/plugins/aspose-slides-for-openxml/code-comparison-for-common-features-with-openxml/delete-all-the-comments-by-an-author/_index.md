---
title: Удалить все комментарии автора
type: docs
weight: 70
url: /net/delete-all-the-comments-by-an-author/
---

## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Удалить все комментарии автора.pptx";

string author = "Zeeshan Shafqat";

DeleteCommentsByAuthorInPresentation(FileName, author);

// Удалить все комментарии на слайдах определенного автора.

public static void DeleteCommentsByAuthorInPresentation(string fileName, string author)

{

if (String.IsNullOrEmpty(fileName) || String.IsNullOrEmpty(author))

    throw new ArgumentNullException("Имя файла или имя автора NULL!");

using (PresentationDocument doc = PresentationDocument.Open(fileName, true))

{

    // Получить указанного автора комментариев.

    IEnumerable<CommentAuthor> commentAuthors =

        doc.PresentationPart.CommentAuthorsPart.CommentAuthorList.Elements<CommentAuthor>()

        .Where(e => e.Name.Value.Equals(author));

    // Перебрать всех соответствующих авторов.

    foreach (CommentAuthor commentAuthor in commentAuthors)

    {

        UInt32Value authorId = commentAuthor.Id;

        // Перебрать все слайды и получить части слайдов.

        foreach (SlidePart slide in doc.PresentationPart.SlideParts)

        {

            SlideCommentsPart slideCommentsPart = slide.SlideCommentsPart;

            // Получить список комментариев.

            if (slideCommentsPart != null && slide.SlideCommentsPart.CommentList != null)

            {

                IEnumerable<Comment> commentList =

                    slideCommentsPart.CommentList.Elements<Comment>().Where(e => e.AuthorId == authorId.Value);

                List<Comment> comments = new List<Comment>();

                comments = commentList.ToList<Comment>();

                foreach (Comment comm in comments)

                {

                    // Удалить все комментарии указанного автора.

                    slideCommentsPart.CommentList.RemoveChild<Comment>(comm);

                }

                // Если в part комментариев нет существующих комментариев.

                if (slideCommentsPart.CommentList.ChildElements.Count == 0)

                    // Удалить эту часть.

                    slide.DeletePart(slideCommentsPart);

            }

        }

        // Удалить автора комментариев из части авторов комментариев.

        doc.PresentationPart.CommentAuthorsPart.CommentAuthorList.RemoveChild<CommentAuthor>(commentAuthor);

    }

}

}

``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Удалить все комментарии автора.pptx";

string author = "MZ";

DeleteCommentsByAuthorInPresentation(FileName, author);

// Удалить все комментарии на слайдах определенного автора.

public static void DeleteCommentsByAuthorInPresentation(string fileName, string author)

{

    if (String.IsNullOrEmpty(fileName) || String.IsNullOrEmpty(author))

        throw new ArgumentNullException("Имя файла или имя автора NULL!");

    //Создать объект PresentationEx, представляющий файл PPTX

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
## **Скачать пример кода**
- [CodePlex](https://asposeopenxml.codeplex.com/releases/view/615920)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Удалить%20все%20комментарии%20автора%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Удалить%20все%20комментарии%20автора%20\(Aspose.Slides\).zip)