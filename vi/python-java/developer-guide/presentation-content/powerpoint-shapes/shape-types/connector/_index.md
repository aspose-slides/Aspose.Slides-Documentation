---
title: Quản lý các connector trong bản trình chiếu bằng Python qua Java
linktitle: Kết nối
type: docs
weight: 10
url: /vi/python-java/connector/
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
- bản trình chiếu
- Python
- Aspose.Slides
description: "Tìm hiểu cách thêm, gắn, thay đổi lộ trình, điều chỉnh và kiểm tra các connector thẳng, uốn cong và cong trong PowerPoint bằng Aspose.Slides cho Python qua Java."
---
## **Tổng quan**

Một connector là một đường có thể duy trì việc gắn vào hai hình khi một trong hai hình di chuyển. Các đầu của nó gắn vào các site kết nối, được biểu thị bằng các chấm xanh lá trong PowerPoint. Một số connector cong và uốn lượn cũng có các điểm điều chỉnh, được biểu thị bằng các chấm cam, điều khiển vị trí của các đoạn connector riêng lẻ.

Aspose.Slides đại diện cho các connector thông qua lớp [Connector](https://reference.aspose.com/slides/vi/python-java/aspose.slides/connector/). Bạn có thể tạo chúng, gắn đầu vào các hình, chọn site kết nối, thay đổi lộ trình và sửa đổi hình học của các connector có điểm điều chỉnh.

## **Các loại Connector**

Lớp [ShapeType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapetype/) bao gồm các preset connector thẳng, uốn cong và cong. Bảng dưới đây hiển thị các hình học connector khả dụng và số điểm điều chỉnh được định nghĩa bởi mỗi preset.

| Connector | Image | Số điểm điều chỉnh |
|---|---|---|
| [ShapeType.Line](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapetype/#Line) | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| [ShapeType.StraightConnector1](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapetype/#StraightConnector1) | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| [ShapeType.BentConnector2](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapetype/#BentConnector2) | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| [ShapeType.BentConnector3](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapetype/#BentConnector3) | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| [ShapeType.BentConnector4](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapetype/#BentConnector4) | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| [ShapeType.BentConnector5](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapetype/#BentConnector5) | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| [ShapeType.CurvedConnector2](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapetype/#CurvedConnector2) | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| [ShapeType.CurvedConnector3](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapetype/#CurvedConnector3) | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| [ShapeType.CurvedConnector4](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapetype/#CurvedConnector4) | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| [ShapeType.CurvedConnector5](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapetype/#CurvedConnector5) | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

Số lượng và ý nghĩa của các điểm điều chỉnh là một phần của preset connector đã chọn. Đừng giả định rằng hai loại connector khác nhau sẽ hiển thị cùng một bố cục bộ sưu tập.

## **Kết nối Hai Hình**

Sử dụng [ShapeCollection.addConnector](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapecollection/#addConnector) để thêm một connector, và dùng [Connector.setStartShapeConnectedTo](https://reference.aspose.com/slides/vi/python-java/aspose.slides/connector/#setStartShapeConnectedTo) và [Connector.setEndShapeConnectedTo](https://reference.aspose.com/slides/vi/python-java/aspose.slides/connector/#setEndShapeConnectedTo) để gắn các đầu của nó. Khi cả hai đầu đã được gắn, [Connector.reroute](https://reference.aspose.com/slides/vi/python-java/aspose.slides/connector/#reroute) sẽ chọn một lộ trình ngắn giữa các hình.

Ví dụ sau kết nối một ellipse và một rectangle bằng một connector uốn:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 40, 80, 120, 80)
    rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 320, 240, 140, 80)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 10, 10)

    connector.setStartShapeConnectedTo(ellipse)
    connector.setEndShapeConnectedTo(rectangle)
    connector.reroute()

    presentation.save("connected-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="Warning" %}}
Gọi [reroute](https://reference.aspose.com/slides/vi/python-java/aspose.slides/connector/#reroute) có thể thay đổi các giá trị [setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/vi/python-java/aspose.slides/connector/#setStartShapeConnectionSiteIndex) và [setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/vi/python-java/aspose.slides/connector/#setEndShapeConnectionSiteIndex). Gán các site kết nối cụ thể sau khi reroute nếu các site đó phải được giữ cố định.
{{% /alert %}}

## **Chọn một Connection Site**

Mỗi hình có khả năng kết nối sẽ báo cáo số lượng site của nó qua [Shape.getConnectionSiteCount](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#getConnectionSiteCount). Hãy xác thực chỉ mục site (bắt đầu từ 0) mong muốn trước khi gán nó cho đầu connector; số lượng site thay đổi tùy theo hình học của hình.

Ví dụ này gắn connector vào một site cụ thể trên ellipse khi site đó tồn tại:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 40, 80, 120, 80)
    rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 320, 240, 140, 80)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector3, 0, 0, 10, 10)

    connector.setStartShapeConnectedTo(ellipse)
    connector.setEndShapeConnectedTo(rectangle)

    preferred_site_index = 2
    if preferred_site_index < ellipse.getConnectionSiteCount():
        connector.setStartShapeConnectionSiteIndex(preferred_site_index)
    else:
        print(f"The ellipse has only {ellipse.getConnectionSiteCount()} connection sites.")

    presentation.save("specific-connection-site.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Điều chỉnh một Điểm Connector**

Các connector có điểm điều chỉnh sẽ hiển thị chúng thông qua [GeometryShape.getAdjustments](https://reference.aspose.com/slides/vi/python-java/aspose.slides/geometryshape/#getAdjustments). Kiểm tra từng [AdjustValue](https://reference.aspose.com/slides/vi/python-java/aspose.slides/adjustvalue/) và xem giá trị [getType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/adjustvalue/#getType) trước khi thay đổi bằng [setRawValue](https://reference.aspose.com/slides/vi/python-java/aspose.slides/adjustvalue/#setRawValue). Các quy tắc chung để xác định các adjustment shape preset được mô tả trong [Shape Manipulation](/slides/vi/python-java/shape-manipulations/).

Số lượng, thứ tự, ý nghĩa và phạm vi giá trị hợp lệ của các adjustment connector phụ thuộc vào preset connector. Kiểu adjustment chỉ đọc, còn giá trị adjustment có thể ghi. Phương thức chỉ đọc [getName](https://reference.aspose.com/slides/vi/python-java/aspose.slides/adjustvalue/#getName) cung cấp thông tin nhận dạng bổ sung khi một connector chứa nhiều hơn một adjustment có cùng kiểu ngữ nghĩa.

### **Định tuyến Xung quanh Một Chướng Ngại Vật**

Trong bố cục sau, một connector [BentConnector5](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapetype/#BentConnector5) giữa hai hình đi qua một hình thứ ba:

![connector-obstruction](connector-obstruction.png)

Đoạn mã này tạo connector bị cản:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, LineArrowheadStyle, FillType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getShapes().addAutoShape(ShapeType.Rectangle, 300, 150, 150, 75)
    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 400, 100, 50)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 70, 30)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector5, 20, 20, 400, 300)

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle)
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setStartShapeConnectionSiteIndex(2)

    presentation.save("connector-obstruction.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Di chuyển khúc uốn dọc thay đổi lộ trình sao cho connector tránh chướng ngại vật:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Thay vì giả định rằng chỉ mục bộ sưu tập `1` luôn đại diện cho khúc uốn dọc, ví dụ này tìm kiếm [ConnectorBendPositionY](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionY) và chỉ thay đổi nó khi kiểu ngữ nghĩa mong đợi xuất hiện:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, LineArrowheadStyle, FillType, ShapeAdjustmentType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getShapes().addAutoShape(ShapeType.Rectangle, 300, 150, 150, 75)
    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 400, 100, 50)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 70, 30)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector5, 20, 20, 400, 300)

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle)
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setStartShapeConnectionSiteIndex(2)

    vertical_bend = None
    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        print(f"{adjustment.getName()}: {adjustment.getType()}, raw value = {adjustment.getRawValue()}")
        if adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY:
            vertical_bend = adjustment
            break

    if vertical_bend is None:
        print("The connector does not expose a vertical bend adjustment.")
    else:
        vertical_bend.setRawValue(60000)
        presentation.save("connector-obstruction-fixed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Một [BentConnector5](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapetype/#BentConnector5) có hai adjustment [ConnectorBendPositionX](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionX) và một adjustment [ConnectorBendPositionY](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionY). Nếu kiểu bạn cần xuất hiện nhiều hơn một lần, hãy kiểm tra [getName](https://reference.aspose.com/slides/vi/python-java/aspose.slides/adjustvalue/#getName) và hình học đã biết của preset trước khi chọn. Nếu một adjustment trả về [ShapeAdjustmentType.Custom](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapeadjustmenttype/#Custom), coi ý nghĩa và phạm vi của nó là đặc thù cho preset và không thay đổi cho đến khi hợp đồng này được xác định.

## **Liên kết Giá trị Adjustment với Hình học Connector**

Đối với các connector uốn, giá trị adjustment có thể được dùng để ước tính vị trí của các đoạn riêng lẻ. Các phép tính này là riêng cho preset connector:

- [BentConnector4](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapetype/#BentConnector4) thường hiển thị một adjustment [ConnectorBendPositionX](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionX) và một [ConnectorBendPositionY](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionY).
- Đối với các vị trí uốn này, việc chia giá trị trả về từ [getRawValue](https://reference.aspose.com/slides/vi/python-java/aspose.slides/adjustvalue/#getRawValue) cho `100000.0` tạo ra phần tỷ lệ của chiều rộng hoặc chiều cao khung connector được dùng trong các ví dụ dưới đây.
- Khung connector có thể được xoay hoặc lật, vì vậy tọa độ khung phải được biến đổi trước khi so sánh với tọa độ slide.

Các ví dụ sau dùng [getType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/adjustvalue/#getType) để xác định các adjustment trước. Chúng không coi chỉ mục bộ sưu tập là định danh di động.

### **Connector Không Xoay**

Bố cục ban đầu chứa hai hình chữ nhật văn bản được kết nối bằng một [BentConnector4](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapetype/#BentConnector4):

![connector-shape-complex](connector-shape-complex.png)

Ví dụ này kiểm tra connector và lấy các adjustment uốn ngang và dọc:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, LineArrowheadStyle, FillType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25)
    source_shape.getTextFrame().setText("From")
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25)
    target_shape.getTextFrame().setText("To")
    connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300)

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle)
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)
    connector.getLineFormat().setWidth(3)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setStartShapeConnectionSiteIndex(3)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setEndShapeConnectionSiteIndex(2)

    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        print(f"{adjustment.getName()}: {adjustment.getType()}, raw value = {adjustment.getRawValue()}")
