---
title: Tùy chỉnh các hình dạng trong bản trình chiếu trên Android
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
- điểm đường dẫn
- điểm chỉnh sửa
- thêm điểm
- xóa điểm
- hoạt động chỉnh sửa
- góc cong
- PowerPoint
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Tạo và tùy chỉnh các hình dạng trong bản trình chiếu PowerPoint bằng Aspose.Slides cho Android qua Java: đường dẫn hình học, các góc cong, hình dạng hỗn hợp."
---
## **Tổng quan**

Bài viết này giải thích cách tùy chỉnh các hình dạng trong bản trình chiếu Aspose.Slides bằng cách chỉnh sửa hình học của hình dạng thông qua các điểm chỉnh sửa và đường dẫn hình học. Nó cho thấy cách làm việc với [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) và [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/) để chỉnh sửa các hình dạng hiện có, thực hiện các thao tác chỉnh sửa đường dẫn cơ bản, thêm hoặc xóa điểm, và áp dụng hình học đã cập nhật trở lại cho một hình dạng.

Nó cũng minh họa cách tạo các hình dạng tùy chỉnh và hỗn hợp, xây dựng các hình dạng có góc cong, xác định xem hình học của một hình dạng có đóng không, và kiểm tra các phần tử hình dạng bằng mảng điểm Android.

## **Thay đổi hình dạng bằng các điểm chỉnh sửa**

Trong PowerPoint, bạn có thể sử dụng **Edit Points** để chỉnh sửa một hình vuông:

* Di chuyển một góc vào trong hoặc ra ngoài.
* Điều chỉnh độ cong tại một điểm.
* Thêm các điểm mới.

Việc chỉnh sửa các điểm cho phép bạn thay đổi đường viền của một hình dạng hoặc sử dụng một hình dạng hiện có làm cơ sở cho hình dạng mới.

## **Mẹo chỉnh sửa hình dạng**

![overview_image](custom_shape_0.png)

Khi chỉnh sửa các hình dạng PowerPoint, cần nhớ các khái niệm sau:

* Một hình dạng (hoặc đường dẫn của nó) có thể là đóng hoặc mở.
* Đường dẫn của một hình dạng bao gồm các điểm neo được nối bằng các đoạn.
* Một đoạn có thể thẳng hoặc cong. Các điểm neo và tay cầm điều khiển xác định hình dạng của nó.
* Các điểm neo tồn tại dưới dạng điểm góc, điểm thẳng hoặc điểm mượt:
  * Tại một điểm góc, các đoạn liền kề có thể gặp nhau ở một góc.
  * Tại một điểm mượt, hai tay cầm điều khiển được căn chỉnh và cách đều điểm neo.
  * Tại một điểm thẳng, hai tay cầm điều khiển được căn chỉnh nhưng có thể cách điểm neo khác nhau.
* Di chuyển các điểm neo hoặc điều chỉnh tay cầm của chúng sẽ thay đổi đường viền của hình dạng.

Để chỉnh sửa các hình dạng PowerPoint thông qua các điểm chỉnh sửa, **Aspose.Slides** cung cấp lớp [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) và giao diện [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/).

