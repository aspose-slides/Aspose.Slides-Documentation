---
title: Lấy Thuộc Tính Hiệu Quả của Hình Dạng từ Bản Trình Chiếu trong .NET
linktitle: Thuộc Tính Hiệu Quả
type: docs
weight: 50
url: /vi/net/shape-effective-properties/
keywords:
- thuộc tính hình dạng
- thuộc tính camera
- bộ ánh sáng
- hình dạng bevel
- khung văn bản
- kiểu văn bản
- chiều cao phông chữ
- định dạng nền
- PowerPoint
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu cách sử dụng Aspose.Slides cho .NET để phân biệt định dạng hình dạng cục bộ, kế thừa và hiệu quả trong các bản trình chiếu PowerPoint."
---
## **Hiểu Các Thuộc Tính Cục Bộ, Kế Thừa và Hiệu Quả**

Định dạng PowerPoint có thể đến từ nhiều nguồn. Giá trị được lưu trực tiếp trên một đối tượng là **giá trị cục bộ**. Nếu giá trị đó không được đặt, PowerPoint sẽ xem các nguồn định dạng cha, chẳng hạn như mặc định đoạn văn, kiểu văn bản, bố cục hoặc slide mẫu, chủ đề, hoặc các mặc định ở cấp trình chiếu. Những giá trị đó là **giá trị kế thừa**. Giá trị còn lại sau khi toàn bộ cấp độ được giải quyết là **giá trị hiệu quả**—giá trị được dùng để hiển thị đối tượng.

