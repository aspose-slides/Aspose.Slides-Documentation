---
title: Định dạng Văn bản Bản trình chiếu trong .NET
linktitle: Định dạng Văn bản
type: docs
weight: 50
url: /vi/net/text-formatting/
keywords:
- đánh dấu văn bản
- biểu thức chính quy
- căn đoạn văn
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
- thuộc tính autofit
- neo khung văn bản
- tab văn bản
- ngôn ngữ mặc định
- PowerPoint
- OpenDocument
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Định dạng và tạo kiểu cho văn bản trong các bản trình chiếu PowerPoint và OpenDocument bằng Aspose.Slides cho .NET. Tùy chỉnh phông chữ, màu sắc, căn chỉnh và nhiều hơn nữa."
---
## **Tổng quan**

Bài viết này hướng dẫn cách định dạng văn bản trong các bản thuyết trình PowerPoint và OpenDocument bằng Aspose.Slides cho .NET. Nội dung bao gồm việc đánh dấu, màu nền, độ trong suốt, khoảng cách ký tự, thuộc tính phông chữ, xoay, khoảng cách đoạn, hành vi Autofit, neo văn bản, tab và cài đặt ngôn ngữ.

Trong các ví dụ dưới đây, chúng ta sẽ dùng tệp có tên “sample.pptx”, chứa một hộp văn bản duy nhất trên slide đầu tiên với nội dung sau:

![Văn bản mẫu](sample_text.png)

## **Đánh dấu văn bản**

Sử dụng phương thức [ITextFrame.HighlightText](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/highlighttext/) khi bạn cần đánh dấu văn bản khớp với mẫu cụ thể trong một khung văn bản. Phương thức này áp dụng màu nền cho các đoạn văn bản khớp và có thể kết hợp với [TextSearchOptions](https://reference.aspose.com/slides/vi/net/aspose.slides/textsearchoptions/) để kiểm soát cách tìm kiếm, ví dụ chỉ khớp toàn bộ từ.

Mã mẫu dưới đây đánh dấu tất cả các lần xuất hiện của ký tự **"try"** và sau đó chỉ đánh dấu từ **"to"** đầy đủ.

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    // Lấy hình dạng đầu tiên từ slide đầu tiên.
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];

    // Đánh dấu từ "try" trong hình dạng.
    shape.TextFrame.HighlightText("try", Color.LightBlue);

    var searchOptions = new TextSearchOptions()
    {
        WholeWordsOnly = true
    };

    // Đánh dấu từ "to" trong hình dạng.
    shape.TextFrame.HighlightText("to", Color.Violet, searchOptions, null);

    presentation.Save("highlighted_text.pptx", SaveFormat.Pptx);
}
```

Kết quả:

![Văn bản được đánh dấu](highlighted_text.png)

## **Đánh dấu văn bản bằng biểu thức chính quy**

Phương thức [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/highlightregex/) đánh dấu các kết quả tìm kiếm được tìm thấy bằng biểu thức chính quy. Trong .NET, API này được khai báo trên [ITextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/).

Mã mẫu dưới đây đánh dấu tất cả các từ có **bảy ký tự trở lên**:

```cs
using (var presentation = new Presentation(folderPath + "sample.pptx"))
{
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];

    var regex = new Regex(@"\b[^\s]{7,}\b");

    // Đánh dấu tất cả các từ có bảy ký tự trở lên.
    shape.TextFrame.HighlightRegex(regex, Color.Yellow, null);

    presentation.Save(folderPath + "highlighted_text_using_regex.pptx", SaveFormat.Pptx);
}
```

Kết quả:

![Văn bản được đánh dấu bằng biểu thức chính quy](highlighted_text_using_regex.png)

## **Đặt màu nền cho văn bản**

Sử dụng [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/defaultportionformat/) để đặt màu nền mặc định cho một đoạn, hoặc dùng [IPortionFormat.HighlightColor](https://reference.aspose.com/slides/vi/net/aspose.slides/iportionformat/highlightcolor/) cho các phần văn bản riêng lẻ.

Mã mẫu sau cho thấy cách đặt màu nền cho **toàn bộ đoạn**:

```cs
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

![Đoạn văn xám](gray_paragraph.png)

Mã mẫu dưới đây minh họa cách đặt màu nền cho **các phần văn bản có phông chữ in đậm**:

```cs
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

![Các đoạn văn bản xám](gray_text_portions.png)

## **Căn chỉnh đoạn văn bản**

Sử dụng [IParagraphFormat.Alignment](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/alignment/) để đặt căn chỉnh đoạn trong một khung văn bản. Giá trị có thể là căn giữa, căn trái, căn phải, canh lề, v.v.

Mã mẫu sau cho thấy cách căn đoạn văn ở **giữa**:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Đặt căn chỉnh của đoạn văn thành trung tâm.
    paragraph.ParagraphFormat.Alignment = TextAlignment.Center;

    presentation.Save("aligned_paragraph.pptx", SaveFormat.Pptx);
}
```

