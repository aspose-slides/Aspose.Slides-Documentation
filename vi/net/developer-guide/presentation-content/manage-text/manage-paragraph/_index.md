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
  - bản trình bày
  - .NET
  - C#
  - Aspose.Slides
description: "Tìm hiểu cách tạo và định dạng các đoạn, phần, dấu đầu dòng, danh sách đánh số, thụt lề, nội dung HTML và hình ảnh đoạn bằng Aspose.Slides cho .NET."
---
## **Tổng quan**

Aspose.Slides for .NET biểu diễn văn bản dưới dạng một cây phân cấp gồm các khung văn bản, đoạn văn và phần:

* [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) đại diện cho container văn bản trong một shape và cung cấp quyền truy cập vào bộ sưu tập các đoạn của nó.
* [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) đại diện cho một đoạn trong một khung văn bản và cung cấp quyền truy cập vào các phần và định dạng mức đoạn.
* [IPortion](https://reference.aspose.com/slides/net/aspose.slides/iportion/) đại diện cho một đoạn chạy văn bản trong một đoạn. Mỗi phần có thể có văn bản và định dạng mức ký tự riêng.

Do đó một đoạn có thể chứa văn bản với các phông chữ, màu sắc, kích thước và các định dạng khác nhau bằng cách sử dụng nhiều phần.

## **Tạo và Định dạng Đoạn**

Tạo các đoạn trong khung văn bản của shape và sử dụng các phần để định dạng các đoạn chạy văn bản riêng lẻ. Phần này cho thấy cách kết hợp nhiều phần trong mỗi đoạn và áp dụng các màu, kích thước phông chữ và kiểu dáng khác nhau.

### **Tạo Đoạn với Nhiều Phần**

Ví dụ C# sau tạo ba đoạn, mỗi đoạn chứa ba đoạn chạy văn bản trong bộ sưu tập [IParagraph.Portions](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/portions/) . Nó tái sử dụng đoạn mặc định và phần rỗng của nó, sau đó thêm các đoạn và phần còn lại. Định dạng được áp dụng qua [IPortion.PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportion/portionformat/): phần đầu tiên trong mỗi đoạn có màu đỏ, in đậm và 15 điểm; phần thứ hai có màu xanh, in nghiêng và 18 điểm. Phần thứ ba giữ nguyên định dạng mặc định:

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

## **Tạo Danh sách Đánh dấu và Đánh số**

Tổ chức văn bản đoạn thành các danh sách với ký hiệu, số hoặc hình ảnh tùy chỉnh. Các ví dụ trong phần này bao gồm định dạng dấu đầu dòng, danh sách đa cấp và số bắt đầu tùy chỉnh.

### **Tạo Danh sách Đánh dấu hoặc Đánh số**

Dấu đầu dòng và đánh số giúp việc quét các mục liên quan dễ hơn. Trong Aspose.Slides, cài đặt danh sách được định nghĩa qua [IBulletFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/).

Ví dụ C# này thêm một dấu đầu dòng ký hiệu và một mục có đánh số vào cùng một khung văn bản. [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) chọn loại dấu đầu dòng, trong khi [IBulletFormat.Char](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/char/) cung cấp ký hiệu và [IBulletFormat.NumberedBulletStyle](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstyle/) chọn kiểu đánh số. Cả hai mục đều sử dụng dấu đầu dòng màu đen với chiều cao 100% và thụt lề đoạn 25 điểm:

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

Ví dụ C# này thêm một hình ảnh vào bộ sưu tập hình ảnh của bản trình bày dưới dạng [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) và sử dụng nó làm dấu đầu dòng cho đoạn. Nó đặt [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) để sử dụng dấu đầu dòng hình ảnh và gán hình ảnh qua [IBulletFormat.Picture](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/picture/). [IBulletFormat.Height](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/height/) được đặt thành 100% để định kích thước dấu đầu dòng so với văn bản đoạn:

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

Đặt [IParagraphFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) để đặt các đoạn ở các cấp độ khác nhau của danh sách. Cấp cao nhất có độ sâu là `0`.

Ví dụ C# này gán các giá trị [IParagraphFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) từ 0 đến 3 cho bốn đoạn, tạo một cấu trúc phân cấp trong một khung văn bản. Mỗi đoạn sử dụng dấu đầu dòng ký hiệu, với [IBulletFormat.Char](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/char/) luân phiên giữa dấu đầu dòng tròn và dấu gạch nối để phân biệt các cấp bên nhau:

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

### **Bắt đầu các mục danh sách đánh số với Giá trị Tùy chỉnh**

Sử dụng [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith/) để đặt số ban đầu hiển thị cho một đoạn có đánh số.

Ví dụ C# này đặt [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) để sử dụng đánh số cho ba đoạn và gán các giá trị [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith/) là 2, 3 và 7. Giá trị bắt đầu được cấu hình riêng cho mỗi đoạn, cho phép các số hiển thị bỏ qua một số giá trị:

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

Điều chỉnh lề và thụt lề của đoạn để kiểm soát vị trí của dòng đầu và các dòng gói. Bạn cũng có thể định dạng dấu kết thúc đoạn riêng biệt so với các phần văn bản hiển thị.

### **Đặt Thụt Lề Dòng Đầu**

Sử dụng thuộc tính [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) để kiểm soát thụt lề dòng đầu của một đoạn. Thuộc tính này chỉ di chuyển dòng đầu so với lề trái của đoạn. Giá trị dương dịch dòng đầu sang phải, trong khi các dòng còn lại vẫn căn chỉnh với phần thân đoạn.

Sử dụng [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) khi bạn cần di chuyển toàn bộ đoạn. Sử dụng [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) khi bạn chỉ cần di chuyển dòng đầu.

Ví dụ sau cung cấp cho ba đoạn cùng một giá trị [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) là 20 điểm và các giá trị [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) là 0, 20 và 40 điểm. Các dòng đầu bắt đầu tại các độ lệch ngày càng lớn, trong khi các dòng gói vẫn giữ cùng lề trái:

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

### **Đặt Thụt Lề Treo**

Thụt lề treo là một bố cục đoạn trong đó dòng đầu bắt đầu ở phía trái của các dòng còn lại. Trong Aspose.Slides, bạn tạo hiệu ứng này bằng thuộc tính [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/). Đặt `Indent` thành giá trị âm để di chuyển dòng đầu sang trái so với phần thân đoạn.

Trong thực tế, [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) xác định vị trí bên trái của phần thân đoạn, và [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) xác định vị trí của dòng đầu so với lề đó. Để tạo thụt lề treo, đặt giá trị `MarginLeft` dương và giá trị `Indent` âm.

Định dạng này hữu ích cho thư mục, tài liệu tham khảo, mục từ điển, và các đoạn khác nơi các dòng gói phải căn dưới phần thân đoạn chứ không phải dưới ký tự đầu tiên của dòng đầu.

Ví dụ C# sau ghép các giá trị [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) là 40 và 60 điểm với các giá trị [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) là -20 và -30 điểm. Trong mỗi đoạn, dòng đầu bắt đầu ở phía trái của các dòng gói; đoạn thứ hai có thụt lề treo sâu hơn:

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

### **Đặt Thuộc tính Chạy Kết thúc Đoạn**

Thuộc tính [IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/endparagraphportionformat/) kiểm soát định dạng của dấu kết thúc đoạn. Ví dụ sau tạo một [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/) với [IBasePortionFormat.FontHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fontheight/) đặt thành 48 điểm và [IBasePortionFormat.LatinFont](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/latinfont/) đặt thành Times New Roman. Nó gán định dạng này cho dấu kết thúc của đoạn thứ hai, để nguyên các phần văn bản hiển thị:

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

## **Đếm Số Dòng Được Render**

Khi xem các quy tắc đoạn ảnh hưởng đến việc gói tự động và dấu chấm câu ở cuối dòng, xem [Control Line Breaking](/slides/vi/net/text-formatting/#control-line-breaking) và [Control Hanging Punctuation](/slides/vi/net/text-formatting/#control-hanging-punctuation).

Sử dụng [IParagraph.GetLinesCount](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getlinescount/) để đếm số dòng mà một đoạn chiếm sau khi bố trí văn bản, bao gồm việc gói tự động. Điều này hữu ích khi kiểm tra độ dài văn bản và bố cục trong các mẫu bản trình bày.

Đoạn là một mục trong [ITextFrame.Paragraphs](https://reference.aspose.com/slides/net/aspose.slides/itextframe/paragraphs/), và nó có thể chiếm nhiều dòng được render. Một ngắt dòng rõ ràng trong đoạn buộc một dòng mới mà không tạo đoạn mới. Gói tự động tạo các dòng dựa trên chiều rộng khả dụng mà không chèn ký tự ngắt dòng vào văn bản. Do đó, việc đếm số đoạn hoặc ký tự ngắt dòng không cho số dòng đã render.

Ví dụ sau tạo một shape văn bản, đếm số dòng của nó, thu hẹp shape, và sau đó thay thế văn bản bằng một chuỗi ngắn hơn. Ví dụ này bật [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/) và tắt [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) để chiều rộng shape kiểm soát việc gói mà không tự động thu nhỏ văn bản hoặc thay đổi kích thước shape. Mỗi phép đo sử dụng [IParagraph.GetLinesCount](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getlinescount/). Kích thước shape tính bằng điểm. Cuối cùng, ví dụ thêm một đoạn nữa và tổng hợp số dòng trên toàn bộ khung văn bản.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 200);
var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.WrapText = NullableBool.True;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;

var paragraph = textFrame.Paragraphs[0];
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 20;
paragraph.Text = "This text demonstrates how automatic wrapping changes the number of rendered lines.";
Console.WriteLine($"Original width: {paragraph.GetLinesCount()}");

shape.Width = 150;
Console.WriteLine($"Narrower shape: {paragraph.GetLinesCount()}");

paragraph.Text = "Short text.";
Console.WriteLine($"Shorter text: {paragraph.GetLinesCount()}");

var secondParagraph = new Paragraph { Text = "Another paragraph." };
secondParagraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 20;
textFrame.Paragraphs.Add(secondParagraph);

var totalLineCount = 0;
foreach (var currentParagraph in textFrame.Paragraphs)
{
    totalLineCount += currentParagraph.GetLinesCount();
}
Console.WriteLine($"Total lines in the text frame: {totalLineCount}");
```

Khi dùng văn bản và các kích thước này, thu hẹp shape làm tăng số dòng, trong khi thay thế văn bản bằng chuỗi ngắn hơn làm giảm số dòng. Số đếm chính xác có thể thay đổi tùy thuộc vào việc có sẵn phông chữ và thay thế, kích thước phông chữ, lề, thụt lề, gói và cài đặt autofit. Sử dụng phông chữ và cài đặt bố cục dự định cho môi trường mục tiêu khi kiểm tra mẫu.

Chỉ số dòng không quyết định liệu văn bản có tràn khỏi container hay không. Chiều cao khả dụng, chiều cao dòng, khoảng cách đoạn và dòng, và hành vi autofit cũng quan trọng; ngay cả một dòng duy nhất cũng có thể vượt quá chiều rộng khả dụng khi tắt gói.

## **Nhập và Xuất Nội dung Đoạn**

Sử dụng HTML để đưa văn bản vào bản trình bày hoặc xuất các đoạn hiện có để sử dụng bên ngoài. Phần này cũng cho thấy cách render các đoạn riêng lẻ dưới dạng hình ảnh, bao gồm các đoạn trong ô bảng.

### **Nhập Văn bản HTML vào Các Đoạn**

Sử dụng [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/addfromhtml/) để chuyển đổi markup HTML thành các đoạn và phần trong một khung văn bản.

Ví dụ C# này đọc HTML từ một tệp và truyền markup cho [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/addfromhtml/). Nó xóa đoạn mặc định của khung văn bản để khung chỉ chứa nội dung đã nhập. Shape hình chữ nhật để lại lề 10 điểm ở mỗi phía của slide:

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

Sử dụng [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/exporttohtml/) để xuất một phạm vi đoạn đã chọn dưới dạng HTML. Khi tái sử dụng văn bản bản trình bày trên một trang web, bạn có thể muốn giữ lại nhấn mạnh cục bộ mà không mang theo phông chữ, kích thước hoặc kiểu hộp văn bản của bản trình bày. Đặt [TextToHtmlConversionOptions.TextInheritanceLimit](https://reference.aspose.com/slides/net/aspose.slides.export/texttohtmlconversionoptions/textinheritancelimit/) để kiểm soát mức độ mà bộ xuất theo kế thừa định dạng.

Tải xuống [the sample presentation](text-inheritance.pptx) và đặt nó trong thư mục làm việc của ứng dụng. Slide đầu tiên của nó chứa một shape văn bản với văn bản "Inherited text; explicit red 18pt". Đầu vào cố ý sử dụng nhiều cấp định dạng:

- Kiểu văn bản mặc định của bản trình bày cung cấp phông Calibri và kích thước 28 pt.
- Kiểu văn bản cấp một của khung văn bản cung cấp văn bản màu xanh và in nghiêng.
- Đoạn này rõ ràng đặt văn bản in đậm.
- Phần thứ hai, "explicit red 18pt", rõ ràng đặt văn bản màu đỏ và kích thước 18 pt.

Ví dụ hoàn chỉnh sau xuất cùng các đoạn ba lần. Nó truyền [TextToHtmlConversionOptions](https://reference.aspose.com/slides/net/aspose.slides.export/texttohtmlconversionoptions/) vào phương thức xuất và ghi mỗi kết quả thành một tệp HTML UTF-8 riêng:

```csharp
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("text-inheritance.pptx");
var textShape = (IAutoShape)presentation.Slides[0].Shapes[0];

var paragraphs = textShape.TextFrame.Paragraphs;
var modes = new[] { TextInheritanceLimit.All, TextInheritanceLimit.TextBox, TextInheritanceLimit.ParagraphOnly };

foreach (var mode in modes)
{
    var options = new TextToHtmlConversionOptions { TextInheritanceLimit = mode };

    var html = paragraphs.ExportToHtml(0, paragraphs.Count, options);
    File.WriteAllText($"{mode}.html", html, Encoding.UTF8);
}
```

HTML được tạo chứa CSS sau cho phần đầu tiên, "Inherited text; ". Bảng liệt kê các khai báo liên quan; các thuộc tính được tạo khác bị bỏ qua để rõ ràng.

| Kết quả | CSS liên quan cho phần đầu tiên | Hiển thị |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | Văn bản màu xanh, in đậm, in nghiêng kích thước 28 pt trong Calibri, nếu phông chữ đó khả dụng. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | Văn bản màu xanh, in đậm, in nghiêng; trang hoặc trình duyệt bao quanh cung cấp phông chữ và kích thước. |
| `ParagraphOnly.html` | `font-weight:bold` | Văn bản in đậm; trang hoặc trình duyệt bao quanh cung cấp phông chữ, kích thước, màu và kiểu nghiêng. |

Phần thứ hai giữ lại `color:#ff0000`, `font-size:18pt`, và `font-weight:bold` trong cả ba kết quả. Nó cũng giữ lại kiểu nghiêng trong `All` và `TextBox`, nhưng không trong `ParagraphOnly`. Hạn chế kế thừa do đó không loại bỏ định dạng được gán rõ ràng cho một đoạn hoặc phần.

Mở các tệp trong cùng một trình duyệt để so sánh chúng. Trong hai chế độ bị hạn chế, các thuộc tính CSS bị bỏ qua được giải quyết bởi kiểu của trang đích hoặc mặc định của trình duyệt, vì vậy giao diện kết quả phụ thuộc vào nơi HTML được sử dụng.

### **Render một Đoạn dưới dạng Hình ảnh**

[IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) render trực tiếp một đoạn riêng lẻ và trả về một [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/). Lưu kết quả vào tệp hoặc stream bằng [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/). Bạn không cần render shape chứa hoặc cắt bitmap bằng tay.

[IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) có thể trả về `null` nếu đoạn không tìm thấy trong bộ sưu tập cha, không có giới hạn render hợp lệ, hoặc không thể render. Kiểm tra kết quả trước khi lưu và giải phóng hình ảnh trả về sau khi sử dụng.

#### **Render một Đoạn ở Tỷ lệ Mặc định**

Ví dụ sử dụng một bản trình bày có một slide, shape đầu tiên là một hộp văn bản chứa ba đoạn.

![Hộp văn bản với ba đoạn](paragraph_to_image_input.png)

Ví dụ sau chọn đoạn thứ hai ở chỉ mục 1 và gọi [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) mà không có tham số tỷ lệ. Nó kiểm tra shape có chứa đoạn yêu cầu và việc render trả về một hình ảnh trước khi gọi [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) để lưu dưới dạng PNG. Khai báo `using` giải phóng hình ảnh sau khi sử dụng.

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

![Hình ảnh đoạn](paragraph_to_image_output.png)

#### **Render một Đoạn trong Ô Bảng với Tỷ lệ**

Sử dụng phiên bản overload của [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) chấp nhận các tham số `float scaleX` và `float scaleY` để đặt hệ số tỷ lệ ngang và dọc. Ví dụ sau tạo một bảng, render đoạn trong ô đầu tiên với độ rộng và chiều cao gấp đôi mặc định, và lưu kết quả dưới dạng PNG.

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

Hệ số tỷ lệ `1` giữ trục đó ở kích thước pixel mặc định. Ví dụ, `2` cho cả hai hệ số tạo ra một hình ảnh có chiều rộng và chiều cao khoảng gấp đôi kích thước mặc định, dẫn đến bốn lần số pixel. Các hệ số lớn hơn thường tạo ra văn bản sắc nét hơn cho việc phóng to hoặc đầu ra độ phân giải cao, nhưng cũng tăng sử dụng bộ nhớ và kích thước tệp. Các hệ số dưới `1` tạo hình ảnh nhỏ hơn với ít chi tiết. Sử dụng các hệ số bằng nhau để giữ tỉ lệ khung hình của đoạn; các hệ số ngang và dọc khác nhau sẽ kéo dài đầu ra một cách độc lập.

Render toàn bộ shape bằng [IShape.GetImage](https://reference.aspose.com/slides/net/aspose.slides/ishape/getimage/) vẫn hữu ích khi đầu ra cần bao gồm nền, viền hoặc ngữ cảnh hình ảnh của shape. Đối với hình ảnh chỉ có đoạn, sử dụng [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/).

## **FAQ**

**Tôi có thể tắt hoàn toàn việc gói dòng trong một khung văn bản không?**

Đúng. Đặt [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/) để tắt gói, vì vậy các dòng không bị ngắt tại các cạnh của khung văn bản.

**Làm thế nào tôi có thể lấy giới hạn chính xác trên slide của một đoạn cụ thể?**

Sử dụng [IParagraph.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getrect/) để lấy hình chữ nhật bao quanh của đoạn. [IPortion.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iportion/getrect/) cung cấp giới hạn của một phần riêng lẻ.

**Căn chỉnh đoạn (trái, phải, giữa, hoặc căn đều) được điều khiển ở đâu?**

[IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) là cài đặt mức đoạn và áp dụng cho toàn bộ đoạn bất kể định dạng của các phần riêng lẻ. Để căn dọc các phần có kích thước phông chữ khác nhau trong mỗi dòng, xem [Align Fonts Within a Line](/slides/vi/net/text-formatting/#align-fonts-within-a-line).

**Tôi có thể đặt ngôn ngữ kiểm tra cho một phần của đoạn không?**

Đúng. Đặt [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/) cho các phần riêng lẻ, vì vậy một đoạn có thể chứa văn bản bằng nhiều ngôn ngữ.