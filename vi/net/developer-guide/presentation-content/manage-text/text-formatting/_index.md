---
title: Định dạng Văn bản Trình chiếu trong .NET
linktitle: Định dạng Văn bản
type: docs
weight: 50
url: /vi/net/text-formatting/
keywords:
- căn chỉnh đoạn văn
- kiểu văn bản
- nền văn bản
- độ trong suốt văn bản
- khoảng cách ký tự
- thuộc tính phông chữ
- họ phông chữ
- xoay văn bản
- góc xoay
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
description: "Định dạng và tạo kiểu văn bản trong các bản trình chiếu PowerPoint và OpenDocument bằng Aspose.Slides cho .NET. Tùy chỉnh phông chữ, màu sắc, căn chỉnh và nhiều hơn nữa."
---
## **Tổng quan**

Bài viết này hướng dẫn cách định dạng văn bản trong các bản trình chiếu PowerPoint và OpenDocument bằng Aspose.Slides cho .NET. Nội dung bao gồm màu nền, độ trong suốt, khoảng cách ký tự, thuộc tính phông chữ, xoay, khoảng cách đoạn văn, hành vi tự động vừa, neo văn bản, dấu tab và cài đặt ngôn ngữ.

Trừ khi có ghi chú khác, các ví dụ sử dụng [sample.pptx](sample.pptx). Đối tượng hình dạng đầu tiên trên slide đầu tiên là một hộp văn bản, và đoạn văn đầu tiên của nó chứa văn bản được hiển thị bên dưới. Cả chỉ số slide và hình dạng đều bắt đầu từ 0. Các ví dụ chọn phần in đậm sử dụng định dạng hiệu quả, bao gồm cả định dạng in đậm được kế thừa:

![Văn bản mẫu](sample_text.png)

Để tìm và làm nổi bật văn bản nguyên mẫu hoặc các khớp biểu thức chính quy, xem [Search and Replace Text](/slides/vi/net/search-and-replace-text/).

## **Đặt Màu Nền Văn Bản**

Sử dụng [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) để đặt màu tô sáng mặc định cho một đoạn văn, hoặc sử dụng [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/highlightcolor/) cho các phần văn bản riêng lẻ.

Ví dụ sau đặt màu tô sáng xám nhạt làm mặc định cho đoạn văn đầu tiên. Màu tô sáng rõ ràng trên các phần riêng lẻ sẽ ưu tiên hơn mặc định này:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Đặt màu nổi bật cho toàn bộ đoạn văn.
paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
```

Kết quả:

![Đoạn văn màu xám](gray_paragraph.png)

Ví dụ mã dưới đây minh họa cách đặt màu nền cho **các phần văn bản có phông in đậm**:

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
        // Đặt màu nổi bật cho phần văn bản.
        portion.PortionFormat.HighlightColor.Color = Color.LightGray;
    }
}

presentation.Save("gray_text_portions.pptx", SaveFormat.Pptx);
```

Kết quả:

![Các phần văn bản màu xám](gray_text_portions.png)

## **Căn chỉnh Đoạn Văn Bản**

Sử dụng [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) để đặt căn chỉnh đoạn văn trong một khung văn bản. Giá trị có thể là căn giữa, căn lề trái, căn lề phải, căn đều, v.v.

Ví dụ mã sau cho thấy cách căn đoạn văn về **giữa**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Đặt căn chỉnh của đoạn văn thành trung tâm.
paragraph.ParagraphFormat.Alignment = TextAlignment.Center;

