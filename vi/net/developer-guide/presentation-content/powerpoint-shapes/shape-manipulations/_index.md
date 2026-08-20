---
title: Quản lý các hình dạng trong bài thuyết trình bằng .NET
linktitle: Thao tác Hình dạng
type: docs
weight: 40
url: /vi/net/shape-manipulations/
keywords:
- hình PowerPoint
- hình dạng trong bài thuyết trình
- hình trên slide
- tìm hình dạng
- sao chép hình dạng
- xóa hình dạng
- ẩn hình dạng
- thay đổi thứ tự hình dạng
- lấy ID hình dạng interop
- văn bản thay thế của hình dạng
- định dạng bố cục hình dạng
- hình dạng dưới dạng SVG
- chuyển hình dạng sang SVG
- căn chỉnh hình dạng
- lật hình dạng
- PowerPoint
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu cách xác định, sao chép, xóa, ẩn, thay đổi thứ tự, xuất, căn chỉnh và lật các hình dạng trong bài thuyết trình với Aspose.Slides cho .NET."
---
## **Tổng quan**

Aspose.Slides for .NET đại diện cho các hình dạng trên một slide dưới dạng một [IShapeCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/ishapecollection/) được sắp xếp có thứ tự. Bộ sưu tập này vừa là nơi bạn tìm và sửa đổi các hình dạng vừa là nguồn của thứ tự xếp chồng của chúng: chỉ mục `0` là hình dạng ở phía sau nhất, trong khi chỉ mục cuối cùng là hình dạng ở phía trước nhất.

Bài viết này tuân theo mô hình đó. Đầu tiên nó giải thích cách xác định một hình dạng một cách đáng tin cậy, sau đó trình bày cách sao chép, xóa, ẩn và thay đổi thứ tự các hình dạng. Các phần cuối cùng bao phủ định dạng cấp bố cục, xuất SVG, căn chỉnh và cài đặt lật. Mỗi ví dụ là độc lập, vì vậy bạn chỉ cần sử dụng các thao tác mà quy trình của bạn yêu cầu.

## **Xác định và Tìm hình dạng**

Chỉ mục của bộ sưu tập tiện lợi khi xử lý một tệp đã biết, nhưng chúng không phải là định danh ổn định. Thêm, xóa hoặc thay đổi thứ tự một hình dạng có thể làm thay đổi chỉ mục của nó. Hãy chọn một định danh dựa trên cách bài thuyết trình được tạo và duy trì:

- [Name](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/name/) hữu ích cho các mẫu do nhà phát triển kiểm soát và dễ kiểm tra trong Bảng chọn của PowerPoint. Tên có thể được chỉnh sửa và không được đảm bảo là duy nhất, vì vậy hãy thiết lập quy ước đặt tên nếu mã phụ thuộc vào chúng.
- [AlternativeText](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/alternativetext/) hữu ích khi một mô tả khả năng truy cập hoặc thẻ do tác giả cung cấp đã xác định hình dạng. Nó hiển thị cho người dùng, có thể được bản địa hoá hoặc viết lại cho khả năng truy cập, và không được đảm bảo là duy nhất. Đừng lặng lẽ dùng lại văn bản khả năng truy cập có ý nghĩa như một khóa cơ sở dữ liệu.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/officeinteropshapeid/) là một định danh chỉ đọc, duy nhất trong một slide và tương ứng với ID hình dạng được PowerPoint interop sử dụng. Sử dụng nó khi tích hợp với PowerPoint hoặc khi bạn cần một tham chiếu không mơ hồ trong vòng đời của một hình dạng. Một hình dạng được sao chép hoặc tạo lại là một hình dạng khác và nhận ID riêng của nó.

Thuộc tính [UniqueId](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/uniqueid/) liên quan có phạm vi toàn bài thuyết trình, nhưng nó dành cho các add‑in và có thể được gán lại. Nó không nên được coi là khóa bên ngoài vĩnh viễn. Nếu tính đồng nhất lâu dài là quan trọng, hãy giữ ánh xạ trong dữ liệu ứng dụng và xác thực rằng hình dạng mong đợi vẫn tồn tại.

Ví dụ sau tìm kiếm theo `Name` bằng so sánh thứ tự và báo cáo ID interop có phạm vi slide. Khi mẫu không chứa hình dạng mong đợi, mã sẽ báo kết quả đó thay vì tiếp tục với đối tượng sai.

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

