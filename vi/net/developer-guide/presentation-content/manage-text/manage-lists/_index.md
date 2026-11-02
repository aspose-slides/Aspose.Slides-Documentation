---
title: Quản lý danh sách dạng gạch đầu dòng và đánh số trong bản trình chiếu .NET
linktitle: Quản lý danh sách
type: docs
weight: 70
url: /vi/net/manage-lists/
aliases:
  - /net/manage-bullet-and-numbered-lists/
keywords:
- dấu đầu dòng
- danh sách có dấu đầu dòng
- danh sách đánh số
- dấu đầu dòng ký hiệu
- dấu đầu dòng hình ảnh
- dấu đầu dòng tùy chỉnh
- danh sách đa cấp
- tạo dấu đầu dòng
- thêm dấu đầu dòng
- thêm danh sách
- PowerPoint
- OpenDocument
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu cách tạo và định dạng danh sách dạng gạch đầu dòng, hình ảnh, đa cấp và đánh số trong các bản trình chiếu PowerPoint và OpenDocument bằng Aspose.Slides cho .NET."
---
## **Tổng quan**

Aspose.Slides for .NET cho phép bạn tạo và định dạng danh sách dạng gạch đầu dòng và đánh số trong các bản thuyết trình PowerPoint và OpenDocument. Một mục danh sách là một đoạn văn mà cài đặt dấu đầu dòng được kiểm soát thông qua định dạng đoạn văn của nó.

Sử dụng thuộc tính [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/paragraphformat/) để truy cập cài đặt danh sách ở mức đoạn. Điểm vào chính là [IParagraphFormat.Bullet](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/bullet/), trả về một đối tượng [IBulletFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/). Với đối tượng này, bạn có thể đặt loại dấu đầu dòng, ký hiệu, hình ảnh, màu, kích thước, kiểu đánh số và số bắt đầu.

Bài viết này cho biết cách:

- tạo danh sách dạng gạch đầu dòng với ký hiệu tùy chỉnh
- tạo dấu đầu dòng là hình ảnh
- tạo danh sách đa cấp bằng cách đặt độ sâu đoạn
- tạo danh sách đánh số
- kiểm tra và thay đổi định dạng danh sách trong một bản thuyết trình hiện có
- đọc các dấu đầu dòng và số thực tế cùng với văn bản đoạn

## **Tạo danh sách dạng gạch đầu dòng**

