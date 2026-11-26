---
title: Tùy chỉnh các hình dạng trong bài thuyết trình bằng .NET
linktitle: Hình dạng tùy chỉnh
type: docs
weight: 20
url: /vi/net/custom-shape/
keywords:
- hình dạng tùy chỉnh
- thêm hình dạng
- tạo hình dạng
- thay đổi hình dạng
- hình học hình dạng
- đường hình học
- các điểm đường
- điểm chỉnh sửa
- thêm điểm
- xóa điểm
- hoạt động chỉnh sửa
- góc cong
- PowerPoint
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Tạo và tùy chỉnh các hình dạng trong bài thuyết trình PowerPoint với Aspose.Slides cho .NET: đường hình học, góc cong, hình dạng tổng hợp."
---
## **Tổng quan**

Bài viết này giải thích cách tùy chỉnh các hình dạng trong bài thuyết trình bằng Aspose.Slides bằng cách chỉnh sửa hình học hình dạng thông qua các điểm chỉnh sửa và đường dẫn hình học. Nó cho thấy cách làm việc với [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) và [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/) để sửa đổi các hình dạng hiện có, thực hiện các thao tác chỉnh sửa đường cơ bản, thêm hoặc xóa các điểm, và áp dụng hình học đã cập nhật trở lại cho một hình dạng.

Nó cũng trình bày cách tạo các hình dạng tùy chỉnh và hợp hợp, xây dựng các hình dạng có góc cong, xác định xem hình học của một hình dạng có đóng không, và sử dụng chuyển đổi legacy giữa [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) và [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) cho các kịch bản tùy chỉnh hình học bổ sung.

## **Thay đổi một hình dạng bằng Điểm chỉnh sửa**

Trong PowerPoint, bạn có thể sử dụng **Điểm chỉnh sửa** để sửa đổi một hình vuông:

* Di chuyển một góc vào trong hoặc ra ngoài.
* Điều chỉnh độ cong tại một điểm.
* Thêm các điểm mới.

Việc chỉnh sửa các điểm cho phép bạn sửa đổi đường viền của hình dạng hoặc sử dụng một hình dạng hiện có làm cơ sở cho một hình dạng mới.

## **Mẹo chỉnh sửa hình dạng**

![hình_đánh_giá](custom_shape_0.png)

Khi chỉnh sửa các hình dạng trong PowerPoint, hãy ghi nhớ các khái niệm sau:

* Một hình dạng (hoặc đường dẫn của nó) có thể là đóng hoặc mở.
* Đường dẫn của một hình dạng gồm các điểm neo được nối bằng các đoạn.
* Một đoạn có thể thẳng hoặc cong. Các điểm neo và tay cầm điều khiển xác định hình dạng của nó.
* Các điểm neo tồn tại dưới dạng điểm góc, điểm thẳng hoặc điểm mượt:
  * Tại một điểm góc, các đoạn liền kề có thể gặp nhau ở một góc.
  * Tại một điểm mượt, hai tay cầm điều khiển được thẳng hàng và cách đều điểm neo.
  * Tại một điểm thẳng, hai tay cầm điều khiển thẳng hàng nhưng có thể ở các khoảng cách khác nhau so với điểm neo.
* Di chuyển các điểm neo hoặc điều chỉnh tay cầm của chúng sẽ thay đổi đường viền của hình dạng.

Để chỉnh sửa các hình dạng PowerPoint thông qua các điểm chỉnh sửa, **Aspose.Slides** cung cấp lớp [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) và giao diện [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/).

