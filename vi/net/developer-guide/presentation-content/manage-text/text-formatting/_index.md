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

Bài viết này trình bày cách định dạng văn bản trong các bản trình chiếu PowerPoint và OpenDocument bằng Aspose.Slides cho .NET. Nó bao gồm màu nền, độ trong suốt, khoảng cách ký tự, thuộc tính phông chữ, xoay, khoảng cách đoạn, hành vi tự động vừa, neo văn bản, điểm tab và cài đặt ngôn ngữ.

Trừ khi có ghi chú khác, các ví dụ sử dụng [sample.pptx](sample.pptx). Đối tượng hình dạng đầu tiên trên slide đầu tiên là một hộp văn bản, và đoạn đầu tiên của nó chứa văn bản được hiển thị bên dưới. Cả chỉ mục slide và shape đều tính từ 0. Các ví dụ chọn phần in đậm sử dụng định dạng hiệu quả, bao gồm định dạng in đậm được kế thừa:

![Văn bản mẫu](sample_text.png)

Để tìm và đánh dấu văn bản nguyên mẫu hoặc các khớp biểu thức chính quy, xem [Tìm kiếm và Thay thế Văn bản](/slides/vi/net/search-and-replace-text/).

## **Đặt Màu Nền Văn Bản**

Sử dụng [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) để đặt màu tô sáng mặc định cho một đoạn, hoặc sử dụng [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/highlightcolor/) cho các phần văn bản riêng lẻ.

Ví dụ sau đặt màu tô sáng xám nhạt làm mặc định cho đoạn đầu tiên. Màu tô sáng rõ ràng trên các phần riêng lẻ sẽ có ưu tiên hơn mặc định này:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Đặt màu tô sáng cho toàn bộ đoạn.
paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
```

Kết quả:

![Đoạn văn bản màu xám](gray_paragraph.png)

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
        // Đặt màu tô sáng cho phần văn bản.
        portion.PortionFormat.HighlightColor.Color = Color.LightGray;
    }
}

presentation.Save("gray_text_portions.pptx", SaveFormat.Pptx);
```

Kết quả:

![Các phần văn bản màu xám](gray_text_portions.png)

## **Căn Đoạn Văn Bản**

Sử dụng [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) để đặt căn chỉnh đoạn trong khung văn bản. Giá trị có thể là trung tâm, căn trái, căn phải, căn đều, v.v.

Ví dụ mã sau cho thấy cách căn đoạn **ở giữa**:

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

![Đoạn văn bản đã căn chỉnh](aligned_paragraph.png)

## **Căn Phông Chữ Trong Một Dòng**

Sử dụng [IParagraphFormat.FontAlignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/fontalignment/) để căn dọc các phần văn bản có kích thước phông chữ khác nhau trong một dòng. Cài đặt này áp dụng cho toàn bộ đoạn và kiểm soát căn chỉnh trong mỗi dòng của nó.

Ví dụ tự chứa dưới đây tạo bốn hộp văn bản có nhãn trên một slide. Mỗi đoạn chứa cùng một văn bản với kích thước 18, 36 và 54 điểm, với căn chỉnh phông chữ khác nhau. Nó sử dụng Arial, vô hiệu hoá tự động vừa và cuộn, và giữ khung văn bản đủ lớn cho một dòng duy nhất.

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

![So sánh căn Baseline, Top, Center và Bottom với kích thước phông chữ hỗn hợp](font_alignment.png)

Căn phông chữ sử dụng các chỉ số phông, vì vậy các cạnh hiển thị của các ký tự riêng lẻ không nhất thiết phải thẳng hàng hoàn toàn. Ví dụ bao gồm cả một ký tự viết hoa và một ký tự có phần chỗ xuống để minh họa sự khác biệt giữa căn baseline và bottom. Tính sẵn có và thay thế phông, các ký tự được dùng, và sự khác nhau về kích thước phông ảnh hưởng đến kết quả. Kích thước khung, lề, khoảng cách dòng, cuộn và tự động vừa cũng ảnh hưởng đến bố cục; hãy sử dụng cùng phông và cùng cài đặt bố cục khi so sánh các chế độ.

Cài đặt này khác với [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/), điều khiển căn chỉnh ngang của đoạn, và [ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/), định vị khối văn bản theo chiều dọc trong shape. Định dạng siêu chỉ số và chỉ số dưới bằng [IBasePortionFormat.Escapement](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/escapement/) dịch chuyển các phần riêng lẻ so với baseline thay vì đặt căn phông cho các dòng của đoạn.

