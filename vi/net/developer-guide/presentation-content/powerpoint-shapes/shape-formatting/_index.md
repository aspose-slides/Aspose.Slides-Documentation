---
title: Định dạng các hình PowerPoint trong .NET
linktitle: Định dạng hình
type: docs
weight: 20
url: /vi/net/shape-formatting/
keywords:
- định dạng hình
- định dạng đường
- hiệu ứng vẽ tay
- đường vẽ tay hình dạng
- định dạng kiểu nối
- đổ màu gradient
- đổ màu mẫu
- đổ màu ảnh
- đổ màu texture
- đổ màu đồng nhất
- độ trong suốt hình
- hiển thị hình đen‑trắng
- hiển thị hình xám
- xoay hình
- hiệu ứng bevel 3D
- hiệu ứng xoay 3D
- đặt lại định dạng
- PowerPoint
- bản trình bày
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu cách định dạng các hình PowerPoint trong C# bằng Aspose.Slides—đặt kiểu đổ màu, đường viền và hiệu ứng cho tệp PPT và PPTX một cách chính xác và kiểm soát đầy đủ."
---
## **Giới thiệu**

Định dạng các hình dạng trong PowerPoint bằng cách điều chỉnh viền, tô màu và hiệu ứng của chúng. Aspose.Slides cho .NET cho phép bạn kiểm soát các cài đặt này bằng chương trình, bao gồm độ trong suốt, xoay và định dạng 3D.

![Các tùy chọn định dạng hình trong PowerPoint](format-shape-powerpoint.png)

Aspose.Slides cho .NET cung cấp các giao diện và thuộc tính cho phép bạn định dạng hình dạng bằng các tùy chọn có sẵn trong PowerPoint.

## **Định dạng đường viền**

Sử dụng [IShape.LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) để kiểm soát viền của một hình. Ví dụ này tạo một hình chữ nhật không tô màu với viền màu xanh da trời dạng gạch đứt. [ILineFormat.Style](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/style/) chọn một đường ghép dày‑mỏng, trong khi [ILineFormat.Width](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/width/) đặt độ rộng của nó là 7 điểm và [ILineFormat.DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) chọn mẫu gạch.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.Style = LineStyle.ThickThin;
shape.LineFormat.Width = 7;
shape.LineFormat.DashStyle = LineDashStyle.Dash;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

presentation.Save("formatted_lines.pptx", SaveFormat.Pptx);
```

Kết quả:

![Các đường viền đã định dạng trong bản trình bày](formatted-lines.png)

### **Đặt mẫu gạch tùy chỉnh cho đường viền**

Sử dụng [ILineFormat.CustomDashPattern](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/customdashpattern/) khi các kiểu đường viền có sẵn không cung cấp độ dài gạch và khoảng trống bạn cần, ví dụ cho viền thương hiệu hoặc sơ đồ kỹ thuật. Gán một mẫu sẽ tự động đặt [ILineFormat.DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) thành [LineDashStyle.Custom](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/).

Các mục trong mảng xen kẽ giữa độ dài gạch và khoảng trống, bắt đầu bằng gạch. Mỗi giá trị là một bội số của độ rộng đường viền: `{ 4, 2 }` ở độ rộng 3 điểm tạo ra một đoạn gạch 12 điểm theo sau là một khoảng trống 6 điểm. Sử dụng các cặp giá trị hữu hạn, không âm để định nghĩa các đoạn gạch‑khoảng trống đầy đủ. Ví dụ sử dụng các giá trị dương để giữ cho mọi gạch và khoảng trống đều nhìn thấy.

Ví dụ này tạo năm đường màu xanh có cùng độ dài và đầu thẳng. Ba đường đầu tiên so sánh các mẫu ở độ rộng 3 điểm. Đường thứ tư lặp lại mẫu đầu tiên với độ rộng gấp đôi, làm đôi cả độ dài gạch và khoảng trống. Đường thứ năm chuyển từ mẫu tùy chỉnh sang đường liền.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(600, 300, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var patterns = new[]
{
    new float[] { 4, 2 },
    new float[] { 1, 2 },
    new float[] { 6, 2, 1, 2 },
    new float[] { 4, 2 },
    new float[] { 4, 2 }
};

for (var i = 0; i < patterns.Length; i++)
{
    var line = slide.Shapes.AddAutoShape(ShapeType.Line, 50, 50 + i * 50, 500, 0);
    line.LineFormat.Width = i == 3 ? 6 : 3;
    line.LineFormat.FillFormat.FillType = FillType.Solid;
    line.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
    line.LineFormat.CapStyle = LineCapStyle.Flat;
    line.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.None;
    line.LineFormat.EndArrowheadStyle = LineArrowheadStyle.None;
    line.LineFormat.CustomDashPattern = patterns[i];
}

// Đặt lại đường cuối cùng thành kiểu liền.
slide.Shapes[4].LineFormat.DashStyle = LineDashStyle.Solid;

presentation.Save("custom_dash_patterns.pptx", SaveFormat.Pptx);
```

Để quay lại kiểu gạch có sẵn, gán [LineDashStyle.Dash](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/) cho [ILineFormat.DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/). Kiểu đã chọn sẽ kiểm soát cách hiển thị của đường viền.

Kết quả trong PowerPoint, từ trên xuống dưới: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; và **Solid, 3 pt**.

