---
title: Quản lý danh sách có dấu đầu mục và danh sách đánh số trong bản trình bày bằng .NET
linktitle: Quản lý danh sách
type: docs
weight: 70
url: /vi/net/manage-lists/
keywords:
- dấu đầu mục
- danh sách có dấu đầu mục
- danh sách đánh số
- dấu đầu mục biểu tượng
- dấu đầu mục hình ảnh
- dấu đầu mục tùy chỉnh
- danh sách đa cấp
- tạo dấu đầu mục
- thêm dấu đầu mục
- thêm danh sách
- PowerPoint
- OpenDocument
- bản trình bày
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu cách tạo và định dạng danh sách có dấu đầu mục, danh sách hình ảnh, danh sách đa cấp và danh sách đánh số trong các bản trình bày PowerPoint và OpenDocument bằng Aspose.Slides cho .NET."
---
## **Tổng quan**

Aspose.Slides for .NET cho phép bạn tạo và định dạng danh sách có dấu đầu mục và danh sách đánh số trong các bản trình bày PowerPoint và OpenDocument. Một mục danh sách là một đoạn văn mà cài đặt dấu đầu mục được kiểm soát thông qua định dạng đoạn văn của nó.

Sử dụng thuộc tính [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraph/paragraphformat/) để truy cập cài đặt danh sách ở mức đoạn văn. Điểm vào chính là [IParagraphFormat.Bullet](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/bullet/), trả về một đối tượng [IBulletFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/ibulletformat/). Với đối tượng này, bạn có thể đặt loại dấu đầu mục, ký hiệu, hình ảnh, màu, kích thước, kiểu đánh số và số bắt đầu.

Bài viết này minh họa cách:

- tạo danh sách có dấu đầu mục với biểu tượng tùy chỉnh
- tạo dấu đầu mục bằng hình ảnh
- tạo danh sách đa cấp bằng cách đặt độ sâu đoạn văn
- tạo danh sách đánh số
- kiểm tra và thay đổi định dạng danh sách trong một bản trình bày hiện có

## **Tạo danh sách có dấu đầu mục**

