---
title: 在 .NET 中管理簡報批註
linktitle: 簡報批註
type: docs
weight: 100
url: /zh-hant/net/presentation-comments/
keywords:
- 批註
- 現代批註
- PowerPoint 批註
- 簡報批註
- 投影片批註
- 新增批註
- 存取批註
- 編輯批註
- 回覆批註
- 移除批註
- 刪除批註
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 管理簡報批註：快速且輕鬆地在 PowerPoint 簡報中新增、閱讀、編輯、回覆與移除批註。"
---
## **概觀**

本文說明如何使用 Aspose.Slides for .NET 管理簡報批註。它介紹了與批註相關的主要型別，並示範如何在投影片上加入批註、存取現有批註、處理回覆與現代批註，以及如何從簡報中移除批註。

示例涵蓋了 PowerPoint 中常見的審閱與協作情境，例如指派批註作者、讀取批註文字與中繼資料、建立回覆鏈，以及移除選取的批註或全部批註。

在 PowerPoint 中，批註會以註解的形式顯示於投影片上。選取批註時會顯示其文字與相關討論。

若要在開啟簡報時請求顯示或隱藏批註（而不改變批註本身），請參考[在開啟簡報時顯示或隱藏批註](/slides/zh-hant/net/presentation-view-properties/)。

## **為何要在簡報中加入批註？**

您可以使用批註在審閱簡報時提供回饋並與同事協作。

Aspose.Slides for .NET 提供以下用於操作批註的 API：

