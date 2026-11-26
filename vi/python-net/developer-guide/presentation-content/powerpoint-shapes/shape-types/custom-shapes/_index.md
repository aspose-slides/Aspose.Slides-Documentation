---
title: Tùy chỉnh hình dạng trình chiếu trong Python
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
- điểm đường
- điểm chỉnh sửa
- thêm điểm
- xóa điểm
- thao tác chỉnh sửa
- góc cong
- PowerPoint
- bản trình chiếu
- Python
- Aspose.Slides
description: "Tạo và tùy chỉnh các hình dạng trong bản trình chiếu PowerPoint bằng Aspose.Slides cho Python thông qua .NET: các đường hình học, góc cong, hình dạng tổng hợp."
---
## **Tổng quan**

Bài viết này giải thích cách tùy chỉnh các hình dạng trong bản trình chiếu Aspose.Slides bằng cách chỉnh sửa hình học của hình dạng thông qua các điểm chỉnh sửa và các đường hình học. Nó cho thấy cách làm việc với [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) để sửa đổi các hình dạng hiện có, thực hiện các thao tác chỉnh sửa đường cơ bản, thêm hoặc xóa điểm, và áp dụng hình học đã cập nhật trở lại cho một hình dạng.

Nó cũng trình bày cách tạo các hình dạng tùy chỉnh và tổng hợp, xây dựng các hình dạng có góc cong, xác định liệu hình học của một hình dạng có đóng không, và trích xuất các yếu tố hình dạng để phân tích đường viền.

## **Thay đổi một Hình Dạng bằng Điểm Chỉnh Sửa**

Trong PowerPoint, bạn có thể sử dụng **Edit Points** để chỉnh sửa một hình vuông:

* Di chuyển một góc vào trong hoặc ra ngoài.
* Điều chỉnh độ cong tại một điểm.
* Thêm các điểm mới.

Chỉnh sửa các điểm cho phép bạn thay đổi đường viền của một hình dạng hoặc sử dụng một hình dạng hiện có làm cơ sở cho hình dạng mới.

## **Mẹo Chỉnh Sửa Hình Dạng**

![overview_image](custom_shape_0.png)

Khi chỉnh sửa các hình dạng PowerPoint, hãy ghi nhớ các khái niệm sau:

* Một hình dạng (hoặc đường của nó) có thể được đóng hoặc mở.
* Đường của một hình dạng bao gồm các điểm neo được kết nối bởi các đoạn.
* Một đoạn có thể thẳng hoặc cong. Các điểm neo và tay điều khiển xác định hình dạng của nó.
* Các điểm neo tồn tại dưới dạng điểm góc, điểm thẳng hoặc điểm mượt:
  * Tại một điểm góc, các đoạn liền kề có thể gặp nhau ở một góc.
  * Tại một điểm mượt, hai tay điều khiển được căn chỉnh và cách đều điểm neo.
  * Tại một điểm thẳng, hai tay điều khiển được căn chỉnh nhưng có thể cách điểm neo khác nhau.
* Di chuyển các điểm neo hoặc điều chỉnh tay của chúng sẽ thay đổi đường viền của hình dạng.

Để chỉnh sửa các hình dạng PowerPoint thông qua các điểm chỉnh sửa, **Aspose.Slides** cung cấp lớp [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/).

* Một thể hiện [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) đại diện cho đường hình học của đối tượng [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/).
* Để lấy [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) từ thể hiện [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/), bạn có thể sử dụng phương thức [GeometryShape.get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/).
* Để đặt [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) cho một hình dạng, bạn có thể sử dụng các phương thức: [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) cho các hình dạng có một đường duy nhất và [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) cho các hình dạng có đa đường.
* Để thêm các đoạn, bạn có thể sử dụng các phương thức trong [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/).
* Sử dụng các thuộc tính [GeometryPath.stroke](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/stroke/) và [GeometryPath.fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/fill_mode/), bạn có thể đặt cách hiển thị cho một đường hình học.
* Sử dụng thuộc tính [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/), bạn có thể lấy đường hình học của một [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) dưới dạng một mảng các đoạn đường.

