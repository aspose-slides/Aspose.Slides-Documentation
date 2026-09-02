---
title: Quản lý các hình dạng trong bản thuyết trình bằng .NET
linktitle: Thao tác Hình dạng
type: docs
weight: 40
url: /vi/net/shape-manipulations/
keywords:
- hình PowerPoint
- hình dạng trong bản thuyết trình
- hình trên slide
- tìm hình
- sao chép hình
- xóa hình
- ẩn hình
- thay đổi thứ tự hình
- lấy ID hình dạng interop
- văn bản thay thế của hình
- điểm điều chỉnh hình dạng
- điều chỉnh hình dạng đặt trước
- hình học hình dạng
- định dạng layout hình dạng
- hình dạng dưới dạng SVG
- chuyển hình dạng sang SVG
- căn chỉnh hình
- lật hình
- PowerPoint
- bản thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu cách xác định, điều chỉnh, sao chép, xóa, ẩn, sắp lại, xuất, căn chỉnh và lật các hình dạng trong bản thuyết trình bằng Aspose.Slides cho .NET."
---
## **Tổng quan**

Aspose.Slides for .NET đại diện cho các hình dạng trên một slide dưới dạng một [IShapeCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/ishapecollection/) có thứ tự. Bộ sưu tập vừa là nơi bạn tìm và chỉnh sửa các hình dạng, vừa là nguồn của thứ tự xếp chồng: chỉ mục `0` là hình dạng ở phía sau nhất, trong khi chỉ mục cuối cùng là hình dạng ở phía trước nhất.

Bài viết này tuân theo mô hình đó. Đầu tiên nó giải thích cách xác định một hình dạng một cách đáng tin cậy và chỉnh sửa các điểm điều chỉnh đã xác định trước, sau đó cho thấy cách sao chép, xóa, ẩn và sắp lại thứ tự các hình dạng. Các phần cuối cùng đề cập tới định dạng ở mức layout, xuất SVG, căn chỉnh và cài đặt lật. Mỗi ví dụ đều độc lập, vì vậy bạn có thể chỉ sử dụng các thao tác cần thiết cho quy trình của mình.

## **Xác định và Tìm kiếm Hình dạng**

Chỉ mục trong bộ sưu tập tiện lợi khi xử lý một tệp đã biết, nhưng chúng không phải là định danh ổn định. Thêm, xóa hoặc sắp lại một hình dạng có thể làm thay đổi chỉ mục của nó. Hãy chọn định danh phù hợp dựa trên cách bản thuyết trình được tạo và duy trì:

- [Name](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/name/) hữu ích cho các mẫu do nhà phát triển kiểm soát và dễ kiểm tra trong Bảng chọn của PowerPoint. Tên có thể được chỉnh sửa và không được đảm bảo là duy nhất, vì vậy hãy thiết lập quy ước đặt tên nếu mã phụ thuộc vào chúng.
- [AlternativeText](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/alternativetext/) hữu ích khi mô tả khả năng truy cập hoặc thẻ do tác giả cung cấp đã xác định hình dạng. Nó hiển thị cho người dùng, có thể được bản địa hoá hoặc viết lại cho khả năng truy cập, và cũng không được đảm bảo là duy nhất. Đừng lạm dụng nội dung khả năng truy cập có ý nghĩa làm khóa cơ sở dữ liệu.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/officeinteropshapeid/) là một định danh chỉ đọc, duy nhất trong một slide và tương ứng với ID hình dạng được PowerPoint interop sử dụng. Dùng nó khi tích hợp với PowerPoint hoặc khi bạn cần một tham chiếu không mơ hồ trong suốt vòng đời của một hình dạng. Một hình dạng được sao chép hoặc tái tạo sẽ có ID khác.

