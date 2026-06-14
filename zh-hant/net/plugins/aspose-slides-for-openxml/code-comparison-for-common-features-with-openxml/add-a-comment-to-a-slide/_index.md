---
title: 在投影片上新增註解
type: docs
weight: 10
url: /zh-hant/net/add-a-comment-to-a-slide/
---
## **OpenXML 簡報**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Add a comment to a slide.pptx"; 

AddCommentToPresentation(FileName,

"Zeeshan", "MZ",

"This is my programmatically added comment.");

// 在簡報文件的第一張投影片上新增註解。
// 簡報文件必須至少包含一張投影片。

private static void AddCommentToPresentation(string file, string initials, string name, string text)

{

using (PresentationDocument doc = PresentationDocument.Open(file, true))

{

    // 宣告 CommentAuthorsPart 物件。

    CommentAuthorsPart authorsPart;

    // 驗證是否已存在評論作者部分。

    if (doc.PresentationPart.CommentAuthorsPart == null)

    {

        // 如果不存在，新增一個。

        authorsPart = doc.PresentationPart.AddNewPart<CommentAuthorsPart>();

    }

    else

    {

        authorsPart = doc.PresentationPart.CommentAuthorsPart;

    }

    // 驗證評論作者部分中是否有評論作者列表。

    if (authorsPart.CommentAuthorList == null)

    {

        // 如果不存在，新增一個。

        authorsPart.CommentAuthorList = new CommentAuthorList();

    }

    // 宣告新的作者 ID。

    uint authorId = 0;

    CommentAuthor author = null;

    // 如果評論作者列表中已存在子元素...

    if (authorsPart.CommentAuthorList.HasChildren)

    {

        // 驗證傳入的作者是否在列表中。

        var authors = authorsPart.CommentAuthorList.Elements<CommentAuthor>().Where(a => a.Name == name && a.Initials == initials);

        // 如果是...

        if (authors.Any())

        {

            // 為新評論作者指派現有的作者 ID。

            author = authors.First();

            authorId = author.Id;

        }

        // 如果不是...

        if (author == null)

        {

            // 為傳入的作者指派新的 ID

            authorId = authorsPart.CommentAuthorList.Elements<CommentAuthor>().Select(a => a.Id.Value).Max();

        }

    }

    // 如果評論作者列表中沒有既有子元素。

    if (author == null)

    {

        authorId++;

        // 在評論作者列表中新增子元素（評論作者）。

        author = authorsPart.CommentAuthorList.AppendChild<CommentAuthor>

        (new CommentAuthor()

        {

            Id = authorId,

            Name = name,

            Initials = initials,

            ColorIndex = 0

        });

    }

    // 取得第一張投影片，使用 GetFirstSlide 方法。

    SlidePart slidePart1 = GetFirstSlide(doc);

    // 宣告評論部分。

    SlideCommentsPart commentsPart;

    // 驗證第一張投影片部分中是否有評論部分。

    if (slidePart1.GetPartsOfType<SlideCommentsPart>().Count() == 0)

    {

        // 如果不存在，新增一個評論部分。

        commentsPart = slidePart1.AddNewPart<SlideCommentsPart>();

    }

    else

    {

        // 否則，使用投影片部分中的第一個評論部分。

        commentsPart = slidePart1.GetPartsOfType<SlideCommentsPart>().First();

    }

    // 如果評論清單不存在。

    if (commentsPart.CommentList == null)

    {

        // 新增一個評論清單。

        commentsPart.CommentList = new CommentList();

    }

    // 取得新的評論 ID。

    uint commentIdx = author.LastIndex == null ? 1 : author.LastIndex + 1;

    author.LastIndex = commentIdx;

    // 新增一個評論。

    Comment comment = commentsPart.CommentList.AppendChild<Comment>(

    new Comment()

    {

        AuthorId = authorId,

        Index = commentIdx,

        DateTime = DateTime.Now

    });

    // 為評論元素新增位置子節點。

    comment.Append(

    new Position() { X = 100, Y = 200 },

    new Text() { Text = text });

    // 儲存評論作者部分。

    authorsPart.CommentAuthorList.Save();

    // 儲存評論部分。

    commentsPart.CommentList.Save();

}

}

// 取得第一張投影片的關係 ID

private static SlidePart GetFirstSlide(PresentationDocument presentationDocument)

{

// 依關係 ID 取得投影片部分。

PresentationPart part = presentationDocument.PresentationPart;

SlideId slideId = part.Presentation.SlideIdList.GetFirstChild<SlideId>();

string relId = slideId.RelationshipId;

// 依關係 ID 取得投影片部分。

SlidePart slidePart = (SlidePart)part.GetPartById(relId);

return slidePart;

}


``` 
## **Aspose.Slides**
在 .NET 的 **Aspose.Slides** 中，PPT 投影片註解集合包含在每個 **Slide** 類別中。**CommentCollection** 類別用於保存特定投影片的註解。**Comment** 類別包含如加入註解的作者、其縮寫、建立時間、註解在投影片上的位置以及註解文字等資訊。**CommentAuthor** 類別用於在簡報層級為投影片註解新增作者。**Presentation** 類別在 **CommentAuthors** 類別中保存簡報的作者集合。

以下範例中，我們加入了用於新增投影片註解的程式碼片段。

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Add a comment to a slide.pptx";

using (Presentation pres = new Presentation())

{

    //加入空白投影片

    pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

    //加入作者

    ICommentAuthor author = pres.CommentAuthors.AddAuthor("Zeeshan", "MZ");

    //註解的位置

    PointF point = new PointF();

    point.X = 1;

    point.Y = 1;

    //為作者在投影片上新增註解

    author.Comments.AddComment("Hello Zeeshan, this is slide comment", pres.Slides[0], point, DateTime.Now);

    pres.Save(FileName, Aspose.Slides.Export.SaveFormat.Pptx);

}

``` 
## **下載範例程式碼**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Add%20a%20comment%20to%20a%20slide%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Add%20a%20comment%20to%20a%20slide/)