## **Các Thao Tác Chỉnh Sửa Đơn Giản**

Sử dụng các phương thức sau để chỉnh sửa một đường hình học. Các overload chấp nhận chỉ số sẽ chèn một đoạn tại vị trí dựa trên chỉ số không‑dựa trong mảng đoạn của đường.

| Hoạt động | Phương thức |
| --- | --- |
| Thêm hoặc chèn một đường thẳng. | [GeometryPath.line_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/line_to/) |
| Thêm hoặc chèn một đường cong Bézier bậc ba với hai điểm điều khiển và một điểm cuối. | [GeometryPath.cubic_bezier_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/cubic_bezier_to/) |
| Thêm hoặc chèn một đường cong Bézier bậc hai với một điểm điều khiển và một điểm cuối. | [GeometryPath.quadratic_bezier_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/quadratic_bezier_to/) |
| Thêm một cung ellip với kích thước và góc được chỉ định tính bằng độ. | [GeometryPath.arc_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/arc_to/) |
| Đóng hình hiện tại bằng cách nối điểm cuối của nó tới điểm bắt đầu. | [GeometryPath.close_figure](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/close_figure/) |
| Đặt điểm bắt đầu của một hình. | [GeometryPath.move_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/move_to/) |
| Xóa một đoạn tại một chỉ số không‑dựa. | [GeometryPath.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/remove_at/) |

## **Thêm Các Điểm Tùy Chỉnh vào Một Hình Dạng**

Ví dụ này chèn hai điểm vào một hình chữ nhật bằng [GeometryPath.line_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/line_to/) và áp dụng đường đã chỉnh sửa với [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/). Tọa độ là nội bộ đối với hình dạng: cả hai điểm mới đều ở trung tâm, cách trái 100 điểm và cách trên 5 0 điểm. Các chỉ số đoạn 1 và 4 đặt chúng trên các cạnh trên và dưới, kéo các cạnh này vào trong.

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

## **Xóa Các Điểm khỏi Một Hình Dạng**

Ví dụ này thay đổi đường viền hình dạng trái tim bằng cách xóa đoạn tại chỉ số không‑dựa 2 với [GeometryPath.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/remove_at/). Áp dụng đường đã sửa đổi với [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) sẽ cập nhật đường viền của hình dạng.

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

## **Tạo Một Hình Dạng Tùy Chỉnh**

Ví dụ này xây dựng một ngôi sao năm cánh bằng [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/). Các bán kính ngoài và trong xen kẽ 100 và 50 điểm xác định các đầu nhọn và các rãnh; một bước 72 độ phân bố đều năm đầu nhọn. Đường được đóng bằng [GeometryPath.close_figure](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/close_figure/) và áp dụng cho một hình chữ nhật bằng [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/), thay thế đường viền của nó.

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

## **Tạo Một Hình Dạng Tổng Hợp Tùy Chỉnh**

Ví dụ này định nghĩa hai [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) đóng cho phần trên và phần dưới của một hình dạng. Áp dụng cả hai đường với [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) tạo ra một hình dạng tổng hợp duy nhất với một khoảng trống ở phần giữa.

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

## **Tạo Một Hình Dạng Tùy Chỉnh với Các Góc Cong**

Ví dụ này kết hợp các đoạn thẳng với [GeometryPath.arc_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/arc_to/) để tạo một hình dạng có các góc cong vào trong. Mỗi kích thước góc đặt độ rộng và chiều cao của cung tính bằng điểm, và quét -90 độ vẽ một phần tư ellip ngược chiều kim đồng hồ. Đường hoàn chỉnh được áp dụng bằng [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/), và bản trình bày được lưu ở định dạng PPTX.

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

## **Xác Định Liệu Hình Học Của Một Hình Dạng Có Đóng Không**

