---
title: Định dạng Văn bản Bài thuyết trình trong .NET
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
- góc xoay
- khung văn bản
- khoảng cách dòng
- thuộc tính tự điều chỉnh
- neo khung văn bản
- tab văn bản
- ngôn ngữ mặc định
- PowerPoint
- OpenDocument
- bản trình bày
- .NET
- C#
- Aspose.Slides
description: "Định dạng và tạo kiểu văn bản trong các bài thuyết trình PowerPoint và OpenDocument bằng Aspose.Slides cho .NET. Tùy chỉnh phông chữ, màu sắc, căn chỉnh và hơn nữa."
---
## **Tổng quan**

Bài viết này hướng dẫn cách định dạng văn bản trong các bản trình bày PowerPoint và OpenDocument bằng Aspose.Slides cho .NET. Nó bao gồm màu nền, độ trong suốt, khoảng cách ký tự, thuộc tính phông chữ, xoay, khoảng cách đoạn, hành vi tự điều chỉnh, neo văn bản, tab stop và cài đặt ngôn ngữ.

Trừ khi có ghi chú khác, các ví dụ sử dụng [sample.pptx](sample.pptx). Hình dạng đầu tiên trên slide đầu tiên là một hộp văn bản, và đoạn văn đầu tiên của nó chứa văn bản được hiển thị bên dưới. Cả chỉ số slide và hình dạng đều bắt đầu từ số 0. Các ví dụ chọn phần in đậm sử dụng định dạng hiệu quả, bao gồm định dạng in đậm được kế thừa:

![Sample text](sample_text.png)

Để tìm và làm nổi bật văn bản nguyên literal hoặc các khớp biểu thức chính quy, xem [Tìm kiếm và Thay thế Văn bản](/slides/vi/net/search-and-replace-text/).

## **Đặt Màu Nền cho Văn Bản**

Sử dụng [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) để đặt màu nổi bật mặc định cho một đoạn, hoặc sử dụng [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/highlightcolor/) cho các phần văn bản riêng lẻ.

Ví dụ sau đặt màu nổi bật xám nhạt làm mặc định cho đoạn đầu tiên. Màu nổi bật rõ ràng trên các phần riêng lẻ sẽ ưu tiên hơn mặc định này:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Đặt màu nổi bật cho toàn bộ đoạn.
presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
```

Kết quả:

![The gray paragraph](gray_paragraph.png)

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
        // Đặt màu nổi bật cho phần văn bản.
        portion.PortionFormat.HighlightColor.Color = Color.LightGray;
    }
}

presentation.Save("gray_text_portions.pptx", SaveFormat.Pptx);
```

Kết quả:

![The gray text portions](gray_text_portions.png)

## **Căn Đoạn Văn Bản**

Sử dụng [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) để đặt căn chỉnh đoạn trong một khung văn bản. Giá trị có thể là căn giữa, căn trái, căn phải, căn đều, v.v.

Ví dụ mã sau cho thấy cách căn đoạn về **giữa**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Đặt căn chỉnh của đoạn văn bản thành trung tâm.
paragraph.ParagraphFormat.Alignment = TextAlignment.Center;