Để tạo danh sách có dấu đầu mục, thêm các đối tượng [IParagraph](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraph/) vào một [ITextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/) và đặt [IBulletFormat.Type](https://reference.aspose.com/slides/vi/net/aspose.slides/ibulletformat/type/) thành [BulletType.Symbol](https://reference.aspose.com/slides/vi/net/aspose.slides/bullettype/). Sau đó bạn có thể đặt [IBulletFormat.Char](https://reference.aspose.com/slides/vi/net/aspose.slides/ibulletformat/char/), [IBulletFormat.Color](https://reference.aspose.com/slides/vi/net/aspose.slides/ibulletformat/color/) và [IBulletFormat.Height](https://reference.aspose.com/slides/vi/net/aspose.slides/ibulletformat/height/) để kiểm soát giao diện dấu đầu mục.

Mã C# sau đây minh họa cách tạo danh sách có dấu đầu mục trong một slide:

```csharp
static Paragraph CreateParagraph(string text)
{
    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    paragraph.ParagraphFormat.Bullet.Char = '*';
    paragraph.ParagraphFormat.Indent = 15;
    paragraph.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True;
    paragraph.ParagraphFormat.Bullet.Color.Color = Color.IndianRed;
    paragraph.ParagraphFormat.Bullet.Height = 100;
    paragraph.Text = text;
    return paragraph;
}

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph1 = CreateParagraph("The first paragraph");
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = CreateParagraph("The second paragraph");
textFrame.Paragraphs.Add(paragraph2);

presentation.Save("symbol_bullets.pptx", SaveFormat.Pptx);
```

Kết quả:

![Các dấu đầu mục biểu tượng](symbol_bullets.png)

## **Tạo danh sách đánh số**

Sử dụng danh sách đánh số khi thứ tự của các mục quan trọng. Đặt [IBulletFormat.Type](https://reference.aspose.com/slides/vi/net/aspose.slides/ibulletformat/type/) thành [BulletType.Numbered](https://reference.aspose.com/slides/vi/net/aspose.slides/bullettype/). Bạn cũng có thể chọn định dạng đánh số bằng [IBulletFormat.NumberedBulletStyle](https://reference.aspose.com/slides/vi/net/aspose.slides/ibulletformat/numberedbulletstyle/) hoặc đặt [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/vi/net/aspose.slides/ibulletformat/numberedbulletstartwith/) khi danh sách nên bắt đầu từ giá trị khác 1.

Mã C# sau đây cho thấy cách tạo danh sách đánh số trong một slide:

```csharp
using var presentation = new Presentation();

var slide = presentation.Slides[0];
var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 90, 80);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph1 = new Paragraph();
paragraph1.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph1.Text = "Apple";
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = new Paragraph();
paragraph2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph2.Text = "Orange";
textFrame.Paragraphs.Add(paragraph2);

var paragraph3 = new Paragraph();
paragraph3.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph3.Text = "Banana";
textFrame.Paragraphs.Add(paragraph3);

presentation.Save("numbered_bullets.pptx", SaveFormat.Pptx);
```

Kết quả:

![Các dấu đầu mục đánh số](numbered_bullets.png)

## **Tạo dấu đầu mục bằng hình ảnh**

Aspose.Slides cho phép bạn thay thế ký hiệu dấu đầu mục thông thường bằng một hình ảnh. Dấu đầu mục bằng hình ảnh hoạt động tốt nhất với những hình ảnh đơn giản vẫn có thể đọc được ở kích thước nhỏ, chẳng hạn như biểu tượng hoặc các tệp PNG trong suốt nhỏ.

{{% alert color="primary" %}}
Lý tưởng nhất, nếu bạn dự định thay thế ký hiệu dấu đầu mục thông thường bằng một hình ảnh, bạn nên chọn một đồ họa đơn giản có nền trong suốt. Những hình ảnh như vậy hoạt động tốt như các ký hiệu dấu đầu mục tùy chỉnh.

Hãy nhớ rằng hình ảnh sẽ được thu nhỏ xuống kích thước rất nhỏ. Vì lý do này, chúng tôi khuyến nghị mạnh mẽ bạn chọn một hình ảnh vẫn rõ ràng và hiệu quả về mặt hình ảnh khi được sử dụng làm dấu đầu mục trong danh sách.
{{% /alert %}}

Để tạo dấu đầu mục bằng hình ảnh, thêm một hình ảnh vào [Presentation.Images](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/images/) và gán đối tượng hình ảnh trả về cho [IBulletFormat.Picture](https://reference.aspose.com/slides/vi/net/aspose.slides/ibulletformat/picture/). Đặt [IBulletFormat.Type](https://reference.aspose.com/slides/vi/net/aspose.slides/ibulletformat/type/) thành [BulletType.Picture](https://reference.aspose.com/slides/vi/net/aspose.slides/bullettype/) trước khi gán hình ảnh.

Giả sử chúng ta có một "image.png":

![Một hình ảnh cho các dấu đầu mục](picture_for_bullets.png)

Mã C# sau đây cho thấy cách tạo dấu đầu mục bằng hình ảnh trong một slide:

```csharp
static Paragraph CreateParagraph(string text, IPPImage image)
{
    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
    paragraph.ParagraphFormat.Bullet.Picture.Image = image;
    paragraph.ParagraphFormat.Indent = 15;
    paragraph.ParagraphFormat.Bullet.Height = 100;
    paragraph.Text = text;
    return paragraph;
}

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var imageBytes = File.ReadAllBytes("image.png");
var bulletImage = presentation.Images.AddImage(imageBytes);

var paragraph1 = CreateParagraph("The first paragraph", bulletImage);
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = CreateParagraph("The second paragraph", bulletImage);
textFrame.Paragraphs.Add(paragraph2);

presentation.Save("picture_bullets.pptx", SaveFormat.Pptx);
```

Kết quả:

![Các dấu đầu mục hình ảnh](picture_bullets.png)

## **Tạo danh sách đa cấp**

Sử dụng [IParagraphFormat.Depth](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/depth/) để đặt các mục danh sách ở các cấp độ khác nhau. Cấp 0 là cấp trên cùng, cấp 1 nằm lồng dưới nó, và cứ tiếp tục như vậy.

Mã C# sau đây cho thấy cách tạo danh sách có dấu đầu mục đa cấp:

```csharp
using var presentation = new Presentation();

var slide = presentation.Slides[0];
var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 260, 110);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph1 = new Paragraph();
paragraph1.ParagraphFormat.Depth = 0;
paragraph1.Text = "My text - Depth 0";
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = new Paragraph();
paragraph2.ParagraphFormat.Depth = 1;
paragraph2.Text = "My text - Depth 1";
textFrame.Paragraphs.Add(paragraph2);

var paragraph3 = new Paragraph();
paragraph3.ParagraphFormat.Depth = 2;
paragraph3.Text = "My text - Depth 2";
textFrame.Paragraphs.Add(paragraph3);

var paragraph4 = new Paragraph();
paragraph4.ParagraphFormat.Depth = 3;
paragraph4.Text = "My text - Depth 3";
textFrame.Paragraphs.Add(paragraph4);

presentation.Save("multilevel_bullets.pptx", SaveFormat.Pptx);
```

Kết quả:

![Danh sách đa cấp](multilevel_list.png)

## **Thay đổi danh sách hiện có**

Để thay đổi định dạng danh sách trong một bản trình bày hiện có, truy cập đoạn văn mục tiêu và cập nhật cài đặt [IParagraphFormat.Bullet](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/bullet/) của nó. Các thuộc tính giống như khi tạo danh sách có thể được dùng để kiểm tra hoặc sửa đổi danh sách được tải từ tệp PPT, PPTX hoặc ODP.

Mã C# sau đây thay đổi đoạn văn đầu tiên trong một khung văn bản để sử dụng kiểu danh sách đánh số:

```csharp
using var presentation = new Presentation("input.pptx");

var slide = presentation.Slides[0];
var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

paragraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletRomanUCPeriod;
paragraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 1;
paragraph.ParagraphFormat.MarginLeft = 30;
paragraph.ParagraphFormat.Indent = -20;

presentation.Save("updated_list.pptx", SaveFormat.Pptx);
```

## **Câu hỏi thường gặp**

**Liệu các danh sách có dấu đầu mục và danh sách đánh số có thể xuất ra PDF hoặc hình ảnh không?**

Có. Aspose.Slides bảo tồn định dạng danh sách khi định dạng đích hỗ trợ bố cục văn bản và các tính năng dấu đầu mục tương ứng.

**Tôi có thể chỉnh sửa danh sách trong các bản trình bày hiện có không?**

Có. Tải bản trình bày, truy cập đoạn văn mục tiêu, kiểm tra hoặc cập nhật cài đặt [IParagraphFormat.Bullet](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/bullet/) của nó và lưu bản trình bày.

**Liệu danh sách có thể chứa văn bản không phải chữ Latinh không?**

Có. Văn bản của mục danh sách có thể chứa ký tự Unicode, vì vậy bạn có thể tạo danh sách trong các bản trình bày đa ngôn ngữ. Đảm bảo các phông chữ được sử dụng trong bản trình bày hỗ trợ các ký tự bạn cần.