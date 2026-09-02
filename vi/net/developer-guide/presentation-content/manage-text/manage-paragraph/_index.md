---
title: Quản lý các đoạn văn bản PowerPoint trong .NET
linktitle: Quản lý Đoạn văn
type: docs
weight: 40
url: /vi/net/manage-paragraph/
aliases:
  - /net/paragraph/
  - /net/portion/
keywords:
- thêm văn bản
- thêm đoạn
- quản lý văn bản
- quản lý đoạn
- quản lý dấu đầu dòng
- thụt lề đoạn
- thụt lề treo
- dấu đầu dòng đoạn
- danh sách đánh số
- danh sách có dấu đầu dòng
- thuộc tính đoạn
- nhập HTML
- văn bản sang HTML
- đoạn sang HTML
- đoạn sang hình ảnh
- văn bản sang hình ảnh
- xuất đoạn
- PowerPoint
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu cách tạo và định dạng các đoạn, phần, dấu đầu dòng, danh sách đánh số, thụt lề, nội dung HTML và hình ảnh đoạn bằng Aspose.Slides cho .NET."
---
## **Tổng quan**

Aspose.Slides for .NET biểu diễn văn bản dưới dạng một hệ thống phân cấp các khung văn bản, đoạn văn và phần:

* [ITextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/) đại diện cho vùng chứa văn bản trong một hình dạng và cung cấp quyền truy cập vào bộ sưu tập các đoạn văn.
* [IParagraph](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraph/) đại diện cho một đoạn văn trong khung văn bản và cung cấp quyền truy cập vào các phần và định dạng ở mức đoạn.
* [IPortion](https://reference.aspose.com/slides/vi/net/aspose.slides/iportion/) đại diện cho một chuỗi văn bản trong một đoạn. Mỗi phần có thể có văn bản và định dạng ký tự riêng.

Do đó, một đoạn có thể chứa văn bản với các phông chữ, màu sắc, kích thước và định dạng khác nhau bằng cách sử dụng nhiều phần.

## **Tạo và Định dạng Đoạn Văn**

### **Tạo Đoạn Văn với Nhiều Phần**

Các bước sau tạo một khung văn bản với ba đoạn, mỗi đoạn chứa ba phần:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation).
2. Truy cập tham chiếu slide tương ứng qua chỉ mục của nó.
3. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/) hình chữ nhật vào slide.
4. Truy cập [ITextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/) của hình dạng.
5. Sử dụng đoạn mặc định và thêm hai đối tượng [IParagraph](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraph/) nữa vào khung văn bản.
6. Thêm đủ các đối tượng [IPortion](https://reference.aspose.com/slides/vi/net/aspose.slides/iportion/) cho mỗi đoạn để chứa ba phần. Đoạn mặc định đã chứa một phần rỗng.
7. Đặt văn bản cho mỗi phần.
8. Áp dụng định dạng ký tự thông qua [IPortion.PortionFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/iportion/portionformat/).
9. Lưu bản trình chiếu đã chỉnh sửa.

Ví dụ C# thực hiện các bước trên:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);
var textFrame = shape.TextFrame;

var firstParagraph = textFrame.Paragraphs[0];
firstParagraph.Portions.Add(new Portion());
firstParagraph.Portions.Add(new Portion());

var secondParagraph = new Paragraph();
secondParagraph.Portions.Add(new Portion());
secondParagraph.Portions.Add(new Portion());
secondParagraph.Portions.Add(new Portion());
textFrame.Paragraphs.Add(secondParagraph);

var thirdParagraph = new Paragraph();
thirdParagraph.Portions.Add(new Portion());
thirdParagraph.Portions.Add(new Portion());
thirdParagraph.Portions.Add(new Portion());
textFrame.Paragraphs.Add(thirdParagraph);

var paragraphCount = textFrame.Paragraphs.Count;
for (var paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
{
    var paragragaph = textFrame.Paragraphs[paragraphIndex];
    var portionCount = paragragaph.Portions.Count;
    for (var portionIndex = 0; portionIndex < portionCount; portionIndex++)
    {
        var portion = paragragaph.Portions[portionIndex];
        portion.Text = $"Portion {paragraphIndex + 1}.{portionIndex + 1}";

        if (portionIndex == 0)
        {
            portion.PortionFormat.FillFormat.FillType = FillType.Solid;
            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Red;
            portion.PortionFormat.FontBold = NullableBool.True;
            portion.PortionFormat.FontHeight = 15;
        }
        else if (portionIndex == 1)
        {
            portion.PortionFormat.FillFormat.FillType = FillType.Solid;
            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;
            portion.PortionFormat.FontItalic = NullableBool.True;
            portion.PortionFormat.FontHeight = 18;
        }
    }
}

presentation.Save("paragraphs_with_portions.pptx", SaveFormat.Pptx);
```

## **Tạo Danh sách có Dấu đầu dòng và Đánh số**

### **Tạo Danh sách có Dấu đầu dòng hoặc Đánh số**

Dấu đầu dòng và đánh số giúp người đọc quét các mục liên quan dễ dàng hơn. Trong Aspose.Slides, cài đặt danh sách được xác định qua [IBulletFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/ibulletformat/).

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation).
2. Truy cập tham chiếu slide tương ứng qua chỉ mục của nó.
3. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/) vào slide đã chọn.
4. Truy cập [ITextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/) của hình dạng.
5. Xóa đoạn mặc định khỏi khung văn bản.
6. Tạo một [Paragraph](https://reference.aspose.com/slides/vi/net/aspose.slides/paragraph/) cho dấu đầu dòng kiểu ký hiệu.
7. Đặt [IBulletFormat.Type](https://reference.aspose.com/slides/vi/net/aspose.slides/ibulletformat/type/) thành [BulletType.Symbol](https://reference.aspose.com/slides/vi/net/aspose.slides/bullettype/) và chỉ định ký tự dấu đầu dòng.
8. Đặt văn bản đoạn, thụt lề, màu dấu đầu dòng và chiều cao dấu đầu dòng.
9. Thêm đoạn vào khung văn bản.
10. Tạo đoạn thứ hai và đặt [IBulletFormat.Type](https://reference.aspose.com/slides/vi/net/aspose.slides/ibulletformat/type/) thành [BulletType.Numbered](https://reference.aspose.com/slides/vi/net/aspose.slides/bullettype/).
11. Cấu hình kiểu dấu đầu dòng đánh số và thêm đoạn vào khung văn bản.
12. Lưu bản trình chiếu.

Ví dụ C# tạo một dấu đầu dòng ký hiệu và một dấu đầu dòng đánh số:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var symbolParagraph = new Paragraph { Text = "Welcome to Aspose.Slides" };
symbolParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
symbolParagraph.ParagraphFormat.Bullet.Char = Convert.ToChar(0x2022);
symbolParagraph.ParagraphFormat.Indent = 25;
symbolParagraph.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
symbolParagraph.ParagraphFormat.Bullet.Color.Color = Color.Black;
symbolParagraph.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True;
symbolParagraph.ParagraphFormat.Bullet.Height = 100;
textFrame.Paragraphs.Add(symbolParagraph);

var numberedParagraph = new Paragraph { Text = "This is a numbered item" };
numberedParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
numberedParagraph.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletCircleNumWDBlackPlain;
numberedParagraph.ParagraphFormat.Indent = 25;
numberedParagraph.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
numberedParagraph.ParagraphFormat.Bullet.Color.Color = Color.Black;
numberedParagraph.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True;
numberedParagraph.ParagraphFormat.Bullet.Height = 100;
textFrame.Paragraphs.Add(numberedParagraph);

presentation.Save("bulleted_and_numbered_list.pptx", SaveFormat.Pptx);
```

### **Sử dụng Dấu đầu dòng Hình ảnh**

Dấu đầu dòng hình ảnh cho phép bạn sử dụng một hình ảnh tùy chỉnh thay cho ký hiệu hoặc số.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation).
2. Truy cập tham chiếu slide tương ứng qua chỉ mục của nó.
3. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/) và truy cập [ITextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/) của nó.
4. Xóa đoạn mặc định khỏi khung văn bản.
5. Tải hình ảnh dấu đầu dòng và thêm nó vào bộ sưu tập hình ảnh của bản trình chiếu dưới dạng một [IPPImage](https://reference.aspose.com/slides/vi/net/aspose.slides/ippimage/).
6. Tạo một [Paragraph](https://reference.aspose.com/slides/vi/net/aspose.slides/paragraph/) và đặt văn bản cho nó.
7. Đặt [IBulletFormat.Type](https://reference.aspose.com/slides/vi/net/aspose.slides/ibulletformat/type/) thành [BulletType.Picture](https://reference.aspose.com/slides/vi/net/aspose.slides/bullettype/).
8. Gán hình ảnh qua [IBulletFormat.Picture](https://reference.aspose.com/slides/vi/net/aspose.slides/ibulletformat/picture/) và đặt chiều cao dấu đầu dòng.
9. Thêm đoạn vào khung văn bản.
10. Lưu bản trình chiếu đã chỉnh sửa.

Ví dụ C# tạo một dấu đầu dòng hình ảnh:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var bulletImage = Images.FromFile("bullets.png");
var presentationImage = presentation.Images.AddImage(bulletImage);

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph = new Paragraph { Text = "Welcome to Aspose.Slides" };
paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
paragraph.ParagraphFormat.Bullet.Picture.Image = presentationImage;
paragraph.ParagraphFormat.Bullet.Height = 100;
textFrame.Paragraphs.Add(paragraph);

presentation.Save("picture_bullet.pptx", SaveFormat.Pptx);
presentation.Save("picture_bullet.ppt", SaveFormat.Ppt);
```

### **Tạo Danh sách Đa cấp**

Đặt [IParagraphFormat.Depth](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/depth/) để đưa các đoạn vào các cấp độ khác nhau của danh sách. Cấp cao nhất có độ sâu `0`.

1. Tạo một [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) và truy cập một slide.
2. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/) và xóa đoạn mặc định khỏi khung văn bản của nó.
3. Tạo bốn đoạn và cấu hình các ký hiệu dấu đầu dòng cho chúng.
4. Đặt giá trị [IParagraphFormat.Depth](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/depth/) thành `0`, `1`, `2` và `3`.
5. Thêm các đoạn vào khung văn bản và lưu bản trình chiếu.

Ví dụ C# tạo một danh sách dấu đầu dòng bốn cấp:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "Content" };
firstParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
firstParagraph.ParagraphFormat.Bullet.Char = Convert.ToChar(0x2022);
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
firstParagraph.ParagraphFormat.Depth = 0;

var secondParagraph = new Paragraph { Text = "Second level" };
secondParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
secondParagraph.ParagraphFormat.Bullet.Char = '-';
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
secondParagraph.ParagraphFormat.Depth = 1;

var thirdParagraph = new Paragraph { Text = "Third level" };
thirdParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
thirdParagraph.ParagraphFormat.Bullet.Char = Convert.ToChar(0x2022);
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
thirdParagraph.ParagraphFormat.Depth = 2;

var fourthParagraph = new Paragraph { Text = "Fourth level" };
fourthParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
fourthParagraph.ParagraphFormat.Bullet.Char = '-';
fourthParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
fourthParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
fourthParagraph.ParagraphFormat.Depth = 3;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);
textFrame.Paragraphs.Add(thirdParagraph);
textFrame.Paragraphs.Add(fourthParagraph);

presentation.Save("multilevel_list.pptx", SaveFormat.Pptx);
```

### **Bắt đầu Mục Đánh số ở Giá trị Tùy chỉnh**

Sử dụng [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/vi/net/aspose.slides/ibulletformat/numberedbulletstartwith/) để đặt số ban đầu hiển thị cho một đoạn được đánh số.

1. Tạo một [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) và thêm một [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/) vào một slide.
2. Xóa đoạn mặc định khỏi khung văn bản của hình dạng.
3. Tạo ba đoạn đánh số.
4. Đặt [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/vi/net/aspose.slides/ibulletformat/numberedbulletstartwith/) thành `2`, `3` và `7` cho các đoạn tương ứng.
5. Thêm các đoạn vào khung văn bản và lưu bản trình chiếu.

Ví dụ C# gán số bắt đầu tùy chỉnh cho mỗi đoạn:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "Start at 2" };
firstParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
firstParagraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 2;
textFrame.Paragraphs.Add(firstParagraph);

var secondParagraph = new Paragraph { Text = "Start at 3" };
secondParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
secondParagraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 3;
textFrame.Paragraphs.Add(secondParagraph);

var thirdParagraph = new Paragraph { Text = "Start at 7" };
thirdParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
thirdParagraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 7;
textFrame.Paragraphs.Add(thirdParagraph);

presentation.Save("custom_numbered_list.pptx", SaveFormat.Pptx);
```

## **Kiểm soát Bố cục Đoạn và Thuộc tính Kết thúc**

### **Đặt Thụt lề Dòng Đầu tiên**

Sử dụng thuộc tính [IParagraphFormat.Indent](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/indent/) để kiểm soát thụt lề dòng đầu tiên của một đoạn. Thuộc tính này chỉ di chuyển dòng đầu tiên so với lề trái của đoạn. Giá trị dương đẩy dòng đầu tiên sang phải, các dòng còn lại vẫn căn theo thân đoạn.

Sử dụng [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/marginleft/) khi cần di chuyển toàn bộ đoạn. Dùng [IParagraphFormat.Indent](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/indent/) khi chỉ muốn di chuyển dòng đầu tiên.

Ví dụ dưới tạo một số đoạn và áp dụng các giá trị [IParagraphFormat.Indent](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/indent/) khác nhau để minh họa cách thụt lề dòng đầu tiên ảnh hưởng đến bố cục đoạn.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/).
2. Truy cập slide mục tiêu.
3. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/) hình chữ nhật vào slide.
4. Truy cập [ITextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/) của hình dạng và xóa đoạn mặc định.
5. Tạo một số đoạn và đặt các giá trị [Indent](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/indent/) khác nhau cho chúng.
6. Thêm các đoạn vào khung văn bản.
7. Lưu bản trình chiếu đã chỉnh sửa.

Đoạn mã này cho thấy cách đặt thụt lề đoạn:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "No first-line indent. Wrapped lines start at the same position as the first line." };
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
firstParagraph.ParagraphFormat.MarginLeft = 20;
firstParagraph.ParagraphFormat.Indent = 0;

var secondParagraph = new Paragraph { Text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body." };
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
secondParagraph.ParagraphFormat.MarginLeft = 20;
secondParagraph.ParagraphFormat.Indent = 20;

var thirdParagraph = new Paragraph { Text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see." };
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
thirdParagraph.ParagraphFormat.MarginLeft = 20;
thirdParagraph.ParagraphFormat.Indent = 40;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);
textFrame.Paragraphs.Add(thirdParagraph);

presentation.Save("paragraph_indent.pptx", SaveFormat.Pptx);
```

Kết quả:

![Thụt lề dòng đầu của các đoạn](first_line_indent.png)

### **Đặt Thụt lề Treo**

Thụt lề treo là bố cục đoạn trong đó dòng đầu tiên bắt đầu phía trái hơn các dòng còn lại. Trong Aspose.Slides, bạn tạo hiệu ứng này bằng thuộc tính [IParagraphFormat.Indent](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/indent/). Đặt `Indent` thành giá trị âm để di chuyển dòng đầu tiên sang trái so với thân đoạn.

Thực tế, [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/marginleft/) xác định vị trí bên trái của thân đoạn, còn [IParagraphFormat.Indent](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/indent/) xác định vị trí của dòng đầu tiên so với lề đó. Để tạo thụt lề treo, đặt giá trị `MarginLeft` dương và `Indent` âm.

Định dạng này hữu ích cho các mục thư mục, tài liệu tham khảo, mục glossaries và các đoạn khác mà các dòng gập cần căn dưới thân đoạn thay vì dưới ký tự đầu tiên của dòng đầu.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/).
2. Truy cập slide mục tiêu.
3. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/) hình chữ nhật vào slide.
4. Truy cập [ITextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/) của hình dạng và xóa đoạn mặc định.
5. Tạo các đoạn và đặt một giá trị [MarginLeft](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/marginleft/) dương cho mỗi đoạn.
6. Đặt giá trị [Indent](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/indent/) âm để tạo hiệu ứng thụt lề treo.
7. Thêm các đoạn vào khung văn bản.
8. Lưu bản trình chiếu đã chỉnh sửa.

Đoạn mã này cho thấy cách đặt thụt lề treo cho một đoạn:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body." };
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
firstParagraph.ParagraphFormat.MarginLeft = 40;
firstParagraph.ParagraphFormat.Indent = -20;

var secondParagraph = new Paragraph { Text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare." };
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
secondParagraph.ParagraphFormat.MarginLeft = 60;
secondParagraph.ParagraphFormat.Indent = -30;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);

presentation.Save("hanging_indent.pptx", SaveFormat.Pptx);
```

Kết quả:

![Thụt lề treo của các đoạn](hanging_indent.png)

### **Đặt Thuộc tính Kết thúc Đoạn**

Thuộc tính [IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraph/endparagraphportionformat/) kiểm soát định dạng của ký tự kết thúc đoạn. Ví dụ sau gán kích thước phông chữ và phông Latin cho ký tự kết thúc của đoạn thứ hai:

1. Tải một [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) và truy cập một slide.
2. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/) và xóa đoạn mặc định của nó.
3. Tạo hai đoạn và thêm các phần văn bản vào chúng.
4. Tạo một [PortionFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/portionformat/) cho ký tự kết thúc của đoạn thứ hai.
5. Đặt [IBasePortionFormat.FontHeight](https://reference.aspose.com/slides/vi/net/aspose.slides/ibaseportionformat/fontheight/) và [IBasePortionFormat.LatinFont](https://reference.aspose.com/slides/vi/net/aspose.slides/ibaseportionformat/latinfont/).
6. Gán định dạng cho [IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraph/endparagraphportionformat/) và lưu bản trình chiếu.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Test.pptx");
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph();
firstParagraph.Portions.Add(new Portion("Sample text"));

var secondParagraph = new Paragraph();
secondParagraph.Portions.Add(new Portion("Sample text 2"));

var endParagraphFormat = new PortionFormat();
endParagraphFormat.FontHeight = 48;
endParagraphFormat.LatinFont = new FontData("Times New Roman");
secondParagraph.EndParagraphPortionFormat = endParagraphFormat;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);

presentation.Save("end_paragraph_format.pptx", SaveFormat.Pptx);
```

## **Nhập và Xuất Nội dung Đoạn**

### **Nhập Văn bản HTML vào Đoạn**

Sử dụng [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/vi/net/aspose.slides/paragraphcollection/addfromhtml/) để chuyển đổi markup HTML thành các đoạn và phần trong một khung văn bản.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) .
2. Truy cập một slide và thêm một [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/) .
3. Truy cập [ITextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/) của hình dạng và xóa đoạn mặc định.
4. Đọc tệp HTML nguồn.
5. Chuyển chuỗi HTML cho [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/vi/net/aspose.slides/paragraphcollection/addfromhtml/) .
6. Lưu bản trình chiếu đã chỉnh sửa.

Ví dụ C# nhập HTML vào một khung văn bản:

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shapeWidth = presentation.SlideSize.Size.Width - 20;
var shapeHeight = presentation.SlideSize.Size.Height - 20;
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, shapeWidth, shapeHeight);
shape.FillFormat.FillType = FillType.NoFill;
shape.TextFrame.Paragraphs.Clear();