## **Đặt Độ Trong Suốt cho Văn Bản**

Độ trong suốt của văn bản được kiểm soát thông qua thành phần alpha của màu được gán cho [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/). Trong các ví dụ dưới đây, `alpha = 50` là giá trị kênh alpha ARGB trên thang 0–255, không phải là phần trăm trong suốt.

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

![Đoạn văn bản trong suốt](transparent_paragraph.png)

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

![Các phần văn bản trong suốt](transparent_text_portions.png)

## **Đặt Khoảng Cách Ký Tự cho Văn Bản**

Sử dụng [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/spacing/) để mở rộng hoặc thu gọn khoảng cách giữa các ký tự trong một hộp văn bản. Các ví dụ thêm 3 điểm khoảng cách; giá trị âm sẽ thu gọn văn bản.

Mã C# dưới đây cho thấy cách mở rộng khoảng cách ký tự trong **toàn bộ đoạn**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Lưu ý: Sử dụng các giá trị âm để nén khoảng cách ký tự.
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
        // Lưu ý: Sử dụng các giá trị âm để nén khoảng cách ký tự.
        portion.PortionFormat.Spacing = 3;  // Mở rộng khoảng cách ký tự.
    }
}

presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
```

Kết quả:

![Khoảng cách ký tự trong các phần văn bản](character_spacing_in_text_portions.png)

### **Tắt Kerning cho Các Phông Chữ Cụ Thể**

Trong một số trường hợp, văn bản do Aspose.Slides hiển thị có thể trông hơi chặt hơn so với cùng văn bản trong PowerPoint. Điều này có thể xảy ra vì PowerPoint có thể bỏ qua dữ liệu kerning cho một số phông, ngay cả khi phông chứa thông tin kerning hợp lệ và kerning được bật trong cài đặt PowerPoint.

Để làm cho kết quả hiển thị gần với PowerPoint hơn, bạn có thể tắt kerning cho các phần văn bản sử dụng phông bị ảnh hưởng. Đặt [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/kerningminimalsize/) thành giá trị lớn hơn kích thước phông thực tế. Ví dụ này yêu cầu "presentation.pptx" có một hộp văn bản là shape đầu tiên trên slide đầu tiên. Nó kiểm tra tên phông hiệu quả, bao gồm các phông kế thừa, và đặt ngưỡng 100 điểm cho các phần sử dụng Roboto. Điều này sẽ tắt kerning cho các phần khớp có kích thước phông dưới 100 điểm:

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

Đối với văn bản khớp dưới ngưỡng, cài đặt này ngăn kerning và có thể giúp hiển thị Aspose.Slides gần với kết quả trực quan của PowerPoint đối với các phông bị hành vi đặc thù của PowerPoint ảnh hưởng.

## **Quản Lý Thuộc Tính Phông Chữ Văn Bản**

Thuộc tính phông chữ có thể được đặt ở mức đoạn thông qua [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) hoặc trên các phần riêng lẻ thông qua [IPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/).

Ví dụ dưới đây đặt phông mặc định cho đoạn đầu tiên là Times New Roman 12 điểm với định dạng in đậm, in nghiêng và gạch dưới dạng chấm. Định dạng rõ ràng trên các phần riêng lẻ sẽ có ưu tiên hơn các mặc định này:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Đặt các thuộc tính phông chữ cho đoạn.
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

Ví dụ sau áp dụng Times New Roman 13 điểm, định dạng nghiêng và gạch dưới dạng chấm cho các phần có định dạng hiệu quả là in đậm:

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

![Thuộc tính phông chữ cho các phần văn bản](font_properties_for_text_portions.png)

## **Đặt Xoay Văn Bản**

Sử dụng [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/textverticaltype/) để đặt hướng văn bản được xác định trước trong một shape.

Mã dưới đây đặt hướng văn bản trong shape thành [TextVerticalType.Vertical270](https://reference.aspose.com/slides/net/aspose.slides/textverticaltype/), sẽ xoay văn bản **90 độ ngược chiều kim đồng hồ**:

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

## **Đặt Xoay Tùy Chỉnh cho Khung Văn Bản**

Sử dụng [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/rotationangle/) để đặt góc xoay tùy chỉnh cho một [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/).

Mã dưới đây xoay khung văn bản 3 độ theo chiều kim đồng hồ trong shape:

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

![Xoay văn bản tùy chỉnh](custom_text_rotation.png)

## **Đặt Khoảng Cách Dòng cho Các Đoạn**

Aspose.Slides cung cấp [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spaceafter/), [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacebefore/), và [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/) để kiểm soát khoảng cách đoạn. Các thuộc tính này được sử dụng như sau:

* Dùng giá trị dương để chỉ định khoảng cách dòng dưới dạng phần trăm chiều cao dòng.
* Dùng giá trị âm để chỉ định khoảng cách dòng bằng điểm.

Ví dụ dưới đây đặt khoảng cách trong đoạn đầu tiên là 200 % chiều cao dòng (gấp đôi):

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

## **Kiểm Soát Ngắt Dòng**

Các quy tắc ngắt dòng của đoạn hữu ích trong các khối văn bản hẹp và các bản trình chiếu hỗn hợp Latin và Đông Á. Các thuộc tính sau thuộc về [IParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/), do đó áp dụng cho toàn đoạn:

- [LatinLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/latinlinebreak/) kiểm soát quy tắc ngắt dòng Latin. Trong văn bản hỗn hợp, thay đổi nó cũng có thể ảnh hưởng tới vị trí ngắt dòng của văn bản và dấu chấm câu Đông Á liền kề.
- [EastAsianLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/eastasianlinebreak/) kiểm soát quy tắc ngắt dòng Đông Á, bao gồm các hạn chế về ký tự ở đầu và cuối dòng.

Các quy tắc này không thay thế [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/), thứ cho phép tự động cuộn trong khung văn bản. Chúng ảnh hưởng tới bố cục khi cuộn xảy ra; chúng không chèn ký tự ngắt dòng. Một ngắt dòng rõ ràng buộc một dòng mới trong đoạn bất kể độ rộng khả dụng.

Ví dụ tự chứa dưới đây tạo một khối văn bản hẹp chứa tiếng Trung và Latin. Nó đặt cả hai thuộc tính ngắt dòng một cách rõ ràng và lưu "line_breaking.pptx". Để thử nghiệm từng quy tắc, thay đổi giá trị thuộc tính đó trong khi giữ các cài đặt còn lại cố định. Ví dụ sử dụng Arial 24 pt và SimSun với độ rộng khung 160 pt và lề ngang khung bằng 0. [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) được đặt thành [TextAutofitType.None](https://reference.aspose.com/slides/net/aspose.slides/textautofittype/) để kích thước văn bản và kích thước khung giữ nguyên:

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

[IParagraphFormat.HangingPunctuation](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/hangingpunctuation/) cho phép các dấu câu đủ điều kiện mở rộng ra ngoài cạnh phải của dòng văn bản thay vì chiếm dòng tiếp theo. Nó áp dụng cho toàn đoạn và khác với thụt lề treo.

Ví dụ tự chứa dưới đây bật dấu câu treo trong khung văn bản rộng 100 pt và lưu "hanging_punctuation.pptx". Với Arial 24 pt và lề ngang khung bằng 0, dấu chấm cuối cùng vẫn ở sau từ “sentence” và kéo ra ngoài cạnh phải. Đặt thuộc tính thành [NullableBool.False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) để so sánh: với các cài đặt này, dấu chấm sẽ chiếm một dòng riêng. Cuộn được bật và tự động vừa bị tắt để giữ độ rộng khả dụng cố định.

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

Không phải mọi dấu câu đều có thể treo. Các [điều kiện phông và bố cục mô tả ở trên](#control-line-breaking) cũng áp dụng cho so sánh này: thay đổi phông, độ rộng khả dụng, lề, hoặc cài đặt tự động vừa có thể làm mất sự khác biệt nhìn thấy.

## **Đặt Loại Tự Động Vừa cho Khung Văn Bản**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) xác định cách văn bản hành xử khi vượt quá giới hạn của vùng chứa. Sử dụng nó để kiểm soát việc văn bản co lại, tràn, hoặc tự động thay đổi kích thước shape. Ví dụ dưới đây cấu hình shape để thay đổi kích thước phù hợp với văn bản và lưu kết quả thành "autofit_type.pptx".

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
```