* Một thể hiện [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) đại diện cho đường dẫn hình học của đối tượng [IGeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/).
* Để lấy [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) từ thể hiện [IGeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/), bạn có thể sử dụng phương thức [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--).
* Để đặt [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) cho một hình dạng, bạn có thể dùng các phương thức: [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) cho các hình dạng có một đường dẫn duy nhất và [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) cho các hình dạng có nhiều đường dẫn.
* Để thêm các đoạn, bạn có thể sử dụng các phương thức trong [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/).
* Bằng cách sử dụng các phương thức [IGeometryPath.setStroke](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#setStroke-boolean-) và [IGeometryPath.setFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#setFillMode-byte-), bạn có thể đặt giao diện cho một đường dẫn hình học.
* Bằng cách sử dụng phương thức [IGeometryPath.getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--) , bạn có thể lấy đường dẫn hình học của một [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometryshape/) dưới dạng mảng các đoạn đường.

## **Các thao tác chỉnh sửa đơn giản**

Sử dụng các phương thức sau để chỉnh sửa một đường dẫn hình học. Các phiên bản nạp chồng chấp nhận một chỉ mục sẽ chèn một đoạn tại vị trí dựa trên chỉ mục không‑gian trong mảng các đoạn của đường dẫn.

| Thao tác | Phương thức |
| --- | --- |
| Thêm hoặc chèn một đường thẳng. | [GeometryPath.lineTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#lineTo-float-float-) |
| Thêm hoặc chèn một đường cong Bézier bậc ba với hai điểm điều khiển và một điểm cuối. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#cubicBezierTo-float-float-float-float-float-float-) |
| Thêm hoặc chèn một đường cong Bézier bậc hai với một điểm điều khiển và một điểm cuối. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#quadraticBezierTo-float-float-float-float-) |
| Thêm một cung elip với các kích thước và góc được chỉ định tính bằng độ. | [GeometryPath.arcTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) |
| Đóng hình hiện tại bằng cách nối điểm cuối của nó với điểm bắt đầu. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#closeFigure--) |
| Đặt điểm bắt đầu của một hình. | [GeometryPath.moveTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#moveTo-float-float-) |
| Xóa một đoạn tại một chỉ mục không‑gian. | [GeometryPath.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#removeAt-int-) |

## **Thêm các điểm tùy chỉnh vào hình dạng**

Ví dụ này chèn hai điểm vào một hình chữ nhật bằng cách sử dụng [GeometryPath.lineTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#lineTo-float-float-) và áp dụng đường dẫn đã chỉnh sửa với [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-). Các tọa độ là cục bộ đối với hình dạng: cả hai điểm mới đều ở trung tâm của nó, cách mép trái 100 điểm và cách mép trên 50 điểm. Các chỉ mục đoạn 1 và 4 đặt chúng trên các cạnh trên và dưới, kéo các cạnh đó vào trong.

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

## **Xóa các điểm khỏi hình dạng**

Ví dụ này thay đổi đường viền hình dạng trái tim bằng cách xóa đoạn tại chỉ mục không‑gian 2 với [GeometryPath.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#removeAt-int-). Áp dụng đường dẫn đã sửa đổi với [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) cập nhật đường viền của hình dạng.

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

Ví dụ này xây dựng một ngôi sao năm cánh bằng [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/). Các bán kính ngoài và trong xen kẽ 100 và 50 điểm xác định các đầu nhọn và các khâu lõm; bước 72 độ chia đều năm đầu nhọn. Đường dẫn được đóng bằng [GeometryPath.closeFigure](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#closeFigure--) và áp dụng cho một hình chữ nhật bằng [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-), thay thế đường viền của nó.

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

## **Tạo một hình dạng tùy chỉnh hỗn hợp**

Ví dụ này định nghĩa hai đối tượng [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) đóng cho phần trên và phần dưới của một hình dạng. Áp dụng cả hai đường dẫn với [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) tạo ra một hình dạng hỗn hợp duy nhất có một khoảng trống ở phần giữa của nó.

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

Ví dụ này kết hợp các đoạn thẳng với [GeometryPath.arcTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) để tạo một hình dạng có các góc cong vào trong. Mỗi kích thước góc đặt chiều rộng và chiều cao của cung tính bằng điểm, và vòng quét -90 độ vẽ một phần tư elip ngược chiều kim đồng hồ. Đường dẫn hoàn chỉnh được áp dụng bằng [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-), và bản trình chiếu được lưu ở định dạng PPTX.

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

## **Kiểm tra xem hình học của một hình dạng có đóng không**

Trợ giúp sau kiểm tra xem mọi đường dẫn hình học không rỗng có kết thúc bằng một đoạn đóng hay không. Nó đọc [IGeometryPath.getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--) và so sánh lệnh cuối cùng của đoạn với [IPathSegment.getPathCommand](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipathsegment/#getPathCommand--) so với [PathCommandType.Close](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pathcommandtype/). Nó trả về false khi không có đường dẫn nào không rỗng. Kiểm tra này chỉ xem lệnh cuối cùng của mỗi đường dẫn; nó không kiểm tra mọi tiểu hình trong một đường dẫn. Ví dụ in ra `true` cho một hình chữ nhật.

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

## **Trích xuất và kiểm tra các phần tử hình dạng**

Sử dụng [IGeometryShape.createShapeElements](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#createShapeElements--) để kiểm tra một hình dạng hiện có dưới dạng các phần tử chứa các điểm đường dẫn và kiểu điểm. Ép mỗi [IShapeElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapeelement/) trả về sang [ShapeElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/) để lấy mảng điểm và mảng kiểu thông qua các phương thức [getPathPoints](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/#getPathPoints--) và [getPathTypes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/#getPathTypes--) . Đại diện này hữu ích cho việc phân tích đường viền hoặc truyền hình học tới các công cụ vẽ tùy chỉnh.

Ví dụ mở file input.pptx, tìm hình hình học đầu tiên trực tiếp trên slide đầu tiên, và in các đoạn đường dẫn của nó. Sử dụng một bản trình chiếu chứa một hình dạng có các đoạn thẳng và cong để thấy cả hai loại đầu ra. Nó không tìm kiếm bên trong các nhóm.

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
                        i += 2; // Tiêu thụ cả các điểm điều khiển và điểm cuối.
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

Các mảng tương ứng theo chỉ số: `points[i]` là một điểm và `types[i]` mô tả vai trò của nó. Kiểu `0` bắt đầu một hình, và kiểu `1` vẽ một đường từ điểm trước đến điểm hiện tại. Một đoạn Bézier bậc ba bắt đầu ở điểm cuối trước và sử dụng ba mục kiểu `3` liên tiếp: hai điểm điều khiển và sau đó là điểm cuối mới. Vòng lặp sẽ tiêu thụ ba mục này cùng nhau và kiểm tra điểm cuối để xác định đóng.

Các kiểu điểm cũng chứa các cờ. Áp dụng mặt nạ `0x07` để xác định kiểu đoạn, và kiểm tra `0x80` riêng biệt để phát hiện một tiểu đường dẫn đóng. Ví dụ, `129` (`0x81`) có nghĩa là một điểm cuối đường thẳng đóng một tiểu đường dẫn, và `131` (`0x83`) có nghĩa là một điểm cuối Bézier đóng một tiểu đường dẫn. Java lưu các cờ này trong các byte có dấu; việc áp dụng mặt nạ bảo tồn các giá trị bit dự định. So sánh giá trị thô chỉ với `1` hoặc `3` sẽ bỏ qua các trường hợp này. Các cờ khác, như dấu gạch ngang (`0x10`) và dấu đánh dấu (`0x20`), không thay đổi kiểu đoạn cơ bản.

**Tọa độ và biến đổi.** Các điểm được đo bằng điểm (1/72 inch), với trục X tăng về phía bên phải và trục Y tăng xuống phía dưới. Đối với một hình dạng không thuộc nhóm, các tọa độ đã trích xuất đã bao gồm vị trí trả về bởi [getX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getX--) và [getY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getY--) và phản ánh chiều rộng và chiều cao hiện tại của nó. Ví dụ, một hình chữ nhật không quay tại `(100, 200)` có kích thước `120 × 80` sẽ có giới hạn đường viền `(100, 200)`–`(220, 280)`. Đừng cộng thêm vị trí của hình dạng một lần nữa. Trừ X và Y của nó để có được tọa độ tương đối với khung không quay của nó.

Các điểm đã trích xuất không áp dụng việc quay của hình dạng, được trả về bởi [getRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getRotation--), hoặc việc lật ngang và dọc. Để tái tạo đường viền hiển thị, áp dụng các biến đổi này quanh trung tâm của hình dạng. Đối với các hình dạng trong nhóm, cũng cần tính đến việc ánh xạ và biến đổi tọa độ của nhóm; đừng giả định rằng các điểm đã trích xuất là tọa độ cuối cùng được hiển thị trên slide hoặc áp dụng dịch chuyển hoặc tỷ lệ gấp đôi nếu chúng đã được phản ánh trong khung của đối tượng con.

**Kiểm tra so với chỉnh sửa.** Các mảng đã trích xuất mô tả đường viền; việc thay đổi chúng không cập nhật hình dạng gốc. Chọn cách tiếp cận này khi việc phân tích hoặc mã vẽ của bạn cần các mảng điểm/kiểu. Sử dụng [getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--) khi bạn cần các lệnh hình học trong hệ tọa độ cục bộ của hình dạng hoặc muốn chỉnh sửa hình học của nó. Áp dụng các đường dẫn đã chỉnh sửa qua [setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) hoặc [setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---).

## **FAQ**

**Điều gì sẽ xảy ra với màu nền và viền sau khi thay thế hình học?**

Kiểu vẫn còn với hình dạng; chỉ có đường viền thay đổi. Màu nền và viền sẽ tự động áp dụng cho hình học mới.

**Làm thế nào để quay đúng một hình dạng tùy chỉnh cùng với hình học của nó?**

Sử dụng phương thức [setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setRotation-float-) của hình dạng; hình học sẽ quay cùng với hình dạng vì nó được gắn vào hệ tọa độ của chính hình dạng.

**Tôi có thể chuyển đổi một hình dạng tùy chỉnh thành hình ảnh để “khóa” kết quả không?**

Có. Xuất khu vực [slide](/slides/vi/androidjava/convert-powerpoint-to-png/) cần thiết hoặc chính [shape](/slides/vi/androidjava/create-shape-thumbnails/) ra định dạng raster; việc này đơn giản hoá công việc tiếp theo với các hình học phức tạp.