presentation.Save("aligned_paragraph.pptx", SaveFormat.Pptx);
```

Kết quả:

![The aligned paragraph](aligned_paragraph.png)

## **Căn Phông Chữ Trong Một Dòng**

Sử dụng [IParagraphFormat.FontAlignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/fontalignment/) để căn dọc các phần văn bản có kích thước phông khác nhau trong một dòng. Cài đặt này áp dụng cho toàn bộ đoạn và kiểm soát việc căn chỉnh trong mỗi dòng của nó.

Ví dụ tự chứa dưới đây tạo bốn hộp văn bản có nhãn trên một slide. Mỗi đoạn chứa cùng một văn bản với kích thước 18, 36 và 54 điểm, với căn phông chữ khác nhau. Nó sử dụng Arial, tắt tự điều chỉnh và ngắt dòng, và giữ các khung văn bản đủ lớn cho một dòng duy nhất.

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

![So sánh căn Phông chữ Baseline, Top, Center và Bottom với kích thước phông hỗn hợp](font_alignment.png)

Căn phông chữ sử dụng các chỉ số đo phông, vì vậy các cạnh hiển thị của các ký tự riêng lẻ không nhất thiết phải thẳng hàng hoàn toàn. Ví dụ bao gồm cả một chữ hoa và một ký tự có phần chấm xuống để giúp minh họa sự khác biệt giữa căn baseline và bottom. Tính khả dụng và thay thế phông, các ký tự được sử dụng và sự khác biệt về kích thước phông đều ảnh hưởng tới kết quả. Kích thước khung, lề, khoảng cách dòng, ngắt dòng và tự điều chỉnh cũng ảnh hưởng tới bố cục; hãy sử dụng cùng một phông và cùng các cài đặt bố cục khi so sánh các chế độ.

Cài đặt này khác với [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/), điều khiển căn chỉnh ngang của đoạn, và [ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/), vị trí khối văn bản theo chiều dọc trong hình dạng. Định dạng chỉ số trên [IBasePortionFormat.Escapement](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/escapement/) dịch chuyển các phần riêng lẻ so với baseline thay vì đặt căn phông cho các dòng của đoạn.

## **Đặt Độ Trong Suốt cho Văn Bản**

Độ trong suốt văn bản được kiểm soát thông qua thành phần alpha của màu được gán cho [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/). Trong các ví dụ dưới đây, `alpha = 50` là giá trị kênh alpha ARGB trên thang 0–255, không phải là phần trăm độ trong suốt.

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

![The transparent paragraph](transparent_paragraph.png)

Ví dụ mã sau cho thấy cách áp dụng độ trong suốt cho **các phần văn bản có phông chữ in đậm**:

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

![The transparent text portions](transparent_text_portions.png)

## **Đặt Khoảng Cách Ký Tự cho Văn Bản**

Sử dụng [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/spacing/) để mở rộng hoặc thu hẹp khoảng cách giữa các ký tự trong một hộp văn bản. Các ví dụ thêm 3 điểm khoảng cách; giá trị âm sẽ thu hẹp văn bản.

Mã C# sau cho thấy cách mở rộng khoảng cách ký tự trong **toàn bộ đoạn**:

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

![The character spacing in the paragraph](character_spacing_in_paragraph.png)

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

![The character spacing in the text portions](character_spacing_in_text_portions.png)

### **Tắt Kerning cho Các Phông Chỉ Định**

Trong một số trường hợp, văn bản được Aspose.Slides hiển thị có thể chặt hơn một chút so với văn bản cùng loại trong PowerPoint. Điều này có thể xảy ra vì PowerPoint có thể bỏ qua dữ liệu kerning cho một số phông, ngay cả khi phông chứa thông tin kerning hợp lệ và kerning được bật trong cài đặt PowerPoint.

Để đưa kết quả hiển thị gần với PowerPoint hơn, bạn có thể tắt kerning cho các phần văn bản sử dụng phông bị ảnh hưởng. Đặt [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/kerningminimalsize/) thành giá trị lớn hơn kích thước phông thực tế. Ví dụ này yêu cầu “presentation.pptx” với một hộp văn bản là hình dạng đầu tiên trên slide đầu tiên. Nó kiểm tra tên phông hiệu quả, bao gồm các phông được kế thừa, và đặt ngưỡng 100 điểm cho các phần sử dụng Roboto. Điều này tắt kerning cho các phần khớp có kích thước phông dưới 100 điểm:

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

Đối với văn bản khớp dưới ngưỡng, cài đặt này ngăn kerning và có thể giúp đồng bộ việc hiển thị của Aspose.Slides với đầu ra trực quan của PowerPoint đối với các phông bị hành vi riêng của PowerPoint này ảnh hưởng.

## **Quản Lý Thuộc Tính Phông Chữ của Văn Bản**

Thuộc tính phông chữ có thể được đặt ở mức đoạn thông qua [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) hoặc trên các phần riêng lẻ thông qua [IPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/).

Ví dụ dưới đây đặt phông mặc định cho đoạn đầu tiên là Times New Roman 12 điểm với định dạng in đậm, in nghiêng và gạch dưới chấm. Định dạng rõ ràng trên các phần riêng lẻ sẽ ưu tiên hơn các mặc định này.

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

![The font properties for the paragraph](font_properties_for_paragraph.png)

Ví dụ dưới đây áp dụng Times New Roman 13 điểm, định dạng in nghiêng và gạch dưới chấm cho các phần có định dạng hiệu quả là in đậm:

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

![The font properties for text portions](font_properties_for_text_portions.png)

## **Kiểm Soát Chuẩn Hóa Chiều Cao Văn Bản**

Sử dụng [IBasePortionFormat.NormaliseHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/normaliseheight/) khi tái tạo kiểu chữ mẫu hoặc nghiên cứu sự khác biệt về chiều cao ký tự. Trong PowerPoint, bật chuẩn hóa sẽ kéo dài hoặc nén các ký tự riêng lẻ theo chiều dọc để chúng có chiều cao hiển thị đồng nhất trong phần văn bản. Điều này không đảm bảo các đoạn văn bản có chiều cao bằng nhau giữa các phông khác nhau.

Đặt thuộc tính thành [NullableBool.True hoặc False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) để bật hoặc tắt chuẩn hóa một cách rõ ràng. `NullableBool.NotDefined` để lại cài đặt cục bộ không được đặt, do đó phần văn bản sẽ kế thừa giá trị, ví dụ, từ [DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) của đoạn. Nó không đồng nghĩa với `False`. Sử dụng [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/) và đọc [IBasePortionFormatEffectiveData.NormaliseHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformateffectivedata/normaliseheight/) để lấy giá trị Boolean đã giải quyết.

Ví dụ tự chứa dưới đây yêu cầu **Arial** đã được cài đặt. Nó tạo hai khối văn bản chứa cùng các chữ hoa, chữ thường, ký tự có phần chấm xuống và ký tự có dấu ở 54 điểm. Cả hai đoạn đều bật chuẩn hóa theo mặc định. Phần trên tắt chuẩn hóa một cách rõ ràng; phần dưới kế thừa chế độ đã bật. Kích thước khung, lề và khoảng cách đoạn giống nhau, với ngắt dòng và tự điều chỉnh tắt để giữ so sánh nhất quán. Ví dụ in ra `False: False` và `NotDefined: True`, sau đó lưu “text_height_normalization.pptx”.

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

So sánh dưới đây được xuất từ bản trình bày đã lưu. Hàng trên có chuẩn hóa tắt (`False`); hàng dưới kế thừa cài đặt bật (`NotDefined` → `True`). Giữ Arial được cài đặt để tái tạo giao diện này.

![Arial 54-point text with normalization disabled above and inherited normalization enabled below](text_height_normalization.png)

Chuẩn hóa thay đổi chiều cao ký tự mà không thay đổi giá trị [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fontheight/) đã gán, giá trị này xác định kích thước phông tính bằng điểm. [SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/) của đoạn điều khiển khoảng cách dòng, trong khi [AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) của khung văn bản kiểm soát cách văn bản hoặc vùng chứa điều chỉnh để vừa. Các cài đặt này phục vụ các mục đích khác nhau và có thể ảnh hưởng đến bố cục tổng thể một cách độc lập. Để biết thêm về định dạng đoạn và kế thừa, xem [Quản Lý Đoạn](/slides/vi/net/manage-paragraph/).

## **Áp Dụng và Xóa Gạch Nối**

Sử dụng [IBasePortionFormat.StrikethroughType](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/strikethroughtype/) trên một phần văn bản để hiển thị các sửa đổi, thuật ngữ đã hủy hoặc giá cũ mà không xóa văn bản gốc. Đặt thành [TextStrikethroughType.Single hoặc Double](https://reference.aspose.com/slides/net/aspose.slides/textstrikethroughtype/) để có một hoặc hai đường gạch xuyên qua văn bản.

Để xóa gạch nối, gán `TextStrikethroughType.None`. Điều này tắt hiệu ứng một cách rõ ràng, ngay cả khi định dạng xung quanh chỉ định gạch nối. Ngược lại, `TextStrikethroughType.NotDefined` để lại cài đặt cục bộ chưa định nghĩa, cho phép phần văn bản kế thừa định dạng, ví dụ, từ đoạn. Nó không đảm bảo gạch nối bị xóa. Sử dụng [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/) để đọc định dạng kết quả, bao gồm các giá trị kế thừa.

Ví dụ tự chứa dưới đây tạo ba so sánh giá. Mỗi đoạn có các phần riêng cho nhãn, giá cũ và giá hiện tại, vì vậy chỉ giá cũ bị ảnh hưởng. Hàng trên áp dụng rồi xóa gạch nối; các hàng còn lại giữ gạch nối đơn và gạch nối đôi. Thay đổi thuộc tính này giữ nguyên văn bản và các định dạng khác, bao gồm giá cũ in đậm.

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

// Apply strikethrough, then explicitly remove it from the first previous price.
paragraphs[0].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Single;
paragraphs[0].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.None;

paragraphs[1].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Single;
paragraphs[2].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Double;

presentation.Save("strikethrough.pptx", SaveFormat.Pptx);
```