Để đếm số dòng sau khi tự động cuộn và xem cách thay đổi độ rộng văn bản hoặc shape ảnh hưởng tới kết quả, xem [Count Rendered Lines](/slides/vi/net/manage-paragraph/). Số lượng dòng một mình không cho biết liệu văn bản có tràn khỏi vùng chứa hay không.

## **Đặt Neo cho Khung Văn Bản**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/) định nghĩa cách văn bản được định vị theo chiều dọc bên trong shape, ví dụ ở trên, giữa hoặc dưới. Ví dụ dưới đây neo văn bản vào đáy shape đầu tiên và lưu kết quả thành "text_anchor.pptx".

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

Sử dụng [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaulttabsize/) và [IParagraphFormat.Tabs](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/tabs/) để cấu hình các vị trí tab trong một đoạn. Ví dụ dưới đây đặt khoảng cách tab mặc định là 100 pt và thêm một tab trái ở 30 pt. Các cài đặt này ảnh hưởng đến văn bản chứa ký tự tab.

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

## **Đặt Ngôn Ngữ Kiểm Tra**

Aspose.Slides cung cấp [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/), cho phép bạn đặt ngôn ngữ kiểm tra cho một phần văn bản. Ngôn ngữ kiểm tra quyết định ngôn ngữ được sử dụng cho kiểm tra chính tả và ngữ pháp trong PowerPoint.