presentation.Save("aligned_paragraph.pptx", SaveFormat.Pptx);
```

Kết quả:

![Đoạn văn đã căn chỉnh](aligned_paragraph.png)

## **Căn chỉnh Phông Chữ trong một Dòng**

Sử dụng [IParagraphFormat.FontAlignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/fontalignment/) để căn chỉnh dọc các phần văn bản có kích thước phông chữ khác nhau trong một dòng. Cài đặt này áp dụng cho toàn bộ đoạn văn và kiểm soát căn chỉnh trong mỗi dòng của nó.

Ví dụ độc lập sau tạo bốn hộp văn bản có nhãn trên một slide. Mỗi đoạn văn chứa cùng một văn bản ở kích thước 18, 36 và 54 điểm, với căn chỉnh phông chữ khác nhau. Ví dụ này dùng Arial, tắt tự động vừa và ngắt dòng, đồng thời giữ khung văn bản đủ rộng cho một dòng duy nhất.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var alignments = new[] { FontAlignment.Baseline, FontAlignment.Top, FontAlignment.Center, FontAlignment.Bottom };
var fontSizes = new[] { 18f, 36f, 54f };

for (var i = 0; i < alignments.Length; i++)
{
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 20 + i * 130, 660, 120);
    shape.FillFormat.FillType = FillType.NoFill;
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;

    var textFrame = shape.TextFrame;
    textFrame.TextFrameFormat.AnchoringType = TextAnchorType.Top;
    textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
    textFrame.TextFrameFormat.WrapText = NullableBool.False;

    var label = textFrame.Paragraphs[0];
    label.Text = alignments[i].ToString();
    label.ParagraphFormat.Alignment = TextAlignment.Left;
    label.ParagraphFormat.DefaultPortionFormat.FontHeight = 14;
    label.ParagraphFormat.DefaultPortionFormat.LatinFont = new FontData("Arial");
    label.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    label.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;

    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.FontAlignment = alignments[i];
    paragraph.ParagraphFormat.Alignment = TextAlignment.Left;
    paragraph.ParagraphFormat.DefaultPortionFormat.LatinFont = new FontData("Arial");
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

    foreach (var fontSize in fontSizes)
    {
        var portion = new Portion("Ag ");
        portion.PortionFormat.FontHeight = fontSize;
        paragraph.Portions.Add(portion);
    }

    textFrame.Paragraphs.Add(paragraph);
}

presentation.Save("font_alignment.pptx", SaveFormat.Pptx);
```

Kết quả:

![So sánh căn baseline, top, center và bottom với các kích thước phông chữ hỗn hợp](font_alignment.png)

Căn chỉnh phông chữ sử dụng các chỉ số đo phông, vì vậy mép hiển thị của các ký tự riêng lẻ không nhất thiết phải khớp hoàn toàn. Ví dụ bao gồm một ký tự in hoa và một ký tự có phần đáy (descender) để minh họa sự khác biệt giữa căn baseline và bottom. Sự sẵn có và việc thay thế phông, các ký tự được dùng, và sự khác biệt về kích thước phông đều ảnh hưởng tới kết quả. Kích thước khung, lề, khoảng cách dòng, ngắt dòng và tự động vừa cũng ảnh hưởng tới bố cục; hãy dùng cùng phông và cùng cài đặt bố trí khi so sánh các chế độ.

Cài đặt này khác với [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/), điều khiển căn chỉnh ngang của đoạn văn, và [ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/), định vị khối văn bản dọc trong hình dạng. Định dạng chỉ số trên và chỉ số dưới qua [IBasePortionFormat.Escapement](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/escapement/) di chuyển các phần riêng lẻ so với baseline thay vì thiết lập căn chỉnh phông cho các dòng của đoạn văn.

## **Đặt Độ Trong Suốt cho Văn Bản**

Độ trong suốt của văn bản được điều khiển qua thành phần alpha của màu được gán cho [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/). Trong các ví dụ dưới, `alpha = 50` là giá trị kênh alpha ARGB trên thang 0–255, không phải là phần trăm trong suốt.