using var reader = new StreamReader("file.html");
var html = reader.ReadToEnd();
shape.TextFrame.Paragraphs.AddFromHtml(html);

presentation.Save("html_text.pptx", SaveFormat.Pptx);
```

### **Xuất Văn bản Đoạn ra HTML**

Sử dụng [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/vi/net/aspose.slides/paragraphcollection/exporttohtml/) để xuất một phạm vi đoạn đã chọn dưới dạng HTML.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) và tải bản trình chiếu mong muốn.
2. Truy cập slide và tìm [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/) chứa văn bản.
3. Truy cập [ITextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/) của hình dạng.
4. Gọi [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/vi/net/aspose.slides/paragraphcollection/exporttohtml/) với chỉ mục đoạn bắt đầu và số lượng đoạn cần xuất.
5. Ghi chuỗi HTML trả về vào tệp.

Ví dụ C# xuất tất cả các đoạn từ hình dạng văn bản đầu tiên:

```csharp
using System;
using System.IO;
using System.Text;
using Aspose.Slides;

using var presentation = new Presentation("ExportingHTMLText.pptx");
var shape = presentation.Slides[0].Shapes[0];

if (shape is IAutoShape textShape && textShape.TextFrame != null)
{
    var paragraphs = textShape.TextFrame.Paragraphs;
    var html = paragraphs.ExportToHtml(0, paragraphs.Count, null);
    using var writer = new StreamWriter("paragraphs.html", false, Encoding.UTF8);
    writer.Write(html);
}
else
{
    Console.WriteLine("The first shape is not a text shape.");
}
```

### **Kết xuất Đoạn dưới dạng Hình ảnh**

[IParagraph.GetImage](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraph/getimage/) kết xuất trực tiếp một đoạn riêng lẻ và trả về một [IImage](https://reference.aspose.com/slides/vi/net/aspose.slides/iimage/). Lưu kết quả vào tệp hoặc luồng bằng [IImage.Save](https://reference.aspose.com/slides/vi/net/aspose.slides/iimage/save/). Bạn không cần phải kết xuất toàn bộ hình dạng chứa hoặc cắt ảnh bitmap thủ công.

[IParagraph.GetImage](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraph/getimage/) có thể trả về `null` nếu đoạn không tồn tại trong bộ sưu tập cha, không có giới hạn kết xuất hợp lệ, hoặc không thể được kết xuất. Kiểm tra kết quả trước khi lưu và giải phóng ảnh đã trả về sau khi sử dụng.

#### **Kết xuất Đoạn ở Tỷ lệ Mặc định**

Giả sử chúng ta có một tệp trình chiếu có tên sample.pptx với một slide, trong đó hình dạng đầu tiên là một hộp văn bản chứa ba đoạn.

![Hộp văn bản với ba đoạn](paragraph_to_image_input.png)

Ví dụ dưới kết xuất đoạn thứ hai trong một hình dạng văn bản bình thường ở tỷ lệ mặc định và lưu ảnh trả về ở định dạng PNG. Lời khai báo `using` đảm bảo ảnh được giải phóng đúng cách.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var shape = presentation.Slides[0].Shapes[0];
if (shape is IAutoShape textShape && 
    textShape.TextFrame != null && 
    textShape.TextFrame.Paragraphs.Count > 1)
{
    var paragraph = textShape.TextFrame.Paragraphs[1];
    using var paragraphImage = paragraph.GetImage();

    if (paragraphImage != null)
    {
        paragraphImage.Save("paragraph.png", ImageFormat.Png);
    }
    else
    {
        Console.WriteLine("The paragraph could not be rendered.");
    }
}
else
{
    Console.WriteLine("The expected text shape or paragraph was not found.");
}
```

