---
title: 在 .NET 中管理簡報註解
linktitle: 簡報註解
type: docs
weight: 100
url: /zh-hant/net/presentation-comments/
keywords:
- 註解
- 現代註解
- PowerPoint 註解
- 簡報註解
- 投影片註解
- 新增註解
- 存取註解
- 編輯註解
- 回覆註解
- 移除註解
- 刪除註解
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 管理簡報註解：在 PowerPoint 簡報中快速且輕鬆地新增、閱讀、編輯、回覆及移除註解。"
---
## **概述**

本文說明如何使用 Aspose.Slides for .NET 管理簡報註解。它介紹了主要的註解相關類型，並示範如何將註解加入投影片、存取現有註解、處理回覆與現代註解，以及如何從簡報中移除註解。

這些範例涵蓋了 PowerPoint 中常見的審閱與協作情境，例如指派作者、讀取註解文字與中繼資料、建立回覆鏈，與移除選取的註解或全部註解。

在 PowerPoint 中，註解會以標註的形式顯示在投影片上。選取註解即可顯示其文字與相關討論。

## **為何要在簡報中加入註解？**

在審閱簡報時，可使用註解提供回饋並與同事協作。

Aspose.Slides for .NET 提供以下 API 讓您操作註解：

* [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別，可存取簡報的註解作者。
* [ICommentCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/icommentcollection) 介面，表示單一作者所屬的註解集合。
* [IComment](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/icomment) 介面，提供註解的資訊，包括作者、建立時間、位置與文字。
* [CommentAuthor](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/commentauthor) 類別，提供作者資訊，包括姓名、縮寫與相關註解。

## **新增投影片註解**
以下範例說明如何在 PowerPoint 簡報的投影片中新增註解：

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

## **存取投影片註解**
以下範例說明如何存取 PowerPoint 簡報中已有的註解：

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

## **回覆註解**
父註解是回覆層級最上方的原始註解。[IComment](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/icomment) 介面的 [ParentComment](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/icomment/properties/parentcomment) 屬性可取得或設定註解的父項。

以下範例示範如何新增回覆並檢查產生的註解層級結構：

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

{{% alert color="warning" title="注意" %}} 

* 當使用 [IComment](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/icomment) 介面的 [Remove](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/icomment/methods/remove) 方法刪除註解時，該註解的所有回覆也會一起被刪除。
* 若 [ParentComment](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/icomment/properties/parentcomment) 屬性形成循環參照，將拋出 [PptxEditException](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/pptxeditexception)。

{{% /alert %}}

## **新增現代註解**

現代註解可以關聯至整張投影片、特定圖形，或 AutoShape 內的文字範圍。 [ICommentCollection.AddModernComment](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/icommentcollection/addmoderncomment/) 方法接受一個 [IShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/) 參數，此外還需要投影片與註解標記的座標。

當 shape 參數傳入 `null` 時，註解為投影片層級註解。其標記位置由提供的座標決定，但不會關聯到特定圖形，因而 [IModernComment.Shape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imoderncomment/shape/) 會回傳 `null`。若提供 [IShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/)，註解則會錨定於該圖形。座標仍然定義標記在投影片上的位置，而圖形關聯可透過 [IModernComment.Shape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imoderncomment/shape/) 取得。

### **將現代註解錨定至圖形**

以下範例同時建立投影片層級的現代註解與錨定於特定 AutoShape 的現代註解，並讀取每個註解所關聯的圖形。

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

### **將註解錨定至不同類型的圖形**

任何實作了 [IShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/) 的投影片物件都可作為圖形錨點。常見的範例包括 [IAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/)、[IPictureFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipictureframe/)、[IGroupShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/igroupshape/)、[IConnector](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iconnector/)，以及如圖表等 [IGraphicalObject](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/igraphicalobject/) 實例。

以下範例建立多種常見圖形類型，並為每個圖形關聯一個現代註解。

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

### **將註解錨定至文字並設定其狀態**

對於關聯至 [IAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/) 的現代註解，[IModernComment.TextSelectionStart](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imoderncomment/textselectionstart/) 指定形狀文字框中所選文字的起始位置，而 [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imoderncomment/textselectionlength/) 指定選取的長度。兩者共同將註解與 AutoShape 內的特定文字範圍關聯。

[IModernComment.Status](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imoderncomment/status/) 屬性可讀取或以 [ModernCommentStatus](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/moderncommentstatus/) 列舉值進行設定：

- `NotDefined` — 未定義特定的現代註解狀態。
- `Active` — 註解為活躍狀態。
- `Resolved` — 註解已解決。
- `Closed` — 註解已關閉。

以下範例建立一個錨定於圖形的現代註解，將其與文字選取關聯，標記為已解決，儲存簡報，並在重新開啟檔案後驗證其值。

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

### **檢查現有的現代註解**

若要檢查現有簡報，先找出哪些註解實作了 [IModernComment](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imoderncomment/)，再檢查其 [IModernComment.Shape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imoderncomment/shape/)、[IModernComment.TextSelectionStart](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imoderncomment/textselectionstart/)、[IModernComment.TextSelectionLength](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imoderncomment/textselectionlength/) 與 [IModernComment.Status](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imoderncomment/status/)。`null` 的 shape 代表投影片層級註解。若為 [IAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/) 錨點，文字選取屬性則指出該圖形文字框中的相關範圍。

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

## **移除註解**

### **移除全部註解與註解作者**

以下範例示範如何從簡報中移除所有註解與註解作者：

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

### **移除特定註解**

以下範例示範如何從投影片中移除特定註解：

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

## **常見問題**

**Aspose.Slides 是否支援現代註解的已解決狀態？**

是的。[IModernComment.Status](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imoderncomment/status/) 可讀寫 [ModernCommentStatus](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/moderncommentstatus/) 值，其中包含 `Resolved`。此狀態會儲存在簡報中，重新開啟檔案後仍可讀取。

**是否支援串接討論（回覆鏈），且有巢狀深度限制嗎？**

支援。每個註解均可參照其 [parent comment](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/comment/parentcomment/)，形成回覆鏈。API 未定義具體的巢狀深度上限。

**註解標記在投影片上的位置使用哪種座標系統？**

標記位置是以浮點座標表示，基於投影片的座標系統，您可以精確地將其放置於投影片上。