Khi một thao tác đặc thù cho kiểu hình dạng, hãy kiểm tra giao diện trước khi sử dụng các thành viên đặc thù kiểu. Ví dụ này cập nhật văn bản và văn bản thay thế chỉ khi đối tượng được đặt tên là một [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/).

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

## **Sửa đổi Bộ sưu tập Hình dạng**

Các phương pháp thêm, sao chép, xóa và thay đổi thứ tự hoạt động trên bộ sưu tập ngay lập tức. Nếu một thao tác thay đổi số lượng hoặc thứ tự các hình dạng, đừng tiếp tục dựa vào các chỉ mục đã được lấy trước thao tác đó.

### **Sao chép một Hình dạng**

[AddClone](https://reference.aspose.com/slides/vi/net/aspose.slides/ishapecollection/addclone/) tạo một bản sao độc lập và thêm nó vào cuối bộ sưu tập đích. [InsertClone](https://reference.aspose.com/slides/vi/net/aspose.slides/ishapecollection/insertclone/) cũng tạo một bản sao nhưng đặt nó ở chỉ mục z‑order được chỉ định. Các overload nhận tọa độ di chuyển bản sao mà không thay đổi kích thước; các overload có chiều rộng và chiều cao có thể thay đổi kích thước nó đồng thời.

Ví dụ tạo một slide đích, sao chép một hình chữ nhật có nhãn vào phía trước, và chèn một bản sao thứ hai vào phía sau. Thay đổi đối với bất kỳ bản sao nào cũng không làm thay đổi hình dạng nguồn.

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

Sao chép sao chép nội dung và định dạng của hình dạng, bao gồm tên và văn bản thay thế. Gán các định danh logic mới cho bản sao khi những giá trị đó phải là duy nhất. Các tài nguyên được các hình dạng phức tạp sử dụng được trình bày quản lý, nhưng một bản sao vẫn là một mục mới trong bộ sưu tập với định danh hình dạng mới.

### **Xóa Hình dạng**

[Remove](https://reference.aspose.com/slides/vi/net/aspose.slides/ishapecollection/remove/) xóa một đối tượng hình dạng cụ thể khỏi bộ sưu tập của nó. Khi xóa nhiều kết quả khớp trong vòng lặp dựa trên chỉ mục, hãy duyệt từ cuối xuống để mỗi chỉ mục còn lại vẫn hợp lệ.

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

Sau khi xóa, số lượng hình dạng và chỉ mục của các hình dạng sau thay đổi. Tham chiếu tới các hình dạng không bị ảnh hưởng vẫn đáng tin cậy hơn so với các chỉ mục đã lưu. Cũng cần cân nhắc các connector, animation và các tính năng khác của bài thuyết trình có thể tham chiếu tới đối tượng đã bị xóa; việc xóa một hình dạng hiển thị có thể thay đổi hơn cả giao diện slide.

### **Ẩn một Hình dạng**

Đặt [Hidden](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/hidden/) thành `true` giữ hình dạng trong bộ sưu tập nhưng ngăn nó xuất hiện trong buổi chiếu slide bình thường. Chỉ mục, định dạng và nội dung của nó vẫn khả dụng cho mã, vì vậy việc ẩn phù hợp cho các yếu tố tùy chọn có thể được khôi phục sau.

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

Ẩn không phải là xóa hay bảo mật. Đối tượng vẫn có thể được người dùng hoặc mã khám phá và hiện lại, và nó vẫn là một phần của tệp bài thuyết trình.

### **Thay đổi Thứ tự Z**

Các hình dạng chồng lên nhau được vẽ theo thứ tự của bộ sưu tập. [Reorder](https://reference.aspose.com/slides/vi/net/aspose.slides/ishapecollection/reorder/) di chuyển một hình dạng hiện có đến chỉ mục đích mà không sao chép nó. Chỉ mục `0` là phía sau; `Count - 1` là phía trước.

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

Hình chữ nhật được tạo đầu tiên và ban đầu nằm phía sau hình ellipse. Di chuyển nó đến chỉ mục cuối cùng sẽ đặt nó ở phía trước. Hoàn thiện thứ tự z‑order sau khi đã thêm hoặc sao chép tất cả các hình dạng liên quan, vì các thao tác đó thêm hoặc chèn mục mới vào bộ sưu tập và có thể làm thay đổi cấu trúc xếp chồng dự định.

## **Kiểm tra Hình dạng trên Slide Bố cục**

Slide thường, slide bố cục và slide mẫu có các bộ sưu tập hình dạng riêng biệt. Một hình dạng trong bộ sưu tập bố cục không phải là cùng một đối tượng với một hình dạng tương tự trên slide thường. Kiểm tra các hình dạng bố cục khi bạn cần hiểu hoặc thay đổi định dạng do bố cục cung cấp.

Ví dụ dưới đây đọc [FillFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/fillformat/) và [LineFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/lineformat/) của mỗi hình dạng bố cục mà không giả định rằng mọi hình dạng đều là `AutoShape`.

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

Chỉnh sửa một bố cục có thể ảnh hưởng tới nhiều slide sử dụng nó. Trước khi thay đổi một hình dạng bố cục, hãy xác định xem slide thường có kế thừa đối tượng này hay chứa một ghi đè cục bộ, và kiểm tra mọi slide sử dụng bố cục đó.

## **Xuất Hình dạng sang SVG**

[WriteAsSvg](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/writeassvg/) ghi nội dung đã render của một hình dạng vào một luồng. Kết quả chỉ chứa hình dạng, không phải toàn bộ nền slide hay các hình dạng lân cận.

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

Giữ bài thuyết trình mở trong khi render. Đầu ra phụ thuộc vào định dạng của hình dạng và các tài nguyên như phông chữ và hình ảnh. Nếu bạn cần toàn bộ bố cục, hãy xuất slide thay vì một hình dạng riêng lẻ. Người gọi sở hữu luồng và phải giải phóng nó.

## **Canh chỉnh Hình dạng**

Các overload của [SlideUtil.AlignShapes](https://reference.aspose.com/slides/vi/net/aspose.slides.util/slideutil/alignshapes/) căn chỉnh hoặc tất cả các hình dạng hoặc các chỉ mục bộ sưu tập đã chọn. [ShapesAlignmentType](https://reference.aspose.com/slides/vi/net/aspose.slides/shapesalignmenttype/) xác định cạnh, đường trung tâm hoặc chế độ phân phối. Đặt `alignToSlide` thành `true` để sử dụng các cạnh slide; đặt thành `false` để căn chỉnh các hình dạng đã chọn tương đối với nhau.

Ví dụ này căn chỉnh ba hình dạng đến cạnh trên của slide. Các tham chiếu hình dạng trả về được chuyển sang chỉ mục hiện tại ngay trước khi căn chỉnh.

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

Căn chỉnh thay đổi vị trí, không phải thứ tự z. Căn chỉnh tương đối thường yêu cầu ít nhất hai hình dạng, trong khi phân phối ngang hoặc dọc cần đủ hình dạng để xác định khoảng cách. Tính lại chỉ mục nếu bạn sửa đổi bộ sưu tập trước khi gọi phương thức.

## **Lật một Hình dạng**

Lớp [ShapeFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/shapeframe/) lưu trữ vị trí, kích thước, các thiết lập lật ngang và dọc, và góc quay. Các giá trị `FlipH` và `FlipV` của nó sử dụng [NullableBool](https://reference.aspose.com/slides/vi/net/aspose.slides/nullablebool/): `True` bật lật, `False` tắt lật, và `NotDefined` giữ trạng thái chưa xác định/mặc định.

Bài thuyết trình nhập dưới đây chứa một hình dạng chưa được lật.

![Hình dạng trước khi lật](shape_to_be_flipped.png)

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

Hình dạng đã lưu được phản chiếu ngang và dọc trong khi giữ nguyên vị trí, kích thước và góc quay.

![Hình dạng sau khi lật](flipped_shape.png)

## **Câu hỏi thường gặp**

**Có nên sử dụng chỉ mục bộ sưu tập làm định danh cho hình dạng không?**

Chỉ nên dùng trong các quy trình ngắn hạn khi bộ sưu tập sẽ không thay đổi trước khi chỉ mục được sử dụng. Nên ưu tiên một quy ước `Name` hoặc `AlternativeText` đã được xác thực cho các mẫu được tạo, hoặc `OfficeInteropShapeId` cho công việc interop có phạm vi slide.

**Việc ẩn một hình dạng có loại bỏ nó khỏi thứ tự z không?**

Không. Một hình dạng ẩn vẫn nằm trong bộ sưu tập với cùng chỉ mục. Nó có thể được tìm, thay đổi thứ tự, chỉnh sửa hoặc hiển thị lại.

**Tại sao một hình dạng sao chép lại xuất hiện phía trước một hình dạng khác?**

`AddClone` thêm bản sao vào cuối bộ sưu tập, đó là phía trước của thứ tự z. Hãy dùng `InsertClone` để chọn chỉ mục ban đầu hoặc `Reorder` sau khi đã thêm tất cả các hình dạng.