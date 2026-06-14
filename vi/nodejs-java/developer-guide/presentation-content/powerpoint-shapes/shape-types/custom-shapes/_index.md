---
title: Tùy chỉnh các hình dạng trong bài thuyết trình bằng JavaScript
linktitle: Hình dạng tùy chỉnh
type: docs
weight: 20
url: /vi/nodejs-java/custom-shape/
keywords:
- hình dạng tùy chỉnh
- thêm hình dạng
- tạo hình dạng
- thay đổi hình dạng
- hình học hình dạng
- đường dẫn hình học
- điểm trên đường
- điểm chỉnh sửa
- thêm điểm
- xóa điểm
- hoạt động chỉnh sửa
- góc cong
- PowerPoint
- bài thuyết trình
- Node.js
- JavaScript
- Aspose.Slides
description: "Tạo và tùy chỉnh các hình dạng trong bài thuyết trình PowerPoint bằng JavaScript và Aspose.Slides cho Node.js: đường dẫn hình học, góc cong, hình dạng hợp thành."
---
## **Tổng quan**

Bài viết này giải thích cách tùy chỉnh các hình dạng trong bài thuyết trình bằng Aspose.Slides bằng cách chỉnh sửa hình học của hình dạng thông qua các điểm chỉnh sửa và đường dẫn hình học. Nó cho thấy cách làm việc với `GeometryPath` để sửa đổi các hình dạng hiện có, thực hiện các thao tác chỉnh sửa đường cơ bản, thêm hoặc xóa điểm, và áp dụng hình học đã cập nhật trở lại cho một hình dạng.

Nó cũng trình bày cách tạo các hình dạng tùy chỉnh và hợp thành, xây dựng các hình dạng có góc cong, xác định liệu hình học của một hình dạng có đóng không, và chuyển đổi giữa `GeometryPath` và `java.awt.Shape` cho các kịch bản tùy chỉnh hình học bổ sung.

## **Thay đổi Hình dạng bằng Điểm chỉnh sửa**

Xem xét một hình vuông. Trong PowerPoint, sử dụng **điểm chỉnh sửa**, bạn có thể 

* di chuyển góc của hình vuông vào hoặc ra
* xác định độ cong cho một góc hoặc điểm
* thêm các điểm mới vào hình vuông
* thao tác các điểm trên hình vuông, v.v. 

Về cơ bản, bạn có thể thực hiện các nhiệm vụ đã mô tả trên bất kỳ hình dạng nào. Sử dụng điểm chỉnh sửa, bạn có thể thay đổi một hình dạng hoặc tạo một hình dạng mới từ một hình dạng hiện có. 

## **Mẹo chỉnh sửa hình dạng**

![overview_image](custom_shape_0.png)

Trước khi bắt đầu chỉnh sửa các hình dạng PowerPoint thông qua điểm chỉnh sửa, bạn có thể muốn xem xét các điểm sau về hình dạng:

* Một hình dạng (hoặc đường dẫn của nó) có thể là đóng hoặc mở.
* Khi một hình dạng đóng, nó không có điểm bắt đầu hay kết thúc. Khi một hình dạng mở, nó có điểm đầu và điểm cuối. 
* Tất cả các hình dạng bao gồm ít nhất 2 điểm neo được liên kết với nhau bằng các đường thẳng.
* Một đường thẳng có thể là thẳng hoặc cong. Các điểm neo quyết định tính chất của đường.
* Các điểm neo tồn tại dưới dạng điểm góc, điểm thẳng, hoặc điểm mượt:
  * Điểm góc là điểm mà 2 đường thẳng gặp nhau tạo thành một góc. 
  * Điểm mượt là điểm mà 2 tay cầm nằm trên một đường thẳng và các đoạn đường của đường thẳng nối liền nhau thành một đường cong mượt. Trong trường hợp này, tất cả các tay cầm cách điểm neo một khoảng cách đều nhau. 
  * Điểm thẳng là điểm mà 2 tay cầm nằm trên một đường thẳng và các đoạn đường của nó nối liền nhau thành một đường cong mượt. Trong trường hợp này, các tay cầm không nhất thiết phải cách điểm neo một khoảng cách đều nhau. 
* Bằng cách di chuyển hoặc chỉnh sửa các điểm neo (điều này thay đổi góc của các đường), bạn có thể thay đổi cách hình dạng hiển thị. 

Để chỉnh sửa các hình dạng PowerPoint thông qua điểm chỉnh sửa, **Aspose.Slides** cung cấp lớp [**GeometryPath**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/GeometryPath) và lớp [**GeometryPath**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/GeometryPath).

