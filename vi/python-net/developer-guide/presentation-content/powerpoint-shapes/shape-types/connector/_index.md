---
title: Quản lý các connector trong bài thuyết trình bằng Python
linktitle: Kết nối
type: docs
weight: 10
url: /vi/python-net/connector/
keywords:
- kết nối
- loại kết nối
- điểm kết nối
- đường kết nối
- góc kết nối
- vị trí kết nối
- điểm điều chỉnh
- kết nối các hình
- PowerPoint
- bài thuyết trình
- Python
- Aspose.Slides
description: "Tìm hiểu cách thêm, gắn, định tuyến lại, điều chỉnh và kiểm tra các connector thẳng, uốn và cong trong PowerPoint bằng Aspose.Slides cho Python qua .NET."
---
## **Tổng quan**

Connector là một đường có thể gắn vào hai hình dạng và vẫn giữ nguyên khi một trong hai hình dạng di chuyển. Các đầu của nó gắn vào các vị trí kết nối, được biểu thị bằng các chấm màu xanh lá trong PowerPoint. Một số connector uốn cong và cong cũng hiển thị các điểm điều chỉnh, được biểu thị bằng các chấm màu cam, điều khiển vị trí của các đoạn connector riêng lẻ.

Aspose.Slides đại diện cho các connector thông qua giao diện [IConnector](https://reference.aspose.com/slides/vi/python-net/aspose.slides/iconnector/). Bạn có thể tạo chúng, gắn các đầu vào hình dạng, chọn vị trí kết nối, định tuyến lại và sửa đổi hình học của các connector có điểm điều chỉnh.

## **Các loại connector**

[ShapeType](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shapetype/) liệt kê các mẫu connector thẳng, uốn và cong. Bảng dưới đây hiển thị các hình học connector khả dụng và số điểm điều chỉnh được định nghĩa cho mỗi mẫu.

| Kết nối | Hình ảnh | Số điểm điều chỉnh |
|---|---|---|
| `ShapeType.LINE` | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| `ShapeType.STRAIGHT_CONNECTOR1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| `ShapeType.BENT_CONNECTOR2` | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| `ShapeType.BENT_CONNECTOR3` | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| `ShapeType.BENT_CONNECTOR4` | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| `ShapeType.BENT_CONNECTOR5` | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| `ShapeType.CURVED_CONNECTOR2` | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType.CURVED_CONNECTOR3` | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType.CURVED_CONNECTOR4` | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType.CURVED_CONNECTOR5` | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

Số lượng và ý nghĩa của các điểm điều chỉnh là một phần của mẫu connector đã chọn. Đừng cho rằng hai loại connector khác nhau sẽ hiển thị cùng một bố cục bộ sưu tập.

## **Kết nối hai hình**

Sử dụng [IShapeCollection.add_connector](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ishapecollection/add_connector/) để thêm một connector, và gán các thuộc tính [start_shape_connected_to](https://reference.aspose.com/slides/vi/python-net/aspose.slides/iconnector/start_shape_connected_to/) và [end_shape_connected_to](https://reference.aspose.com/slides/vi/python-net/aspose.slides/iconnector/end_shape_connected_to/). Sau khi cả hai đầu đã được gắn, [IConnector.reroute](https://reference.aspose.com/slides/vi/python-net/aspose.slides/iconnector/reroute/) sẽ chọn một tuyến ngắn giữa các hình.

Ví dụ sau kết nối một ellipse và một rectangle bằng một connector uốn:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    ellipse = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 40, 80, 120, 80)
    rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 320, 240, 140, 80)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 10, 10)

    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle
    connector.reroute()

    presentation.save("connected-shapes.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Warning" %}}
