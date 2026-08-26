---
title: Quản lý Nhận xét Bản trình bày trong .NET
linktitle: Nhận xét Bản trình bày
type: docs
weight: 100
url: /vi/net/presentation-comments/
keywords:
- nhận xét
- nhận xét hiện đại
- nhận xét PowerPoint
- nhận xét bản trình bày
- nhận xét slide
- thêm nhận xét
- truy cập nhận xét
- chỉnh sửa nhận xét
- trả lời nhận xét
- xóa nhận xét
- xoá nhận xét
- PowerPoint
- bản trình bày
- .NET
- C#
- Aspose.Slides
description: "Quản lý nhận xét bản trình bày với Aspose.Slides cho .NET: thêm, đọc, chỉnh sửa, trả lời và xóa nhận xét trong các bản trình bày PowerPoint một cách nhanh chóng và dễ dàng."
---
## **Tổng quan**

Bài viết này giải thích cách quản lý nhận xét trong bản trình bày bằng Aspose.Slides cho .NET. Nó giới thiệu các kiểu liên quan đến nhận xét chính và trình bày cách thêm nhận xét vào các slide, truy cập các nhận xét hiện có, làm việc với trả lời và nhận xét hiện đại, và xóa nhận xét khỏi một bản trình bày.

Các ví dụ bao phủ các kịch bản đánh giá và cộng tác phổ biến trong PowerPoint, chẳng hạn như gán nhận xét cho tác giả, đọc nội dung và siêu dữ liệu của nhận xét, xây dựng chuỗi trả lời, và xóa các nhận xét đã chọn hoặc tất cả các nhận xét.

Trong PowerPoint, nhận xét xuất hiện dưới dạng chú thích trên slide. Khi chọn một nhận xét, nó sẽ hiển thị văn bản và cuộc thảo luận liên quan.

## **Tại sao cần thêm nhận xét vào bản trình bày?**

Bạn có thể sử dụng nhận xét để đưa ra phản hồi và cộng tác với đồng nghiệp khi xem xét bản trình bày.

Aspose.Slides cho .NET cung cấp các API sau để làm việc với nhận xét:

* Lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation), cung cấp quyền truy cập vào các tác giả nhận xét của bản trình bày.
* Giao diện [ICommentCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/icommentcollection), đại diện cho các nhận xét liên quan đến một tác giả cụ thể.
* Giao diện [IComment](https://reference.aspose.com/slides/vi/net/aspose.slides/icomment), cung cấp thông tin về một nhận xét, bao gồm tác giả, thời gian tạo, vị trí và nội dung.
* Lớp [CommentAuthor](https://reference.aspose.com/slides/vi/net/aspose.slides/commentauthor), cung cấp thông tin về một tác giả, bao gồm tên, ký hiệu và các nhận xét liên quan.

## **Thêm nhận xét vào slide**
Ví dụ sau cho thấy cách thêm nhận xét vào các slide trong một bản trình bày PowerPoint:

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

## **Truy cập nhận xét của slide**
Ví dụ sau cho thấy cách truy cập các nhận xét hiện có trong một bản trình bày PowerPoint:

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

## **Trả lời nhận xét**
Một nhận xét cha là nhận xét gốc ở đầu chuỗi trả lời. Thuộc tính [ParentComment](https://reference.aspose.com/slides/vi/net/aspose.slides/icomment/properties/parentcomment) của giao diện [IComment](https://reference.aspose.com/slides/vi/net/aspose.slides/icomment) cho phép bạn lấy hoặc đặt cha của một nhận xét.

Ví dụ sau cho thấy cách thêm trả lời và kiểm tra cấu trúc nhận xét tạo ra:

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

{{% alert color="warning" title="Chú ý" %}} 

* Khi sử dụng phương thức [Remove](https://reference.aspose.com/slides/vi/net/aspose.slides/icomment/methods/remove) của giao diện [IComment](https://reference.aspose.com/slides/vi/net/aspose.slides/icomment) để xóa một nhận xét, tất cả các trả lời của nhận xét đó cũng sẽ bị xóa.
* Nếu thuộc tính [ParentComment](https://reference.aspose.com/slides/vi/net/aspose.slides/icomment/properties/parentcomment) tạo ra một tham chiếu vòng, một [PptxEditException](https://reference.aspose.com/slides/vi/net/aspose.slides/pptxeditexception) sẽ được ném ra.

{{% /alert %}}

## **Thêm nhận xét hiện đại**

Nhận xét hiện đại có thể được gắn với chính slide, với một hình dạng cụ thể, hoặc với một đoạn văn bản bên trong AutoShape. Phương thức [ICommentCollection.AddModernComment](https://reference.aspose.com/slides/vi/net/aspose.slides/icommentcollection/addmoderncomment/) chấp nhận một đối số [IShape](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/) bên cạnh slide và tọa độ dấu nhận xét.

Khi truyền `null` cho đối số shape, nhận xét sẽ là một nhận xét cấp slide. Dấu nhận xét được định vị bằng các tọa độ đã cung cấp, nhưng không được gắn với một shape cụ thể, vì vậy [IModernComment.Shape](https://reference.aspose.com/slides/vi/net/aspose.slides/imoderncomment/shape/) trả về `null`. Khi cung cấp một [IShape](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/), nhận xét sẽ được neo vào shape đó. Các tọa độ vẫn xác định vị trí của dấu nhận xét trên slide, trong khi việc gắn shape có thể được lấy thông qua [IModernComment.Shape](https://reference.aspose.com/slides/vi/net/aspose.slides/imoderncomment/shape/).

### **Neo một nhận xét hiện đại vào shape**

Ví dụ sau tạo cả một nhận xét hiện đại cấp slide và một nhận xét hiện đại được neo vào một AutoShape cụ thể. Sau đó nó đọc shape liên quan từ mỗi nhận xét.

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

### **Neo nhận xét vào các kiểu shape khác nhau**

Bất kỳ đối tượng slide nào triển khai [IShape](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/) đều có thể được dùng làm neo shape. Các ví dụ phổ biến bao gồm [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/vi/net/aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/vi/net/aspose.slides/iconnector/), và các thể hiện [IGraphicalObject](https://reference.aspose.com/slides/vi/net/aspose.slides/igraphicalobject/) như biểu đồ.

Ví dụ sau tạo một số kiểu shape thông thường và gắn một nhận xét hiện đại vào mỗi shape đó.

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

### **Neo nhận xét vào văn bản và đặt trạng thái**

Đối với một nhận xét hiện đại được gắn với [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/), thuộc tính [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/vi/net/aspose.slides/imoderncomment/textselectionstart/) chỉ vị trí bắt đầu của đoạn văn bản đã chọn trong khung văn bản của shape, trong khi [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/vi/net/aspose.slides/imoderncomment/textselectionlength/) chỉ độ dài của đoạn chọn. Cả hai thuộc tính này kết hợp để gắn nhận xét với một đoạn văn bản cụ thể bên trong AutoShape.

Thuộc tính [IModernComment.Status](https://reference.aspose.com/slides/vi/net/aspose.slides/imoderncomment/status/) có thể được đọc hoặc cập nhật bằng một giá trị từ enum [ModernCommentStatus](https://reference.aspose.com/slides/vi/net/aspose.slides/moderncommentstatus/):

- `NotDefined` — không có trạng thái nhận xét hiện đại cụ thể nào được xác định.
- `Active` — nhận xét đang hoạt động.
- `Resolved` — nhận xét đã được giải quyết.
- `Closed` — nhận xét đã đóng.

Ví dụ sau tạo một nhận xét hiện đại được neo vào shape, gắn nó với một đoạn văn bản đã chọn, đánh dấu là đã giải quyết, lưu bản trình bày, và kiểm tra các giá trị sau khi mở lại tệp.

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

### **Kiểm tra các nhận xét hiện đại đã tồn tại**

Để kiểm tra một bản trình bày hiện có, xác định các nhận xét thực hiện [IModernComment](https://reference.aspose.com/slides/vi/net/aspose.slides/imoderncomment/), sau đó xem xét [IModernComment.Shape](https://reference.aspose.com/slides/vi/net/aspose.slides/imoderncomment/shape/), [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/vi/net/aspose.slides/imoderncomment/textselectionstart/), [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/vi/net/aspose.slides/imoderncomment/textselectionlength/), và [IModernComment.Status](https://reference.aspose.com/slides/vi/net/aspose.slides/imoderncomment/status/). Một shape `null` cho thấy là nhận xét cấp slide. Đối với một neo [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/), các thuộc tính lựa chọn văn bản xác định phạm vi liên quan trong khung văn bản của shape.

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

## **Xóa nhận xét**

### **Xóa tất cả nhận xét và tác giả nhận xét**

Ví dụ sau cho thấy cách xóa tất cả nhận xét và các tác giả nhận xét khỏi một bản trình bày:

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

### **Xóa các nhận xét cụ thể**

Ví dụ sau cho thấy cách xóa các nhận xét cụ thể khỏi một slide:

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

**Aspose.Slides có hỗ trợ trạng thái đã giải quyết cho nhận xét hiện đại không?**

Có. [IModernComment.Status](https://reference.aspose.com/slides/vi/net/aspose.slides/imoderncomment/status/) có thể được đọc và đặt bằng một giá trị [ModernCommentStatus](https://reference.aspose.com/slides/vi/net/aspose.slides/moderncommentstatus/), bao gồm `Resolved`. Trạng thái này được lưu trong bản trình bày và có thể đọc lại sau khi tệp được mở lại.

**Liệu các cuộc thảo luận dạng chuỗi trả lời có được hỗ trợ không, và có giới hạn mức lồng nhau không?**

Có. Mỗi nhận xét có thể tham chiếu đến [parent comment](https://reference.aspose.com/slides/vi/net/aspose.slides/comment/parentcomment/), cho phép tạo chuỗi trả lời. API không định nghĩa giới hạn độ sâu lồng nhau cụ thể.

**Vị trí của dấu nhận xét trên slide được xác định trong hệ tọa độ nào?**

Vị trí dấu nhận xét được xác định bằng các tọa độ kiểu số thực trong hệ tọa độ của slide, cho phép bạn đặt nó chính xác trên slide.