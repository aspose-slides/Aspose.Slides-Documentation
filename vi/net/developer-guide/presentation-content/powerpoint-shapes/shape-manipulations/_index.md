---
title: Quản lý các hình dạng trong bản trình chiếu bằng .NET
linktitle: Thao tác Hình dạng
type: docs
weight: 40
url: /vi/net/shape-manipulations/
keywords:
- Hình PowerPoint
- Hình trong bản trình chiếu
- Hình trên slide
- Tìm hình
- Sao chép hình
- Xóa hình
- Ẩn hình
- Thay đổi thứ tự hình
- Lấy ID hình dạng interop
- Văn bản thay thế cho hình
- Điểm điều chỉnh hình dạng
- Điều chỉnh hình dạng preset
- Hình học hình dạng
- Định dạng bố cục hình dạng
- Hình dạng dưới dạng SVG
- Chuyển hình dạng sang SVG
- Căn chỉnh hình
- Lật hình
- PowerPoint
- Bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu cách xác định, điều chỉnh, sao chép, xóa, ẩn, sắp lại thứ tự, xuất, căn chỉnh và lật các hình dạng trong bản trình chiếu bằng Aspose.Slides cho .NET."
---
## **Tổng quan**

Aspose.Slides for .NET đại diện cho các hình dạng trên một slide dưới dạng một [IShapeCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/ishapecollection/) có thứ tự. Bộ sưu tập vừa là nơi bạn tìm và sửa đổi các hình dạng, vừa là nguồn của thứ tự xếp chồng: chỉ mục `0` là hình dạng ở phía sau nhất, trong khi chỉ mục cuối cùng là hình dạng ở phía trước nhất.

Bài viết này tuân theo mô hình đó. Đầu tiên nó giải thích cách xác định một hình dạng một cách đáng tin cậy và sửa đổi các điểm điều chỉnh hình dạng được đặt trước, sau đó cho biết cách sao chép, xóa, ẩn và sắp lại thứ tự các hình dạng. Các phần cuối cùng đề cập đến định dạng ở cấp độ bố cục, xuất SVG, căn chỉnh và thiết lập lật. Mỗi ví dụ là độc lập, vì vậy bạn có thể chỉ dùng những thao tác cần thiết cho quy trình của mình.

## **Xác định và Tìm kiếm Các Hình dạng**

Các chỉ mục trong bộ sưu tập tiện lợi khi xử lý một tệp đã biết, nhưng chúng không phải là định danh ổn định. Thêm, xóa hoặc sắp lại thứ tự một hình dạng có thể thay đổi chỉ mục của nó. Hãy chọn một định danh dựa trên cách bản trình chiếu được tạo và duy trì:

- [Name](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/name/) hữu ích cho các mẫu được kiểm soát bởi nhà phát triển và dễ kiểm tra trong Bảng chọn của PowerPoint. Tên có thể được chỉnh sửa và không được đảm bảo là duy nhất, vì vậy hãy thiết lập quy ước đặt tên nếu mã phụ thuộc vào chúng.
- [AlternativeText](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/alternativetext/) hữu ích khi mô tả khả năng tiếp cận hoặc một thẻ do tác giả cung cấp đã xác định hình dạng. Nó hiển thị cho người dùng, có thể được bản địa hoá hoặc viết lại cho khả năng tiếp cận, và không được đảm bảo là duy nhất. Đừng lạm dụng nội dung mô tả khả năng tiếp cận có ý nghĩa làm khóa cơ sở dữ liệu.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/officeinteropshapeid/) là một định danh chỉ đọc, duy nhất trong một slide và tương ứng với ID hình dạng được PowerPoint interop sử dụng. Sử dụng nó khi tích hợp với PowerPoint hoặc khi bạn cần một tham chiếu rõ ràng trong suốt vòng đời của một hình dạng. Một hình dạng sao chép hoặc tạo lại là một hình dạng khác và nhận ID riêng của nó.