Ví dụ mã dưới đây cho thấy cách áp dụng độ trong suốt cho **toàn bộ đoạn văn**:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var alpha = 50;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Đặt màu nền đen bán trong suốt cho văn bản.
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
```

Kết quả:

![Đoạn văn trong suốt](transparent_paragraph.png)

Ví dụ mã sau cho thấy cách áp dụng độ trong suốt cho **các phần văn bản có phông in đậm**:

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

## **Đặt Khoảng cách Ký tự cho Văn Bản**

Sử dụng [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/spacing/) để mở rộng hoặc co lại khoảng cách giữa các ký tự trong một hộp văn bản. Các ví dụ thêm 3 điểm khoảng cách; giá trị âm sẽ làm văn bản gọn lại.

Mã C# sau cho thấy cách mở rộng khoảng cách ký tự trong **toàn bộ đoạn văn**:

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

![Khoảng cách ký tự trong đoạn văn](character_spacing_in_paragraph.png)

Ví dụ mã dưới đây cho thấy cách mở rộng khoảng cách ký tự trong **các phần văn bản có phông in đậm**:

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

### **Vô hiệu hoá Kerning cho Các Phông Chữ Cụ Thể**

Trong một số trường hợp, văn bản được render bởi Aspose.Slides có thể trông hơi chặt hơn so với cùng văn bản hiển thị trong PowerPoint. Điều này có thể xảy ra vì PowerPoint có thể bỏ qua dữ liệu kerning cho một số phông, ngay cả khi phông chứa thông tin kerning hợp lệ và kerning được bật trong cài đặt PowerPoint.

Để đầu ra render gần hơn với PowerPoint trong các trường hợp như vậy, bạn có thể vô hiệu hoá kerning cho các phần văn bản dùng phông bị ảnh hưởng. Đặt [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/kerningminimalsize/) thành một giá trị lớn hơn kích thước phông thực tế. Ví dụ này yêu cầu “presentation.pptx” với một hộp văn bản là hình dạng đầu tiên trên slide đầu tiên. Nó kiểm tra các tên phông hiệu quả, bao gồm các phông kế thừa, và đặt ngưỡng 100 điểm cho các phần sử dụng Roboto. Điều này vô hiệu hoá kerning cho các phần khớp có kích thước phông dưới 100 điểm:

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

Đối với văn bản khớp dưới ngưỡng, cài đặt này ngăn kerning và có thể giúp kết quả render của Aspose.Slides gần hơn với đầu ra trực quan của PowerPoint cho các phông bị ảnh hưởng bởi hành vi đặc thù của PowerPoint.

## **Quản lý Thuộc tính Phông chữ Văn Bản**

Thuộc tính phông chữ có thể được đặt ở mức đoạn văn thông qua [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) hoặc trên các phần riêng lẻ thông qua [IPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/).

Ví dụ sau đặt phông mặc định cho đoạn văn đầu tiên là Times New Roman 12 điểm, in đậm, in nghiêng và gạch chân chấm. Định dạng rõ ràng trên các phần riêng lẻ sẽ ưu tiên hơn các mặc định này:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Đặt các thuộc tính phông chữ cho đoạn văn.
var portionFormat = paragraph.ParagraphFormat.DefaultPortionFormat;
portionFormat.FontHeight = 12;
portionFormat.FontBold = NullableBool.True;
portionFormat.FontItalic = NullableBool.True;
portionFormat.FontUnderline = TextUnderlineType.Dotted;
portionFormat.LatinFont = new FontData("Times New Roman");

presentation.Save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
```

Kết quả:

![Thuộc tính phông cho đoạn văn](font_properties_for_paragraph.png)

Ví dụ sau áp dụng Times New Roman 13 điểm, định dạng nghiêng và gạch chân chấm cho các phần mà định dạng hiệu quả là in đậm:

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
        // Đặt các thuộc tính phông chữ cho phần văn bản.
        portion.PortionFormat.FontHeight = 13;
        portion.PortionFormat.FontItalic = NullableBool.True;
        portion.PortionFormat.FontUnderline = TextUnderlineType.Dotted;
        portion.PortionFormat.LatinFont = new FontData("Times New Roman");
    }
}

