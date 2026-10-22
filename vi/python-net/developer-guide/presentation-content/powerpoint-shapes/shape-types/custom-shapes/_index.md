---
title: Tùy chỉnh hình dạng trong bản trình chiếu bằng Python
linktitle: Hình dạng tùy chỉnh
type: docs
weight: 20
url: /vi/python-net/custom-shape/
keywords:
- hình dạng tùy chỉnh
- thêm hình
- tạo hình
- thay đổi hình
- hình học của hình
- đường dẫn hình học
- điểm đường dẫn
- điểm chỉnh sửa
- thêm điểm
- xóa điểm
- hoạt động chỉnh sửa
- góc cong
- PowerPoint
- bản trình chiếu
- Python
- Aspose.Slides
description: "Tạo và tùy chỉnh các hình dạng trong bản trình chiếu PowerPoint bằng Aspose.Slides cho Python qua .NET: đường dẫn hình học, góc cong, hình hợp thành."
---
## **Tổng quan**

Bài viết này giải thích cách tùy chỉnh các hình dạng trong bài thuyết trình bằng Aspose.Slides bằng cách chỉnh sửa hình học của hình thông qua các điểm chỉnh sửa và các đường dẫn hình học. Nó cho thấy cách làm việc với [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) để sửa đổi các hình hiện có, thực hiện các thao tác chỉnh sửa đường cơ bản, thêm hoặc xóa điểm, và áp dụng hình học đã cập nhật trở lại cho một hình.

Nó cũng minh họa cách tạo các hình tùy chỉnh và hợp thành, xây dựng các hình có góc cong, xác định xem hình học của một hình có đóng không, và trích xuất các phần tử hình để phân tích đường viền.

## **Thay đổi một hình bằng các điểm chỉnh sửa**

Trong PowerPoint, bạn có thể sử dụng **Edit Points** để chỉnh sửa một hình vuông:

* Di chuyển một góc vào trong hoặc ra ngoài.
* Điều chỉnh độ cong tại một điểm.
* Thêm các điểm mới.

Chỉnh sửa các điểm cho phép bạn sửa đổi đường viền của một hình hoặc sử dụng một hình hiện có làm cơ sở cho một hình mới.

## **Mẹo chỉnh sửa hình dạng**

![overview_image](custom_shape_0.png)

Khi chỉnh sửa các hình PowerPoint, hãy ghi nhớ các khái niệm sau:

* Một hình (hoặc đường dẫn của nó) có thể là đóng hoặc mở.
* Đường dẫn của một hình bao gồm các điểm neo được nối bởi các đoạn.
* Một đoạn có thể thẳng hoặc cong. Các điểm neo và tay cầm điều khiển xác định hình dạng của nó.
* Các điểm neo tồn tại dưới dạng điểm góc, điểm thẳng hoặc điểm mượt:
  * Tại một điểm góc, các đoạn liền kề có thể gặp nhau tạo thành một góc.
  * Tại một điểm mượt, hai tay cầm điều khiển được sắp thẳng hàng và cách đều điểm neo.
  * Tại một điểm thẳng, hai tay cầm điều khiển được sắp thẳng hàng nhưng có thể có khoảng cách khác nhau tới điểm neo.
* Di chuyển các điểm neo hoặc điều chỉnh các tay cầm của chúng sẽ thay đổi đường viền của hình.

Để chỉnh sửa các hình PowerPoint thông qua các điểm chỉnh sửa, **Aspose.Slides** cung cấp lớp [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/).

* Một thể hiện [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) đại diện cho một đường dẫn hình học của đối tượng [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/).
* Để lấy [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) từ thể hiện [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/), bạn có thể sử dụng phương thức [GeometryShape.get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/).
* Để đặt [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) cho một hình, bạn có thể sử dụng các phương thức: [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) cho các hình có một đường và [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) cho các hình có nhiều đường.
* Để thêm các đoạn, bạn có thể sử dụng các phương thức dưới [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/).
* Bằng cách sử dụng các thuộc tính [GeometryPath.stroke](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/stroke/) và [GeometryPath.fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/fill_mode/), bạn có thể đặt kiểu hiển thị cho một đường dẫn hình học.
* Bằng cách sử dụng thuộc tính [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/), bạn có thể lấy đường dẫn hình học của một [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) dưới dạng một mảng các đoạn đường.

## **Các thao tác chỉnh sửa đơn giản**

Sử dụng các phương thức sau để chỉnh sửa một đường dẫn hình học. Các phiên bản chấp nhận chỉ mục sẽ chèn một đoạn tại vị trí bắt đầu từ 0 trong mảng đoạn của đường dẫn.