Trợ giúp sau kiểm tra xem mỗi đường hình học không rỗng có kết thúc bằng một đoạn đóng hay không. Nó đọc [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) và so sánh lệnh [PathSegment.path_command](https://reference.aspose.com/slides/python-net/aspose.slides/pathsegment/path_command/) cuối cùng với [PathCommandType.CLOSE](https://reference.aspose.com/slides/python-net/aspose.slides/pathcommandtype/). Nó trả về false khi không có đường không rỗng. Kiểm tra này xem lệnh cuối cùng của mỗi đường; nó không kiểm tra mọi tiểu hình trong một đường. Ví dụ in ra `True` cho một hình chữ nhật.

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

## **Kiểm Tra Các Lệnh Đường Hình Học**

Tải xuống [contour.pptx](contour.pptx) và đặt nó trong thư mục làm việc của bạn. Hình dạng đầu tiên trên slide đầu tiên có một cạnh trên thẳng, một đường cong Bézier bậc ba, và một cạnh đóng thẳng. Sử dụng [GeometryShape.get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/) để đọc các đường của nó. Đối với mỗi đường, [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) liệt kê các đoạn theo thứ tự vẽ. Lệnh [PathSegment.path_command](https://reference.aspose.com/slides/python-net/aspose.slides/pathsegment/path_command/) của mỗi đoạn quyết định cách diễn giải [PathSegment.segment_data](https://reference.aspose.com/slides/python-net/aspose.slides/pathsegment/segment_data/).

```python
import aspose.slides as slides

with slides.Presentation("contour.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    for i, path in enumerate(shape.get_geometry_paths()):
        for j, segment in enumerate(path.path_data):
            command = segment.path_command
            data = segment.segment_data
            if command in (slides.PathCommandType.MOVE_TO, slides.PathCommandType.LINE_TO):
                detail = f"destination={tuple(data)}"
            elif command == slides.PathCommandType.CUBIC_BEZIER_TO:
                detail = f"control1={tuple(data[:2])} control2={tuple(data[2:4])} end={tuple(data[4:])}"
            elif command == slides.PathCommandType.CLOSE:
                detail = "no coordinates"
            else:
                detail = f"raw={data}"
            print(f"Path {i}, segment {j}: {command.name} {detail}")
```

Hình dạng nằm tại (200, 100) điểm trên slide. Các tọa độ được báo cáo là nội bộ đối với hình dạng. Góc trên‑trái của nó là (0, 0), x tăng sang phải, y tăng xuống. Đoạn đóng trả về điểm bắt đầu mà không cần tọa độ thêm.

```text
Path 0, segment 0: MOVE_TO destination=(0, 0)
Path 0, segment 1: LINE_TO destination=(80, 0)
Path 0, segment 2: CUBIC_BEZIER_TO control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: CLOSE no coordinates
```

![PowerPoint shape with a straight top edge, a curved edge from the upper right to the lower left, and a straight left edge](contour.png)

## **Trích Xuất và Kiểm Tra Các Thành Phần Hình Dạng**

Sử dụng [GeometryShape.create_shape_elements](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/create_shape_elements/) để kiểm tra một hình dạng hiện có dưới dạng các thành phần chứa các điểm đường và kiểu điểm. Mỗi [ShapeElement](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/) trả về cung cấp các mảng [path_points](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/path_points/) và [path_types](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/path_types/). Đại diện này hữu ích cho việc phân tích đường viền hoặc truyền hình học tới các công cụ vẽ tùy chỉnh.

Ví dụ mở một bản trình bày, tìm hình dạng hình học đầu tiên trực tiếp trên slide đầu tiên, và in ra các đoạn đường của nó. Sử dụng một bản trình bày chứa một hình dạng có các đoạn thẳng và cong để thấy cả hai loại đầu ra. Nó không tìm kiếm bên trong các nhóm.

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
                point_type = types[i] & 0x07  # Keep the segment type, excluding flags.
                if point_type == 0:
                    print(f"Start figure at {points[i]}")
                elif point_type == 1:
                    print(f"Line to {points[i]}")
                elif point_type == 3:
                    print(f"Cubic Bezier: controls {points[i]}, {points[i + 1]}; end {points[i + 2]}")
                    i += 2  # Consume both control points and the endpoint.

                if (types[i] & 0x80) != 0:
                    print("Close subpath back to its starting point.")
                i += 1
```

Các mảng tương ứng theo chỉ số: `points[i]` là một điểm và `types[i]` mô tả vai trò của nó. Kiểu `0` bắt đầu một hình, và kiểu `1` vẽ một đường từ điểm trước đến điểm hiện tại. Một đoạn Bézier bậc ba bắt đầu tại điểm cuối trước và sử dụng ba mục kiểu `3` liên tiếp: hai điểm điều khiển theo sau là điểm cuối mới. Vòng lặp tiêu thụ ba mục này cùng nhau và kiểm tra điểm cuối để xác định đóng.

Các kiểu điểm cũng chứa các cờ. Áp dụng mask `0x07` để xác định loại đoạn, và kiểm tra riêng `0x80` để phát hiện một tiểu đường đóng. Ví dụ, `129` (`0x81`) nghĩa là một điểm cuối đoạn thẳng đóng một tiểu đường, và `131` (`0x83`) nghĩa là một điểm cuối Bézier đóng một tiểu đường. So sánh giá trị thô chỉ với `1` hoặc `3` sẽ bỏ sót các trường hợp này. Các cờ khác, như nét đứt (`0x10`) và ký hiệu (`0x20`), không thay đổi loại đoạn cơ bản.

**Tọa độ và biến đổi.** Các điểm được đo bằng điểm (1/72 inch), với X tăng sang phải và Y tăng xuống. Đối với một hình dạng không thuộc nhóm, các tọa độ đã trích xuất đã bao gồm vị trí [x](https://reference.aspose.com/slides/python-net/aspose.slides/shape/x/) và [y](https://reference.aspose.com/slides/python-net/aspose.slides/shape/y/) và phản ánh chiều rộng và chiều cao hiện tại. Ví dụ, một hình chữ nhật không xoay tại `(100, 200)` với kích thước `120 × 80` có giới hạn đường viền `(100, 200)`–`(220, 280)`. Đừng cộng thêm vị trí của hình nữa. Trừ X và Y của nó để có được tọa độ tương đối với khung không xoay.

Các điểm đã trích xuất không áp dụng phép quay [rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) hoặc lật ngang và dọc của hình dạng. Để tái tạo đường viền hiển thị, áp dụng các biến đổi này quanh trung tâm của hình dạng. Đối với các hình dạng nhóm, cũng cần tính tới ánh xạ và biến đổi tọa độ nhóm; đừng cho rằng các điểm đã trích xuất là tọa độ slide cuối cùng đã được vẽ hoặc áp dụng dịch chuyển hoặc tỉ lệ hai lần nếu chúng đã được phản ánh trong khung con.

**Kiểm tra so với chỉnh sửa.** Các mảng đã trích xuất mô tả đường viền; thay đổi chúng sẽ không cập nhật lại hình dạng gốc. Chọn cách này khi phân tích hoặc mã vẽ của bạn cần các mảng điểm/kiểu. Sử dụng [get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/) khi bạn cần các lệnh hình học trong hệ tọa độ nội bộ của hình dạng hoặc muốn chỉnh sửa hình học của nó. Áp dụng các đường đã chỉnh sửa qua [set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) hoặc [set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/).

## **Câu Hỏi Thường Gặp**

**Bổ sung sẽ xảy ra với màu nền và đường viền sau khi thay thế hình học?**

Kiểu vẫn giữ nguyên với hình dạng; chỉ đường viền thay đổi. Màu nền và đường viền tự động áp dụng cho hình học mới.

**Làm sao để xoay đúng một hình dạng tùy chỉnh cùng với hình học của nó?**

Sử dụng thuộc tính [rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) của hình dạng; hình học sẽ xoay cùng với hình dạng vì nó được gắn vào hệ tọa độ của hình dạng.

**Tôi có thể chuyển đổi một hình dạng tùy chỉnh thành hình ảnh để “khóa” kết quả không?**

Có. Xuất khu vực [slide](/slides/vi/python-net/convert-powerpoint-to-png/) cần thiết hoặc [shape](/slides/vi/python-net/create-shape-thumbnails/) riêng ra thành định dạng raster; điều này giúp đơn giản hoá công việc với các hình học phức tạp.