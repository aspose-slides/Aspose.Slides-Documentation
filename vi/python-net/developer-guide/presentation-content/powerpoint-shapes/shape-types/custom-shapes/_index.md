---
title: Tùy chỉnh các hình dạng trong bản trình chiếu bằng Python
linktitle: Hình dạng tùy chỉnh
type: docs
weight: 20
url: /vi/python-net/custom-shape/
keywords:
- hình dạng tùy chỉnh
- thêm hình dạng
- tạo hình dạng
- thay đổi hình dạng
- hình học hình dạng
- đường hình học
- các điểm đường
- chỉnh sửa điểm
- thêm điểm
- xóa điểm
- hoạt động chỉnh sửa
- góc cong
- PowerPoint
- OpenDocument
- bản trình chiếu
- Python
- Aspose.Slides
description: "Tạo và tùy chỉnh các hình dạng trong bản trình chiếu PowerPoint và OpenDocument bằng Aspose.Slides cho Python thông qua .NET: đường geometry, góc cong, hình dạng ghép hợp."
---
## **Giới thiệu**

Hãy xem một hình vuông. Trong PowerPoint, sử dụng **Edit Points**, bạn có thể:

* di chuyển góc của hình vuông vào trong hoặc ra ngoài,
* điều chỉnh độ cong của một góc hoặc điểm,
* thêm các điểm mới vào hình vuông,
* thao tác với các điểm của nó.

Bạn có thể áp dụng các thao tác này cho bất kỳ hình dạng nào. Với **Edit Points**, bạn có thể sửa đổi một hình dạng hoặc tạo một hình mới từ một hình dạng hiện có.

## **Mẹo chỉnh sửa hình dạng**

!["Edit Points" command](custom_shape_0.png)

Trước khi bắt đầu chỉnh sửa các hình dạng PowerPoint bằng **Edit Points**, hãy lưu ý các điểm sau về hình dạng:

* Một hình dạng (hoặc đường path của nó) có thể **đóng** hoặc **mở**.
* Một hình dạng đóng không có điểm bắt đầu hay kết thúc; một hình dạng mở có điểm đầu và điểm cuối.
* Mỗi hình dạng có ít nhất hai điểm neo được nối với nhau bằng các đoạn thẳng.
* Một đoạn có thể thẳng hoặc cong; các điểm neo xác định tính chất của đoạn.
* Các điểm neo có thể là **corner**, **smooth**, hoặc **straight**:
  * Điểm **corner** là nơi hai đoạn thẳng gặp nhau tạo góc.
  * Điểm **smooth** có hai tay cầm nằm trên cùng một đường thẳng, và các đoạn liền kề tạo một đường cong mượt. Trong trường hợp này, cả hai tay cầm có cùng khoảng cách tới điểm neo.
  * Điểm **straight** cũng có hai tay cầm thẳng hàng, và các đoạn liền kề tạo một đường cong mượt. Tuy nhiên, các tay cầm không nhất thiết phải có cùng khoảng cách tới điểm neo.
* Bằng cách di chuyển hoặc chỉnh sửa các điểm neo (do đó thay đổi góc của các đoạn), bạn có thể thay đổi hình dáng của hình.