| Thao tác | Phương thức |
| --- | --- |
| Thêm hoặc chèn một đường thẳng. | [GeometryPath.line_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/line_to/) |
| Thêm hoặc chèn một đường cong Bézier bậc ba với hai điểm điều khiển và một điểm cuối. | [GeometryPath.cubic_bezier_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/cubic_bezier_to/) |
| Thêm hoặc chèn một đường cong Bézier bậc hai với một điểm điều khiển và một điểm cuối. | [GeometryPath.quadratic_bezier_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/quadratic_bezier_to/) |
| Thêm một cung elip với kích thước và góc đã chỉ định tính bằng độ. | [GeometryPath.arc_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/arc_to/) |
| Đóng hình hiện tại bằng cách nối điểm cuối của nó với điểm bắt đầu. | [GeometryPath.close_figure](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/close_figure/) |
| Đặt điểm bắt đầu của một hình. | [GeometryPath.move_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/move_to/) |
| Xóa một đoạn tại chỉ mục bắt đầu từ 0. | [GeometryPath.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/remove_at/) |

## **Thêm các điểm tùy chỉnh vào một hình**

Ví dụ này chèn hai điểm vào một hình chữ nhật bằng cách sử dụng [GeometryPath.line_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/line_to/) và áp dụng đường đã chỉnh sửa với [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/). Các tọa độ là nội bộ của hình: cả hai điểm mới đều nằm ở trung tâm của nó, cách lề trái 100 điểm và cách lề trên 50 điểm. Các chỉ mục đoạn 1 và 4 đặt chúng trên các cạnh trên và dưới, kéo các cạnh đó vào trong.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)

    geometry_path = shape.get_geometry_paths()[0]
    geometry_path.line_to(100, 50, 1)
    geometry_path.line_to(100, 50, 4)

    shape.set_geometry_path(geometry_path)
```

![example1_image](custom_shape_1.png)

## **Xóa các điểm khỏi một hình**

Ví dụ này thay đổi đường viền hình tim bằng cách xóa đoạn tại chỉ mục bắt đầu từ 0 là 2 với [GeometryPath.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/remove_at/). Áp dụng đường đã sửa đổi với [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) sẽ cập nhật đường viền của hình.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.HEART, 100, 100, 300, 300)

    path = shape.get_geometry_paths()[0]
    path.remove_at(2)

    shape.set_geometry_path(path)
```
![example2_image](custom_shape_2.png)

## **Tạo một hình tùy chỉnh**

Ví dụ này xây dựng một ngôi sao năm cánh bằng [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/). Các bán kính ngoài và trong xen kẽ 100 và 50 điểm xác định các đầu nhọn và các vết lõm; bước 72 độ làm cho năm đầu nhọn được cách đều nhau. Đường được đóng bằng [GeometryPath.close_figure](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/close_figure/) và áp dụng vào một hình chữ nhật bằng [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/), thay thế đường viền ban đầu.

```python
import aspose.slides as slides
import aspose.pydrawing as draw
import math

points = []

outer_radius = 100
inner_radius = 50
angle_step = 72

for angle in range(-90, 270, angle_step):
    radians = angle * (math.pi / 180)
    x = outer_radius * math.cos(radians)
    y = outer_radius * math.sin(radians)
    points.append(slides.PointF(x + outer_radius, y + outer_radius))

    radians = math.pi * (angle + angle_step / 2) / 180.0
    x = inner_radius * math.cos(radians)
    y = inner_radius * math.sin(radians)
    points.append(slides.PointF(x + outer_radius, y + outer_radius))

star_path = slides.GeometryPath()
star_path.move_to(points[0])

for i in range(1, len(points)):
    star_path.line_to(points[i])

star_path.close_figure()

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, outer_radius * 2, outer_radius * 2)
    shape.set_geometry_path(star_path)
```
![example3_image](custom_shape_3.png)

## **Tạo một hình hợp thành tùy chỉnh**

Ví dụ này định nghĩa hai đối tượng [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) đóng cho phần trên và phần dưới của một hình. Áp dụng cả hai đường bằng [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) tạo ra một hình hợp thành duy nhất với một khoảng trống ở phần giữa của nó.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)

    top_path = slides.GeometryPath()
    top_path.move_to(0, 0)
    top_path.line_to(shape.width, 0)
    top_path.line_to(shape.width, shape.height / 3)
    top_path.line_to(0, shape.height / 3)
    top_path.close_figure()

    bottom_path = slides.GeometryPath()
    bottom_path.move_to(0, shape.height / 3 * 2)
    bottom_path.line_to(shape.width, shape.height / 3 * 2)
    bottom_path.line_to(shape.width, shape.height)
    bottom_path.line_to(0, shape.height)
    bottom_path.close_figure()

    shape.set_geometry_paths([top_path, bottom_path])
