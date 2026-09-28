---
title: Định dạng văn bản trình chiếu trong .NET
linktitle: Định dạng Văn bản
type: docs
weight: 50
url: /vi/net/text-formatting/
keywords:
- căn đoạn
- kiểu văn bản
- nền văn bản
- độ trong suốt văn bản
- khoảng cách ký tự
- thuộc tính phông chữ
- họ phông chữ
- xoay văn bản
- góc quay
- khung văn bản
- khoảng cách dòng
- thuộc tính tự động vừa
- neo khung văn bản
- tab văn bản
- ngôn ngữ mặc định
- PowerPoint
- OpenDocument
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Định dạng và tạo kiểu văn bản trong các bản trình chiếu PowerPoint và OpenDocument bằng Aspose.Slides cho .NET. Tùy chỉnh phông chữ, màu sắc, căn chỉnh và hơn nữa."
---
## **Tổng quan**

Bài viết này cho thấy cách định dạng văn bản trong các bản thuyết trình PowerPoint và OpenDocument bằng cách sử dụng Aspose.Slides cho .NET. Nó bao gồm màu nền, độ trong suốt, khoảng cách ký tự, thuộc tính phông chữ, vòng quay, khoảng cách đoạn văn, hành vi tự động vừa, neo văn bản, dừng tab và cài đặt ngôn ngữ.

Trừ khi có ghi chú ngược lại, các ví dụ sử dụng [sample.pptx](sample.pptx). Hình dạng đầu tiên trên slide đầu tiên là một hộp văn bản, và đoạn văn đầu tiên của nó chứa văn bản được hiển thị bên dưới. Cả chỉ số slide và hình dạng đều bắt đầu từ 0. Các ví dụ chọn các phần in đậm sử dụng định dạng hiệu quả, bao gồm cả định dạng in đậm kế thừa:

![Văn bản mẫu](sample_text.png)

Để tìm và làm nổi bật văn bản nguyên bản hoặc các kết quả khớp biểu thức chính quy, xem [Search and Replace Text](/slides/vi/net/search-and-replace-text/).

## **Đặt màu nền cho văn bản**

Sử dụng [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/defaultportionformat/) để đặt màu làm nổi bật mặc định cho một đoạn, hoặc sử dụng [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/vi/net/aspose.slides/ibaseportionformat/highlightcolor/) cho các phần văn bản riêng lẻ.

Ví dụ sau đặt màu làm nổi bật xám nhạt làm mặc định cho đoạn đầu tiên. Màu làm nổi bật cụ thể trên các phần riêng lẻ sẽ ưu tiên hơn mặc định này:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Đặt màu làm nổi bật cho toàn bộ đoạn.
paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
```

Kết quả:

![Đoạn văn xám](gray_paragraph.png)

Ví dụ mã dưới đây minh họa cách đặt màu nền cho **các phần văn bản có phông chữ in đậm**:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

foreach (var portion in paragraph.Portions)
{
    if (portion.PortionFormat.GetEffective().FontBold)
    {
        // Đặt màu làm nổi bật cho phần văn bản.
        portion.PortionFormat.HighlightColor.Color = Color.LightGray;
    }
}

presentation.Save("gray_text_portions.pptx", SaveFormat.Pptx);
```

Kết quả:

![Các phần văn bản xám](gray_text_portions.png)

## **Căn chỉnh đoạn văn bản**

Sử dụng [IParagraphFormat.Alignment](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/alignment/) để đặt căn chỉnh đoạn trong khung văn bản. Giá trị có thể là căn giữa, căn trái, căn phải, căn đều, v.v.

Ví dụ mã dưới đây cho thấy cách căn đoạn về **trung tâm**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Đặt căn chỉnh của đoạn thành trung tâm.
paragraph.ParagraphFormat.Alignment = TextAlignment.Center;

