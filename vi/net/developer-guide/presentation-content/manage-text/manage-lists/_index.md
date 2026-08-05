---
title: Quản lý danh sách có dấu đầu dòng và có số trong bản trình bày bằng .NET
linktitle: Quản lý danh sách
type: docs
weight: 70
url: /vi/net/manage-lists/
aliases:
  - /net/manage-bullet-and-numbered-lists/
keywords:
- dấu đầu dòng
- danh sách có dấu đầu dòng
- danh sách có số
- dấu đầu dòng ký hiệu
- dấu đầu dòng hình ảnh
- dấu đầu dòng tùy chỉnh
- danh sách đa cấp
- tạo dấu đầu dòng
- thêm dấu đầu dòng
- thêm danh sách
- PowerPoint
- OpenDocument
- bản trình bày
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu cách tạo và định dạng danh sách có dấu đầu dòng, hình ảnh, đa cấp và có số trong các bản trình bày PowerPoint và OpenDocument bằng Aspose.Slides cho .NET."
---
## **Tổng quan**

Aspose.Slides for .NET cho phép bạn tạo và định dạng các danh sách có dấu đầu dòng và có số trong các bản trình bày PowerPoint và OpenDocument. Một mục danh sách là một đoạn văn mà cài đặt dấu đầu dòng được kiểm soát thông qua định dạng đoạn của nó.

Sử dụng thuộc tính [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraph/paragraphformat/) để truy cập các cài đặt danh sách ở cấp đoạn. Điểm vào chính là [IParagraphFormat.Bullet](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/bullet/), nó trả về một đối tượng [IBulletFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/ibulletformat/). Với đối tượng này, bạn có thể đặt loại dấu đầu dòng, ký hiệu, hình ảnh, màu sắc, kích thước, kiểu đánh số và số bắt đầu.

Bài viết này trình bày cách:

- tạo danh sách có dấu đầu dòng với ký hiệu tùy chỉnh
- tạo dấu đầu dòng hình ảnh
- tạo danh sách đa cấp bằng cách đặt độ sâu đoạn
- tạo danh sách có số
- kiểm tra và thay đổi định dạng danh sách trong một bản trình bày đã có

## **Tạo danh sách có dấu đầu dòng**