Để tạo danh sách dạng gạch đầu dòng, thêm các đối tượng [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) vào một [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) và đặt [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) thành [BulletType.Symbol](https://reference.aspose.com/slides/net/aspose.slides/bullettype/). Sau đó bạn có thể đặt [IBulletFormat.Char](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/char/), [IBulletFormat.Color](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/color/) và [IBulletFormat.Height](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/height/) để kiểm soát diện mạo dấu đầu dòng.

Mã C# sau trình bày cách tạo danh sách dạng gạch đầu dòng trong một slide:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

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

![Các dấu chấm ký hiệu](symbol_bullets.png)

## **Tạo danh sách đánh số**

Sử dụng danh sách đánh số khi thứ tự các mục quan trọng. Đặt [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) thành [BulletType.Numbered](https://reference.aspose.com/slides/net/aspose.slides/bullettype/). Bạn cũng có thể chọn định dạng đánh số bằng [IBulletFormat.NumberedBulletStyle](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstyle/) hoặc đặt [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith/) khi danh sách cần bắt đầu từ một giá trị khác 1.

Mã C# dưới đây cho thấy cách tạo danh sách đánh số trong một slide:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

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

![Các dấu chấm đánh số](numbered_bullets.png)

## **Tạo dấu đầu dòng là hình ảnh**

Aspose.Slides cho phép bạn thay thế ký hiệu dấu đầu dòng thường bằng một hình ảnh. Dấu đầu dòng dạng hình ảnh hoạt động tốt nhất với các ảnh đơn giản vẫn đọc được ở kích thước nhỏ, chẳng hạn như biểu tượng hoặc các tệp PNG trong suốt nhỏ.

{{% alert color="info" title="Note" %}}
Nên, nếu bạn dự định thay thế ký hiệu dấu đầu dòng thường bằng một hình ảnh, tốt nhất là chọn một đồ họa đơn giản có nền trong suốt. Các hình ảnh như vậy hoạt động tốt làm ký hiệu dấu đầu dòng tùy chỉnh.

Hãy nhớ rằng hình ảnh sẽ được thu nhỏ xuống một kích thước rất nhỏ. Vì lý do này, chúng tôi khuyến cáo mạnh mẽ chọn một hình ảnh vẫn rõ ràng và hiệu quả về mặt trực quan khi được dùng làm dấu đầu dòng trong danh sách.
{{% /alert %}}

Để tạo dấu đầu dòng là hình ảnh, thêm một hình vào [Presentation.Images](https://reference.aspose.com/slides/net/aspose.slides/presentation/images/) và gán đối tượng hình trả về cho [IBulletFormat.Picture](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/picture/). Đặt [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) thành [BulletType.Picture](https://reference.aspose.com/slides/net/aspose.slides/bullettype/) trước khi gán hình.

Giả sử chúng ta có file "image.png":

![Một hình ảnh cho dấu đầu dòng](picture_for_bullets.png)

Mã C# sau cho thấy cách tạo dấu đầu dòng là hình ảnh trong một slide:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

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

![Các dấu đầu dòng dạng hình ảnh](picture_bullets.png)

## **Tạo danh sách đa cấp**

Sử dụng [IParagraphFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) để đặt các mục danh sách ở các mức độ khác nhau. Mức 0 là mức cao nhất, mức 1 lồng dưới mức 0, và tiếp tục như vậy.

Mã C# dưới đây cho thấy cách tạo danh sách gạch đầu dòng đa cấp:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

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

Để thay đổi định dạng danh sách trong một bản thuyết trình hiện có, truy cập đoạn mục tiêu và cập nhật cài đặt [IParagraphFormat.Bullet](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/bullet/) của nó. Các thuộc tính đã dùng để tạo danh sách cũng có thể dùng để kiểm tra hoặc chỉnh sửa danh sách được tải từ tệp PPT, PPTX hoặc ODP.

Mã C# dưới đây thay đổi đoạn đầu tiên trong một khung văn bản để sử dụng kiểu danh sách đánh số:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **Đọc giá trị dấu đầu dòng thực tế**

Khi trích xuất nội dung bản thuyết trình, giữ các dấu đầu dòng cùng với văn bản đoạn. Gọi [IParagraphFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/geteffective/) và truy cập [IParagraphFormatEffectiveData.Bullet](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformateffectivedata/bullet/) để lấy định dạng dấu đầu dòng thực tế. Kiểm tra [Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/type/) trước khi đọc [ActualBulletValue](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/actualbulletvalue/).

Đối với danh sách đánh số, phân biệt ba giá trị sau:

- [NumberedBulletStyle](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/numberedbulletstyle/) xác định định dạng, chẳng hạn như số Ả Rập kèm dấu chấm hoặc chữ cái viết thường kèm dấu chấm.
- [NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/numberedbulletstartwith/) chỉ định số bắt đầu cho một nhóm các đoạn đánh số.
- [ActualBulletValue](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/actualbulletvalue/) trả về dấu đầu dòng đã định dạng cho một đoạn cụ thể. Ví dụ, mục thứ hai trong danh sách bắt đầu từ 5 sẽ trả về `6.`.

Giữ [Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) cho mỗi đoạn để duy trì mức lồng nhau của nó. Dấu thực tế không mã hoá toàn bộ cấu trúc: một mục lồng nhau có thể trả về `c.` thay vì nhãn kết hợp như `6.c.`.

Ví dụ tự chứa dưới đây tạo danh sách, lưu chúng vào một bản thuyết trình và tải lại bản thuyết trình để báo cáo văn bản, độ sâu, loại dấu đầu dòng và giá trị thực tế của mỗi đoạn. Dấu hình ảnh xanh nhỏ được tạo từ SVG nội tuyến.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation())
{
    presentation.SlideSize.SetSize(720, 440, SlideSizeScaleType.DoNotScale);
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 20, 660, 400);
    shape.FillFormat.FillType = FillType.NoFill;
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;

    var textFrame = shape.TextFrame;
    textFrame.Paragraphs.Clear();

    // Tạo một dấu hình ảnh mà không cần tệp ảnh bên ngoài.
    var svg = new SvgImage("<svg xmlns='http://www.w3.org/2000/svg' width='16' height='16'><rect width='16' height='16' rx='4' fill='#0078D4'/></svg>");
    var bulletImage = presentation.Images.AddImage(svg);

    void AddParagraph(string text, short depth, BulletType type, short start = 1, NumberedBulletStyle style = NumberedBulletStyle.BulletArabicPeriod)
    {
        var paragraph = new Paragraph { Text = text };

        var format = paragraph.ParagraphFormat;
        format.Depth = depth;
        format.MarginLeft = 30 + depth * 40;
        format.Indent = -28;
        format.SpaceAfter = 8;
        format.DefaultPortionFormat.FontHeight = 22;
        format.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
        format.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
        format.Bullet.Type = type;
        format.Bullet.IsBulletHardColor = NullableBool.True;
        format.Bullet.Color.Color = Color.Black;
        if (type == BulletType.Numbered)
        {
            format.Bullet.NumberedBulletStyle = style;
            format.Bullet.NumberedBulletStartWith = start;
        }
        else if (type == BulletType.Symbol)
        {
            format.Bullet.Char = '\u2022';
        }
        else if (type == BulletType.Picture)
        {
            format.Bullet.Picture.Image = bulletImage;
        }

        textFrame.Paragraphs.Add(paragraph);
    }

    AddParagraph("First item", 0, BulletType.Numbered, 5);
    AddParagraph("Second item", 0, BulletType.Numbered, 5);
    AddParagraph("Nested item", 1, BulletType.Numbered, 3, NumberedBulletStyle.BulletAlphaLCPeriod);
    AddParagraph("Next nested item", 1, BulletType.Numbered, 3, NumberedBulletStyle.BulletAlphaLCPeriod);
    AddParagraph("Deep item", 2, BulletType.Numbered, 4, NumberedBulletStyle.BulletRomanLCPeriod);
    AddParagraph("Back to top level", 0, BulletType.Numbered, 5);
    AddParagraph("Symbol marker", 0, BulletType.Symbol);
    AddParagraph("No bullet", 0, BulletType.None);
    AddParagraph("Picture marker", 0, BulletType.Picture);
    presentation.Save("actual_bullet_values.pptx", SaveFormat.Pptx);
}

using var loadedPresentation = new Presentation("actual_bullet_values.pptx");
var loadedShape = (IAutoShape)loadedPresentation.Slides[0].Shapes[0];
Console.WriteLine("Text | Depth | Type | Actual value");
foreach (var paragraph in loadedShape.TextFrame.Paragraphs)
{
    var bullet = paragraph.ParagraphFormat.GetEffective().Bullet;
    string marker;
    switch (bullet.Type)
    {
        case BulletType.Numbered:
        case BulletType.Symbol:
            marker = bullet.ActualBulletValue;
            break;
        case BulletType.None:
            marker = $"{bullet.ActualBulletValue ?? "null"} (no bullet)";
            break;
        case BulletType.Picture:
            marker = $"{bullet.ActualBulletValue ?? "null"} (image required)";
            break;
        default:
            marker = "unsupported bullet type";
            break;
    }
    Console.WriteLine($"{paragraph.Text} | {paragraph.ParagraphFormat.Depth} | {bullet.Type} | {marker}");
}
```

Các danh sách nguồn được hiển thị dưới đây.

![Các danh sách bắt đầu từ 5, mục chữ cái lồng nhau và mục số La Mã, một dấu ký hiệu, một đoạn không có dấu đầu dòng, và một dấu hình ảnh xanh](actual_bullet_values.png)

Báo cáo khớp với các dấu hiển thị trong PowerPoint:

```text
Text | Depth | Type | Actual value
First item | 0 | Numbered | 5.
Second item | 0 | Numbered | 6.
Nested item | 1 | Numbered | c.
Next nested item | 1 | Numbered | d.
Deep item | 2 | Numbered | iv.
Back to top level | 0 | Numbered | 7.
Symbol marker | 0 | Symbol | •
No bullet | 0 | None | null (no bullet)
Picture marker | 0 | Picture | null (image required)
```

Đối với [BulletType.None và BulletType.Picture](https://reference.aspose.com/slides/net/aspose.slides/bullettype/), [ActualBulletValue](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/actualbulletvalue/) trả về `null`, không phải chuỗi rỗng. Xử lý các kiểu này riêng biệt: kiểu đầu không có dấu, trong khi kiểu ảnh yêu cầu trích xuất hình ảnh dấu đầu dòng riêng. Không thể tái tạo dấu đầu dòng dạng hình ảnh chỉ bằng cách trích xuất dấu văn bản.

## **Câu hỏi thường gặp**

**Các danh sách dạng gạch đầu dòng và đánh số có thể xuất ra PDF hoặc hình ảnh không?**

Có. Aspose.Slides giữ nguyên định dạng danh sách khi định dạng đích hỗ trợ bố cục văn bản và tính năng dấu đầu dòng tương ứng.

**Tôi có thể chỉnh sửa danh sách trong các bản thuyết trình hiện có không?**

Có. Tải bản thuyết trình, truy cập đoạn mục tiêu, kiểm tra hoặc cập nhật cài đặt [IParagraphFormat.Bullet](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/bullet/) và lưu lại bản thuyết trình.

**Danh sách có thể chứa văn bản không phải tiếng La-tinh không?**

Có. Văn bản mục danh sách có thể chứa các ký tự Unicode, vì vậy bạn có thể tạo danh sách trong các bản thuyết trình đa ngôn ngữ. Đảm bảo các phông chữ được dùng trong bản thuyết trình hỗ trợ các ký tự bạn cần.