presentation.Save("font_properties_for_text_portions.pptx", SaveFormat.Pptx);
```

Kết quả:

![Thuộc tính phông cho các phần văn bản](font_properties_for_text_portions.png)

## **Kiểm soát Chuẩn hoá Chiều cao Văn Bản**

Sử dụng [IBasePortionFormat.NormaliseHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/normaliseheight/) khi sao chép kiểu chữ mẫu hoặc nghiên cứu sự khác biệt về chiều cao ký tự. Trong PowerPoint, bật chuẩn hoá sẽ kéo hoặc nén các ký tự riêng lẻ theo chiều dọc để chúng có chiều cao hiển thị đồng nhất trong phần văn bản. Điều này không đảm bảo các đoạn văn có chiều cao văn bản bằng nhau giữa các phông chữ khác nhau.

Đặt thuộc tính này thành [NullableBool.True or False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) để bật hoặc tắt chuẩn hoá một cách rõ ràng. `NullableBool.NotDefined` để lại cài đặt cục bộ chưa xác định, cho phép phần kế thừa giá trị, ví dụ từ [DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) của đoạn văn. Nó không đồng nghĩa với `False`. Sử dụng [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/) và đọc [IBasePortionFormatEffectiveData.NormaliseHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformateffectivedata/normaliseheight/) để lấy giá trị Boolean đã giải quyết.

Ví dụ độc lập sau yêu cầu **Arial** được cài đặt. Nó tạo hai khối văn bản chứa cùng các chữ in hoa, chữ thường, các ký tự có phần đáy và các ký tự có dấu ở kích thước 54 điểm. Cả hai đoạn văn đều bật chuẩn hoá theo mặc định. Phần trên tắt chuẩn hoá một cách rõ ràng; phần dưới kế thừa nó. Kích thước khung, lề và khoảng cách đoạn văn đều giống nhau, với việc ngắt dòng và tự động vừa bị tắt để duy trì so sánh nhất quán. Ví dụ in ra `False: False` và `NotDefined: True`, sau đó lưu “text_height_normalization.pptx”.

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var settings = new[] { NullableBool.False, NullableBool.NotDefined };

for (var i = 0; i < settings.Length; i++)
{
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 60 + i * 200, 660, 150);
    shape.FillFormat.FillType = FillType.NoFill;
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;

    var textFrame = shape.TextFrame;
    textFrame.Text = "Hxgjpq ÅÉ 0123";
    textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
    textFrame.TextFrameFormat.WrapText = NullableBool.False;
    textFrame.TextFrameFormat.AnchoringType = TextAnchorType.Top;
    textFrame.TextFrameFormat.MarginTop = 0;
    textFrame.TextFrameFormat.MarginLeft = 0;

    var paragraph = textFrame.Paragraphs[0];
    paragraph.ParagraphFormat.Alignment = TextAlignment.Left;
    paragraph.ParagraphFormat.SpaceBefore = 0;
    paragraph.ParagraphFormat.SpaceAfter = 0;
    paragraph.ParagraphFormat.SpaceWithin = 100;
    paragraph.ParagraphFormat.DefaultPortionFormat.NormaliseHeight = NullableBool.True;

    var portion = paragraph.Portions[0];
    portion.PortionFormat.LatinFont = new FontData("Arial");
    portion.PortionFormat.FontHeight = 54;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.NormaliseHeight = settings[i];

    Console.WriteLine($"{settings[i]}: {portion.PortionFormat.GetEffective().NormaliseHeight}");
}

presentation.Save("text_height_normalization.pptx", SaveFormat.Pptx);
```

So sánh dưới đây được xuất từ bản trình chiếu đã lưu. Hàng trên có chuẩn hoá tắt (`False`); hàng dưới kế thừa cài đặt bật (`NotDefined` → `True`). Giữ Arial được cài đặt để tái tạo giao diện này.

![Văn bản Arial 54 điểm với chuẩn hoá tắt ở trên và chuẩn hoá kế thừa bật ở dưới](text_height_normalization.png)