Kết quả:

![Đoạn văn đã căn chỉnh](aligned_paragraph.png)

## **Đặt độ trong suốt cho văn bản**

Độ trong suốt của văn bản được kiểm soát thông qua thành phần alpha của màu được gán cho [IPortionFormat.FillFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/iportionformat/fillformat/). Trong các ví dụ dưới đây, `alpha = 50` là giá trị kênh alpha ARGB trên thang 0–255, không phải là phần trăm trong suốt.

Mã mẫu dưới đây cho thấy cách áp dụng độ trong suốt cho **toàn bộ đoạn**:

```cs
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

Mã mẫu sau cho thấy cách áp dụng độ trong suốt cho **các phần văn bản có phông chữ in đậm**:

```cs
int alpha = 50;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
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
}
```

Kết quả:

![Các đoạn văn bản trong suốt](transparent_text_portions.png)

## **Đặt khoảng cách ký tự cho văn bản**

Sử dụng [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/vi/net/aspose.slides/ibaseportionformat/spacing/) để mở rộng hoặc thu hẹp khoảng cách giữa các ký tự trong một hộp văn bản.

Mã C# sau cho thấy cách mở rộng khoảng cách ký tự trong **toàn bộ đoạn**:

```cs
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

![Khoảng cách ký tự trong đoạn văn](character_spacing_in_paragraph.png)

Mã mẫu dưới đây cho thấy cách mở rộng khoảng cách ký tự trong **các phần văn bản có phông chữ in đậm**:

```cs
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

![Khoảng cách ký tự trong các đoạn văn bản](character_spacing_in_text_portions.png)

### **Tắt Kerning cho phông chữ cụ thể**

Trong một số trường hợp, văn bản do Aspose.Slides render có thể hơi chặt hơn so với cùng văn bản hiển thị trong PowerPoint. Điều này có thể xảy ra vì PowerPoint có thể bỏ qua dữ liệu kerning cho một số phông chữ, ngay cả khi phông chữ đó chứa thông tin kerning hợp lệ và kerning đã được bật trong cài đặt PowerPoint.

Để đầu ra render gần với PowerPoint hơn trong các trường hợp này, bạn có thể tắt kerning cho các phần văn bản sử dụng phông chữ bị ảnh hưởng. Đặt [IPortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/vi/net/aspose.slides/ibaseportionformat/kerningminimalsize/) thành giá trị lớn hơn đáng kể so với kích thước phông chữ thực tế:

```cs
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

Cài đặt này ngăn kerning được áp dụng cho các phần văn bản khớp và có thể giúp đồng bộ quá trình render của Aspose.Slides với kết quả hiển thị của PowerPoint đối với các phông chữ bị ảnh hưởng bởi hành vi đặc thù của PowerPoint.

## **Quản lý thuộc tính phông chữ văn bản**

Thuộc tính phông chữ có thể được đặt ở mức đoạn thông qua [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/defaultportionformat/) hoặc trên từng phần riêng lẻ qua [IPortionFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/iportionformat/).

Mã sau đặt phông chữ và kiểu văn bản cho toàn bộ đoạn: áp dụng kích thước phông chữ, in đậm, in nghiêng, gạch chân chấm và phông Times New Roman cho mọi phần trong đoạn.

```cs
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

![Thuộc tính phông chữ cho đoạn văn](font_properties_for_paragraph.png)

Mã mẫu dưới đây áp dụng các thuộc tính tương tự cho **các phần văn bản có phông chữ in đậm**:

```cs
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

![Thuộc tính phông chữ cho các đoạn văn bản](font_properties_for_text_portions.png)

## **Đặt xoay văn bản**

Sử dụng [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframeformat/textverticaltype/) để đặt hướng văn bản định sẵn trong một hình dạng.

Mã mẫu sau đặt hướng văn bản trong hình dạng thành `Vertical270`, làm xoay văn bản **90 độ ngược chiều kim đồng hồ**:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.TextVerticalType = TextVerticalType.Vertical270;

    presentation.Save("text_rotation.pptx", SaveFormat.Pptx);
}
```

Kết quả:

![Xoay văn bản](text_rotation.png)

## **Đặt xoay tùy chỉnh cho khung văn bản**

Sử dụng [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframeformat/rotationangle/) để đặt góc xoay tùy chỉnh cho một [ITextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/).

Mã mẫu dưới đây xoay khung văn bản 3 độ theo chiều kim đồng hồ trong hình dạng:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.RotationAngle = 3;

    presentation.Save("custom_text_rotation.pptx", SaveFormat.Pptx);
}
```

Kết quả:

![Xoay văn bản tùy chỉnh](custom_text_rotation.png)

## **Đặt khoảng cách dòng cho các đoạn văn**

Aspose.Slides cung cấp [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/spaceafter/), [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/spacebefore/), và [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/spacewithin/) để kiểm soát khoảng cách đoạn. Các thuộc tính này được sử dụng như sau:

