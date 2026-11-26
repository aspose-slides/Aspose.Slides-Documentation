---
title: Tùy chỉnh các hình dạng bài thuyết trình trên Android
linktitle: Hình dạng tùy chỉnh
type: docs
weight: 20
url: /vi/androidjava/custom-shape/
keywords:
- hình dạng tùy chỉnh
- thêm hình dạng
- tạo hình dạng
- thay đổi hình dạng
- hình học hình dạng
- đường dẫn hình học
- các điểm đường dẫn
- điểm chỉnh sửa
- thêm điểm
- xóa điểm
- thao tác chỉnh sửa
- góc cong
- PowerPoint
- bài thuyết trình
- Android
- Java
- Aspose.Slides
description: "Tạo và tùy chỉnh các hình dạng trong bài thuyết trình PowerPoint bằng Aspose.Slides cho Android qua Java: đường dẫn hình học, góc cong, hình dạng ghép hợp."
---
## **Tổng quan**

Bài viết này giải thích cách tùy chỉnh các hình dạng trong bài thuyết trình của Aspose.Slides bằng cách chỉnh sửa hình học hình dạng thông qua các điểm chỉnh sửa và đường dẫn hình học. Nó trình bày cách làm việc với [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) và [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/) để sửa đổi các hình dạng hiện có, thực hiện các thao tác chỉnh sửa đường dẫn cơ bản, thêm hoặc xóa các điểm, và áp dụng hình học đã cập nhật trở lại cho một hình dạng.

Cũng nó minh họa cách tạo các hình dạng tùy chỉnh và ghép hợp, xây dựng các hình dạng có góc cong, xác định xem hình học của một hình dạng có đóng không, và kiểm tra các thành phần của hình dạng bằng cách sử dụng mảng điểm Android.

## **Thay đổi một hình dạng bằng các điểm chỉnh sửa**

Trong PowerPoint, bạn có thể sử dụng **Edit Points** để chỉnh sửa một hình vuông:

* Di chuyển một góc vào trong hoặc ra ngoài.
* Điều chỉnh độ cong tại một điểm.
* Thêm các điểm mới.

Việc chỉnh sửa các điểm cho phép bạn sửa đổi viền của một hình dạng hoặc sử dụng một hình dạng hiện có làm cơ sở cho một hình dạng mới.

## **Mẹo chỉnh sửa hình dạng**

![overview_image](custom_shape_0.png)

Khi chỉnh sửa các hình dạng PowerPoint, hãy nhớ những khái niệm sau:

* Một hình dạng (hoặc đường dẫn của nó) có thể đóng hoặc mở.
* Đường dẫn của một hình dạng bao gồm các điểm neo được kết nối bởi các đoạn.
* Một đoạn có thể thẳng hoặc cong. Các điểm neo và tay cầm điều khiển xác định hình dạng của nó.
* Các điểm neo tồn tại dưới dạng điểm góc, điểm thẳng hoặc điểm mượt:
  * Ở điểm góc, các đoạn nối kề nhau có thể gặp nhau tại một góc.
  * Ở điểm mượt, hai tay cầm điều khiển được căn chỉnh và cách đều nhau đến điểm neo.
  * Ở điểm thẳng, hai tay cầm điều khiển được căn chỉnh nhưng có thể cách điểm neo với khoảng cách khác nhau.
* Di chuyển các điểm neo hoặc điều chỉnh các tay cầm của chúng làm thay đổi viền của hình dạng.

Để chỉnh sửa các hình dạng PowerPoint thông qua các điểm chỉnh sửa, **Aspose.Slides** cung cấp lớp [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) và giao diện [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/).