Gọi `reroute` có thể thay đổi các giá trị [start_shape_connection_site_index](https://reference.aspose.com/slides/vi/python-net/aspose.slides/iconnector/start_shape_connection_site_index/) và [end_shape_connection_site_index](https://reference.aspose.com/slides/vi/python-net/aspose.slides/iconnector/end_shape_connection_site_index/). Gán các vị trí kết nối cụ thể sau khi định tuyến lại nếu các vị trí đó phải cố định.
{{% /alert %}}

## **Chọn vị trí kết nối**

Mỗi hình dạng có thể kết nối đều báo cáo số lượng vị trí thông qua [connection_site_count](https://reference.aspose.com/slides/vi/python-net/aspose.slides/igeometryshape/connection_site_count/). Hãy xác thực chỉ mục vị trí dựa trên chỉ số bắt đầu từ 0 trước khi gán cho đầu connector; số lượng vị trí thay đổi tùy theo hình học của hình.

Ví dụ này gắn connector vào một vị trí cụ thể trên ellipse khi vị trí đó tồn tại:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    ellipse = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 40, 80, 120, 80)
    rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 320, 240, 140, 80)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR3, 0, 0, 10, 10)

    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    preferred_site_index = 2
    if preferred_site_index < ellipse.connection_site_count:
        connector.start_shape_connection_site_index = preferred_site_index
    else:
        print(f"The ellipse has only {ellipse.connection_site_count} connection sites.")

    presentation.save("specific-connection-site.pptx", slides.export.SaveFormat.PPTX)
```

## **Điều chỉnh một điểm connector**

Các connector có điểm điều chỉnh sẽ mở ra chúng thông qua [IGeometryShape.adjustments](https://reference.aspose.com/slides/vi/python-net/aspose.slides/igeometryshape/adjustments/). Kiểm tra từng [IAdjustValue](https://reference.aspose.com/slides/vi/python-net/aspose.slides/iadjustvalue/) và xác thực [type](https://reference.aspose.com/slides/vi/python-net/aspose.slides/iadjustvalue/type/) trước khi thay đổi [raw_value](https://reference.aspose.com/slides/vi/python-net/aspose.slides/iadjustvalue/raw_value/). Đối với thao tác hình dạng chung, xem [Shape Manipulation](/slides/vi/python-net/shape-manipulations/).

Số lượng, thứ tự, ý nghĩa và phạm vi giá trị hợp lệ của các điểm điều chỉnh connector phụ thuộc vào mẫu connector. Thuộc tính `type` chỉ đọc, trong khi giá trị điều chỉnh có thể ghi. Thuộc tính chỉ đọc [name](https://reference.aspose.com/slides/vi/python-net/aspose.slides/iadjustvalue/name/) cung cấp thông tin xác định bổ sung khi một connector chứa nhiều hơn một điểm điều chỉnh có cùng kiểu ngữ nghĩa.

### **Định tuyến quanh một chướng ngại vật**

Trong bố cục dưới đây, một connector `ShapeType.BENT_CONNECTOR5` giữa hai hình dạng đi qua một hình dạng thứ ba:

![connector-obstruction](connector-obstruction.png)

Mã này tạo connector bị cản trở:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 150, 150, 75)
    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 400, 100, 50)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 70, 30)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR5, 20, 20, 400, 300)

    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.black
    connector.start_shape_connected_to = source_shape
    connector.end_shape_connected_to = target_shape
    connector.start_shape_connection_site_index = 2

    presentation.save("connector-obstruction.pptx", slides.export.SaveFormat.PPTX)
```

Di chuyển khúc uốn dọc thay đổi tuyến sao cho connector đi vòng qua chướng ngại vật:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Thay vì giả định chỉ mục bộ sưu tập `1` luôn đại diện cho khúc uốn dọc, ví dụ này tìm kiếm `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y` và thay đổi nó chỉ khi kiểu ngữ nghĩa mong đợi có mặt:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 150, 150, 75)
    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 400, 100, 50)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 70, 30)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR5, 20, 20, 400, 300)

    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.black
    connector.start_shape_connected_to = source_shape
    connector.end_shape_connected_to = target_shape
    connector.start_shape_connection_site_index = 2

    vertical_bend = None
    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        print(f"{adjustment.name}: {adjustment.type}, raw value = {adjustment.raw_value}")
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            vertical_bend = adjustment
            break

    if vertical_bend is None:
        print("The connector does not expose a vertical bend adjustment.")
    else:
        vertical_bend.raw_value = 60000
        presentation.save("connector-obstruction-fixed.pptx", slides.export.SaveFormat.PPTX)