Thuộc tính [UniqueId](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/uniqueid/) có phạm vi toàn bộ bản trình chiếu, nhưng nó được thiết kế cho các add‑in và có thể được gán lại. Nó không nên được coi là khóa ngoại bộ vĩnh viễn. Nếu danh tính dài hạn là quan trọng, hãy giữ ánh xạ trong dữ liệu ứng dụng và xác thực rằng hình dạng mong đợi vẫn còn tồn tại.

Để xem ví dụ thực tế về việc đọc và cập nhật cả tiêu đề và mô tả văn bản thay thế, xem [Manage Alternative Text Titles and Descriptions](/slides/vi/net/presentation-accessibility/). Sử dụng văn bản thay thế để giải thích ý nghĩa hình ảnh cho người đọc, và giữ nó riêng biệt với tên hình dạng mà mã sử dụng để tìm hình dạng.

Ví dụ dưới đây tìm kiếm bằng `Name` với so sánh thứ tự và báo cáo ID interop có phạm vi slide. Khi mẫu không chứa hình dạng mong đợi, mã sẽ báo kết quả đó thay vì tiếp tục với đối tượng sai.

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

Khi một thao tác cụ thể cho một loại hình dạng, hãy kiểm tra giao diện trước khi sử dụng các thành viên đặc thù cho loại. Ví dụ này cập nhật văn bản và văn bản thay thế chỉ khi đối tượng được đặt tên là một [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/).

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

## **Xác định và Sửa đổi Các Điều chỉnh Hình dạng Đặt trước**

