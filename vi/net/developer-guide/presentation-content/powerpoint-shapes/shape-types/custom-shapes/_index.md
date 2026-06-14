---
title: Tùy chỉnh hình dạng trong bản trình chiếu bằng .NET
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
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Tạo và tùy chỉnh các hình dạng trong bản trình chiếu PowerPoint với Aspose.Slides cho .NET: các đường hình học, góc cong, hình hợp thành."
---
## **Tổng quan**

Bài viết này giải thích cách tùy chỉnh các hình dạng trong bài thuyết trình bằng Aspose.Slides bằng cách chỉnh sửa hình học của hình qua các điểm chỉnh sửa và đường hình học. Nó cho thấy cách làm việc với `GeometryPath` và `IGeometryPath` để sửa đổi các hình hiện có, thực hiện các thao tác chỉnh sửa đường cơ bản, thêm hoặc xóa điểm, và áp dụng hình học đã cập nhật trở lại cho một hình.

Nó cũng trình bày cách tạo các hình tùy chỉnh và hợp thành, xây dựng các hình có các góc cong, xác định liệu hình học của một hình có đóng không, và chuyển đổi giữa `GeometryPath` và `GraphicsPath` cho các kịch bản tùy chỉnh hình học bổ sung.

## **Thay đổi một hình bằng các điểm chỉnh sửa**

Xem xét một hình vuông. Trong PowerPoint, sử dụng **điểm chỉnh sửa**, bạn có thể 

* di chuyển góc của hình vuông vào trong hoặc ra ngoài  
* chỉ định độ cong cho một góc hoặc một điểm  
* thêm các điểm mới vào hình vuông  
* thao tác các điểm trên hình vuông, v.v.  

Cơ bản, bạn có thể thực hiện các nhiệm vụ đã mô tả trên bất kỳ hình nào. Sử dụng điểm chỉnh sửa, bạn có thể thay đổi một hình hoặc tạo một hình mới từ một hình hiện có. 

## **Mẹo chỉnh sửa hình**

![overview_image](custom_shape_0.png)

Trước khi bắt đầu chỉnh sửa các hình PowerPoint qua các điểm chỉnh sửa, bạn có thể muốn xem xét những điểm sau về các hình:

* Một hình (hoặc đường của nó) có thể là đóng hoặc mở.  
* Tất cả các hình đều gồm ít nhất 2 điểm neo được nối với nhau bằng các đoạn thẳng.  
* Một đoạn thẳng có thể thẳng hoặc cong. Các điểm neo quyết định tính chất của đoạn.  
* Các điểm neo tồn tại dưới dạng điểm góc, điểm thẳng, hoặc điểm mượt:  
  * Điểm góc là điểm mà 2 đoạn thẳng gặp nhau tạo thành một góc.  
  * Điểm mượt là điểm mà 2 tay cầm tồn tại trên một đường thẳng và các đoạn của đường nối nhau thành một đường cong mượt. Trong trường hợp này, tất cả các tay cầm được tách đều một khoảng cách bằng nhau so với điểm neo.  
  * Điểm thẳng là điểm mà 2 tay cầm tồn tại trên một đường thẳng và các đoạn của đường nối nhau thành một đường cong mượt. Trong trường hợp này, các tay cầm không cần phải tách đều một khoảng cách bằng nhau so với điểm neo.  
* Bằng cách di chuyển hoặc chỉnh sửa các điểm neo (điều này thay đổi góc của các đoạn), bạn có thể thay đổi cách hình hiển thị.  

