---
title: Lấy Thuộc Tính Effective của Hình trong Bài Thuyết Trình bằng .NET
linktitle: Thuộc Tính Effective
type: docs
weight: 50
url: /vi/net/shape-effective-properties/
keywords:
- thuộc tính hình
- thuộc tính camera
- bộ đèn chiếu sáng
- hình bevel
- khung văn bản
- kiểu văn bản
- độ cao phông chữ
- định dạng tô
- PowerPoint
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Khám phá cách Aspose.Slides cho .NET tính toán và áp dụng các thuộc tính shape effective để render PowerPoint một cách chính xác."
---
## **Tổng quan**

Chủ đề này giải thích sự khác nhau giữa các thuộc tính **local** và **effective**. Giá trị local là các giá trị được đặt trực tiếp ở một mức định dạng cụ thể, chẳng hạn như:

1. Thuộc tính phần trên một slide.
1. Kiểu chữ của hình mẫu trên một bố cục hoặc slide master, khi hình dạng khung văn bản của phần đó có kiểu chữ.
1. Cài đặt văn bản toàn cục trong một bài thuyết trình.

Giá trị local có thể được định nghĩa hoặc bỏ qua ở bất kỳ mức nào. Khi Aspose.Slides cần định dạng cuối cùng "as rendered", nó giải quyết chuỗi kế thừa và trả về các giá trị **effective**. Bạn có thể lấy chúng bằng cách gọi phương thức `GetEffective` trên đối tượng định dạng local.

Ví dụ sau đây cho thấy cách lấy các giá trị effective. Giả sử hình dạng đầu tiên trên slide đầu tiên là một [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/) có khung văn bản và ít nhất một phần.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var localTextFrameFormat = shape.TextFrame.TextFrameFormat;
var effectiveTextFrameFormat = localTextFrameFormat.GetEffective();

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
var localPortionFormat = portion.PortionFormat;
var effectivePortionFormat = localPortionFormat.GetEffective();
```

{{% alert color="info" %}}
Dữ liệu định dạng effective đại diện cho định dạng hiện tại đã được tính toán sau khi áp dụng kế thừa. Trong triển khai hiện tại, một số đối tượng dữ liệu effective, chẳng hạn như [IPortionFormatEffectiveData](https://reference.aspose.com/slides/vi/net/aspose.slides/iportionformateffectivedata/), có thể được lưu trong bộ nhớ cache nội bộ. Gọi lại `GetEffective` sau khi thay đổi định dạng cha hoặc kế thừa có thể làm mới dữ liệu đã cache, và một đối tượng đã lấy trước đó có thể không còn đại diện cho trạng thái trước đó. Nếu bạn cần bảo lưu các giá trị effective để sử dụng sau, sao chép các thuộc tính cần thiết, chẳng hạn như chiều cao phông chữ, màu nền, kiểu phông chữ hoặc căn chỉnh, vào đối tượng dữ liệu của riêng bạn.
{{% /alert %}}

## **Lấy Thuộc Tính Effective của Camera**

Aspose.Slides cho phép bạn lấy các thuộc tính effective của một camera. Giao diện [ICameraEffectiveData](https://reference.aspose.com/slides/vi/net/aspose.slides/icameraeffectivedata/) đại diện cho một đối tượng bất biến chứa các thuộc tính camera effective. Một thể hiện [ICameraEffectiveData](https://reference.aspose.com/slides/vi/net/aspose.slides/icameraeffectivedata/) được cung cấp thông qua [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/vi/net/aspose.slides/ithreedformateffectivedata/), cung cấp các giá trị effective cho [IThreeDFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/ithreedformat/).

Mẫu code sau đây cho thấy cách lấy các thuộc tính effective cho camera. Giả sử hình dạng đầu tiên trên slide đầu tiên có định dạng 3D.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective camera properties =");
Console.WriteLine("Type: " + threeDEffectiveData.Camera.CameraType);
Console.WriteLine("Field of view: " + threeDEffectiveData.Camera.FieldOfViewAngle);
Console.WriteLine("Zoom: " + threeDEffectiveData.Camera.Zoom);
```

## **Lấy Thuộc Tính Effective của Light Rig**