finally:
    presentation.dispose()
```

Để thay đổi cả hai uốn, xác định từng kiểu mong đợi và chỉ thay đổi giá trị sau khi đã tìm thấy cả hai:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, ShapeAdjustmentType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setStartShapeConnectionSiteIndex(3)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setEndShapeConnectionSiteIndex(2)

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        if adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX:
            horizontal_bend = adjustment
        elif adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        horizontal_bend.setRawValue(horizontal_bend.getRawValue() + 20000)
        vertical_bend.setRawValue(vertical_bend.getRawValue() + 200000)
        presentation.save("connector-adjusted.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kết quả là một connector có các đoạn ngang và dọc đã di chuyển:

![connector-adjusted-1](connector-adjusted-1.png)

Khi các kiểu ngữ nghĩa đã được biết, giá trị của chúng có thể chuyển sang tọa độ khung connector. Ví dụ này vẽ một hình chữ nhật mỏng lên đoạn dọc do hai adjustment uốn điều khiển:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, ShapeAdjustmentType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setStartShapeConnectionSiteIndex(3)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setEndShapeConnectionSiteIndex(2)

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        if adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX:
            horizontal_bend = adjustment
        elif adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        x = connector.getX() + connector.getWidth() * horizontal_bend.getRawValue() / 100000.0
        y = connector.getY()
        height = connector.getHeight() * vertical_bend.getRawValue() / 100000.0
        slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 1, height)
        presentation.save("connector-segment-guide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Hình dẫn đánh dấu đoạn đã tính:

![connector-adjusted-2](connector-adjusted-2.png)

### **Connector Xoay hoặc Lật**

Khi cùng một hình connector được định hướng dọc, các giá trị [Shape.getFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#getFrame), [ShapeFrame.getFlipH](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapeframe/#getFlipH) và [ShapeFrame.getFlipV](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapeframe/#getFlipV) ảnh hưởng đến việc chuyển đổi từ tọa độ khung connector sang tọa độ slide.

Ví dụ này tạo và điều chỉnh connector được định hướng dọc:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, LineArrowheadStyle, FillType, ShapeAdjustmentType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25)
    source_shape.getTextFrame().setText("From")
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25)
    target_shape.getTextFrame().setText("To 1")
    connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300)

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle)
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    connector_color = Color(102, 205, 170)
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(connector_color)
    connector.getLineFormat().setWidth(3)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setStartShapeConnectionSiteIndex(2)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setEndShapeConnectionSiteIndex(3)

    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        if adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX:
            adjustment.setRawValue(adjustment.getRawValue() + 20000)
        elif adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY:
            adjustment.setRawValue(adjustment.getRawValue() + 200000)

    presentation.save("vertical-connector-adjusted.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Connector đã điều chỉnh xuất hiện dọc giữa các hình:

![connector-adjusted-3](connector-adjusted-3.png)

Đối với một góc xoay tùy ý `alpha`, quay một điểm khung connector `(x, y)` quanh trung tâm khung `(x0, y0)`:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Đoạn mã sau xử lý góc xoay 90 độ được dùng trong ví dụ này và vẽ một đường dẫn màu đỏ lên đoạn connector tương ứng:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, FillType, ShapeAdjustmentType, NullableBool

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setStartShapeConnectionSiteIndex(2)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setEndShapeConnectionSiteIndex(3)

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        if adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX:
            horizontal_bend = adjustment
        elif adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        horizontal_bend.setRawValue(horizontal_bend.getRawValue() + 20000)
        vertical_bend.setRawValue(vertical_bend.getRawValue() + 200000)

        x = connector.getX()
        y = connector.getY()
        if connector.getFrame().getFlipH() == NullableBool.True_:
            x += connector.getWidth()
        if connector.getFrame().getFlipV() == NullableBool.True_:
            y += connector.getHeight()

        x += connector.getWidth() * horizontal_bend.getRawValue() / 100000.0
        rotated_x = connector.getFrame().getCenterX() - y + connector.getFrame().getCenterY()
        rotated_y = x - connector.getFrame().getCenterX() + connector.getFrame().getCenterY()
        segment_width = connector.getHeight() * vertical_bend.getRawValue() / 100000.0
        guide = slide.getShapes().addAutoShape(ShapeType.Rectangle, rotated_x, rotated_y, segment_width, 1)
        guide.getLineFormat().getFillFormat().setFillType(FillType.Solid)
        guide.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

        presentation.save("rotated-connector-segment-guide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Đường dẫn màu đỏ đánh dấu đoạn đã tính sau khi biến đổi tọa độ:

![connector-adjusted-4](connector-adjusted-4.png)

Các công thức này mô tả các preset được dùng trong các ví dụ, không phải mô hình connector chung. Hãy xác thực các kiểu adjustment, hướng khung và phạm vi giá trị trước khi áp dụng cùng một phép tính cho một preset khác.

## **Tìm Góc Hướng của Connector**

Hướng của một connector thẳng có thể tính từ chiều rộng và chiều cao, với các lật ngang và dọc được áp dụng. Ví dụ dưới đây báo cáo góc theo chiều kim đồng hồ tính từ trục ngang dương trong tọa độ slide:

```python
import jpype
import asposeslides
import math

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, NullableBool

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    connector = slide.getShapes().addConnector(ShapeType.StraightConnector1, 100, 100, 200, 100)

    flip_h = connector.getFrame().getFlipH() == NullableBool.True_
    flip_v = connector.getFrame().getFlipV() == NullableBool.True_
    delta_x = connector.getWidth() * (-1 if flip_h else 1)
    delta_y = connector.getHeight() * (-1 if flip_v else 1)
    angle = math.atan2(delta_y, delta_x) * 180.0 / math.pi

    if angle < 0:
        angle += 360

    print(f"Connector direction: {angle:.2f} degrees")
