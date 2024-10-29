---
title: 在幻灯片上添加注释
type: docs
weight: 10
url: /zh/net/add-a-comment-to-a-slide/
---

## **OpenXML 演示文稿:**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "在幻灯片上添加注释.pptx"; 

AddCommentToPresentation(FileName,

"Zeeshan", "MZ",

"这是我程序matically添加的注释。");

// 在演示文稿文档的第一张幻灯片上添加注释。

// 演示文稿文档必须至少包含一张幻灯片。

private static void AddCommentToPresentation(string file, string initials, string name, string text)

{

using (PresentationDocument doc = PresentationDocument.Open(file, true))

{

    // 声明一个 CommentAuthorsPart 对象。

    CommentAuthorsPart authorsPart;

    // 验证是否存在已存在的注释作者部分。

    if (doc.PresentationPart.CommentAuthorsPart == null)

    {

        // 如果没有，则添加一个新的。

        authorsPart = doc.PresentationPart.AddNewPart<CommentAuthorsPart>();

    }

    else

    {

        authorsPart = doc.PresentationPart.CommentAuthorsPart;

    }

    // 验证评论作者部分中是否有评论作者列表。

    if (authorsPart.CommentAuthorList == null)

    {

        // 如果没有，则添加一个新的。

        authorsPart.CommentAuthorList = new CommentAuthorList();

    }

    // 声明一个新的作者 ID。

    uint authorId = 0;

    CommentAuthor author = null;

    // 如果评论作者列表中存在现有子元素...

    if (authorsPart.CommentAuthorList.HasChildren)

    {

        // 验证传入的作者是否在列表中。

        var authors = authorsPart.CommentAuthorList.Elements<CommentAuthor>().Where(a => a.Name == name && a.Initials == initials);

        // 如果是...

        if (authors.Any())

        {

            // 将新评论作者分配给现有作者 ID。

            author = authors.First();

            authorId = author.Id;

        }

        // 如果不是...

        if (author == null)

        {

            // 给传入的作者分配一个新的 ID

            authorId = authorsPart.CommentAuthorList.Elements<CommentAuthor>().Select(a => a.Id.Value).Max();

        }

    }

    // 如果评论作者列表中没有现有子元素。

    if (author == null)

    {

        authorId++;

        // 向评论作者列表添加一个新子元素（评论作者）。

        author = authorsPart.CommentAuthorList.AppendChild<CommentAuthor>

        (new CommentAuthor()

        {

            Id = authorId,

            Name = name,

            Initials = initials,

            ColorIndex = 0

        });

    }

    // 使用 GetFirstSlide 方法获取第一张幻灯片。

    SlidePart slidePart1 = GetFirstSlide(doc);

    // 声明一个评论部分。

    SlideCommentsPart commentsPart;

    // 验证第一张幻灯片部分中是否有评论部分。

    if (slidePart1.GetPartsOfType<SlideCommentsPart>().Count() == 0)

    {

        // 如果没有，则添加一个新的评论部分。

        commentsPart = slidePart1.AddNewPart<SlideCommentsPart>();

    }

    else

    {

        // 否则，使用幻灯片部分中的第一评论部分。

        commentsPart = slidePart1.GetPartsOfType<SlideCommentsPart>().First();

    }

    // 如果评论列表不存在。

    if (commentsPart.CommentList == null)

    {

        // 添加一个新的评论列表。

        commentsPart.CommentList = new CommentList();

    }

    // 获取新的评论 ID。

    uint commentIdx = author.LastIndex == null ? 1 : author.LastIndex + 1;

    author.LastIndex = commentIdx;

    // 添加一个新评论。

    Comment comment = commentsPart.CommentList.AppendChild<Comment>(

    new Comment()

    {

        AuthorId = authorId,

        Index = commentIdx,

        DateTime = DateTime.Now

    });

    // 将位置子节点添加到评论元素。

    comment.Append(

    new Position() { X = 100, Y = 200 },

    new Text() { Text = text });

    // 保存评论作者部分。

    authorsPart.CommentAuthorList.Save();

    // 保存评论部分。

    commentsPart.CommentList.Save();

}

}

// 获取演示文稿文档中第一张幻灯片的幻灯片部分。

private static SlidePart GetFirstSlide(PresentationDocument presentationDocument)

{

// 获取第一张幻灯片的关系 ID

PresentationPart part = presentationDocument.PresentationPart;

SlideId slideId = part.Presentation.SlideIdList.GetFirstChild<SlideId>();

string relId = slideId.RelationshipId;

// 通过关系 ID 获取幻灯片部分。

SlidePart slidePart = (SlidePart)part.GetPartById(relId);

return slidePart;

}


``` 
## **Aspose.Slides**
在 **Aspose.Slides** for .NET 中，PPT 幻灯片注释集合包含在每个 **Slide** 类中。**CommentCollection** 类用于保存特定幻灯片的注释。**Comment** 类包含信息，如添加幻灯片注释的作者，他的首字母，创建时间，幻灯片上注释的位置和注释文本。**CommentAuthor** 类用于在演示文稿级别为幻灯片注释添加作者。**Presentation** 类在 **CommentAuthors** 类中保存演示文稿的作者集合。

在下面的示例中，我们添加了用于添加幻灯片注释的代码片段。

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "在幻灯片上添加注释.pptx";

using (Presentation pres = new Presentation())

{

    // 添加空幻灯片

    pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

    // 添加作者

    ICommentAuthor author = pres.CommentAuthors.AddAuthor("Zeeshan", "MZ");

    // 注释的位置

    PointF point = new PointF();

    point.X = 1;

    point.Y = 1;

    // 在幻灯片上为作者添加幻灯片注释

    author.Comments.AddComment("你好Zeeshan，这是幻灯片注释", pres.Slides[0], point, DateTime.Now);

    pres.Save(FileName, Aspose.Slides.Export.SaveFormat.Pptx);

}

``` 
## **下载示例代码**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://master.dl.sourceforge.net/project/asposeopenxml/Aspose.Slides%20Vs%20OpenXML/Add%20a%20comment%20to%20a%20slide%20%28Aspose.Slides%29.zip?viasf=1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Add%20a%20comment%20to%20a%20slide%20\(Aspose.Slides\).zip)