Aspose.Slides cho phép bạn lấy các thuộc tính effective của một light rig. Giao diện [ILightRigEffectiveData](https://reference.aspose.com/slides/vi/net/aspose.slides/ilightrigeffectivedata/) đại diện cho một đối tượng bất biến chứa các thuộc tính light rig effective. Một thể hiện [ILightRigEffectiveData](https://reference.aspose.com/slides/vi/net/aspose.slides/ilightrigeffectivedata/) được cung cấp thông qua [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/vi/net/aspose.slides/ithreedformateffectivedata/), cung cấp các giá trị effective cho [IThreeDFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/ithreedformat/).

Mẫu code sau đây cho thấy cách lấy các thuộc tính effective cho light rig. Giả sử hình dạng đầu tiên trên slide đầu tiên có định dạng 3D.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective light rig properties =");
Console.WriteLine("Type: " + threeDEffectiveData.LightRig.LightType);
Console.WriteLine("Direction: " + threeDEffectiveData.LightRig.Direction);
```

## **Lấy Thuộc Tính Effective của Bevel Shape**

Aspose.Slides cho phép bạn lấy các thuộc tính effective của một shape bevel. Giao diện [IShapeBevelEffectiveData](https://reference.aspose.com/slides/vi/net/aspose.slides/ishapebeveleffectivedata/) đại diện cho một đối tượng bất biến chứa các thuộc tính relief mặt cho một shape. Một thể hiện [IShapeBevelEffectiveData](https://reference.aspose.com/slides/vi/net/aspose.slides/ishapebeveleffectivedata/) được cung cấp thông qua [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/vi/net/aspose.slides/ithreedformateffectivedata/), cung cấp các giá trị effective cho [IThreeDFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/ithreedformat/).

Mẫu code sau đây cho thấy cách lấy các thuộc tính effective cho bevel trên cùng của một shape. Giả sử hình dạng đầu tiên trên slide đầu tiên có định dạng 3D.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective shape's top face relief properties =");
Console.WriteLine("Type: " + threeDEffectiveData.BevelTop.BevelType);
Console.WriteLine("Width: " + threeDEffectiveData.BevelTop.Width);
Console.WriteLine("Height: " + threeDEffectiveData.BevelTop.Height);
```

## **Lấy Thuộc Tính Effective của Text Frame**

Sử dụng Aspose.Slides, bạn có thể lấy các thuộc tính effective của một khung văn bản. Giao diện [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframeformateffectivedata/) chứa các thuộc tính định dạng text frame effective.

Mẫu code sau đây cho thấy cách lấy các thuộc tính định dạng text frame effective. Giả sử hình dạng đầu tiên trên slide đầu tiên là một [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/) có khung văn bản.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var textFrameFormat = shape.TextFrame.TextFrameFormat;
var effectiveTextFrameFormat = textFrameFormat.GetEffective();

Console.WriteLine("Anchoring type: " + effectiveTextFrameFormat.AnchoringType);
Console.WriteLine("Autofit type: " + effectiveTextFrameFormat.AutofitType);
Console.WriteLine("Text vertical type: " + effectiveTextFrameFormat.TextVerticalType);
Console.WriteLine("Margins");
Console.WriteLine("   Left: " + effectiveTextFrameFormat.MarginLeft);
Console.WriteLine("   Top: " + effectiveTextFrameFormat.MarginTop);
Console.WriteLine("   Right: " + effectiveTextFrameFormat.MarginRight);
Console.WriteLine("   Bottom: " + effectiveTextFrameFormat.MarginBottom);
```

## **Lấy Thuộc Tính Effective của Text Style**

Sử dụng Aspose.Slides, bạn có thể lấy các thuộc tính effective của một text style. Giao diện [ITextStyleEffectiveData](https://reference.aspose.com/slides/vi/net/aspose.slides/itextstyleeffectivedata/) chứa các thuộc tính text style effective.

Mẫu code sau đây cho thấy cách lấy các thuộc tính text style effective. Giả sử hình dạng đầu tiên trên slide đầu tiên là một [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/) có khung văn bản.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var effectiveTextStyle = shape.TextFrame.TextFrameFormat.TextStyle.GetEffective();
var levelCount = 9;

for (var levelIndex = 0; levelIndex < levelCount; levelIndex++)
{
    var effectiveStyleLevel = effectiveTextStyle.GetLevel(levelIndex);
    Console.WriteLine("= Effective paragraph formatting for style level #" + levelIndex + " =");

    Console.WriteLine("Depth: " + effectiveStyleLevel.Depth);
    Console.WriteLine("Indent: " + effectiveStyleLevel.Indent);
    Console.WriteLine("Alignment: " + effectiveStyleLevel.Alignment);
    Console.WriteLine("Font alignment: " + effectiveStyleLevel.FontAlignment);
}
```

## **Lấy Giá Trị Chiều Cao Phông Chữ Effective**

Sử dụng Aspose.Slides, bạn có thể lấy chiều cao phông chữ effective. Đoạn code sau đây minh họa cách chiều cao phông chữ effective của một phần thay đổi sau khi các giá trị chiều cao phông chữ local được đặt ở các mức cấu trúc bài thuyết trình khác nhau.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 75, false);
autoShape.AddTextFrame("");

var paragraph = autoShape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var firstPortion = new Portion("Sample text with first portion");
var secondPortion = new Portion(" and second portion.");

paragraph.Portions.Add(firstPortion);
paragraph.Portions.Add(secondPortion);

var firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
var secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height just after creation:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

presentation.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight = 24;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting the presentation default font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 40;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting paragraph default font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

firstPortion.PortionFormat.FontHeight = 55;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting portion #0 font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

secondPortion.PortionFormat.FontHeight = 18;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting portion #1 font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