```

`ShapeType.BENT_CONNECTOR5` có hai điểm điều chỉnh `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X` và một điểm `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y`. Nếu kiểu bạn cần xuất hiện nhiều lần, hãy kiểm tra `name` và hình học đã biết của mẫu đó trước khi chọn. Nếu một điểm điều chỉnh trả về [ShapeAdjustmentType.CUSTOM](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shapeadjustmenttype/), coi ý nghĩa và phạm vi của nó là đặc thù cho mẫu và không thay đổi cho đến khi hợp đồng được xác định.

## **Liên kết giá trị điều chỉnh với hình học connector**

Đối với các connector uốn, giá trị điều chỉnh có thể được dùng để ước tính vị trí của các đoạn riêng lẻ. Các phép tính này chỉ áp dụng cho mẫu connector cụ thể:

- `ShapeType.BENT_CONNECTOR4` thường hiển thị một điểm `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X` và một điểm `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y`.
- Đối với các vị trí uốn này, `raw_value / 100000` tạo ra phần tỷ lệ của chiều rộng hoặc chiều cao khung connector được sử dụng trong các ví dụ bên dưới.
- Khung connector có thể được quay hoặc lật, do đó tọa độ khung phải được chuyển đổi trước khi so sánh với tọa độ slide.

Các ví dụ sau sử dụng `type` để xác định các điểm điều chỉnh trước. Chúng không coi chỉ mục bộ sưu tập là định danh di động.

### **Connector không xoay**

Bố cục ban đầu chứa hai hình dạng văn bản được nối bằng một `ShapeType.BENT_CONNECTOR4`:

![connector-shape-complex](connector-shape-complex.png)

Ví dụ này kiểm tra connector và lấy các điểm uốn ngang và dọc:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    source_shape.text_frame.text = "From"
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    target_shape.text_frame.text = "To"
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)

    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.crimson
    connector.line_format.width = 3
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 2

    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        print(f"{adjustment.name}: {adjustment.type}, raw value = {adjustment.raw_value}")
```

Để thay đổi cả hai khúc uốn, xác định mỗi kiểu mong đợi và chỉnh sửa giá trị chỉ sau khi đã tìm thấy cả hai:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 2

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X:
            horizontal_bend = adjustment
        elif adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        horizontal_bend.raw_value += 20000
        vertical_bend.raw_value += 200000
        presentation.save("connector-adjusted.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả là một connector mà các đoạn ngang và dọc đã di chuyển:

![connector-adjusted-1](connector-adjusted-1.png)

Khi các kiểu ngữ nghĩa đã được biết, giá trị của chúng có thể chuyển đổi thành tọa độ khung connector. Ví dụ này vẽ một hình chữ nhật mỏng lên đoạn dọc được điều khiển bởi hai điểm uốn:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 2

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X:
            horizontal_bend = adjustment
        elif adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        x = connector.x + connector.width * horizontal_bend.raw_value / 100000
        y = connector.y
        height = connector.height * vertical_bend.raw_value / 100000
        slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 1, height)
        presentation.save("connector-segment-guide.pptx", slides.export.SaveFormat.PPTX)
```

Hình dạng hướng dẫn đánh dấu đoạn đã tính toán:

![connector-adjusted-2](connector-adjusted-2.png)

### **Connector xoay hoặc lật**

Khi cùng một hình học connector được đặt theo chiều dọc, các giá trị [frame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/iconnector/frame/), [flip_h](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ishapeframe/flip_h/), và [flip_v](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ishapeframe/flip_v/) ảnh hưởng đến quá trình chuyển đổi tọa độ khung connector sang tọa độ slide.

Ví dụ này tạo và điều chỉnh connector được định hướng dọc:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    source_shape.text_frame.text = "From"
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 400, 60, 25)
    target_shape.text_frame.text = "To 1"
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)

    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.medium_aquamarine
    connector.line_format.width = 3
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 2
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 3

    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X:
            adjustment.raw_value += 20000
        elif adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            adjustment.raw_value += 200000

    presentation.save("vertical-connector-adjusted.pptx", slides.export.SaveFormat.PPTX)
```

Connector đã điều chỉnh xuất hiện dọc giữa các hình dạng:

![connector-adjusted-3](connector-adjusted-3.png)