Ví dụ, một phần văn bản có thể không xác định chiều cao phông chữ của riêng nó. Giá trị cục bộ của nó [FontHeight](https://reference.aspose.com/slides/vi/net/aspose.slides/ibaseportionformat/fontheight/) sẽ là `float.NaN`, có nghĩa là “không được đặt ở đây”. Phần này có thể kế thừa chiều cao từ đoạn văn, kiểu văn bản mặc định của bài thuyết trình, hoặc một nguồn áp dụng khác. Gọi phương thức [GetEffective](https://reference.aspose.com/slides/vi/net/aspose.slides/iportionformat/geteffective/) trên định dạng phần sẽ trả về chiều cao đã được giải quyết cuối cùng.

Sử dụng hai loại dữ liệu định dạng cho các mục đích khác nhau:

- Đọc hoặc thay đổi một đối tượng định dạng cục bộ, chẳng hạn như [IPortionFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/iportionformat/), khi bạn cần kiểm soát nơi giá trị được định nghĩa.
- Đọc một đối tượng dữ liệu hiệu quả, chẳng hạn như [IPortionFormatEffectiveData](https://reference.aspose.com/slides/vi/net/aspose.slides/iportionformateffectivedata/), khi bạn cần kết quả cuối cùng đã được hiển thị. Dữ liệu hiệu quả chỉ được đọc.

## **So Sánh Các Giá Trị Cục Bộ, Kế Thừa và Hiệu Quả**

Ví dụ hoàn chỉnh sau tạo một hình dạng và áp dụng chiều cao phông chữ ở mức trình chiếu, đoạn văn và phần. Mỗi bước in ra các giá trị được xác định ở các mức đó và giá trị hiệu quả kết quả cho cùng một phần văn bản. Nó cũng minh họa lý do tại sao dữ liệu hiệu quả phải được đọc lại sau khi thay đổi định dạng.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 500, 80, false);
var textFrame = shape.AddTextFrame("Effective formatting");
var paragraph = textFrame.Paragraphs[0];
var portion = paragraph.Portions[0];

// Xác định các giá trị kế thừa ở hai mức khác nhau.
presentation.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight = 20;
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 28;

PrintFontHeights("The portion inherits from the paragraph", presentation, paragraph, portion);

// Giá trị cục bộ trên phần sẽ ghi đè cả hai giá trị kế thừa.
portion.PortionFormat.FontHeight = 36;
PrintFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

// Thay đổi giá trị kế thừa không ghi đè giá trị cục bộ hiện có.
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 30;
PrintFontHeights("The local value still has priority", presentation, paragraph, portion);

// Xóa giá trị cục bộ. Phần hiện sẽ kế thừa lại từ đoạn văn.
portion.PortionFormat.FontHeight = float.NaN;
PrintFontHeights("The local value is cleared", presentation, paragraph, portion);

// Xóa giá trị đoạn văn. Mặc định của bản trình chiếu sẽ cung cấp kết quả.
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = float.NaN;
PrintFontHeights("The paragraph value is cleared", presentation, paragraph, portion);

presentation.Save("effective-properties.pptx", SaveFormat.Pptx);

static void PrintFontHeights(string caption, Presentation presentation, IParagraph paragraph, IPortion portion)
{
    var presentationValue = presentation.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight;
    var paragraphValue = paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight;
    var localValue = portion.PortionFormat.FontHeight;

    // Đọc dữ liệu hiệu quả sau các thay đổi trước đó.
    var effectiveValue = portion.PortionFormat.GetEffective().FontHeight;

    Console.WriteLine(caption);
    Console.WriteLine($"  Presentation default: {FormatLocalValue(presentationValue)}");
    Console.WriteLine($"  Paragraph default:    {FormatLocalValue(paragraphValue)}");
    Console.WriteLine($"  Portion local:        {FormatLocalValue(localValue)}");
    Console.WriteLine($"  Portion effective:    {effectiveValue}");
}

static string FormatLocalValue(float value) => float.IsNaN(value) ? "<not set>" : value.ToString();
```

Ưu tiên trong ví dụ này là định dạng cục bộ của phần, tiếp theo là định dạng đoạn văn, rồi đến mặc định của trình chiếu. Các đối tượng khác có thể có chuỗi kế thừa khác nhau, nhưng nguyên tắc vẫn giống nhau: giá trị cụ thể hơn sẽ thắng, và [GetEffective](https://reference.aspose.com/slides/vi/net/aspose.slides/iportionformat/geteffective/) trả về kết quả cuối cùng.

## **Lấy Thuộc Tính Văn Bản Hiệu Quả**

Định dạng văn bản được chia thành nhiều đối tượng:

- [ITextFrameFormat.GetEffective()](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframeformat/geteffective/) giải quyết các thuộc tính khung văn bản như lề, neo, tự động điều chỉnh, và hướng văn bản dọc.
- [ITextStyle.GetEffective()](https://reference.aspose.com/slides/vi/net/aspose.slides/itextstyle/geteffective/) giải quyết định dạng đoạn văn cho mỗi cấp độ kiểu văn bản.
- [IParagraphFormat.GetEffective()](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/geteffective/) giải quyết các thuộc tính đoạn văn như căn chỉnh, thụt lề và dấu chấm.
- [IPortionFormat.GetEffective()](https://reference.aspose.com/slides/vi/net/aspose.slides/iportionformat/geteffective/) giải quyết các thuộc tính ký tự như chiều cao phông chữ, họ phông, màu, in đậm và in nghiêng.

Đối với ví dụ tiếp theo, tệp `text-formatting.pptx` phải chứa ít nhất một slide và một [AutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/autoshape/) có khung văn bản không rỗng. AutoShape có thể xuất hiện ở bất kỳ vị trí nào trong bộ sưu tập hình dạng; mã sẽ tìm kiếm một đối tượng phù hợp và xác thực nó trước khi sử dụng.

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("text-formatting.pptx");

if (presentation.Slides.Count == 0)
    throw new InvalidOperationException("The presentation contains no slides.");

var autoShapes = presentation.Slides[0].Shapes.OfType<IAutoShape>();
var shape = autoShapes.FirstOrDefault(candidate => HasNonEmptyText(candidate));

if (shape == null)
{
    throw new InvalidOperationException("The first slide must contain an AutoShape with non-empty text.");
}

var textFrame = shape.TextFrame;
var paragraph = textFrame.Paragraphs[0];
var portion = paragraph.Portions[0];

var textFrameEffective = textFrame.TextFrameFormat.GetEffective();
var paragraphEffective = paragraph.ParagraphFormat.GetEffective();
var portionEffective = portion.PortionFormat.GetEffective();

Console.WriteLine("Text frame margins:");
Console.WriteLine($"  Left: {textFrameEffective.MarginLeft}");
Console.WriteLine($"  Top: {textFrameEffective.MarginTop}");
Console.WriteLine($"  Right: {textFrameEffective.MarginRight}");
Console.WriteLine($"  Bottom: {textFrameEffective.MarginBottom}");
Console.WriteLine($"Paragraph alignment: {paragraphEffective.Alignment}");
Console.WriteLine($"Font height: {portionEffective.FontHeight}");
Console.WriteLine($"Bold: {portionEffective.FontBold}");

var effectiveTextStyle = textFrame.TextFrameFormat.TextStyle.GetEffective();
for (var level = 0; level < 9; level++)
{
    var levelEffective = effectiveTextStyle.GetLevel(level);
    Console.WriteLine($"Level {level} indent: {levelEffective.Indent}");
}

static bool HasNonEmptyText(IAutoShape shape)
{
    if (shape.TextFrame == null)
        return false;

    if (shape.TextFrame.Paragraphs.Count == 0)
        return false;

    return shape.TextFrame.Paragraphs[0].Portions.Count > 0;
}
```

## **Lấy Thuộc Tính 3D Hiệu Quả**

[IThreeDFormat.GetEffective()](https://reference.aspose.com/slides/vi/net/aspose.slides/ithreedformat/geteffective/) trả về một đối tượng [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/vi/net/aspose.slides/ithreedformateffectivedata/) nhóm tất cả các cài đặt 3D đã được giải quyết. Các thuộc tính [Camera](https://reference.aspose.com/slides/vi/net/aspose.slides/ithreedformateffectivedata/camera/), [LightRig](https://reference.aspose.com/slides/vi/net/aspose.slides/ithreedformateffectivedata/lightrig/), [BevelTop](https://reference.aspose.com/slides/vi/net/aspose.slides/ithreedformateffectivedata/beveltop/) và [BevelBottom](https://reference.aspose.com/slides/vi/net/aspose.slides/ithreedformateffectivedata/bevelbottom/) của nó hiển thị dữ liệu hiệu quả tương ứng. Đọc các cài đặt liên quan này cùng nhau giúp dễ dàng hơn trong việc hiểu hình dạng 3D cuối cùng.

Đối với ví dụ này, tệp `shape-3d.pptx` phải chứa ít nhất một hình dạng trên slide đầu tiên. Áp dụng cài đặt camera 3D, ánh sáng hoặc bevel cho hình dạng đó nếu bạn muốn đầu ra chứa các giá trị khác ngoài mặc định.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("shape-3d.pptx");

if (presentation.Slides.Count == 0 || presentation.Slides[0].Shapes.Count == 0)
{
    throw new InvalidOperationException("The first slide must contain a shape.");
}

var shape = presentation.Slides[0].Shapes[0];
var threeDEffective = shape.ThreeDFormat.GetEffective();

Console.WriteLine("Camera:");
Console.WriteLine($"  Type: {threeDEffective.Camera.CameraType}");
Console.WriteLine($"  Field of view: {threeDEffective.Camera.FieldOfViewAngle}");
Console.WriteLine($"  Zoom: {threeDEffective.Camera.Zoom}");

Console.WriteLine("Light rig:");
Console.WriteLine($"  Type: {threeDEffective.LightRig.LightType}");
Console.WriteLine($"  Direction: {threeDEffective.LightRig.Direction}");

Console.WriteLine("Top bevel:");
Console.WriteLine($"  Type: {threeDEffective.BevelTop.BevelType}");
Console.WriteLine($"  Width: {threeDEffective.BevelTop.Width}");
Console.WriteLine($"  Height: {threeDEffective.BevelTop.Height}");
```

## **Lấy Định Dạng Bảng Hiệu Quả**

Định dạng bảng có thể đến từ kiểu bảng và từ các định dạng áp dụng cho toàn bộ bảng, một cột, một hàng hoặc một ô riêng lẻ. Khi có xung đột giữa các màu nền được định nghĩa rõ ràng, ưu tiên là ô, hàng, cột và rồi toàn bảng. Định dạng hiệu quả của một ô là định dạng cuối cùng được dùng để vẽ ô đó.

Đối với ví dụ này, tệp `table-formatting.pptx` phải chứa ít nhất một bảng trên slide đầu tiên. Bảng phải có ít nhất một hàng và một cột. Mã sẽ tìm kiếm một đối tượng [ITable](https://reference.aspose.com/slides/vi/net/aspose.slides/itable/) thay vì giả định rằng `Shapes[0]` là một bảng.

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("table-formatting.pptx");

if (presentation.Slides.Count == 0)
    throw new InvalidOperationException("The presentation contains no slides.");

var table = presentation.Slides[0].Shapes.OfType<ITable>().FirstOrDefault();

if (table == null)
    throw new InvalidOperationException("The first slide must contain a table.");

if (table.Rows.Count == 0 || table.Columns.Count == 0)
    throw new InvalidOperationException("The table must contain at least one cell.");

var tableEffective = table.TableFormat.GetEffective();
var rowEffective = table.Rows[0].RowFormat.GetEffective();
var columnEffective = table.Columns[0].ColumnFormat.GetEffective();
var cellEffective = table[0, 0].CellFormat.GetEffective();

Console.WriteLine($"Table fill: {tableEffective.FillFormat.FillType}");
Console.WriteLine($"Row fill: {rowEffective.FillFormat.FillType}");
Console.WriteLine($"Column fill: {columnEffective.FillFormat.FillType}");
Console.WriteLine($"Final cell fill: {cellEffective.FillFormat.FillType}");
```

Nếu bạn cần màu thay vì chỉ loại nền, trước tiên kiểm tra [FillType](https://reference.aspose.com/slides/vi/net/aspose.slides/ifillformateffectivedata/filltype/) hiệu quả, sau đó đọc thuộc tính áp dụng cho loại đó—ví dụ, [SolidFillColor](https://reference.aspose.com/slides/vi/net/aspose.slides/ifillformateffectivedata/solidfillcolor/) cho nền đặc.

## **Đọc Lại Dữ Liệu Hiệu Quả Sau Khi Thay Đổi**

Dữ liệu hiệu quả mô tả cấu trúc định dạng tại thời điểm nó được giải quyết. Gọi lại `GetEffective` sau khi thay đổi bất kỳ yếu tố nào có thể tham gia vào cấu trúc đó, bao gồm:

- định dạng cục bộ của đối tượng;
- mặc định đoạn văn hoặc khung văn bản;
- kiểu bảng, bảng, cột, hàng hoặc định dạng ô;
- định dạng bố cục hoặc slide mẫu;
- dữ liệu chủ đề hoặc mặc định ở cấp trình chiếu;
- bố cục hoặc mẫu được gán cho một slide.

Không nên giữ một đối tượng dữ liệu hiệu quả như một ảnh chụp cố định. Aspose.Slides có thể lưu bộ nhớ đệm một số dữ liệu hiệu quả nội bộ, và một lời gọi `GetEffective` sau này có thể làm mới dữ liệu đó. Nếu bạn cần so sánh các giá trị trước và sau khi thay đổi, sao chép các giá trị vô hướng cần thiết—như chiều cao phông chữ, màu, căn chỉnh, hoặc độ rộng bevel—vào các biến của bạn trước khi thực hiện thay đổi.

Để thay đổi một giá trị, cập nhật đối tượng định dạng cục bộ thích hợp và sau đó gọi `GetEffective` để xác minh kết quả. Các đối tượng dữ liệu hiệu quả tự chúng chỉ được đọc.

## **Câu Hỏi Thường Gặp**

**Làm sao tôi biết mức nào đã cung cấp giá trị hiệu quả?**

Dữ liệu hiệu quả chứa giá trị cuối cùng, không phải nguồn gốc của nó. Kiểm tra các đối tượng cục bộ áp dụng từ mức cụ thể nhất ra ngoài. Đối với văn bản, điều này có thể bao gồm phần, đoạn văn, khung văn bản, bố cục, mẫu, chủ đề và các mặc định của trình chiếu. Các giá trị không xác định như `float.NaN` hoặc `null` cho biết việc tìm kiếm sẽ tiếp tục ở mức khác.

**Đi gì sẽ xảy ra khi không có mức nào định nghĩa một thuộc tính?**

Aspose.Slides sẽ giải quyết giá trị mặc định thích hợp của PowerPoint hoặc thư viện. Giá trị đã giải quyết đó xuất hiện trong dữ liệu hiệu quả mặc dù không có đối tượng cục bộ nào định nghĩa rõ ràng.

**Tại sao đôi khi một giá trị hiệu quả lại bằng với giá trị cục bộ?**

Giá trị cục bộ đã thắng trong phép tính kế thừa. Điều này là mong đợi khi thuộc tính được đặt rõ ràng trên đối tượng và không có quy tắc cụ thể hơn nào ghi đè.

**Khi nào tôi nên sử dụng dữ liệu cục bộ thay vì dữ liệu hiệu quả?**

Sử dụng dữ liệu cục bộ để kiểm tra hoặc chỉnh sửa một mức định dạng cụ thể. Sử dụng dữ liệu hiệu quả khi bạn cần giao diện cuối cùng sau khi kế thừa, các quy tắc chủ đề và các kiểu áp dụng đã được giải quyết. Ví dụ [complete comparison example](#compare-local-inherited-and-effective-values) thể hiện cả hai trong cùng một quy trình làm việc.