presentation.Save("SetLocalFontHeightValues.pptx", SaveFormat.Pptx);
```

## **Lấy Định Dạng Fill Effective cho Bảng**

Sử dụng Aspose.Slides, bạn có thể lấy định dạng fill effective cho các phần khác nhau của bảng. Giao diện [IFillFormatEffectiveData](https://reference.aspose.com/slides/vi/net/aspose.slides/ifillformateffectivedata/) chứa các thuộc tính định dạng fill effective. Định dạng ô có độ ưu tiên cao hơn định dạng hàng, định dạng hàng có độ ưu tiên cao hơn định dạng cột, và định dạng cột có độ ưu tiên cao hơn định dạng toàn bảng.

Kết quả là, các thuộc tính [ICellFormatEffectiveData](https://reference.aspose.com/slides/vi/net/aspose.slides/icellformateffectivedata/) được sử dụng để vẽ ô bảng. Mẫu code sau đây cho thấy cách lấy định dạng fill effective cho các phần khác nhau của bảng. Giả sử hình dạng đầu tiên trên slide đầu tiên là một [ITable](https://reference.aspose.com/slides/vi/net/aspose.slides/itable/).

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var table = (ITable)presentation.Slides[0].Shapes[0];

var tableFormatEffective = table.TableFormat.GetEffective();
var rowFormatEffective = table.Rows[0].RowFormat.GetEffective();
var columnFormatEffective = table.Columns[0].ColumnFormat.GetEffective();
var cellFormatEffective = table[0, 0].CellFormat.GetEffective();

var tableFillFormatEffective = tableFormatEffective.FillFormat;
var rowFillFormatEffective = rowFormatEffective.FillFormat;
var columnFillFormatEffective = columnFormatEffective.FillFormat;
var cellFillFormatEffective = cellFormatEffective.FillFormat;
```

## **Câu hỏi thường gặp**

### `GetEffective` có trả về một bản sao không?

Không phải lúc nào cũng vậy. Dữ liệu effective đại diện cho định dạng đã được tính toán sau khi áp dụng kế thừa, nhưng một số đối tượng dữ liệu effective có thể được lưu trong bộ nhớ cache nội bộ. Lần gọi `GetEffective` sau đó có thể tính lại định dạng và làm mới dữ liệu đã cache, vì vậy một đối tượng đã lấy trước không nên được coi là một bản sao bền vững.

### Khi nào tôi nên đọc lại các thuộc tính effective?

Gọi lại `GetEffective` sau khi thay đổi định dạng local, kiểu cha, định dạng bố cục, định dạng master hoặc các mặc định ở cấp trình chiếu. Lần gọi tiếp theo sẽ đánh giá lại cây định dạng và trả về kết quả effective hiện tại.

### Việc thay đổi hoặc xóa một slide bố cục/master có ảnh hưởng đến các thuộc tính effective đã được lấy không?

Đúng, nhưng sự thay đổi sẽ được phản ánh ở lần gọi `GetEffective` tiếp theo. Nếu nguồn định dạng cha bị thay đổi hoặc xóa, dữ liệu effective đã lấy trước có thể đã lỗi thời. Khi `GetEffective` được gọi lại, Aspose.Slides sẽ đánh giá lại cây định dạng và các phông chữ, màu sắc, kích thước hoặc các giá trị khác có thể thay đổi.

### Tôi có thể sửa đổi giá trị qua các đối tượng dữ liệu effective không?

Không. Các đối tượng dữ liệu effective chỉ cung cấp các giá trị đã tính toán. Thực hiện thay đổi trong các đối tượng định dạng local, sau đó lại lấy các giá trị effective.

### Điều gì xảy ra nếu một thuộc tính không được đặt ở mức shape, bố cục/master hoặc cài đặt toàn cục?

Giá trị effective sẽ được xác định bằng cơ chế mặc định, bao gồm các mặc định của PowerPoint và Aspose.Slides. Giá trị đã giải quyết đó sẽ trở thành một phần của dữ liệu effective hiện tại.

### Từ một giá trị phông chữ effective, tôi có thể biết cấp độ nào đã cung cấp kích thước hoặc kiểu phông không?

Không trực tiếp. Dữ liệu effective chỉ trả về giá trị cuối cùng. Để tìm nguồn, kiểm tra các giá trị local ở phần, đoạn văn, khung văn bản và các kiểu văn bản ở mức bố cục, master và trình chiếu để xem nơi định nghĩa rõ ràng đầu tiên xuất hiện.

### Tại sao các giá trị effective đôi khi trông giống hệt với các giá trị local?

Vì giá trị local đã trở thành giá trị cuối cùng (không cần kế thừa ở mức cao hơn). Trong trường hợp đó, giá trị effective trùng với giá trị local.

### Khi nào tôi nên sử dụng các thuộc tính effective, và khi nào chỉ làm việc với các thuộc tính local?

Sử dụng dữ liệu effective khi bạn cần kết quả "as rendered" sau khi áp dụng tất cả kế thừa, chẳng hạn để đồng bộ màu sắc, thụt lề hoặc kích thước. Nếu bạn cần bảo lưu các giá trị này bất chấp các thay đổi định dạng sau này, sao chép các thuộc tính cần thiết vào đối tượng của riêng bạn. Nếu bạn muốn thay đổi định dạng ở một mức cụ thể, hãy sửa đổi các thuộc tính local và sau đó, nếu cần, đọc lại dữ liệu effective để xác nhận kết quả.