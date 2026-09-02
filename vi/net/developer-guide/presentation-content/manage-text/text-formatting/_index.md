---
title: Định dạng Văn bản Bản trình chiếu trong .NET
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
- thuộc tính tự động điều chỉnh kích thước
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

Bài viết này hướng dẫn cách định dạng văn bản trong các bản trình chiếu PowerPoint và OpenDocument bằng Aspose.Slides cho .NET. Nó bao gồm màu nền, độ trong suốt, khoảng cách ký tự, thuộc tính phông chữ, xoay, khoảng cách đoạn, hành vi tự động điều chỉnh kích thước, neo văn bản, tab và cài đặt ngôn ngữ.

Trong các ví dụ bên dưới, chúng tôi sẽ sử dụng tệp có tên "sample.pptx", chứa một hộp văn bản duy nhất trên slide đầu tiên với nội dung sau:

![Văn bản mẫu](sample_text.png)

Để tìm và làm nổi bật văn bản nguyên mẫu hoặc các khớp biểu thức chính quy, xem [Tìm và Thay thế Văn bản](/slides/vi/net/search-and-replace-text/).

## **Đặt Màu Nền Văn Bản**

Sử dụng [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/defaultportionformat/) để đặt màu nền mặc định cho một đoạn, hoặc sử dụng [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/vi/net/aspose.slides/ibaseportionformat/highlightcolor/) cho các phần văn bản riêng lẻ.

Đoạn mã sau cho thấy cách đặt màu nền cho **toàn bộ đoạn**: 

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Đặt màu nền cho toàn bộ đoạn.
    paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

    presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
}
```

Kết quả:

![Đoạn văn màu xám](gray_paragraph.png)

Đoạn mã dưới đây minh họa cách đặt màu nền cho **các phần văn bản có phông đậm**:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // Đặt màu nền cho phần văn bản.
            portion.PortionFormat.HighlightColor.Color = Color.LightGray;
        }
    }

    presentation.Save("gray_text_portions.pptx", SaveFormat.Pptx);
}
```

Kết quả:

![Các phần văn bản màu xám](gray_text_portions.png)

## **Căn Chỉnh Đoạn Văn Bản**

Sử dụng [IParagraphFormat.Alignment](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/alignment/) để đặt căn chỉnh đoạn trong khung văn bản. Giá trị có thể là trung tâm, căn trái, căn phải, căn đều, v.v.

Đoạn mã sau cho thấy cách căn chỉnh đoạn ở **giữa**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Đặt căn chỉnh của đoạn về trung tâm.
    paragraph.ParagraphFormat.Alignment = TextAlignment.Center;

    presentation.Save("aligned_paragraph.pptx", SaveFormat.Pptx);
}
```

Kết quả:

![Đoạn văn đã căn chỉnh](aligned_paragraph.png)

## **Đặt Độ Trong Suốt cho Văn Bản**

Độ trong suốt văn bản được kiểm soát qua thành phần alpha của màu được gán cho [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/ibaseportionformat/fillformat/). Trong các ví dụ dưới đây, `alpha = 50` là giá trị kênh alpha ARGB trên thang 0–255, không phải phần trăm độ trong suốt.

Đoạn mã dưới đây cho thấy cách áp dụng độ trong suốt cho **toàn bộ đoạn**:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

int alpha = 50;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Đặt màu tô của văn bản thành màu trong suốt.
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

    presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
}
```

Kết quả:

![Đoạn văn trong suốt](transparent_paragraph.png)

Đoạn mã sau cho thấy cách áp dụng độ trong suốt cho **các phần văn bản có phông đậm**:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

