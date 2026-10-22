---
title: Tùy chỉnh các hình dạng trong bản trình chiếu bằng Java
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
- bản trình chiếu
- Java
- Aspose.Slides
description: "Tạo và tùy chỉnh các hình dạng trong bản trình chiếu PowerPoint với Aspose.Slides cho Java: đường hình học, góc cong, hình ghép nối."
---
## **Tổng quan**

Bài viết này giải thích cách tùy chỉnh các hình dạng trong bản trình chiếu của Aspose.Slides bằng cách chỉnh sửa hình học của hình thông qua các điểm chỉnh sửa và đường hình học. Nó cho thấy cách làm việc với [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) và [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/) để sửa đổi các hình hiện có, thực hiện các thao tác chỉnh sửa đường cơ bản, thêm hoặc xóa các điểm, và áp dụng hình học đã cập nhật trở lại cho một hình dạng.

Nó cũng trình diễn cách tạo các hình dạng tùy chỉnh và ghép nối, xây dựng các hình dạng có góc cong, xác định xem hình học của một hình dạng có đóng không, kiểm tra các phần tử hình dạng, và chuyển đổi các đường viền văn bản Java AWT thành các đường hình học.

## **Thay đổi một Hình Dạng Bằng Điểm Chỉnh Sửa**

Trong PowerPoint, bạn có thể sử dụng **Edit Points** để sửa đổi một hình vuông:

* Di chuyển một góc vào trong hoặc ra ngoài.
* Điều chỉnh độ cong tại một điểm.
* Thêm các điểm mới.

Việc chỉnh sửa các điểm cho phép bạn thay đổi đường viền của một hình dạng hoặc sử dụng một hình dạng hiện có làm cơ sở cho một hình mới.

## **Mẹo Chỉnh Sửa Hình Dạng**

![overview_image](custom_shape_0.png)

Khi chỉnh sửa các hình dạng PowerPoint, hãy ghi nhớ các khái niệm sau:

* Một hình dạng (hoặc đường của nó) có thể là đóng hoặc mở.
* Đường của một hình dạng bao gồm các điểm neo được kết nối bằng các đoạn.
* Một đoạn có thể thẳng hoặc cong. Các điểm neo và tay điều khiển xác định hình dạng của nó.
* Các điểm neo tồn tại dưới dạng điểm góc, điểm thẳng, hoặc điểm trơn:
  * Tại một điểm góc, các đoạn liền kề có thể gặp nhau ở một góc.
  * Tại một điểm trơn, hai tay điều khiển được căn chỉnh và cách điểm neo cùng một khoảng cách.
  * Tại một điểm thẳng, hai tay điều khiển được căn chỉnh nhưng có thể có khoảng cách khác nhau từ điểm neo.
* Di chuyển các điểm neo hoặc điều chỉnh các tay của chúng sẽ thay đổi đường viền của hình dạng.

Để chỉnh sửa các hình dạng PowerPoint thông qua các điểm chỉnh sửa, **Aspose.Slides** cung cấp lớp [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) và giao diện [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/).

* Một đối tượng [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) đại diện cho đường hình học của đối tượng [IGeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/).
* Để lấy [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) từ thể hiện [IGeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/), bạn có thể sử dụng phương thức [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--) .
* Để đặt [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) cho một hình dạng, bạn có thể sử dụng các phương thức: [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) cho các hình dạng có một đường duy nhất và [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) cho các hình dạng có nhiều đường.
* Để thêm các đoạn, bạn có thể sử dụng các phương thức trong [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/) .
* Bằng cách sử dụng các phương thức [IGeometryPath.setStroke](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setStroke-boolean-) và [IGeometryPath.setFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setFillMode-byte-), bạn có thể đặt giao diện cho một đường hình học.
* Bằng cách sử dụng phương thức [IGeometryPath.getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--) , bạn có thể lấy đường hình học của một [GeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/geometryshape/) dưới dạng mảng các đoạn đường.
* Để truy cập các tùy chọn tùy chỉnh hình học bổ sung, bạn có thể đọc một [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) thông qua [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) và phát lại các đoạn trên một [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) .