```
![example4_image](custom_shape_4.png)

## **Tạo một hình tùy chỉnh với các góc cong**

Ví dụ này kết hợp các đoạn thẳng với [GeometryPath.arc_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/arc_to/) để tạo một hình có các góc cong vào trong. Kích thước mỗi góc đặt chiều rộng và chiều cao của cung tính bằng điểm, và góc quét -90 độ vẽ một phần tư elip ngược chiều kim đồng hồ. Đường đã hoàn thành được áp dụng bằng [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/), và bản trình bày được lưu ở định dạng PPTX.

```python
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

    shape = slide.shapes.add_auto_shape(slides.ShapeType.CUSTOM, shape_x, shape_y, shape_width, shape_height)

    top_left = slides.PointF(left_top_size, 0)
    top_right = slides.PointF(shape_width - right_top_size, 0)
    right_bottom = slides.PointF(shape_width, shape_height - right_bottom_size)
    bottom_left = slides.PointF(left_bottom_size, shape_height)
    left_top = slides.PointF(0, left_top_size)

    geometry_path = slides.GeometryPath()
    geometry_path.move_to(top_left)
    geometry_path.line_to(top_right)
    geometry_path.arc_to(right_top_size, right_top_size, 180, -90)
    geometry_path.line_to(right_bottom)
    geometry_path.arc_to(right_bottom_size, right_bottom_size, -90, -90)
    geometry_path.line_to(bottom_left)
    geometry_path.arc_to(left_bottom_size, left_bottom_size, 0, -90)
    geometry_path.line_to(left_top)
    geometry_path.arc_to(left_top_size, left_top_size, 90, -90)
    geometry_path.close_figure()

    shape.set_geometry_path(geometry_path)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Kiểm tra xem hình học của một hình có đóng không**

Trợ giúp sau kiểm tra xem mỗi đường hình học không rỗng có kết thúc bằng một đoạn đóng hay không. Nó đọc [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) và so sánh lệnh cuối cùng của đoạn với [PathSegment.path_command](https://reference.aspose.com/slides/python-net/aspose.slides/pathsegment/path_command/) so với [PathCommandType.CLOSE](https://reference.aspose.com/slides/python-net/aspose.slides/pathcommandtype/). Nó trả về false khi không có đường không rỗng. Kiểm tra này chỉ xem lệnh cuối của mỗi đường; nó không kiểm tra mọi tiểu hình bên trong một đường. Ví dụ in ra `True` cho một hình chữ nhật.

```python
import aspose.slides as slides


def is_geometry_closed(geometry_shape):
    has_nonempty_path = False

    for geometry_path in geometry_shape.get_geometry_paths():
        segments = geometry_path.path_data
        if len(segments) == 0:
            continue

        has_nonempty_path = True
        last_segment = segments[len(segments) - 1]
        if last_segment.path_command != slides.PathCommandType.CLOSE:
            return False

    return has_nonempty_path


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)
    print(is_geometry_closed(shape))
```

## **Trích xuất và kiểm tra các phần tử hình**

Sử dụng [GeometryShape.create_shape_elements](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/create_shape_elements/) để kiểm tra một hình hiện có như các phần tử chứa các điểm đường và kiểu điểm. Mỗi [ShapeElement](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/) trả về sẽ hiển thị các mảng [path_points](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/path_points/) và [path_types](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/path_types/). Đại diện này hữu ích cho việc phân tích đường viền hoặc truyền hình học cho các công cụ vẽ tùy chỉnh.

Ví dụ mở một bản trình bày, tìm hình geometry đầu tiên trực tiếp trên slide đầu tiên, và in ra các đoạn đường của nó. Sử dụng một bản trình bày chứa một hình có các đoạn thẳng và cong để xem cả hai loại đầu ra. Nó không tìm kiếm bên trong các nhóm.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]
    shape = next((item for item in slide.shapes if isinstance(item, slides.GeometryShape)), None)

    if shape is None:
        print("No geometry shape found on the first slide.")
    else:
        for element in shape.create_shape_elements():
            points = element.path_points
            types = element.path_types
            print("Shape element:")

            i = 0
            while i < len(points):
                point_type = types[i] & 0x07  # Giữ lại loại đoạn, loại trừ các cờ.
                if point_type == 0:
                    print(f"Start figure at {points[i]}")
                elif point_type == 1:
                    print(f"Line to {points[i]}")
                elif point_type == 3:
                    print(f"Cubic Bezier: controls {points[i]}, {points[i + 1]}; end {points[i + 2]}")
                    i += 2  # Tiêu thụ cả hai điểm điều khiển và điểm cuối.

                if (types[i] & 0x80) != 0:
                    print("Close subpath back to its starting point.")
                i += 1