* Đặt giá trị dương để chỉ định khoảng cách dòng dưới dạng phần trăm của chiều cao dòng.
* Đặt giá trị âm để chỉ định khoảng cách dòng bằng điểm.

Mã mẫu sau cho thấy cách chỉ định khoảng cách dòng trong đoạn:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    paragraph.ParagraphFormat.SpaceWithin = 200;

    presentation.Save("line_spacing.pptx", SaveFormat.Pptx);
}
```

Kết quả:

![Khoảng cách dòng trong đoạn văn](line_spacing.png)

## **Đặt loại Autofit cho khung văn bản**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframeformat/autofittype/) xác định cách văn bản hành xử khi vượt quá giới hạn của khung chứa. Sử dụng nó để kiểm soát việc thu nhỏ, tràn hoặc tự động thay đổi kích thước hình dạng.

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

    presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
}
```

## **Đặt neo cho khung văn bản**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframeformat/anchoringtype/) xác định cách văn bản được đặt theo chiều dọc trong một hình dạng, ví dụ ở trên, giữa hoặc dưới.

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

    presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
}
```

## **Đặt tab cho văn bản**

Sử dụng [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/defaulttabsize/) và [IParagraphFormat.Tabs](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/tabs/) để cấu hình các vị trí tab trong một đoạn.

```cs
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

![Các tab trong đoạn văn](paragraph_tabs.png)

## **Đặt ngôn ngữ kiểm tra chính tả**

Aspose.Slides cung cấp [IPortionFormat.LanguageId](https://reference.aspose.com/slides/vi/net/aspose.slides/iportionformat/languageid/), cho phép bạn đặt ngôn ngữ kiểm tra chính tả cho một phần văn bản. Ngôn ngữ này quyết định ngôn ngữ được sử dụng cho việc kiểm tra chính tả và ngữ pháp trong PowerPoint.

Mã mẫu sau cho thấy cách đặt ngôn ngữ kiểm tra cho một phần văn bản:

```cs
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

## **Đặt ngôn ngữ mặc định**

Sử dụng [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/vi/net/aspose.slides/loadoptions/defaulttextlanguage/) để xác định ngôn ngữ mặc định cho văn bản được tạo khi tải hoặc tạo bản thuyết trình.

```cs
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

## **Đặt kiểu văn bản mặc định**

Để áp dụng định dạng văn bản mặc định ở cấp độ bản thuyết trình, sử dụng [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/vi/net/aspose.slides/ipresentation/defaulttextstyle/).

Mã mẫu sau cho thấy cách đặt phông chữ đậm mặc định với kích thước 14 pt cho toàn bộ văn bản trên các slide trong một bản thuyết trình mới.

```cs
using (var presentation = new Presentation())
{
    // Lấy định dạng đoạn văn cấp cao nhất.
    var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

    if (paragraphFormat != null)
    {
        paragraphFormat.DefaultPortionFormat.FontHeight = 14;
        paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
    }

    presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
}
```

## **Trích xuất văn bản với hiệu ứng All-Caps**

Trong PowerPoint, áp dụng hiệu ứng phông chữ **All Caps** làm cho văn bản hiển thị dưới dạng chữ hoa trên slide ngay cả khi đã nhập bằng chữ thường. Khi bạn lấy phần văn bản này bằng Aspose.Slides, thư viện sẽ trả về văn bản đúng như khi nhập. Để khớp với văn bản hiển thị, kiểm tra [TextCapType](https://reference.aspose.com/slides/vi/net/aspose.slides/textcaptype/) và chuyển chuỗi trả về sang chữ hoa khi giá trị là `All`.

Giả sử chúng ta có hộp văn bản sau trên slide đầu tiên của tệp sample2.pptx.

![Hiệu ứng All Caps](all_caps_effect.png)

Mã mẫu dưới đây cho thấy cách trích xuất văn bản có hiệu ứng **All Caps** được áp dụng:

```cs
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

## **Câu hỏi thường gặp**

**Làm thế nào để sửa đổi văn bản trong bảng trên một slide?**

Để sửa đổi văn bản trong bảng trên một slide, sử dụng [ITable](https://reference.aspose.com/slides/vi/net/aspose.slides/itable/). Duyệt qua các ô và cập nhật mỗi ô thông qua [ICell.TextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/icell/textframe/) và định dạng đoạn qua [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraph/paragraphformat/).

**Làm thế nào để áp dụng màu gradient cho văn bản trong slide PowerPoint?**

Để áp dụng màu gradient cho văn bản, sử dụng [IPortionFormat.FillFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/iportionformat/fillformat/). Đặt [IFillFormat.FillType](https://reference.aspose.com/slides/vi/net/aspose.slides/ifillformat/filltype/) thành [FillType.Gradient](https://reference.aspose.com/slides/vi/net/aspose.slides/filltype/) và cấu hình các điểm dừng gradient, hướng và độ trong suốt.