Thuộc tính [UniqueId](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/uniqueid/) liên quan có phạm vi toàn bộ bản thuyết trình, nhưng nó được thiết kế cho các add‑in và có thể được gán lại. Không nên coi nó là khóa ngoài cố định. Nếu nhận dạng lâu dài là quan trọng, hãy giữ ánh xạ trong dữ liệu ứng dụng và xác nhận rằng hình dạng dự kiến vẫn còn tồn tại.

Ví dụ sau tìm kiếm bằng `Name` với so sánh thứ tự và báo cáo ID interop có phạm vi slide. Khi mẫu không chứa hình dạng mong đợi, mã sẽ báo kết quả này thay vì tiếp tục với đối tượng sai.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

IShape? targetShape = null;
foreach (var shape in slide.Shapes)
{
    if (string.Equals(shape.Name, "RevenueChart", StringComparison.Ordinal))
    {
        targetShape = shape;
        break;
    }
}

if (targetShape is null)
{
    Console.WriteLine("The shape 'RevenueChart' was not found on slide 1.");
}
else
{
    Console.WriteLine($"Found {targetShape.Name}; interop ID: {targetShape.OfficeInteropShapeId}");
}
```

Khi một thao tác cụ thể đối với một loại hình dạng, hãy kiểm tra giao diện trước khi sử dụng các thành viên đặc thù loại. Ví dụ này cập nhật văn bản và văn bản thay thế chỉ nếu đối tượng đã đặt tên là một [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/).

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

IShape? candidate = null;
foreach (var shape in slide.Shapes)
{
    if (string.Equals(shape.Name, "StatusLabel", StringComparison.Ordinal))
    {
        candidate = shape;
        break;
    }
}

if (candidate is IAutoShape autoShape)
{
    autoShape.TextFrame.Text = "Approved";
    autoShape.AlternativeText = "Approval status: approved";
    presentation.Save("identified-shape.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("'StatusLabel' is missing or is not an AutoShape.");
}
```

## **Xác định và Chỉnh sửa Các Điều chỉnh Hình dạng Đặt trước**