Đối với một góc quay tùy ý `alpha`, quay một điểm khung connector `(x, y)` quanh trung tâm khung `(x0, y0)`:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Mã dưới đây xử lý hướng 90 độ được dùng trong ví dụ này và vẽ một hướng dẫn màu đỏ lên đoạn connector tương ứng:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 400, 60, 25)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 2
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 3

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X:
            horizontal_bend = adjustment
        elif adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        horizontal_bend.raw_value += 20000
        vertical_bend.raw_value += 200000

        x = connector.x
        y = connector.y
        if connector.frame.flip_h == slides.NullableBool.TRUE:
            x += connector.width
        if connector.frame.flip_v == slides.NullableBool.TRUE:
            y += connector.height

        x += connector.width * horizontal_bend.raw_value / 100000
        rotated_x = connector.frame.center_x - y + connector.frame.center_y
        rotated_y = x - connector.frame.center_x + connector.frame.center_y
        segment_width = connector.height * vertical_bend.raw_value / 100000
        guide = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, rotated_x, rotated_y, segment_width, 1)
        guide.line_format.fill_format.fill_type = slides.FillType.SOLID
        guide.line_format.fill_format.solid_fill_color.color = draw.Color.red

        presentation.save("rotated-connector-segment-guide.pptx", slides.export.SaveFormat.PPTX)
```

Hướng dẫn màu đỏ đánh dấu đoạn đã tính sau khi chuyển đổi tọa độ:

![connector-adjusted-4](connector-adjusted-4.png)

Các công thức này mô tả các mẫu được dùng trong các ví dụ, không phải một mô hình connector chung. Hãy xác thực các kiểu điều chỉnh, hướng khung và phạm vi giá trị trước khi áp dụng cùng một phép tính cho một mẫu khác.

## **Tìm góc hướng của connector**

Hướng của một connector thẳng có thể tính từ chiều rộng và chiều cao, áp dụng các lật ngang và dọc. Ví dụ sau báo cáo góc quay theo chiều kim đồng hồ từ trục ngang dương trong tọa độ slide:

```python
import math
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    connector = slide.shapes.add_connector(slides.ShapeType.STRAIGHT_CONNECTOR1, 100, 100, 200, 100)

    flip_h = connector.frame.flip_h == slides.NullableBool.TRUE
    flip_v = connector.frame.flip_v == slides.NullableBool.TRUE
    delta_x = connector.width * (-1 if flip_h else 1)
    delta_y = connector.height * (-1 if flip_v else 1)
    angle = math.atan2(delta_y, delta_x) * 180.0 / math.pi

    if angle < 0:
        angle += 360

    print(f"Connector direction: {angle:.2f} degrees")
```

## **Câu hỏi thường gặp**

**Làm sao tôi biết một connector có thể gắn vào một hình dạng không?**

Kiểm tra [connection_site_count](https://reference.aspose.com/slides/vi/python-net/aspose.slides/igeometryshape/connection_site_count/) của hình dạng. Giá trị dương nghĩa là hình dạng có các vị trí kết nối. Xác thực chỉ mục vị trí đã chọn trước khi gán cho bất kỳ đầu connector nào.

**Tôi có thể xác định một điểm điều chỉnh connector bằng chỉ mục bộ sưu tập không?**

Chỉ mục chỉ có ý nghĩa đối với một mẫu connector và bố cục bộ sưu tập đã biết. Kiểm tra [IAdjustValue.type](https://reference.aspose.com/slides/vi/python-net/aspose.slides/iadjustvalue/type/) trước khi thay đổi giá trị, và sử dụng [IAdjustValue.name](https://reference.aspose.com/slides/vi/python-net/aspose.slides/iadjustvalue/name/) như thông tin bổ sung khi cùng một kiểu ngữ nghĩa xuất hiện nhiều lần.

**Điều gì xảy ra khi một hình dạng được kết nối bị xóa?**

Đầu connector tương ứng sẽ bị tách rời. Connector vẫn còn trên slide và có thể bị xóa, chuyển thành một đường tự do, hoặc gắn lại vào một hình dạng khác.

**Các ràng buộc connector có được giữ nguyên khi sao chép slide không?**

Các ràng buộc thường được giữ khi các hình dạng được sao chép cùng slide. Nếu một connector được sao chép mà không có một trong các hình dạng mục tiêu, đầu bị ảnh hưởng phải được gắn lại.