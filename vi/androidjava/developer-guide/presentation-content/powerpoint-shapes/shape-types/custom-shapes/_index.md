---
title: Tùy chỉnh các hình dạng trong bản trình bày trên Android
linktitle: Hình dạng tùy chỉnh
type: docs
weight: 20
url: /vi/androidjava/custom-shape/
keywords:
- hình dạng tùy chỉnh
- thêm hình dạng
- tạo hình dạng
- thay đổi hình dạng
- định dạng hình dạng
- đường dẫn geometry
- các điểm đường dẫn
- điểm chỉnh sửa
- thêm điểm
- xóa điểm
- thao tác chỉnh sửa
- góc cong
- PowerPoint
- bản trình bày
- Android
- Java
- Aspose.Slides
description: "Tạo và tùy chỉnh các hình dạng trong bản trình bày PowerPoint với Aspose.Slides cho Android bằng Java: đường dẫn geometry, các góc cong, hình dạng tổng hợp."
---
## **Tổng quan**

Bài viết này giải thích cách tùy chỉnh các hình dạng trong bản trình bày của Aspose.Slides bằng cách chỉnh sửa geometry của hình dạng thông qua các **điểm chỉnh sửa** và **đường dẫn geometry**. Nó cho thấy cách làm việc với `GeometryPath` và `IGeometryPath` để sửa đổi các hình dạng hiện có, thực hiện các thao tác chỉnh sửa đường dẫn cơ bản, thêm hoặc xóa các điểm, và áp dụng geometry đã cập nhật trở lại cho một hình dạng.

Nó cũng trình bày cách tạo các hình dạng tùy chỉnh và tổng hợp, xây dựng hình dạng với các góc cong, xác định xem geometry của một hình dạng có đóng hay không, và chuyển đổi giữa `GeometryPath` và `java.awt.Shape` cho các kịch bản tùy chỉnh geometry bổ sung.

## **Thay đổi hình dạng bằng Điểm chỉnh sửa**
Xem xét một hình vuông. Trong PowerPoint, sử dụng **điểm chỉnh sửa**, bạn có thể

* di chuyển góc của hình vuông vào trong hoặc ra ngoài
* xác định độ cong cho một góc hoặc một điểm
* thêm các điểm mới vào hình vuông
* thao tác các điểm trên hình vuông, v.v.

Về cơ bản, bạn có thể thực hiện các tác vụ mô tả trên bất kỳ hình dạng nào. Sử dụng điểm chỉnh sửa, bạn có thể thay đổi một hình dạng hoặc tạo một hình dạng mới từ một hình dạng hiện có.

## **Mẹo chỉnh sửa hình dạng**

![overview_image](custom_shape_0.png)

Trước khi bạn bắt đầu chỉnh sửa các hình dạng PowerPoint bằng điểm chỉnh sửa, bạn có thể muốn cân nhắc các điểm sau về hình dạng:

* Một hình dạng (hoặc đường dẫn của nó) có thể là đóng hoặc mở.
* Khi một hình dạng đóng, nó không có điểm bắt đầu hoặc kết thúc. Khi một hình dạng mở, nó có điểm đầu và điểm cuối.
* Tất cả các hình dạng bao gồm ít nhất 2 điểm neo được liên kết với nhau bằng các đoạn thẳng.
* Một đoạn thẳng có thể là thẳng hoặc cong. Các điểm neo quyết định tính chất của đoạn thẳng.
* Các điểm neo tồn tại dưới dạng điểm góc, điểm thẳng hoặc điểm mượt:
  * Điểm góc là điểm mà 2 đoạn thẳng thẳng gặp nhau tạo thành một góc.
  * Điểm mượt là điểm mà 2 tay cầm nằm trên một đường thẳng và các đoạn của đường thẳng nối nhau thành một đường cong mượt. Trong trường hợp này, tất cả các tay cầm được cách điểm neo một khoảng cách bằng nhau.
  * Điểm thẳng là điểm mà 2 tay cầm nằm trên một đường thẳng và các đoạn của đường thẳng nối nhau thành một đường cong mượt. Trong trường hợp này, các tay cầm không cần phải cách điểm neo một khoảng cách bằng nhau.
* Bằng cách di chuyển hoặc chỉnh sửa các điểm neo (điều này thay đổi góc của các đoạn), bạn có thể thay đổi cách hình dạng hiển thị.

Để chỉnh sửa các hình dạng PowerPoint bằng điểm chỉnh sửa, **Aspose.Slides** cung cấp lớp [**GeometryPath**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/GeometryPath) và giao diện [**IGeometryPath**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IGeometryPath).