presentation.Save("aligned_paragraph.pptx", SaveFormat.Pptx);
```

Kết quả:

![Đoạn văn đã căn chỉnh](aligned_paragraph.png)

## **Đặt độ trong suốt cho văn bản**

Độ trong suốt của văn bản được điều khiển qua thành phần alpha của màu được gán cho [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/ibaseportionformat/fillformat/). Trong các ví dụ dưới đây, `alpha = 50` là giá trị kênh alpha ARGB trên thang 0–255, không phải là phần trăm độ trong suốt.

Ví dụ mã dưới đây cho thấy cách áp dụng độ trong suốt cho **toàn bộ đoạn**:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var alpha = 50;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Đặt màu đen bán trong suốt cho văn bản.
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
```

Kết quả:

![Đoạn văn trong suốt](transparent_paragraph.png)

Ví dụ mã sau đây cho thấy cách áp dụng độ trong suốt cho **các phần văn bản có phông chữ in đậm**:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var alpha = 50;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

foreach (var portion in paragraph.Portions)
{
    if (portion.PortionFormat.GetEffective().FontBold)
    {
        // Đặt độ trong suốt cho phần văn bản.
        portion.PortionFormat.FillFormat.FillType = FillType.Solid;
        portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);
    }
}

presentation.Save("transparent_text_portions.pptx", SaveFormat.Pptx);
```

Kết quả:

![Các phần văn bản trong suốt](transparent_text_portions.png)

## **Đặt khoảng cách ký tự cho văn bản**

Sử dụng [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/vi/net/aspose.slides/ibaseportionformat/spacing/) để mở rộng hoặc thu hẹp khoảng cách giữa các ký tự trong một hộp văn bản. Các ví dụ thêm 3 điểm khoảng cách; các giá trị âm sẽ thu hẹp văn bản.

Đoạn mã C# dưới đây cho thấy cách mở rộng khoảng cách ký tự trong **toàn bộ đoạn**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Lưu ý: Sử dụng giá trị âm để nén khoảng cách ký tự.
paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // Mở rộng khoảng cách ký tự.

presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
```

Kết quả:

![Khoảng cách ký tự trong đoạn](character_spacing_in_paragraph.png)

Ví dụ mã dưới đây cho thấy cách mở rộng khoảng cách ký tự trong **các phần văn bản có phông chữ in đậm**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

foreach (var portion in paragraph.Portions)
{
    if (portion.PortionFormat.GetEffective().FontBold)
    {
        // Lưu ý: Sử dụng giá trị âm để nén khoảng cách ký tự.
        portion.PortionFormat.Spacing = 3;  // Mở rộng khoảng cách ký tự.
    }
}

presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
```

Kết quả:

![Khoảng cách ký tự trong các phần văn bản](character_spacing_in_text_portions.png)

### **Vô hiệu hoá Kerning cho các phông chữ cụ thể**

Trong một số trường hợp, văn bản được render bởi Aspose.Slides có thể trông hơi chặt hơn so với cùng một văn bản hiển thị trong PowerPoint. Điều này có thể xảy ra vì PowerPoint có thể bỏ qua dữ liệu kerning cho một số phông chữ, ngay cả khi phông chữ chứa thông tin kerning hợp lệ và kerning đã được bật trong cài đặt PowerPoint.

Để làm cho kết quả render gần hơn với PowerPoint trong các trường hợp này, bạn có thể tắt kerning cho các phần văn bản sử dụng phông chữ bị ảnh hưởng. Đặt [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/vi/net/aspose.slides/ibaseportionformat/kerningminimalsize/) thành một giá trị lớn hơn kích thước phông chữ thực tế. Ví dụ này yêu cầu "presentation.pptx" có một hộp văn bản là hình dạng đầu tiên trên slide đầu tiên. Nó kiểm tra tên phông chữ hiệu quả, bao gồm cả phông chữ kế thừa, và thiết lập ngưỡng 100 điểm cho các phần sử dụng Roboto. Điều này sẽ tắt kerning cho các phần phù hợp có kích thước phông chữ dưới 100 điểm:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var targetFont = "Roboto";

foreach (var paragraph in autoShape.TextFrame.Paragraphs)
{
    foreach (var portion in paragraph.Portions)
    {
        var textFormat = portion.PortionFormat.GetEffective();
        
        var usesTargetFont = textFormat.LatinFont?.FontName == targetFont || 
            textFormat.EastAsianFont?.FontName == targetFont || 
            textFormat.ComplexScriptFont?.FontName == targetFont;

        if (usesTargetFont)
        {
            portion.PortionFormat.KerningMinimalSize = 100;
        }
    }
}

presentation.Save("output.pptx", SaveFormat.Pptx);
```