* Một đối tượng [GeometryPath](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/GeometryPath) đại diện cho đường dẫn hình học của đối tượng [GeometryShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/GeometryShape).
* Để lấy `GeometryPath` từ thể hiện `GeometryShape`, bạn có thể sử dụng phương pháp [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/GeometryShape#getGeometryPaths--).
* Để đặt `GeometryPath` cho một hình dạng, bạn có thể sử dụng các phương pháp: [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/GeometryShape#setGeometryPath-aspose.slides.IGeometryPath-) cho *hình dạng rắn* và [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/GeometryShape#setGeometryPaths-aspose.slides.IGeometryPath:A-) cho *hình dạng hợp thành*.
* Để thêm các đoạn, bạn có thể sử dụng các phương pháp dưới lớp [GeometryPath](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/GeometryPath).
* Sử dụng các phương pháp [GeometryPath.setStroke](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/GeometryPath#setStroke-boolean-) và [GeometryPath.setFillMode](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/GeometryPath#setFillMode-byte-), bạn có thể đặt kiểu hiển thị cho một đường dẫn hình học.
* Sử dụng phương pháp [GeometryPath.getPathData](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/GeometryPath#getPathData--) , bạn có thể lấy đường dẫn hình học của `GeometryShape` dưới dạng một mảng các đoạn đường.
* Để truy cập các tùy chọn tùy chỉnh hình học bổ sung, bạn có thể chuyển đổi [GeometryPath](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/GeometryPath) sang [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html)
* Sử dụng các phương pháp [geometryPathToGraphicsPath](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ShapeUtil#geometryPathToGraphicsPath-aspose.slides.IGeometryPath-) và [graphicsPathToGeometryPath](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ShapeUtil#graphicsPathToGeometryPath-java.awt.Shape-) (từ lớp [ShapeUtil](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ShapeUtil)) để chuyển đổi [GeometryPath](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/GeometryPath) sang [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) và ngược lại.

## **Các thao tác chỉnh sửa đơn giản**

Mã JavaScript này cho bạn thấy cách

**Thêm một đường** vào cuối một đường dẫn

```javascript
lineTo(point);
lineTo(x, y);
```
**Thêm một đường** vào một vị trí chỉ định trên đường dẫn:

```javascript
lineTo(point, index);
lineTo(x, y, index);
```
**Thêm một đường cong Bezier bậc ba** vào cuối một đường dẫn:

```javascript
cubicBezierTo(point1, point2, point3);
cubicBezierTo(x1, y1, x2, y2, x3, y3);
```
**Thêm một đường cong Bezier bậc ba** vào vị trí chỉ định trên đường dẫn:

```javascript
cubicBezierTo(point1, point2, point3);
cubicBezierTo(x1, y1, x2, y2, x3, y3);
```
**Thêm một đường cong Bezier bậc hai** vào cuối một đường dẫn:

```javascript
quadraticBezierTo(point1, point2);
quadraticBezierTo(x1, y1, x2, y2);
```
**Thêm một đường cong Bezier bậc hai** vào vị trí chỉ định trên đường dẫn:

```javascript
quadraticBezierTo(point1, point2, index);
quadraticBezierTo(x1, y1, x2, y2, index);
```
**Gắn một cung đã cho** vào một đường dẫn:

```javascript
arcTo(width, heigth, startAngle, sweepAngle);
```
**Đóng hình hiện tại** của một đường dẫn:

```javascript
closeFigure();
```
**Đặt vị trí cho điểm tiếp theo**:

```javascript
moveTo(point);
moveTo(x, y);
```
**Xóa đoạn đường** tại một chỉ mục cho trước:

```javascript
removeAt(index);
```

## **Thêm các điểm tùy chỉnh vào hình dạng**
1. Tạo một thể hiện của lớp [GeometryShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/GeometryShape) và đặt loại [ShapeType.Rectangle](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ShapeType).
2. Lấy một thể hiện của lớp [GeometryPath](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/GeometryPath) từ hình dạng.
3. Thêm một điểm mới giữa hai điểm trên cùng của đường dẫn.
4. Thêm một điểm mới giữa hai điểm ở phía dưới của đường dẫn.
5. Áp dụng đường dẫn cho hình dạng.

Mã JavaScript này cho bạn thấy cách thêm các điểm tùy chỉnh vào một hình dạng:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 200, 100);
    var geometryPath = shape.getGeometryPaths()[0];
    geometryPath.lineTo(100, 50, 1);
    geometryPath.lineTo(100, 50, 4);
    shape.setGeometryPath(geometryPath);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
![example1_image](custom_shape_1.png)

## **Xóa các điểm khỏi hình dạng**

1. Tạo một thể hiện của lớp [GeometryShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/GeometryShape) và đặt loại [ShapeType.Heart](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ShapeType).
2. Lấy một thể hiện của lớp [GeometryPath](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/GeometryPath) từ hình dạng.
3. Xóa đoạn cho đường dẫn.
4. Áp dụng đường dẫn cho hình dạng.

Mã JavaScript này cho bạn thấy cách xóa các điểm khỏi một hình dạng:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Heart, 100, 100, 300, 300);
    var path = shape.getGeometryPaths()[0];
    path.removeAt(2);
    shape.setGeometryPath(path);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
![example2_image](custom_shape_2.png)

## **Tạo hình dạng tùy chỉnh**

1. Tính toán các điểm cho hình dạng.
2. Tạo một thể hiện của lớp [GeometryPath](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/GeometryPath).
3. Điền các điểm vào đường dẫn.
4. Tạo một thể hiện của lớp [GeometryShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/GeometryShape).
5. Áp dụng đường dẫn cho hình dạng.

Mã JavaScript này cho bạn thấy cách tạo một hình dạng tùy chỉnh:

```javascript
var points = java.newInstanceSync("java.util.ArrayList");
var R = 100;
var r = 50;
var step = 72;
for (var angle = -90; angle < 270; angle += step) {
    var radians = angle * (java.getStaticFieldValue("java.lang.Math", "PI") / 180.0);
    var x = R * java.callStaticMethodSync("java.lang.Math", "cos", radians);
    var y = R * java.callStaticMethodSync("java.lang.Math", "sin", radians);
    points.add(java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(x + R), java.newFloat(y + R)));
    radians = (java.getStaticFieldValue("java.lang.Math", "PI") * (angle + (step / 2))) / 180.0;
    x = r * java.callStaticMethodSync("java.lang.Math", "cos", radians);
    y = r * java.callStaticMethodSync("java.lang.Math", "sin", radians);
    points.add(java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(x + R), java.newFloat(y + R)));
}
var starPath = new aspose.slides.GeometryPath();
starPath.moveTo(points.get(0));
for (var i = 1; i < points.size(); i++) {
    starPath.lineTo(points.get(i));
}
starPath.closeFigure();
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, R * 2, R * 2);
    shape.setGeometryPath(starPath);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
![example3_image](custom_shape_3.png)


## **Tạo Hình dạng Hợp thành Tùy chỉnh**

  1. Tạo một thể hiện của lớp [GeometryShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/GeometryShape).
  2. Tạo một thể hiện đầu tiên của lớp [GeometryPath](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/GeometryPath).
  3. Tạo một thể hiện thứ hai của lớp [GeometryPath](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/GeometryPath).
  4. Áp dụng các đường dẫn cho hình dạng.

Mã JavaScript này cho bạn thấy cách tạo một hình dạng hợp thành tùy chỉnh:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 200, 100);
    var geometryPath0 = new aspose.slides.GeometryPath();
    geometryPath0.moveTo(0, 0);
    geometryPath0.lineTo(shape.getWidth(), 0);
    geometryPath0.lineTo(shape.getWidth(), shape.getHeight() / 3);
    geometryPath0.lineTo(0, shape.getHeight() / 3);
    geometryPath0.closeFigure();
    var geometryPath1 = new aspose.slides.GeometryPath();
    geometryPath1.moveTo(0, (shape.getHeight() / 3) * 2);
    geometryPath1.lineTo(shape.getWidth(), (shape.getHeight() / 3) * 2);
    geometryPath1.lineTo(shape.getWidth(), shape.getHeight());
    geometryPath1.lineTo(0, shape.getHeight());
    geometryPath1.closeFigure();
    shape.setGeometryPaths(java.newArray("com.aspose.slides.GeometryPath",[geometryPath0, geometryPath1]));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
![example4_image](custom_shape_4.png)

## **Tạo Hình dạng Tùy chỉnh Với Các Góc Cong**

Mã JavaScript này cho bạn thấy cách tạo một hình dạng tùy chỉnh với các góc cong (hướng vào trong);

```javascript
var shapeX = 20.0;
var shapeY = 20.0;
var shapeWidth = 300.0;
var shapeHeight = 200.0;
var leftTopSize = 50.0;
var rightTopSize = 20.0;
var rightBottomSize = 40.0;
var leftBottomSize = 10.0;
var pres = new aspose.slides.Presentation();
try {
    var childShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);
    var geometryPath = new aspose.slides.GeometryPath();
    var point1 = java.newInstanceSync("com.aspose.slides.Point2DFloat", leftTopSize, 0);
    var point2 = java.newInstanceSync("com.aspose.slides.Point2DFloat", shapeWidth - rightTopSize, 0);
    var point3 = java.newInstanceSync("com.aspose.slides.Point2DFloat", shapeWidth, shapeHeight - rightBottomSize);
    var point4 = java.newInstanceSync("com.aspose.slides.Point2DFloat", leftBottomSize, shapeHeight);
    var point5 = java.newInstanceSync("com.aspose.slides.Point2DFloat", 0, leftTopSize);
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
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Xác định xem hình học của một hình dạng có đóng không**

Một hình dạng đóng được định nghĩa là hình dạng mà tất cả các cạnh của nó nối liền nhau, tạo thành một ranh giới duy nhất không có khoảng trống. Hình dạng như vậy có thể là một dạng hình học đơn giản hoặc một đường viền tùy chỉnh phức tạp. Đoạn mã sau đây minh họa cách kiểm tra xem hình học của một hình dạng có đóng hay không:

```java
function isGeometryClosed(geometryShape) 
{
    let isClosed = null;

    geometryShape.getGeometryPaths().forEach(geometryPath => {
        const pathData = geometryPath.getPathData();
        const dataLength = pathData.length;

        if (dataLength === 0) return;

        const lastSegment = pathData[dataLength - 1];
        isClosed = lastSegment.getPathCommand() === aspose.slides.PathCommandType.Close;

        if (!isClosed) return false;
    });

    return isClosed === true;
}
```

## **Chuyển GeometryPath sang java.awt.Shape** 

1. Tạo một thể hiện của lớp [GeometryShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/GeometryShape).
2. Tạo một thể hiện của lớp [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html).
3. Chuyển đổi thể hiện [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) sang thể hiện [GeometryPath](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/GeometryPath) bằng cách sử dụng [ShapeUtil](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ShapeUtil).
4. Áp dụng các đường dẫn cho hình dạng.

Mã JavaScript—một triển khai của các bước trên—trình bày quá trình chuyển đổi **GeometryPath** sang **GraphicsPath**:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Tạo hình dạng mới
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 100);
    // Lấy đường dẫn hình học của hình dạng
    var originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(aspose.slides.PathFillModeType.None);
    // Tạo đường đồ họa mới với văn bản
    var graphicsPath;
    var font = java.newInstanceSync("java.awt.Font", "Arial", java.getStaticFieldValue("java.awt.Font", "PLAIN"), 40);
    var text = "Text in shape";
    var img = java.newInstanceSync("BufferedImage", 100, 100, java.getStaticFieldValue("BufferedImage", "TYPE_INT_ARGB"));
    var g2 = img.createGraphics();
    try {
        var glyphVector = font.createGlyphVector(g2.getFontRenderContext(), text);
        graphicsPath = glyphVector.getOutline(20.0, -glyphVector.getVisualBounds().getY() + 10);
    } finally {
        g2.dispose();
    }
    // Chuyển đổi đường đồ họa thành đường hình học
    var textPath = aspose.slides.ShapeUtil.graphicsPathToGeometryPath(graphicsPath);
    textPath.setFillMode(aspose.slides.PathFillModeType.Normal);
    // Đặt sự kết hợp của đường hình học mới và đường hình học gốc cho hình dạng
    shape.setGeometryPaths(java.newArray("com.aspose.slides.IGeometryPath", [originalPath, textPath]));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
![example5_image](custom_shape_5.png)

## **FAQ**

**Điều gì sẽ xảy ra với phần nền và viền sau khi thay thế hình học?**

Kiểu dáng vẫn giữ cùng hình dạng; chỉ đường viền thay đổi. Phần nền và viền sẽ tự động được áp dụng cho hình học mới.

**Làm thế nào để quay một hình dạng tùy chỉnh cùng với hình học của nó một cách chính xác?**

Sử dụng phương pháp [setRotation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/setrotation/) của hình dạng; hình học sẽ quay cùng với hình dạng vì nó được gắn vào hệ tọa độ của hình dạng đó.

**Tôi có thể chuyển đổi một hình dạng tùy chỉnh thành ảnh để “khóa” kết quả không?**

Có. Xuất vùng [slide](/slides/vi/nodejs-java/convert-powerpoint-to-png/) hoặc [shape](/slides/vi/nodejs-java/create-shape-thumbnails/) cần thiết sang định dạng raster; việc này giúp đơn giản hoá công việc với các hình học phức tạp.