finally:
    presentation.dispose()
```

## **Câu hỏi thường gặp**

**Làm sao tôi biết một connector có thể gắn vào một hình không?**

Kiểm tra giá trị [getConnectionSiteCount](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#getConnectionSiteCount) của hình. Một số lượng dương có nghĩa là hình cung cấp các site kết nối. Xác thực chỉ mục site đã chọn trước khi gán nó cho bất kỳ đầu connector nào.

**Tôi có thể xác định một adjustment connector bằng chỉ mục bộ sưu tập không?**

Chỉ mục chỉ có ý nghĩa đối với một preset connector đã biết và bố cục bộ sưu tập. Kiểm tra [AdjustValue.getType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/adjustvalue/#getType) trước khi thay đổi giá trị, và dùng [AdjustValue.getName](https://reference.aspose.com/slides/vi/python-java/aspose.slides/adjustvalue/#getName) như thông tin bổ sung khi cùng một kiểu ngữ nghĩa xuất hiện nhiều lần.

**Điều gì xảy ra khi một hình được kết nối bị xóa?**

Đầu connector tương ứng sẽ bị tách rời. Connector vẫn còn trên slide và có thể bị xóa, được đặt như một đường tự do, hoặc gắn lại vào một hình khác.

**Các ràng buộc connector có được giữ khi slide được sao chép không?**

Các ràng buộc thường được giữ khi các hình được kết nối được sao chép cùng slide. Nếu một connector được sao chép mà không có một trong các hình mục tiêu, đầu bị ảnh hưởng phải được gắn lại.