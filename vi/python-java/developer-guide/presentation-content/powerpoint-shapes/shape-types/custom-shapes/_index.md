---
title: Tùy chỉnh các hình dạng trong bản trình bày bằng Python qua Java
linktitle: Hình dạng tùy chỉnh
type: docs
weight: 20
url: /vi/python-java/custom-shape/
keywords: 
- hình dạng tùy chỉnh
- thêm hình
- tạo hình
- thay đổi hình
- hình học hình dạng
- đường dẫn hình học
- các điểm đường
- điểm chỉnh sửa
- thêm điểm
- xóa điểm
- thao tác chỉnh sửa
- góc cong
- PowerPoint
- bản trình bày
- Python
- Aspose.Slides
description: "Tạo và tùy chỉnh các hình dạng trong bản trình bày PowerPoint bằng Aspose.Slides cho Python qua Java: đường dẫn hình học, góc cong, hình hợp thành."
---
## **Tổng quan**

Bài viết này giải thích cách tùy chỉnh các hình dạng trong bản trình bày bằng Aspose.Slides bằng cách chỉnh sửa hình học của hình thông qua các điểm chỉnh sửa và đường dẫn hình học. Nó cho thấy cách làm việc với [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) để sửa đổi các hình hiện có, thực hiện các thao tác chỉnh sửa đường cơ bản, thêm hoặc xóa các điểm, và áp dụng hình học đã cập nhật trở lại cho một hình.

Nó cũng minh họa cách tạo các hình tùy chỉnh và hợp hợp, xây dựng các hình có góc cong, xác định xem một hình học có được đóng không, kiểm tra các thành phần của hình, và chuyển đổi các đường viền văn bản Java AWT thành các đường dẫn hình học.

## **Thay đổi một Hình bằng các Điểm chỉnh sửa**

Trong PowerPoint, bạn có thể sử dụng **Edit Points** để sửa một hình vuông:

* Di chuyển một góc vào trong hoặc ra ngoài.
* Điều chỉnh độ cong tại một điểm.
* Thêm các điểm mới.

Chỉnh sửa các điểm cho phép bạn thay đổi đường viền của hình hoặc sử dụng một hình hiện có làm cơ sở cho một hình mới.

## **Mẹo chỉnh sửa Hình**

![overview_image](custom_shape_0.png)

Khi chỉnh sửa các hình PowerPoint, hãy nhớ những khái niệm sau:

* Một hình (hoặc đường dẫn của nó) có thể là đóng hoặc mở.
* Đường dẫn của một hình bao gồm các điểm neo được kết nối bởi các đoạn.
* Một đoạn có thể thẳng hoặc cong. Các điểm neo và tay cầm điều khiển xác định hình dạng của nó.
* Các điểm neo tồn tại dưới dạng điểm góc, điểm thẳng hoặc điểm mượt:
  * Tại một điểm góc, các đoạn liền kề có thể gặp nhau ở một góc.
  * Tại một điểm mượt, hai tay cầm điều khiển được căn chỉnh và cách đều nhau so với điểm neo.
  * Tại một điểm thẳng, hai tay cầm điều khiển được căn chỉnh nhưng có thể có khoảng cách khác nhau so với điểm neo.
* Di chuyển các điểm neo hoặc điều chỉnh các tay cầm của chúng sẽ thay đổi đường viền của hình.

Để chỉnh sửa các hình PowerPoint thông qua các điểm chỉnh sửa, **Aspose.Slides** cung cấp lớp [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/).

* Một đối tượng [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) thể hiện đường dẫn hình học của đối tượng [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/).
* Để lấy [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) từ một thể hiện [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/), bạn có thể sử dụng phương thức [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths).
* Để đặt [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) cho một hình, bạn có thể sử dụng các phương thức: [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) cho các hình có một đường duy nhất và [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) cho các hình có nhiều đường.
* Để thêm các đoạn, bạn có thể sử dụng các phương thức dưới [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/).
* Sử dụng các phương thức [GeometryPath.setStroke](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setStroke) và [GeometryPath.setFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setFillMode), bạn có thể đặt kiểu hiển thị cho một đường hình học.
* Sử dụng phương thức [GeometryPath.getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData), bạn có thể lấy đường dẫn hình học của một [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/) dưới dạng một mảng các đoạn đường.
* Để truy cập các tùy chọn tùy chỉnh hình học bổ sung, bạn có thể đọc một [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) thông qua [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) và phát lại các đoạn trên một [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/).