int alpha = 50;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // Đặt độ trong suốt của phần văn bản.
            portion.PortionFormat.FillFormat.FillType = FillType.Solid;
            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);
        }
    }

    presentation.Save("transparent_text_portions.pptx", SaveFormat.Pptx);
}
```

Kết quả:

![Các phần văn bản trong suốt](transparent_text_portions.png)

## **Đặt Khoảng Cách Ký Tự cho Văn Bản**

Sử dụng [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/vi/net/aspose.slides/ibaseportionformat/spacing/) để mở rộng hoặc thu hẹp khoảng cách giữa các ký tự trong một hộp văn bản.

Đoạn mã C# sau cho thấy cách mở rộng khoảng cách ký tự trong **toàn bộ đoạn**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Lưu ý: Sử dụng giá trị âm để nén khoảng cách ký tự.
    paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // Mở rộng khoảng cách ký tự.

    presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
}
```

Kết quả:

![Khoảng cách ký tự trong đoạn](character_spacing_in_paragraph.png)

Đoạn mã dưới đây cho thấy cách mở rộng khoảng cách ký tự trong **các phần văn bản có phông đậm**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
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
}
```

Kết quả:

![Khoảng cách ký tự trong các phần văn bản](character_spacing_in_text_portions.png)

### **Vô Hiệu Hóa Kerning cho Các Phông Cụ Thể**

Trong một số trường hợp, văn bản do Aspose.Slides hiển thị có thể trông hơi chặt hơn so với cùng một văn bản trong PowerPoint. Điều này có thể xảy ra vì PowerPoint có thể bỏ qua dữ liệu kerning cho một số phông chữ, ngay cả khi phông chữ chứa thông tin kerning hợp lệ và kerning đã được bật trong cài đặt PowerPoint.

Để đầu ra được render gần với PowerPoint hơn trong các trường hợp này, bạn có thể vô hiệu hóa kerning cho các phần văn bản sử dụng phông ảnh hưởng. Đặt [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/vi/net/aspose.slides/ibaseportionformat/kerningminimalsize/) thành giá trị lớn hơn đáng kể so với kích thước phông thực tế:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("presentation.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var targetFont = "Roboto";

    foreach (var paragraph in autoShape.TextFrame.Paragraphs)
    {
        foreach (var portion in paragraph.Portions)
        {
            if ((portion.PortionFormat.LatinFont != null &&
                 portion.PortionFormat.LatinFont.FontName == targetFont) ||
                (portion.PortionFormat.EastAsianFont != null &&
                 portion.PortionFormat.EastAsianFont.FontName == targetFont) ||
                (portion.PortionFormat.ComplexScriptFont != null &&
                 portion.PortionFormat.ComplexScriptFont.FontName == targetFont))
            {
                portion.PortionFormat.KerningMinimalSize = 100;
            }
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

Cài đặt này ngăn kerning được áp dụng cho các phần văn bản khớp và có thể giúp đồng bộ việc render của Aspose.Slides với đầu ra trực quan của PowerPoint cho các phông chữ bị ảnh hưởng bởi hành vi riêng của PowerPoint này.

## **Quản Lý Thuộc Tính Phông Chữ Văn Bản**

Thuộc tính phông chữ có thể được đặt ở mức đoạn thông qua [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/defaultportionformat/) hoặc ở mức phần riêng lẻ qua [IPortionFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/iportionformat/).

Đoạn mã sau thiết lập phông chữ và kiểu văn bản cho toàn bộ đoạn: nó áp dụng kích thước phông, in đậm, in nghiêng, gạch chân chấm và phông Times New Roman cho tất cả các phần trong đoạn.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Đặt các thuộc tính phông chữ cho đoạn.
    paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 12;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontItalic = NullableBool.True;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontUnderline = TextUnderlineType.Dotted;
    paragraph.ParagraphFormat.DefaultPortionFormat.LatinFont = new FontData("Times New Roman");

    presentation.Save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
}
```

Kết quả:

![Thuộc tính phông chữ của đoạn](font_properties_for_paragraph.png)