* Một thể hiện [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) đại diện cho đường hình học của đối tượng [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/).
* Để lấy [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) từ thể hiện [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/), bạn có thể sử dụng phương thức [IGeometryShape.GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/).
* Để đặt [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) cho một hình dạng, bạn có thể sử dụng các phương thức: [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) cho các hình dạng có một đường duy nhất và [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) cho các hình dạng có nhiều đường.
* Để thêm các đoạn, bạn có thể sử dụng các phương thức trong [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/).
* Bằng cách sử dụng các thuộc tính [IGeometryPath.Stroke](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/stroke/) và [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/fillmode/), bạn có thể đặt giao diện cho một đường hình học.
* Bằng cách sử dụng thuộc tính [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/), bạn có thể lấy đường hình học của một [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape/) dưới dạng một mảng các đoạn đường.
* Trong các phiên bản legacy hỗ trợ các phương pháp chuyển đổi dưới đây, bạn có thể chuyển [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) sang [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath).
* Sử dụng các phương thức [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/geometrypathtographicspath/) và [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) (từ lớp [ShapeUtil](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/)) để chuyển đổi giữa [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) và [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath).

## **Các thao tác chỉnh sửa đơn giản**

Sử dụng các phương thức sau để chỉnh sửa một đường hình học. Các phiên bản overload chấp nhận một chỉ mục sẽ chèn một đoạn tại vị trí chỉ số không‑dựa trên trong mảng các đoạn của đường.

| Hoạt động | Phương thức |
| --- | --- |
| Append or insert a straight line. | [GeometryPath.LineTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/lineto/) |
| Append or insert a cubic Bézier curve with two control points and an endpoint. | [GeometryPath.CubicBezierTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/cubicbezierto/) |
| Append or insert a quadratic Bézier curve with one control point and an endpoint. | [GeometryPath.QuadraticBezierTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/quadraticbezierto/) |
| Append an elliptical arc with the specified dimensions and angles in degrees. | [GeometryPath.ArcTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/arcto/) |
| Close the current figure by connecting its endpoint to its starting point. | [GeometryPath.CloseFigure](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/closefigure/) |
| Set the starting point of a figure. | [GeometryPath.MoveTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/moveto/) |
| Remove a segment at a zero-based index. | [GeometryPath.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/removeat/) |

## **Thêm các điểm tùy chỉnh vào một hình dạng**

Ví dụ này chèn hai điểm vào một hình chữ nhật bằng cách sử dụng [GeometryPath.LineTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/lineto/) và áp dụng đường đã chỉnh sửa với [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/). Các tọa độ là cục bộ đối với hình dạng: cả hai điểm mới đều nằm ở trung tâm, 100 điểm từ bên trái và 50 điểm từ trên. Các chỉ mục đoạn 1 và 4 đặt chúng trên các cạnh trên và dưới, kéo các cạnh này vào trong.

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

var geometryPath = shape.GetGeometryPaths()[0];
geometryPath.LineTo(100, 50, 1);
geometryPath.LineTo(100, 50, 4);

shape.SetGeometryPath(geometryPath);
```
![ví dụ1_hình_ảnh](custom_shape_1.png)

## **Xóa các điểm khỏi một hình dạng**

Ví dụ này thay đổi đường viền hình trái tim bằng cách xóa đoạn tại chỉ số không‑dựa trên 2 bằng [GeometryPath.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/removeat/). Áp dụng đường đã sửa đổi với [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) sẽ cập nhật đường viền của hình dạng.

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Heart, 100, 100, 300, 300);

var path = shape.GetGeometryPaths()[0];
path.RemoveAt(2);

shape.SetGeometryPath(path);
```
![ví dụ2_hình_ảnh](custom_shape_2.png)

## **Tạo một hình dạng tùy chỉnh**

Ví dụ này xây dựng một ngôi sao năm cánh bằng [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/). Bán kính ngoài và trong xen kẽ là 100 và 50 điểm xác định các đầu nhọn và các khuyết; bước 72 độ phân bố đều năm đầu nhọn. Đường được đóng bằng [GeometryPath.CloseFigure](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/closefigure/) và áp dụng cho một hình chữ nhật bằng [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/), thay thế đường viền của nó.