* Một đối tượng [GeometryPath](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/GeometryPath) đại diện cho đường dẫn geometry của đối tượng [IGeometryShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IGeometryShape).
* Để lấy `GeometryPath` từ đối tượng `IGeometryShape`, bạn có thể sử dụng phương thức [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IGeometryShape#getGeometryPaths--) .
* Để đặt `GeometryPath` cho một hình dạng, bạn có thể sử dụng các phương thức: [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IGeometryShape#setGeometryPath-com.aspose.slides.IGeometryPath-) cho *hình dạng rắn* và [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IGeometryShape#setGeometryPaths-com.aspose.slides.IGeometryPath:A-) cho *hình dạng tổng hợp*.
* Để thêm các đoạn, bạn có thể sử dụng các phương thức dưới [IGeometryPath](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IGeometryPath).
* Sử dụng các phương thức [IGeometryPath.setStroke](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IGeometryPath#setStroke-boolean-) và [IGeometryPath.setFillMode](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IGeometryPath#setFillMode-byte-), bạn có thể thiết lập giao diện cho một đường dẫn geometry.
* Sử dụng phương thức [IGeometryPath.getPathData](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IGeometryPath#getPathData--) , bạn có thể lấy geometry của một `GeometryShape` dưới dạng mảng các đoạn đường.
* Để truy cập các tùy chọn tùy chỉnh geometry bổ sung, bạn có thể chuyển đổi [GeometryPath](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/GeometryPath) sang [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html)
* Sử dụng các phương thức [geometryPathToGraphicsPath](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ShapeUtil#geometryPathToGraphicsPath-com.aspose.slides.IGeometryPath-) và [graphicsPathToGeometryPath](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ShapeUtil#graphicsPathToGeometryPath-java.awt.Shape-) (từ lớp [ShapeUtil](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ShapeUtil)) để chuyển đổi [GeometryPath](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/GeometryPath) sang [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) và ngược lại.

## **Các thao tác chỉnh sửa đơn giản**

Mã Java này cho bạn thấy cách

**Thêm một đường** vào cuối một đường dẫn

``` java
public void lineTo(java.awt.geom.Point2D.Float point);
public void lineTo(float x, float y);
```
**Thêm một đường** vào vị trí xác định trên một đường dẫn:

``` java    
public void lineTo(java.awt.geom.Point2D.Float point, long index);
public void lineTo(float x, float y, long index);
```
**Thêm một đường cong Bezier bậc ba** vào cuối một đường dẫn:

``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```
**Thêm một đường cong Bezier bậc ba** vào vị trí xác định trên một đường dẫn:

``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3, long index);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, long index);
```
**Thêm một đường cong Bezier bậc hai** vào cuối một đường dẫn:

``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2);
public void quadraticBezierTo(float x1, float y1, float x2, float y2);
```
**Thêm một đường cong Bezier bậc hai** vào vị trí xác định trên một đường dẫn:

``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, long index);
public void quadraticBezierTo(float x1, float y1, float x2, float y2, long index);
```
**Gắn một cung** vào một đường dẫn:

``` java
public void arcTo(float width, float heigth, float startAngle, float sweepAngle);
```
**Đóng hình hiện tại** của một đường dẫn:

``` java
public void closeFigure();
```
**Đặt vị trí cho điểm tiếp theo**:

``` java
public void moveTo(java.awt.geom.Point2D.Float point);
public void moveTo(float x, float y);
```
**Xóa đoạn đường** tại một chỉ mục cho trước:

``` java
public void removeAt(int index);
```

## **Thêm các điểm tùy chỉnh vào một hình dạng**
1. Tạo một thể hiện của lớp [GeometryShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/GeometryShape) và đặt loại [ShapeType.Rectangle](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ShapeType).
2. Lấy một thể hiện của lớp [GeometryPath](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/GeometryPath) từ hình dạng.
3. Thêm một điểm mới giữa hai điểm trên cùng của đường dẫn.
4. Thêm một điểm mới giữa hai điểm dưới cùng của đường dẫn.
5. Áp dụng đường dẫn cho hình dạng.

Mã Java này cho bạn thấy cách thêm các điểm tùy chỉnh vào một hình dạng:

``` java
Presentation pres = new Presentation();
try {
    GeometryShape shape = (GeometryShape) pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    IGeometryPath geometryPath = shape.getGeometryPaths()[0];

    geometryPath.lineTo(100, 50, 1);
    geometryPath.lineTo(100, 50, 4);
    shape.setGeometryPath(geometryPath);
} finally {
    if (pres != null) pres.dispose();
}
```
![example1_image](custom_shape_1.png)

## **Xóa các điểm khỏi một hình dạng**

1. Tạo một thể hiện của lớp [GeometryShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/GeometryShape) và đặt loại [ShapeType.Heart](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ShapeType).
2. Lấy một thể hiện của lớp [GeometryPath](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/GeometryPath) từ hình dạng.
3. Xóa đoạn đường cho đường dẫn.
4. Áp dụng đường dẫn cho hình dạng.

Mã Java này cho bạn thấy cách xóa các điểm khỏi một hình dạng:

``` java
Presentation pres = new Presentation();
try {
    GeometryShape shape = (GeometryShape) pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Heart, 100, 100, 300, 300);

    IGeometryPath path = shape.getGeometryPaths()[0];
    path.removeAt(2);
    shape.setGeometryPath(path);
} finally {
    if (pres != null) pres.dispose();
}
```
![example2_image](custom_shape_2.png)

## **Tạo một hình dạng tùy chỉnh**

1. Tính toán các điểm cho hình dạng.
2. Tạo một thể hiện của lớp [GeometryPath](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/GeometryPath).
3. Điền đường dẫn bằng các điểm.
4. Tạo một thể hiện của lớp [GeometryShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/GeometryShape).
5. Áp dụng đường dẫn cho hình dạng.

Mã Java này cho bạn thấy cách tạo một hình dạng tùy chỉnh:

``` java
List<Point2D.Float> points = new ArrayList<Point2D.Float>();

float R = 100, r = 50;
int step = 72;

for (int angle = -90; angle < 270; angle += step)
{
    double radians = angle * (Math.PI / 180f);
    double x = R * Math.cos(radians);
    double y = R * Math.sin(radians);
    points.add(new Point2D.Float((float)x + R, (float)y + R));

    radians = Math.PI * (angle + step / 2) / 180.0;
    x = r * Math.cos(radians);
    y = r * Math.sin(radians);
    points.add(new Point2D.Float((float)x + R, (float)y + R));
}

GeometryPath starPath = new GeometryPath();
starPath.moveTo(points.get(0));

for (int i = 1; i < points.size(); i++)
{
    starPath.lineTo(points.get(i));
}

starPath.closeFigure();

Presentation pres = new Presentation();
try {
    GeometryShape shape = (GeometryShape) pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, R * 2, R * 2);

    shape.setGeometryPath(starPath);
} finally {
    if (pres != null) pres.dispose();
}
```
![example3_image](custom_shape_3.png)


## **Tạo một hình dạng tùy chỉnh tổng hợp**

  1. Tạo một thể hiện của lớp [GeometryShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/GeometryShape).
  2. Tạo một thể hiện đầu tiên của lớp [GeometryPath](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/GeometryPath).
  3. Tạo một thể hiện thứ hai của lớp [GeometryPath](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/GeometryPath).
  4. Áp dụng các đường dẫn cho hình dạng.

Mã Java này cho bạn thấy cách tạo một hình dạng tùy chỉnh tổng hợp:

``` java
Presentation pres = new Presentation();
try {
    GeometryShape shape = (GeometryShape) pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    GeometryPath geometryPath0 = new GeometryPath();
    geometryPath0.moveTo(0, 0);
    geometryPath0.lineTo(shape.getWidth(), 0);
    geometryPath0.lineTo(shape.getWidth(), shape.getHeight()/3);
    geometryPath0.lineTo(0, shape.getHeight() / 3);
    geometryPath0.closeFigure();

    GeometryPath geometryPath1 = new GeometryPath();
    geometryPath1.moveTo(0, shape.getHeight()/3 * 2);
    geometryPath1.lineTo(shape.getWidth(), shape.getHeight() / 3 * 2);
    geometryPath1.lineTo(shape.getWidth(), shape.getHeight());
    geometryPath1.lineTo(0, shape.getHeight());
    geometryPath1.closeFigure();

    shape.setGeometryPaths(new GeometryPath[] { geometryPath0, geometryPath1});
} finally {
    if (pres != null) pres.dispose();
}
```
![example4_image](custom_shape_4.png)

## **Tạo một hình dạng tùy chỉnh với các góc cong**

Mã Java này cho bạn thấy cách tạo một hình dạng tùy chỉnh với các góc cong (hướng vào trong);

```java
float shapeX = 20f;
float shapeY = 20f;
float shapeWidth = 300f;
float shapeHeight = 200f;

float leftTopSize = 50f;
float rightTopSize = 20f;
float rightBottomSize = 40f;
float leftBottomSize = 10f;

Presentation pres = new Presentation();
try {
    IAutoShape childShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(
            ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);

    GeometryPath geometryPath = new GeometryPath();

    Point2D.Float point1 = new Point2D.Float(leftTopSize, 0);
    Point2D.Float point2 = new Point2D.Float(shapeWidth - rightTopSize, 0);
    Point2D.Float point3 = new Point2D.Float(shapeWidth, shapeHeight - rightBottomSize);
    Point2D.Float point4 = new Point2D.Float(leftBottomSize, shapeHeight);
    Point2D.Float point5 = new Point2D.Float(0, leftTopSize);

    geometryPath.moveTo(point1);
    geometryPath.lineTo(point2);
    geometryPath.arcTo(rightTopSize, rightTopSize, 180, -90);
    geometryPath.lineTo(point3);
    geometryPath.arcTo(rightBottomSize, rightBottomSize, -90, -90);
    geometryPath.lineTo(point4);
    geometryPath.arcTo(leftBottomSize, leftBottomSize, 0, -90);
    geometryPath.lineTo(point5);
    geometryPath.arcTo(leftTopSize, leftTopSize, 90, -90);

    geometryPath.closeFigure();

    childShape.setGeometryPath(geometryPath);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres!= null) pres.dispose();
}
```

## **Xác định xem Geometry của một hình dạng có đóng không**

Một hình dạng đóng được định nghĩa là hình dạng mà tất cả các cạnh của nó kết nối với nhau, tạo thành một biên duy nhất không có khoảng trống. Hình dạng như vậy có thể là một hình học đơn giản hoặc một đường viền tùy chỉnh phức tạp. Đoạn mã sau cho thấy cách kiểm tra xem Geometry của một hình dạng có đóng hay không:

```java
boolean isGeometryClosed(IGeometryShape geometryShape)
{
    Boolean isClosed = null;

    for (IGeometryPath geometryPath : geometryShape.getGeometryPaths()) {
        int dataLength = geometryPath.getPathData().length;
        if (dataLength == 0)
            continue;

        IPathSegment lastSegment = geometryPath.getPathData()[dataLength - 1];
        isClosed = lastSegment.getPathCommand() == PathCommandType.Close;

        if (isClosed == false)
            return false;
    }

    return isClosed == true;
}
```

## **Chuyển GeometryPath sang java.awt.Shape** 

1. Tạo một thể hiện của lớp [GeometryShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/GeometryShape).
2. Tạo một thể hiện của lớp [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html).
3. Chuyển đổi thể hiện [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) sang thể hiện [GeometryPath](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/GeometryPath) bằng [ShapeUtil](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ShapeUtil).
4. Áp dụng các đường dẫn cho hình dạng.

Mã Java này—một triển khai của các bước trên—trình bày quá trình chuyển đổi **GeometryPath** sang **GraphicsPath**:

``` java
Presentation pres = new Presentation();
try {
    // Tạo hình dạng mới
    GeometryShape shape = (GeometryShape)pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

    // Lấy đường dẫn geometry của hình dạng
    IGeometryPath originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(PathFillModeType.None);

    // Tạo đường đồ họa mới với văn bản
    Shape graphicsPath;
    Font font = new java.awt.Font("Arial", Font.PLAIN, 40);
    String text = "Text in shape";
    BufferedImage img = new BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB);
    Graphics2D g2 = img.createGraphics();

    try
    {
        GlyphVector glyphVector = font.createGlyphVector(g2.getFontRenderContext(), text);
        graphicsPath = glyphVector.getOutline(20f, ((float) -glyphVector.getVisualBounds().getY()) + 10);
    }
    finally {
        g2.dispose();
    }

    // Chuyển đổi đường đồ họa thành đường geometry
    IGeometryPath textPath = ShapeUtil.graphicsPathToGeometryPath(graphicsPath);
    textPath.setFillMode(PathFillModeType.Normal);

    // Thiết lập kết hợp đường geometry mới và đường geometry gốc cho hình dạng
    shape.setGeometryPaths(new IGeometryPath[] { originalPath, textPath });
} finally {
    if (pres != null) pres.dispose();
}
```
![example5_image](custom_shape_5.png)

## **Câu hỏi thường gặp**

**Điều gì sẽ xảy ra với màu nền và viền sau khi thay thế geometry?**

Kiểu vẫn giữ nguyên với hình dạng; chỉ đường viền thay đổi. Màu nền và viền sẽ tự động được áp dụng cho geometry mới.

**Làm thế nào để xoay chính xác một hình dạng tùy chỉnh cùng với geometry của nó?**

Sử dụng phương thức [setRotation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/shape/#setRotation-float-) của hình dạng; geometry sẽ xoay cùng với hình dạng vì nó được gắn vào hệ tọa độ của chính hình dạng đó.

**Tôi có thể chuyển một hình dạng tùy chỉnh sang ảnh để “khóa” kết quả không?**

Có. Xuất vùng [slide](/slides/vi/androidjava/convert-powerpoint-to-png/) hoặc [shape](/slides/vi/androidjava/create-shape-thumbnails/) cần thiết sang định dạng raster; việc này đơn giản hoá quá trình làm việc với các geometry phức tạp.