Đoạn mã dưới đây áp dụng các thuộc tính tương tự cho **các phần văn bản có phông đậm**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
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
}
```

Kết quả:

![Thuộc tính phông chữ của các phần văn bản](font_properties_for_text_portions.png)

## **Đặt Xoay Văn Bản**

Sử dụng [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframeformat/textverticaltype/) để thiết lập hướng văn bản đã định trước trong một hình dạng.

Đoạn mã sau đặt hướng văn bản trong hình dạng thành `Vertical270`, làm xoay văn bản **90 độ ngược chiều kim đồng hồ**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.TextVerticalType = TextVerticalType.Vertical270;

    presentation.Save("text_rotation.pptx", SaveFormat.Pptx);
}
```

Kết quả:

![Xoay văn bản](text_rotation.png)

## **Đặt Xoay Tùy Chỉnh cho Khung Văn Bản**

Sử dụng [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframeformat/rotationangle/) để đặt góc xoay tùy chỉnh cho một [ITextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/).

Đoạn mã dưới đây xoay khung văn bản 3 độ theo chiều kim đồng hồ trong hình dạng:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.RotationAngle = 3;

    presentation.Save("custom_text_rotation.pptx", SaveFormat.Pptx);
}
```

Kết quả:

![Xoay văn bản tùy chỉnh](custom_text_rotation.png)

## **Đặt Khoảng Cách Dòng của Các Đoạn**

Aspose.Slides cung cấp [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/spaceafter/), [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/spacebefore/) và [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/spacewithin/) để kiểm soát khoảng cách đoạn. Các thuộc tính này được sử dụng như sau:

* Dùng giá trị dương để chỉ định khoảng cách dòng dưới dạng phần trăm của chiều cao dòng.
* Dùng giá trị âm để chỉ định khoảng cách dòng theo điểm.

Đoạn mã sau cho thấy cách chỉ định khoảng cách dòng trong đoạn:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    paragraph.ParagraphFormat.SpaceWithin = 200;

    presentation.Save("line_spacing.pptx", SaveFormat.Pptx);
}
```

Kết quả:

![Khoảng cách dòng trong đoạn](line_spacing.png)

## **Đặt Kiểu Tự Động Điều Chỉnh Kích Thước cho Khung Văn Bản**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframeformat/autofittype/) quyết định cách văn bản hành xử khi vượt quá giới hạn của vùng chứa. Sử dụng nó để kiểm soát việc văn bản thu nhỏ, tràn ra ngoài hoặc tự động thay đổi kích thước hình dạng.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

    presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
}
```

## **Đặt Neo cho Khung Văn Bản**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframeformat/anchoringtype/) xác định cách văn bản được định vị theo chiều dọc bên trong một hình dạng, ví dụ ở trên, giữa hoặc dưới.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

    presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
}
```

## **Đặt Tab cho Văn Bản**

Sử dụng [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/defaulttabsize/) và [IParagraphFormat.Tabs](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/tabs/) để cấu hình các vị trí tab trong một đoạn.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    paragraph.ParagraphFormat.DefaultTabSize = 100;
    paragraph.ParagraphFormat.Tabs.Add(30, TabAlignment.Left);

    presentation.Save("paragraph_tabs.pptx", SaveFormat.Pptx);
}
```

Kết quả:

![Các tab của đoạn](paragraph_tabs.png)

## **Đặt Ngôn Ngữ Kiểm Tra Chính Tả**

Aspose.Slides cung cấp [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/vi/net/aspose.slides/ibaseportionformat/languageid/), cho phép bạn đặt ngôn ngữ kiểm tra chính tả cho một phần văn bản. Ngôn ngữ này quyết định ngôn ngữ được sử dụng cho việc kiểm tra chính tả và ngữ pháp trong PowerPoint.

Đoạn mã sau cho thấy cách đặt ngôn ngữ kiểm tra cho một phần văn bản:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("presentation.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    var paragraph = autoShape.TextFrame.Paragraphs[0];
    paragraph.Portions.Clear();

    var font = new FontData("SimSun");

    var textPortion = new Portion();
    textPortion.PortionFormat.ComplexScriptFont = font;
    textPortion.PortionFormat.EastAsianFont = font;
    textPortion.PortionFormat.LatinFont = font;

    // Đặt Id của ngôn ngữ kiểm tra.
    textPortion.PortionFormat.LanguageId = "zh-CN";

    textPortion.Text = "1。";
    paragraph.Portions.Add(textPortion);

    presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
}
```