Chuẩn hoá thay đổi chiều cao ký tự mà không thay đổi giá trị [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fontheight/) đã gán, giá trị này chỉ định kích thước phông bằng điểm. Thuộc tính [SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/) của đoạn văn kiểm soát khoảng cách dòng, trong khi [AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) của khung văn bản kiểm soát cách văn bản hoặc container của nó điều chỉnh để vừa. Các cài đặt này phục vụ các mục đích khác nhau và có thể ảnh hưởng đến bố cục tổng thể một cách độc lập. Để tìm hiểu thêm về định dạng đoạn văn và kế thừa, xem [Manage Paragraph](/slides/vi/net/manage-paragraph/).

## **Áp dụng và Xóa Gạch Ngang**

Sử dụng [IBasePortionFormat.StrikethroughType](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/strikethroughtype/) trên một phần văn bản để hiển thị các sửa đổi, từ bị hủy hoặc giá cũ mà không xóa bỏ văn bản gốc. Đặt nó thành [TextStrikethroughType.Single or Double](https://reference.aspose.com/slides/net/aspose.slides/textstrikethroughtype/) để có một hoặc hai đường kẻ xuyên qua văn bản.

Để xóa gạch ngang, gán `TextStrikethroughType.None`. Điều này tắt hiệu ứng một cách rõ ràng, ngay cả khi định dạng bao quanh chỉ định gạch ngang. Ngược lại, `TextStrikethroughType.NotDefined` để lại cài đặt cục bộ không xác định, cho phép phần kế thừa định dạng, ví dụ từ đoạn văn. Nó không đảm bảo gạch ngang bị xóa. Sử dụng [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/) để đọc định dạng kết quả, bao gồm các giá trị kế thừa.

Ví dụ độc lập sau tạo ba so sánh giá. Mỗi đoạn văn có các phần riêng cho nhãn, giá cũ và giá hiện tại, vì vậy chỉ giá cũ bị ảnh hưởng. Hàng trên áp dụng và sau đó xóa gạch ngang; các hàng còn lại giữ gạch ngang đơn và gạch ngang đôi. Thay đổi thuộc tính này giữ nguyên văn bản và các định dạng khác, bao gồm giá cũ in đậm.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 620, 220);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.NoFill;
shape.TextFrame.Paragraphs.Clear();

var labels = new[] { "None: ", "Single: ", "Double: " };

foreach (var label in labels)
{
    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.Alignment = TextAlignment.Left;
    paragraph.ParagraphFormat.SpaceAfter = 20;

    var format = paragraph.ParagraphFormat.DefaultPortionFormat;
    format.FontHeight = 28;
    format.LatinFont = new FontData("Arial");
    format.FillFormat.FillType = FillType.Solid;
    format.FillFormat.SolidFillColor.Color = Color.Black;

    paragraph.Portions.Add(new Portion(label));

    var previousPrice = new Portion("$100");
    previousPrice.PortionFormat.FontBold = NullableBool.True;
    paragraph.Portions.Add(previousPrice);
    paragraph.Portions.Add(new Portion(" → $80"));
    
    shape.TextFrame.Paragraphs.Add(paragraph);
}

var paragraphs = shape.TextFrame.Paragraphs;

// Áp dụng gạch ngang, sau đó xóa bỏ một cách rõ ràng nó khỏi giá trước đầu tiên.
paragraphs[0].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Single;
paragraphs[0].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.None;

paragraphs[1].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Single;
paragraphs[2].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Double;