* [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 類別，可存取簡報的批註作者。
* [ICommentCollection](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection) 介面，代表與單一作者相關的批註集合。
* [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) 介面，提供批註的資訊，包括作者、建立時間、位置與文字。
* [CommentAuthor](https://reference.aspose.com/slides/net/aspose.slides/commentauthor) 類別，提供作者的資訊，包括姓名、縮寫與相關批註。

## **新增投影片批註**

範例建立兩張投影片，並使用 [AddAuthor](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/addauthor/) 註冊一位批註作者。它使用 [AddComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addcomment/) 在每張投影片上放置一則批註，然後使用 [GetSlideComments](https://reference.aspose.com/slides/net/aspose.slides/islide/getslidecomments/) 取得該作者在第一張投影片的批註。主控台會兩次顯示第一則批註的文字，示範透過投影片與作者兩種方式存取，且儲存的簡報同時包含兩則批註。

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

## **尋找或建立批註作者**

當自動審閱程式多次處理同一簡報時，應先搜尋其 [CommentAuthors](https://reference.aspose.com/slides/net/aspose.slides/presentation/commentauthors/) 集合再新增作者。[FindByNameAndInitials](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/findbynameandinitials/) 同時比對名稱與縮寫，回傳符合的作者陣列，若無符合則回傳空陣列。相較之下，[FindByName](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/findbyname/) 只依名稱搜尋，與縮寫無關。以已存在的名稱與縮寫呼叫 [AddAuthor](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/addauthor/) 會拋出例外。

此範例需要一個至少包含一張投影片的簡報檔案。於兩次執行過程中，它會重複使用第一個符合的作者，或在結果為空時才建立新作者。若有多筆符合，會選取陣列的第一個元素，且不會合併或移除其他作者。接著為選取的作者呼叫 [AddComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addcomment/)，並儲存簡報。第二次執行會開啟第一次的輸出檔案並重複此操作。

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

第二次執行會新增另一則批註，但不會新增其他作者，也不會移除既有批註。最終檔案 `review_pass_2.pptx` 會同時包含兩個新批註以及任何原始批註。重複使用作者不會自動去除重複批註：若要避免重複新增相同批註，請在加入前自行實作重複偵測。

## **存取投影片批註**

此範例開啟現有簡報，讀取其 [CommentAuthors](https://reference.aspose.com/slides/net/aspose.slides/presentation/commentauthors/) 集合。對於每位作者，它會遍歷 [Comments](https://reference.aspose.com/slides/net/aspose.slides/icommentauthor/comments/) 並列印投影片編號、批註文字、作者名稱與建立時間。輸入的簡報必須含有批註才能產生主控台輸出。

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

## **回覆批註**

父批註是回覆階層頂端的原始批註。[IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) 介面的 [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/parentcomment/) 屬性讓您取得或設定批註的父項。

此範例建立兩位作者的批註，並使用 [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/parentcomment/) 來建構回覆，包括對另一則回覆的回覆。將 `null` 傳入 [GetSlideComments](https://reference.aspose.com/slides/net/aspose.slides/islide/getslidecomments/) 可取得所有作者的批註；主控台會根據回覆階層的深度縮排每筆條目。範例儲存完整討論，對第一個根批註呼叫 [Remove](https://reference.aspose.com/slides/net/aspose.slides/icomment/remove/)，並儲存第二份不含該批註及其回覆的簡報。

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
* 使用 [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) 介面的 [Remove](https://reference.aspose.com/slides/net/aspose.slides/icomment/remove/) 方法刪除批註時，該批註的所有回覆也會一起被刪除。
* 若 [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/parentcomment/) 屬性造成循環參照，將拋出 [PptxEditException](https://reference.aspose.com/slides/net/aspose.slides/pptxeditexception)。
{{% /alert %}}

## **新增現代批註**

現代批註可以與投影片本身、特定圖形，或 AutoShape 內的文字範圍相關聯。[ICommentCollection.AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addmoderncomment/) 方法接受一個 [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) 參數，除此之外還需要投影片與批註標記座標。

當形狀參數傳入 `null` 時，批註為投影片層級批註。其標記位置由提供的座標決定，但不會關聯到特定圖形，因此 [IModernComment.Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/) 會回傳 `null`。若提供 [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) ，批註則會錨定於該圖形。座標仍然定義批註標記在投影片上的位置，而圖形關聯可透過 [IModernComment.Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/) 取得。

### **將現代批註錨定至圖形**

此範例兩次呼叫 [AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addmoderncomment/)：一次以 `null` 圖形建立投影片層級批註，一次以矩形作為錨點。讀取 [Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/) 時會為投影片層級批註的 `null` 檢查印出 `True`，而錨定批註則印出 `Revenue title`。兩則批註皆隨簡報一起儲存。

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

### **將批註錨定至不同類型的圖形**

任何實作了 [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) 的投影片物件皆可作為圖形錨點。常見例子包括 [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/)、[IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/)、[IGroupShape](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/)、[IConnector](https://reference.aspose.com/slides/net/aspose.slides/iconnector/)、以及像圖表這樣的 [IGraphicalObject](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobject/) 實例。

此範例使用 [AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addmoderncomment/) 為五種圖形類型各加入一則批註：AutoShape、圖片框、群組、連接線與圖表。圖片使用內嵌影像資料，無需外部影像。每則批註都有自己的標記位置，儲存的簡報會保留全部五個圖形關聯。

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

### **將批註錨定至文字並設定其狀態**

對於與 [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) 相關的現代批註，[IModernComment.TextSelectionStart](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionstart/) 指定形狀文字框中所選文字的起始位置，而 [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionlength/) 指定選取的長度。兩者結合即可將批註與 AutoShape 內特定文字範圍關聯。

[IModernComment.Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/) 屬性可讀取或以 [ModernCommentStatus](https://reference.aspose.com/slides/net/aspose.slides/moderncommentstatus/) 列舉的值進行設定：

- `NotDefined` — 未定義特定的現代批註狀態。
- `Active` — 批註處於作用中。
- `Resolved` — 批註已解決。
- `Closed` — 批註已關閉。

此範例將現代批註錨定於矩形文字中的「quarterly revenue」字詞。它從文字計算零基礎的 [TextSelectionStart](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionstart/)，並將 [TextSelectionLength](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionlength/) 設為所選字元數。將 [Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/) 設為 `Resolved` 後，儲存並重新開啟簡報。四個主控台檢查皆會印出 `True`，證實圖形錨點、文字範圍與狀態均被保留。

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

### **檢查現有的現代批註**

此範例需要一個已包含現代批註的簡報，並印出它們的文字、狀態與錨點細節。檢查時，先找出實作了 [IModernComment](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/) 的批註，然後檢視其 [IModernComment.Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/)、[IModernComment.TextSelectionStart](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionstart/)、[IModernComment.TextSelectionLength](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionlength/) 與 [IModernComment.Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/)。`null` 圖形表示投影片層級批註。若錨點為 [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/)，文字選取屬性即代表該圖形文字框中的範圍。

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

## **移除批註**

Aspose.Slides for .NET 允許您移除簡報中所有批註與其作者，或僅刪除選取的批註而保留其餘。以下範例示範兩種做法，並儲存更新後的簡報。

### **移除所有批註與批註作者**

此範例開啟現有簡報，對每位作者呼叫 [ICommentCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/clear/)，然後呼叫 [ICommentAuthorCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/clear/) 移除作者本身。儲存的簡報將不含任何批註或批註作者。請使用含有批註的簡報以觀察移除效果。

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

### **移除特定批註**

此範例在同一張投影片上建立兩則批註，並使用 [GetSlideComments](https://reference.aspose.com/slides/net/aspose.slides/islide/getslidecomments/) 依作者找出批註。它會收集文字等於「comment 1」的批註，然後呼叫 [ICommentCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/remove/)，以避免在選取過程中修改集合。儲存的簡報將僅保留「comment 2」。

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

**Aspose.Slides 是否支援現代批註的已解決狀態？**

是的。可以讀取並以 [ModernCommentStatus](https://reference.aspose.com/slides/net/aspose.slides/moderncommentstatus/) 值（含 `Resolved`）設定 [IModernComment.Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/)。此狀態會儲存於簡報中，重新開啟檔案後仍可讀取。

**是否支援串流討論（回覆鏈），以及是否有巢狀深度限制？**

是的。每則批註皆可參照其 [parent comment](https://reference.aspose.com/slides/net/aspose.slides/comment/parentcomment/)，從而形成回覆鏈。API 未定義特定的巢狀深度上限。

**批註標記在投影片上的座標系統是什麼？**

標記位置使用浮點座標，定義於投影片的座標系統中，讓您能精確地將其放置於投影片上。