Các hình dạng hình học đặt trước có thể hiển thị các điểm điều chỉnh để kiểm soát các tính năng như kích thước góc, tỷ lệ mũi tên hoặc góc cung. Truy cập chúng qua bộ sưu tập chỉ đọc [IGeometryShape.Adjustments](https://reference.aspose.com/slides/vi/net/aspose.slides/igeometryshape/adjustments/). Bộ sưu tập này được cung cấp bởi hình dạng, nhưng mỗi [IAdjustValue](https://reference.aspose.com/slides/vi/net/aspose.slides/iadjustvalue/) chứa một giá trị có thể thay đổi.

Đừng chỉ dựa vào một chỉ mục cố định. Lặp lại qua các điều chỉnh và kiểm tra thuộc tính chỉ đọc [Type](https://reference.aspose.com/slides/vi/net/aspose.slides/adjustvalue/type/), trong đó giá trị [ShapeAdjustmentType](https://reference.aspose.com/slides/vi/net/aspose.slides/shapeadjustmenttype/) mô tả điều chỉnh điều khiển gì. Thuộc tính chỉ đọc [Name](https://reference.aspose.com/slides/vi/net/aspose.slides/adjustvalue/name/) cung cấp thông tin nhận dạng bổ sung và đặc biệt hữu ích khi một preset chứa hơn một điều chỉnh có cùng loại ngữ nghĩa.

Sử dụng thuộc tính giá trị phù hợp với ý nghĩa của điều chỉnh:

| Loại điều chỉnh | Mục đích | Giá trị cần thay đổi |
|---|---|---|
| `CornerSize` | Kích thước các góc bo tròn | [RawValue](https://reference.aspose.com/slides/vi/net/aspose.slides/adjustvalue/rawvalue/) |
| `ArrowTailThickness` | Độ dày đuôi mũi tên | `RawValue` |
| `ArrowheadLength` | Độ dài đầu mũi tên | `RawValue` |
| `ArrowheadWidth` | Độ rộng đầu mũi tên | `RawValue` |
| `StartAngle` | Góc bắt đầu của hình bánh hoặc cung | [AngleValue](https://reference.aspose.com/slides/vi/net/aspose.slides/adjustvalue/anglevalue/) |
| `EndAngle` | Góc kết thúc của hình bánh hoặc cung | `AngleValue` |

`Type` và `Name` không thể gán. `RawValue` là một số nguyên đọc/ghi theo đơn vị hình học gốc của preset, trong khi `AngleValue` là một góc đọc/ghi tính bằng độ. Số lượng, thứ tự, ý nghĩa và phạm vi hợp lệ của các điều chỉnh phụ thuộc vào preset [ShapeType](https://reference.aspose.com/slides/vi/net/aspose.slides/igeometryshape/shapetype/). Một giá trị hợp lệ cho một preset có thể không hợp lệ hoặc có hiệu ứng khác cho một preset khác.

Khi `Type` là `ShapeAdjustmentType.Custom`, API không nhận ra ý nghĩa ngữ nghĩa chuẩn. Kiểm tra `Name`, loại preset và giá trị hiện tại, và giữ nguyên điều chỉnh trừ khi bạn biết chắc ý nghĩa và phạm vi mong muốn. Ngay cả với các loại đã được công nhận, cũng hãy kiểm tra xem cùng một loại có xuất hiện nhiều hơn một lần không trước khi chọn giá trị. Bài viết [Connector](/slides/vi/net/connector/) minh họa tình huống này với các điều chỉnh độ cong của connector.

Ví dụ hoàn chỉnh sau tạo các phiên bản mặc định và đã chỉnh sửa của ba hình dạng preset. Nó lặp qua mọi điều chỉnh, báo cáo `Name` và `Type`, thay đổi các giá trị liên quan đến kích thước qua `RawValue`, thay đổi các góc qua `AngleValue`, và lưu kết quả. Cột bên trái giữ hình học mặc định; cột bên phải hiển thị hình chữ nhật bo tròn đã chỉnh, mũi tên bốn chiều và hình bánh.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

// Thêm tiêu đề cho các cột hình dạng mặc định và đã điều chỉnh.
var defaultColumnLabel = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 20, 250, 30);
defaultColumnLabel.TextFrame.Text = "Default preset geometry";
var adjustedColumnLabel = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 390, 20, 250, 30);
adjustedColumnLabel.TextFrame.Text = "Modified adjustment values";

slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 80, 70, 160, 70);
var modifiedRoundedRectangle = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 430, 70, 160, 70);
modifiedRoundedRectangle.Name = "ModifiedRoundedRectangle";

slide.Shapes.AddAutoShape(ShapeType.QuadArrow, 80, 180, 160, 110);
var modifiedArrow = slide.Shapes.AddAutoShape(ShapeType.QuadArrow, 430, 180, 160, 110);
modifiedArrow.Name = "ModifiedQuadArrow";

slide.Shapes.AddAutoShape(ShapeType.Pie, 95, 330, 130, 130);
var modifiedPie = slide.Shapes.AddAutoShape(ShapeType.Pie, 445, 330, 130, 130);
modifiedPie.Name = "ModifiedPie";

var shapesToAdjust = new IGeometryShape[]
{
    modifiedRoundedRectangle,
    modifiedArrow,
    modifiedPie
};

foreach (var shape in shapesToAdjust)
{
    for (var adjustmentIndex = 0; adjustmentIndex < shape.Adjustments.Count; adjustmentIndex++)
    {
        var adjustment = shape.Adjustments[adjustmentIndex];
        Console.WriteLine($"{shape.Name} / {adjustment.Name}: {adjustment.Type}");

        switch (adjustment.Type)
        {
            case ShapeAdjustmentType.CornerSize:
                adjustment.RawValue = 5000;
                break;
            case ShapeAdjustmentType.ArrowTailThickness:
                adjustment.RawValue = 25000;
                break;
            case ShapeAdjustmentType.ArrowheadLength:
                adjustment.RawValue = 30000;
                break;
            case ShapeAdjustmentType.ArrowheadWidth:
                adjustment.RawValue = 40000;
                break;
            case ShapeAdjustmentType.StartAngle:
                adjustment.AngleValue = 30;
                break;
            case ShapeAdjustmentType.EndAngle:
                adjustment.AngleValue = 300;
                break;
            case ShapeAdjustmentType.Custom:
                Console.WriteLine($"Custom adjustment '{adjustment.Name}' was not changed.");
                break;
        }
    }
}

presentation.Save("preset-shape-adjustments.pptx", SaveFormat.Pptx);
```

Kiểm tra loại ngữ nghĩa trước khi thay đổi giá trị giúp mã rõ ràng về mục đích và tránh giả định một chỉ mục bộ sưu tập có cùng ý nghĩa trên các hình dạng preset khác nhau.

## **Chỉnh sửa Bộ sưu tập Hình dạng**

Các phương thức thêm, sao chép, xóa và sắp lại hoạt động ngay trên bộ sưu tập. Nếu một thao tác thay đổi số lượng hoặc thứ tự các hình dạng, đừng tiếp tục dựa vào các chỉ mục đã lấy trước khi thực hiện thao tác đó.

### **Sao chép một Hình dạng**

[AddClone](https://reference.aspose.com/slides/vi/net/aspose.slides/ishapecollection/addclone/) tạo một bản sao độc lập và nối nó vào bộ sưu tập đích. [InsertClone](https://reference.aspose.com/slides/vi/net/aspose.slides/ishapecollection/insertclone/) cũng tạo một bản sao nhưng đặt nó ở một chỉ mục z‑order xác định. Các overload chấp nhận tọa độ di chuyển bản sao mà không đổi kích thước; overload có chiều rộng và chiều cao cũng có thể thay đổi kích thước.

Ví dụ tạo một slide đích, sao chép một hình chữ nhật có nhãn lên phía trước, và chèn bản sao thứ hai ở phía sau. Thay đổi bất kỳ bản sao nào cũng không ảnh hưởng đến hình dạng nguồn.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var sourceSlide = presentation.Slides[0];
var sourceShape = sourceSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 180, 60);
sourceShape.Name = "SourceLabel";
sourceShape.TextFrame.Text = "Source";

var blankLayout = presentation.Masters[0].LayoutSlides.GetByType(SlideLayoutType.Blank);
var destinationSlide = presentation.Slides.AddEmptySlide(blankLayout);

var frontCloneShape = destinationSlide.Shapes.AddClone(sourceShape, 80, 80);
frontCloneShape.Name = "FrontClone";
if (frontCloneShape is IAutoShape frontClone)
{
    frontClone.TextFrame.Text = "Front clone";
}
else
{
    Console.WriteLine("The front clone is not an AutoShape; its text was not changed.");
}

var backCloneShape = destinationSlide.Shapes.InsertClone(0, sourceShape, 80, 180);
backCloneShape.Name = "BackClone";
if (backCloneShape is IAutoShape backClone)
{
    backClone.TextFrame.Text = "Back clone";
}
else
{
    Console.WriteLine("The back clone is not an AutoShape; its text was not changed.");
}

presentation.Save("cloned-shapes.pptx", SaveFormat.Pptx);
```

Sao chép giữ lại nội dung và định dạng của hình dạng, bao gồm tên và văn bản thay thế. Gán các định danh logic mới cho bản sao khi các giá trị này phải là duy nhất. Các tài nguyên dùng cho các hình dạng phức tạp được trình chiếu quản lý, nhưng một bản sao vẫn là một mục mới trong bộ sưu tập với danh tính hình dạng mới.

### **Xóa Hình dạng**

[Remove](https://reference.aspose.com/slides/vi/net/aspose.slides/ishapecollection/remove/) xóa một đối tượng hình dạng cụ thể khỏi bộ sưu tập của nó. Khi xóa nhiều kết quả trong vòng lặp dựa trên chỉ mục, hãy duyệt từ cuối lên để mỗi chỉ mục còn lại vẫn hợp lệ.

Ví dụ này xóa mọi hình dạng có tên đã chỉ định. Nó đọc `slide.Shapes[i]`, không phải một mục cố định trong bộ sưu tập, và không ép kiểu hình dạng một cách không cần thiết.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var keepShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 140, 60);
keepShape.Name = "Keep";

var firstTemporaryShape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 220, 40, 80, 80);
firstTemporaryShape.Name = "Temporary";