## **Các Thao Tác Chỉnh Sửa Cơ Bản**

Sử dụng các phương thức sau để chỉnh sửa một đường hình học. Các phiên bản nhận chỉ số sẽ chèn một đoạn ở vị trí dựa trên chỉ số không-đếm trong mảng các đoạn của đường.

| Thao tác | Phương thức |
| --- | --- |
| Thêm hoặc chèn một đường thẳng. | [GeometryPath.lineTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#lineTo-float-float-) |
| Thêm hoặc chèn một đường cong Bézier bậc ba với hai điểm điều khiển và một điểm cuối. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#cubicBezierTo-float-float-float-float-float-float-) |
| Thêm hoặc chèn một đường cong Bézier bậc hai với một điểm điều khiển và một điểm cuối. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#quadraticBezierTo-float-float-float-float-) |
| Thêm một cung elip với kích thước và góc được chỉ định theo độ. | [GeometryPath.arcTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) |
| Đóng hình hiện tại bằng cách kết nối điểm cuối của nó với điểm bắt đầu. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#closeFigure--) |
| Đặt điểm bắt đầu của một hình. | [GeometryPath.moveTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#moveTo-float-float-) |
| Xóa một đoạn ở chỉ số không-đếm. | [GeometryPath.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#removeAt-int-) |

## **Thêm Các Điểm Tùy Chỉnh Vào Một Hình Dạng**

Ví dụ này chèn hai điểm vào một hình chữ nhật bằng cách sử dụng [GeometryPath.lineTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#lineTo-float-float-) và áp dụng đường đã chỉnh sửa với [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-). Các tọa độ là cục bộ đối với hình dạng: cả hai điểm mới đều nằm ở trung tâm của nó, cách mép trái 100 điểm và cách mép trên 50 điểm. Các chỉ số đoạn 1 và 4 đặt chúng trên các cạnh trên và dưới, kéo các cạnh này vào trong.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    IGeometryPath geometryPath = shape.getGeometryPaths()[0];
    geometryPath.lineTo(100, 50, 1);
    geometryPath.lineTo(100, 50, 4);

    shape.setGeometryPath(geometryPath);
} finally {
    presentation.dispose();
}
```

![example1_image](custom_shape_1.png)

## **Xóa Các Điểm Khỏi Một Hình Dạng**

Ví dụ này thay đổi đường viền dạng trái tim bằng cách xóa đoạn ở chỉ số không-đếm 2 với [GeometryPath.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#removeAt-int-). Áp dụng đường đã sửa đổi bằng [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) sẽ cập nhật đường viền của hình dạng.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Heart, 100, 100, 300, 300);

    IGeometryPath path = shape.getGeometryPaths()[0];
    path.removeAt(2);

    shape.setGeometryPath(path);
} finally {
    presentation.dispose();
}
```
![example2_image](custom_shape_2.png)

## **Tạo Một Hình Dạng Tùy Chỉnh**

Ví dụ này xây dựng một ngôi sao năm cánh bằng [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/). Các bán kính ngoài và trong xen kẽ 100 và 50 điểm xác định các ngọn và các rãnh; bước 72 độ tạo khoảng cách đều cho năm ngọn. Đường được đóng bằng [GeometryPath.closeFigure](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#closeFigure--) và áp dụng cho một hình chữ nhật bằng [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-), thay thế đường viền của nó.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;
import java.util.ArrayList;
import java.util.List;

List<Point2D.Float> points = new ArrayList<>();

float outerRadius = 100f;
float innerRadius = 50f;
int angleStep = 72;

for (int angle = -90; angle < 270; angle += angleStep)
{
    double radians = angle * (Math.PI / 180f);
    double x = outerRadius * Math.cos(radians);
    double y = outerRadius * Math.sin(radians);
    Point2D.Float point = new Point2D.Float((float)x + outerRadius, (float)y + outerRadius);
    points.add(point);

    radians = Math.PI * (angle + angleStep / 2) / 180.0;
    x = innerRadius * Math.cos(radians);
    y = innerRadius * Math.sin(radians);
    point = new Point2D.Float((float)x + outerRadius, (float)y + outerRadius);
    points.add(point);
}

GeometryPath starPath = new GeometryPath();
starPath.moveTo(points.get(0));

for (int i = 1; i < points.size(); i++)
{
    starPath.lineTo(points.get(i));
}

starPath.closeFigure();

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, outerRadius * 2, outerRadius * 2);
    shape.setGeometryPath(starPath);
} finally {
    presentation.dispose();
}
```
![example3_image](custom_shape_3.png)

## **Tạo Một Hình Dạng Ghép Nối Tùy Chỉnh**

Ví dụ này định nghĩa hai đối tượng [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) đóng cho phần trên và phần dưới của một hình dạng. Áp dụng cả hai đường bằng [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) tạo ra một hình dạng ghép nối duy nhất với một khoảng trống ở phần ba giữa.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    GeometryPath topPath = new GeometryPath();
    topPath.moveTo(0, 0);
    topPath.lineTo(shape.getWidth(), 0);
    topPath.lineTo(shape.getWidth(), shape.getHeight() / 3);
    topPath.lineTo(0, shape.getHeight() / 3);
    topPath.closeFigure();

    GeometryPath bottomPath = new GeometryPath();
    bottomPath.moveTo(0, shape.getHeight() / 3 * 2);
    bottomPath.lineTo(shape.getWidth(), shape.getHeight() / 3 * 2);
    bottomPath.lineTo(shape.getWidth(), shape.getHeight());
    bottomPath.lineTo(0, shape.getHeight());
    bottomPath.closeFigure();

    shape.setGeometryPaths(new GeometryPath[] { topPath, bottomPath });
} finally {
    presentation.dispose();
}
```
![example4_image](custom_shape_4.png)

## **Tạo Một Hình Dạng Tùy Chỉnh Với Các Góc Cong**

Ví dụ này kết hợp các đoạn thẳng với [GeometryPath.arcTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) để tạo một hình dạng có các góc cong vào trong. Mỗi kích thước góc đặt chiều rộng và chiều cao của cung bằng điểm, và vòng quét -90 độ vẽ một phần tư elip ngược chiều kim đồng hồ. Đường hoàn chỉnh được áp dụng bằng [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-), và bản trình chiếu được lưu dưới định dạng PPTX.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

float shapeX = 20f;
float shapeY = 20f;
float shapeWidth = 300f;
float shapeHeight = 200f;

float leftTopSize = 50f;
float rightTopSize = 20f;
float rightBottomSize = 40f;
float leftBottomSize = 10f;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);

    Point2D.Float topLeft = new Point2D.Float(leftTopSize, 0);
    Point2D.Float topRight = new Point2D.Float(shapeWidth - rightTopSize, 0);
    Point2D.Float rightBottom = new Point2D.Float(shapeWidth, shapeHeight - rightBottomSize);
    Point2D.Float bottomLeft = new Point2D.Float(leftBottomSize, shapeHeight);
    Point2D.Float leftTop = new Point2D.Float(0, leftTopSize);

    GeometryPath geometryPath = new GeometryPath();
    geometryPath.moveTo(topLeft);
    geometryPath.lineTo(topRight);
    geometryPath.arcTo(rightTopSize, rightTopSize, 180, -90);
    geometryPath.lineTo(rightBottom);
    geometryPath.arcTo(rightBottomSize, rightBottomSize, -90, -90);
    geometryPath.lineTo(bottomLeft);
    geometryPath.arcTo(leftBottomSize, leftBottomSize, 0, -90);
    geometryPath.lineTo(leftTop);
    geometryPath.arcTo(leftTopSize, leftTopSize, 90, -90);
    geometryPath.closeFigure();

    shape.setGeometryPath(geometryPath);

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Kiểm Tra Hình Học Của Một Hình Dạng Có Đóng Không**

Trợ giúp sau đây kiểm tra xem mỗi đường hình học không rỗng có kết thúc bằng một đoạn đóng hay không. Nó đọc [IGeometryPath.getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--) và so sánh lệnh cuối cùng của đoạn với [IPathSegment.getPathCommand](https://reference.aspose.com/slides/java/com.aspose.slides/ipathsegment/#getPathCommand--) so với [PathCommandType.Close](https://reference.aspose.com/slides/java/com.aspose.slides/pathcommandtype/). Nó trả về false khi không có đường nào không rỗng. Kiểm tra này chỉ xem xét lệnh cuối cùng của mỗi đường; nó không kiểm tra mọi hình con bên trong một đường. Ví dụ in ra `true` cho một hình chữ nhật.

```java
import com.aspose.slides.*;

class GeometryInspector {
    boolean isGeometryClosed(IGeometryShape geometryShape) {
        boolean hasNonemptyPath = false;

        for (IGeometryPath geometryPath : geometryShape.getGeometryPaths()) {
            IPathSegment[] segments = geometryPath.getPathData();
            if (segments.length == 0) {
                continue;
            }

            hasNonemptyPath = true;
            IPathSegment lastSegment = segments[segments.length - 1];
            if (lastSegment.getPathCommand() != PathCommandType.Close) {
                return false;
            }
        }

        return hasNonemptyPath;
    }
}

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    GeometryInspector inspector = new GeometryInspector();
    boolean closed = inspector.isGeometryClosed(shape);
    System.out.println(closed);
} finally {
    presentation.dispose();
}
```

## **Trích Xuất và Kiểm Tra Các Phần Tử Hình Dạng**

Sử dụng [IGeometryShape.createShapeElements](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#createShapeElements--) để kiểm tra một hình dạng hiện có dưới dạng các phần tử chứa các điểm đường và kiểu điểm. Ép mỗi [IShapeElement](https://reference.aspose.com/slides/java/com.aspose.slides/ishapeelement/) trả về sang [ShapeElement](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/) để lấy các mảng điểm và kiểu thông qua các phương thức [getPathPoints](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/#getPathPoints--) và [getPathTypes](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/#getPathTypes--) . Định dạng này hữu ích cho việc phân tích đường viền hoặc chuyển geometry sang các công cụ vẽ tùy chỉnh.

Ví dụ mở file input.pptx, tìm hình geometry đầu tiên trên slide đầu tiên, và in ra các đoạn đường của nó. Sử dụng một bản trình chiếu chứa hình dạng có các đoạn thẳng và cong để xem cả hai loại đầu ra. Nó không tìm kiếm bên trong các nhóm.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IGeometryShape shape = null;
    for (IShape candidate : slide.getShapes()) {
        if (candidate instanceof IGeometryShape) {
            shape = (IGeometryShape) candidate;
            break;
        }
    }

    if (shape == null) {
        System.out.println("No geometry shape found on the first slide.");
    } else {
        for (IShapeElement element : shape.createShapeElements()) {
            ShapeElement shapeElement = (ShapeElement) element;
            Point2D.Float[] points = shapeElement.getPathPoints();
            byte[] types = shapeElement.getPathTypes();
            System.out.println("Shape element:");

            for (int i = 0; i < points.length; i++) {
                int pointType = types[i] & 0x07; // Giữ lại loại đoạn, loại trừ các cờ.
                switch (pointType) {
                    case 0:
                        System.out.println("Start figure at " + points[i]);
                        break;
                    case 1:
                        System.out.println("Line to " + points[i]);
                        break;
                    case 3:
                        System.out.println("Cubic Bezier: controls " + points[i] + ", " + points[i + 1] + "; end " + points[i + 2]);
                        i += 2; // Consume both control points and the endpoint.
                        break;
                }

                if ((types[i] & 0x80) != 0) {
                    System.out.println("Close subpath back to its starting point.");
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Các mảng tương ứng theo chỉ số: `points[i]` là một điểm và `types[i]` mô tả vai trò của nó. Kiểu `0` bắt đầu một hình, và kiểu `1` vẽ một đường từ điểm trước đó tới điểm hiện tại. Một đoạn Bézier bậc ba bắt đầu tại điểm cuối trước và sử dụng ba mục kiểu `3` liên tiếp: hai điểm điều khiển rồi điểm cuối mới. Vòng lặp tiêu thụ ba mục này cùng nhau và kiểm tra điểm cuối để xác định đóng.

Các kiểu điểm cũng chứa các cờ. Áp dụng mask `0x07` để xác định loại đoạn, và kiểm tra `0x80` riêng để phát hiện một subpath đóng. Ví dụ, `129` (`0x81`) có nghĩa là một điểm cuối đường thẳng đóng một subpath, và `131` (`0x83`) là một điểm cuối Bézier đóng một subpath. Java lưu các cờ này trong byte có dấu; việc mask giữ nguyên các giá trị bit mong muốn. So sánh giá trị thô chỉ với `1` hoặc `3` sẽ bỏ lỡ các trường hợp này. Các cờ khác, như dấu gạch (`0x10`) và marker (`0x20`), không thay đổi loại đoạn cơ bản.

**Tọa độ và biến đổi.** Các điểm được đo bằng điểm (1/72 inch), với X tăng về phía bên phải và Y tăng xuống phía dưới. Đối với một hình không nhóm, các tọa độ đã được trích xuất đã bao gồm vị trí trả về bởi [getX](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getX--) và [getY](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getY--) và phản ánh chiều rộng‑chiều cao hiện tại của nó. Ví dụ, một hình chữ nhật không quay ở vị trí `(100, 200)` với kích thước `120 × 80` có giới hạn viền `(100, 200)`–`(220, 280)`. Không cần cộng lại vị trí của hình nữa. Trừ X và Y của nó để có tọa độ tương đối so với khung không quay.

Các điểm đã trích xuất không áp dụng phép quay của hình, trả về bởi [getRotation](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getRotation--), cũng như các phép lật ngang và dọc. Để tái tạo đường viền hiển thị, hãy áp dụng các biến đổi này quanh trung tâm của hình. Đối với các hình được nhóm, cũng cần tính đến ánh xạ tọa độ và biến đổi của nhóm; không giả định rằng các điểm đã trích xuất là tọa độ cuối cùng trên slide hoặc thực hiện một phép dịch/thu phóng hai lần nếu nó đã được phản ánh trong khung của đối tượng con.

**Kiểm tra so với chỉnh sửa.** Các mảng đã trích xuất mô tả đường viền; việc thay đổi chúng sẽ không cập nhật hình dạng gốc. Chọn cách tiếp cận này khi phân tích hoặc mã vẽ của bạn cần các mảng điểm/kiểu. Sử dụng [getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--) khi bạn cần các lệnh geometry trong hệ tọa độ cục bộ của hình hoặc muốn chỉnh sửa geometry của nó. Áp dụng các đường đã chỉnh sửa qua [setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) hoặc [setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) .

## **Chuyển Đổi Một Java AWT Shape Thành GeometryPath**

Ví dụ này kết hợp một đường viền hình chữ nhật với văn bản đã chuyển đổi thành geometry. Phương thức [setFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setFillMode-byte-) của đường viền vô hiệu hoá việc tô màu. Một [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) tạo đường viền văn bản trong một [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html). [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) của nó cung cấp các đoạn di chuyển, đường thẳng, quadratic, cubic và đóng, mà ví dụ này phát lại trên một [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) .

Văn bản sử dụng phông Arial 40 điểm. Đường viền được dịch 20 điểm theo chiều ngang và đặt vị trí sao cho đỉnh thị giác cách mép trên của hình dạng 10 điểm. Đường văn bản được tô đầy, trong khi hình chữ nhật gốc vẫn là đường viền. Áp dụng cả hai đường bằng [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) tạo ra một hình duy nhất chứa hình chữ nhật và văn bản.

```java
import com.aspose.slides.*;
import java.awt.Font;
import java.awt.Graphics2D;
import java.awt.Shape;
import java.awt.font.GlyphVector;
import java.awt.font.FontRenderContext;
import java.awt.geom.Rectangle2D;
import java.awt.geom.PathIterator;
import java.awt.image.BufferedImage;

Presentation presentation = new Presentation();
try {
    // Tạo hình dạng mới
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

    // Lấy đường hình học của hình dạng
    IGeometryPath originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(PathFillModeType.None);

    // Tạo đường đồ họa mới với văn bản
    Shape graphicsPath;
    Font font = new Font("Arial", Font.PLAIN, 40);
    String text = "Text in shape";
    BufferedImage image = new BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB);
    Graphics2D graphics = image.createGraphics();

    try
    {
        FontRenderContext fontContext = graphics.getFontRenderContext();
        GlyphVector glyphVector = font.createGlyphVector(fontContext, text);
        Rectangle2D textBounds = glyphVector.getVisualBounds();
        float baseline = (float) -textBounds.getY() + 10;
        graphicsPath = glyphVector.getOutline(20f, baseline);
    }
    finally {
        graphics.dispose();
    }

    // Chuyển đổi đường đồ họa sang đường hình học
    IGeometryPath textPath = new GeometryPath();
    PathIterator pathIterator = graphicsPath.getPathIterator(null);
    float[] points = new float[6];

    while (!pathIterator.isDone())
    {
        int segmentType = pathIterator.currentSegment(points);
        switch (segmentType)
        {
            case PathIterator.SEG_MOVETO:
                textPath.moveTo(points[0], points[1]);
                break;
            case PathIterator.SEG_LINETO:
                textPath.lineTo(points[0], points[1]);
                break;
            case PathIterator.SEG_QUADTO:
                textPath.quadraticBezierTo(points[0], points[1], points[2], points[3]);
                break;
            case PathIterator.SEG_CUBICTO:
                textPath.cubicBezierTo(points[0], points[1], points[2], points[3], points[4], points[5]);
                break;
            case PathIterator.SEG_CLOSE:
                textPath.closeFigure();
                break;
        }
        pathIterator.next();
    }

    textPath.setFillMode(PathFillModeType.Normal);

    // Đặt tổ hợp đường hình học mới và đường hình học gốc cho hình dạng
    shape.setGeometryPaths(new IGeometryPath[] { originalPath, textPath });
} finally {
    presentation.dispose();
}
```
![example5_image](custom_shape_5.png)

## **FAQ**

**Điều gì sẽ xảy ra với phần tô và đường viền sau khi thay thế geometry?**

Kiểu vẫn giữ nguyên trên hình; chỉ đường viền được thay đổi. Phần tô và đường viền sẽ tự động áp dụng cho geometry mới.

**Làm sao để quay đúng một hình dạng tùy chỉnh cùng với geometry của nó?**

Sử dụng phương thức [setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#setRotation-float-) của hình; geometry sẽ quay cùng hình vì nó gắn liền với hệ tọa độ của hình.

**Tôi có thể chuyển đổi một hình dạng tùy chỉnh thành hình ảnh để “khóa” kết quả không?**

Có. Xuất khu vực [slide](/slides/vi/java/convert-powerpoint-to-png/) cần thiết hoặc trực tiếp [shape](/slides/vi/java/create-shape-thumbnails/) sang định dạng raster; việc này đơn giản hoá các thao tác tiếp theo với các geometry phức tạp.