Kết quả:

![Hình ảnh đoạn văn bản](paragraph_to_image_output.png)

#### **Kết xuất Đoạn trong Ô Bảng với Tỷ lệ Phóng to**

Sử dụng phương thức [IParagraph.GetImage](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraph/getimage/) có tham số `float scaleX` và `float scaleY` để đặt hệ số phóng to theo chiều ngang và dọc. Ví dụ dưới tạo một bảng, kết xuất đoạn trong ô đầu tiên với độ rộng và chiều cao gấp đôi so với mặc định, và lưu kết quả dưới dạng ảnh PNG.

```csharp
using System;
using Aspose.Slides;

var scaleX = 2f;
var scaleY = 2f;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var table = slide.Shapes.AddTable(50, 50, new[] { 300d }, new[] { 80d });
var paragraph = table[0, 0].TextFrame.Paragraphs[0];
paragraph.Text = "Text in a table cell";

using var paragraphImage = paragraph.GetImage(scaleX, scaleY);
if (paragraphImage != null)
{
    paragraphImage.Save("table_paragraph.png", ImageFormat.Png);
}
else
{
    Console.WriteLine("The paragraph could not be rendered.");
}
```

Hệ số `1` giữ kích thước pixel mặc định cho trục tương ứng. Ví dụ, `2` cho cả hai hệ số tạo ra một ảnh có chiều rộng và chiều cao gần gấp đôi kích thước mặc định, tương đương bốn lần số pixel. Các hệ số lớn hơn thường cho văn bản nét hơn khi phóng to hoặc xuất ảnh độ phân giải cao, nhưng đồng thời tăng mức tiêu thụ bộ nhớ và kích thước tệp. Các hệ số nhỏ hơn `1` tạo ảnh nhỏ hơn với chi tiết ít hơn. Sử dụng các hệ số bằng nhau để giữ tỷ lệ khung hình của đoạn; các hệ số khác nhau theo chiều ngang và chiều dọc sẽ kéo dài đầu ra một cách độc lập.