presentation.Save("strikethrough.pptx", SaveFormat.Pptx);
```

Kết quả, từ trên xuống dưới: không có gạch ngang, gạch ngang đơn và gạch ngang đôi.

![Giá trước không gạch ngang, gạch ngang đơn và gạch ngang đôi](strikethrough.png)

## **Đặt Xoay Văn Bản**

Sử dụng [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/textverticaltype/) để đặt một hướng văn bản định sẵn trong một hình dạng.

Ví dụ mã sau đặt hướng văn bản trong hình dạng thành [TextVerticalType.Vertical270](https://reference.aspose.com/slides/net/aspose.slides/textverticaltype/), làm xoay văn bản **90 độ ngược chiều kim đồng hồ**:

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

![Xoay văn bản](text_rotation.png)

## **Đặt Xoay Tùy chỉnh cho Khung Văn Bản**

Sử dụng [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/rotationangle/) để đặt góc xoay tùy chỉnh cho một [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/).

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

![Xoay tùy chỉnh văn bản](custom_text_rotation.png)

## **Đặt Khoảng cách Dòng của Đoạn Văn**

Aspose.Slides cung cấp [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spaceafter/), [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacebefore/), và [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/) để kiểm soát khoảng cách đoạn văn. Các thuộc tính này được sử dụng như sau:

* Dùng giá trị dương để chỉ định khoảng cách dòng theo phần trăm chiều cao dòng.
* Dùng giá trị âm để chỉ định khoảng cách dòng bằng điểm.

Ví dụ sau đặt khoảng cách trong đoạn văn đầu tiên thành 200% chiều cao dòng (gấp đôi):

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

![Khoảng cách dòng trong đoạn văn](line_spacing.png)

## **Kiểm soát Ngắt Dòng**

Quy tắc ngắt dòng của đoạn văn hữu ích trong các khối văn bản hẹp và các bản trình chiếu trộn văn bản Latin và Đông Á. Các thuộc tính sau thuộc về [IParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/), do đó chúng áp dụng cho toàn bộ đoạn văn:

- [LatinLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/latinlinebreak/) kiểm soát quy tắc ngắt dòng Latin. Trong văn bản hỗn hợp, thay đổi thuộc tính này cũng có thể thay đổi vị trí ngắt của văn bản Đông Á và dấu câu kề nhau.
- [EastAsianLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/eastasianlinebreak/) kiểm soát quy tắc ngắt dòng Đông Á, bao gồm các hạn chế về ký tự ở đầu và cuối dòng.

Các quy tắc này không thay thế [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/), thuộc tính này bật tự động ngắt dòng trong một khung văn bản. Chúng ảnh hưởng tới bố cục khi ngắt dòng xảy ra; chúng không chèn ký tự ngắt dòng. Một ký tự ngắt dòng rõ ràng buộc một dòng mới trong đoạn văn mà không phụ thuộc vào độ rộng hiện có.

Ví dụ độc lập sau tạo một khối văn bản hẹp chứa tiếng Trung và Latin. Nó đặt cả hai thuộc tính ngắt dòng một cách rõ ràng và lưu “line_breaking.pptx”. Để thử nghiệm mỗi quy tắc, thay đổi giá trị của thuộc tính đó trong khi giữ các cài đặt khác cố định. Ví dụ dùng Arial 24 điểm và SimSun, khung rộng 160 điểm và không có lề ngang cho khung văn bản. [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) được đặt thành [TextAutofitType.None](https://reference.aspose.com/slides/net/aspose.slides/textautofittype/) để kích thước văn bản và khung không thay đổi.

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

## **Kiểm soát Dấu câu Treo**

[IParagraphFormat.HangingPunctuation](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/hangingpunctuation/) cho phép các dấu câu đủ điều kiện mở rộng ra ngoài mép phải của dòng văn bản thay vì chiếm dòng tiếp theo. Thuộc tính này áp dụng cho toàn bộ đoạn văn và khác với thụt vào treo.

Ví dụ độc lập sau bật dấu câu treo trong một khung văn bản rộng 100 điểm và lưu “hanging_punctuation.pptx”. Với Arial 24 điểm và không có lề ngang cho khung, dấu chấm cuối cùng ở sau “sentence” và mở rộng ra ngoài mép phải. Đặt thuộc tính thành [NullableBool.False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) để so sánh: với cài đặt này, dấu chấm chiếm một dòng riêng. Ngắt dòng được bật và tự động vừa bị tắt để giữ độ rộng khả dụng cố định.

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

Không phải mọi dấu câu đều có thể treo. Các [điều kiện phông và bố cục được mô tả ở trên](#control-line-breaking) cũng áp dụng cho so sánh này: thay đổi phông, độ rộng khả dụng, lề hoặc cài đặt tự động vừa có thể làm mất sự khác biệt hiển thị.

## **Đặt Kiểu Tự động vừa cho Khung Văn Bản**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) quyết định cách văn bản hành xử khi vượt quá giới hạn của container. Dùng nó để kiểm soát văn bản co lại, tràn ra, hay tự động thay đổi kích thước hình dạng. Ví dụ sau cấu hình hình dạng để tự động thay đổi kích thước phù hợp với văn bản và lưu kết quả thành “autofit_type.pptx”.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
```