* Một thể hiện [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) đại diện cho một đường dẫn hình học của đối tượng [IGeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/).
* Để lấy [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) từ thể hiện [IGeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/), bạn có thể sử dụng phương thức [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--).
* Để đặt [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) cho một hình dạng, bạn có thể sử dụng các phương thức sau: [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) cho các hình dạng có một đường duy nhất và [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) cho các hình dạng có nhiều đường.
* Để thêm các đoạn, bạn có thể sử dụng các phương thức trong [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/).
* Sử dụng các phương thức [IGeometryPath.setStroke](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#setStroke-boolean-) và [IGeometryPath.setFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#setFillMode-byte-) , bạn có thể đặt giao diện cho một đường dẫn hình học.
* Sử dụng phương thức [IGeometryPath.getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--) , bạn có thể lấy đường dẫn hình học của một [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometryshape/) dưới dạng một mảng các đoạn đường.

## **Các thao tác chỉnh sửa đơn giản**

Sử dụng các phương thức sau để chỉnh sửa một đường dẫn hình học. Các phiên bản chấp nhận chỉ mục sẽ chèn một đoạn tại vị trí zero‑based đó trong mảng các đoạn của đường dẫn.

| Thao tác | Phương thức |
| --- | --- |
| Thêm hoặc chèn một đường thẳng. | [GeometryPath.lineTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#lineTo-float-float-) |
| Thêm hoặc chèn một đường cong Bézier bậc ba với hai điểm điều khiển và một điểm cuối. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#cubicBezierTo-float-float-float-float-float-float-) |
| Thêm hoặc chèn một đường cong Bézier bậc hai với một điểm điều khiển và một điểm cuối. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#quadraticBezierTo-float-float-float-float-) |
| Thêm một cung elip với các kích thước và góc được chỉ định tính bằng độ. | [GeometryPath.arcTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) |
| Đóng hình hiện tại bằng cách kết nối điểm cuối với điểm bắt đầu. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#closeFigure--) |
| Đặt điểm bắt đầu của một hình. | [GeometryPath.moveTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#moveTo-float-float-) |
| Xóa một đoạn tại chỉ mục zero‑based. | [GeometryPath.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#removeAt-int-) |

## **Thêm các điểm tùy chỉnh vào một hình dạng**

Ví dụ này chèn hai điểm vào một hình chữ nhật bằng cách sử dụng [GeometryPath.lineTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#lineTo-float-float-) và áp dụng đường dẫn đã chỉnh sửa bằng [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-). Các tọa độ là cục bộ đối với hình dạng: cả hai điểm mới nằm ở trung tâm, cách bên trái 100 điểm và cách trên 50 điểm. Các chỉ mục đoạn 1 và 4 đặt chúng trên các cạnh trên và dưới, kéo các cạnh đó vào trong.

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

## **Xóa các điểm khỏi một hình dạng**

Ví dụ này thay đổi viền dạng trái tim bằng cách xóa đoạn tại chỉ mục zero‑based 2 bằng [GeometryPath.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#removeAt-int-). Áp dụng đường dẫn đã sửa đổi bằng [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) cập nhật đường viền của hình dạng.

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

## **Tạo một hình dạng tùy chỉnh**

Ví dụ này tạo một ngôi sao năm góc bằng [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/). Các bán kính ngoài và trong xen kẽ 100 và 50 điểm xác định các đầu nhọn và các rãnh lõm; bước 72 độ phân bố đều năm đầu nhọn. Đường dẫn được đóng bằng [GeometryPath.closeFigure](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#closeFigure--) và áp dụng cho một hình chữ nhật bằng [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-), thay thế viền của nó.

```java
import com.aspose.slides.*;
import android.graphics.PointF;
import java.util.ArrayList;
import java.util.List;

List<PointF> points = new ArrayList<>();

float outerRadius = 100f;
float innerRadius = 50f;
int angleStep = 72;

for (int angle = -90; angle < 270; angle += angleStep)
{
    double radians = angle * (Math.PI / 180f);
    double x = outerRadius * Math.cos(radians);
    double y = outerRadius * Math.sin(radians);
    PointF point = new PointF((float)x + outerRadius, (float)y + outerRadius);
    points.add(point);

    radians = Math.PI * (angle + angleStep / 2) / 180.0;
    x = innerRadius * Math.cos(radians);
    y = innerRadius * Math.sin(radians);
    point = new PointF((float)x + outerRadius, (float)y + outerRadius);
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

## **Tạo một hình dạng tùy chỉnh ghép hợp**

Ví dụ này định nghĩa hai đối tượng [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) đóng cho phần trên và phần dưới của một hình dạng. Áp dụng cả hai đường dẫn bằng [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) tạo ra một hình dạng ghép hợp duy nhất với một khoảng trống ở phần giữa của nó.

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

## **Tạo một hình dạng tùy chỉnh với các góc cong**

Ví dụ này kết hợp các đoạn thẳng với [GeometryPath.arcTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) để tạo một hình dạng có các góc cong vào trong. Kích thước mỗi góc đặt độ rộng và độ cao của cung tính bằng điểm, và vòng quét -90 độ vẽ một phần tư elip ngược chiều kim đồng hồ. Đường dẫn hoàn chỉnh được áp dụng bằng [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-), và bản trình chiếu được lưu ở định dạng PPTX.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

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

    PointF topLeft = new PointF(leftTopSize, 0);
    PointF topRight = new PointF(shapeWidth - rightTopSize, 0);
    PointF rightBottom = new PointF(shapeWidth, shapeHeight - rightBottomSize);
    PointF bottomLeft = new PointF(leftBottomSize, shapeHeight);
    PointF leftTop = new PointF(0, leftTopSize);

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

## **Xác định xem hình học của một hình dạng có đóng không**

Bộ trợ giúp sau kiểm tra xem mọi đường dẫn hình học không rỗng có kết thúc bằng một đoạn đóng hay không. Nó đọc [IGeometryPath.getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--) và so sánh lệnh của đoạn cuối cùng [IPathSegment.getPathCommand](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipathsegment/#getPathCommand--) với [PathCommandType.Close](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pathcommandtype/). Nó trả về false khi không có đường dẫn nào không rỗng. Kiểm tra này chỉ xem lệnh cuối cùng của mỗi đường dẫn; nó không kiểm tra mọi hình phụ trong một đường dẫn. Ví dụ in ra `true` cho một hình chữ nhật.

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

## **Kiểm tra các lệnh đường dẫn hình học**

Tải xuống [contour.pptx](contour.pptx) và thay thế tên tệp mẫu bằng đường dẫn trên thiết bị. Hình dạng đầu tiên trên slide đầu tiên có một cạnh trên thẳng, một đường cong Bézier bậc ba, và một cạnh đóng thẳng. Sử dụng [getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--) để đọc các đường dẫn của hình dạng và [getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--) để đọc các đoạn của mỗi đường dẫn theo thứ tự vẽ. Đối với mỗi đoạn, [getPathCommand](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipathsegment/#getPathCommand--) xác định lệnh và quyết định cách diễn giải các giá trị trả về bởi [getSegmentData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipathsegment/#getSegmentData--).

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

Hình dạng nằm tại (200, 100) điểm trên slide. Các tọa độ được báo cáo là cục bộ đối với hình dạng, với (0, 0) ở góc trên‑trái, x tăng sang phải và y tăng xuống dưới. Đoạn đóng trả về điểm bắt đầu mà không có tọa độ bổ sung.

```text
Path 0, segment 0: MoveTo destination=(0.0, 0.0)
Path 0, segment 1: LineTo destination=(80.0, 0.0)
Path 0, segment 2: CubicBezierTo control1=(70.0, 15.0) control2=(30.0, 45.0) end=(0.0, 60.0)
Path 0, segment 3: Close no coordinates
```

![Hình PowerPoint có cạnh trên thẳng, cạnh cong từ góc trên‑phải tới góc dưới‑trái, và cạnh trái thẳng](contour.png)

## **Trích xuất và Kiểm tra các thành phần hình dạng**

Sử dụng [IGeometryShape.createShapeElements](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#createShapeElements--) để kiểm tra một hình dạng hiện có dưới dạng các thành phần chứa các điểm đường dẫn và các loại điểm. Ép kiểu mỗi [IShapeElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapeelement/) trả về sang [ShapeElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/) để lấy các mảng điểm và loại thông qua các phương thức [getPathPoints](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/#getPathPoints--) và [getPathTypes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/#getPathTypes--) . Đại diện này hữu ích cho việc phân tích đường viền hoặc truyền hình học tới các công cụ vẽ tùy chỉnh.

Ví dụ này mở file input.pptx, tìm hình dạng hình học đầu tiên trực tiếp trên slide đầu tiên, và in ra các đoạn đường của nó. Sử dụng một bản trình chiếu chứa một hình dạng có cả đoạn thẳng và đoạn cong để xem cả hai loại đầu ra. Nó không tìm kiếm bên trong các nhóm.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

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
            PointF[] points = shapeElement.getPathPoints();
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

Các mảng tương ứng theo chỉ mục: `points[i]` là một điểm và `types[i]` mô tả vai trò của nó. Loại `0` bắt đầu một hình, và loại `1` vẽ một đường từ điểm trước tới điểm hiện tại. Một đoạn Bézier bậc ba bắt đầu tại điểm cuối trước và sử dụng ba mục loại `3` liên tiếp: hai điểm điều khiển tiếp theo là điểm cuối mới. Vòng lặp tiêu thụ ba mục này cùng nhau và kiểm tra điểm cuối để biết có đóng không.

Các loại điểm cũng chứa các cờ. Áp dụng mặt nạ `0x07` để xác định loại đoạn, và kiểm tra `0x80` riêng biệt để phát hiện một đường phụ đóng. Ví dụ, `129` (`0x81`) có nghĩa là một điểm cuối đường thẳng đóng một đường phụ, và `131` (`0x83`) có nghĩa là một điểm cuối Bézier đóng một đường phụ. Java lưu các cờ này trong các byte có dấu; việc áp dụng mặt nạ bảo tồn giá trị bit mong muốn. So sánh giá trị thô chỉ với `1` hoặc `3` sẽ bỏ lỡ các trường hợp này. Các cờ khác, như gạch ngang (`0x10`) và dấu (`0x20`), không thay đổi loại đoạn cơ bản.

**Tọa độ và biến đổi.** Các điểm được đo bằng điểm (1/72 inch), với X tăng sang phải và Y tăng xuống. Đối với một hình dạng không thuộc nhóm, các tọa độ đã trích xuất đã bao gồm vị trí trả về bởi [getX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getX--) và [getY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getY--) và phản ánh chiều rộng và chiều cao hiện tại của nó. Ví dụ, một hình chữ nhật không quay tại `(100, 200)` có kích thước `120 × 80` có giới hạn đường viền `(100, 200)`–`(220, 280)`. Không thêm vị trí của hình dạng một lần nữa. Trừ X và Y của nó để có được tọa độ tương đối với khung không quay.

Các điểm đã trích xuất không áp dụng góc quay của hình dạng, trả về bởi [getRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getRotation--), hoặc các phép lật ngang và dọc. Để tái tạo đường viền hiển thị, áp dụng các biến đổi đó quanh trung tâm của hình dạng. Đối với các hình dạng được nhóm, cũng phải tính đến việc ánh xạ tọa độ nhóm và các biến đổi; không giả định rằng các điểm đã trích xuất là tọa độ slide đã render cuối cùng hoặc áp dụng một phép dịch hoặc tỉ lệ hai lần nếu nó đã được phản ánh trong khung của phần tử con.

**Kiểm tra so với chỉnh sửa.** Các mảng đã trích xuất mô tả đường viền; việc thay đổi chúng không cập nhật hình dạng gốc. Chọn cách tiếp cận này khi phân tích hoặc mã vẽ của bạn cần các mảng điểm/loại. Sử dụng [getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--) khi bạn cần các lệnh hình học trong hệ tọa độ cục bộ của hình dạng hoặc muốn chỉnh sửa hình học của nó. Áp dụng các đường dẫn đã chỉnh sửa thông qua [setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) hoặc [setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---).

## **Câu hỏi thường gặp**

**Điều gì sẽ xảy ra với màu nền và viền sau khi thay thế hình học?**

Kiểu dáng vẫn giữ nguyên với hình dạng; chỉ đường viền thay đổi. Màu nền và viền sẽ tự động được áp dụng cho hình học mới.

**Làm thế nào để tôi xoay đúng một hình dạng tùy chỉnh cùng với hình học của nó?**

Sử dụng phương thức [setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setRotation-float-) của hình dạng; hình học sẽ quay cùng với hình dạng vì nó được gắn vào hệ tọa độ riêng của hình dạng.

**Tôi có thể chuyển đổi một hình dạng tùy chỉnh thành hình ảnh để "khóa" kết quả không?**

Có. Xuất khu vực [slide](/slides/vi/androidjava/convert-powerpoint-to-png/) hoặc [shape](/slides/vi/androidjava/create-shape-thumbnails/) cần thiết sang định dạng raster; điều này đơn giản hoá việc làm tiếp theo với các hình học phức tạp.