## **Đặt Ngôn Ngữ Mặc Định**

Sử dụng [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/vi/net/aspose.slides/loadoptions/defaulttextlanguage/) để xác định ngôn ngữ mặc định cho văn bản được tạo khi tải hoặc khởi tạo một bản trình chiếu.

```cs
using Aspose.Slides;

var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using (var presentation = new Presentation(loadOptions))
{
    var slide = presentation.Slides[0];

    // Thêm một hình chữ nhật mới có văn bản.
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.TextFrame.Text = "Sample text";

    // Kiểm tra ngôn ngữ của phần văn bản đầu tiên.
    var portion = shape.TextFrame.Paragraphs[0].Portions[0];
    Console.WriteLine(portion.PortionFormat.LanguageId);
}
```

## **Đặt Kiểu Văn Bản Mặc Định**

Để áp dụng định dạng văn bản mặc định ở mức bản trình chiếu, sử dụng [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/vi/net/aspose.slides/ipresentation/defaulttextstyle/).

Đoạn mã sau cho thấy cách đặt phông chữ đậm mặc định kích thước 14 pt cho tất cả văn bản trên các slide trong một bản trình chiếu mới.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation())
{
    // Lấy định dạng đoạn cấp cao nhất.
    var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

    if (paragraphFormat != null)
    {
        paragraphFormat.DefaultPortionFormat.FontHeight = 14;
        paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
    }

    presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
}
```

## **Trích Xuất Văn Bản với Hiệu Ứng In HOA**

Trong PowerPoint, áp dụng hiệu ứng **In HOA** khiến văn bản hiển thị ở dạng chữ hoa trên slide ngay cả khi ban đầu được gõ bằng chữ thường. Khi bạn lấy phần văn bản như vậy bằng Aspose.Slides, thư viện sẽ trả về văn bản đúng như đã nhập. Để khớp với văn bản hiển thị, kiểm tra [TextCapType](https://reference.aspose.com/slides/vi/net/aspose.slides/textcaptype/) và chuyển chuỗi trả về sang chữ hoa khi giá trị là `All`.

Giả sử chúng ta có hộp văn bản sau trên slide đầu tiên của tệp sample2.pptx.

![Hiệu ứng In HOA](all_caps_effect.png)

Đoạn mã dưới đây cho thấy cách trích xuất văn bản có hiệu ứng **In HOA** áp dụng:

```cs
using Aspose.Slides;

using (var presentation = new Presentation("sample2.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var textPortion = autoShape.TextFrame.Paragraphs[0].Portions[0];

    Console.WriteLine($"Original text: {textPortion.Text}");

    var textFormat = textPortion.PortionFormat.GetEffective();
    if (textFormat.TextCapType == TextCapType.All)
    {
        var text = textPortion.Text.ToUpper();
        Console.WriteLine($"All-Caps effect: {text}");
    }
}
```

Kết quả:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **Câu Hỏi Thường Gặp**

**Làm thế nào để sửa đổi văn bản trong bảng trên một slide?**

Để sửa đổi văn bản trong bảng trên một slide, sử dụng [ITable](https://reference.aspose.com/slides/vi/net/aspose.slides/itable/). Duyệt qua các ô và cập nhật mỗi ô thông qua [ICell.TextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/icell/textframe/) và định dạng đoạn qua [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraph/paragraphformat/).

**Làm thế nào để áp dụng màu gradient cho văn bản trong slide PowerPoint?**

Để áp dụng màu gradient cho văn bản, sử dụng [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/ibaseportionformat/fillformat/). Đặt [IFillFormat.FillType](https://reference.aspose.com/slides/vi/net/aspose.slides/ifillformat/filltype/) thành [FillType.Gradient](https://reference.aspose.com/slides/vi/net/aspose.slides/filltype/) và cấu hình các điểm dừng gradient, hướng và độ trong suốt.