```csharp
using System;
using System.Collections.Generic;
using System.Drawing;
using Aspose.Slides;

var points = new List<PointF>();

var outerRadius = 100f;
var innerRadius = 50f;
var angleStep = 72;

for (var angle = -90; angle < 270; angle += angleStep)
{
    var radians = angle * (Math.PI / 180f);
    var x = outerRadius * Math.Cos(radians);
    var y = outerRadius * Math.Sin(radians);
    points.Add(new PointF((float)x + outerRadius, (float)y + outerRadius));

    radians = Math.PI * (angle + angleStep / 2) / 180.0;
    x = innerRadius * Math.Cos(radians);
    y = innerRadius * Math.Sin(radians);
    points.Add(new PointF((float)x + outerRadius, (float)y + outerRadius));
}

var starPath = new GeometryPath();
starPath.MoveTo(points[0]);

for (var i = 1; i < points.Count; i++)
{
    starPath.LineTo(points[i]);
}

starPath.CloseFigure();

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, outerRadius * 2, outerRadius * 2);
shape.SetGeometryPath(starPath);
```
![ví dụ3_hình_ảnh](custom_shape_3.png)

## **Tạo một hình dạng tùy chỉnh tổng hợp**

Ví dụ này định nghĩa hai đối tượng [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) đóng cho phần trên và phần dưới của một hình dạng. Áp dụng cả hai đường với [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) tạo ra một hình dạng tổng hợp duy nhất với một khoảng trống ở phần giữa của nó.

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

var topPath = new GeometryPath();
topPath.MoveTo(0, 0);
topPath.LineTo(shape.Width, 0);
topPath.LineTo(shape.Width, shape.Height / 3);
topPath.LineTo(0, shape.Height / 3);
topPath.CloseFigure();

var bottomPath = new GeometryPath();
bottomPath.MoveTo(0, shape.Height / 3 * 2);
bottomPath.LineTo(shape.Width, shape.Height / 3 * 2);
bottomPath.LineTo(shape.Width, shape.Height);
bottomPath.LineTo(0, shape.Height);
bottomPath.CloseFigure();

shape.SetGeometryPaths(new GeometryPath[] { topPath, bottomPath });
```
![ví dụ4_hình_ảnh](custom_shape_4.png)

## **Tạo một hình dạng tùy chỉnh với các góc cong**

Ví dụ này kết hợp các đoạn thẳng với [GeometryPath.ArcTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/arcto/) để tạo một hình dạng có các góc cong vào trong. Mỗi kích thước góc đặt độ rộng và chiều cao của cung tính bằng điểm, và quét -90 độ vẽ một phần tư elip ngược chiều kim đồng hồ. Đường đã hoàn thành được áp dụng bằng [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/), và bản trình chiếu được lưu dưới định dạng PPTX.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var shapeX = 20f;
var shapeY = 20f;
var shapeWidth = 300f;
var shapeHeight = 200f;

var leftTopSize = 50f;
var rightTopSize = 20f;
var rightBottomSize = 40f;
var leftBottomSize = 10f;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var topLeft = new PointF(leftTopSize, 0);
var topRight = new PointF(shapeWidth - rightTopSize, 0);
var rightBottom = new PointF(shapeWidth, shapeHeight - rightBottomSize);
var bottomLeft = new PointF(leftBottomSize, shapeHeight);
var leftTop = new PointF(0, leftTopSize);

var geometryPath = new GeometryPath();
geometryPath.MoveTo(topLeft);
geometryPath.LineTo(topRight);
geometryPath.ArcTo(rightTopSize, rightTopSize, 180, -90);
geometryPath.LineTo(rightBottom);
geometryPath.ArcTo(rightBottomSize, rightBottomSize, -90, -90);
geometryPath.LineTo(bottomLeft);
geometryPath.ArcTo(leftBottomSize, leftBottomSize, 0, -90);
geometryPath.LineTo(leftTop);
geometryPath.ArcTo(leftTopSize, leftTopSize, 90, -90);
geometryPath.CloseFigure();

var shape = slide.Shapes.AddAutoShape(ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);
shape.SetGeometryPath(geometryPath);

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Xác định xem hình học của một hình dạng có đóng không**

Trợ giúp sau đây kiểm tra xem mọi đường hình học không rỗng có kết thúc bằng một đoạn đóng không. Nó đọc [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/) và so sánh lệnh của đoạn cuối cùng [IPathSegment.PathCommand](https://reference.aspose.com/slides/net/aspose.slides/ipathsegment/pathcommand/) với [PathCommandType.Close](https://reference.aspose.com/slides/net/aspose.slides/pathcommandtype/). Nó trả về false khi không có đường không rỗng. Điều này kiểm tra lệnh cuối cùng của mỗi đường; nó không kiểm tra mọi tiểu hình bên trong một đường. Ví dụ in ra `True` cho một hình chữ nhật.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
Console.WriteLine(IsGeometryClosed(shape));

bool IsGeometryClosed(IGeometryShape geometryShape)
{
    var hasNonemptyPath = false;

    foreach (var geometryPath in geometryShape.GetGeometryPaths())
    {
        var segments = geometryPath.PathData;
        if (segments.Length == 0)
        {
            continue;
        }

        hasNonemptyPath = true;
        var lastSegment = segments[segments.Length - 1];
        if (lastSegment.PathCommand != PathCommandType.Close)
        {
            return false;
        }
    }

    return hasNonemptyPath;
}
```

