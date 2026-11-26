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
- đường dẫn hình học
- điểm đường
- điểm chỉnh sửa
- thêm điểm
- xóa điểm
- thao tác chỉnh sửa
- góc cong
- PowerPoint
- bản trình chiếu
- Java
- Aspose.Slides
description: "Tạo và tùy chỉnh các hình dạng trong bản trình chiếu PowerPoint với Aspose.Slides cho Java: đường dẫn hình học, các góc cong, hình dạng tổng hợp."
---
## **Tổng quan**

Bài viết này giải thích cách tùy chỉnh các hình dạng trong bản trình chiếu Aspose.Slides bằng cách chỉnh sửa hình học của hình dạng thông qua các điểm chỉnh sửa và các đường dẫn hình học. Nó cho thấy cách làm việc với [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) và [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/) để sửa đổi các hình dạng hiện có, thực hiện các thao tác chỉnh sửa đường cơ bản, thêm hoặc xóa điểm, và áp dụng hình học đã cập nhật trở lại cho một hình dạng.

Nó cũng trình bày cách tạo các hình dạng tùy chỉnh và tổng hợp, xây dựng các hình dạng với các góc cong, xác định liệu hình học của một hình dạng có đóng không, kiểm tra các phần tử hình dạng, và chuyển đổi các đường viền văn bản Java AWT thành các đường dẫn hình học.

## **Thay đổi một Hình dạng bằng Các Điểm Chỉnh sửa**

Trong PowerPoint, bạn có thể sử dụng **Edit Points** để chỉnh sửa một hình vuông:

* Di chuyển một góc vào trong hoặc ra ngoài.
* Điều chỉnh độ cong tại một điểm.
* Thêm các điểm mới.

Việc chỉnh sửa các điểm cho phép bạn thay đổi đường viền của một hình dạng hoặc sử dụng một hình dạng hiện có làm cơ sở cho một hình dạng mới.

## **Mẹo Chỉnh sửa Hình dạng**

![overview_image](custom_shape_0.png)

Khi chỉnh sửa các hình dạng PowerPoint, hãy ghi nhớ những khái niệm sau:

* Một hình dạng (hoặc đường dẫn của nó) có thể là đóng hoặc mở.
* Đường dẫn của một hình dạng bao gồm các điểm neo được nối bởi các đoạn.
* Một đoạn có thể thẳng hoặc cong. Các điểm neo và tay cầm điều khiển xác định hình dạng của nó.
* Các điểm neo tồn tại dưới dạng điểm góc, điểm thẳng, hoặc điểm mượt:
  * Tại một điểm góc, các đoạn kề nhau có thể gặp nhau ở một góc.
  * Tại một điểm mượt, hai tay cầm điều khiển được căn chỉnh và cách đều điểm neo.
  * Tại một điểm thẳng, hai tay cầm điều khiển được căn chỉnh nhưng có thể ở các khoảng cách khác nhau so với điểm neo.
* Di chuyển các điểm neo hoặc điều chỉnh các tay cầm của chúng sẽ thay đổi đường viền của hình dạng.

Để chỉnh sửa các hình dạng PowerPoint thông qua các điểm chỉnh sửa, **Aspose.Slides** cung cấp lớp [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) và giao diện [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/).

* Một thực thể [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) đại diện cho một đường dẫn hình học của đối tượng [IGeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/) .
* Để lấy [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) từ thực thể [IGeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/) , bạn có thể sử dụng phương thức [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--) .
* Để đặt [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) cho một hình dạng, bạn có thể sử dụng các phương thức này: [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) cho các hình dạng có một đường duy nhất và [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) cho các hình dạng có nhiều đường .
* Để thêm các đoạn, bạn có thể sử dụng các phương thức dưới [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/) .
* Sử dụng các phương thức [IGeometryPath.setStroke](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setStroke-boolean-) và [IGeometryPath.setFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setFillMode-byte-) , bạn có thể đặt giao diện cho một đường hình học .
* Sử dụng phương thức [IGeometryPath.getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--) , bạn có thể lấy đường hình học của một [GeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/geometryshape/) dưới dạng một mảng các đoạn đường .
* Để truy cập các tùy chọn tùy chỉnh hình học hình dạng bổ sung, bạn có thể đọc một [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) thông qua [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) của nó và phát lại các đoạn trên một [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) .

## **Các thao tác chỉnh sửa đơn giản**

Sử dụng các phương pháp sau để chỉnh sửa một đường hình học. Các phiên bản tải chồng chấp nhận một chỉ số sẽ chèn một đoạn tại vị trí dựa trên chỉ số không trong mảng các đoạn của đường.