Để tạo danh sách có dấu đầu dòng, thêm các đối tượng [IParagraph](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraph/) vào một [ITextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/) và đặt [IBulletFormat.Type](https://reference.aspose.com/slides/vi/net/aspose.slides/ibulletformat/type/) thành [BulletType.Symbol](https://reference.aspose.com/slides/vi/net/aspose.slides/bullettype/). Sau đó bạn có thể đặt [IBulletFormat.Char](https://reference.aspose.com/slides/vi/net/aspose.slides/ibulletformat/char/), [IBulletFormat.Color](https://reference.aspose.com/slides/vi/net/aspose.slides/ibulletformat/color/), và [IBulletFormat.Height](https://reference.aspose.com/slides/vi/net/aspose.slides/ibulletformat/height/) để kiểm soát giao diện của dấu đầu dòng.

Đoạn mã C# dưới đây minh họa cách tạo danh sách có dấu đầu dòng trong một slide:

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

![Các dấu đầu dòng ký hiệu](symbol_bullets.png)

## **Tạo danh sách có số**

Sử dụng danh sách có số khi thứ tự các mục quan trọng. Đặt [IBulletFormat.Type](https://reference.aspose.com/slides/vi/net/aspose.slides/ibulletformat/type/) thành [BulletType.Numbered](https://reference.aspose.com/slides/vi/net/aspose.slides/bullettype/). Bạn cũng có thể chọn định dạng đánh số bằng [IBulletFormat.NumberedBulletStyle](https://reference.aspose.com/slides/vi/net/aspose.slides/ibulletformat/numberedbulletstyle/) hoặc đặt [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/vi/net/aspose.slides/ibulletformat/numberedbulletstartwith/) khi danh sách cần bắt đầu từ một giá trị khác 1.

Đoạn mã C# dưới đây cho thấy cách tạo danh sách có số trong một slide:

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

![Các dấu đầu dòng có số](numbered_bullets.png)

## **Tạo dấu đầu dòng hình ảnh**

Aspose.Slides cho phép bạn thay thế ký hiệu dấu đầu dòng thông thường bằng một hình ảnh. Dấu đầu dòng hình ảnh hoạt động tốt nhất với các hình ảnh đơn giản có thể đọc được ở kích thước nhỏ, chẳng hạn như biểu tượng hoặc các tệp PNG trong suốt nhỏ.

{{% alert color="primary" %}}
Lý tưởng nhất, nếu bạn dự định thay thế ký hiệu dấu đầu dòng thông thường bằng một hình ảnh, tốt nhất là chọn một đồ họa đơn giản với nền trong suốt. Những hình ảnh như vậy hoạt động tốt như các ký hiệu dấu đầu dòng tùy chỉnh.

Hãy nhớ rằng hình ảnh sẽ được thu nhỏ xuống kích thước rất nhỏ. Vì lý do này, chúng tôi mạnh mẽ khuyến nghị chọn một hình ảnh vẫn rõ ràng và hiệu quả về mặt thị giác khi được sử dụng làm dấu đầu dòng trong danh sách.
{{% /alert %}}

Để tạo dấu đầu dòng hình ảnh, thêm một hình ảnh vào [Presentation.Images](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/images/) và gán đối tượng hình ảnh trả về cho [IBulletFormat.Picture](https://reference.aspose.com/slides/vi/net/aspose.slides/ibulletformat/picture/). Đặt [IBulletFormat.Type](https://reference.aspose.com/slides/vi/net/aspose.slides/ibulletformat/type/) thành [BulletType.Picture](https://reference.aspose.com/slides/vi/net/aspose.slides/bullettype/) trước khi gán hình ảnh.

Giả sử chúng ta có một tập tin "image.png":

![Một hình ảnh cho các dấu đầu dòng](picture_for_bullets.png)

Đoạn mã C# dưới đây cho thấy cách tạo dấu đầu dòng hình ảnh trong một slide:

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

![Các dấu đầu dòng hình ảnh](picture_bullets.png)

## **Tạo danh sách đa cấp**

Sử dụng [IParagraphFormat.Depth](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/depth/) để đặt các mục danh sách ở các cấp độ khác nhau. Cấp độ 0 là cấp cao nhất, cấp độ 1 là cấp con của nó, và tiếp tục như vậy.

Đoạn mã C# dưới đây cho thấy cách tạo danh sách có dấu đầu dòng đa cấp:

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

Để thay đổi định dạng danh sách trong một bản trình bày hiện có, truy cập đoạn văn mục tiêu và cập nhật các cài đặt [IParagraphFormat.Bullet](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/bullet/). Các thuộc tính tương tự được sử dụng để tạo danh sách cũng có thể được dùng để kiểm tra hoặc sửa đổi danh sách được tải từ tệp PPT, PPTX hoặc ODP.

Đoạn mã C# dưới đây thay đổi đoạn văn đầu tiên trong một khung văn bản để sử dụng kiểu danh sách có số:

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

**Có thể xuất danh sách có dấu đầu dòng và có số sang PDF hoặc hình ảnh không?**

Có. Aspose.Slides giữ nguyên định dạng danh sách khi định dạng đích hỗ trợ bố cục văn bản và tính năng dấu đầu dòng tương ứng.

**Tôi có thể chỉnh sửa danh sách trong các bản trình bày hiện có không?**

Có. Tải bản trình bày, truy cập đoạn văn mục tiêu, kiểm tra hoặc cập nhật các cài đặt [IParagraphFormat.Bullet](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/bullet/), và lưu bản trình bày.

**Danh sách có thể chứa văn bản không phải chữ Latin không?**

Có. Văn bản của mục danh sách có thể chứa ký tự Unicode, vì vậy bạn có thể tạo danh sách trong các bản trình bày đa ngôn ngữ. Đảm bảo các phông chữ được sử dụng trong bản trình bày hỗ trợ các ký tự bạn cần.