## **Kiểm tra các lệnh đường hình học**

Tải xuống [contour.pptx](contour.pptx) và đặt nó vào thư mục làm việc của ứng dụng. Slide đầu tiên chứa một hình dạng có cạnh trên thẳng, một đường cong Bézier bậc ba và một cạnh đóng thẳng. Sử dụng [GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/) để đọc các đường của nó. Mỗi đường liệt kê các đoạn của nó theo thứ tự vẽ trong [PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/). Lệnh [PathCommand](https://reference.aspose.com/slides/net/aspose.slides/ipathsegment/pathcommand/) của mỗi đoạn xác định cách đọc [SegmentData](https://reference.aspose.com/slides/net/aspose.slides/ipathsegment/segmentdata/).

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("contour.pptx");

var shape = (IGeometryShape)presentation.Slides[0].Shapes[0];
var paths = shape.GetGeometryPaths();

for (int i = 0; i < paths.Length; i++)
{
    var segments = paths[i].PathData;
    for (int j = 0; j < segments.Length; j++)
    {
        var command = segments[j].PathCommand;
        var data = segments[j].SegmentData;
        var detail = command switch
        {
            PathCommandType.MoveTo or PathCommandType.LineTo => $"destination=({data[0]}, {data[1]})",
            PathCommandType.CubicBezierTo => $"control1=({data[0]}, {data[1]}) control2=({data[2]}, {data[3]}) end=({data[4]}, {data[5]})",
            PathCommandType.Close => "no coordinates",
            _ => $"raw=[{string.Join(", ", data)}]"
        };
        Console.WriteLine($"Path {i}, segment {j}: {command} {detail}");
    }
}
```

Hình dạng nằm ở (200, 100) điểm trên slide. Các điểm được báo cáo là cục bộ đối với hình dạng, với (0, 0) ở góc trên‑trái, x tăng về phía bên phải, và y tăng xuống dưới. Đoạn đóng trả về điểm bắt đầu mà không cần thêm tọa độ nào.

```text
Path 0, segment 0: MoveTo destination=(0, 0)
Path 0, segment 1: LineTo destination=(80, 0)
Path 0, segment 2: CubicBezierTo control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: Close no coordinates
```
![Hình PowerPoint có cạnh trên thẳng, cạnh cong từ góc trên‑phải tới góc dưới‑trái, và cạnh trái thẳng](contour.png)

## **Trích xuất và kiểm tra các phần tử hình dạng**

Sử dụng [IGeometryShape.CreateShapeElements](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/createshapeelements/) để kiểm tra một hình dạng hiện có dưới dạng các phần tử chứa các điểm đường và loại điểm. Ép kiểu mỗi [IShapeElement](https://reference.aspose.com/slides/net/aspose.slides/ishapeelement/) trả về sang [ShapeElement](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/) để đọc các mảng [PathPoints](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/pathpoints/) và [PathTypes](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/pathtypes/). Đại diện này hữu ích cho việc phân tích đường viền hoặc truyền hình học tới các công cụ vẽ tùy chỉnh.

Ví dụ mở một bản trình chiếu, tìm hình dạng hình học đầu tiên trực tiếp trên slide đầu tiên, và in các đoạn đường của nó. Sử dụng một bản trình chiếu chứa một hình dạng có các đoạn thẳng và cong để xem cả hai loại đầu ra. Nó không tìm kiếm bên trong các nhóm.

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

var shape = slide.Shapes.OfType<IGeometryShape>().FirstOrDefault();
if (shape == null)
{
    Console.WriteLine("No geometry shape found on the first slide.");
    return;
}

foreach (IShapeElement element in shape.CreateShapeElements())
{
    var shapeElement = (ShapeElement)element;
    var points = shapeElement.PathPoints;
    var types = shapeElement.PathTypes;
    Console.WriteLine("Shape element:");

    for (var i = 0; i < points.Length; i++)
    {
        var pointType = types[i] & 0x07; // Giữ loại đoạn, loại trừ các cờ.
        switch (pointType)
        {
            case 0:
                Console.WriteLine($"Start figure at {points[i]}");
                break;
            case 1:
                Console.WriteLine($"Line to {points[i]}");
                break;
            case 3:
                Console.WriteLine($"Cubic Bezier: controls {points[i]}, {points[i + 1]}; end {points[i + 2]}");
                i += 2; // Tiêu thụ cả hai điểm điều khiển và điểm cuối.
                break;
        }

        if ((types[i] & 0x80) != 0)
        {
            Console.WriteLine("Close subpath back to its starting point.");
        }
    }
}
```

Các mảng tương ứng theo chỉ mục: `points[i]` là một điểm và `types[i]` mô tả vai trò của nó. Kiểu `0` bắt đầu một hình, và kiểu `1` vẽ một đường từ điểm trước tới điểm hiện tại. Một đoạn Bézier bậc ba bắt đầu tại điểm cuối trước và sử dụng ba mục kiểu-`3` liên tiếp: hai điểm điều khiển sau đó là điểm cuối mới. Vòng lặp tiêu thụ ba mục này cùng nhau và kiểm tra điểm cuối để biết có đóng không.

Các loại điểm cũng chứa các cờ. Áp dụng mặt nạ `0x07` để xác định kiểu đoạn, và kiểm tra `0x80` riêng để phát hiện một tiểu đường đóng. Ví dụ, `129` (`0x81`) có nghĩa là một điểm cuối đường thẳng đóng một tiểu đường, và `131` (`0x83`) là một điểm cuối Bézier đóng một tiểu đường. So sánh giá trị thô chỉ với `1` hoặc `3` sẽ bỏ qua các trường hợp này. Các cờ khác, như dash (`0x10`) và marker (`0x20`), không thay đổi kiểu đoạn cơ bản.

**Tọa độ và biến đổi.** Các điểm được đo bằng điểm (1/72 inch), với X tăng sang phải và Y tăng xuống. Đối với một hình không được nhóm, các tọa độ đã trích xuất đã bao gồm vị trí [X](https://reference.aspose.com/slides/net/aspose.slides/shape/x/) và [Y](https://reference.aspose.com/slides/net/aspose.slides/shape/y/) của nó và phản ánh chiều rộng và chiều cao hiện tại. Ví dụ, một hình chữ nhật không xoay tại `(100, 200)` có kích thước `120 × 80` có biên độ viền `(100, 200)`–`(220, 280)`. Không thêm lại vị trí của hình. Trừ X và Y của nó để có được tọa độ tương đối với khung không xoay.

Các điểm đã trích xuất không áp dụng [Rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/) hoặc các lật ngang và dọc của hình. Để tái tạo đường viền hiển thị, áp dụng các biến đổi đó quanh trung tâm của hình. Đối với các hình được nhóm, cũng cần tính đến việc ánh xạ tọa độ và biến đổi của nhóm; không giả định rằng các điểm đã trích xuất là tọa độ cuối cùng trên slide hoặc áp dụng một phép dịch hoặc tỉ lệ hai lần nếu nó đã được phản ánh trong khung của phần tử con.

**Kiểm tra và chỉnh sửa.** Các mảng đã trích xuất mô tả đường viền; việc thay đổi chúng không cập nhật hình dạng gốc. Chọn cách tiếp cận này khi phân tích hoặc mã vẽ của bạn cần các mảng điểm/loại. Sử dụng [GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/) khi bạn cần các lệnh hình học trong hệ tọa độ cục bộ của hình hoặc muốn chỉnh sửa hình học của nó. Áp dụng các đường đã chỉnh sửa qua [SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) hoặc [SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/).

## **Chuyển đổi GeometryPath sang GraphicsPath (System.Drawing.Drawing2D)**

Ví dụ sau yêu cầu một assembly Aspose.Slides for .NET legacy hỗ trợ [ShapeUtil.GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/), như phiên bản 25.10, và môi trường Windows với `System.Drawing.Common`. Các phương pháp chuyển đổi đã bị xóa trong [phiên bản 25.11](https://releases.aspose.com/slides/net/release-notes/2025/aspose-slides-for-net-25-11-release-notes/).

Ví dụ này kết hợp một đường viền hình chữ nhật với văn bản được chuyển đổi thành hình học. [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/fillmode/) của đường viền được đặt để tắt việc điền màu. Một [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) lưu trữ đường viền văn bản, mà [ShapeUtil.GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) chuyển sang một đường hình học đã điền màu. Áp dụng cả hai đường với [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) tạo ra một hình duy nhất chứa hình chữ nhật và văn bản. Để chuyển đổi ngược lại, sử dụng [ShapeUtil.GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/geometrypathtographicspath/).

```csharp
using System.Drawing;
using System.Drawing.Drawing2D;
using Aspose.Slides;
using Aspose.Slides.Util;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

var originalPath = shape.GetGeometryPaths()[0];
originalPath.FillMode = PathFillModeType.None;

using var graphicsPath = new GraphicsPath();
using var fontFamily = new FontFamily("Arial");
using var stringFormat = StringFormat.GenericDefault;

graphicsPath.AddString("Text in shape", fontFamily, (int)FontStyle.Bold, 40, new PointF(10, 10), stringFormat);

var textPath = ShapeUtil.GraphicsPathToGeometryPath(graphicsPath);
textPath.FillMode = PathFillModeType.Normal;

shape.SetGeometryPaths(new[] { originalPath, textPath });
```
![ví dụ5_hình_ảnh](custom_shape_5.png)

## **Câu hỏi thường gặp**

**Điều gì sẽ xảy ra với phần tô và đường viền sau khi thay thế hình học?**

Kiểu dáng vẫn giữ với hình dạng; chỉ đường viền thay đổi. Phần tô và đường viền được tự động áp dụng cho hình học mới.

**Làm sao tôi có thể quay đúng một hình dạng tùy chỉnh cùng với hình học của nó?**

Sử dụng thuộc tính [Rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/) của hình; hình học sẽ quay cùng với hình vì nó được gắn vào hệ tọa độ riêng của hình.

**Tôi có thể chuyển một hình dạng tùy chỉnh thành ảnh để "khóa" kết quả không?**

Có. Xuất vùng [slide](/slides/vi/net/convert-powerpoint-to-png/) yêu cầu hoặc chính [shape](/slides/vi/net/create-shape-thumbnails/) sang định dạng raster; điều này đơn giản hoá công việc tiếp theo với các hình học phức tạp.