Để chỉnh sửa các hình dạng PowerPoint, Aspose.Slides cung cấp lớp [GeometryPath](https://reference.aspose.com/slides/vi/python-net/aspose.slides/geometrypath/).

* Một đối tượng [GeometryPath](https://reference.aspose.com/slides/vi/python-net/aspose.slides/geometrypath/) đại diện cho đường geometry của một đối tượng [GeometryShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/geometryshape/).
* Để lấy [GeometryPath](https://reference.aspose.com/slides/vi/python-net/aspose.slides/geometrypath/) từ một thể hiện của [GeometryShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/geometryshape/), hãy sử dụng phương thức [GeometryShape.get_geometry_paths](https://reference.aspose.com/slides/vi/python-net/aspose.slides/geometryshape/get_geometry_paths/).
* Để đặt [GeometryPath](https://reference.aspose.com/slides/vi/python-net/aspose.slides/geometrypath/) cho một hình dạng, sử dụng [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/vi/python-net/aspose.slides/geometryshape/set_geometry_path/) cho *solid shapes* và [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/vi/python-net/aspose.slides/geometryshape/set_geometry_paths/) cho *composite shapes*.
* Để thêm các đoạn, sử dụng các phương thức trên lớp [GeometryPath](https://reference.aspose.com/slides/vi/python-net/aspose.slides/geometrypath/).
* Sử dụng các thuộc tính [GeometryPath.stroke](https://reference.aspose.com/slides/vi/python-net/aspose.slides/geometrypath/stroke/) và [GeometryPath.fill_mode](https://reference.aspose.com/slides/vi/python-net/aspose.slides/geometrypath/fill_mode/) để điều khiển cách hiển thị của đường geometry.
* Sử dụng thuộc tính [GeometryPath.path_data](https://reference.aspose.com/slides/vi/python-net/aspose.slides/geometrypath/path_data/) để lấy đường geometry của một hình dạng dưới dạng mảng các đoạn path.

## **Các thao tác chỉnh sửa đơn giản**

Các phương thức sau được sử dụng cho các thao tác chỉnh sửa đơn giản.

**Thêm một đường thẳng** vào cuối một path:

```py
line_to(point)
line_to(x, y)
```

**Thêm một đường thẳng** tại vị trí chỉ định trong một path:

```py    
line_to(point, index)
line_to(x, y, index)
```

**Thêm một đường cong Bezier bậc ba** vào cuối một path:

```py
cubic_bezier_to(point1, point2, point3)
cubic_bezier_to(x1, y1, x2, y2, x3, y3)
```

**Thêm một đường cong Bezier bậc ba** tại vị trí chỉ định trong một path:

```py
cubic_bezier_to(point1, point2, point3, index)
cubic_bezier_to(x1, y1, x2, y2, x3, y3, index)
```

**Thêm một đường cong Bezier bậc hai** vào cuối một path:

```py
quadratic_bezier_to(point1, point2)
quadratic_bezier_to(x1, y1, x2, y2)
```

**Thêm một đường cong Bezier bậc hai** tại vị trí chỉ định trong một path:

```py
quadratic_bezier_to(point1, point2, index)
quadratic_bezier_to(x1, y1, x2, y2, index)
```

**Gắn một cung** vào một path:

```py
arc_to(width, heigth, startAngle, sweepAngle)
```

**Đóng hình hiện tại** trong một path:

```py
close_figure()
```

**Đặt vị trí cho điểm tiếp theo**:

```py
move_to(point)
move_to(x, y)
```

**Xóa đoạn path** tại một chỉ mục cho trước:

```py
remove_at(index)
```

## **Thêm các điểm tùy chỉnh vào hình dạng**

Ở đây bạn sẽ học cách định nghĩa một hình dạng tự do bằng cách thêm chuỗi các điểm của riêng bạn. Bằng cách chỉ định các điểm có thứ tự và loại đoạn (thẳng hoặc cong) và tùy chọn đóng path, bạn có thể vẽ các đồ họa tùy chỉnh chính xác—đa giác, biểu tượng, chú thích, hoặc logo—trực tiếp trên slide của mình.

1. Tạo một thể hiện của lớp [GeometryShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/geometryshape/) và đặt kiểu của nó thành [ShapeType.RECTANGLE](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shapetype/).
2. Lấy một thể hiện [GeometryPath](https://reference.aspose.com/slides/vi/python-net/aspose.slides/geometrypath/) từ hình dạng.
3. Chèn một điểm mới giữa hai điểm trên cùng của path.
4. Chèn một điểm mới giữa hai điểm dưới cùng của path.
5. Áp dụng path đã cập nhật cho hình dạng.

Mã Python sau minh họa cách thêm các điểm tùy chỉnh vào một hình dạng:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)

    geometry_path = shape.get_geometry_paths()[0]
    geometry_path.line_to(100, 50, 1)
    geometry_path.line_to(100, 50, 4)

    shape.set_geometry_path(geometry_path)

    presentation.save("custom_points.pptx", slides.export.SaveFormat.PPTX)
```

![Custom points](custom_shape_1.png)

##  **Xóa các điểm khỏi hình dạng**

Đôi khi một hình dạng tùy chỉnh chứa các điểm không cần thiết gây phức tạp cho geometry hoặc ảnh hưởng đến cách hiển thị. Phần này hướng dẫn cách xóa các điểm cụ thể khỏi path của một hình dạng để bạn có thể đơn giản hoá đường viền và đạt được kết quả sạch sẽ, chính xác hơn.

1. Tạo một thể hiện của lớp [GeometryShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/geometryshape/) và đặt kiểu của nó thành [ShapeType.HEART](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shapetype/).
2. Lấy một thể hiện [GeometryPath](https://reference.aspose.com/slides/vi/python-net/aspose.slides/geometrypath/) từ hình dạng.
3. Xóa một đoạn khỏi path.
4. Áp dụng path đã cập nhật cho hình dạng.

Mã Python sau minh họa cách xóa các điểm khỏi một hình dạng:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.HEART, 100, 100, 300, 300)

    path = shape.get_geometry_paths()[0]
    path.remove_at(2)

    shape.set_geometry_path(path)

    presentation.save("removed_points.pptx", slides.export.SaveFormat.PPTX)
```

![Removed points](custom_shape_2.png)

##  **Tạo hình dạng tùy chỉnh**

Tạo các hình vector độc đáo bằng cách định nghĩa một [GeometryPath](https://reference.aspose.com/slides/vi/python-net/aspose.slides/geometrypath/) và cấu thành nó từ các đường thẳng, cung và đường cong Bézier. Phần này chỉ ra cách xây dựng một geometry tùy chỉnh từ đầu và thêm hình dạng kết quả vào slide của bạn.

1. Tính toán các điểm cho hình dạng.
2. Tạo một thể hiện của lớp [GeometryPath](https://reference.aspose.com/slides/vi/python-net/aspose.slides/geometrypath/).
3. Điền các điểm vào path.
4. Tạo một thể hiện của lớp [GeometryShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/geometryshape/).
5. Áp dụng path cho hình dạng.

Mã Python sau minh họa cách tạo một hình dạng tùy chỉnh:

```py
import aspose.slides as slides
import aspose.pydrawing as draw
import math

points = []

R = 100
r = 50
step = 72

for angle in range(-90, 270, step):
    radians = angle * (math.pi / 180)
    x = R * math.cos(radians)
    y = R * math.sin(radians)
    points.append(draw.PointF(x + R, y + R))

    radians = math.pi * (angle + step / 2) / 180.0
    x = r * math.cos(radians)
    y = r * math.sin(radians)
    points.append(draw.PointF(x + R, y + R))

star_path = slides.GeometryPath()
star_path.move_to(points[0])

for i in range(len(points)):
    star_path.line_to(points[i])

star_path.close_figure()

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, R * 2, R * 2)
    shape.set_geometry_path(star_path)

    presentation.save("custom_shape.pptx", slides.export.SaveFormat.PPTX)
```

![Custom shape](custom_shape_3.png)

## **Tạo các hình dạng tùy chỉnh ghép hợp**

Tạo một hình dạng tùy chỉnh ghép hợp cho phép bạn kết hợp nhiều đường geometry thành một hình dạng duy nhất, có thể tái sử dụng trên slide. Định nghĩa và hợp nhất các path này để xây dựng các hình ảnh phức tạp vượt qua bộ hình dạng tiêu chuẩn.

1. Tạo một thể hiện của lớp [GeometryShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/geometryshape/).
2. Tạo thể hiện đầu tiên của lớp [GeometryPath](https://reference.aspose.com/slides/vi/python-net/aspose.slides/geometrypath/).
3. Tạo thể hiện thứ hai của lớp [GeometryPath](https://reference.aspose.com/slides/vi/python-net/aspose.slides/geometrypath/).
4. Áp dụng cả hai path cho hình dạng.

Mã Python sau minh họa cách tạo một hình dạng tùy chỉnh ghép hợp:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)

    geometry_path_0 = slides.GeometryPath()
    geometry_path_0.move_to(0, 0)
    geometry_path_0.line_to(shape.width, 0)
    geometry_path_0.line_to(shape.width, shape.height/3)
    geometry_path_0.line_to(0, shape.height / 3)
    geometry_path_0.close_figure()

    geometry_path_1 = slides.GeometryPath()
    geometry_path_1.move_to(0, shape.height/3 * 2)
    geometry_path_1.line_to(shape.width, shape.height / 3 * 2)
    geometry_path_1.line_to(shape.width, shape.height)
    geometry_path_1.line_to(0, shape.height)
    geometry_path_1.close_figure()

    shape.set_geometry_paths([ geometry_path_0, geometry_path_1])

    presentation.save("composite_shape.pptx", slides.export.SaveFormat.PPTX)
```

![Composite shape](custom_shape_4.png)

## **Tạo các hình dạng tùy chỉnh với các góc cong**

Phần này chỉ ra cách vẽ một hình dạng tùy chỉnh với các góc cong mượt mà bằng một geometry path. Bạn sẽ kết hợp các đoạn thẳng và các cung tròn để tạo ra đường viền và thêm hình dạng hoàn chỉnh vào slide.

Mã Python sau minh họa cách tạo một hình dạng tùy chỉnh với các góc cong:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

shape_x = 20
shape_y = 20
shape_width = 300
shape_height = 200

left_top_size = 50
right_top_size = 20
right_bottom_size = 40
left_bottom_size = 10

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(
        slides.ShapeType.CUSTOM, shape_x, shape_y, shape_width, shape_height)

    point1 = draw.PointF(left_top_size, 0)
    point2 = draw.PointF(shape_width - right_top_size, 0)
    point3 = draw.PointF(shape_width, shape_height - right_bottom_size)
    point4 = draw.PointF(left_bottom_size, shape_height)
    point5 = draw.PointF(0, left_top_size)

    geometry_path = slides.GeometryPath()
    geometry_path.move_to(point1)
    geometry_path.line_to(point2)
    geometry_path.arc_to(right_top_size, right_top_size, 180, -90)
    geometry_path.line_to(point3)
    geometry_path.arc_to(right_bottom_size, right_bottom_size, -90, -90)
    geometry_path.line_to(point4)
    geometry_path.arc_to(left_bottom_size, left_bottom_size, 0, -90)
    geometry_path.line_to(point5)
    geometry_path.arc_to(left_top_size, left_top_size, 90, -90)
    geometry_path.close_figure()

    shape.set_geometry_path(geometry_path)

    presentation.save("curved_corners.pptx", slides.export.SaveFormat.PPTX)
```

![Curved corners](custom_shape_6.png)

## **Xác định liệu geometry của một hình dạng có bị đóng hay không**

Một hình dạng đóng được định nghĩa là hình mà tất cả các cạnh của nó kết nối với nhau, tạo thành một ranh giới duy nhất không có khoảng trống. Hình dạng như vậy có thể là một hình học đơn giản hoặc một đường viền tùy chỉnh phức tạp. Đoạn mã dưới đây cho thấy cách kiểm tra xem geometry của một hình dạng có bị đóng hay không:

```py
def is_geometry_closed(geometry_shape):
    is_closed = None

    for geometry_path in geometry_shape.get_geometry_paths():
        data_length = len(geometry_path.path_data)
        if data_length == 0:
            continue

        last_segment = geometry_path.path_data[data_length - 1]
        is_closed = last_segment.path_command == PathCommandType.CLOSE

        if not is_closed:
            return False

    return is_closed
```

## **FAQ**

**Điều gì sẽ xảy ra với màu nền và viền sau khi thay thế geometry?**

Kiểu dáng vẫn giữ với hình dạng; chỉ có đường viền thay đổi. Màu nền và viền sẽ tự động được áp dụng cho geometry mới.

**Làm thế nào để xoay một hình dạng tùy chỉnh cùng với geometry của nó một cách đúng?**

Sử dụng thuộc tính [rotation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/geometryshape/rotation/) của hình dạng; geometry sẽ quay cùng với hình dạng vì nó được gắn vào hệ tọa độ của chính hình dạng.

**Tôi có thể chuyển đổi một hình dạng tùy chỉnh thành hình ảnh để "khóa" kết quả không?**

Có. Xuất khu vực [slide](/slides/vi/python-net/convert-powerpoint-to-png/) cần thiết hoặc chính [shape](/slides/vi/python-net/create-shape-thumbnails/) sang định dạng raster; việc này sẽ đơn giản hoá công việc tiếp theo với các geometry phức tạp.