Ví dụ dưới này yêu cầu "presentation.pptx" có một hộp văn bản là shape đầu tiên trên slide đầu tiên và ít nhất một đoạn. Nó thay thế nội dung của đoạn đầu tiên bằng "1。", đặt SimSun làm phông và gán ngôn ngữ kiểm tra tiếng Trung giản thể (`zh-CN`). Sau đó lưu kết quả thành "proofing_language.pptx":

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

## **Đặt Ngôn Ngữ Mặc Định**

Sử dụng [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/defaulttextlanguage/) để xác định ngôn ngữ mặc định cho văn bản được tạo khi tải hoặc tạo một bản trình chiếu. Ví dụ dưới đây tạo một bản trình chiếu với tiếng Anh Hoa Kỳ làm ngôn ngữ văn bản mặc định, thêm một hộp văn bản và in `en-US` cho phần văn bản đầu tiên của nó.

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

// Kiểm tra ngôn ngữ của phần đầu tiên.
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine(portion.PortionFormat.LanguageId);
```

## **Đặt Kiểu Văn Bản Mặc Định**

Để áp dụng định dạng văn bản mặc định ở mức trình chiếu, sử dụng [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/defaulttextstyle/).

Ví dụ dưới đây đặt phông chữ đậm 14 pt làm mặc định cho các đoạn cấp cao trong một bản trình chiếu mới và lưu thành "default_text_style.pptx". Văn bản có thể kế thừa các mặc định này trừ khi có định dạng cụ thể hơn ghi đè.

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

## **Trích Xuất Văn Bản với Hiệu Ứng Viết Hoa**

Trong PowerPoint, áp dụng hiệu ứng **All Caps** làm cho văn bản hiển thị ở dạng viết hoa trên slide ngay cả khi nó được gõ bằng chữ thường. Khi bạn truy xuất phần văn bản đó bằng Aspose.Slides, thư viện trả về văn bản đúng như khi nhập. Để khớp với văn bản hiển thị, kiểm tra [TextCapType](https://reference.aspose.com/slides/net/aspose.slides/textcaptype/) và chuyển chuỗi trả về thành chữ hoa khi giá trị là `All`.

Ví dụ này yêu cầu "sample2.pptx" có một hộp văn bản là shape đầu tiên trên slide đầu tiên. Phần đầu tiên của đoạn đầu tiên chứa "Hello, Aspose!" với hiệu ứng All Caps được áp dụng, như hình dưới.

![Hiệu ứng All Caps](all_caps_effect.png)

Mã dưới đây cho thấy cách trích xuất văn bản có hiệu ứng **All Caps** được áp dụng:

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

**Làm sao tôi có thể chỉnh sửa văn bản trong bảng trên một slide?**

Để chỉnh sửa văn bản trong bảng trên một slide, sử dụng [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/). Duyệt qua các ô và cập nhật mỗi ô thông qua [ICell.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/) và định dạng đoạn qua [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/paragraphformat/).

**Làm sao tôi có thể áp dụng màu gradient cho văn bản trên slide PowerPoint?**

Để áp dụng màu gradient cho văn bản, sử dụng [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/). Đặt [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) thành [FillType.Gradient](https://reference.aspose.com/slides/net/aspose.slides/filltype/) và cấu hình các điểm dừng gradient, hướng và độ trong suốt.