var secondTemporaryShape = slide.Shapes.AddAutoShape(ShapeType.Triangle, 340, 40, 100, 80);
secondTemporaryShape.Name = "Temporary";

for (var i = slide.Shapes.Count - 1; i >= 0; i--)
{
    var shape = slide.Shapes[i];
    if (string.Equals(shape.Name, "Temporary", StringComparison.Ordinal))
    {
        slide.Shapes.Remove(shape);
    }
}

presentation.Save("removed-shapes.pptx", SaveFormat.Pptx);
```

Sau khi xóa, số lượng hình dạng và chỉ mục của các hình dạng sau sẽ thay đổi. Tham chiếu đến các hình dạng không bị ảnh hưởng vẫn đáng tin cậy hơn so với các chỉ mục đã lưu. Cũng cần cân nhắc các connector, hoạt ảnh và các tính năng khác của bản thuyết trình có thể tham chiếu tới đối tượng đã bị xóa; việc xóa một hình dạng hiển thị có thể thay đổi nhiều hơn chỉ giao diện slide.

### **Ẩn một Hình dạng**

Đặt [Hidden](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/hidden/) thành `true` giữ hình dạng trong bộ sưu tập nhưng ngăn nó xuất hiện trong buổi trình chiếu bình thường. Chỉ mục, định dạng và nội dung của nó vẫn có thể truy cập bằng mã, vì vậy việc ẩn thích hợp cho các yếu tố tùy chọn có thể được khôi phục sau này.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var visibleShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 160, 60);
visibleShape.Name = "VisibleLabel";

var optionalShape = slide.Shapes.AddAutoShape(ShapeType.Moon, 240, 40, 100, 100);
optionalShape.Name = "OptionalDecoration";

foreach (var shape in slide.Shapes)
{
    if (string.Equals(shape.Name, "OptionalDecoration", StringComparison.Ordinal))
    {
        shape.Hidden = true;
    }
}

presentation.Save("hidden-shape.pptx", SaveFormat.Pptx);
```

