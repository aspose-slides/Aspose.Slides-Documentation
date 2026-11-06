---
title: 在 .NET 中管理演示文稿批注
linktitle: 演示文稿批注
type: docs
weight: 100
url: /zh/net/presentation-comments/
keywords:
- 批注
- 现代批注
- PowerPoint 批注
- 演示文稿批注
- 幻灯片批注
- 添加批注
- 访问批注
- 编辑批注
- 回复批注
- 移除批注
- 删除批注
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 管理演示文稿批注：在 PowerPoint 演示文稿中快速轻松地添加、读取、编辑、回复和移除批注。"
---
## **概述**

本文档说明了如何使用 Aspose.Slides for .NET 管理演示文稿批注。它介绍了主要的批注相关类型，并演示了如何向幻灯片添加批注、访问现有批注、处理回复和现代批注，以及如何从演示文稿中删除批注。

示例涵盖了 PowerPoint 中常见的审阅和协作场景，例如为作者分配批注、读取批注文本和元数据、构建回复链，以及删除选定批注或全部批注。

在 PowerPoint 中，批注显示为幻灯片上的标注。选中批注后会显示其文本和相关讨论。

若要在打开演示文稿时请求显示或隐藏批注（而不更改批注本身），请参阅 [打开演示文稿时显示或隐藏批注](/slides/zh/net/presentation-view-properties/)。

## **为什么要向演示文稿添加批注？**

在审阅演示文稿时，您可以使用批注提供反馈并与同事协作。

Aspose.Slides for .NET 提供了以下用于操作批注的 API：