Kết quả, từ trên xuống: không có gạch nối, gạch nối đơn, và gạch nối đôi.

![Previous prices without strikethrough, with single strikethrough, and with double strikethrough](strikethrough.png)

## **Đặt Xoay Văn Bản**

Sử dụng [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/textverticaltype/) để đặt một hướng văn bản định sẵn trong một hình dạng.

Ví dụ mã sau đặt hướng văn bản trong hình dạng thành [TextVerticalType.Vertical270](https://reference.aspose.com/slides/net/aspose.slides/textverticaltype/), xoay văn bản **90 độ ngược chiều kim đồng hồ**:

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

![The text rotation](text_rotation.png)

## **Hiển Thị Các Chữ Số Bên Nhau Trong Văn Bản Dọc**

Để giữ một số hai chữ số cùng nhau trong một nhãn tiếng Nhật dọc, đặt cả hai chữ số vào một phần văn bản và thiết lập [IBasePortionFormat.Kumimoji](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/kumimoji/) cho phần đó. Ví dụ sử dụng [TextVerticalType.EastAsianVertical](https://reference.aspose.com/slides/net/aspose.slides/textverticaltype/) và MS Gothic 40 điểm cho cả hai nhãn. Chỉ giá trị của [NullableBool](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) được gán cho phần số thay đổi.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

AddLabel(slide, 120, NullableBool.True);
AddLabel(slide, 360, NullableBool.False);

presentation.Save("vertical_date.pptx", SaveFormat.Pptx);

static void AddLabel(ISlide slide, float x, NullableBool kumimoji)
{
    var label = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x, 48, 120, 420);
    label.FillFormat.FillType = FillType.NoFill;
    label.LineFormat.FillFormat.FillType = FillType.NoFill;

    var frame = label.AddTextFrame("");
    frame.TextFrameFormat.TextVerticalType = TextVerticalType.EastAsianVertical;

    var paragraph = frame.Paragraphs[0];
    var format = paragraph.ParagraphFormat.DefaultPortionFormat;
    var font = new FontData("MS Gothic");
    format.LatinFont = font;
    format.EastAsianFont = font;
    format.FontHeight = 40;
    format.FillFormat.FillType = FillType.Solid;
    format.FillFormat.SolidFillColor.Color = System.Drawing.Color.Black;

    var digits = new Portion("12");
    digits.PortionFormat.Kumimoji = kumimoji;
    
    paragraph.Portions.Clear();
    paragraph.Portions.Add(new Portion("令和"));
    paragraph.Portions.Add(digits);
    paragraph.Portions.Add(new Portion("年"));
}
```

Trong PowerPoint, nhãn trái (`True`) hiển thị các chữ số thẳng đứng và đứng cạnh nhau giữa 和 và 年. Nhãn phải (`False`) quay cặp chữ số 90 độ theo chiều kim đồng hồ. Các ký tự Nhật Bản bao quanh vẫn thẳng đứng trong cả hai nhãn.

![PowerPoint comparison of vertical date labels with upright digits on the left and rotated digits on the right.](vertical_date.png)

## **Đặt Xoay Tùy Chỉnh cho Khung Văn Bản**

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

![The custom text rotation](custom_text_rotation.png)

## **Đặt Khoảng Cách Dòng của Các Đoạn**

Aspose.Slides cung cấp [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spaceafter/), [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacebefore/), và [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/) để kiểm soát khoảng cách đoạn. Các thuộc tính này được sử dụng như sau:

* Sử dụng giá trị dương để chỉ định khoảng cách dòng dưới dạng phần trăm của chiều cao dòng.
* Sử dụng giá trị âm để chỉ định khoảng cách dòng bằng điểm.

Ví dụ sau đặt khoảng cách trong đoạn đầu tiên là 200 % chiều cao dòng (gấp đôi):

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

![The line spacing within the paragraph](line_spacing.png)

## **Kiểm Soát Ngắt Dòng**

Các quy tắc ngắt dòng của đoạn hữu ích trong các khối văn bản hẹp và các bản trình bày hỗn hợp văn bản Latin và Đông Á. Các thuộc tính sau thuộc về [IParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/), vì vậy chúng áp dụng cho toàn bộ đoạn:

- [LatinLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/latinlinebreak/) kiểm soát quy tắc ngắt dòng Latin. Trong văn bản hỗn hợp, thay đổi nó cũng có thể thay đổi vị trí ngắt của văn bản và dấu câu Đông Á liền kề.
- [EastAsianLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/eastasianlinebreak/) kiểm soát quy tắc ngắt dòng Đông Á, bao gồm các hạn chế về ký tự ở đầu và cuối dòng.

Các quy tắc này không thay thế [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/), cho phép tự động ngắt dòng trong một khung văn bản. Chúng ảnh hưởng tới bố cục khi ngắt dòng xảy ra; chúng không chèn ký tự ngắt dòng. Một ngắt dòng rõ ràng buộc một dòng mới trong đoạn bất kể độ rộng hiện có.

Ví dụ tự chứa dưới đây tạo một khối văn bản hẹp chứa tiếng Trung và Latin. Nó đặt cả hai thuộc tính ngắt dòng một cách rõ ràng và lưu “line_breaking.pptx”. Để thử nghiệm từng quy tắc, thay đổi giá trị thuộc tính đó trong khi giữ các cài đặt khác cố định. Ví dụ sử dụng Arial 24 điểm và SimSun với độ rộng khung 160 điểm và lề khung văn bản ngang bằng 0. [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) được đặt thành [TextAutofitType.None](https://reference.aspose.com/slides/net/aspose.slides/textautofittype/) để kích thước văn bản và khung không thay đổi.

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

## **Kiểm Soát Dấu Câu Treo**

[IParagraphFormat.HangingPunctuation](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/hangingpunctuation/) cho phép các dấu câu đủ điều kiện kéo ra ngoài cạnh phải của dòng văn bản thay vì chiếm dòng tiếp theo. Nó áp dụng cho toàn bộ đoạn và khác với thụt lề treo.

Ví dụ tự chứa dưới đây bật dấu câu treo trong một khung văn bản rộng 100 điểm và lưu “hanging_punctuation.pptx”. Với Arial 24 điểm và lề khung văn bản ngang bằng 0, dấu chấm cuối cùng ở cuối “sentence” sẽ nằm sau từ và kéo ra ngoài cạnh phải. Đặt thuộc tính thành [NullableBool.False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) để so sánh: với cài đặt này, dấu chấm sẽ chiếm một dòng riêng. Ngắt dòng được bật và tự điều chỉnh tắt để giữ độ rộng khả dụng cố định.

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

Không phải mọi dấu câu đều có thể treo. Các [điều kiện phông và bố cục được mô tả ở trên](#control-line-breaking) cũng áp dụng cho so sánh này: thay đổi phông, độ rộng khả dụng, lề hoặc cài đặt tự điều chỉnh có thể loại bỏ sự khác biệt nhìn thấy.

## **Đặt Loại Tự Điều Chỉnh cho Khung Văn Bản**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) xác định cách văn bản hành xử khi vượt quá giới hạn của vùng chứa. Sử dụng nó để kiểm soát việc văn bản co lại, tràn ra ngoài hoặc tự động thay đổi kích thước hình dạng. Ví dụ dưới đây cấu hình hình dạng để thay đổi kích thước phù hợp với văn bản và lưu kết quả thành “autofit_type.pptx”.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
```

Để đếm số dòng sau khi tự động ngắt và xem cách văn bản hoặc chiều rộng hình dạng thay đổi kết quả, xem [Đếm Dòng Được Kết Xuất](/slides/vi/net/manage-paragraph/). Số dòng một mình không cho biết liệu văn bản có tràn khỏi vùng chứa hay không.

## **Đặt Neo cho Khung Văn Bản**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/) định nghĩa cách văn bản được đặt theo chiều dọc bên trong một hình dạng, ví dụ, ở trên, giữa hoặc dưới. Ví dụ dưới đây neo văn bản vào đáy của hình dạng đầu tiên và lưu kết quả thành “text_anchor.pptx”.

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

Sử dụng [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaulttabsize/) và [IParagraphFormat.Tabs](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/tabs/) để cấu hình các vị trí tab trong một đoạn. Ví dụ dưới đây đặt khoảng cách tab mặc định thành 100 điểm và thêm một vị trí tab trái căn ở 30 điểm. Các cài đặt này ảnh hưởng tới văn bản có ký tự tab.

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

![The paragraph tabs](paragraph_tabs.png)

## **Đặt Ngôn Ngữ Kiểm Tra Chính Tả**

Aspose.Slides cung cấp [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/), cho phép bạn đặt ngôn ngữ kiểm tra chính tả cho một phần văn bản. Ngôn ngữ này quyết định ngôn ngữ được dùng cho kiểm tra chính tả và ngữ pháp trong PowerPoint.

Ví dụ dưới đây yêu cầu “presentation.pptx” với một hộp văn bản là hình dạng đầu tiên trên slide đầu tiên và ít nhất một đoạn. Nó thay thế nội dung của đoạn đầu tiên bằng “1。”, đặt SimSun làm phông và gán ngôn ngữ kiểm tra tiếng Trung giản thể (`zh-CN`). Sau đó lưu kết quả thành “proofing_language.pptx”:

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

// Đặt ngôn ngữ kiểm tra thành tiếng Trung giản thể.
textPortion.PortionFormat.LanguageId = "zh-CN";

textPortion.Text = "1。";
paragraph.Portions.Add(textPortion);

presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
```

### **Sao Chép Siêu Dữ Liệu Ngôn Ngữ**

Khi sao chép văn bản đa ngôn ngữ từ một mẫu, hãy bảo lưu cả [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/) và [IBasePortionFormat.AlternativeLanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/alternativelanguageid/). Ví dụ tự chứa dưới đây tạo một phần nguồn với ngôn ngữ tiếng Anh Mỹ và ngôn ngữ thay thế là tiếng Pháp, sau đó sao chép văn bản và các định danh vào một phần trong bản trình bày mới.

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
// Nếu nguồn không có ngôn ngữ thay thế, null sẽ xóa giá trị của đích.
destination.PortionFormat.AlternativeLanguageId = source.PortionFormat.AlternativeLanguageId;
paragraph.Portions.Add(destination);

presentation.Save("copied_language_metadata.pptx", SaveFormat.Pptx);
```

Để thử nguồn không có ngôn ngữ thay thế, bỏ qua việc gán `"fr-FR"`. Khi đó định danh thay thế sẽ là `null`, và câu lệnh sao chép giữ nguyên việc không có giá trị thay thế mà không tạo giá trị mặc định, ngay cả khi đích trước đó đã có ngôn ngữ thay thế được gán.

Các định danh này lưu siêu dữ liệu ngôn ngữ. Bảo lưu chúng không quyết định từ điển nào PowerPoint sẽ chọn để kiểm tra chính tả hoặc ngữ pháp.

## **Đặt Ngôn Ngữ Mặc Định**

Sử dụng [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/defaulttextlanguage/) để xác định ngôn ngữ mặc định cho văn bản được tạo khi tải hoặc tạo một bản trình bày. Ví dụ dưới đây tạo một bản trình bày với ngôn ngữ văn bản mặc định là tiếng Anh Mỹ, thêm một hộp văn bản và in `en-US` cho phần văn bản đầu tiên.

```cs
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];

// Thêm một hình dạng hình chữ nhật mới với văn bản.
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
shape.TextFrame.Text = "Sample text";

// Kiểm tra ngôn ngữ của phần văn bản đầu tiên.
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine(portion.PortionFormat.LanguageId);
```

## **Đặt Kiểu Văn Bản Mặc Định**

Để áp dụng định dạng văn bản mặc định ở mức bản trình bày, sử dụng [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/defaulttextstyle/).

Ví dụ dưới đây đặt phông chữ 14 điểm in đậm làm mặc định cho các đoạn cấp cao nhất trong một bản trình bày mới và lưu nó thành “default_text_style.pptx”. Văn bản có thể kế thừa các mặc định này trừ khi có định dạng cụ thể hơn ghi đè.

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

## **Trích Xuất Văn Bản với Hiệu Ứng In HOA**

Trong PowerPoint, áp dụng hiệu ứng **All Caps** làm cho văn bản hiển thị dưới dạng chữ hoa trên slide ngay cả khi nó được gõ bằng chữ thường. Khi bạn lấy phần văn bản như vậy bằng Aspose.Slides, thư viện trả về văn bản chính xác như khi nhập. Để khớp với văn bản hiển thị, kiểm tra [TextCapType](https://reference.aspose.com/slides/net/aspose.slides/textcaptype/) và chuyển chuỗi trả về sang chữ hoa khi giá trị là `All`.

Ví dụ này yêu cầu “sample2.pptx” với một hộp văn bản là hình dạng đầu tiên trên slide đầu tiên. Phần đầu tiên của đoạn đầu tiên chứa “Hello, Aspose!” với hiệu ứng All Caps được áp dụng, như hình dưới.

![The All Caps effect](all_caps_effect.png)

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

## **FAQ**

**Làm thế nào để chỉnh sửa văn bản trong bảng trên một slide?**

Để chỉnh sửa văn bản trong bảng trên một slide, sử dụng [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/). Duyệt qua các ô và cập nhật từng ô thông qua [ICell.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/) và định dạng đoạn qua [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/paragraphformat/).

**Làm thế nào để áp dụng màu gradient cho văn bản trên slide PowerPoint?**

Để áp dụng màu gradient cho văn bản, sử dụng [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/). Đặt [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) thành [FillType.Gradient](https://reference.aspose.com/slides/net/aspose.slides/filltype/) và cấu hình các dừng gradient, hướng và độ trong suốt.

Tính năng liên quan: [Định dạng văn bản trong slide](/slides/vi/features/text-formatting/).