Ẩn không đồng nghĩa với xóa hay bảo mật. Đối tượng vẫn có thể được người dùng hoặc mã phát hiện và hiện ra lại, và nó vẫn là một phần của tệp bản thuyết trình.

### **Thay đổi Z‑Order**

Các hình dạng chồng lên nhau được vẽ theo thứ tự trong bộ sưu tập. [Reorder](https://reference.aspose.com/slides/vi/net/aspose.slides/ishapecollection/reorder/) di chuyển một hình dạng hiện có đến một chỉ mục đích mà không sao chép nó. Chỉ mục `0` là phía sau; `Count - 1` là phía trước.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var blueRectangle = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 220, 120);
blueRectangle.Name = "BlueRectangle";
blueRectangle.FillFormat.FillType = FillType.Solid;
blueRectangle.FillFormat.SolidFillColor.Color = Color.SteelBlue;

var orangeEllipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 180, 140, 220, 120);
orangeEllipse.Name = "OrangeEllipse";
orangeEllipse.FillFormat.FillType = FillType.Solid;
orangeEllipse.FillFormat.SolidFillColor.Color = Color.Orange;

slide.Shapes.Reorder(slide.Shapes.Count - 1, blueRectangle);
presentation.Save("reordered-shapes.pptx", SaveFormat.Pptx);
```

Hình chữ nhật được tạo đầu tiên và ban đầu nằm sau hình ellipse. Di chuyển nó tới chỉ mục cuối cùng sẽ đưa nó lên phía trước. Hoàn thiện z‑order sau khi thêm hoặc sao chép tất cả các hình dạng liên quan, vì các thao tác này sẽ chèn hoặc nối các mục mới vào bộ sưu tập và có thể thay đổi thứ tự dự định.

## **Kiểm tra Hình dạng trên Slide Layout**

Slide bình thường, slide layout và master slide có các bộ sưu tập hình dạng riêng. Một hình dạng trong bộ sưu tập layout không phải là cùng một đối tượng với một hình dạng có vị trí tương tự trên slide bình thường. Kiểm tra các hình dạng layout khi bạn cần hiểu hoặc thay đổi định dạng được cung cấp bởi layout.

Ví dụ sau đọc [FillFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/fillformat/) và [LineFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/lineformat/) của mỗi hình dạng layout mà không giả định mọi hình dạng đều là `AutoShape`.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");

foreach (var layoutSlide in presentation.LayoutSlides)
{
    foreach (var shape in layoutSlide.Shapes)
    {
        var fillType = shape.FillFormat.FillType;
        var lineWidth = shape.LineFormat.Width;
        Console.WriteLine($"{layoutSlide.Name} / {shape.Name}: fill={fillType}, line width={lineWidth}");
    }
}
```