Đối với văn bản phù hợp dưới ngưỡng, cài đặt này ngăn kerning và có thể giúp đồng bộ việc render của Aspose.Slides với đầu ra hình ảnh của PowerPoint cho các phông chữ bị ảnh hưởng bởi hành vi đặc thù của PowerPoint này.

## **Quản lý thuộc tính phông chữ văn bản**

Thuộc tính phông chữ có thể được đặt ở mức đoạn thông qua [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/defaultportionformat/) hoặc trên các phần riêng lẻ thông qua [IPortionFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/iportionformat/).

Ví dụ sau đặt phông chữ mặc định cho đoạn đầu tiên là Times New Roman 12 điểm với định dạng in đậm, in nghiêng và gạch chân chấm. Định dạng cụ thể trên các phần riêng lẻ sẽ ưu tiên hơn các mặc định này.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Đặt thuộc tính phông chữ cho đoạn.
var portionFormat = paragraph.ParagraphFormat.DefaultPortionFormat;
portionFormat.FontHeight = 12;
portionFormat.FontBold = NullableBool.True;
portionFormat.FontItalic = NullableBool.True;
portionFormat.FontUnderline = TextUnderlineType.Dotted;
portionFormat.LatinFont = new FontData("Times New Roman");

presentation.Save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
```

Kết quả:

![Thuộc tính phông chữ cho đoạn](font_properties_for_paragraph.png)

Ví dụ sau áp dụng Times New Roman 13 điểm, định dạng in nghiêng và gạch chân chấm cho các phần có định dạng hiệu quả là in đậm:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

foreach (var portion in paragraph.Portions)
{
    if (portion.PortionFormat.GetEffective().FontBold)
    {
        // Đặt thuộc tính phông chữ cho phần văn bản.
        portion.PortionFormat.FontHeight = 13;
        portion.PortionFormat.FontItalic = NullableBool.True;
        portion.PortionFormat.FontUnderline = TextUnderlineType.Dotted;
        portion.PortionFormat.LatinFont = new FontData("Times New Roman");
    }
}

presentation.Save("font_properties_for_text_portions.pptx", SaveFormat.Pptx);
```

Kết quả:

![Thuộc tính phông chữ cho các phần văn bản](font_properties_for_text_portions.png)

## **Đặt vòng quay cho văn bản**

Sử dụng [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframeformat/textverticaltype/) để đặt hướng văn bản đã định sẵn trong một hình dạng.