```

Các mảng tương ứng theo chỉ số: `points[i]` là một điểm và `types[i]` mô tả vai trò của nó. Kiểu `0` bắt đầu một hình, và kiểu `1` vẽ một đoạn từ điểm trước tới điểm hiện tại. Một đoạn Bézier bậc ba bắt đầu tại điểm cuối trước và sử dụng ba mục kiểu `3` liên tiếp: hai điểm điều khiển và sau đó là điểm cuối mới. Vòng lặp tiêu thụ ba mục này cùng nhau và kiểm tra điểm cuối để xác định đóng.

Các kiểu điểm cũng chứa các cờ. Áp dụng mặt nạ `0x07` để xác định kiểu đoạn, và kiểm tra `0x80` riêng biệt để phát hiện một tiểu đường đóng. Ví dụ, `129` (`0x81`) có nghĩa là một điểm cuối đoạn line đóng một tiểu đường, và `131` (`0x83`) có nghĩa là một điểm cuối Bézier đóng một tiểu đường. So sánh giá trị thô chỉ với `1` hoặc `3` sẽ bỏ qua các trường hợp này. Các cờ khác, như gạch ngang (`0x10`) và dấu đánh dấu (`0x20`), không thay đổi kiểu đoạn cơ bản.

**Tọa độ và biến đổi.** Các điểm được đo bằng điểm (1/72 inch), với X tăng sang bên phải và Y tăng xuống dưới. Đối với một hình không thuộc nhóm, các tọa độ đã trích xuất đã bao gồm vị trí [x](https://reference.aspose.com/slides/python-net/aspose.slides/shape/x/) và [y](https://reference.aspose.com/slides/python-net/aspose.slides/shape/y/) và phản ánh chiều rộng và chiều cao hiện tại của nó. Ví dụ, một hình chữ nhật không xoay tại `(100, 200)` với kích thước `120 × 80` có giới hạn đường viền `(100, 200)`–`(220, 280)`. Đừng cộng lại vị trí của hình một lần nữa. Trừ X và Y của nó để có được tọa độ tương đối với khung không xoay.

Các điểm đã trích xuất không áp dụng việc xoay [rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) hoặc lật ngang và dọc của hình. Để tái tạo đường viền hiển thị, hãy áp dụng các biến đổi này quanh trung tâm của hình. Đối với các hình trong nhóm, cũng cần tính tới ánh xạ và biến đổi tọa độ của nhóm; đừng giả định rằng các điểm đã trích xuất là tọa độ cuối cùng trên slide hoặc áp dụng một phép dịch hoặc tỉ lệ đôi khi đã được phản ánh trong khung của đối tượng con.

**Kiểm tra so với chỉnh sửa.** Các mảng đã trích xuất mô tả đường viền; việc thay đổi chúng không cập nhật hình gốc. Chọn cách tiếp cận này khi phân tích hoặc mã vẽ của bạn cần các mảng điểm/kiểu. Sử dụng [get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/) khi bạn cần các lệnh hình học trong hệ tọa độ cục bộ của hình hoặc muốn chỉnh sửa hình học của nó. Áp dụng các đường đã chỉnh sửa qua [set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) hoặc [set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/).

## **FAQ**

**Điều gì sẽ xảy ra với màu nền và đường viền sau khi thay thế hình học?**

Kiểu vẫn giữ nguyên trên hình; chỉ đường viền thay đổi. Màu nền và đường viền sẽ tự động được áp dụng cho hình học mới.

**Làm sao để xoay đúng một hình tùy chỉnh cùng với hình học của nó?**

Sử dụng thuộc tính [rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) của hình; hình học sẽ xoay cùng với hình vì nó gắn vào hệ tọa độ của hình.

**Tôi có thể chuyển đổi một hình tùy chỉnh sang ảnh để \"khóa\" kết quả không?**

Có. Xuất vùng [slide](/slides/vi/python-net/convert-powerpoint-to-png/) cần thiết hoặc [shape](/slides/vi/python-net/create-shape-thumbnails/) riêng sang định dạng raster; điều này đơn giản hoá việc làm việc tiếp theo với các hình học phức tạp.