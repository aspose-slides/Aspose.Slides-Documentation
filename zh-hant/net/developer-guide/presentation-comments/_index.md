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
description: "使用 Aspose.Slides for .NET 管理簡報註解：在 PowerPoint 簡報中快速輕鬆地新增、閱讀、編輯、回覆及移除註解。"
---
## **概觀**

本文說明如何使用 Aspose.Slides for .NET 管理簡報註解。它介紹主要的註解相關類型，並示範如何向投影片新增註解、存取現有註解、處理回覆與現代註解，以及從簡報中移除註解。

這些範例涵蓋在 PowerPoint 中常見的審閱與協作情境，例如指派註解給作者、讀取註解文字與中繼資料、建立回覆鏈，以及移除選取的註解或全部註解。

在 PowerPoint 中，註解會以標註的形式出現在投影片上。選取註解時會顯示其文字與相關討論。

若希望在開啟簡報時顯示或隱藏註解（而不更改註解本身），請參閱[開啟簡報時顯示或隱藏註解](/slides/zh-hant/net/presentation-view-properties/)。

## **為何在簡報中新增註解？**

在審閱簡報時，您可以使用註解提供回饋並與同事協作。

Aspose.Slides for .NET 提供以下 API 以處理註解：

* The [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) class，提供取得簡報註解作者的功能。
* The [ICommentCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/icommentcollection) interface，代表與單一作者相關聯的註解。
* The [IComment](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/icomment) interface，提供關於註解的資訊，包括作者、建立時間、位置與文字。
* The [CommentAuthor](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/commentauthor) class，提供作者資訊，包括姓名、縮寫與相關註解。

## **新增投影片註解**
以下範例示範如何在 PowerPoint 簡報的投影片中新增註解：

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
以下範例示範如何存取 PowerPoint 簡報中現有的註解：

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
父註解是回覆階層最上層的原始註解。[ParentComment](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/icomment/properties/parentcomment) 屬性屬於 [IComment](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/icomment) 介面，可讓您取得或設定註解的父項。

以下範例示範如何新增回覆並檢查產生的註解階層：

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

* 當使用 [IComment] 介面的 [Remove](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/icomment/methods/remove) 方法刪除註解時，該註解的所有回覆亦會被刪除。
* 若 [ParentComment](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/icomment/properties/parentcomment) 屬性造成循環參考，則會拋出 [PptxEditException](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/pptxeditexception)。

{{% /alert %}}

## **新增現代註解**

現代註解可以與投影片本身、特定形狀，或 AutoShape 內的文字範圍相關聯。[ICommentCollection.AddModernComment](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/icommentcollection/addmoderncomment/) 方法除了接受投影片與註解標記座標外，還接受一個 [IShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/) 參數。

當 `null` 被傳入形狀參數時，註解為投影片層級的註解。其標記以提供的座標定位，但不會與特定形狀關聯，因此 [IModernComment.Shape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imoderncomment/shape/) 會回傳 `null`。當提供一個 [IShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/) 時，註解會錨定至該形狀。座標仍然定義註解標記在投影片上的位置，而形狀關聯可透過 [IModernComment.Shape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imoderncomment/shape/) 取得。

### **將現代註解錨定至形狀**

以下範例同時建立投影片層級的現代註解與錨定至特定 AutoShape 的現代註解，並從每個註解讀取關聯的形狀。

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

### **將註解錨定至不同形狀類型**

任何實作 [IShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/) 的投影片物件皆可作為形狀錨點。常見的範例包括 [IAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/)、[IPictureFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipictureframe/)、[IGroupShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/igroupshape/)、[IConnector](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iconnector/) 以及像圖表此類的 [IGraphicalObject](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/igraphicalobject/) 實例。

以下範例建立多種常見形狀類型，並為每個形狀關聯一個現代註解。

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

對於與 [IAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/) 相關聯的現代註解，[IModernComment.TextSelectionStart](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imoderncomment/textselectionstart/) 指定形狀文字框中選取文字的起始位置，而 [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imoderncomment/textselectionlength/) 指定選取的長度。這兩個屬性共同將註解與 AutoShape 內的特定文字範圍關聯起來。

[IModernComment.Status](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imoderncomment/status/) 屬性可讀取或使用 [ModernCommentStatus](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/moderncommentstatus/) 列舉的值進行設定：

- `NotDefined` — 未定義特定的現代註解狀態。
- `Active` — 註解為活動狀態。
- `Resolved` — 註解已被解決。
- `Closed` — 註解已關閉。

以下範例建立一個錨定至形狀的現代註解，將其與文字選取關聯，標示為已解決，儲存簡報，並在重新開啟檔案後驗證其值。

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

### **檢視現有的現代註解**

要檢查現有簡報，先確認哪些註解實作了 [IModernComment](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imoderncomment/)，然後檢查 [IModernComment.Shape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imoderncomment/shape/)、[IModernComment.TextSelectionStart](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imoderncomment/textselectionstart/)、[IModernComment.TextSelectionLength](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imoderncomment/textselectionlength/) 與 [IModernComment.Status](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imoderncomment/status/)。`null` 形狀表示投影片層級的註解。若以 [IAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/) 作為錨點，文字選取屬性會指示該形狀文字框中的相關範圍。

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

### **移除所有註解與註解作者**

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

## **常見問答**

**Aspose.Slides 是否支援現代註解的已解決狀態？**

是的。[IModernComment.Status](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imoderncomment/status/) 可讀取並設定為 [ModernCommentStatus](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/moderncommentstatus/) 列舉值，包括 `Resolved`。此狀態會儲存在簡報中，重新開啟檔案後仍可讀取。

**是否支援串接討論（回覆鏈），且有巢狀深度限制嗎？**

是的。每個註解都可以參照其 [parent comment](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/comment/parentcomment/)，從而形成回覆鏈。API 並未定義具體的巢狀深度限制。

**註解標記在投影片上的位置是以哪個座標系統定義的？**

標記位置以投影片座標系統中的浮點座標表示，讓您能精確地將其放置於投影片上。