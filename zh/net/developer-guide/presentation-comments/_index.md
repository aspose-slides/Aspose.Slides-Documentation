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
- 删除批注
- 删除批注
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 管理演示文稿批注：快速轻松地在 PowerPoint 演示文稿中添加、读取、编辑、回复和删除批注。"
---
## **概述**

本文介绍如何使用 Aspose.Slides for .NET 管理演示文稿中的批注。它介绍了主要的批注相关类型，并演示了如何向幻灯片添加批注、访问现有批注、处理回复和现代批注以及从演示文稿中删除批注。

示例涵盖了 PowerPoint 中常见的审阅和协作场景，例如将批注分配给作者、读取批注文本和元数据、构建回复链，以及删除选定的批注或全部批注。

在 PowerPoint 中，批注显示为幻灯片上的注释。选中批注后会显示其文本和相关讨论。

## **为何向演示文稿添加批注？**

在审阅演示文稿时，您可以使用批注提供反馈并与同事协作。

Aspose.Slides for .NET 提供以下用于操作批注的 API：

* [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation) 类，提供对演示文稿批注作者的访问。
* [ICommentCollection](https://reference.aspose.com/slides/zh/net/aspose.slides/icommentcollection) 接口，表示与单个作者关联的批注集合。
* [IComment](https://reference.aspose.com/slides/zh/net/aspose.slides/icomment) 接口，提供批注的信息，包括作者、创建时间、位置和文本。
* [CommentAuthor](https://reference.aspose.com/slides/zh/net/aspose.slides/commentauthor) 类，提供作者的信息，包括名称、缩写和关联的批注。

## **添加幻灯片批注**
以下示例展示了如何在 PowerPoint 演示文稿的幻灯片中添加批注：

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

## **访问幻灯片批注**
以下示例展示了如何访问 PowerPoint 演示文稿中已有的批注：

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
父批注是回复层级顶部的原始批注。[IComment](https://reference.aspose.com/slides/zh/net/aspose.slides/icomment) 接口的 [ParentComment](https://reference.aspose.com/slides/zh/net/aspose.slides/icomment/properties/parentcomment) 属性允许获取或设置批注的父批注。

以下示例展示了如何添加回复并检查生成的批注层级结构：

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var position = new PointF(10, 10);
var createdTime = DateTime.Now;

var author1 = presentation.CommentAuthors.AddAuthor("Author_1", "A.A.");
var comment1 = author1.Comments.AddComment("comment 1", slide, position, createdTime);

var author2 = presentation.CommentAuthors.AddAuthor("Author_2", "B.B.");
var reply1 = author2.Comments.AddComment("reply 1 for comment 1", slide, position, createdTime);
reply1.ParentComment = comment1;

var reply2 = author2.Comments.AddComment("reply 2 for comment 1", slide, position, createdTime);
reply2.ParentComment = comment1;

var subReply = author1.Comments.AddComment("subreply 3 for reply 2", slide, position, createdTime);
subReply.ParentComment = reply2;

author2.Comments.AddComment("comment 2", slide, position, createdTime);
var comment3 = author2.Comments.AddComment("comment 3", slide, position, createdTime);

var reply3 = author1.Comments.AddComment("reply 4 for comment 3", slide, position, createdTime);
reply3.ParentComment = comment3;

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

comment1.Remove();
presentation.Save("remove_comment.pptx", SaveFormat.Pptx);
```

{{% alert color="warning" title="Attention" %}} 
* 当使用 [IComment](https://reference.aspose.com/slides/zh/net/aspose.slides/icomment) 接口的 [Remove](https://reference.aspose.com/slides/zh/net/aspose.slides/icomment/methods/remove) 方法删除批注时，该批注的所有回复也会被删除。
* 如果 [ParentComment](https://reference.aspose.com/slides/zh/net/aspose.slides/icomment/properties/parentcomment) 属性产生循环引用，则会抛出 [PptxEditException](https://reference.aspose.com/slides/zh/net/aspose.slides/pptxeditexception)。
{{% /alert %}}

## **添加现代批注**

现代批注可以关联到幻灯片本身、特定形状或 AutoShape 中的文本范围。[ICommentCollection.AddModernComment](https://reference.aspose.com/slides/zh/net/aspose.slides/icommentcollection/addmoderncomment/) 方法除了接受幻灯片和批注标记坐标外，还接受一个 [IShape](https://reference.aspose.com/slides/zh/net/aspose.slides/ishape/) 参数。

如果对形状参数传入 `null`，则该批注为幻灯片级批注。其标记位置由提供的坐标决定，但不关联到特定形状，因此 [IModernComment.Shape](https://reference.aspose.com/slides/zh/net/aspose.slides/imoderncomment/shape/) 返回 `null`。如果提供了 [IShape](https://reference.aspose.com/slides/zh/net/aspose.slides/ishape/)，批注将锚定到该形状。坐标仍然定义批注标记在幻灯片上的位置，而通过 [IModernComment.Shape](https://reference.aspose.com/slides/zh/net/aspose.slides/imoderncomment/shape/) 可以获取形状关联。

### **将现代批注锚定到形状**

以下示例创建了一个幻灯片级现代批注和一个锚定到特定 AutoShape 的现代批注。随后读取每个批注关联的形状。

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

任何实现了 [IShape](https://reference.aspose.com/slides/zh/net/aspose.slides/ishape/) 的幻灯片对象都可以用作形状锚点。常见示例包括 [IAutoShape](https://reference.aspose.com/slides/zh/net/aspose.slides/iautoshape/)、[IPictureFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/ipictureframe/)、[IGroupShape](https://reference.aspose.com/slides/zh/net/aspose.slides/igroupshape/)、[IConnector](https://reference.aspose.com/slides/zh/net/aspose.slides/iconnector/) 以及像图表这样的 [IGraphicalObject](https://reference.aspose.com/slides/zh/net/aspose.slides/igraphicalobject/) 实例。

以下示例创建了几种常见形状类型，并为每种形状关联了一个现代批注。

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

对于与 [IAutoShape](https://reference.aspose.com/slides/zh/net/aspose.slides/iautoshape/) 关联的现代批注，[IModernComment.TextSelectionStart](https://reference.aspose.com/slides/zh/net/aspose.slides/imoderncomment/textselectionstart/) 指定形状文本框中所选文本的起始位置，而 [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/zh/net/aspose.slides/imoderncomment/textselectionlength/) 指定选择的长度。这两个属性共同将批注关联到 AutoShape 中的特定文本范围。

[IModernComment.Status](https://reference.aspose.com/slides/zh/net/aspose.slides/imoderncomment/status/) 属性可读取或使用 [ModernCommentStatus](https://reference.aspose.com/slides/zh/net/aspose.slides/moderncommentstatus/) 枚举的值进行更新：

- `NotDefined` — 未定义特定的现代批注状态。
- `Active` — 批注处于活动状态。
- `Resolved` — 批注已解决。
- `Closed` — 批注已关闭。

以下示例创建了一个锚定到形状的现代批注，将其关联到文本选择，标记为已解决，保存演示文稿，并在重新打开文件后验证这些值。

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

要检查现有的演示文稿，首先确定哪些批注实现了 [IModernComment](https://reference.aspose.com/slides/zh/net/aspose.slides/imoderncomment/)，然后检查 [IModernComment.Shape](https://reference.aspose.com/slides/zh/net/aspose.slides/imoderncomment/shape/)、[IModernComment.TextSelectionStart](https://reference.aspose.com/slides/zh/net/aspose.slides/imoderncomment/textselectionstart/)、[IModernComment.TextSelectionLength](https://reference.aspose.com/slides/zh/net/aspose.slides/imoderncomment/textselectionlength/) 和 [IModernComment.Status](https://reference.aspose.com/slides/zh/net/aspose.slides/imoderncomment/status/)。`null` 形状表示幻灯片级批注。对于 [IAutoShape](https://reference.aspose.com/slides/zh/net/aspose.slides/iautoshape/) 锚点，文本选择属性指示形状文本框中的相应范围。

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

### **删除所有批注和批注作者**

以下示例展示了如何从演示文稿中删除所有批注和批注作者：

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

以下示例展示了如何从幻灯片中删除特定批注：

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

## **FAQ**

**Aspose.Slides 是否支持现代批注的已解决状态？**

是的。可以读取和设置 [IModernComment.Status](https://reference.aspose.com/slides/zh/net/aspose.slides/imoderncomment/status/) 为 [ModernCommentStatus](https://reference.aspose.com/slides/zh/net/aspose.slides/moderncommentstatus/) 值，包括 `Resolved`。该状态保存在演示文稿中，文件重新打开后仍可读取。

**是否支持线程式讨论（回复链），以及是否有嵌套深度限制？**

是的。每个批注都可以引用其 [parent comment](https://reference.aspose.com/slides/zh/net/aspose.slides/comment/parentcomment/)，从而实现回复链。API 未定义具体的嵌套深度限制。

**批注标记在幻灯片上的位置采用何种坐标系定义？**

标记位置使用幻灯片坐标系中的浮点坐标定义，您可以在幻灯片上精确定位。