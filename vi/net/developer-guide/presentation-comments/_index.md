---
title: Quản lý bình luận bài thuyết trình trong .NET
linktitle: Bình luận bài thuyết trình
type: docs
weight: 100
url: /vi/net/presentation-comments/
keywords:
- bình luận
- bình luận hiện đại
- bình luận PowerPoint
- bình luận bài thuyết trình
- bình luận slide
- thêm bình luận
- truy cập bình luận
- chỉnh sửa bình luận
- trả lời bình luận
- loại bỏ bình luận
- xóa bình luận
- PowerPoint
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Quản lý bình luận bài thuyết trình với Aspose.Slides cho .NET: thêm, đọc, chỉnh sửa, trả lời và xóa bình luận trong các bài thuyết trình PowerPoint một cách nhanh chóng và dễ dàng."
---
## **Tổng quan**

Bài viết này giải thích cách quản lý các bình luận trong bài thuyết trình bằng Aspose.Slides for .NET. Nó giới thiệu các kiểu dữ liệu liên quan đến bình luận chính và trình bày cách thêm bình luận vào các slide, truy cập các bình luận hiện có, làm việc với trả lời và bình luận hiện đại, cũng như xóa bình luận khỏi bài thuyết trình.

Các ví dụ bao phủ các kịch bản xem xét và cộng tác phổ biến trong PowerPoint, chẳng hạn như gán bình luận cho tác giả, đọc văn bản và siêu dữ liệu của bình luận, xây dựng chuỗi trả lời, và xóa các bình luận đã chọn hoặc tất cả bình luận.

Trong PowerPoint, bình luận xuất hiện như các chú thích trên slide. Khi chọn một bình luận, văn bản và cuộc thảo luận liên quan sẽ được hiển thị.

Để yêu cầu hiển thị hoặc ẩn bình luận khi mở bài thuyết trình mà không thay đổi nội dung bình luận, hãy xem [Show or Hide Comments When Opening a Presentation](/slides/vi/net/presentation-view-properties/).

## **Tại sao nên thêm bình luận vào bài thuyết trình?**

Bạn có thể sử dụng bình luận để cung cấp phản hồi và cộng tác với đồng nghiệp khi xem xét bài thuyết trình.

Aspose.Slides for .NET cung cấp các API sau để làm việc với bình luận:

* Lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) cung cấp quyền truy cập vào các tác giả bình luận của bài thuyết trình.
* Giao diện [ICommentCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/icommentcollection) đại diện cho các bình luận liên kết với một tác giả cụ thể.
* Giao diện [IComment](https://reference.aspose.com/slides/vi/net/aspose.slides/icomment) cung cấp thông tin về một bình luận, bao gồm tác giả, thời gian tạo, vị trí và nội dung.
* Lớp [CommentAuthor](https://reference.aspose.com/slides/vi/net/aspose.slides/commentauthor) cung cấp thông tin về một tác giả, bao gồm tên, ký tự viết tắt và các bình luận liên quan.

## **Thêm bình luận vào slide**
Ví dụ sau cho thấy cách thêm bình luận vào các slide trong một bài thuyết trình PowerPoint:

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

## **Truy cập bình luận trên slide**
Ví dụ sau cho thấy cách truy cập các bình luận hiện có trong một bài thuyết trình PowerPoint:

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

## **Trả lời bình luận**
Một bình luận gốc là bình luận ban đầu ở đầu cây trả lời. Thuộc tính [ParentComment](https://reference.aspose.com/slides/vi/net/aspose.slides/icomment/properties/parentcomment) của giao diện [IComment](https://reference.aspose.com/slides/vi/net/aspose.slides/icomment) cho phép bạn lấy hoặc đặt bình luận cha của một bình luận.

Ví dụ sau cho thấy cách thêm trả lời và kiểm tra cấu trúc cây bình luận tạo ra:

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

* Khi sử dụng phương thức [Remove](https://reference.aspose.com/slides/vi/net/aspose.slides/icomment/methods/remove) của giao diện [IComment](https://reference.aspose.com/slides/vi/net/aspose.slides/icomment) để xóa một bình luận, tất cả các trả lời của bình luận đó cũng sẽ bị xóa.
* Nếu thuộc tính [ParentComment](https://reference.aspose.com/slides/vi/net/aspose.slides/icomment/properties/parentcomment) tạo ra một vòng tham chiếu, một [PptxEditException](https://reference.aspose.com/slides/vi/net/aspose.slides/pptxeditexception) sẽ được ném ra.

{{% /alert %}}

## **Thêm bình luận hiện đại**

Bình luận hiện đại có thể được liên kết với chính slide, với một hình dạng cụ thể, hoặc với một đoạn văn bản bên trong một AutoShape. Phương thức [ICommentCollection.AddModernComment](https://reference.aspose.com/slides/vi/net/aspose.slides/icommentcollection/addmoderncomment/) chấp nhận một đối số [IShape](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/) bổ sung cho slide và tọa độ đánh dấu bình luận.

Khi truyền `null` cho đối số shape, bình luận sẽ là bình luận cấp slide. Dấu đánh dấu của nó được định vị bằng các tọa độ được cung cấp, nhưng không gắn với một shape cụ thể, do đó [IModernComment.Shape](https://reference.aspose.com/slides/vi/net/aspose.slides/imoderncomment/shape/) trả về `null`. Khi cung cấp một [IShape](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/), bình luận sẽ được neo vào shape đó. Các tọa độ vẫn xác định vị trí của dấu đánh dấu bình luận trên slide, trong khi việc liên kết shape có thể được truy xuất qua [IModernComment.Shape](https://reference.aspose.com/slides/vi/net/aspose.slides/imoderncomment/shape/).

### **Neo một bình luận hiện đại vào một shape**

Ví dụ sau tạo cả bình luận hiện đại cấp slide và bình luận hiện đại được neo vào một AutoShape cụ thể. Sau đó nó đọc shape liên kết từ mỗi bình luận.

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

### **Neo bình luận vào các loại shape khác nhau**

Bất kỳ đối tượng slide nào triển khai [IShape](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/) đều có thể được dùng làm neo shape. Các ví dụ phổ biến bao gồm [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/vi/net/aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/vi/net/aspose.slides/iconnector/), và các thể hiện [IGraphicalObject](https://reference.aspose.com/slides/vi/net/aspose.slides/igraphicalobject/) như biểu đồ.

Ví dụ sau tạo một số loại shape thông dụng và gắn một bình luận hiện đại vào mỗi shape.

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

### **Neo bình luận vào văn bản và đặt trạng thái**

Đối với một bình luận hiện đại được gắn với một [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/), thuộc tính [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/vi/net/aspose.slides/imoderncomment/textselectionstart/) chỉ vị trí bắt đầu của đoạn văn bản được chọn trong khung văn bản của shape, trong khi [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/vi/net/aspose.slides/imoderncomment/textselectionlength/) chỉ độ dài của phần chọn. Hai thuộc tính này kết hợp lại để liên kết bình luận với một đoạn văn bản cụ thể bên trong AutoShape.

Thuộc tính [IModernComment.Status](https://reference.aspose.com/slides/vi/net/aspose.slides/imoderncomment/status/) có thể được đọc hoặc cập nhật bằng một giá trị từ enum [ModernCommentStatus](https://reference.aspose.com/slides/vi/net/aspose.slides/moderncommentstatus/):

- `NotDefined` — không có trạng thái bình luận hiện đại cụ thể nào được xác định.
- `Active` — bình luận đang hoạt động.
- `Resolved` — bình luận đã được giải quyết.
- `Closed` — bình luận đã đóng.

Ví dụ sau tạo một bình luận hiện đại được neo vào shape, liên kết nó với một đoạn văn bản được chọn, đánh dấu là đã giải quyết, lưu bài thuyết trình và kiểm tra các giá trị sau khi mở lại tệp.

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

### **Kiểm tra các bình luận hiện đại hiện có**

Để kiểm tra một bài thuyết trình hiện có, xác định những bình luận nào triển khai [IModernComment](https://reference.aspose.com/slides/vi/net/aspose.slides/imoderncomment/), sau đó xem xét [IModernComment.Shape](https://reference.aspose.com/slides/vi/net/aspose.slides/imoderncomment/shape/), [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/vi/net/aspose.slides/imoderncomment/textselectionstart/), [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/vi/net/aspose.slides/imoderncomment/textselectionlength/) và [IModernComment.Status](https://reference.aspose.com/slides/vi/net/aspose.slides/imoderncomment/status/). Một shape `null` cho thấy bình luận cấp slide. Đối với neo vào [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/), các thuộc tính chọn văn bản xác định đoạn văn bản liên quan trong khung văn bản của shape.

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

## **Xóa bình luận**

### **Xóa tất cả bình luận và tác giả bình luận**

Ví dụ sau cho thấy cách xóa tất cả bình luận và tác giả bình luận khỏi một bài thuyết trình:

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

### **Xóa các bình luận cụ thể**

Ví dụ sau cho thấy cách xóa các bình luận cụ thể khỏi một slide:

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

## **Câu hỏi thường gặp**

**Aspose.Slides có hỗ trợ trạng thái đã giải quyết cho bình luận hiện đại không?**

Có. Thuộc tính [IModernComment.Status](https://reference.aspose.com/slides/vi/net/aspose.slides/imoderncomment/status/) có thể được đọc và đặt bằng một giá trị [ModernCommentStatus](https://reference.aspose.com/slides/vi/net/aspose.slides/moderncommentstatus/), bao gồm `Resolved`. Trạng thái này được lưu trong bài thuyết trình và có thể được đọc lại sau khi mở lại tệp.

**Liệu có hỗ trợ các cuộc thảo luận dạng chuỗi trả lời (threaded discussions) và có giới hạn độ sâu lồng nhau không?**

Có. Mỗi bình luận có thể tham chiếu đến [parent comment](https://reference.aspose.com/slides/vi/net/aspose.slides/comment/parentcomment/), cho phép tạo chuỗi trả lời. API không xác định giới hạn độ sâu lồng nhau cụ thể.

**Vị trí dấu đánh dấu bình luận trên slide được xác định bằng hệ tọa độ nào?**

Vị trí dấu đánh dấu được xác định bằng các tọa độ số thực trong hệ tọa độ của slide, cho phép bạn đặt nó một cách chính xác trên slide.