| Thao tác | Phương thức |
| --- | --- |
| Thêm hoặc chèn một đường thẳng. | [GeometryPath.lineTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#lineTo-float-float-) |
| Thêm hoặc chèn một đường cong Bézier bậc ba với hai điểm điều khiển và một điểm cuối. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#cubicBezierTo-float-float-float-float-float-float-) |
| Thêm hoặc chèn một đường cong Bézier bậc hai với một điểm điều khiển và một điểm cuối. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#quadraticBezierTo-float-float-float-float-) |
| Thêm một cung ellip với kích thước và góc đã chỉ định tính bằng độ. | [GeometryPath.arcTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) |
| Đóng hình hiện tại bằng cách nối điểm cuối của nó với điểm bắt đầu. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#closeFigure--) |
| Đặt điểm bắt đầu của một hình. | [GeometryPath.moveTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#moveTo-float-float-) |
| Xóa một đoạn tại chỉ số bắt đầu từ 0. | [GeometryPath.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#removeAt-int-) |

## **Thêm các Điểm Tùy chỉnh vào Một Hình dạng**

Ví dụ này chèn hai điểm vào một hình chữ nhật bằng cách sử dụng [GeometryPath.lineTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#lineTo-float-float-) và áp dụng đường đã chỉnh sửa với [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) . Các tọa độ là cục bộ đối với hình dạng: cả hai điểm mới đều nằm ở trung tâm, cách bên trái 100 điểm và cách trên 50 điểm. Các chỉ số đoạn 1 và 4 đặt chúng trên các cạnh trên và dưới, kéo các cạnh này vào trong.

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

## **Xóa các Điểm khỏi Một Hình dạng**

Ví dụ này thay đổi đường viền hình trái tim bằng cách xóa đoạn tại chỉ số 2 (bắt đầu từ 0) bằng [GeometryPath.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#removeAt-int-) . Áp dụng đường đã sửa đổi với [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) cập nhật đường viền của hình dạng.

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

## **Tạo một Hình dạng Tùy chỉnh**

Ví dụ này xây dựng một ngôi sao năm cánh bằng [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) . Bán kính ngoài và trong xen kẽ là 100 và 50 điểm để xác định các đầu nhọn và các rãnh; bước 72 độ tạo khoảng cách đều cho năm đầu. Đường được đóng bằng [GeometryPath.closeFigure](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#closeFigure--) và áp dụng cho một hình chữ nhật bằng [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) , thay thế đường viền của nó.

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

## **Tạo một Hình dạng Tùy chỉnh Tổng hợp**

Ví dụ này định nghĩa hai đối tượng [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) đóng cho phần trên và dưới một phần ba của một hình dạng. Áp dụng cả hai đường bằng [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) tạo ra một hình dạng tổng hợp duy nhất với một khoảng trống qua phần giữa của nó.

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

## **Tạo một Hình dạng Tùy chỉnh với Các Góc Cong**

Ví dụ này kết hợp các đoạn thẳng với [GeometryPath.arcTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) để tạo một hình dạng có các góc cong vào trong. Mỗi kích thước góc đặt chiều rộng và chiều cao của cung tính bằng điểm, và góc quét -90 độ vẽ một phần tư elip ngược chiều kim đồng hồ. Đường hoàn chỉnh được áp dụng bằng [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) , và bản trình chiếu được lưu ở định dạng PPTX.

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

## **Xác định xem Hình học của Hình dạng có Đóng không**

Trợ giúp dưới đây kiểm tra xem mỗi đường hình học không rỗng có kết thúc bằng một đoạn đóng hay không. Nó đọc [IGeometryPath.getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--) và so sánh lệnh của đoạn cuối cùng [IPathSegment.getPathCommand](https://reference.aspose.com/slides/java/com.aspose.slides/ipathsegment/#getPathCommand--) với [PathCommandType.Close](https://reference.aspose.com/slides/java/com.aspose.slides/pathcommandtype/) . Nó trả về false khi không có đường nào không rỗng. Kiểm tra này chỉ xét lệnh cuối cùng của mỗi đường; nó không kiểm tra mọi hình phụ bên trong một đường. Ví dụ in ra `true` cho một hình chữ nhật.

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

## **Kiểm tra Các Lệnh Đường Dẫn Hình Học**

Tải xuống tệp [contour.pptx](contour.pptx) và đặt nó trong thư mục làm việc của ứng dụng. Hình dạng đầu tiên trên slide đầu có một cạnh trên thẳng, một đường cong Bézier bậc ba, và một cạnh đóng thẳng. Sử dụng [getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--) để đọc các đường của hình và [getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--) để đọc các đoạn của mỗi đường theo thứ tự vẽ. Đối với mỗi đoạn, [getPathCommand](https://reference.aspose.com/slides/java/com.aspose.slides/ipathsegment/#getPathCommand--) xác định lệnh và quyết định cách diễn giải các giá trị trả về bởi [getSegmentData](https://reference.aspose.com/slides/java/com.aspose.slides/ipathsegment/#getSegmentData--) .

```java
import com.aspose.slides.*;
import java.util.Arrays;

Presentation presentation = new Presentation("contour.pptx");
try {
    IGeometryShape shape = (IGeometryShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IGeometryPath[] paths = shape.getGeometryPaths();

    for (int i = 0; i < paths.length; i++) {
        IPathSegment[] segments = paths[i].getPathData();
        for (int j = 0; j < segments.length; j++) {
            byte command = segments[j].getPathCommand();
            float[] data = segments[j].getSegmentData();
            String detail;
            switch (command) {
                case PathCommandType.MoveTo:
                case PathCommandType.LineTo:
                    detail = String.format("destination=(%s, %s)", data[0], data[1]);
                    break;
                case PathCommandType.CubicBezierTo:
                    detail = String.format("control1=(%s, %s) control2=(%s, %s) end=(%s, %s)", data[0], data[1], data[2], data[3], data[4], data[5]);
                    break;
                case PathCommandType.Close:
                    detail = "no coordinates";
                    break;
                default:
                    detail = "raw=" + Arrays.toString(data);
            }
            String name = PathCommandType.getName(PathCommandType.class, command);
            System.out.printf("Path %d, segment %d: %s %s%n", i, j, name, detail);
        }
    }
} finally {
    presentation.dispose();
}
```

Hình dạng nằm tại (200, 100) điểm trên slide. Các tọa độ được báo cáo là cục bộ đối với hình dạng, với (0, 0) ở góc trên‑trái, x tăng sang phải, và y tăng xuống dưới. Đoạn đóng trả về điểm bắt đầu mà không có tọa độ bổ sung.

```text
Path 0, segment 0: MoveTo destination=(0.0, 0.0)
Path 0, segment 1: LineTo destination=(80.0, 0.0)
Path 0, segment 2: CubicBezierTo control1=(70.0, 15.0) control2=(30.0, 45.0) end=(0.0, 60.0)
Path 0, segment 3: Close no coordinates
```

![Hình PowerPoint với cạnh trên thẳng, cạnh cong từ trên‑phải xuống dưới‑trái, và cạnh trái thẳng](contour.png)

## **Trích xuất và Kiểm tra Các Phần tử Hình dạng**

Sử dụng [IGeometryShape.createShapeElements](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#createShapeElements--) để kiểm tra một hình dạng hiện có dưới dạng các phần tử chứa các điểm đường và loại điểm. Ép mỗi [IShapeElement](https://reference.aspose.com/slides/java/com.aspose.slides/ishapeelement/) trả về sang [ShapeElement](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/) để lấy các mảng điểm và loại thông qua các phương thức [getPathPoints](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/#getPathPoints--) và [getPathTypes](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/#getPathTypes--) . Đại diện này hữu ích cho việc phân tích đường viền hoặc truyền hình học tới các công cụ vẽ tùy chỉnh.

Ví dụ mở tệp input.pptx, tìm hình dạng hình học đầu tiên trực tiếp trên slide đầu, và in các đoạn đường của nó. Sử dụng một bản trình chiếu chứa một hình dạng có các đoạn thẳng và cong để xem cả hai loại đầu ra. Nó không tìm kiếm bên trong các nhóm.

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
                int pointType = types[i] & 0x07; // Giữ loại đoạn, loại trừ các cờ.
                switch (pointType) {
                    case 0:
                        System.out.println("Start figure at " + points[i]);
                        break;
                    case 1:
                        System.out.println("Line to " + points[i]);
                        break;
                    case 3:
                        System.out.println("Cubic Bezier: controls " + points[i] + ", " + points[i + 1] + "; end " + points[i + 2]);
                        i += 2; // Tiêu thụ cả các điểm kiểm soát và điểm cuối.
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

Các mảng tương ứng theo chỉ số: `points[i]` là một điểm và `types[i]` mô tả vai trò của nó. Loại `0` bắt đầu một hình, và loại `1` vẽ một đường từ điểm trước tới điểm hiện tại. Một đoạn Bézier bậc ba bắt đầu từ điểm cuối trước và sử dụng ba mục liên tiếp loại-`3`: hai điểm điều khiển và sau đó là điểm cuối mới. Vòng lặp tiêu thụ ba mục này cùng nhau và kiểm tra điểm cuối để đóng.

Các loại điểm cũng chứa các cờ. Áp dụng mặt nạ `0x07` để xác định loại đoạn, và kiểm tra `0x80` riêng biệt để phát hiện một đường con đã đóng. Ví dụ, `129` (`0x81`) nghĩa là một điểm cuối đường thẳng đóng một đường con, và `131` (`0x83`) nghĩa là một điểm cuối Bézier đóng một đường con. Java lưu các cờ này trong byte có dấu; việc áp dụng mặt nạ giữ lại giá trị bit mong muốn. So sánh giá trị thô chỉ với `1` hoặc `3` sẽ bỏ qua các trường hợp này. Các cờ khác, như dash (`0x10`) và marker (`0x20`), không thay đổi loại đoạn cơ bản.

**Tọa độ và chuyển đổi.**  
Điểm được đo bằng điểm (1/72 inch), với X tăng sang phải và Y tăng xuống dưới. Đối với một hình dạng không thuộc nhóm, các tọa độ đã trích xuất đã bao gồm vị trí trả về bởi [getX](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getX--) và [getY](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getY--) và phản ánh chiều rộng và chiều cao hiện tại của nó. Ví dụ, một hình chữ nhật không xoay tại `(100, 200)` với kích thước `120 × 80` có giới hạn đường viền `(100, 200)`–`(220, 280)` . Đừng cộng lại vị trí của hình dạng nữa. Trừ X và Y của nó để có được các tọa độ tương đối với khung chưa xoay.

Các điểm đã trích xuất không áp dụng việc xoay của hình dạng, được trả về bởi [getRotation](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getRotation--) , hoặc việc lật ngang và dọc. Để tái tạo đường viền hiển thị, hãy áp dụng các chuyển đổi này quanh trung tâm của hình dạng. Đối với các hình dạng trong nhóm, cũng phải tính đến việc ánh xạ và chuyển đổi tọa độ nhóm; đừng cho rằng các điểm đã trích xuất là tọa độ cuối cùng trên slide hoặc áp dụng một phép dịch hoặc tỉ lệ hai lần nếu chúng đã được phản ánh trong khung con.

**Kiểm tra so với chỉnh sửa.**  
Các mảng đã trích xuất mô tả đường viền; việc thay đổi chúng không cập nhật hình dạng gốc. Chọn cách này khi phân tích hoặc mã vẽ của bạn cần các mảng điểm/loại. Sử dụng [getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--) khi bạn cần các lệnh hình học trong hệ tọa độ cục bộ của hình dạng hoặc muốn chỉnh sửa hình học của nó. Áp dụng các đường đã chỉnh sửa thông qua [setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) hoặc [setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) .

## **Chuyển đổi một Java AWT Shape sang GeometryPath**

Ví dụ này kết hợp một đường viền hình chữ nhật với văn bản được chuyển đổi thành hình học. Phương thức [setFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setFillMode-byte-) của đường viền tắt việc tô. Một [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) tạo đường viền văn bản trong một [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) . [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) của nó cung cấp các đoạn di chuyển, line, quadratic, cubic và closing, mà ví dụ này phát lại trên một [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) .

Văn bản sử dụng phông Arial 40 điểm. Đường viền được dịch 20 điểm theo chiều ngang và đặt vị trí với phần trên trực quan cách dưới 10 điểm so với cạnh trên của hình dạng. Đường văn bản được tô, trong khi hình chữ nhật gốc vẫn là đường viền. Áp dụng cả hai đường bằng [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) tạo một hình dạng duy nhất chứa hình chữ nhật và văn bản.

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
    // Tạo hình mới
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

    // Chuyển đổi đường đồ họa thành đường hình học
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

    // Đặt kết hợp giữa đường hình học mới và đường hình học gốc cho hình dạng
    shape.setGeometryPaths(new IGeometryPath[] { originalPath, textPath });
} finally {
    presentation.dispose();
}
```
![example5_image](custom_shape_5.png)

## **FAQ**

**Điều gì sẽ xảy ra với màu nền và đường viền sau khi thay thế hình học?**  
Kiểu dáng vẫn giữ cùng hình dạng; chỉ đường viền thay đổi. Màu nền và đường viền sẽ tự động được áp dụng cho hình học mới.

**Làm sao để xoay đúng một hình dạng tùy chỉnh cùng với hình học của nó?**  
Sử dụng phương thức [setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#setRotation-float-) của hình; hình học sẽ xoay cùng với hình vì nó được ràng buộc vào hệ tọa độ của chính hình dạng.

**Tôi có thể chuyển đổi một hình dạng tùy chỉnh thành hình ảnh để “khóa” kết quả không?**  
Có. Xuất vùng [slide](/slides/vi/java/convert-powerpoint-to-png/) cần thiết hoặc chính [shape](/slides/vi/java/create-shape-thumbnails/) ra định dạng raster; điều này giúp việc làm việc tiếp theo với các hình học phức tạp trở nên dễ dàng hơn.