---
title: Quản lý nhận xét bản trình chiếu trong .NET
linktitle: Nhận xét bản trình chiếu
type: docs
weight: 100
url: /vi/net/presentation-comments/
keywords:
- nhận xét
- nhận xét hiện đại
- nhận xét PowerPoint
- nhận xét bản trình chiếu
- nhận xét slide
- thêm nhận xét
- truy cập nhận xét
- chỉnh sửa nhận xét
- trả lời nhận xét
- xóa nhận xét
- xoá nhận xét
- PowerPoint
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Quản lý các nhận xét bản trình chiếu với Aspose.Slides cho .NET: thêm, đọc, chỉnh sửa, trả lời và xóa nhận xét trong các bản trình chiếu PowerPoint một cách nhanh chóng và dễ dàng."
---
## **Tổng quan**

Bài viết này giải thích cách quản lý các chú thích trong bản trình chiếu bằng Aspose.Slides cho .NET. Nó giới thiệu các kiểu liên quan tới chú thích chính và trình bày cách thêm chú thích vào các slide, truy cập các chú thích hiện có, làm việc với các phản hồi và chú thích hiện đại, và xóa các chú thích khỏi một bản trình chiếu.

Các ví dụ bao gồm các kịch bản đánh giá và cộng tác thường gặp trong PowerPoint, chẳng hạn như gán chú thích cho tác giả, đọc nội dung và siêu dữ liệu của chú thích, xây dựng chuỗi phản hồi, và xóa các chú thích đã chọn hoặc tất cả các chú thích.

Trong PowerPoint, các chú thích xuất hiện dưới dạng chú giải trên các slide. Việc chọn một chú thích sẽ hiển thị nội dung và cuộc thảo luận liên quan.

Để yêu cầu hiển thị hoặc ẩn các chú thích khi mở bản trình chiếu mà không thay đổi chúng, xem [Hiển thị hoặc Ẩn chú thích khi mở bản trình chiếu](/slides/vi/net/presentation-view-properties/).

## **Tại sao thêm chú thích vào bản trình chiếu?**

Bạn có thể sử dụng chú thích để đưa ra phản hồi và cộng tác với đồng nghiệp khi xem xét bản trình chiếu.

Aspose.Slides cho .NET cung cấp các API sau để làm việc với chú thích:

