---
title: Tùy chỉnh hình dạng trình chiếu trong Java
linktitle: Hình dạng tùy chỉnh
type: docs
weight: 20
url: /vi/java/custom-shape/
keywords:
- hình dạng tùy chỉnh
- thêm hình dạng
- tạo hình dạng
- thay đổi hình dạng
- hình học hình dạng
- đường hình học
- điểm đường
- điểm chỉnh sửa
- thêm điểm
- xóa điểm
- hoạt động chỉnh sửa
- góc cong
- PowerPoint
- bài thuyết trình
- Java
- Aspose.Slides
description: "Tạo và tùy chỉnh các hình dạng trong bài thuyết trình PowerPoint với Aspose.Slides cho Java: đường hình học, góc cong, hình dạng ghép."
---
## **Tổng quan**

Bài viết này giải thích cách tùy chỉnh các hình dạng trong bản trình chiếu bằng Aspose.Slides bằng cách chỉnh sửa geometry của hình dạng thông qua các điểm chỉnh sửa và đường geometry. Nó cho thấy cách làm việc với `GeometryPath` và `IGeometryPath` để sửa đổi các hình dạng hiện có, thực hiện các thao tác chỉnh sửa đường cơ bản, thêm hoặc xóa các điểm, và áp dụng geometry đã cập nhật trở lại cho một hình dạng.

Nó cũng minh họa cách tạo các hình dạng tùy chỉnh và phức hợp, xây dựng các hình dạng với góc cong, xác định liệu geometry của một hình dạng có đóng hay không, và chuyển đổi giữa `GeometryPath` và `java.awt.Shape` cho các kịch bản tùy chỉnh geometry bổ sung.

## **Thay đổi một hình dạng bằng các điểm chỉnh sửa**

Xem xét một hình vuông. Trong PowerPoint, bằng cách sử dụng **edit points**, bạn có thể 

* di chuyển góc của hình vuông ra vào
* chỉ định độ cong cho một góc hoặc điểm
* thêm các điểm mới vào hình vuông
* thao tác các điểm trên hình vuông, v.v. 

Về cơ bản, bạn có thể thực hiện các nhiệm vụ đã mô tả trên bất kỳ hình dạng nào. Bằng cách sử dụng các điểm chỉnh sửa, bạn có thể thay đổi một hình dạng hoặc tạo một hình dạng mới từ một hình dạng hiện có. 

## **Mẹo chỉnh sửa hình dạng**

![overview_image](custom_shape_0.png)

Trước khi bắt đầu chỉnh sửa các hình dạng PowerPoint bằng các điểm chỉnh sửa, bạn có thể muốn xem xét các điểm sau về hình dạng:

* Một hình dạng (hoặc đường của nó) có thể là đóng hoặc mở.
* Khi một hình dạng đóng, nó không có điểm bắt đầu hoặc kết thúc. Khi một hình dạng mở, nó có điểm đầu và điểm cuối. 
* Tất cả các hình dạng bao gồm ít nhất 2 điểm neo được liên kết với nhau bằng các đường thẳng.
* Một đường có thể là thẳng hoặc cong. Các điểm neo xác định tính chất của đường. 
* Các điểm neo tồn tại dưới dạng điểm góc, điểm thẳng hoặc điểm mịn:
  * Điểm góc là điểm mà 2 đường thẳng gặp nhau tạo thành một góc. 
  * Điểm mịn là điểm mà 2 tay cầm nằm trên một đường thẳng và các đoạn đường nối nhau thành một đường cong mịn. Trong trường hợp này, tất cả các tay cầm đều cách điểm neo một khoảng cách bằng nhau. 
  * Điểm thẳng là điểm mà 2 tay cầm nằm trên một đường thẳng và các đoạn đường nối nhau thành một đường cong mịn. Trong trường hợp này, các tay cầm không nhất thiết phải cách điểm neo một khoảng cách bằng nhau. 
* Bằng cách di chuyển hoặc chỉnh sửa các điểm neo (điều này thay đổi góc của các đường), bạn có thể thay đổi cách hình dạng hiển thị. 

Để chỉnh sửa các hình dạng PowerPoint bằng các điểm chỉnh sửa, **Aspose.Slides** cung cấp lớp [**GeometryPath**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/GeometryPath) và giao diện [**IGeometryPath**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IGeometryPath). 