Để chỉnh sửa các hình PowerPoint qua các điểm chỉnh sửa, **Aspose.Slides** cung cấp lớp [**GeometryPath**](https://reference.aspose.com/slides/vi/net/aspose.slides/geometrypath) và giao diện [**IGeometryPath**](https://reference.aspose.com/slides/vi/net/aspose.slides/igeometrypath).  

* Một đối tượng [GeometryPath](https://reference.aspose.com/slides/vi/net/aspose.slides/geometrypath) biểu diễn một đường hình học của đối tượng [IGeometryShape](https://reference.aspose.com/slides/vi/net/aspose.slides/igeometryshape).  
* Để lấy `GeometryPath` từ thể hiện `IGeometryShape`, bạn có thể sử dụng phương thức [IGeometryShape.GetGeometryPaths](https://reference.aspose.com/slides/vi/net/aspose.slides/igeometryshape/methods/getgeometrypaths).  
* Để đặt `GeometryPath` cho một hình, bạn có thể dùng các phương thức: [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/vi/net/aspose.slides/igeometryshape/methods/setgeometrypath) cho *hình rắn* và [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/vi/net/aspose.slides/igeometryshape/methods/setgeometrypaths) cho *hình hợp thành*.  
* Để thêm các đoạn, bạn có thể sử dụng các phương thức dưới [IGeometryPath](https://reference.aspose.com/slides/vi/net/aspose.slides/igeometrypath).  
* Sử dụng các thuộc tính [IGeometryPath.Stroke](https://reference.aspose.com/slides/vi/net/aspose.slides/igeometrypath/properties/stroke) và [IGeometryPath.FillMode](https://reference.aspose.com/slides/vi/net/aspose.slides/igeometrypath/properties/fillmode), bạn có thể đặt kiểu hiển thị cho một đường hình học.  
* Thông qua thuộc tính [IGeometryPath.PathData](https://reference.aspose.com/slides/vi/net/aspose.slides/igeometrypath/properties/pathdata), bạn có thể lấy đường hình học của một `GeometryShape` dưới dạng mảng các đoạn đường.  
* Để truy cập các tùy chọn tùy chỉnh hình học bổ sung, bạn có thể chuyển đổi [GeometryPath](https://reference.aspose.com/slides/vi/net/aspose.slides/geometrypath) sang [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0).  
* Sử dụng các phương thức [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/vi/net/aspose.slides.util/shapeutil/methods/geometrypathtographicspath) và [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/vi/net/aspose.slides.util/shapeutil/methods/graphicspathtogeometrypath) (từ lớp [ShapeUtil](https://reference.aspose.com/slides/vi/net/aspose.slides.util/shapeutil)) để chuyển đổi qua lại giữa [GeometryPath](https://reference.aspose.com/slides/vi/net/aspose.slides/geometrypath) và [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0). 

## **Các thao tác chỉnh sửa đơn giản**

Đoạn mã C# này cho bạn cách  

**Thêm một đoạn** vào cuối một đường  

``` csharp
void LineTo(PointF point);
void LineTo(float x, float y);
```
**Thêm một đoạn** vào một vị trí xác định trên đường:  

``` csharp    
void LineTo(PointF point, uint index);
void LineTo(float x, float y, uint index);
```
**Thêm một đường cong Bezier bậc ba** vào cuối một đường:  

``` csharp
void CubicBezierTo(PointF point1, PointF point2, PointF point3);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```
**Thêm một đường cong Bezier bậc ba** vào vị trí xác định trên đường:  

``` csharp
void CubicBezierTo(PointF point1, PointF point2, PointF point3, uint index);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, uint index);
```
**Thêm một đường cong Bezier bậc hai** vào cuối một đường:  

``` csharp
void QuadraticBezierTo(PointF point1, PointF point2);
void QuadraticBezierTo(float x1, float y1, float x2, float y2);
```
**Thêm một đường cong Bezier bậc hai** vào vị trí xác định trên đường:  

``` csharp
void QuadraticBezierTo(PointF point1, PointF point2, uint index);
void QuadraticBezierTo(float x1, float y1, float x2, float y2, uint index);
```
**Nối một cung đã cho** vào một đường:  

``` csharp
void ArcTo(float width, float heigth, float startAngle, float sweepAngle);
```
**Đóng hình hiện tại** của một đường:  

``` csharp
void CloseFigure();
```
**Đặt vị trí cho điểm tiếp theo**:  

``` csharp
void MoveTo(PointF point);
void MoveTo(float x, float y);
```
**Xóa đoạn đường** tại một chỉ mục cho trước:  

``` csharp
void RemoveAt(int index);
```

## **Thêm các điểm tùy chỉnh vào một hình**

1. Tạo một thể hiện của lớp [GeometryShape](https://reference.aspose.com/slides/vi/net/aspose.slides/geometryshape) và đặt kiểu [ShapeType.Rectangle](https://reference.aspose.com/slides/vi/net/aspose.slides/shapetype).  
2. Lấy một thể hiện của lớp [GeometryPath](https://reference.aspose.com/slides/vi/net/aspose.slides/geometrypath) từ hình.  
3. Thêm một điểm mới giữa hai điểm trên cùng của đường.  
4. Thêm một điểm mới giữa hai điểm dưới cùng của đường.  
5. Áp dụng đường cho hình.  

Đoạn mã C# này cho bạn cách thêm các điểm tùy chỉnh vào một hình:

``` csharp
using (Presentation pres = new Presentation())
{
    GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100) as GeometryShape;
    IGeometryPath geometryPath = shape.GetGeometryPaths()[0];

    geometryPath.LineTo(100, 50, 1);
    geometryPath.LineTo(100, 50, 4);
    shape.SetGeometryPath(geometryPath);
}
```

![example1_image](custom_shape_1.png)

## **Xóa các điểm khỏi một hình**

1. Tạo một thể hiện của lớp [GeometryShape](https://reference.aspose.com/slides/vi/net/aspose.slides/geometryshape) và đặt kiểu [ShapeType.Heart](https://reference.aspose.com/slides/vi/net/aspose.slides/shapetype).  
2. Lấy một thể hiện của lớp [GeometryPath](https://reference.aspose.com/slides/vi/net/aspose.slides/geometrypath) từ hình.  
3. Xóa đoạn cho đường.  
4. Áp dụng đường cho hình.  

Đoạn mã C# này cho bạn cách xóa các điểm khỏi một hình:

``` csharp
using (Presentation pres = new Presentation())
{
	GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Heart, 100, 100, 300, 300) as GeometryShape;

	IGeometryPath path = shape.GetGeometryPaths()[0];
	path.RemoveAt(2);
	shape.SetGeometryPath(path);
}
```
![example2_image](custom_shape_2.png)

## **Tạo một hình tùy chỉnh**

1. Tính toán các điểm cho hình.  
2. Tạo một thể hiện của lớp [GeometryPath](https://reference.aspose.com/slides/vi/net/aspose.slides/geometrypath).  
3. Điền các điểm vào đường.  
4. Tạo một thể hiện của lớp [GeometryShape](https://reference.aspose.com/slides/vi/net/aspose.slides/geometryshape).  
5. Áp dụng đường cho hình.  

Đoạn mã C# này cho bạn cách tạo một hình tùy chỉnh:

``` csharp
List<PointF> points = new List<PointF>();

float R = 100, r = 50;
int step = 72;

for (int angle = -90; angle < 270; angle += step)
{
    double radians = angle * (Math.PI / 180f);
    double x = R * Math.Cos(radians);
    double y = R * Math.Sin(radians);
    points.Add(new PointF((float)x + R, (float)y + R));

    radians = Math.PI * (angle + step / 2) / 180.0;
    x = r * Math.Cos(radians);
    y = r * Math.Sin(radians);
    points.Add(new PointF((float)x + R, (float)y + R));
}

GeometryPath starPath = new GeometryPath();
starPath.MoveTo(points[0]);

for (int i = 1; i < points.Count; i++)
{
    starPath.LineTo(points[i]);
}

starPath.CloseFigure();

using (Presentation pres = new Presentation())
{
    GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, R * 2, R * 2) as GeometryShape;

    shape.SetGeometryPath(starPath);
}
```
![example3_image](custom_shape_3.png)

## **Tạo một hình tùy chỉnh hợp thành**

  1. Tạo một thể hiện của lớp [GeometryShape](https://reference.aspose.com/slides/vi/net/aspose.slides/geometryshape).  
  2. Tạo một thể hiện đầu tiên của lớp [GeometryPath](https://reference.aspose.com/slides/vi/net/aspose.slides/geometrypath).  
  3. Tạo một thể hiện thứ hai của lớp [GeometryPath](https://reference.aspose.com/slides/vi/net/aspose.slides/geometrypath).  
  4. Áp dụng các đường cho hình.  

Đoạn mã C# này cho bạn cách tạo một hình tùy chỉnh hợp thành:

``` csharp
using (Presentation pres = new Presentation())
{
    GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100) as GeometryShape;

    GeometryPath geometryPath0 = new GeometryPath();
    geometryPath0.MoveTo(0, 0);
    geometryPath0.LineTo(shape.Width, 0);
    geometryPath0.LineTo(shape.Width, shape.Height/3);
    geometryPath0.LineTo(0, shape.Height / 3);
    geometryPath0.CloseFigure();

    GeometryPath geometryPath1 = new GeometryPath();
    geometryPath1.MoveTo(0, shape.Height/3 * 2);
    geometryPath1.LineTo(shape.Width, shape.Height / 3 * 2);
    geometryPath1.LineTo(shape.Width, shape.Height);
    geometryPath1.LineTo(0, shape.Height);
    geometryPath1.CloseFigure();

    shape.SetGeometryPaths(new GeometryPath[] { geometryPath0, geometryPath1});
}
```
![example4_image](custom_shape_4.png)

## **Tạo một hình tùy chỉnh với các góc cong**

Đoạn mã C# này cho bạn cách tạo một hình tùy chỉnh với các góc cong (hướng vào trong);  

```c#
var shapeX = 20f;
var shapeY = 20f;
var shapeWidth = 300f;
var shapeHeight = 200f;

var leftTopSize = 50f;
var rightTopSize = 20f;
var rightBottomSize = 40f;
var leftBottomSize = 10f;

using (var presentation = new Presentation())
{
    var childShape = presentation.Slides[0].Shapes.AddAutoShape(
        ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);

    var geometryPath = new GeometryPath();

    var point1 = new PointF(leftTopSize, 0);
    var point2 = new PointF(shapeWidth - rightTopSize, 0);
    var point3 = new PointF(shapeWidth, shapeHeight - rightBottomSize);
    var point4 = new PointF(leftBottomSize, shapeHeight);
    var point5 = new PointF(0, leftTopSize);

    geometryPath.MoveTo(point1);
    geometryPath.LineTo(point2);
    geometryPath.ArcTo(rightTopSize, rightTopSize, 180, -90);
    geometryPath.LineTo(point3);
    geometryPath.ArcTo(rightBottomSize, rightBottomSize, -90, -90);
    geometryPath.LineTo(point4);
    geometryPath.ArcTo(leftBottomSize, leftBottomSize, 0, -90);
    geometryPath.LineTo(point5);
    geometryPath.ArcTo(leftTopSize, leftTopSize, 90, -90);

    geometryPath.CloseFigure();

    childShape.SetGeometryPath(geometryPath);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Xác định xem hình học của một hình có đóng không**

Một hình đóng được định nghĩa là hình mà tất cả các cạnh của nó nối liền, tạo thành một ranh giới duy nhất không có khoảng trống. Hình như vậy có thể là một hình dạng hình học đơn giản hoặc một đường viền tùy chỉnh phức tạp. Đoạn mã sau đây cho thấy cách kiểm tra xem hình học của một hình có đóng không:

```cs
bool IsGeometryClosed(IGeometryShape geometryShape)
{
    bool? isClosed = null;

    foreach (var geometryPath in geometryShape.GetGeometryPaths())
    {
        var dataLength = geometryPath.PathData.Length;
        if (dataLength == 0)
            continue;

        var lastSegment = geometryPath.PathData[dataLength - 1];
        isClosed = lastSegment.PathCommand == PathCommandType.Close;

        if (isClosed == false)
            return false;
    }
    
    return isClosed == true;
}
```

## **Chuyển đổi GeometryPath sang GraphicsPath (System.Drawing.Drawing2D)**

1. Tạo một thể hiện của lớp [GeometryShape](https://reference.aspose.com/slides/vi/net/aspose.slides/geometryshape).  
2. Tạo một thể hiện của lớp [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0) thuộc không gian tên [System.Drawing.Drawing2D](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0).  
3. Chuyển đổi thể hiện [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0) sang thể hiện [GeometryPath](https://reference.aspose.com/slides/vi/net/aspose.slides/geometrypath) bằng cách sử dụng [ShapeUtil](https://reference.aspose.com/slides/vi/net/aspose.slides.util/shapeutil).  
4. Áp dụng các đường cho hình.  

Đoạn mã C#—một triển khai của các bước trên—trình bày quá trình chuyển đổi **GeometryPath** sang **GraphicsPath**:

``` csharp
using (Presentation pres = new Presentation())
{
    GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 100) as GeometryShape;

    IGeometryPath originalPath = shape.GetGeometryPaths()[0];
    originalPath.FillMode = PathFillModeType.None;

    GraphicsPath gPath = new GraphicsPath();

    gPath.AddString("Text in shape", new FontFamily("Arial"), 1, 40, new PointF(10, 10), StringFormat.GenericDefault);

    IGeometryPath textPath = ShapeUtil.GraphicsPathToGeometryPath(gPath);
    textPath.FillMode = PathFillModeType.Normal;

    shape.SetGeometryPaths(new[] {originalPath, textPath}) ;
}
```
![example5_image](custom_shape_5.png)

## **Câu hỏi thường gặp**

**Điều gì sẽ xảy ra với màu nền và viền sau khi thay thế hình học?**

Kiểu dáng vẫn được giữ nguyên trên hình; chỉ đường viền thay đổi. Màu nền và viền sẽ tự động áp dụng cho hình học mới.

**Làm thế nào để quay đúng một hình tùy chỉnh cùng với hình học của nó?**

Sử dụng thuộc tính [rotation](https://reference.aspose.com/slides/vi/net/aspose.slides/shape/rotation/) của hình; hình học sẽ quay cùng với hình vì nó được liên kết với hệ tọa độ của hình.

**Tôi có thể chuyển đổi một hình tùy chỉnh thành hình ảnh để “khóa” kết quả không?**

Có. Xuất khu vực [slide](/slides/vi/net/convert-powerpoint-to-png/) yêu cầu hoặc [shape](/slides/vi/net/create-shape-thumbnails/) sang định dạng raster; việc này giúp đơn giản hoá công việc tiếp theo với các hình học phức tạp.