Ví dụ mã sau đặt hướng văn bản trong hình dạng thành [TextVerticalType.Vertical270](https://reference.aspose.com/slides/vi/net/aspose.slides/textverticaltype/), xoay văn bản **90 độ ngược chiều kim đồng hồ**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.TextVerticalType = TextVerticalType.Vertical270;

presentation.Save("text_rotation.pptx", SaveFormat.Pptx);
```

Kết quả:

![Vòng quay văn bản](text_rotation.png)

## **Đặt vòng quay tùy chỉnh cho khung văn bản**

Sử dụng [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframeformat/rotationangle/) để đặt góc quay tùy chỉnh cho một [ITextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/).

Ví dụ mã dưới đây xoay khung văn bản 3 độ theo chiều kim đồng hồ trong hình dạng:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.RotationAngle = 3;

presentation.Save("custom_text_rotation.pptx", SaveFormat.Pptx);
```

Kết quả:

![Vòng quay văn bản tùy chỉnh](custom_text_rotation.png)

## **Đặt khoảng cách dòng cho các đoạn**

Aspose.Slides cung cấp [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/spaceafter/), [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/spacebefore/), và [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/spacewithin/) để kiểm soát khoảng cách đoạn. Các thuộc tính này được sử dụng như sau:

* Sử dụng giá trị dương để chỉ định khoảng cách dòng dưới dạng phần trăm của chiều cao dòng.
* Sử dụng giá trị âm để chỉ định khoảng cách dòng bằng điểm.

Ví dụ sau đặt khoảng cách bên trong đoạn đầu tiên là 200% chiều cao dòng (khoảng cách gấp đôi):

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

paragraph.ParagraphFormat.SpaceWithin = 200;

presentation.Save("line_spacing.pptx", SaveFormat.Pptx);
```

Kết quả:

![Khoảng cách dòng trong đoạn](line_spacing.png)

## **Kiểm soát ngắt dòng**

Định nghĩa ngắt dòng đoạn hữu ích cho các khối văn bản hẹp và các bản thuyết trình pha trộn văn bản Latin và Đông Á. Các thuộc tính sau thuộc về [IParagraphFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/), vì vậy chúng áp dụng cho toàn bộ đoạn:

- [LatinLineBreak](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/latinlinebreak/) kiểm soát quy tắc ngắt dòng Latin. Trong văn bản hỗn hợp, việc thay đổi nó cũng có thể thay đổi vị trí gói văn bản và dấu câu Đông Á liền kề.
- [EastAsianLineBreak](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/eastasianlinebreak/) kiểm soát quy tắc ngắt dòng Đông Á, bao gồm các hạn chế về ký tự ở đầu và cuối dòng.

Những quy tắc này không thay thế [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframeformat/wraptext/), cho phép tự động gói trong một khung văn bản. Chúng ảnh hưởng đến bố cục khi gói xảy ra; chúng không chèn ký tự ngắt dòng. Một ngắt dòng rõ ràng buộc một dòng mới trong đoạn mà không phụ thuộc vào độ rộng khả dụng.

Ví dụ tự chứa dưới đây tạo một khối văn bản hẹp chứa tiếng Trung và Latin. Nó đặt cả hai thuộc tính ngắt dòng một cách rõ ràng và lưu "line_breaking.pptx". Để thử nghiệm bất kỳ quy tắc nào, thay đổi giá trị của thuộc tính đó trong khi giữ các cài đặt khác không đổi. Ví dụ sử dụng Arial 24 điểm và SimSun với độ rộng khung 160 điểm và lề ngang khung văn bản bằng 0. [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframeformat/autofittype/) được đặt thành [TextAutofitType.None](https://reference.aspose.com/slides/vi/net/aspose.slides/textautofittype/) để kích thước văn bản và kích thước khung giữ nguyên.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 160, 300);
shape.FillFormat.FillType = FillType.NoFill;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.WrapText = NullableBool.True;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
textFrame.TextFrameFormat.MarginLeft = 0;
textFrame.TextFrameFormat.MarginRight = 0;

var paragraph = textFrame.Paragraphs[0];
paragraph.Text = "中文排版测试，PowerPoint 中文演示。";

var format = paragraph.ParagraphFormat;
format.Alignment = TextAlignment.Left;
format.DefaultPortionFormat.FontHeight = 24;
format.DefaultPortionFormat.LatinFont = new FontData("Arial");
format.DefaultPortionFormat.EastAsianFont = new FontData("SimSun");
format.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
format.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
format.LatinLineBreak = NullableBool.False;
format.EastAsianLineBreak = NullableBool.True;

presentation.Save("line_breaking.pptx", SaveFormat.Pptx);
```

## **Kiểm soát dấu câu treo**

[IParagraphFormat.HangingPunctuation](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/hangingpunctuation/) cho phép các dấu câu đủ điều kiện mở rộng ra ngoài mép phải của dòng văn bản thay vì chiếm dòng tiếp theo. Nó áp dụng cho toàn bộ đoạn và khác với thụt lề treo.

Ví dụ tự chứa dưới đây bật dấu câu treo trong một khung văn bản rộng 100 điểm và lưu "hanging_punctuation.pptx". Với Arial 24 điểm và lề ngang khung bằng 0, dấu chấm cuối cùng vẫn ở sau "sentence" và mở rộng ra ngoài mép phải của văn bản. Đặt thuộc tính thành [NullableBool.False](https://reference.aspose.com/slides/vi/net/aspose.slides/nullablebool/) để so sánh: với các cài đặt này, dấu chấm chiếm một dòng riêng. Việc gói được bật và tự động vừa bị tắt để giữ độ rộng khả dụng cố định.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 200);
shape.FillFormat.FillType = FillType.NoFill;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.WrapText = NullableBool.True;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
textFrame.TextFrameFormat.MarginLeft = 0;
textFrame.TextFrameFormat.MarginRight = 0;

var paragraph = textFrame.Paragraphs[0];
paragraph.Text = "Simple text, next sentence.";

var format = paragraph.ParagraphFormat;
format.Alignment = TextAlignment.Left;
format.DefaultPortionFormat.FontHeight = 24;
format.DefaultPortionFormat.LatinFont = new FontData("Arial");
format.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
format.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
format.HangingPunctuation = NullableBool.True;

presentation.Save("hanging_punctuation.pptx", SaveFormat.Pptx);
```

Không phải mọi dấu câu đều có thể treo. Các [điều kiện phông chữ và bố cục đã mô tả ở trên](#conditions-and-limitations) cũng áp dụng cho so sánh này: thay đổi phông chữ, độ rộng khả dụng, lề hoặc cài đặt tự động vừa có thể làm mất sự khác biệt nhìn thấy.

## **Đặt kiểu tự động vừa cho khung văn bản**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframeformat/autofittype/) xác định cách văn bản hành xử khi vượt quá giới hạn của container. Sử dụng nó để kiểm soát liệu văn bản sẽ thu nhỏ, tràn ra, hay tự động thay đổi kích thước hình dạng. Ví dụ sau cấu hình hình dạng để thay đổi kích thước phù hợp với văn bản và lưu kết quả vào "autofit_type.pptx".

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
```

Để đếm số dòng sau khi tự động gói và xem cách văn bản hoặc độ rộng hình dạng thay đổi kết quả, xem [Count Rendered Lines](/slides/vi/net/manage-paragraph/). Số lượng dòng một mình không cho biết văn bản có tràn ra ngoài container hay không.

## **Đặt neo cho khung văn bản**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframeformat/anchoringtype/) xác định cách văn bản được định vị theo chiều dọc bên trong một hình dạng, ví dụ, ở trên cùng, giữa hoặc dưới cùng. Ví dụ sau neo văn bản ở phía dưới của hình dạng đầu tiên và lưu kết quả vào "text_anchor.pptx".

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
```

## **Đặt tabulation cho văn bản**

Sử dụng [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/defaulttabsize/) và [IParagraphFormat.Tabs](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/tabs/) để cấu hình vị trí tab trong một đoạn. Ví dụ sau đặt khoảng cách tab mặc định là 100 điểm và thêm một vị trí tab căn trái tại 30 điểm. Các cài đặt này ảnh hưởng đến văn bản chứa ký tự tab.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];
paragraph.ParagraphFormat.DefaultTabSize = 100;
paragraph.ParagraphFormat.Tabs.Add(30, TabAlignment.Left);

presentation.Save("paragraph_tabs.pptx", SaveFormat.Pptx);
```

Kết quả:

![Các tab của đoạn](paragraph_tabs.png)

## **Đặt ngôn ngữ kiểm tra chính tả**

Aspose.Slides cung cấp [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/vi/net/aspose.slides/ibaseportionformat/languageid/), cho phép bạn đặt ngôn ngữ kiểm tra chính tả cho một phần văn bản. Ngôn ngữ kiểm tra quyết định ngôn ngữ được sử dụng cho việc kiểm tra chính tả và ngữ pháp trong PowerPoint.

Ví dụ sau yêu cầu "presentation.pptx" có một hộp văn bản là hình dạng đầu tiên trên slide đầu tiên và ít nhất một đoạn. Nó thay thế nội dung của đoạn đầu tiên bằng "1。", đặt SimSun làm phông chữ và gán ngôn ngữ kiểm tra tiếng Trung giản thể (`zh-CN`). Nó lưu kết quả vào "proofing_language.pptx":

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var font = new FontData("SimSun");

var textPortion = new Portion();
textPortion.PortionFormat.ComplexScriptFont = font;
textPortion.PortionFormat.EastAsianFont = font;
textPortion.PortionFormat.LatinFont = font;

// Đặt ngôn ngữ kiểm tra chính tả thành tiếng Trung giản thể.
textPortion.PortionFormat.LanguageId = "zh-CN";

textPortion.Text = "1。";
paragraph.Portions.Add(textPortion);

presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
```

## **Đặt ngôn ngữ mặc định**

Sử dụng [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/vi/net/aspose.slides/loadoptions/defaulttextlanguage/) để định nghĩa ngôn ngữ mặc định cho văn bản được tạo trong quá trình tải hoặc tạo một bản thuyết trình. Ví dụ sau tạo một bản thuyết trình với tiếng Anh Mỹ làm ngôn ngữ văn bản mặc định, thêm một hộp văn bản và in `en-US` cho phần văn bản đầu tiên của nó.

```cs
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];

// Thêm một hình chữ nhật mới với văn bản.
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
shape.TextFrame.Text = "Sample text";

// Kiểm tra ngôn ngữ của phần văn bản đầu tiên.
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine(portion.PortionFormat.LanguageId);
```

## **Đặt kiểu văn bản mặc định**

Để áp dụng định dạng văn bản mặc định ở mức bản thuyết trình, sử dụng [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/vi/net/aspose.slides/ipresentation/defaulttextstyle/).

Ví dụ sau đặt phông chữ in đậm 14 điểm làm mặc định cho các đoạn cấp cao nhất trong một bản thuyết trình mới và lưu nó vào "default_text_style.pptx". Văn bản có thể kế thừa các mặc định này trừ khi có định dạng cụ thể hơn ghi đè.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
// Lấy định dạng đoạn cấp cao nhất.
var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

if (paragraphFormat != null)
{
    paragraphFormat.DefaultPortionFormat.FontHeight = 14;
    paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
}

presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
```

## **Trích xuất văn bản với hiệu ứng All-Caps**

Trong PowerPoint, áp dụng hiệu ứng phông chữ **All Caps** làm cho văn bản hiển thị dưới dạng chữ hoa trên slide ngay cả khi nó được gõ bằng chữ thường. Khi bạn lấy một phần văn bản như vậy bằng Aspose.Slides, thư viện sẽ trả về văn bản chính xác như đã nhập. Để khớp với văn bản hiển thị, kiểm tra [TextCapType](https://reference.aspose.com/slides/vi/net/aspose.slides/textcaptype/) và chuyển chuỗi trả về thành chữ hoa khi giá trị là `All`.

Ví dụ này yêu cầu "sample2.pptx" có một hộp văn bản là hình dạng đầu tiên trên slide đầu tiên. Phần đầu tiên của đoạn đầu tiên chứa "Hello, Aspose!" với hiệu ứng All Caps được áp dụng, như dưới đây.

![Hiệu ứng All Caps](all_caps_effect.png)

Ví dụ mã dưới đây cho thấy cách trích xuất văn bản với hiệu ứng **All Caps** đã áp dụng:

```cs
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample2.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var textPortion = autoShape.TextFrame.Paragraphs[0].Portions[0];

Console.WriteLine($"Original text: {textPortion.Text}");

var textFormat = textPortion.PortionFormat.GetEffective();
if (textFormat.TextCapType == TextCapType.All)
{
    var text = textPortion.Text.ToUpper();
    Console.WriteLine($"All-Caps effect: {text}");
}
```

Đầu ra:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **Câu hỏi thường gặp**

**Làm thế nào để chỉnh sửa văn bản trong bảng trên slide?**

Để chỉnh sửa văn bản trong bảng trên slide, sử dụng [ITable](https://reference.aspose.com/slides/vi/net/aspose.slides/itable/). Duyệt qua các ô và cập nhật mỗi ô thông qua [ICell.TextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/icell/textframe/) và định dạng đoạn qua [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraph/paragraphformat/).

**Làm thế nào để áp dụng màu gradient cho văn bản trên slide PowerPoint?**

Để áp dụng màu gradient cho văn bản, sử dụng [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/ibaseportionformat/fillformat/). Đặt [IFillFormat.FillType](https://reference.aspose.com/slides/vi/net/aspose.slides/ifillformat/filltype/) thành [FillType.Gradient](https://reference.aspose.com/slides/vi/net/aspose.slides/filltype/) và cấu hình các điểm dừng gradient, hướng và độ trong suốt.