* Lớp [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), cung cấp quyền truy cập vào các tác giả chú thích của bản trình chiếu.  
* Giao diện [ICommentCollection](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection), đại diện cho các chú thích liên kết với một tác giả riêng lẻ.  
* Giao diện [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment), cung cấp thông tin về một chú thích, bao gồm tác giả, thời gian tạo, vị trí và nội dung.  
* Lớp [CommentAuthor](https://reference.aspose.com/slides/net/aspose.slides/commentauthor), cung cấp thông tin về một tác giả, bao gồm tên, ký hiệu và các chú thích liên quan.

## **Thêm chú thích vào slide**

Ví dụ tạo hai slide và đăng ký một tác giả chú thích bằng [AddAuthor](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/addauthor/). Nó sử dụng [AddComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addcomment/) để đặt một chú thích trên mỗi slide, sau đó lấy các chú thích của slide đầu tiên cho tác giả đó bằng [GetSlideComments](https://reference.aspose.com/slides/net/aspose.slides/islide/getslidecomments/). Bảng điều khiển hiển thị nội dung của chú thích đầu tiên hai lần, chứng minh việc truy cập qua cả slide và tác giả, và bản trình chiếu đã lưu chứa cả hai chú thích.

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

## **Tìm hoặc Tạo Tác Giả Chú Thích**

Khi một quy trình đánh giá tự động xử lý cùng một bản trình chiếu nhiều lần, hãy tìm trong bộ sưu tập [CommentAuthors](https://reference.aspose.com/slides/net/aspose.slides/presentation/commentauthors/) trước khi thêm tác giả. [FindByNameAndInitials](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/findbynameandinitials/) khớp cả tên và ký hiệu và trả về một mảng các tác giả phù hợp, hoặc một mảng rỗng nếu không tìm thấy. Ngược lại, [FindByName](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/findbyname/) chỉ tìm theo tên, bất kể ký hiệu. Gọi [AddAuthor](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/addauthor/) với tên và ký hiệu đã tồn tại trong bộ sưu tập sẽ ném ngoại lệ.

Ví dụ yêu cầu một tệp bản trình chiếu có ít nhất một slide. Trong mỗi trong hai lần chạy, nó tái sử dụng tác giả khớp đầu tiên, hoặc tạo mới chỉ khi kết quả rỗng. Nếu có nhiều kết quả phù hợp, nó chọn phần tử đầu tiên trong mảng mà không hợp nhất hay xóa các tác giả khác. Sau đó nó gọi [AddComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addcomment/) cho tác giả đã chọn và lưu bản trình chiếu. Lần chạy thứ hai mở kết quả của lần chạy đầu tiên và lặp lại thao tác.

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

Lần chạy thứ hai thêm một chú thích khác mà không thêm tác giả mới hoặc xóa các chú thích hiện có. Tệp cuối cùng, `review_pass_2.pptx`, chứa cả hai chú thích mới cùng với bất kỳ chú thích gốc nào. Tái sử dụng một tác giả không loại bỏ trùng lặp các chú thích: để tránh việc thêm lại cùng một chú thích, hãy triển khai kiểm tra trùng lặp riêng trước khi thêm.

## **Truy cập các chú thích trên slide**

Ví dụ mở một bản trình chiếu hiện có và đọc bộ sưu tập [CommentAuthors](https://reference.aspose.com/slides/net/aspose.slides/presentation/commentauthors/). Đối với mỗi tác giả, nó duyệt qua [Comments](https://reference.aspose.com/slides/net/aspose.slides/icommentauthor/comments/) và in số slide, nội dung chú thích, tên tác giả và thời gian tạo. Bản trình chiếu nhập vào phải chứa chú thích để tạo ra đầu ra trên bảng điều khiển.

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

## **Phản hồi cho các chú thích**

Một chú thích cha là chú thích gốc ở đầu một chuỗi phản hồi. Thuộc tính [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/parentcomment/) của giao diện [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) cho phép bạn lấy hoặc đặt chú thích cha.

Ví dụ tạo các chú thích từ hai tác giả và sử dụng [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/parentcomment/) để xây dựng các phản hồi, bao gồm một phản hồi cho một phản hồi khác. Truyền `null` vào [GetSlideComments](https://reference.aspose.com/slides/net/aspose.slides/islide/getslidecomments/) sẽ lấy các chú thích từ tất cả các tác giả; bảng điều khiển thụt lề mỗi mục theo độ sâu trong cây phản hồi. Ví dụ lưu toàn bộ cuộc thảo luận, gọi [Remove](https://reference.aspose.com/slides/net/aspose.slides/icomment/remove/) trên chú thích gốc đầu tiên, và lưu một bản trình chiếu thứ hai với chú thích đó và các phản hồi của nó đã bị xóa.

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
* Khi sử dụng phương thức [Remove](https://reference.aspose.com/slides/net/aspose.slides/icomment/remove/) của giao diện [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) để xóa một chú thích, tất cả các phản hồi của chú thích đó cũng sẽ bị xóa.
* Nếu thuộc tính [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/parentcomment/) tạo ra một tham chiếu vòng, một [PptxEditException](https://reference.aspose.com/slides/net/aspose.slides/pptxeditexception) sẽ được ném.
{{% /alert %}}

## **Thêm chú thích hiện đại**

Các chú thích hiện đại có thể được gắn với slide, với một hình dạng cụ thể, hoặc với một đoạn văn bản bên trong một AutoShape. Phương thức [ICommentCollection.AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addmoderncomment/) chấp nhận một đối số [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) bổ sung vào slide và tọa độ của dấu chú thích.

Khi truyền `null` cho đối số shape, chú thích sẽ là chú thích ở mức slide. Dấu chú thích được định vị bằng các tọa độ cung cấp, nhưng không gắn với một hình dạng cụ thể, vì vậy [IModernComment.Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/) trả về `null`. Khi cung cấp một [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/), chú thích sẽ được neo vào hình dạng đó. Các tọa độ vẫn xác định vị trí của dấu chú thích trên slide, trong khi thông tin về hình dạng có thể được truy xuất qua [IModernComment.Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/).

### **Neo một chú thích hiện đại vào một hình dạng**

Ví dụ gọi [AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addmoderncomment/) hai lần: một lần với shape `null` cho chú thích ở mức slide và một lần nữa với một hình chữ nhật làm neo. Đọc [Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/) in ra `True` cho kiểm tra `null` của chú thích ở mức slide và in ra `Revenue title` cho chú thích được neo. Cả hai chú thích đều được lưu cùng bản trình chiếu.

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

### **Neo chú thích vào các loại hình dạng khác nhau**

Bất kỳ đối tượng slide nào triển khai [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) đều có thể được dùng làm neo cho chú thích. Các ví dụ phổ biến bao gồm [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/net/aspose.slides/iconnector/), và các thể hiện của [IGraphicalObject](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobject/) như biểu đồ.

Ví dụ sử dụng [AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addmoderncomment/) để gắn một chú thích vào mỗi một trong năm loại hình dạng: một AutoShape, một khung hình, một nhóm, một kết nối và một biểu đồ. Hình ảnh được nhúng dữ liệu ảnh, vì vậy không cần hình ảnh bên ngoài. Mỗi chú thích có vị trí dấu riêng, và bản trình chiếu đã lưu giữ tất cả năm mối liên kết hình dạng.

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

### **Neo chú thích vào văn bản và đặt trạng thái**

Đối với một chú thích hiện đại gắn với [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/), thuộc tính [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionstart/) xác định vị trí bắt đầu của văn bản được chọn trong khung văn bản của hình dạng, trong khi [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionlength/) xác định độ dài của phần chọn. Hai thuộc tính này kết hợp để gắn chú thích với một đoạn văn bản cụ thể bên trong AutoShape.

Thuộc tính [IModernComment.Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/) có thể được đọc hoặc cập nhật với một giá trị từ liệt kê [ModernCommentStatus](https://reference.aspose.com/slides/net/aspose.slides/moderncommentstatus/):

- `NotDefined` — không có trạng thái chú thích hiện đại cụ thể nào được định nghĩa.  
- `Active` — chú thích đang hoạt động.  
- `Resolved` — chú thích đã được giải quyết.  
- `Closed` — chú thích đã đóng.

Ví dụ neo một chú thích hiện đại vào các từ “quarterly revenue” trong văn bản của một hình chữ nhật. Nó tính [TextSelectionStart](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionstart/) dựa trên vị trí zero‑based trong văn bản và đặt [TextSelectionLength](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionlength/) bằng số ký tự được chọn. Sau khi đặt [Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/) thành `Resolved`, nó lưu và mở lại bản trình chiếu. Bốn kiểm tra trên bảng điều khiển đều in `True`, xác nhận rằng neo hình dạng, phạm vi văn bản và trạng thái đã được bảo tồn.

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

### **Kiểm tra các chú thích hiện đại hiện có**

Ví dụ yêu cầu một bản trình chiếu hiện có chứa các chú thích hiện đại và in ra nội dung, trạng thái và chi tiết neo. Để kiểm tra, xác định các chú thích triển khai [IModernComment](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/), sau đó xem xét [IModernComment.Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/), [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionstart/), [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionlength/) và [IModernComment.Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/). Một hình dạng `null` cho thấy đây là chú thích ở mức slide. Đối với neo [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/), các thuộc tính lựa chọn văn bản xác định phạm vi liên quan trong khung văn bản của hình dạng.

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

## **Xóa chú thích**

Aspose.Slides cho .NET cho phép bạn xóa tất cả các chú thích và các tác giả của chúng khỏi một bản trình chiếu hoặc xóa các chú thích đã chọn trong khi giữ lại phần còn lại. Các ví dụ sau minh họa cả hai cách và lưu bản trình chiếu đã cập nhật.

### **Xóa tất cả các chú thích và tác giả chú thích**

Ví dụ mở một bản trình chiếu hiện có và gọi [ICommentCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/clear/) cho mỗi tác giả, sau đó gọi [ICommentAuthorCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/clear/) để xóa các tác giả. Bản trình chiếu đã lưu sẽ không còn chứa chú thích và cũng không có tác giả chú thích. Hãy sử dụng một bản trình chiếu có chú thích để quan sát quá trình xóa.

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

### **Xóa các chú thích cụ thể**

Ví dụ tạo hai chú thích trên một slide và sử dụng [GetSlideComments](https://reference.aspose.com/slides/net/aspose.slides/islide/getslidecomments/) để tìm các chú thích theo từng tác giả. Nó thu thập các chú thích có nội dung bằng “comment 1” trước khi gọi [ICommentCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/remove/), tránh việc thay đổi bộ sưu tập trong quá trình lựa chọn. Bản trình chiếu đã lưu sẽ chỉ còn lại “comment 2”.

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

**Aspose.Slides có hỗ trợ trạng thái đã giải quyết cho các chú thích hiện đại không?**

Có. [IModernComment.Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/) có thể được đọc và đặt bằng một giá trị của [ModernCommentStatus](https://reference.aspose.com/slides/net/aspose.slides/moderncommentstatus/), bao gồm `Resolved`. Trạng thái được lưu trong bản trình chiếu và có thể đọc lại sau khi tệp được mở lại.

**Các cuộc thảo luận dạng chuỗi (chuỗi phản hồi) có được hỗ trợ không, và có giới hạn độ sâu không?**

Có. Mỗi chú thích có thể tham chiếu tới [parent comment](https://reference.aspose.com/slides/net/aspose.slides/comment/parentcomment/), cho phép tạo chuỗi phản hồi. API không định nghĩa giới hạn độ sâu cụ thể nào.

**Vị trí của dấu chú thích trên slide được định nghĩa trong hệ tọa độ nào?**

Vị trí dấu chú thích được xác định bằng các tọa độ kiểu số thực trong hệ tọa độ của slide, cho phép bạn đặt nó một cách chính xác trên slide.