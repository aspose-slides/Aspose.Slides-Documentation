---
title: Tùy chỉnh hình dạng trình chiếu trong Python thông qua Java
linktitle: Hình dạng tùy chỉnh
type: docs
weight: 20
url: /vi/python-java/custom-shape/
keywords:
- hình dạng tùy chỉnh
- thêm hình dạng
- tạo hình dạng
- thay đổi hình dạng
- hình học của hình dạng
- đường dẫn hình học
- các điểm đường dẫn
- điểm chỉnh sửa
- thêm điểm
- xóa điểm
- hoạt động chỉnh sửa
- góc cong
- PowerPoint
- bản trình chiếu
- Python
- Aspose.Slides
description: "Tạo và tùy chỉnh các hình dạng trong bản trình chiếu PowerPoint bằng Aspose.Slides cho Python thông qua Java: đường dẫn hình học, góc cong, hình dạng tổng hợp."
---
## **Tổng quan**

Bài viết này giải thích cách tùy chỉnh các hình dạng trong bản trình bày Aspose.Slides bằng cách chỉnh sửa hình học của hình thông qua các **điểm chỉnh sửa** và **đường dẫn hình học**. Nó chỉ ra cách làm việc với [GeometryPath](https://reference.aspose.com/slides/vi/python-java/aspose.slides/geometrypath/) để sửa đổi các hình hiện có, thực hiện các thao tác chỉnh sửa đường dẫn cơ bản, thêm hoặc xóa các điểm, và áp dụng hình học đã cập nhật trở lại cho một hình dạng.

Nó cũng trình bày cách tạo các hình dạng tùy chỉnh và tổng hợp, xây dựng các hình dạng với góc cong, xác định xem hình học của một hình dạng có đóng không, và chuyển đổi giữa [GeometryPath](https://reference.aspose.com/slides/vi/python-java/aspose.slides/geometrypath/) và [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) cho các kịch bản tùy chỉnh hình học bổ sung.

## **Thay đổi một Hình bằng Điểm Chỉnh sửa**

Xem xét một hình vuông. Trong PowerPoint, bằng cách sử dụng **điểm chỉnh sửa**, bạn có thể 

* di chuyển góc của hình vuông ra vào
* chỉ định độ cong cho một góc hoặc một điểm
* thêm các điểm mới vào hình vuông
* thao tác các điểm trên hình vuông, v.v. 

Về cơ bản, bạn có thể thực hiện các nhiệm vụ đã mô tả trên bất kỳ hình dạng nào. Sử dụng điểm chỉnh sửa, bạn có thể thay đổi một hình dạng hoặc tạo một hình dạng mới từ một hình dạng hiện có. 

## **Mẹo Chỉnh sửa Hình**

![overview_image](custom_shape_0.png)

Trước khi bắt đầu chỉnh sửa các hình dạng PowerPoint thông qua điểm chỉnh sửa, bạn có thể muốn cân nhắc những điểm sau về các hình dạng:

* Một hình dạng (hoặc đường dẫn của nó) có thể là **đóng** hoặc **mở**.
* Khi một hình dạng đóng, nó không có điểm bắt đầu hay kết thúc. Khi một hình dạng mở, nó có điểm đầu và điểm cuối. 
* Tất cả các hình dạng đều bao gồm ít nhất 2 điểm neo được liên kết với nhau bằng các đường thẳng.
* Một đường thẳng có thể là **thẳng** hoặc **cong**. Các điểm neo quyết định tính chất của đường. 
* Các điểm neo tồn tại dưới dạng **điểm góc**, **điểm thẳng**, hoặc **điểm mượt**:
  * Điểm góc là điểm mà 2 đường thẳng nối với nhau tạo thành một góc. 
  * Điểm mượt là điểm mà 2 tay cầm nằm trên một đường thẳng và các đoạn của đường nối nhau tạo thành một đường cong mượt. Trong trường hợp này, tất cả các tay cầm được cách điểm neo một khoảng cách bằng nhau. 
  * Điểm thẳng là điểm mà 2 tay cầm nằm trên một đường thẳng và các đoạn của đường nối nhau tạo thành một đường cong mượt. Trong trường hợp này, các tay cầm không cần phải cách điểm neo một khoảng cách bằng nhau. 
* Bằng cách di chuyển hoặc chỉnh sửa các điểm neo (điều này thay đổi góc của các đường), bạn có thể thay đổi diện mạo của một hình dạng. 

Để chỉnh sửa các hình dạng PowerPoint thông qua điểm chỉnh sửa, **Aspose.Slides** cung cấp lớp [GeometryPath](https://reference.aspose.com/slides/vi/python-java/aspose.slides/geometrypath/). 

* Một thực thể [GeometryPath](https://reference.aspose.com/slides/vi/python-java/aspose.slides/geometrypath/) đại diện cho đường dẫn hình học của đối tượng [GeometryShape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/geometryshape/). 
* Để lấy [GeometryPath](https://reference.aspose.com/slides/vi/python-java/aspose.slides/geometrypath/) từ thực thể [GeometryShape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/geometryshape/), bạn có thể sử dụng phương thức [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/vi/python-java/aspose.slides/geometryshape/#getGeometryPaths). 
* Để đặt [GeometryPath](https://reference.aspose.com/slides/vi/python-java/aspose.slides/geometrypath/) cho một hình dạng, bạn có thể sử dụng các phương thức: [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/vi/python-java/aspose.slides/geometryshape/#setGeometryPath) cho *hình dạng rắn* và [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/vi/python-java/aspose.slides/geometryshape/#setGeometryPaths) cho *hình dạng tổng hợp*.
* Để thêm các đoạn, bạn có thể sử dụng các phương thức dưới [GeometryPath](https://reference.aspose.com/slides/vi/python-java/aspose.slides/geometrypath/). 
* Bằng cách sử dụng các phương thức [GeometryPath.setStroke](https://reference.aspose.com/slides/vi/python-java/aspose.slides/geometrypath/#setStroke) và [GeometryPath.setFillMode](https://reference.aspose.com/slides/vi/python-java/aspose.slides/geometrypath/#setFillMode), bạn có thể thiết lập giao diện cho một đường dẫn hình học.
* Bằng cách sử dụng phương thức [GeometryPath.getPathData](https://reference.aspose.com/slides/vi/python-java/aspose.slides/geometrypath/#getPathData), bạn có thể lấy đường dẫn hình học của một [GeometryShape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/geometryshape/) dưới dạng một mảng các đoạn đường. 
* Để truy cập các tùy chọn tùy chỉnh hình học của hình dạng bổ sung, bạn có thể chuyển đổi [GeometryPath](https://reference.aspose.com/slides/vi/python-java/aspose.slides/geometrypath/) sang [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html)
* Sử dụng các phương thức [geometryPathToGraphicsPath](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapeutil/) và [graphicsPathToGeometryPath](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapeutil/) (từ lớp [ShapeUtil](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapeutil/)) để chuyển đổi [GeometryPath](https://reference.aspose.com/slides/vi/python-java/aspose.slides/geometrypath/) sang [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) và ngược lại. 

## **Các Thao tác Chỉnh sửa Cơ bản**

Các chữ ký sau hiển thị các thao tác chỉnh sửa cơ bản:

**Thêm một đoạn thẳng** vào cuối một đường dẫn:

- `geometry_path.lineTo(point)`
- `geometry_path.lineTo(x, y)`

**Thêm một đoạn thẳng** tại vị trí xác định trên đường dẫn:

- `geometry_path.lineTo(point, index)`
- `geometry_path.lineTo(x, y, index)`

**Thêm một đường cong Bezier bậc ba** vào cuối một đường dẫn:

- `geometry_path.cubicBezierTo(point1, point2, point3)`
- `geometry_path.cubicBezierTo(x1, y1, x2, y2, x3, y3)`

**Thêm một đường cong Bezier bậc ba** tại vị trí xác định trên đường dẫn:

- `geometry_path.cubicBezierTo(point1, point2, point3, index)`
- `geometry_path.cubicBezierTo(x1, y1, x2, y2, x3, y3, index)`

**Thêm một đường cong Bezier bậc hai** vào cuối một đường dẫn:

- `geometry_path.quadraticBezierTo(point1, point2)`
- `geometry_path.quadraticBezierTo(x1, y1, x2, y2)`

**Thêm một đường cong Bezier bậc hai** tại vị trí xác định trên đường dẫn:

- `geometry_path.quadraticBezierTo(point1, point2, index)`
- `geometry_path.quadraticBezierTo(x1, y1, x2, y2, index)`

**Gắn một cung đã cho** vào đường dẫn:

- `geometry_path.arcTo(width, height, start_angle, sweep_angle)`

**Đóng hình hiện tại** của một đường dẫn:

- `geometry_path.closeFigure()`

**Đặt vị trí cho điểm tiếp theo**:

- `geometry_path.moveTo(point)`
- `geometry_path.moveTo(x, y)`

**Xóa đoạn đường** tại một chỉ mục cho trước:

- `geometry_path.removeAt(index)`


## **Thêm Điểm Tùy chỉnh vào Hình dạng**
1. Tạo một thực thể của lớp [GeometryShape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/geometryshape/) và đặt loại [ShapeType.Rectangle](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapetype/#Rectangle).
2. Lấy một thực thể của lớp [GeometryPath](https://reference.aspose.com/slides/vi/python-java/aspose.slides/geometrypath/) từ hình dạng.
3. Thêm một điểm mới giữa hai điểm trên cùng của đường dẫn.
4. Thêm một điểm mới giữa hai điểm dưới cùng của đường dẫn.
5. Áp dụng đường dẫn lên hình dạng.

Đoạn mã Python sau cho bạn thấy cách thêm các điểm tùy chỉnh vào một hình dạng:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)
    geometry_path = shape.getGeometryPaths()[0]
    geometry_path.lineTo(100, 50, 1)
    geometry_path.lineTo(100, 50, 4)
    shape.setGeometryPath(geometry_path)
finally:
    presentation.dispose()
```
![example1_image](custom_shape_1.png)

## **Xóa Điểm khỏi Hình dạng**

1. Tạo một thực thể của lớp [GeometryShape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/geometryshape/) và đặt loại [ShapeType.Heart](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapetype/#Heart). 
2. Lấy một thực thể của lớp [GeometryPath](https://reference.aspose.com/slides/vi/python-java/aspose.slides/geometrypath/) từ hình dạng.
3. Xóa đoạn cho đường dẫn.
4. Áp dụng đường dẫn lên hình dạng.

Đoạn mã Python sau cho bạn thấy cách xóa các điểm khỏi một hình dạng:

```python
import jpime
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Heart, 100, 100, 300, 300)
    geometry_path = shape.getGeometryPaths()[0]
    geometry_path.removeAt(2)
    shape.setGeometryPath(geometry_path)
finally:
    presentation.dispose()
```
![example2_image](custom_shape_2.png)

## **Tạo một Hình dạng Tùy chỉnh**

1. Tính toán các điểm cho hình dạng.
2. Tạo một thực thể của lớp [GeometryPath](https://reference.aspose.com/slides/vi/python-java/aspose.slides/geometrypath/). 
3. Điền các điểm vào đường dẫn.
4. Tạo một thực thể của lớp [GeometryShape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/geometryshape/). 
5. Áp dụng đường dẫn lên hình dạng.

Đoạn mã Python sau cho bạn thấy cách tạo một hình dạng tùy chỉnh:

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
step = 72

for angle in range(-90, 270, step):
    radians = math.radians(angle)
    x = outer_radius * math.cos(radians)
    y = outer_radius * math.sin(radians)
    points.append((x + outer_radius, y + outer_radius))

    radians = math.radians(angle + step / 2)
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
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, outer_radius * 2, outer_radius * 2)
    shape.setGeometryPath(star_path)
finally:
    presentation.dispose()
```
![example3_image](custom_shape_3.png)


## **Tạo một Hình dạng Tổng hợp Tùy chỉnh**

  1. Tạo một thực thể của lớp [GeometryShape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/geometryshape/).
  2. Tạo một thực thể đầu tiên của lớp [GeometryPath](https://reference.aspose.com/slides/vi/python-java/aspose.slides/geometrypath/).
  3. Tạo một thực thể thứ hai của lớp [GeometryPath](https://reference.aspose.com/slides/vi/python-java/aspose.slides/geometrypath/).
  4. Áp dụng các đường dẫn lên hình dạng.

Đoạn mã Python sau cho bạn thấy cách tạo một hình dạng tổng hợp tùy chỉnh:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)

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

## **Tạo một Hình dạng Tùy chỉnh với Các Góc Cong**

Đoạn mã Python sau cho bạn thấy cách tạo một hình dạng tùy chỉnh với các góc cong (ngược vào trong):

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
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Custom, shape_x, shape_y, shape_width, shape_height)
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

## **Xác định Hình dạng Có Đóng Hay Không**

Một hình dạng đóng được định nghĩa là hình mà tất cả các cạnh của nó kết nối lại, tạo thành một ranh giới duy nhất không có khoảng trống. Hình dạng như vậy có thể là một hình học đơn giản hoặc một đường viền tùy chỉnh phức tạp. Đoạn mã dưới đây cho thấy cách kiểm tra xem hình dạng có đóng hay không:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PathCommandType

def is_geometry_closed(geometry_shape):
    is_closed = False
    for geometry_path in geometry_shape.getGeometryPaths():
        path_data = geometry_path.getPathData()
        if len(path_data) == 0:
            continue
        last_segment = path_data[-1]
        is_closed = last_segment.getPathCommand() == PathCommandType.Close
        if not is_closed:
            return False
    return is_closed
```

## **Chuyển đổi GeometryPath sang java.awt.Shape** 

1. Tạo một thực thể của lớp [GeometryShape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/geometryshape/).
2. Tạo một thực thể của lớp [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html).
3. Chuyển đổi thực thể [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) sang thực thể [GeometryPath](https://reference.aspose.com/slides/vi/python-java/aspose.slides/geometrypath/) bằng cách duyệt [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) và tái hiện mỗi đoạn trên đường dẫn.
4. Áp dụng các đường dẫn lên hình dạng.

Đoạn mã Python sau thực hiện các bước trên để chuyển đổi một đường đồ họa sang đường geometry:

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
    # Tạo một hình dạng mới.
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100)

    # Lấy đường dẫn hình học của hình dạng.
    original_path = shape.getGeometryPaths()[0]
    original_path.setFillMode(PathFillModeType.None_)

    # Tạo một đường đồ họa mới với văn bản.
    font = Font("Arial", Font.PLAIN, 40)
    text = "Text in shape"
    image = BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB)
    graphics = image.createGraphics()
    try:
        glyph_vector = font.createGlyphVector(graphics.getFontRenderContext(), text)
        graphics_path = glyph_vector.getOutline(20.0, -glyph_vector.getVisualBounds().getY() + 10)
    finally:
        graphics.dispose()

    # Chuyển đổi đường đồ họa sang đường hình học.
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

    # Áp dụng đường văn bản cùng với đường hình học gốc.
    shape.setGeometryPaths([original_path, text_path])
finally:
    presentation.dispose()
```
![example5_image](custom_shape_5.png)

## **Câu hỏi thường gặp**

**Điều gì sẽ xảy ra với màu nền và viền sau khi thay thế hình học?**

Kiểu dáng vẫn giữ nguyên với hình; chỉ đường viền thay đổi. Màu nền và viền sẽ tự động được áp dụng cho hình học mới.

**Làm thế nào để xoay đúng một hình dạng tùy chỉnh cùng với hình học của nó?**

Sử dụng phương thức [setRotation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#setRotation) của hình; hình học sẽ quay cùng với hình vì nó được gắn vào hệ tọa độ của chính hình.

**Tôi có thể chuyển đổi một hình dạng tùy chỉnh thành ảnh để “khóa” kết quả không?**

Có. Xuất vùng [slide](/slides/vi/python-java/convert-powerpoint-to-png/) cần thiết hoặc chính [shape](/slides/vi/python-java/create-shape-thumbnails/) ra định dạng raster; việc này giúp đơn giản hoá các thao tác tiếp theo với các hình học phức tạp.