## **Các thao tác chỉnh sửa đơn giản**

Sử dụng các phương thức sau để chỉnh sửa một đường hình học. Các overload nhận một chỉ mục sẽ chèn một đoạn tại vị trí dựa trên chỉ mục không âm trong mảng các đoạn của đường.

| Thao tác | Phương thức |
| --- | --- |
| Thêm hoặc chèn một đường thẳng. | [GeometryPath.lineTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#lineTo) |
| Thêm hoặc chèn một đường cong Bézier bậc ba với hai điểm điều khiển và một điểm cuối. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#cubicBezierTo) |
| Thêm hoặc chèn một đường cong Bézier bậc hai với một điểm điều khiển và một điểm cuối. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| Thêm một cung elip với các kích thước và góc được chỉ định tính bằng độ. | [GeometryPath.arcTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#arcTo) |
| Đóng hình hiện tại bằng cách kết nối điểm cuối với điểm bắt đầu. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#closeFigure) |
| Đặt điểm bắt đầu của một hình. | [GeometryPath.moveTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#moveTo) |
| Xóa một đoạn tại một chỉ mục không âm. | [GeometryPath.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#removeAt) |

## **Thêm các Điểm Tùy chỉnh vào một Hình**

Ví dụ này chèn hai điểm vào một hình chữ nhật bằng [GeometryPath.lineTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#lineTo) và áp dụng đường đã chỉnh sửa với [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath). Các tọa độ là nội bộ đối với hình: cả hai điểm mới nằm ở trung tâm, cách trái 100 điểm và cách trên 50 điểm. Các chỉ mục đoạn 1 và 4 đặt chúng trên các cạnh trên và dưới, kéo các cạnh này vào trong.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)

    geometry_path = shape.getGeometryPaths()[0]
    geometry_path.lineTo(100, 50, 1)
    geometry_path.lineTo(100, 50, 4)

    shape.setGeometryPath(geometry_path)
finally:
    presentation.dispose()
```

![example1_image](custom_shape_1.png)

## **Xóa các Điểm khỏi một Hình**

Ví dụ này thay đổi đường viền dạng trái tim bằng cách xóa đoạn tại chỉ mục không âm 2 với [GeometryPath.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#removeAt). Áp dụng đường đã sửa với [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) sẽ cập nhật đường viền của hình.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Heart, 100, 100, 300, 300)

    geometry_path = shape.getGeometryPaths()[0]
    geometry_path.removeAt(2)

    shape.setGeometryPath(geometry_path)
finally:
    presentation.dispose()
```
![example2_image](custom_shape_2.png)

## **Tạo một Hình Tùy chỉnh**

Ví dụ này xây dựng một ngôi sao năm góc bằng [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/). Các bán kính ngoài và trong xen kẽ 100 và 50 điểm xác định các đỉnh và các lõm; bước 72 độ tạo ra năm đỉnh đều nhau. Đường được đóng bằng [GeometryPath.closeFigure](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#closeFigure) và áp dụng cho một hình chữ nhật bằng [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath), thay thế đường viền của nó.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath

import math

points = []
outer_radius = 100
inner_radius = 50
angle_step = 72

for angle in range(-90, 270, angle_step):
    radians = math.radians(angle)
    x = outer_radius * math.cos(radians)
    y = outer_radius * math.sin(radians)
    points.append((x + outer_radius, y + outer_radius))

    radians = math.radians(angle + angle_step / 2)
    x = inner_radius * math.cos(radians)
    y = inner_radius * math.sin(radians)
    points.append((x + outer_radius, y + outer_radius))

star_path = GeometryPath()
star_path.moveTo(*points[0])
for point in points[1:]:
    star_path.lineTo(*point)
star_path.closeFigure()

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, outer_radius * 2, outer_radius * 2)
    shape.setGeometryPath(star_path)
finally:
    presentation.dispose()
```
![example3_image](custom_shape_3.png)

## **Tạo một Hình Tùy chỉnh Hợp thành**

Ví dụ này định nghĩa hai đối tượng [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) đóng cho phần trên và phần dưới của một hình. Áp dụng cả hai đường bằng [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) tạo ra một hình hợp thành duy nhất với một khoảng trống ở phần giữa.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)

    top_path = GeometryPath()
    top_path.moveTo(0, 0)
    top_path.lineTo(shape.getWidth(), 0)
    top_path.lineTo(shape.getWidth(), shape.getHeight() / 3)
    top_path.lineTo(0, shape.getHeight() / 3)
    top_path.closeFigure()

    bottom_path = GeometryPath()
    bottom_path.moveTo(0, shape.getHeight() / 3 * 2)
    bottom_path.lineTo(shape.getWidth(), shape.getHeight() / 3 * 2)
    bottom_path.lineTo(shape.getWidth(), shape.getHeight())
    bottom_path.lineTo(0, shape.getHeight())
    bottom_path.closeFigure()

    shape.setGeometryPaths([top_path, bottom_path])
finally:
    presentation.dispose()
```
![example4_image](custom_shape_4.png)

## **Tạo một Hình Tùy chỉnh với Các Góc Cong**

Ví dụ này kết hợp các đoạn thẳng với [GeometryPath.arcTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#arcTo) để tạo một hình có các góc cong vào trong. Mỗi kích thước góc đặt chiều rộng và chiều cao của cung tính bằng điểm, và vòng quét -90 độ vẽ một phần tư elip ngược chiều kim đồng hồ. Đường hoàn chỉnh được áp dụng bằng [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath), và bản trình chiếu được lưu dưới định dạng PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath, SaveFormat

shape_x = 20
shape_y = 20
shape_width = 300
shape_height = 200

left_top_size = 50
right_top_size = 20
right_bottom_size = 40
left_bottom_size = 10

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Custom, shape_x, shape_y, shape_width, shape_height)

    geometry_path = GeometryPath()
    geometry_path.moveTo(left_top_size, 0)
    geometry_path.lineTo(shape_width - right_top_size, 0)
    geometry_path.arcTo(right_top_size, right_top_size, 180, -90)
    geometry_path.lineTo(shape_width, shape_height - right_bottom_size)
    geometry_path.arcTo(right_bottom_size, right_bottom_size, -90, -90)
    geometry_path.lineTo(left_bottom_size, shape_height)
    geometry_path.arcTo(left_bottom_size, left_bottom_size, 0, -90)
    geometry_path.lineTo(0, left_top_size)
    geometry_path.arcTo(left_top_size, left_top_size, 90, -90)
    geometry_path.closeFigure()
    
    shape.setGeometryPath(geometry_path)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Kiểm tra xem Hình học của Hình có Được Đóng không**

Trợ giúp sau đây kiểm tra xem mỗi đường hình học không rỗng có kết thúc bằng một đoạn đóng hay không. Nó đọc [GeometryPath.getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData) và so sánh lệnh cuối cùng của đoạn với [PathSegment.getPathCommand](https://reference.aspose.com/slides/python-java/aspose.slides/pathsegment/#getPathCommand) và [PathCommandType.Close](https://reference.aspose.com/slides/python-java/aspose.slides/pathcommandtype/). Nó trả về `False` khi không có đường không rỗng nào. Kiểm tra này chỉ xem lệnh cuối của mỗi đường; nó không kiểm tra mọi subfigure bên trong một đường. Ví dụ in ra `True` cho một hình chữ nhật.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, PathCommandType

def is_geometry_closed(geometry_shape):
    has_nonempty_path = False
    for geometry_path in geometry_shape.getGeometryPaths():
        path_data = geometry_path.getPathData()
        if len(path_data) == 0:
            continue
        last_segment = path_data[-1]
        has_nonempty_path = True
        if last_segment.getPathCommand() != PathCommandType.Close:
            return False
    return has_nonempty_path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)
    closed = is_geometry_closed(shape)
    print(closed)
finally:
    presentation.dispose()
```

## **Trích xuất và Kiểm tra Các Thành phần của Hình**

Sử dụng [GeometryShape.createShapeElements](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#createShapeElements) để kiểm tra một hình hiện có dưới dạng các phần tử chứa các điểm đường và loại điểm. Ép mỗi phần tử trả về về [ShapeElement](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/) với `jpype.JObject` để lấy các mảng điểm và loại thông qua các phương thức [getPathPoints](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/#getPathPoints) và [getPathTypes](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/#getPathTypes). Đại diện này hữu ích cho việc phân tích đường viền hoặc truyền hình học cho các công cụ vẽ tùy chỉnh.

Ví dụ mở file input.pptx, tìm hình geometry đầu tiên trực tiếp trên slide đầu tiên, và in các đoạn đường của nó. Sử dụng một bản trình chiếu chứa một hình có các đoạn thẳng và cong để xem cả hai loại đầu ra. Nó không tìm kiếm bên trong các nhóm.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, GeometryShape, ShapeElement

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape = None
    for candidate in slide.getShapes():
        if isinstance(candidate, GeometryShape):
            shape = candidate
            break

    if shape is None:
        print("No geometry shape found on the first slide.")
    else:
        for element in shape.createShapeElements():
            shape_element = jpype.JObject(element, ShapeElement)
            points = shape_element.getPathPoints()
            types = shape_element.getPathTypes()
            print("Shape element:")

            i = 0
            while i < len(points):
                point_type = types[i] & 0x07  # Keep the segment type, excluding flags.
                if point_type == 0:
                    print(f"Start figure at {points[i]}")
                elif point_type == 1:
                    print(f"Line to {points[i]}")
                elif point_type == 3:
                    print(f"Cubic Bezier: controls {points[i]}, {points[i + 1]}; end {points[i + 2]}")
                    i += 2  # Consume both control points and the endpoint.

                if types[i] & 0x80:
                    print("Close subpath back to its starting point.")
                i += 1
finally:
    presentation.dispose()
```

Các mảng tương ứng theo chỉ số: `points[i]` là một điểm và `types[i]` mô tả vai trò của nó. Loại `0` bắt đầu một hình, và loại `1` vẽ một đường từ điểm trước đến điểm hiện tại. Một đoạn Bézier bậc ba bắt đầu tại điểm cuối trước và sử dụng ba mục loại `3` liên tiếp: hai điểm điều khiển rồi điểm cuối mới. Vòng lặp tiêu thụ ba mục này cùng nhau và kiểm tra điểm cuối để xác định tính đóng.

Các loại điểm cũng chứa các cờ. Đặt mặt nạ với `0x07` để xác định loại đoạn, và kiểm tra `0x80` riêng để phát hiện một subpath đóng. Ví dụ, `129` (`0x81`) có nghĩa là một điểm cuối của đường thẳng đóng một subpath, và `131` (`0x83`) có nghĩa là một điểm cuối Bézier đóng một subpath. Java lưu các cờ này trong byte có dấu; việc đặt mặt nạ bảo toàn các giá trị bit mong muốn. So sánh giá trị thô chỉ với `1` hoặc `3` sẽ bỏ lỡ những trường hợp này. Các cờ khác, như dash (`0x10`) và marker (`0x20`), không thay đổi loại đoạn cơ bản.

**Tọa độ và phép biến đổi.** Các điểm được đo bằng point (1/72 inch), với trục X tăng về phía bên phải và trục Y tăng xuống. Đối với một hình không được nhóm, các tọa độ đã trích xuất đã bao gồm vị trí trả về bởi [getX](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getX) và [getY](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getY) và phản ánh độ rộng và chiều cao hiện tại của nó. Ví dụ, một hình chữ nhật không xoay tại `(100, 200)` với kích thước `120 × 80` có giới hạn đường viền `(100, 200)`–`(220, 280)`. Không cần cộng lại vị trí của hình nữa. Trừ X và Y của nó để có được tọa độ tương đối với khung không xoay.

Các điểm đã trích xuất không áp dụng việc xoay của hình, được trả về bởi [getRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getRotation), hoặc các phép lật ngang và dọc. Để tái tạo đường viền hiển thị, áp dụng các biến đổi này quanh trung tâm của hình. Đối với các hình được nhóm, cũng phải tính đến ánh xạ tọa độ và các biến đổi của nhóm; không giả định rằng các điểm đã trích xuất là tọa độ cuối cùng trên slide hoặc áp dụng một phép dịch hoặc tỉ lệ hai lần nếu đã được phản ánh trong khung của đối tượng con.

**Kiểm tra so với chỉnh sửa.** Các mảng đã trích xuất mô tả đường viền; thay đổi chúng không cập nhật lại hình gốc. Chọn cách này khi phân tích hoặc mã vẽ của bạn cần các mảng điểm/loại. Sử dụng [getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths) khi bạn cần các lệnh hình học trong hệ tọa độ cục bộ của hình hoặc muốn chỉnh sửa hình học của nó. Áp dụng các đường đã chỉnh sửa qua [setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) hoặc [setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths).

## **Chuyển đổi một Java AWT Shape thành GeometryPath**

Ví dụ này kết hợp một đường viền hình chữ nhật với văn bản được chuyển thành hình học. Phương thức [setFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setFillMode) của đường viền tắt màu nền. Một [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) tạo đường viền văn bản trong một [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html). [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) của nó cung cấp các đoạn di chuyển, line, quadratic, cubic và đóng, mà ví dụ này phát lại trên một [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/).

Văn bản sử dụng phông Arial 40-point. Đường viền được dịch 20 point theo chiều ngang và đặt vị trí sao cho đỉnh hiển thị cách 10 point phía dưới cạnh trên của hình. Đường văn bản được tô đầy, trong khi hình chữ nhật gốc vẫn là một đường viền. Áp dụng cả hai đường bằng [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) tạo ra một hình duy nhất chứa hình chữ nhật và văn bản.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath, PathFillModeType

from java.awt import Font
from java.awt.geom import PathIterator
from java.awt.image import BufferedImage

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100)

    # Lấy đường dẫn hình học của hình.
    original_path = shape.getGeometryPaths()[0]
    original_path.setFillMode(PathFillModeType.None_)

    # Tạo một đường đồ họa mới với văn bản.
    font = Font("Arial", Font.PLAIN, 40)
    text = "Text in shape"
    image = BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB)
    graphics = image.createGraphics()
    try:
        font_context = graphics.getFontRenderContext()
        glyph_vector = font.createGlyphVector(font_context, text)
        text_bounds = glyph_vector.getVisualBounds()
        baseline = -text_bounds.getY() + 10
        graphics_path = glyph_vector.getOutline(20.0, baseline)
    finally:
        graphics.dispose()

    # Chuyển đổi đường đồ họa thành đường dẫn hình học.
    text_path = GeometryPath()
    path_iterator = graphics_path.getPathIterator(None)
    points = jpype.JArray(jpype.JFloat)(6)
    while not path_iterator.isDone():
        segment_type = path_iterator.currentSegment(points)
        if segment_type == PathIterator.SEG_MOVETO:
            text_path.moveTo(points[0], points[1])
        elif segment_type == PathIterator.SEG_LINETO:
            text_path.lineTo(points[0], points[1])
        elif segment_type == PathIterator.SEG_QUADTO:
            text_path.quadraticBezierTo(points[0], points[1], points[2], points[3])
        elif segment_type == PathIterator.SEG_CUBICTO:
            text_path.cubicBezierTo(points[0], points[1], points[2], points[3], points[4], points[5])
        elif segment_type == PathIterator.SEG_CLOSE:
            text_path.closeFigure()
        path_iterator.next()
    text_path.setFillMode(PathFillModeType.Normal)

    # Apply the text path together with the original geometry path.
    shape.setGeometryPaths([original_path, text_path])
finally:
    presentation.dispose()
```
![example5_image](custom_shape_5.png)

## **Câu hỏi thường gặp**

**Điều gì sẽ xảy ra với màu nền và đường viền sau khi thay thế hình học?**

Kiểu vẫn giữ nguyên trên hình; chỉ có đường viền thay đổi. Màu nền và đường viền sẽ tự động áp dụng cho hình học mới.

**Làm thế nào để xoay đúng một hình tùy chỉnh cùng với hình học của nó?**

Sử dụng phương thức [setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setRotation) của hình; hình học sẽ xoay cùng hình vì nó gắn liền với hệ tọa độ của hình.

**Tôi có thể chuyển một hình tùy chỉnh thành hình ảnh để “khóa” kết quả không?**

Có. Xuất phần [slide](/slides/vi/python-java/convert-powerpoint-to-png/) cần thiết hoặc riêng [shape](/slides/vi/python-java/create-shape-thumbnails/) ra định dạng raster; việc này giúp đơn giản hoá công việc với các hình học phức tạp.