Chỉnh sửa một layout có thể ảnh hưởng tới nhiều slide sử dụng nó. Trước khi thay đổi một hình dạng layout, hãy xác định xem một slide bình thường có kế thừa đối tượng này hay chứa một ghi đè cục bộ, và kiểm tra mọi slide dùng layout đó.

## **Xuất Hình dạng ra SVG**

[WriteAsSvg](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/writeassvg/) ghi nội dung đã render của một hình dạng vào một luồng. Kết quả chỉ chứa hình dạng, không phải nền toàn slide hay các hình dạng lân cận.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

if (slide.Shapes.Count == 0)
{
    Console.WriteLine("Slide 1 does not contain a shape to export.");
}
else
{
    var shape = slide.Shapes[0];
    using var svgStream = File.Create("shape.svg");
    shape.WriteAsSvg(svgStream);
}
```

Giữ bản thuyết trình mở trong khi render. Đầu ra phụ thuộc vào định dạng của hình dạng và các tài nguyên như phông chữ và hình ảnh. Nếu bạn cần toàn bộ thành phần, hãy xuất slide chứ không phải một hình dạng riêng lẻ. Người gọi sở hữu luồng và phải giải phóng nó.

## **Căn chỉnh Hình dạng**

Các overload của [SlideUtil.AlignShapes](https://reference.aspose.com/slides/vi/net/aspose.slides.util/slideutil/alignshapes/) căn chỉnh tất cả các hình dạng hoặc các chỉ mục bộ sưu tập đã chọn. [ShapesAlignmentType](https://reference.aspose.com/slides/vi/net/aspose.slides/shapesalignmenttype/) chỉ định cạnh, đường trung tâm hoặc chế độ phân bố. Đặt `alignToSlide` thành `true` để dùng các cạnh slide; đặt thành `false` để căn chỉnh các hình dạng đã chọn tương quan với nhau.

Ví dụ này căn chỉnh ba hình dạng vào cạnh trên của slide. Các tham chiếu hình dạng trả về được chuyển thành chỉ mục hiện tại ngay trước khi căn.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var firstShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 60, 80, 120, 50);
var secondShape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 240, 160, 120, 50);
var thirdShape = slide.Shapes.AddAutoShape(ShapeType.Triangle, 420, 240, 120, 50);
firstShape.Name = "FirstAlignedShape";
secondShape.Name = "SecondAlignedShape";
thirdShape.Name = "ThirdAlignedShape";

var shapeIndexes = new[]
{
    slide.Shapes.IndexOf(firstShape),
    slide.Shapes.IndexOf(secondShape),
    slide.Shapes.IndexOf(thirdShape)
};

SlideUtil.AlignShapes(ShapesAlignmentType.AlignTop, true, slide, shapeIndexes);
presentation.Save("aligned-shapes.pptx", SaveFormat.Pptx);
```