Các hình dạng hình học được đặt trước có thể mở ra các điểm điều chỉnh kiểm soát các tính năng như kích thước góc, tỷ lệ mũi tên hoặc góc cung. Truy cập chúng thông qua bộ sưu tập chỉ đọc [IGeometryShape.Adjustments](https://reference.aspose.com/slides/vi/net/aspose.slides/igeometryshape/adjustments/). Bộ sưu tập này được cung cấp bởi hình dạng, nhưng mỗi [IAdjustValue](https://reference.aspose.com/slides/vi/net/aspose.slides/iadjustvalue/) chứa một giá trị có thể thay đổi.

Đừng chỉ dựa vào một chỉ mục bộ sưu tập cố định. Duyệt qua các điều chỉnh và kiểm tra thuộc tính chỉ đọc [Type](https://reference.aspose.com/slides/vi/net/aspose.slides/adjustvalue/type/), giá trị [ShapeAdjustmentType](https://reference.aspose.com/slides/vi/net/aspose.slides/shapeadjustmenttype/) của nó mô tả điều chỉnh kiểm soát gì. Thuộc tính chỉ đọc [Name](https://reference.aspose.com/slides/vi/net/aspose.slides/adjustvalue/name/) cung cấp thêm thông tin nhận dạng và đặc biệt hữu ích khi một preset chứa nhiều hơn một điều chỉnh có cùng kiểu ngữ nghĩa.

Sử dụng thuộc tính giá trị phù hợp với ý nghĩa của điều chỉnh:

| Loại điều chỉnh | Mục đích | Giá trị cần thay đổi |
|---|---|---|
| `CornerSize` | Kích thước các góc bo tròn | [RawValue](https://reference.aspose.com/slides/vi/net/aspose.slides/adjustvalue/rawvalue/) |
| `ArrowTailThickness` | Độ dày đuôi mũi tên | `RawValue` |
| `ArrowheadLength` | Độ dài đầu mũi tên | `RawValue` |
| `ArrowheadWidth` | Độ rộng đầu mũi tên | `RawValue` |
| `StartAngle` | Góc bắt đầu của phần bánh hoặc cung | [AngleValue](https://reference.aspose.com/slides/vi/net/aspose.slides/adjustvalue/anglevalue/) |
| `EndAngle` | Góc kết thúc của phần bánh hoặc cung | `AngleValue` |

`Type` và `Name` không thể gán. `RawValue` là một số nguyên đọc/ghi trong đơn vị hình học gốc của preset, trong khi `AngleValue` là góc đọc/ghi tính bằng độ. Số lượng, thứ tự, ý nghĩa và phạm vi hợp lệ của các điều chỉnh phụ thuộc vào preset [ShapeType](https://reference.aspose.com/slides/vi/net/aspose.slides/igeometryshape/shapetype/). Một giá trị hợp lệ cho một preset có thể không hợp lệ hoặc có hiệu ứng khác cho preset khác.

Khi `Type` là `ShapeAdjustmentType.Custom`, API không nhận ra ý nghĩa ngữ nghĩa chuẩn. Kiểm tra `Name`, loại preset và giá trị hiện có, và giữ nguyên điều chỉnh trừ khi biết ý nghĩa và phạm vi mong muốn. Ngay cả với các kiểu đã được nhận diện, cũng hãy kiểm tra xem cùng một kiểu có xuất hiện hơn một lần không trước khi chọn giá trị. Bài viết [Connector](/slides/vi/net/connector/) cho thấy tình huống này với các điều chỉnh gập của connector.

Ví dụ hoàn chỉnh dưới đây tạo các phiên bản mặc định và đã sửa đổi của ba hình dạng preset. Nó duyệt qua mọi điều chỉnh, báo cáo `Name` và `Type`, thay đổi các giá trị liên quan đến kích thước thông qua `RawValue`, thay đổi góc thông qua `AngleValue`, và lưu kết quả. Cột bên trái giữ hình học mặc định; cột bên phải hiển thị hình chữ nhật bo tròn, mũi tên bốn hướng và phần bánh đã được điều chỉnh.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

// Thêm tiêu đề cho các cột hình dạng mặc định và hình dạng đã điều chỉnh.
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

Kiểm tra kiểu ngữ nghĩa trước khi thay đổi giá trị làm cho mã rõ ràng về mục đích và tránh giả định rằng một chỉ mục bộ sưu tập cụ thể có cùng ý nghĩa trên các preset khác nhau.

## **Sửa đổi Bộ sưu tập Hình dạng**

Các phương thức thêm, sao chép, xóa và sắp lại thứ tự hoạt động trên bộ sưu tập ngay lập tức. Nếu một thao tác thay đổi số lượng hoặc thứ tự các hình dạng, đừng tiếp tục dựa vào các chỉ mục được lấy trước khi thực hiện thao tác đó.

### **Sao chép một Hình dạng**

[AddClone](https://reference.aspose.com/slides/vi/net/aspose.slides/ishapecollection/addclone/) tạo một bản sao độc lập và thêm nó vào cuối bộ sưu tập đích. [InsertClone](https://reference.aspose.com/slides/vi/net/aspose.slides/ishapecollection/insertclone/) cũng tạo một bản sao nhưng đặt nó ở chỉ mục z‑order được chỉ định. Các overload nhận tọa độ di chuyển bản sao mà không thay đổi kích thước; các overload có chiều rộng và chiều cao cũng có thể thay đổi kích thước.

Ví dụ tạo một slide đích, sao chép một hình chữ nhật có nhãn lên phía trước, và chèn bản sao thứ hai ở phía sau. Thay đổi bất kỳ bản sao nào cũng không làm ảnh hưởng đến hình dạng nguồn.

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

Sao chép sao chép nội dung và định dạng của hình dạng, bao gồm tên và văn bản thay thế. Gán các định danh logic mới cho bản sao khi các giá trị đó phải là duy nhất. Các tài nguyên được hình dạng phức tạp sử dụng được xử lý bởi bản trình chiếu, nhưng một bản sao vẫn là một mục mới trong bộ sưu tập với danh tính hình dạng mới.

### **Xóa Các Hình dạng**

[Remove](https://reference.aspose.com/slides/vi/net/aspose.slides/ishapecollection/remove/) xóa một đối tượng hình dạng cụ thể khỏi bộ sưu tập của nó. Khi xóa nhiều kết quả trong quá trình lặp có chỉ mục, duyệt từ cuối danh sách để mỗi chỉ mục còn lại vẫn hợp lệ.

Ví dụ này xóa mọi hình dạng có tên được chỉ định. Nó đọc `slide.Shapes[i]`, không phải một mục cố định trong bộ sưu tập, và không ép kiểu hình dạng không cần thiết.

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

Sau khi xóa, số lượng hình dạng và chỉ mục của các hình dạng phía sau thay đổi. Các tham chiếu tới các hình dạng không bị ảnh hưởng vẫn đáng tin cậy hơn so với các chỉ mục đã lưu. Cũng hãy cân nhắc các connector, hoạt ảnh và các tính năng khác của bản trình chiếu có thể tham chiếu tới đối tượng đã xóa; việc xóa một hình dạng hiển thị có thể làm thay đổi hơn cả diện mạo của slide.

### **Ẩn một Hình dạng**

Đặt [Hidden](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/hidden/) thành `true` giữ hình dạng trong bộ sưu tập nhưng ngăn nó xuất hiện trong bản chiếu thông thường. Chỉ mục, định dạng và nội dung của nó vẫn khả dụng cho mã, vì vậy việc ẩn phù hợp cho các yếu tố tùy chọn có thể được khôi phục sau này.

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

Ẩn không phải là xóa hay bảo mật. Đối tượng vẫn có thể được người dùng hoặc mã phát hiện và hủy ẩn, và nó vẫn là một phần của tệp bản trình chiếu.

### **Thay đổi Z‑Order**

Các hình dạng chồng lên nhau được vẽ theo thứ tự bộ sưu tập. [Reorder](https://reference.aspose.com/slides/vi/net/aspose.slides/ishapecollection/reorder/) di chuyển một hình dạng hiện có tới một chỉ mục đích mà không sao chép nó. Chỉ mục `0` là phía sau; `Count - 1` là phía trước.

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

Hình chữ nhật được tạo trước và ban đầu nằm sau hình ellipse. Di chuyển nó tới chỉ mục cuối cùng sẽ đặt nó ở phía trước. Hoàn thiện z‑order sau khi đã thêm hoặc sao chép tất cả các hình dạng liên quan, vì những thao tác đó thêm hoặc chèn mục mới vào bộ sưu tập và có thể làm thay đổi ngăn xếp dự định.

## **Kiểm tra Các Hình dạng trên Slide Bố cục**

Slide bình thường, slide bố cục và slide mẫu có các bộ sưu tập hình dạng riêng biệt. Một hình dạng trong bộ sưu tập bố cục không phải là cùng một đối tượng với một hình dạng nằm ở vị trí tương tự trên slide bình thường. Kiểm tra các hình dạng bố cục khi bạn cần hiểu hoặc thay đổi định dạng do bố cục cung cấp.

Ví dụ sau đọc [FillFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/fillformat/) và [LineFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/lineformat/) của mỗi hình dạng bố cục mà không giả định rằng mọi hình dạng đều là `AutoShape`.

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

Chỉnh sửa một bố cục có thể ảnh hưởng tới nhiều slide sử dụng nó. Trước khi thay đổi một hình dạng bố cục, hãy xác định xem một slide bình thường có kế thừa đối tượng đó hay chứa một ghi đè cục bộ, và thử nghiệm trên mọi slide sử dụng bố cục đó.

## **Xuất Hình dạng sang SVG**

[WriteAsSvg](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/writeassvg/) ghi nội dung đã render của một hình dạng vào một stream. Kết quả chỉ chứa hình dạng, không phải nền toàn slide hay các hình dạng lân cận.

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

Giữ bản trình chiếu mở trong khi render. Đầu ra phụ thuộc vào định dạng của hình dạng và các tài nguyên như phông chữ và hình ảnh. Nếu bạn cần toàn bộ bố cục, hãy xuất slide thay vì từng hình dạng riêng lẻ. Người gọi sở hữu stream và phải giải phóng nó.

## **Căn chỉnh Các Hình dạng**

Các overload của [SlideUtil.AlignShapes](https://reference.aspose.com/slides/vi/net/aspose.slides.util/slideutil/alignshapes/) căn chỉnh toàn bộ các hình dạng hoặc các chỉ mục bộ sưu tập đã chọn. [ShapesAlignmentType](https://reference.aspose.com/slides/vi/net/aspose.slides/shapesalignmenttype/) chỉ định cạnh, đường trung tâm, hoặc chế độ phân phối. Đặt `alignToSlide` thành `true` để sử dụng các cạnh slide; đặt thành `false` để căn chỉnh các hình dạng đã chọn tương quan với nhau.

Ví dụ này căn chỉnh ba hình dạng tới cạnh trên của slide. Các tham chiếu hình dạng trả về được chuyển thành chỉ mục hiện tại ngay trước khi căn chỉnh.

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

Căn chỉnh thay đổi vị trí, không phải z‑order. Căn chỉnh tương đối thường cần ít nhất hai hình dạng, trong khi phân phối ngang hoặc dọc cần đủ hình dạng để xác định khoảng cách. Tính lại chỉ mục nếu bạn sửa đổi bộ sưu tập trước khi gọi phương thức.

## **Lật Một Hình dạng**

Lớp [ShapeFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/shapeframe/) lưu trữ vị trí, kích thước, thiết lập lật ngang và dọc, và góc quay. Các giá trị `FlipH` và `FlipV` sử dụng [NullableBool](https://reference.aspose.com/slides/vi/net/aspose.slides/nullablebool/): `True` bật lật, `False` tắt, và `NotDefined` giữ nguyên trạng thái chưa xác định/mặc định.

Bản trình chiếu đầu vào dưới đây chứa một hình dạng chưa được lật.

![The shape before flipping](shape_to_be_flipped.png)

Ví dụ này giữ nguyên mọi giá trị khung khác và chỉ thay thế hai thiết lập lật. Điều này quan trọng vì gán một [Frame](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/frame/) mới sẽ thay thế toàn bộ khung.

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

**Tôi có nên dùng chỉ mục bộ sưu tập làm định danh cho một hình dạng không?**

Chỉ nên khi xử lý ngắn hạn và bộ sưu tập sẽ không thay đổi trước khi sử dụng chỉ mục. Nên ưu tiên một quy ước `Name` hoặc `AlternativeText` đã được kiểm chứng cho các mẫu được tạo, hoặc `OfficeInteropShapeId` cho công việc interop theo slide.

**Việc ẩn một hình dạng có loại bỏ nó khỏi z‑order không?**

Không. Một hình dạng ẩn vẫn còn trong bộ sưu tập ở cùng chỉ mục. Nó có thể được tìm, sắp lại, chỉnh sửa hoặc hiển thị lại.

**Tại sao một hình dạng sao chép lại xuất hiện ở phía trước một hình dạng khác?**

`AddClone` thêm bản sao vào cuối bộ sưu tập, tức là phía trước của z‑order. Sử dụng `InsertClone` để chọn chỉ mục ban đầu hoặc `Reorder` sau khi đã thêm tất cả các hình dạng.

**Tôi có thể dùng một chỉ mục cố định để xác định một điều chỉnh hình dạng preset không?**

Chỉ được sau khi đã xác thực preset và bố cục bộ sưu tập chính xác. Nên duyệt qua `IGeometryShape.Adjustments` và kiểm tra `IAdjustValue.Type`; sử dụng `IAdjustValue.Name` như thông tin bổ sung khi cùng một kiểu ngữ nghĩa xuất hiện nhiều lần.