Kết xuất toàn bộ hình dạng bằng [IShape.GetImage](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/getimage/) vẫn hữu ích khi đầu ra cần bao gồm màu nền, viền hoặc ngữ cảnh hình ảnh khác của hình dạng. Đối với ảnh chỉ chứa đoạn, hãy sử dụng [IParagraph.GetImage](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraph/getimage/) .

## **Câu hỏi thường gặp**

**Tôi có thể tắt hoàn toàn việc gói dòng trong khung văn bản không?**

Có. Đặt [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframeformat/wraptext/) để tắt gói dòng, vì vậy các dòng sẽ không bị ngắt ở các cạnh của khung văn bản.

**Làm thế nào để lấy giới hạn chính xác trên slide của một đoạn cụ thể?**

Sử dụng [IParagraph.GetRect](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraph/getrect/) để lấy hình chữ nhật bao quanh đoạn. [IPortion.GetRect](https://reference.aspose.com/slides/vi/net/aspose.slides/iportion/getrect/) cung cấp giới hạn của một phần riêng lẻ.

**Nơi nào kiểm soát căn chỉnh đoạn (trái, phải, giữa hoặc canh đều)?**

[IParagraphFormat.Alignment](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/alignment/) là cài đặt cấp đoạn và áp dụng cho toàn bộ đoạn bất kể định dạng của các phần riêng lẻ.

**Tôi có thể đặt ngôn ngữ kiểm tra chính tả cho một phần của đoạn không?**

Có. Đặt [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/vi/net/aspose.slides/ibaseportionformat/languageid/) cho các phần riêng lẻ, vì vậy một đoạn có thể chứa văn bản bằng nhiều ngôn ngữ.