Để đếm số dòng sau khi tự động ngắt và xem cách văn bản hoặc chiều rộng hình dạng thay đổi kết quả, xem [Count Rendered Lines](/slides/vi/net/manage-paragraph/). Số dòng chỉ cho biết có hay không có văn bản tràn container.

## **Đặt Neo cho Khung Văn Bản**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/) xác định cách văn bản được định vị dọc trong một hình dạng, ví dụ ở trên, giữa hoặc dưới. Ví dụ sau neo văn bản vào phía dưới hình dạng đầu tiên và lưu kết quả thành “text_anchor.pptx”.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
```

## **Đặt Tab cho Văn Bản**

Sử dụng [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaulttabsize/) và [IParagraphFormat.Tabs](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/tabs/) để cấu hình dấu tab trong một đoạn văn. Ví dụ sau đặt khoảng cách tab mặc định là 100 điểm và thêm một dấu tab căn lề trái ở 30 điểm. Các cài đặt này ảnh hưởng tới văn bản có chứa ký tự tab.

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

![Các dấu tab của đoạn văn](paragraph_tabs.png)

## **Đặt Ngôn ngữ Kiểm tra Chính tả**

Aspose.Slides cung cấp [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/), cho phép bạn đặt ngôn ngữ kiểm tra chính tả cho một phần văn bản. Ngôn ngữ này quyết định ngôn ngữ được dùng cho kiểm tra chính tả và ngữ pháp trong PowerPoint.

Ví dụ sau yêu cầu “presentation.pptx” với một hộp văn bản là hình dạng đầu tiên trên slide đầu tiên và có ít nhất một đoạn văn. Nó thay thế nội dung của đoạn văn đầu tiên bằng “1。”, đặt SimSun làm phông, và gán ngôn ngữ kiểm tra tiếng Trung giản thể (`zh-CN`). Lưu kết quả thành “proofing_language.pptx”:

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

### **Sao chép Siêu dữ liệu Ngôn ngữ**

Khi sao chép văn bản đa ngôn ngữ từ một mẫu, bảo tồn cả [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/) và [IBasePortionFormat.AlternativeLanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/alternativelanguageid/). Ví dụ độc lập sau tạo một phần nguồn với tiếng Anh Mỹ làm ngôn ngữ và tiếng Pháp làm ngôn ngữ thay thế, sau đó sao chép văn bản và các định danh vào một phần trong bản trình chiếu mới.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var source = new Portion("Hello! Bonjour!");
source.PortionFormat.LanguageId = "en-US";
source.PortionFormat.AlternativeLanguageId = "fr-FR";

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 80);
var paragraph = shape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var destination = new Portion();
destination.Text = source.Text;
destination.PortionFormat.LanguageId = source.PortionFormat.LanguageId;
// Nếu nguồn không có ngôn ngữ thay thế, null sẽ xóa giá trị đích.
destination.PortionFormat.AlternativeLanguageId = source.PortionFormat.AlternativeLanguageId;
paragraph.Portions.Add(destination);

presentation.Save("copied_language_metadata.pptx", SaveFormat.Pptx);
```