![Ba mẫu gạch tùy chỉnh, một đường rộng hơn dùng mẫu đầu tiên, và một đường liền trong PowerPoint](custom-dash-patterns.png)


### **Đặt kiểu đầu mút cho đường viền**

Sử dụng [ILineFormat.CapStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/capstyle/) để đặt đầu mút của một đường mở. Phân loại [LineCapStyle](https://reference.aspose.com/slides/net/aspose.slides/linecapstyle/) cung cấp ba kiểu đầu mút rõ ràng:

- `Flat`: Đường dừng lại ở điểm cuối.
- `Round`: Đầu mút bán vòng mở rộng ra ngoài điểm cuối bằng một nửa độ rộng đường viền.
- `Square`: Đầu mút vuông mở rộng ra ngoài điểm cuối bằng một nửa độ rộng đường viền.

Phân loại cũng bao gồm `NotDefined`, nghĩa là không có kiểu đầu mút nào được chỉ định rõ ràng.

Đầu mút khác với mũi tên, chúng thêm ký hiệu vào đầu đường, và các nối, chúng kiểm soát các góc giữa các đoạn đường. Ví dụ này tắt mũi tên bằng [ILineFormat.BeginArrowheadStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/beginarrowheadstyle/) và [ILineFormat.EndArrowheadStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/endarrowheadstyle/) để chỉ so sánh các hình dạng đầu mút.

Ví dụ sau tạo ba đường ngang gần như giống hệt nhau, mỗi đường rộng 20 điểm. Từ trên xuống dưới, chúng sử dụng đầu mút flat, round và square. Các điểm cuối có cùng tọa độ ngang; các đầu mút round và square mở rộng 10 điểm ra ngoài mỗi đầu.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(500, 240, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var capStyles = new[] { LineCapStyle.Flat, LineCapStyle.Round, LineCapStyle.Square };

for (var i = 0; i < capStyles.Length; i++)
{
    var line = slide.Shapes.AddAutoShape(ShapeType.Line, 100, 50 + i * 70, 300, 0);
    line.LineFormat.Width = 20;
    line.LineFormat.FillFormat.FillType = FillType.Solid;
    line.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
    line.LineFormat.DashStyle = LineDashStyle.Solid;
    line.LineFormat.CapStyle = capStyles[i];
    line.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.None;
    line.LineFormat.EndArrowheadStyle = LineArrowheadStyle.None;
}

presentation.Save("line_caps.pptx", SaveFormat.Pptx);
```

Kết quả trong PowerPoint, từ trên xuống dưới: **Flat**, **Round**, và **Square**.

![Đầu mút flat, round và square trên các đường dày giống hệt trong PowerPoint](line-caps.png)

## **Áp dụng hiệu ứng vẽ tay cho đường viền hình dạng**

Hiệu ứng vẽ tay làm cho đường viền của một hình trông như được vẽ bằng tay. Sử dụng [IShape.LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) để truy cập cài đặt đường, [ILineFormat.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/sketchformat/) để truy cập cài đặt vẽ tay, và [ISketchFormat.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformat/sketchtype/) để chọn một giá trị từ phân loại [LineSketchType](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/).

Mã C# dưới đây cho thấy cách áp dụng hiệu ứng [LineSketchType.Curved](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/) , đọc giá trị đã gán một cách rõ ràng, và loại bỏ hiệu ứng bằng [LineSketchType.None](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/):

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

var sketchFormat = shape.LineFormat.SketchFormat;
sketchFormat.SketchType = LineSketchType.Curved;
var explicitSketchType = sketchFormat.SketchType;
Console.WriteLine($"Explicit sketch type: {explicitSketchType}");
sketchFormat.SketchType = LineSketchType.None;
```

Giá trị trả về bởi [ISketchFormat.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformat/sketchtype/) đại diện cho cài đặt được gán trực tiếp cho hình. Nếu định dạng đường có thể được kế thừa từ một chủ đề, slide chủ, hoặc slide bố cục, sử dụng [ILineFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/geteffective/), truy cập [ILineFormatEffectiveData.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformateffectivedata/sketchformat/), và đọc [ISketchFormatEffectiveData.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformateffectivedata/sketchtype/). Giá trị hiệu quả phản ánh định dạng thực sự được áp dụng sau khi kế thừa được giải quyết. Ví dụ này yêu cầu một bản trình bày hiện có có ít nhất một hình trên slide đầu tiên và in cả hai giá trị:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var shape = presentation.Slides[0].Shapes[0];

var lineFormat = shape.LineFormat;
var explicitSketchType = lineFormat.SketchFormat.SketchType;
var effectiveLineFormat = lineFormat.GetEffective();
var effectiveSketchType = effectiveLineFormat.SketchFormat.SketchType;

Console.WriteLine($"Explicit sketch type: {explicitSketchType}");
Console.WriteLine($"Effective sketch type: {effectiveSketchType}");
```

## **Định dạng kiểu nối**

Dưới đây là ba tùy chọn kiểu nối:

* Round
* Miter
* Bevel

Kiểu nối kiểm soát cách hai đoạn viền gặp nhau tại một góc. Sử dụng **Round** cho các góc tròn, **Miter** cho các góc nhọn, hoặc **Bevel** cho các góc phẳng.

![Kiểu nối trong bản trình bày](join-style-powerpoint.png)

Ví dụ này tạo ba hình chữ nhật màu đen với viền màu xanh rộng 15 điểm. Nó đặt [ILineFormat.JoinStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/joinstyle/) thành các giá trị miter, bevel và round của [LineJoinStyle](https://reference.aspose.com/slides/net/aspose.slides/linejoinstyle/), tương ứng, để so sánh cách các góc được vẽ.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var miterShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
var bevelShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
var roundShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

miterShape.FillFormat.FillType = FillType.Solid;
miterShape.FillFormat.SolidFillColor.Color = Color.Black;
bevelShape.FillFormat.FillType = FillType.Solid;
bevelShape.FillFormat.SolidFillColor.Color = Color.Black;
roundShape.FillFormat.FillType = FillType.Solid;
roundShape.FillFormat.SolidFillColor.Color = Color.Black;

miterShape.LineFormat.Width = 15;
bevelShape.LineFormat.Width = 15;
roundShape.LineFormat.Width = 15;

miterShape.LineFormat.FillFormat.FillType = FillType.Solid;
miterShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
bevelShape.LineFormat.FillFormat.FillType = FillType.Solid;
bevelShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
roundShape.LineFormat.FillFormat.FillType = FillType.Solid;
roundShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

miterShape.LineFormat.JoinStyle = LineJoinStyle.Miter;
bevelShape.LineFormat.JoinStyle = LineJoinStyle.Bevel;
roundShape.LineFormat.JoinStyle = LineJoinStyle.Round;

miterShape.TextFrame.Text = "Miter Join Style";
bevelShape.TextFrame.Text = "Bevel Join Style";
roundShape.TextFrame.Text = "Round Join Style";

presentation.Save("join_styles.pptx", SaveFormat.Pptx);
```

### **Giới hạn miter tại các góc nhọn**

Sử dụng [ILineFormat.MiterLimit](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/miterlimit/) cùng với [ILineFormat.JoinStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/joinstyle/) được đặt thành [LineJoinStyle.Miter](https://reference.aspose.com/slides/net/aspose.slides/linejoinstyle/) để giới hạn mức độ mà một góc nhọn có thể mở rộng.

Giới hạn là tỉ lệ giữa khoảng cách giữa góc trong và góc ngoài của nối so với độ rộng đường viền. Ví dụ, giá trị `8` cho phép độ dài miter lên tới tám lần độ rộng đường viền; đây không phải là một đo lường bằng điểm. Nếu góc vượt quá giới hạn, PowerPoint sẽ sử dụng nối bevel tại góc đó. Giới hạn lớn hơn cho phép các điểm nhọn hơn. Cài đặt này chỉ ảnh hưởng đến các nối miter và không có hiệu quả hiển thị khi góc vẫn nằm trong cả hai giới hạn.

Ví dụ này tạo hai tam giác không tô màu, mỗi tam giác có viền rộng 20 điểm. Tam giác bên trái sử dụng giới hạn `2`, còn bên phải sử dụng `8`. Mỗi tam giác rộng 80 điểm và cao 160 điểm, đưa tỉ lệ độ dài miter‑so‑với‑độ‑rộng‑đường‑viền của góc trên khoảng `4.12`. Do đó, PowerPoint bevel góc phía trái và giữ nguyên góc phía phải.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(500, 320, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var miterLimits = new[] { 2f, 8f };

for (var i = 0; i < miterLimits.Length; i++)
{
    var triangle = slide.Shapes.AddAutoShape(ShapeType.Triangle, 90 + i * 240, 110, 80, 160);
    triangle.FillFormat.FillType = FillType.NoFill;
    triangle.LineFormat.Width = 20;
    triangle.LineFormat.FillFormat.FillType = FillType.Solid;
    triangle.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
    triangle.LineFormat.JoinStyle = LineJoinStyle.Miter;
    triangle.LineFormat.MiterLimit = miterLimits[i];
}

presentation.Save("miter_limits.pptx", SaveFormat.Pptx);
```

Kết quả trong PowerPoint: **Miter limit 2** ở bên trái và **miter limit 8** ở bên phải.

![Một đỉnh bevel với miter limit 2 và một đỉnh nhọn với miter limit 8 trong PowerPoint](miter-limits.png)

## **Đổ màu dần**

Đổ màu dần pha trộn các màu qua một hình dạng. Ví dụ này đổ màu cho một hình ellipse bằng gradient tuyến tính 45 độ từ đỏ sang tím sử dụng [IFillFormat.GradientFormat](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/gradientformat/). Phương thức [IGradientStopCollection.Add](https://reference.aspose.com/slides/net/aspose.slides/igradientstopcollection/add/) đặt các điểm dừng màu ở 0 và 1, tương ứng với đầu và cuối gradient. Xóa các điểm dừng hiện có đảm bảo chỉ hai màu này được sử dụng.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);
shape.FillFormat.FillType = FillType.Gradient;
shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;
shape.FillFormat.GradientFormat.LinearGradientAngle = 45;
shape.FillFormat.GradientFormat.GradientStops.Clear();
shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Purple);
shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Red);

presentation.Save("gradient_fill.pptx", SaveFormat.Pptx);
```

Kết quả:

![Ellipse với đổ màu dần](gradient-fill.png)

Nếu một gradient trông khác nhau trong ảnh xuất khẩu so với trong PowerPoint, xem [Choose a Gradient Rendering Style](/slides/vi/net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Bạn có thể chọn kiểu hiển thị mà không thay đổi gradient lưu trong bản trình bày.

### **Đặt góc gradient tuyến tính**

Sử dụng [IGradientFormat.LinearGradientAngle](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/lineargradientangle/) để kiểm soát hướng của một bộ đổ màu [GradientShape.Linear](https://reference.aspose.com/slides/net/aspose.slides/gradientshape/). Góc được đo bằng độ và tăng theo chiều kim đồng hồ: `0` chạy từ trái sang phải, `90` từ trên xuống dưới, `180` từ phải sang trái, và `270` từ dưới lên trên. Các góc thập phân được hỗ trợ. Các góc hữu hạn nằm ngoài `[0, 360)` được chuẩn hoá thành một vòng quay; ví dụ, `-45` trở thành `315` và `360` trở thành `0`.

Ví dụ này tạo sáu hình chữ nhật với các điểm dừng màu đỏ, xanh lá và xanh dương giống nhau tại vị trí `0`, `0.5`, và `1`. Thuộc tính scaling bị tắt để có thể so sánh góc độc lập với tỷ lệ các hình chữ nhật. Các góc, từ trái sang phải, là `0`, `45`, và `90` ở hàng đầu, và `135`, `180`, và `270` ở hàng dưới.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 400, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var angles = new float[] { 0, 45, 90, 135, 180, 270 };

for (var i = 0; i < angles.Length; i++)
{
    var x = 30 + (i % 3) * 230;
    var y = 30 + (i / 3) * 190;

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x, y, 200, 150);
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;
    shape.FillFormat.FillType = FillType.Gradient;

    var gradient = shape.FillFormat.GradientFormat;
    gradient.GradientShape = GradientShape.Linear;
    gradient.GradientStops.Clear();
    gradient.GradientStops.Add(0f, Color.Red);
    gradient.GradientStops.Add(0.5f, Color.Lime);
    gradient.GradientStops.Add(1f, Color.Blue);
    gradient.LinearGradientScaled = NullableBool.False;
    gradient.LinearGradientAngle = angles[i];
}

presentation.Save("linear_gradient_angles.pptx", SaveFormat.Pptx);
```

Kết quả trong PowerPoint:

![Gradient tuyến tính ở các góc 0, 45, và 90 độ ở hàng trên, và 135, 180, và 270 độ ở hàng dưới](linear-gradient-angles.png)

### **Scale một gradient tuyến tính với hình dạng**

[IGradientFormat.LinearGradientScaled](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/lineargradientscaled/) nhận một giá trị [NullableBool](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/). Đặt nó thành `False` để giữ góc gradient hình học khi tỷ lệ hình thay đổi, hoặc `True` để scale gradient cùng với chiều rộng và chiều cao của hình. Khi scaling được bật, góc hiển thị có thể khác với góc đã gán trên một hình không phải hình vuông.

Ví dụ sau sử dụng góc `45` độ và các điểm dừng màu giống như so sánh góc. Cột trái dùng `False`; cột phải dùng `True`. Mỗi cột chứa một hình chữ nhật rộng ở trên và một hình chữ nhật cao ở dưới. Cả hai bắt đầu với cùng kích thước rộng; việc thay đổi chiều rộng và chiều cao của hình chữ nhật thứ hai cho thấy cách tô màu phản hồi khi thay đổi kích thước mà không thay đổi cài đặt gradient.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 460, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var scalingOptions = new[] { NullableBool.False, NullableBool.True };

for (var column = 0; column < scalingOptions.Length; column++)
{
    for (var row = 0; row < 2; row++)
    {
        var x = 30 + column * 360;
        var y = row == 0 ? 30 : 150;
        
        var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x, y, 300, 90);
        shape.LineFormat.FillFormat.FillType = FillType.NoFill;
        shape.FillFormat.FillType = FillType.Gradient;

        var gradient = shape.FillFormat.GradientFormat;
        gradient.GradientShape = GradientShape.Linear;
        gradient.GradientStops.Clear();
        gradient.GradientStops.Add(0f, Color.Red);
        gradient.GradientStops.Add(0.5f, Color.Lime);
        gradient.GradientStops.Add(1f, Color.Blue);
        gradient.LinearGradientAngle = 45;
        gradient.LinearGradientScaled = scalingOptions[column];

        if (row == 1)
        {
            shape.Width = 90;
            shape.Height = 280;
        }
    }
}

presentation.Save("linear_gradient_scaling.pptx", SaveFormat.Pptx);
```

Kết quả trong PowerPoint, với scaling tắt ở bên trái và bật ở bên phải:

![Các hình chữ nhật rộng và cao với gradient 45 độ, so sánh LinearGradientScaled False bên trái với True bên phải](linear-gradient-scaling.png)

Với scaling tắt, các dải màu chéo giữ cùng hướng trong cả hai hình. Với scaling bật, các dải kéo dài theo tỷ lệ hình. Điều này giúp tái tạo gradient của mẫu khi điều chỉnh hình sang kích thước khác. Trên một hình vuông, bật scaling không thay đổi vẻ ngoài của gradient `45` độ này.

Cả góc và cài đặt scaling đều áp dụng cho gradient tuyến tính. Chúng không kiểm soát các bộ đổ màu [GradientShape.Radial hoặc GradientShape.Rectangle](https://reference.aspose.com/slides/net/aspose.slides/gradientshape/).

### **Kết hợp góc với hướng gradient**

[IGradientFormat.GradientDirection](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/gradientdirection/) chọn một kiểu gradient từ phân loại [GradientDirection](https://reference.aspose.com/slides/net/aspose.slides/gradientdirection/); nó không phải là một thay thế cho góc số. Đối với gradient tuyến tính, các kiểu góc có thể thay đổi khu vực mà màu được phân bố mà không thay đổi [LinearGradientAngle](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/lineargradientangle/). Giữ hướng không đổi khi so sánh góc hoặc scaling.

Ví dụ sau áp dụng cùng một cài đặt nhưng theo thứ tự ngược nhau. Hai hình chữ nhật có cùng ngoại hình: gán hướng trước hoặc sau góc không làm thay đổi kết quả.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

for (var i = 0; i < 2; i++)
{
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30 + i * 140, 320, 100);
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;
    shape.FillFormat.FillType = FillType.Gradient;

    var gradient = shape.FillFormat.GradientFormat;
    gradient.GradientShape = GradientShape.Linear;
    gradient.GradientStops.Clear();
    gradient.GradientStops.Add(0f, Color.Red);
    gradient.GradientStops.Add(0.5f, Color.Lime);
    gradient.GradientStops.Add(1f, Color.Blue);
    gradient.LinearGradientScaled = NullableBool.True;

    if (i == 0)
    {
        gradient.GradientDirection = GradientDirection.FromCorner1;
        gradient.LinearGradientAngle = 30;
    }
    else
    {
        gradient.LinearGradientAngle = 30;
        gradient.GradientDirection = GradientDirection.FromCorner1;
    }
}

presentation.Save("linear_gradient_direction.pptx", SaveFormat.Pptx);
```

## **Đổ màu mẫu**

Đổ màu mẫu áp dụng một thiết kế hai màu, chẳng hạn chấm, sọc, hoặc ô vuông. Ví dụ này sử dụng [IPatternFormat.PatternStyle](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/patternstyle/) để chọn mẫu dạng trellis. [IPatternFormat.BackColor](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/backcolor/) cung cấp nền màu xám nhạt, và [IPatternFormat.ForeColor](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/forecolor/) cung cấp màu vàng cho mẫu.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
shape.FillFormat.FillType = FillType.Pattern;
shape.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;
shape.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
shape.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

presentation.Save("pattern_fill.pptx", SaveFormat.Pptx);
```

Kết quả:

![Hình chữ nhật với đổ màu mẫu](pattern-fill.png)

## **Đổ màu ảnh**

Đổ màu ảnh sử dụng một hình ảnh bên trong một hình dạng. Ví dụ này yêu cầu một ảnh cục bộ và sử dụng [Images.FromFile](https://reference.aspose.com/slides/net/aspose.slides/images/fromfile/) để tải nó vào bộ sưu tập ảnh của bản trình bày. Đặt [IPictureFillFormat.PictureFillMode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/) thành chế độ ghép lặp sẽ lặp lại ảnh trong hình chữ nhật. Ảnh nguồn được sử dụng ở đây được hiển thị bên dưới:

![Ảnh bông sen](lotus.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;

using var image = Images.FromFile("lotus.png");
var presentationImage = presentation.Images.AddImage(image);
shape.FillFormat.PictureFillFormat.Picture.Image = presentationImage;

presentation.Save("picture_fill.pptx", SaveFormat.Pptx);
```

Kết quả:

![Hình dạng với đổ màu ảnh](picture-fill.png)

### **Ghép ảnh thành texture dạng lặp**

Nếu bạn muốn đặt một ảnh lặp làm texture và tùy chỉnh hành vi lặp, có thể sử dụng các thuộc tính sau của giao diện [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/) và lớp [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/):

- [PictureFillMode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/): Đặt chế độ đổ ảnh — `Tile` hoặc `Stretch`.
- [TileAlignment](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilealignment/): Xác định căn chỉnh các ô lặp trong hình dạng.
- [TileFlip](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileflip/): Kiểm soát việc lật ô lặp ngang, dọc hoặc cả hai.
- [TileOffsetX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsetx/): Đặt độ lệch ngang của ô lặp (điểm) so với gốc của hình.
- [TileOffsetY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsety/): Đặt độ lệch dọc của ô lặp (điểm) so với gốc của hình.
- [TileScaleX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescalex/): Xác định tỷ lệ ngang của ô lặp dưới dạng phần trăm.
- [TileScaleY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescaley/): Xác định tỷ lệ dọc của ô lặp dưới dạng phần trăm.

Ví dụ này yêu cầu một ảnh cục bộ và cấu hình [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/) để lặp lại nó ở 50% kích thước gốc. Độ lệch `−32` điểm dịch các ô lặp ngang và dọc; căn chỉnh góc dưới‑phải và lật cả hai hướng quyết định cách texture lặp được sắp xếp.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var firstSlide = presentation.Slides[0];

var shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);
shape.FillFormat.FillType = FillType.Picture;

using var sourceImage = Images.FromFile("lotus.png");
var presentationImage = presentation.Images.AddImage(sourceImage);

var pictureFillFormat = shape.FillFormat.PictureFillFormat;
pictureFillFormat.Picture.Image = presentationImage;
pictureFillFormat.PictureFillMode = PictureFillMode.Tile;
pictureFillFormat.TileOffsetX = -32;
pictureFillFormat.TileOffsetY = -32;
pictureFillFormat.TileScaleX = 50;
pictureFillFormat.TileScaleY = 50;
pictureFillFormat.TileAlignment = RectangleAlignment.BottomRight;
pictureFillFormat.TileFlip = TileFlip.FlipBoth;

presentation.Save("tile.pptx", SaveFormat.Pptx);
```

Kết quả:

![Các tùy chọn ghép lặp](tile-options.png)

## **Đổ màu đậm (solid color fill)**

Đổ màu đậm cung cấp cho một hình một màu duy nhất, đồng nhất. Ví dụ này đặt [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) thành chế độ đổ màu đậm và gán màu vàng thông qua [IFillFormat.SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/), sau đó lưu hình chữ nhật vào bản trình bày.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Yellow;

presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
```

Kết quả:

![Hình dạng với đổ màu đậm](solid-color-fill.png)

### **Sao chép màu trong khi giữ tham chiếu chủ đề**

Sử dụng [IColorFormat.CopyFrom](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/copyfrom/) để sao chép định nghĩa màu, bao gồm loại màu, tham chiếu chủ đề và các biến đổi. Điều này hữu ích khi chuyển màu đổ giữa các hình mà vẫn muốn chúng tiếp tục tuân theo chủ đề của bản trình bày. Phương thức chỉ sao chép màu: nó không sao chép kiểu đổ, viền, hoặc các định dạng khác của hình. Đặt [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) của đối tượng đích một cách rõ ràng.

Ví dụ này tạo ba hình chữ nhật, từ trái qua phải: nguồn, bản sao có nhận thức chủ đề, và bản sao RGB cố định. Nguồn sử dụng [IColorFormat.SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/schemecolor/) để tham chiếu màu accent đầu tiên và thêm một tint thông qua [IColorOperationCollection.Add](https://reference.aspose.com/slides/net/aspose.slides/icoloroperationcollection/add/). Bản sao RGB sử dụng màu đổ hiệu quả của nguồn nên ba hình ban đầu trông giống nhau. Gán [IColorFormat.Color](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/color/) đặt một giá trị RGB cố định và xóa mọi biến đổi màu hiện có.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(660, 220, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

presentation.MasterTheme.ColorScheme.Accent1.Color = Color.RoyalBlue;

var source = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 40, 180, 140);
var themeCopy = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 240, 40, 180, 140);
var rgbCopy = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 450, 40, 180, 140);

foreach (var shape in new[] { source, themeCopy, rgbCopy })
{
    shape.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;
}

var sourceColor = source.FillFormat.SolidFillColor;
sourceColor.SchemeColor = SchemeColor.Accent1;
sourceColor.ColorTransform.Add(ColorTransformOperation.Tint, 0.75f);

themeCopy.FillFormat.SolidFillColor.CopyFrom(sourceColor);
rgbCopy.FillFormat.SolidFillColor.Color = source.FillFormat.GetEffective().SolidFillColor;

using var before = slide.GetImage(1f, 1f);
before.Save("color-copy-before.png", ImageFormat.Png);

// Theme references follow the new accent color; the fixed RGB value does not.
presentation.MasterTheme.ColorScheme.Accent1.Color = Color.OrangeRed;

using var after = slide.GetImage(1f, 1f);
after.Save("color-copy-after.png", ImageFormat.Png);
presentation.Save("copied_colors.pptx", SaveFormat.Pptx);
```

Trước khi thay đổi chủ đề, ba màu đổ đều giống nhau:

![Nguồn, đích CopyFrom, và đích RGB cố định với các màu đổ xanh giống nhau](color-copy-before.png)

Sau khi thay đổi chủ đề, nguồn và bản sao có nhận thức chủ đề sẽ theo màu accent mới và giữ tint. Bản sao RGB cố định vẫn giữ màu xanh:

![Nguồn và đích CopyFrom với màu cam, trong khi đích RGB cố định vẫn màu xanh](color-copy-after.png)

Định nghĩa đã sao chép độc lập với nguồn. Việc thay đổi tham chiếu chủ đề của nguồn, gán màu khác, hoặc thêm/bớt các biến đổi sẽ không ảnh hưởng đến đối tượng đích. Thay đổi chủ đề vẫn ảnh hưởng đến cả hai hình vì mỗi hình vẫn tham chiếu riêng vào cùng một màu chủ đề.

Lưu và mở lại file PPTX sẽ giữ nguyên [IColorFormat.ColorType](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/colortype/), tham chiếu chủ đề và bộ [IColorFormat.ColorTransform](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/colortransform/) của màu đã sao chép; nó không làm phẳng định nghĩa thành RGB.

Khi sao chép giữa các ngữ cảnh chủ đề khác nhau, chẳng hạn các bản trình bày có bảng màu accent khác nhau, tham chiếu đã sao chép sẽ được giải quyết dựa trên chủ đề của đích. Do đó cùng một tham chiếu và các biến đổi có thể tạo ra màu hiển thị khác nhau. Xem [Presentation Theme](/slides/vi/net/presentation-theme/) để biết thêm về cấu hình màu chủ đề.

## **Sử dụng nền slide làm màu đổ cho hình dạng**

Sử dụng [IAutoShape.UseBackgroundFill](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/usebackgroundfill/) khi một hình dạng nên khớp với nền slide, ví dụ trong một mẫu bản trình bày. Đặt [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) thành [FillType.NotDefined](https://reference.aspose.com/slides/net/aspose.slides/filltype/) trước để xóa bất kỳ màu đổ rõ ràng nào. Với sự kết hợp này, hình dạng sẽ sử dụng nền slide thay vì màu đổ kiểu của nó. Bật cờ này một mình không xóa một màu đổ rõ ràng đã tồn tại.

Điều này khác với [FillType.NoFill](https://reference.aspose.com/slides/net/aspose.slides/filltype/): màu đổ nền phủ các đối tượng phía sau hình dạng với khu vực tương ứng của nền slide, trong khi NoFill để các đối tượng đó vẫn hiển thị. Một gradient vẫn được căn chỉnh với slide thay vì khởi động lại bên trong mỗi hình.

Ví dụ sau tạo một nền master được kế thừa bởi slide và đặt một dải màu hồng lụa phía sau ba hình chữ nhật. Hình chữ nhật bên trái sử dụng nền, hình giữa không có màu đổ, và hình bên phải chuyển từ nền sang màu đổ cam rõ ràng.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 400, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

// Kế thừa gradient từ master.
slide.Background.Type = BackgroundType.NotDefined;
slide.LayoutSlide.Background.Type = BackgroundType.NotDefined;
var background = slide.LayoutSlide.MasterSlide.Background;
background.Type = BackgroundType.OwnBackground;
background.FillFormat.FillType = FillType.Gradient;
var gradient = background.FillFormat.GradientFormat;
gradient.GradientShape = GradientShape.Linear;
gradient.LinearGradientAngle = 0;
gradient.GradientStops.Clear();
gradient.GradientStops.Add(0, Color.DarkBlue);
gradient.GradientStops.Add(1, Color.LightSkyBlue);

// Thêm đối tượng này đầu tiên để nó xuất hiện phía sau các hình chữ nhật.
var band = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 25, 150, 670, 100);
band.FillFormat.FillType = FillType.Solid;
band.FillFormat.SolidFillColor.Color = Color.Magenta;
band.LineFormat.FillFormat.FillType = FillType.NoFill;

var backgroundShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 100, 160, 200);
backgroundShape.FillFormat.FillType = FillType.NotDefined;
backgroundShape.UseBackgroundFill = true;

var noFillShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 280, 100, 160, 200);
noFillShape.FillFormat.FillType = FillType.NoFill;

var explicitShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 510, 100, 160, 200);
explicitShape.FillFormat.FillType = FillType.NotDefined;
explicitShape.UseBackgroundFill = true;

// Tắt việc đổ màu nền trước khi áp dụng một màu đổ rõ ràng.
explicitShape.UseBackgroundFill = false;
explicitShape.FillFormat.FillType = FillType.Solid;
explicitShape.FillFormat.SolidFillColor.Color = Color.Orange;

presentation.Save("background_fill.pptx", SaveFormat.Pptx);
```

Kết quả, từ trái qua phải: **đổ màu nền**, **không đổ**, và **đổ màu rõ ràng**. Dải màu hồng lụa bị ẩn bởi các hình trái và phải nhưng vẫn hiển thị qua hình giữa.

![Đổ màu nền, không đổ, và đổ màu cam rõ ràng trên dải hồng lụa](background-fill.png)

Hành vi tương tự áp dụng cho nền được định nghĩa trực tiếp trên slide hoặc kế thừa từ layout. Hình dạng sử dụng nền đã được giải quyết của slide; ví dụ này để cả nền slide và layout không được định nghĩa để master cung cấp.

## **Đặt độ trong suốt**

Đối với một đổ màu đậm, thành phần alpha của màu kiểm soát độ mờ: 0 là hoàn toàn trong suốt và 255 là hoàn toàn đục. Ví dụ này sử dụng giá trị alpha 128 cho một hình chữ nhật màu vàng, làm cho nó khoảng 50% trong suốt để hình dưới vẫn nhìn thấy. Màu được gán thông qua [IFillFormat.SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/).

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const int alpha = 128;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

var transparentShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
transparentShape.FillFormat.FillType = FillType.Solid;
transparentShape.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Yellow);

presentation.Save("shape_transparency.pptx", SaveFormat.Pptx);
```

Kết quả:

![Hình dạng trong suốt](shape-transparency.png)

## **Xoay hình dạng**

Sử dụng [IShape.Rotation](https://reference.aspose.com/slides/net/aspose.slides/ishape/rotation/) để xoay một hình trong mặt phẳng slide. Góc được đo bằng độ; ví dụ này xoay một hình chữ nhật 5 độ theo chiều kim đồng hồ và lưu bản trình bày.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
shape.Rotation = 5;

presentation.Save("shape_rotation.pptx", SaveFormat.Pptx);
```

Kết quả:

![Xoay hình dạng](shape-rotation.png)

## **Thêm hiệu ứng bevel 3D**

Sử dụng [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/threedformat/) để cho một hình độ sâu và các cạnh bevel. Ví dụ này tạo một ellipse màu xanh lá cây với viền màu cam, đặt [IThreeDFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/depth/) thành 4 điểm, và áp dụng bevel trên cùng dạng tròn với độ rộng và chiều cao 6 điểm qua [IThreeDFormat.BevelTop](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/beveltop/). Một camera trực giao nhìn từ phía trước và ánh sáng ba‑điểm làm cho bevel hiển thị.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Green;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Orange;
shape.LineFormat.Width = 2.0;
shape.ThreeDFormat.Depth = 4;
shape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
shape.ThreeDFormat.BevelTop.Height = 6;
shape.ThreeDFormat.BevelTop.Width = 6;
shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.ThreePt;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;

presentation.Save("3D_bevel_effect.pptx", SaveFormat.Pptx);
```

Kết quả:

![Hiệu ứng bevel 3D](3D-bevel-effect.png)

## **Thêm hiệu ứng xoay 3D**

Góc nhìn 3D của một hình được điều khiển bởi các cài đặt camera. Ví dụ này sử dụng [ICamera.SetRotation](https://reference.aspose.com/slides/net/aspose.slides/icamera/setrotation/) với các góc vĩ độ, kinh độ và vòng quay là 40, 35 và 20 độ tương ứng. Nó chọn một camera isometric qua [ICamera.CameraType](https://reference.aspose.com/slides/net/aspose.slides/icamera/cameratype/) và ánh sáng cân bằng qua [ILightRig.LightType](https://reference.aspose.com/slides/net/aspose.slides/ilightrig/lighttype/), sau đó lưu hình chữ nhật đã định dạng.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
autoShape.TextFrame.Text = "Hello, Aspose!";
autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
autoShape.ThreeDFormat.Camera.SetRotation(40, 35, 20);
autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;

presentation.Save("3D_rotation_effect.pptx", SaveFormat.Pptx);
```

Kết quả:

![Hiệu ứng xoay 3D](3D-rotation-effect.png)

## **Kiểm soát hiển thị đen‑trắng cho hình dạng**

Thuộc tính [IShape.BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/ishape/blackwhitemode/) chỉ định cách một hình riêng lẻ được hiển thị khi một bản trình bày được xem hoặc xử lý ở chế độ đen‑trắng. Thuộc tính này không tự động bật chế độ đen‑trắng và không thay đổi màu đổ, đường viền, hoặc các định dạng khác của hình trong chế độ màu bình thường.

Sử dụng một giá trị từ phân loại [BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/blackwhitemode/) để chọn hành vi mong muốn. Ví dụ, `Automatic` để ứng dụng hiển thị chọn cách chuyển đổi, `Gray` và `LightGray` dùng màu xám, `BlackWhite` chỉ dùng đen và trắng, `Black` và `White` buộc một màu duy nhất, `Color` giữ nguyên màu bình thường, và `Hidden` bỏ qua hình trong chế độ đen‑trắng. `NotDefined` nghĩa là không có chế độ ở mức hình được gán.

Ví dụ này tạo một hình chữ nhật màu cam và đặt [IShape.BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/ishape/blackwhitemode/) thành gray. Hình đã lưu giữ màu đổ cam cho hiển thị màu bình thường và yêu cầu màu xám từ các ứng dụng tôn trọng cài đặt hiển thị đen‑trắng.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Orange;
shape.BlackWhiteMode = BlackWhiteMode.Gray;

presentation.Save("shape_black_white_mode.pptx", SaveFormat.Pptx);
```

Trong chế độ màu bình thường, hình chữ nhật vẫn giữ màu đổ cam. Trong quy trình làm việc hiển thị đen‑trắng, nó sử dụng màu xám vì chế độ được đặt thành `Gray`. Điều này cho phép bạn giữ nguyên slide màu đầy đủ trong khi định nghĩa một diện mạo riêng cho việc in ấn, xem trước, hoặc các quy trình khác tôn trọng cài đặt hiển thị đen‑trắng của bản trình bày.

## **Đặt lại định dạng**

Sử dụng [ISlide.Reset](https://reference.aspose.com/slides/net/aspose.slides/islide/reset/) để khôi phục vị trí, kích thước và định dạng của các placeholder slide từ các placeholder bố cục tương ứng. Ví dụ này yêu cầu một bản trình bày hiện có có các placeholder liên kết bố cục và đặt lại mọi slide trước khi lưu. Các hình không có placeholder bố cục tương ứng sẽ không được đặt lại.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
foreach (var slide in presentation.Slides)
{
    slide.Reset();
}

presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Định dạng hình ảnh có ảnh hưởng đến kích thước cuối cùng của file bản trình bày không?**

Màu sắc, kiểu đường viền và cài đặt hiệu ứng thường chỉ thêm ít dữ liệu so với ảnh và phương tiện nhúng. Đổ màu ảnh có thể tăng kích thước file vì ảnh của chúng được lưu trong bản trình bày.

**Làm thế nào để phát hiện các hình trên một slide có cùng định dạng để có thể nhóm chúng lại?**

So sánh các thuộc tính định dạng chính của mỗi hình — màu đổ, đường viền và cài đặt hiệu ứng. Nếu tất cả các giá trị tương ứng khớp nhau, coi các kiểu của chúng là giống hệt và nhóm logic các hình này, giúp việc quản lý kiểu sau này đơn giản hơn.

**Có thể lưu một bộ các kiểu hình tùy chỉnh vào một file riêng để tái sử dụng trong các bản trình bày khác không?**

Có. Lưu các hình mẫu với các kiểu mong muốn trong một slide deck mẫu hoặc file .POTX. Khi tạo một bản trình bày mới, mở mẫu, sao chép các hình đã định dạng bạn cần và áp dụng lại định dạng của chúng ở nơi cần.