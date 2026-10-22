---
title: Tùy chỉnh hình dạng bản trình chiếu trong .NET
linktitle: Hình dạng tùy chỉnh
type: docs
weight: 20
url: /vi/net/custom-shape/
keywords:
- hình dạng tùy chỉnh
- thêm hình dạng
- tạo hình dạng
- thay đổi hình dạng
- hình học của hình dạng
- đường hình học
- điểm trên đường
- điểm chỉnh sửa
- thêm điểm
- xóa điểm
- hoạt động chỉnh sửa
- góc cong
- PowerPoint
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Tạo và tùy chỉnh các hình dạng trong bản trình chiếu PowerPoint với Aspose.Slides cho .NET: các đường hình học, góc cong, hình dạng hợp thành."
---
## **Tổng quan**

Bài viết này giải thích cách tùy chỉnh các hình dạng trong bản trình chiếu Aspose.Slides bằng cách chỉnh sửa hình học của hình qua các điểm chỉnh sửa và các đường hình học. Nó cho thấy cách làm việc với [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) và [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/) để sửa đổi các hình hiện có, thực hiện các thao tác chỉnh sửa đường cơ bản, thêm hoặc xóa điểm, và áp dụng hình học đã cập nhật trở lại cho một hình dạng.

Nó cũng minh họa cách tạo các hình dạng tùy chỉnh và hợp thành, xây dựng các hình dạng có góc cong, xác định liệu hình học của một hình có đóng không, và sử dụng việc chuyển đổi kế thừa giữa [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) và [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) cho các kịch bản tùy chỉnh hình học bổ sung.

## **Thay đổi một hình bằng các điểm chỉnh sửa**

Trong PowerPoint, bạn có thể sử dụng **Edit Points** để sửa đổi một hình vuông:

* Di chuyển một góc vào trong hoặc ra ngoài.
* Điều chỉnh độ cong tại một điểm.
* Thêm các điểm mới.

Việc chỉnh sửa các điểm cho phép bạn thay đổi đường viền của một hình hoặc sử dụng một hình hiện có làm cơ sở cho một hình mới.

## **Mẹo chỉnh sửa hình dạng**

![overview_image](custom_shape_0.png)

Khi chỉnh sửa các hình dạng PowerPoint, hãy ghi nhớ các khái niệm sau:

* Một hình (hoặc đường của nó) có thể là đóng hoặc mở.
* Đường của một hình bao gồm các điểm neo được kết nối bằng các đoạn.
* Một đoạn có thể thẳng hoặc cong. Các điểm neo và tay điều khiển xác định hình dạng của nó.
* Các điểm neo tồn tại dưới dạng điểm góc, điểm thẳng hoặc điểm mịn:
  * Tại một điểm góc, các đoạn liền kề có thể gặp nhau tại một góc.
  * Tại một điểm mịn, hai tay điều khiển được căn thẳng và cách đều điểm neo một khoảng.
  * Tại một điểm thẳng, hai tay điều khiển được căn thẳng nhưng có thể có khoảng cách khác nhau tới điểm neo.
* Di chuyển các điểm neo hoặc điều chỉnh các tay của chúng sẽ thay đổi đường viền của hình.

Để chỉnh sửa các hình PowerPoint qua các điểm chỉnh sửa, **Aspose.Slides** cung cấp lớp [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) và giao diện [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/).

* Một thể hiện [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) đại diện cho đường hình học của đối tượng [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/).
* Để lấy [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) từ thể hiện [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/), bạn có thể dùng phương thức [IGeometryShape.GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/).
* Để đặt [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) cho một hình, bạn có thể dùng các phương thức: [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) cho các hình có một đường và [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) cho các hình có nhiều đường.
* Để thêm các đoạn, bạn có thể dùng các phương thức dưới [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/).
* Bằng cách sử dụng các thuộc tính [IGeometryPath.Stroke](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/stroke/) và [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/fillmode/), bạn có thể đặt giao diện cho một đường hình học.
* Bằng cách sử dụng thuộc tính [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/), bạn có thể lấy đường hình học của một [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape/) dưới dạng mảng các đoạn đường.
* Trong các phiên bản kế thừa hỗ trợ các phương thức chuyển đổi dưới đây, bạn có thể chuyển đổi [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) sang [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath).
* Sử dụng các phương thức [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/geometrypathtographicspath/) và [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) (từ lớp [ShapeUtil](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/)) để chuyển đổi giữa [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) và [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath).