* [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类，可访问演示文稿的批注作者。
* [ICommentCollection](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection) 接口，表示与单个作者关联的批注集合。
* [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) 接口，提供有关批注的信息，包括作者、创建时间、位置和文本。
* [CommentAuthor](https://reference.aspose.com/slides/net/aspose.slides/commentauthor) 类，提供有关作者的信息，包括姓名、缩写和关联的批注。

## **添加幻灯片批注**

示例创建两个幻灯片，并使用 [AddAuthor](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/addauthor/) 注册批注作者。它使用 [AddComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addcomment/) 在每个幻灯片上放置一个批注，然后使用 [GetSlideComments](https://reference.aspose.com/slides/net/aspose.slides/islide/getslidecomments/) 获取该作者在第一张幻灯片上的批注。控制台两次显示第一条批注的文本，演示了通过幻灯片和作者两种方式访问批注，且保存的演示文稿包含这两个批注。

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var firstSlide = presentation.Slides[0];
var secondSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

var author = presentation.CommentAuthors.AddAuthor("Jawad", "MF");
var position = new PointF(0.2f, 0.2f);
var createdTime = DateTime.Now;

author.Comments.AddComment("Hello Jawad, this is a slide comment", firstSlide, position, createdTime);
author.Comments.AddComment("Hello Jawad, this is the second slide comment", secondSlide, position, createdTime);

var comments = firstSlide.GetSlideComments(author);
if (comments.Length > 0)
{
    var firstComment = comments[0];
    Console.WriteLine(firstComment.Text);

    var commentText = firstComment.Author.Comments[0].Text;
    Console.WriteLine(commentText);
}

presentation.Save("Comments_out.pptx", SaveFormat.Pptx);
```

## **查找或创建批注作者**

在自动审阅重复处理同一演示文稿时，应在添加作者之前先搜索其 [CommentAuthors](https://reference.aspose.com/slides/net/aspose.slides/presentation/commentauthors/) 集合。[FindByNameAndInitials](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/findbynameandinitials/) 同时匹配名称和缩写并返回匹配作者的数组，若无匹配则返回空数组。相反，[FindByName](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/findbyname/) 仅按名称搜索，忽略缩写。使用已存在的名称和缩写调用 [AddAuthor](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/addauthor/) 会抛出异常。

示例需要一个至少包含一张幻灯片的演示文稿文件。在两次遍历中，它复用第一个匹配的作者，或仅在结果为空时创建新作者。如果有多个匹配，则选择数组的第一个元素，而不合并或删除其他作者。随后为选定的作者调用 [AddComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addcomment/) 并保存演示文稿。第二次遍历打开第一次的输出并重复此操作。

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const string authorName = "Reviewer";
const string authorInitials = "RV";

var inputFile = "input.pptx";
var position = new PointF(20, 20);

for (var pass = 1; pass <= 2; pass++)
{
    using var presentation = new Presentation(inputFile);

    var matches = presentation.CommentAuthors.FindByNameAndInitials(authorName, authorInitials);
    
    var author = matches.Length > 0 ? matches[0] : presentation.CommentAuthors.AddAuthor(authorName, authorInitials);
    author.Comments.AddComment("Please review this slide.", presentation.Slides[0], position, DateTime.Now);

    var outputFile = $"review_pass_{pass}.pptx";
    presentation.Save(outputFile, SaveFormat.Pptx);
    inputFile = outputFile;
}
```

第二次遍历在不添加新作者或删除现有批注的情况下添加了另一条批注。最终文件 `review_pass_2.pptx` 包含这两条新批注以及任何原始批注。复用作者不会去重批注：若要避免重复添加相同批注，需要在添加之前实现单独的重复检测。

## **访问幻灯片批注**

示例打开现有演示文稿并读取其 [CommentAuthors](https://reference.aspose.com/slides/net/aspose.slides/presentation/commentauthors/) 集合。对每个作者，遍历其 [Comments](https://reference.aspose.com/slides/net/aspose.slides/icommentauthor/comments/) 并打印幻灯片编号、批注文本、作者名称和创建时间。输入的演示文稿必须包含批注才能产生控制台输出。

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("Comments1.pptx");

foreach (var author in presentation.CommentAuthors)
{
    foreach (var comment in author.Comments)
    {
        Console.WriteLine($"Slide: {comment.Slide.SlideNumber}");
        Console.WriteLine($"Comment: {comment.Text}");
        Console.WriteLine($"Author: {comment.Author.Name}");
        Console.WriteLine($"Posted at: {comment.CreatedTime}");
        Console.WriteLine();
    }
}
```

## **回复批注**

父批注是回复层级顶部的原始批注。 [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) 接口的 [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/parentcomment/) 属性允许获取或设置批注的父级。

示例创建两个作者的批注，并使用 [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/parentcomment/) 构建回复，包括对另一个回复的回复。向 [GetSlideComments](https://reference.aspose.com/slides/net/aspose.slides/islide/getslidecomments/) 传递 `null` 可检索所有作者的批注；控制台根据回复层级的深度对每条条目进行缩进。示例保存完整的讨论，对第一个根批注调用 [Remove](https://reference.aspose.com/slides/net/aspose.slides/icomment/remove/)，并保存第二个演示文稿，已删除该批注及其所有回复。

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var position = new PointF(10, 10);
var createdTime = DateTime.Now;

var originalAuthor = presentation.CommentAuthors.AddAuthor("Author_1", "A.A.");
var rootComment = originalAuthor.Comments.AddComment("comment 1", slide, position, createdTime);

var reviewer = presentation.CommentAuthors.AddAuthor("Author_2", "B.B.");
var firstReply = reviewer.Comments.AddComment("reply 1 for comment 1", slide, position, createdTime);
firstReply.ParentComment = rootComment;

var secondReply = reviewer.Comments.AddComment("reply 2 for comment 1", slide, position, createdTime);
secondReply.ParentComment = rootComment;

var subReply = originalAuthor.Comments.AddComment("subreply 3 for reply 2", slide, position, createdTime);
subReply.ParentComment = secondReply;

reviewer.Comments.AddComment("comment 2", slide, position, createdTime);
var separateComment = reviewer.Comments.AddComment("comment 3", slide, position, createdTime);

var separateReply = originalAuthor.Comments.AddComment("reply 4 for comment 3", slide, position, createdTime);
separateReply.ParentComment = separateComment;

var comments = slide.GetSlideComments(null);
for (var i = 0; i < comments.Length; i++)
{
    var comment = comments[i];
    while (comment.ParentComment != null)
    {
        Console.Write("\t");
        comment = comment.ParentComment;
    }

    Console.WriteLine($"{comments[i].Author.Name}: {comments[i].Text}");
}

presentation.Save("parent_comment.pptx", SaveFormat.Pptx);

rootComment.Remove();
presentation.Save("remove_comment.pptx", SaveFormat.Pptx);
```

{{% alert color="warning" title="Warning" %}}

* 当使用 [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) 接口的 [Remove](https://reference.aspose.com/slides/net/aspose.slides/icomment/remove/) 方法删除批注时，该批注的所有回复也会被删除。
* 如果 [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/parentcomment/) 属性导致循环引用，将抛出 [PptxEditException](https://reference.aspose.com/slides/net/aspose.slides/pptxeditexception)。

{{% /alert %}}

## **添加现代批注**

现代批注可以关联到幻灯片本身、特定形状或 AutoShape 中的文本范围。 [ICommentCollection.AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addmoderncomment/) 方法除了接受幻灯片和批注标记坐标外，还接受一个 [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) 参数。

当形状参数为 `null` 时，批注为幻灯片级批注。其标记由提供的坐标定位，但不关联到特定形状，因此 [IModernComment.Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/) 返回 `null`。当提供了 [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) 时，批注锚定到该形状。坐标仍定义批注标记在幻灯片上的位置，而形状关联可通过 [IModernComment.Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/) 获取。

### **将现代批注锚定到形状**

示例分别使用 `null` 形状（幻灯片级批注）和矩形形状（锚定批注）两次调用 [AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addmoderncomment/)。读取 [Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/) 时，对幻灯片级批注的空检查输出 `True`，对锚定批注输出 “Revenue title”。两个批注均随演示文稿一起保存。

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var author = presentation.CommentAuthors.AddAuthor("Reviewer", "RV");

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 300, 80);
shape.Name = "Revenue title";
shape.TextFrame.Text = "Quarterly revenue";

var createdTime = DateTime.Now;
var slideCommentPosition = new PointF(20, 20);
var shapeCommentPosition = new PointF(60, 60);
var slideComment = author.Comments.AddModernComment("Review the overall slide layout.", slide, null, slideCommentPosition, createdTime);
var shapeComment = author.Comments.AddModernComment("Check this title.", slide, shape, shapeCommentPosition, createdTime);

Console.WriteLine(slideComment.Shape == null);
Console.WriteLine(shapeComment.Shape?.Name);

presentation.Save("modern_comments.pptx", SaveFormat.Pptx);
```

### **将批注锚定到不同的形状类型**

实现了 [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) 的任意幻灯片对象都可用作形状锚点。常见示例包括 [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/)、[IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/)、[IGroupShape](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/)、[IConnector](https://reference.aspose.com/slides/net/aspose.slides/iconnector/) 和 [IGraphicalObject](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobject/)（如图表）实例。

示例使用 [AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addmoderncomment/) 为五种形状类型（AutoShape、图片框、组合、连接线和图表）各关联一个批注。图片使用嵌入的图像数据，无需外部图像。每个批注都有自己的标记位置，保存的演示文稿保留了所有五种形状的关联。

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var author = presentation.CommentAuthors.AddAuthor("Reviewer", "RV");
var createdTime = DateTime.Now;

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 180, 60);
autoShape.TextFrame.Text = "AutoShape";

var autoShapeCommentPosition = new PointF(30, 30);
author.Comments.AddModernComment("Comment on an AutoShape.", slide, autoShape, autoShapeCommentPosition, createdTime);

var imageBase64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg==";
var imageData = Convert.FromBase64String(imageBase64);
var image = presentation.Images.AddImage(imageData);
var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 220, 20, 120, 80, image);
var pictureCommentPosition = new PointF(230, 30);
author.Comments.AddModernComment("Comment on a picture.", slide, pictureFrame, pictureCommentPosition, createdTime);

var groupShape = slide.Shapes.AddGroupShape();
groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 80, 40);
groupShape.Shapes.AddAutoShape(ShapeType.Ellipse, 100, 0, 80, 40);
var groupCommentPosition = new PointF(40, 150);
author.Comments.AddModernComment("Comment on a group.", slide, groupShape, groupCommentPosition, createdTime);

var connector = slide.Shapes.AddConnector(ShapeType.StraightConnector1, 220, 150, 140, 40);
var connectorCommentPosition = new PointF(240, 150);
author.Comments.AddModernComment("Comment on a connector.", slide, connector, connectorCommentPosition, createdTime);

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 400, 20, 250, 180);
var chartCommentPosition = new PointF(420, 40);
author.Comments.AddModernComment("Comment on a graphical object.", slide, chart, chartCommentPosition, createdTime);

presentation.Save("modern_comment_shape_types.pptx", SaveFormat.Pptx);
```

### **将批注锚定到文本并设置其状态**

对于与 [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) 关联的现代批注，[IModernComment.TextSelectionStart](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionstart/) 指定形状文本框中所选文本的起始位置，[IModernComment.TextSelectionLength](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionlength/) 指定选区的长度。这两个属性共同将批注关联到 AutoShape 文本中的特定范围。

[IModernComment.Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/) 属性可以读取或使用 [ModernCommentStatus](https://reference.aspose.com/slides/net/aspose.slides/moderncommentstatus/) 枚举的值进行更新：

- `NotDefined` — 未定义特定的现代批注状态。
- `Active` — 批注处于活动状态。
- `Resolved` — 批注已解决。
- `Closed` — 批注已关闭。

示例将现代批注锚定到矩形文本中的 “quarterly revenue” 这几个词。它根据文本计算零基的 [TextSelectionStart](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionstart/)，并将 [TextSelectionLength](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionlength/) 设置为所选字符数。随后将 [Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/) 设置为 `Resolved`，保存并重新打开演示文稿。四个控制台检查应均输出 `True`，确认形状锚点、文本范围和状态均已保留。

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const string outputFile = "modern_comment_text_anchor.pptx";
const string shapeText = "Review the quarterly revenue forecast.";
const string selectedText = "quarterly revenue";
var expectedSelectionStart = shapeText.IndexOf(selectedText, StringComparison.Ordinal);

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.Name = "Forecast text";
shape.TextFrame.Text = shapeText;

var author = presentation.CommentAuthors.AddAuthor("Reviewer", "RV");
var commentPosition = new PointF(60, 60);
var comment = author.Comments.AddModernComment("Verify this forecast wording.", slide, shape, commentPosition, DateTime.Now);
comment.TextSelectionStart = expectedSelectionStart;
comment.TextSelectionLength = selectedText.Length;
comment.Status = ModernCommentStatus.Resolved;

presentation.Save(outputFile, SaveFormat.Pptx);

using var reopenedPresentation = new Presentation(outputFile);
var reopenedSlide = reopenedPresentation.Slides[0];
var reopenedComments = reopenedSlide.GetSlideComments(null);

foreach (var reopenedComment in reopenedComments)
{
    if (reopenedComment is not IModernComment modernComment)
    {
        continue;
    }

    var shapeMatches = modernComment.Shape?.Name == "Forecast text";
    var selectionStartMatches = modernComment.TextSelectionStart == expectedSelectionStart;
    var selectionLengthMatches = modernComment.TextSelectionLength == selectedText.Length;
    var statusMatches = modernComment.Status == ModernCommentStatus.Resolved;

    Console.WriteLine($"Shape anchor preserved: {shapeMatches}");
    Console.WriteLine($"Text selection start preserved: {selectionStartMatches}");
    Console.WriteLine($"Text selection length preserved: {selectionLengthMatches}");
    Console.WriteLine($"Resolved status preserved: {statusMatches}");
}
```

### **检查现有的现代批注**

示例需要一个包含现代批注的现有演示文稿，并打印其文本、状态和锚点细节。检查方式是：先找出实现了 [IModernComment](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/) 的批注，然后检查其 [Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/)、[TextSelectionStart](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionstart/)、[TextSelectionLength](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionlength/) 和 [Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/)。`null` 形状表示幻灯片级批注。对于 [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) 锚点，文本选择属性指示在形状文本框中的关联范围。

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("comments.pptx");

foreach (var slide in presentation.Slides)
{
    var comments = slide.GetSlideComments(null);
    foreach (var comment in comments)
    {
        if (comment is not IModernComment modernComment)
        {
            continue;
        }

        Console.WriteLine($"Slide: {slide.SlideNumber}");
        Console.WriteLine($"Text: {modernComment.Text}");
        Console.WriteLine($"Status: {modernComment.Status}");

        var shape = modernComment.Shape;
        if (shape == null)
        {
            Console.WriteLine("Anchor: slide level");
        }
        else
        {
            Console.WriteLine($"Anchor shape: {shape.Name}");
            Console.WriteLine($"Anchor type: {shape.GetType().Name}");

            if (shape is IAutoShape)
            {
                Console.WriteLine($"Text selection start: {modernComment.TextSelectionStart}");
                Console.WriteLine($"Text selection length: {modernComment.TextSelectionLength}");
            }
        }

        Console.WriteLine();
    }
}
```

## **删除批注**

Aspose.Slides for .NET 允许您删除演示文稿中的所有批注及其作者，或在保留其余内容的情况下仅删除选定批注。以下示例演示了这两种方法并保存更新后的演示文稿。

### **删除所有批注和批注作者**

示例打开现有演示文稿，对每个作者调用 [ICommentCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/clear/)，随后调用 [ICommentAuthorCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/clear/) 删除作者本身。保存的演示文稿既不包含批注，也不包含批注作者。请使用包含批注的演示文稿以观察删除效果。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("example.pptx");

foreach (var author in presentation.CommentAuthors)
{
    author.Comments.Clear();
}

presentation.CommentAuthors.Clear();

presentation.Save("example_out.pptx", SaveFormat.Pptx);
```

### **删除特定批注**

示例在同一幻灯片上创建两个批注，并使用 [GetSlideComments](https://reference.aspose.com/slides/net/aspose.slides/islide/getslidecomments/) 按作者查找批注。它收集文本等于 “comment 1” 的批注，然后调用 [ICommentCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/remove/) 删除这些批注，避免在选择期间修改集合。保存的演示文稿仅保留 “comment 2”。

```csharp
using System;
using System.Collections.Generic;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var author = presentation.CommentAuthors.AddAuthor("Author", "A");
var createdTime = DateTime.Now;

var firstCommentPosition = new PointF(0.2f, 0.2f);
var secondCommentPosition = new PointF(0.3f, 0.2f);
author.Comments.AddComment("comment 1", slide, firstCommentPosition, createdTime);
author.Comments.AddComment("comment 2", slide, secondCommentPosition, createdTime);

foreach (var commentAuthor in presentation.CommentAuthors)
{
    var commentsToRemove = new List<IComment>();
    var comments = slide.GetSlideComments(commentAuthor);

    foreach (var comment in comments)
    {
        if (comment.Text == "comment 1")
        {
            commentsToRemove.Add(comment);
        }
    }

    foreach (var comment in commentsToRemove)
    {
        commentAuthor.Comments.Remove(comment);
    }
}

presentation.Save("pres.pptx", SaveFormat.Pptx);
```

## **常见问答**

**Aspose.Slides 是否支持现代批注的已解决状态？**

是的。可以读取和设置 [IModernComment.Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/)，该属性接受 [ModernCommentStatus](https://reference.aspose.com/slides/net/aspose.slides/moderncommentstatus/) 枚举值，包括 `Resolved`。状态会保存到演示文稿中，重新打开文件后仍可读取。

**是否支持线程式讨论（回复链），并且有嵌套层级限制吗？**

是的。每个批注都可以引用其 [parent comment](https://reference.aspose.com/slides/net/aspose.slides/comment/parentcomment/)，从而形成回复链。API 并未定义具体的嵌套深度限制。

**批注标记在幻灯片上的位置使用什么坐标系定义？**

标记位置使用幻灯片坐标系中的浮点坐标，可精确地将其放置在幻灯片上的任意位置。