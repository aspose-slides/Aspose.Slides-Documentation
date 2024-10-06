---
title: 著者によるすべてのコメントを削除する
type: docs
weight: 70
url: /ja/net/delete-all-the-comments-by-an-author/
---

## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "著者によるすべてのコメントを削除する.pptx";

string author = "Zeeshan Shafqat";

DeleteCommentsByAuthorInPresentation(FileName, author);

// 指定された著者によるスライド内のすべてのコメントを削除します。

public static void DeleteCommentsByAuthorInPresentation(string fileName, string author)

{

if (String.IsNullOrEmpty(fileName) || String.IsNullOrEmpty(author))

    throw new ArgumentNullException("ファイル名または著者名がNULLです！");

using (PresentationDocument doc = PresentationDocument.Open(fileName, true))

{

    // 指定されたコメントの著者を取得します。

    IEnumerable<CommentAuthor> commentAuthors =

        doc.PresentationPart.CommentAuthorsPart.CommentAuthorList.Elements<CommentAuthor>()

        .Where(e => e.Name.Value.Equals(author));

    // 一致するすべての著者を反復処理します。

    foreach (CommentAuthor commentAuthor in commentAuthors)

    {

        UInt32Value authorId = commentAuthor.Id;

        // すべてのスライドを反復処理し、スライド部分を取得します。

        foreach (SlidePart slide in doc.PresentationPart.SlideParts)

        {

            SlideCommentsPart slideCommentsPart = slide.SlideCommentsPart;

            // コメントのリストを取得します。

            if (slideCommentsPart != null && slide.SlideCommentsPart.CommentList != null)

            {

                IEnumerable<Comment> commentList =

                    slideCommentsPart.CommentList.Elements<Comment>().Where(e => e.AuthorId == authorId.Value);

                List<Comment> comments = new List<Comment>();

                comments = commentList.ToList<Comment>();

                foreach (Comment comm in comments)

                {

                    // 指定された著者によるすべてのコメントを削除します。

                    slideCommentsPart.CommentList.RemoveChild<Comment>(comm);

                }

                // コメントPartに既存のコメントがない場合。

                if (slideCommentsPart.CommentList.ChildElements.Count == 0)

                    // この部分を削除します。

                    slide.DeletePart(slideCommentsPart);

            }

        }

        // コメント著者をコメント著者部分から削除します。

        doc.PresentationPart.CommentAuthorsPart.CommentAuthorList.RemoveChild<CommentAuthor>(commentAuthor);

    }

}

}

``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "著者によるすべてのコメントを削除する.pptx";

string author = "MZ";

DeleteCommentsByAuthorInPresentation(FileName, author);

// 指定された著者によるスライド内のすべてのコメントを削除します。

public static void DeleteCommentsByAuthorInPresentation(string fileName, string author)

{

    if (String.IsNullOrEmpty(fileName) || String.IsNullOrEmpty(author))

        throw new ArgumentNullException("ファイル名または著者名がNULLです！");

    //PPTXファイルを表すPresentationExオブジェクトをインスタンス化します。

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
## **サンプルコードのダウンロード**
- [CodePlex](https://asposeopenxml.codeplex.com/releases/view/615920)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Delete%20all%20the%20comments%20by%20an%20author%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Delete%20all%20the%20comments%20by%20an%20author%20\(Aspose.Slides\).zip)