## **Các thao tác chỉnh sửa đơn giản**

Sử dụng các phương thức sau để chỉnh sửa một đường hình học. Các overload nhận chỉ mục sẽ chèn một đoạn tại vị trí dựa trên chỉ mục không âm trong mảng các đoạn của đường.

| Thao tác | Phương pháp |
| --- | --- |
| Thêm hoặc chèn một đoạn thẳng. | [GeometryPath.LineTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/lineto/) |
| Thêm hoặc chèn một đường cong Bézier bậc ba với hai điểm điều khiển và một điểm cuối. | [GeometryPath.CubicBezierTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/cubicbezierto/) |
| Thêm hoặc chèn một đường cong Bézier bậc hai với một điểm điều khiển và một điểm cuối. | [GeometryPath.QuadraticBezierTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/quadraticbezierto/) |
| Thêm một cung elip với các kích thước và góc đã chỉ định (độ). | [GeometryPath.ArcTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/arcto/) |
| Đóng hình hiện tại bằng cách nối điểm cuối với điểm bắt đầu. | [GeometryPath.CloseFigure](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/closefigure/) |
| Đặt điểm bắt đầu của một hình. | [GeometryPath.MoveTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/moveto/) |
| Xóa một đoạn tại chỉ mục không âm. | [GeometryPath.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/removeat/) |

## **Thêm các điểm tùy chỉnh vào một hình**

Ví dụ này chèn hai điểm vào một hình chữ nhật bằng cách sử dụng [GeometryPath.LineTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/lineto/) và áp dụng đường đã chỉnh sửa với [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/). Các tọa độ là cục bộ đối với hình: cả hai điểm mới đều nằm ở trung tâm, cách bên trái 100 điểm và cách phía trên 50 điểm. Các chỉ mục đoạn 1 và 4 đặt chúng trên các cạnh trên và dưới, kéo các cạnh này vào trong.

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

![example1_image](custom_shape_1.png)

## **Xóa các điểm khỏi một hình**

Ví dụ này thay đổi đường viền dạng trái tim bằng cách xóa đoạn tại chỉ mục không âm 2 với [GeometryPath.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/removeat/). Áp dụng đường đã sửa đổi bằng [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) sẽ cập nhật đường viền của hình.

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Heart, 100, 100, 300, 300);

var path = shape.GetGeometryPaths()[0];
path.RemoveAt(2);

shape.SetGeometryPath(path);
```
![example2_image](custom_shape_2.png)

## **Tạo một hình tùy chỉnh**

Ví dụ này xây dựng một ngôi sao năm cánh bằng [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/). Các bán kính ngoài và trong luân phiên 100 và 50 điểm xác định các đầu nhọn và các rãnh; bước 72 độ tạo ra năm đầu nhọn đều nhau. Đường được đóng bằng [GeometryPath.CloseFigure](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/closefigure/) và áp dụng cho một hình chữ nhật bằng [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/), thay thế đường viền hiện có.

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
![example3_image](custom_shape_3.png)

## **Tạo một hình tùy chỉnh hợp thành**

Ví dụ này định nghĩa hai đối tượng [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) đóng cho phần trên và phần dưới của một hình. Áp dụng cả hai đường bằng [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) tạo ra một hình hợp thành duy nhất với một khoảng trống ở phần giữa.

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
bottomPath.MoveTo(shape.Height / 3 * 2, 0);
bottomPath.LineTo(shape.Width, shape.Height / 3 * 2);
bottomPath.LineTo(shape.Width, shape.Height);
bottomPath.LineTo(0, shape.Height);
bottomPath.CloseFigure();

shape.SetGeometryPaths(new GeometryPath[] { topPath, bottomPath });
```
![example4_image](custom_shape_4.png)