Căn chỉnh thay đổi vị trí, không phải z‑order. Căn chỉnh tương đối thường cần ít nhất hai hình dạng, trong khi phân bố ngang hoặc dọc cần đủ hình dạng để xác định khoảng cách. Tính lại chỉ mục nếu bạn thay đổi bộ sưu tập trước khi gọi phương thức.

## **Lật một Hình dạng**

Lớp [ShapeFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/shapeframe/) lưu trữ vị trí, kích thước, cài đặt lật ngang và dọc, và góc quay. Các giá trị `FlipH` và `FlipV` sử dụng [NullableBool](https://reference.aspose.com/slides/vi/net/aspose.slides/nullablebool/): `True` bật lật, `False` tắt, và `NotDefined` giữ trạng thái không xác định/mặc định.

Bản trình chiếu input dưới đây chứa một hình dạng chưa bị lật.

![The shape before flipping](shape_to_be_flipped.png)

Ví dụ này giữ nguyên mọi giá trị khung khác và chỉ thay thế hai cài đặt lật. Điều này quan trọng vì việc gán một [Frame](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/frame/) mới sẽ thay thế toàn bộ khung.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var shape = presentation.Slides[0].Shapes[0];
var frame = shape.Frame;

Console.WriteLine($"Horizontal flip before change: {frame.FlipH}");
Console.WriteLine($"Vertical flip before change: {frame.FlipV}");

shape.Frame = new ShapeFrame(
    frame.X, frame.Y, frame.Width, frame.Height,
    NullableBool.True, NullableBool.True, frame.Rotation);

presentation.Save("flipped-shape.pptx", SaveFormat.Pptx);
```

Hình dạng đã lưu được lật ngang và dọc trong khi giữ nguyên vị trí, kích thước và góc quay.

![The shape after flipping](flipped_shape.png)

## **Câu hỏi thường gặp**

**Tôi có nên dùng chỉ mục bộ sưu tập làm định danh cho hình dạng không?**

Chỉ nên dùng trong xử lý ngắn hạn khi bộ sưu tập không thay đổi trước khi chỉ mục được sử dụng. Ưu tiên sử dụng `Name` hoặc quy ước `AlternativeText` đã được xác thực cho các mẫu được tạo, hoặc `OfficeInteropShapeId` cho công việc interop có phạm vi slide.

**Ẩn một hình dạng có làm nó biến mất khỏi z‑order không?**

Không. Một hình dạng ẩn vẫn còn trong bộ sưu tập ở cùng chỉ mục. Nó vẫn có thể được tìm, sắp lại, chỉnh sửa hoặc hiển thị lại.

**Tại sao một hình dạng đã sao chép lại xuất hiện ở phía trước một hình dạng khác?**

`AddClone` nối bản sao vào cuối bộ sưu tập, tức là phía trước của z‑order. Dùng `InsertClone` để chọn chỉ mục ban đầu hoặc `Reorder` sau khi đã thêm tất cả các hình dạng.

**Tôi có thể dùng một chỉ mục cố định để xác định một điều chỉnh preset không?**

Chỉ được sau khi xác thực chính xác preset và bố cục bộ sưu tập. Ưu tiên lặp qua `IGeometryShape.Adjustments` và kiểm tra `IAdjustValue.Type`; dùng `IAdjustValue.Name` làm thông tin bổ sung khi cùng một loại ngữ nghĩa xuất hiện nhiều hơn một lần.