* Một đối tượng [GeometryPath](https://reference.aspose.com/slides/vi/java/com.aspose.slides/GeometryPath) đại diện cho đường geometry của đối tượng [IGeometryShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IGeometryShape). 
* Để lấy `GeometryPath` từ đối tượng `IGeometryShape`, bạn có thể sử dụng phương thức [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IGeometryShape#getGeometryPaths--) . 
* Để đặt `GeometryPath` cho một hình dạng, bạn có thể sử dụng các phương thức: [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IGeometryShape#setGeometryPath-com.aspose.slides.IGeometryPath-) cho *hình dạng rắn* và [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IGeometryShape#setGeometryPaths-com.aspose.slides.IGeometryPath:A-) cho *hình dạng phức hợp*.
* Để thêm các đoạn, bạn có thể sử dụng các phương thức dưới [IGeometryPath](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IGeometryPath). 
* Sử dụng các phương thức [IGeometryPath.setStroke](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IGeometryPath#setStroke-boolean-) và [IGeometryPath.setFillMode](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IGeometryPath#setFillMode-byte-), bạn có thể đặt diện mạo cho một đường geometry.
* Sử dụng phương thức [IGeometryPath.getPathData](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IGeometryPath#getPathData--) , bạn có thể lấy đường geometry của một `GeometryShape` dưới dạng mảng các đoạn đường. 
* Để truy cập các tùy chọn tùy chỉnh geometry bổ sung, bạn có thể chuyển đổi [GeometryPath](https://reference.aspose.com/slides/vi/java/com.aspose.slides/GeometryPath) sang [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html)
* Sử dụng các phương thức [geometryPathToGraphicsPath](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ShapeUtil#geometryPathToGraphicsPath-com.aspose.slides.IGeometryPath-) và [graphicsPathToGeometryPath](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ShapeUtil#graphicsPathToGeometryPath-java.awt.Shape-) (từ lớp [ShapeUtil](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ShapeUtil)) để chuyển đổi [GeometryPath](https://reference.aspose.com/slides/vi/java/com.aspose.slides/GeometryPath) sang [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) và ngược lại. 

## **Các thao tác chỉnh sửa đơn giản**

Đoạn mã Java này cho bạn biết cách

**Add a line** to the end of a path

``` java
public void lineTo(java.awt.geom.Point2D.Float point);
public void lineTo(float x, float y);
```
**Add a line** to a specified position on a path:

``` java    
public void lineTo(java.awt.geom.Point2D.Float point, long index);
public void lineTo(float x, float y, long index);
```
**Add a cubic Bezier curve** at the end of a path:

``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```
**Add a cubic Bezier curve** to the specified position on a path:

``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3, long index);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, long index);
```
**Add a quadratic Bezier curve** at the end of a path:

``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2);
public void quadraticBezierTo(float x1, float y1, float x2, float y2);
```
**Add quadratic Bezier curve** to a specified position on a path:

``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, long index);
public void quadraticBezierTo(float x1, float y1, float x2, float y2, long index);
```
**Append a given arc** to a path:

``` java
public void arcTo(float width, float heigth, float startAngle, float sweepAngle);
```
**Close the current figure** of a path:

``` java
public void closeFigure();
```
**Set the position for the next point**:

``` java
public void moveTo(java.awt.geom.Point2D.Float point);
public void moveTo(float x, float y);
```
**Remove the path segment** at a given index:

``` java
public void removeAt(int index);
```

## **Thêm các điểm tùy chỉnh vào một hình dạng**
1. Tạo một thể hiện của lớp [GeometryShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/GeometryShape) và đặt loại [ShapeType.Rectangle](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ShapeType). 
2. Lấy một thể hiện của lớp [GeometryPath](https://reference.aspose.com/slides/vi/java/com.aspose.slides/GeometryPath) từ hình dạng. 
3. Thêm một điểm mới giữa hai điểm trên cùng của đường. 
4. Thêm một điểm mới giữa hai điểm dưới cùng của đường. 
5. Áp dụng đường cho hình dạng. 

Đoạn mã Java này cho bạn biết cách thêm các điểm tùy chỉnh vào một hình dạng:

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

1. Tạo một thể hiện của lớp [GeometryShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/GeometryShape) và đặt loại [ShapeType.Heart](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ShapeType). 
2. Lấy một thể hiện của lớp [GeometryPath](https://reference.aspose.com/slides/vi/java/com.aspose.slides/GeometryPath) từ hình dạng. 
3. Xóa đoạn cho đường. 
4. Áp dụng đường cho hình dạng. 

Đoạn mã Java này cho bạn biết cách xóa các điểm khỏi một hình dạng:

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
2. Tạo một thể hiện của lớp [GeometryPath](https://reference.aspose.com/slides/vi/java/com.aspose.slides/GeometryPath). 
3. Điền các điểm vào đường. 
4. Tạo một thể hiện của lớp [GeometryShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/GeometryShape). 
5. Áp dụng đường cho hình dạng. 

Đoạn mã Java này cho bạn biết cách tạo một hình dạng tùy chỉnh:

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


## **Tạo một hình dạng tùy chỉnh ghép**

  1. Tạo một thể hiện của lớp [GeometryShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/GeometryShape). 
  2. Tạo một thể hiện đầu tiên của lớp [GeometryPath](https://reference.aspose.com/slides/vi/java/com.aspose.slides/GeometryPath). 
  3. Tạo một thể hiện thứ hai của lớp [GeometryPath](https://reference.aspose.com/slides/vi/java/com.aspose.slides/GeometryPath). 
  4. Áp dụng các đường cho hình dạng. 

Đoạn mã Java này cho bạn biết cách tạo một hình dạng tùy chỉnh ghép:

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

## **Tạo một hình dạng tùy chỉnh với góc cong**

Đoạn mã Java này cho bạn biết cách tạo một hình dạng tùy chỉnh với góc cong (ngầm vào trong);

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

## **Xác định xem geometry của một hình dạng có đóng hay không**

Một hình dạng đóng được định nghĩa là hình dạng mà tất cả các mặt của nó kết nối, tạo thành một biên duy nhất không có khoảng trống. Hình dạng này có thể là một hình học đơn giản hoặc một đường viền tùy chỉnh phức tạp. Đoạn mã mẫu dưới đây cho thấy cách kiểm tra xem geometry của một hình dạng có đóng hay không:

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

1. Tạo một thể hiện của lớp [GeometryShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/GeometryShape). 
2. Tạo một thể hiện của lớp [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html). 
3. Chuyển đổi thể hiện [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) sang thể hiện [GeometryPath](https://reference.aspose.com/slides/vi/java/com.aspose.slides/GeometryPath) bằng cách sử dụng [ShapeUtil](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ShapeUtil). 
4. Áp dụng các đường cho hình dạng. 

Đoạn mã Java—một triển khai của các bước trên—trình bày quá trình chuyển đổi **GeometryPath** sang **GraphicsPath**:

``` java
Presentation pres = new Presentation();
try {
    // Tạo hình mới
    GeometryShape shape = (GeometryShape)pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

    // Lấy đường geometry của hình
    IGeometryPath originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(PathFillModeType.None);

    // Tạo đường graphics mới với văn bản
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

    // Chuyển đổi đường graphics thành đường geometry
    IGeometryPath textPath = ShapeUtil.graphicsPathToGeometryPath(graphicsPath);
    textPath.setFillMode(PathFillModeType.Normal);

    // Đặt kết hợp của đường geometry mới và đường geometry gốc cho hình
    shape.setGeometryPaths(new IGeometryPath[] { originalPath, textPath });
} finally {
    if (pres != null) pres.dispose();
}
```
![example5_image](custom_shape_5.png)

## **Câu hỏi thường gặp**

**What will happen to the fill and outline after replacing the geometry?**  
Phong cách vẫn giữ nguyên với hình dạng; chỉ có đường viền thay đổi. Lớp nền và đường viền sẽ tự động áp dụng cho geometry mới.

**How do I correctly rotate a custom shape along with its geometry?**  
Sử dụng phương thức [setRotation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/shape/#setRotation-float-) của hình dạng; geometry sẽ quay cùng với hình dạng vì nó được ràng buộc với hệ tọa độ riêng của hình dạng.

**Can I convert a custom shape to an image to "lock in" the result?**  
Có. Xuất [slide](/slides/vi/java/convert-powerpoint-to-png/) hoặc [shape](/slides/vi/java/create-shape-thumbnails/) cần thiết sang định dạng raster; cách này giúp đơn giản hóa công việc tiếp theo với các geometry phức tạp.