## **Tạo một hình tùy chỉnh với các góc cong**

Ví dụ này kết hợp các đoạn thẳng với [GeometryPath.ArcTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/arcto/) để tạo một hình có các góc cong vào trong. Mỗi kích thước góc đặt chiều rộng và chiều cao của cung tính bằng điểm, và vòng quét -90 độ vẽ một phần tư elip ngược chiều kim đồng hồ. Đường hoàn chỉnh được áp dụng bằng [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/), và bản trình chiếu được lưu ở định dạng PPTX.

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

## **Kiểm tra xem hình học của một hình có đóng không**

Trợ giúp sau đây kiểm tra xem mọi đường hình học không rỗng có kết thúc bằng một đoạn đóng hay không. Nó đọc [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/) và so sánh lệnh đoạn cuối cùng [IPathSegment.PathCommand](https://reference.aspose.com/slides/net/aspose.slides/ipathsegment/pathcommand/) với [PathCommandType.Close](https://reference.aspose.com/slides/net/aspose.slides/pathcommandtype/). Nó trả về false khi không có đường hình học nào không rỗng. Phép kiểm này chỉ xem lệnh cuối của mỗi đường; nó không kiểm tra mọi tiểu hình bên trong một đường. Ví dụ in ra `True` cho một hình chữ nhật.

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

## **Trích xuất và kiểm tra các phần tử của hình**

Sử dụng [IGeometryShape.CreateShapeElements](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/createshapeelements/) để kiểm tra một hình hiện có dưới dạng các phần tử chứa các điểm đường và kiểu điểm. Ép mỗi [IShapeElement](https://reference.aspose.com/slides/net/aspose.slides/ishapeelement/) trả về sang [ShapeElement](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/) để đọc các mảng [PathPoints](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/pathpoints/) và [PathTypes](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/pathtypes/). Biểu diễn này hữu ích cho phân tích đường viền hoặc truyền hình học cho các công cụ vẽ tùy chỉnh.

Ví dụ mở một bản trình chiếu, tìm hình geometry đầu tiên trực tiếp trên slide đầu, và in ra các đoạn đường của nó. Sử dụng một bản trình chiếu chứa một hình có các đoạn thẳng và cong để thấy cả hai loại đầu ra. Nó không tìm kiếm bên trong các nhóm.

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
                i += 2; // Consume both control points and the endpoint.
                break;
        }

        if ((types[i] & 0x80) != 0)
        {
            Console.WriteLine("Close subpath back to its starting point.");
        }
    }
}
```

Các mảng tương ứng theo chỉ mục: `points[i]` là một điểm và `types[i]` mô tả vai trò của nó. Kiểu `0` bắt đầu một hình, và kiểu `1` vẽ một đoạn line từ điểm trước tới điểm hiện tại. Một đoạn Bézier bậc ba bắt đầu từ điểm cuối trước và sử dụng ba mục kiểu `3` liên tiếp: hai điểm điều khiển rồi điểm cuối mới. Vòng lặp tiêu thụ ba mục này cùng nhau và kiểm tra điểm cuối để xác định việc đóng.

Các kiểu điểm cũng chứa các cờ. Mặt nạ với `0x07` để xác định kiểu đoạn, và kiểm tra riêng `0x80` để phát hiện một tiểu đường đóng. Ví dụ, `129` (`0x81`) nghĩa là một điểm cuối line đóng một tiểu đường, và `131` (`0x83`) nghĩa là một điểm cuối Bézier đóng một tiểu đường. So sánh giá trị thô chỉ với `1` hoặc `3` sẽ bỏ lỡ các trường hợp này. Các cờ khác, như dash (`0x10`) và marker (`0x20`), không thay đổi kiểu đoạn cơ bản.

**Tọa độ và biến đổi.** Các điểm được đo bằng điểm (1/72 inch), với trục X tăng sang phải và trục Y tăng xuống. Đối với một hình không nằm trong nhóm, các tọa độ đã trích xuất đã bao gồm vị trí [X](https://reference.aspose.com/slides/net/aspose.slides/shape/x/) và [Y](https://reference.aspose.com/slides/net/aspose.slides/shape/y/) của nó và phản ánh chiều rộng và chiều cao hiện tại. Ví dụ, một hình chữ nhật không xoay ở `(100, 200)` có kích thước `120 × 80` sẽ có giới hạn đường viền `(100, 200)`–`(220, 280)`. Đừng cộng lại vị trí của hình một lần nữa. Trừ X và Y của nó để có được tọa độ tương đối với khung không xoay.

Các điểm đã trích xuất không áp dụng [Rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/) của hình hoặc các lật ngang/dọc. Để tái tạo đường viền hiển thị, hãy áp dụng các biến đổi này quanh trung tâm của hình. Đối với các hình trong nhóm, cũng phải tính tới việc ánh xạ và biến đổi tọa độ của nhóm; đừng giả định rằng các điểm đã trích xuất là tọa độ cuối cùng trên slide hoặc áp dụng một phép dịch hoặc tỷ lệ hai lần nếu chúng đã được phản ánh trong khung con.

**Kiểm tra so với chỉnh sửa.** Các mảng đã trích xuất mô tả đường viền; việc thay đổi chúng sẽ không cập nhật hình gốc. Hãy chọn cách này khi phân tích hoặc mã vẽ của bạn cần các mảng điểm/kiểu. Sử dụng [GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/) khi bạn cần các lệnh hình học trong hệ tọa độ cục bộ của hình hoặc muốn chỉnh sửa hình học. Áp dụng các đường đã chỉnh sửa qua [SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) hoặc [SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/).

## **Chuyển đổi GeometryPath sang GraphicsPath (System.Drawing.Drawing2D)**

Ví dụ sau yêu cầu một assembly Aspose.Slides for .NET kế thừa hỗ trợ [ShapeUtil.GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/), chẳng hạn phiên bản 25.10, và môi trường Windows có `System.Drawing.Common`. Các phương thức chuyển đổi đã bị xóa trong [phiên bản 25.11](https://releases.aspose.com/slides/net/release-notes/2025/aspose-slides-for-net-25-11-release-notes/).

Ví dụ này kết hợp một đường viền hình chữ nhật với văn bản đã chuyển sang hình học. Thuộc tính [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/fillmode/) của đường viền được đặt để tắt việc tô. Một [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) lưu trữ đường viền văn bản, mà [ShapeUtil.GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) chuyển đổi thành một đường hình học đã tô. Áp dụng cả hai đường bằng [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) tạo ra một hình duy nhất chứa hình chữ nhật và văn bản. Để chuyển đổi ngược lại, sử dụng [ShapeUtil.GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/geometrypathtographicspath/).

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
![example5_image](custom_shape_5.png)

## **Câu hỏi thường gặp**

**Điều gì sẽ xảy ra với màu nền và viền sau khi thay thế hình học?**

Kiểu vẫn còn với hình; chỉ đường viền thay đổi. Màu nền và viền sẽ tự động áp dụng cho hình học mới.

**Làm sao tôi có thể xoay đúng một hình tùy chỉnh cùng với hình học của nó?**

Sử dụng thuộc tính [Rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/) của hình; hình học sẽ xoay cùng với hình vì nó được gắn vào hệ tọa độ của hình.

**Tôi có thể chuyển đổi một hình tùy chỉnh thành ảnh để “khóa” kết quả không?**

Có. Xuất khu vực [slide](/slides/vi/net/convert-powerpoint-to-png/) hoặc [shape](/slides/vi/net/create-shape-thumbnails/) cần thiết sang định dạng raster; việc này giúp đơn giản hoá các thao tác tiếp theo với các hình học phức tạp.