Để thử nghiệm nguồn không có ngôn ngữ thay thế, bỏ qua việc gán `"fr-FR"`. Khi đó định danh thay thế sẽ là `null`, và câu lệnh sao chép vẫn giữ nguyên trạng thái không có ngôn ngữ thay thế mà không tạo giá trị mặc định, ngay cả khi đích trước đó đã có ngôn ngữ thay thế được gán.

Các định danh này được lưu trữ như siêu dữ liệu ngôn ngữ. Bảo tồn chúng không quyết định từ điển nào PowerPoint sẽ chọn cho kiểm tra chính tả hoặc ngữ pháp.

## **Đặt Ngôn ngữ Mặc định**

Sử dụng [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/defaulttextlanguage/) để định nghĩa ngôn ngữ mặc định cho văn bản được tạo khi tải hoặc tạo bản trình chiếu. Ví dụ sau tạo một bản trình chiếu với tiếng Anh Mỹ làm ngôn ngữ văn bản mặc định, thêm một hộp văn bản và in ra `en-US` cho phần văn bản đầu tiên.

```cs
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];

// Thêm một hình chữ nhật mới có văn bản.
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
shape.TextFrame.Text = "Sample text";

// Kiểm tra ngôn ngữ của phần đầu tiên.
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine(portion.PortionFormat.LanguageId);
```

## **Đặt Kiểu Văn Bản Mặc định**

Để áp dụng định dạng văn bản mặc định ở mức bản trình chiếu, sử dụng [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/defaulttextstyle/).

Ví dụ sau đặt phông 14 điểm, in đậm làm mặc định cho các đoạn văn cấp cao nhất trong một bản trình chiếu mới và lưu thành “default_text_style.pptx”. Văn bản có thể kế thừa các mặc định này trừ khi có định dạng cụ thể hơn ghi đè.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
// Lấy định dạng đoạn văn cấp cao nhất.
var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

if (paragraphFormat != null)
{
    paragraphFormat.DefaultPortionFormat.FontHeight = 14;
    paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
}

presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
```

## **Trích xuất Văn bản với Hiệu ứng Chữ HOA**

Trong PowerPoint, áp dụng hiệu ứng **All Caps** làm cho văn bản hiển thị ở dạng chữ hoa trên slide ngay cả khi nó được gõ bằng chữ thường. Khi bạn lấy phần văn bản như vậy bằng Aspose.Slides, thư viện trả về văn bản chính xác như đã nhập. Để khớp với văn bản hiển thị, kiểm tra [TextCapType](https://reference.aspose.com/slides/net/aspose.slides/textcaptype/) và chuyển chuỗi trả về thành chữ hoa khi giá trị là `All`.

Ví dụ này yêu cầu “sample2.pptx” với một hộp văn bản là hình dạng đầu tiên trên slide đầu tiên. Phần đầu tiên của đoạn văn đầu tiên chứa “Hello, Aspose!” với hiệu ứng All Caps được áp dụng, như hình dưới.

![Hiệu ứng All Caps](all_caps_effect.png)

Ví dụ mã dưới đây cho thấy cách trích xuất văn bản với hiệu ứng **All Caps** được áp dụng:

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

Kết quả:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **Câu hỏi thường gặp**

**Làm thế nào để chỉnh sửa văn bản trong một bảng trên slide?**

Để chỉnh sửa văn bản trong một bảng trên slide, sử dụng [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/). Duyệt qua các ô và cập nhật mỗi ô qua [ICell.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/) và định dạng đoạn văn qua [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/paragraphformat/).

**Làm thế nào để áp dụng màu gradient cho văn bản trên một slide PowerPoint?**

Để áp dụng màu gradient cho văn bản, sử dụng [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/). Đặt [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) thành [FillType.Gradient](https://reference.aspose.com/slides/net/aspose.slides/filltype/) và cấu hình các điểm dừng gradient, hướng và độ trong suốt.

Tính năng liên quan: [Format text within slides](/slides/vi/features/text-formatting/).