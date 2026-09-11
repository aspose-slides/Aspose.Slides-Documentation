---
title: Quản lý các hình dạng trong bản trình chiếu bằng Python qua Java
linktitle: Thao tác Hình dạng
type: docs
weight: 40
url: /vi/python-java/shape-manipulations/
keywords:
- hình dạng PowerPoint
- hình dạng bản trình chiếu
- hình trên slide
- tìm hình dạng
- sao chép hình dạng
- xóa hình dạng
- ẩn hình dạng
- thay đổi thứ tự hình dạng
- lấy ID hình dạng interop
- văn bản thay thế của hình dạng
- điểm điều chỉnh hình dạng
- điều chỉnh hình dạng được đặt trước
- hình học hình dạng
- định dạng bố cục hình dạng
- hình dạng dưới dạng SVG
- chuyển hình dạng sang SVG
- căn chỉnh hình dạng
- lật hình dạng
- PowerPoint
- bản trình chiếu
- Python
- Java
- Aspose.Slides
description: "Tìm hiểu cách nhận dạng, điều chỉnh, sao chép, xóa, ẩn, sắp lại thứ tự, xuất, căn chỉnh và lật các hình dạng trong bản trình chiếu với Aspose.Slides cho Python qua Java."
---
## **Tổng quan**

Aspose.Slides for Python via Java đại diện cho các hình dạng trên một slide như một [ShapeCollection](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapecollection/) có thứ tự. Bộ sưu tập vừa là nơi bạn tìm và sửa đổi các hình dạng, vừa là nguồn của thứ tự xếp chồng: chỉ mục `0` là hình dạng ở phía sau nhất, trong khi chỉ mục cuối cùng là hình dạng ở phía trước nhất.

Bài viết này tuân theo mô hình đó. Đầu tiên nó giải thích cách nhận dạng một hình dạng một cách đáng tin cậy và chỉnh sửa các điểm điều chỉnh hình dạng được đặt trước, sau đó cho thấy cách sao chép, xóa, ẩn và sắp lại thứ tự các hình dạng. Các phần cuối cùng đề cập đến định dạng cấp layout, xuất SVG, căn chỉnh và cài đặt lật. Mỗi ví dụ là độc lập, vì vậy bạn có thể chỉ sử dụng các thao tác mà quy trình làm việc của bạn yêu cầu.

## **Xác định và Tìm Kiếm Hình Dạng**

Các chỉ mục trong bộ sưu tập tiện lợi khi xử lý một tệp đã biết, nhưng chúng không phải là định danh ổn định. Thêm, xóa hoặc sắp lại thứ tự một hình dạng có thể làm thay đổi chỉ mục của nó. Hãy chọn một định danh dựa trên cách bản trình bày được tạo và duy trì:

- [Name](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#getName) là hữu ích cho các mẫu do nhà phát triển kiểm soát và dễ kiểm tra trong Selection Pane của PowerPoint. Tên có thể được chỉnh sửa và không được đảm bảo là duy nhất, vì vậy hãy thiết lập quy tắc đặt tên nếu mã phụ thuộc vào chúng.
- [AlternativeText](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#getAlternativeText) hữu ích khi mô tả khả năng tiếp cận hoặc thẻ do tác giả cung cấp đã xác định hình dạng. Nó hiển thị cho người dùng, có thể được bản địa hóa hoặc viết lại cho khả năng tiếp cận, và không được đảm bảo là duy nhất. Đừng âm thầm dùng lại văn bản khả năng tiếp cận có ý nghĩa làm khóa cơ sở dữ liệu.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#getOfficeInteropShapeId) là một định danh chỉ đọc, duy nhất trong một slide và tương ứng với ID hình dạng được PowerPoint interop sử dụng. Sử dụng nó khi tích hợp với PowerPoint hoặc khi bạn cần một tham chiếu không mơ hồ trong suốt vòng đời của một hình dạng. Một hình dạng được sao chép hoặc tạo lại là một hình dạng khác và nhận ID riêng của nó.

Phương thức [getUniqueId](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#getUniqueId) liên quan trả về một định danh có phạm vi toàn bộ bản trình bày, nhưng định danh này dành cho add-in và có thể được gán lại. Nó không nên được coi là khóa bên ngoài cố định. Nếu nhận dạng lâu dài là cần thiết, hãy giữ ánh xạ trong dữ liệu ứng dụng và xác nhận rằng hình dạng mong đợi vẫn tồn tại.

Ví dụ sau tìm kiếm theo tên bằng so sánh chính xác và báo cáo ID interop có phạm vi slide. Khi mẫu không chứa hình dạng mong đợi, mã sẽ báo kết quả đó thay vì tiếp tục với đối tượng sai.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    target_shape = None
    for shape in slide.getShapes():
        if shape.getName() == "RevenueChart":
            target_shape = shape
            break

    if target_shape is None:
        print("The shape 'RevenueChart' was not found on slide 1.")
    else:
        print(f"Found {target_shape.getName()}; interop ID: {target_shape.getOfficeInteropShapeId()}")
finally:
    presentation.dispose()
```

Khi một thao tác cụ thể cho một loại hình dạng, hãy kiểm tra loại trước khi sử dụng các thành viên riêng loại. Ví dụ này cập nhật văn bản và văn bản thay thế chỉ nếu đối tượng có tên là một [AutoShape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/autoshape/).

```python
import jpime
import asposeslides

if not jpime.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import AutoShape, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    candidate = None
    for shape in slide.getShapes():
        if shape.getName() == "StatusLabel":
            candidate = shape
            break

    if isinstance(candidate, AutoShape):
        candidate.getTextFrame().setText("Approved")
        candidate.setAlternativeText("Approval status: approved")
        presentation.save("identified-shape.pptx", SaveFormat.Pptx)
    else:
        print("'StatusLabel' is missing or is not an AutoShape.")
finally:
    presentation.dispose()
```

## **Xác Định và Chỉnh Sửa Các Điều Chỉnh Hình Dạng Được Đặt Trước**

Các hình dạng hình học được đặt trước có thể hiển thị các điểm điều chỉnh kiểm soát các tính năng như kích thước góc, tỷ lệ mũi tên hoặc góc cung. Truy cập chúng qua bộ sưu tập chỉ đọc [GeometryShape.getAdjustments](https://reference.aspose.com/slides/vi/python-java/aspose.slides/geometryshape/#getAdjustments). Bộ sưu tập được cung cấp bởi hình dạng, nhưng mỗi [AdjustValue](https://reference.aspose.com/slides/vi/python-java/aspose.slides/adjustvalue/) chứa một giá trị có thể thay đổi.

Đừng chỉ dựa vào chỉ mục bộ sưu tập cố định. Duyệt qua các điều chỉnh và kiểm tra phương thức chỉ đọc [getType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/adjustvalue/#getType), giá trị [ShapeAdjustmentType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapeadjustmenttype/) mô tả điều chỉnh nào đang kiểm soát. Phương thức chỉ đọc [getName](https://reference.aspose.com/slides/vi/python-java/aspose.slides/adjustvalue/#getName) cung cấp thông tin nhận dạng bổ sung và đặc biệt hữu ích khi một preset chứa hơn một điều chỉnh có cùng kiểu ngữ nghĩa.

Sử dụng phương thức giá trị phù hợp với ý nghĩa của điều chỉnh:

| Loại điều chỉnh | Mục đích | Giá trị cần thay đổi |
|---|---|---|
| [CornerSize](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapeadjustmenttype/#CornerSize) | Kích thước góc bo tròn | [setRawValue](https://reference.aspose.com/slides/vi/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [ArrowTailThickness](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapeadjustmenttype/#ArrowTailThickness) | Độ dày của đuôi mũi tên | [setRawValue](https://reference.aspose.com/slides/vi/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [ArrowheadLength](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapeadjustmenttype/#ArrowheadLength) | Độ dài của đầu mũi tên | [setRawValue](https://reference.aspose.com/slides/vi/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [ArrowheadWidth](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapeadjustmenttype/#ArrowheadWidth) | Chiều rộng của đầu mũi tên | [setRawValue](https://reference.aspose.com/slides/vi/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [StartAngle](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapeadjustmenttype/#StartAngle) | Góc bắt đầu của một phần tròn hoặc cung | [setAngleValue](https://reference.aspose.com/slides/vi/python-java/aspose.slides/adjustvalue/#setAngleValue) |
| [EndAngle](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapeadjustmenttype/#EndAngle) | Góc kết thúc của một phần tròn hoặc cung | [setAngleValue](https://reference.aspose.com/slides/vi/python-java/aspose.slides/adjustvalue/#setAngleValue) |

[getType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/adjustvalue/#getType) và [getName](https://reference.aspose.com/slides/vi/python-java/aspose.slides/adjustvalue/#getName) trả về thông tin chỉ đọc. [getRawValue](https://reference.aspose.com/slides/vi/python-java/aspose.slides/adjustvalue/#getRawValue) và [setRawValue](https://reference.aspose.com/slides/vi/python-java/aspose.slides/adjustvalue/#setRawValue) làm việc với một số nguyên trong đơn vị hình học gốc của preset, trong khi [getAngleValue](https://reference.aspose.com/slides/vi/python-java/aspose.slides/adjustvalue/#getAngleValue) và [setAngleValue](https://reference.aspose.com/slides/vi/python-java/aspose.slides/adjustvalue/#setAngleValue) làm việc với góc tính bằng độ. Số lượng, thứ tự, ý nghĩa và phạm vi hợp lệ của các điều chỉnh phụ thuộc vào [ShapeType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/geometryshape/#getShapeType) của preset. Một giá trị hợp lệ cho một preset có thể không hợp lệ hoặc có hiệu ứng khác cho preset khác.

Khi [getType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/adjustvalue/#getType) trả về [ShapeAdjustmentType.Custom](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapeadjustmenttype/#Custom), API không nhận ra ý nghĩa ngữ nghĩa tiêu chuẩn. Kiểm tra [getName](https://reference.aspose.com/slides/vi/python-java/aspose.slides/adjustvalue/#getName), loại preset và giá trị hiện có, và giữ nguyên điều chỉnh trừ khi ý nghĩa và phạm vi mong đợi đã được biết. Ngay cả với các kiểu đã được công nhận, hãy kiểm tra xem cùng một kiểu có xuất hiện hơn một lần không trước khi chọn giá trị. Bài viết [Connector](/slides/vi/python-java/connector/) cho thấy tình huống này với các điều chỉnh uốn của connector.

Ví dụ hoàn chỉnh sau tạo các phiên bản mặc định và đã chỉnh sửa của ba hình dạng preset. Nó duyệt qua mọi điều chỉnh, báo cáo tên và loại, thay đổi các giá trị liên quan đến kích thước qua [setRawValue](https://reference.aspose.com/slides/vi/python-java/aspose.slides/adjustvalue/#setRawValue), thay đổi góc qua [setAngleValue](https://reference.aspose.com/slides/vi/python-java/aspose.slides/adjustvalue/#setAngleValue), và lưu kết quả. Cột trái giữ hình học mặc định; cột phải hiển thị hình chữ nhật bo tròn đã chỉnh, mũi tên bốn chiều, và phần tròn.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeAdjustmentType, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Thêm tiêu đề cho các cột hình dạng mặc định và đã điều chỉnh.
    default_column_label = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 20, 250, 30)
    default_column_label.getTextFrame().setText("Default preset geometry")
    adjusted_column_label = slide.getShapes().addAutoShape(ShapeType.Rectangle, 390, 20, 250, 30)
    adjusted_column_label.getTextFrame().setText("Modified adjustment values")

    slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 80, 70, 160, 70)
    modified_rounded_rectangle = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 430, 70, 160, 70)
    modified_rounded_rectangle.setName("ModifiedRoundedRectangle")

    slide.getShapes().addAutoShape(ShapeType.QuadArrow, 80, 180, 160, 110)
    modified_arrow = slide.getShapes().addAutoShape(ShapeType.QuadArrow, 430, 180, 160, 110)
    modified_arrow.setName("ModifiedQuadArrow")

    slide.getShapes().addAutoShape(ShapeType.Pie, 95, 330, 130, 130)
    modified_pie = slide.getShapes().addAutoShape(ShapeType.Pie, 445, 330, 130, 130)
    modified_pie.setName("ModifiedPie")

    shapes_to_adjust = [modified_rounded_rectangle, modified_arrow, modified_pie]

    for shape in shapes_to_adjust:
        for adjustment_index in range(shape.getAdjustments().size()):
            adjustment = shape.getAdjustments().get_Item(adjustment_index)
            print(f"{shape.getName()} / {adjustment.getName()}: {adjustment.getType()}")

            if adjustment.getType() == ShapeAdjustmentType.CornerSize:
                adjustment.setRawValue(5000)
            elif adjustment.getType() == ShapeAdjustmentType.ArrowTailThickness:
                adjustment.setRawValue(25000)
            elif adjustment.getType() == ShapeAdjustmentType.ArrowheadLength:
                adjustment.setRawValue(30000)
            elif adjustment.getType() == ShapeAdjustmentType.ArrowheadWidth:
                adjustment.setRawValue(40000)
            elif adjustment.getType() == ShapeAdjustmentType.StartAngle:
                adjustment.setAngleValue(30)
            elif adjustment.getType() == ShapeAdjustmentType.EndAngle:
                adjustment.setAngleValue(300)
            elif adjustment.getType() == ShapeAdjustmentType.Custom:
                print(f"Custom adjustment '{adjustment.getName()}' was not changed.")

    presentation.save("preset-shape-adjustments.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kiểm tra kiểu ngữ nghĩa trước khi thay đổi giá trị làm cho mã rõ ràng về mục đích và tránh giả định rằng một chỉ mục bộ sưu tập cụ thể có cùng ý nghĩa giữa các hình dạng preset khác nhau.

## **Chỉnh Sửa Bộ Sưu Tập Hình Dạng**

Các phương thức add, clone, remove và reorder hoạt động trên bộ sưu tập ngay lập tức. Nếu một thao tác thay đổi số lượng hoặc thứ tự của các hình dạng, không tiếp tục dựa vào các chỉ mục đã lấy trước thao tác đó.

### **Sao Chép Một Hình Dạng**

[addClone](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapecollection/#addClone) tạo một bản sao độc lập và thêm vào cuối bộ sưu tập đích. [insertClone](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapecollection/#insertClone) cũng tạo một bản sao nhưng đặt nó ở chỉ mục z-order chỉ định. Các overload chấp nhận tọa độ di chuyển bản sao mà không thay đổi kích thước; các overload có chiều rộng và chiều cao cũng có thể thay đổi kích thước.

Ví dụ tạo một slide đích, sao chép một hình chữ nhật có nhãn lên phía trước, và chèn bản sao thứ hai ở phía sau. Thay đổi bất kỳ bản sao nào cũng không sửa đổi hình dạng nguồn.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation, SaveFormat, ShapeType, SlideLayoutType

presentation = Presentation()
try:
    source_slide = presentation.getSlides().get_Item(0)
    source_shape = source_slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 180, 60)
    source_shape.setName("SourceLabel")
    source_shape.getTextFrame().setText("Source")

    blank_layout = presentation.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank)
    destination_slide = presentation.getSlides().addEmptySlide(blank_layout)

    front_clone_shape = destination_slide.getShapes().addClone(source_shape, 80, 80)
    front_clone_shape.setName("FrontClone")
    if isinstance(front_clone_shape, AutoShape):
        front_clone_shape.getTextFrame().setText("Front clone")
    else:
        print("The front clone is not an AutoShape; its text was not changed.")

    back_clone_shape = destination_slide.getShapes().insertClone(0, source_shape, 80, 180)
    back_clone_shape.setName("BackClone")
    if isinstance(back_clone_shape, AutoShape):
        back_clone_shape.getTextFrame().setText("Back clone")
    else:
        print("The back clone is not an AutoShape; its text was not changed.")

    presentation.save("cloned-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Sao chép cũng sao chép nội dung và định dạng của hình dạng, bao gồm tên và văn bản thay thế. Gán các định danh logic mới cho bản sao khi các giá trị đó phải là duy nhất. Các tài nguyên được các hình dạng phức tạp sử dụng được trình bày quản lý, nhưng một bản sao vẫn là một mục mới trong bộ sưu tập với định danh hình dạng mới.

### **Xóa Các Hình Dạng**

[remove](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapecollection/#remove) xóa một đối tượng hình dạng cụ thể khỏi bộ sưu tập của nó. Khi xóa nhiều kết quả trong quá trình lặp có chỉ mục, duyệt từ cuối để mỗi chỉ mục còn lại vẫn hợp lệ.

Ví dụ này xóa mọi hình dạng có tên được chỉ định. Nó đọc hình dạng tại chỉ mục hiện tại, không phải một mục bộ sưu tập cố định, và không ép kiểu hình dạng một cách không cần thiết.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    keep_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 140, 60)
    keep_shape.setName("Keep")

    first_temporary_shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 220, 40, 80, 80)
    first_temporary_shape.setName("Temporary")

    second_temporary_shape = slide.getShapes().addAutoShape(ShapeType.Triangle, 340, 40, 100, 80)
    second_temporary_shape.setName("Temporary")

    for i in range(slide.getShapes().size() - 1, -1, -1):
        shape = slide.getShapes().get_Item(i)
        if shape.getName() == "Temporary":
            slide.getShapes().remove(shape)

    presentation.save("removed-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Sau khi xóa, số lượng hình dạng và chỉ mục của các hình dạng sau thay đổi. Tham chiếu tới các hình dạng không bị ảnh hưởng vẫn đáng tin cậy hơn so với các chỉ mục đã lưu. Cũng cần xem xét các connector, hoạt ảnh và các tính năng trình chiếu khác có thể tham chiếu tới đối tượng đã xóa; xóa một hình dạng hiển thị có thể thay đổi hơn cả giao diện slide.

### **Ẩn Một Hình Dạng**

Đặt [Hidden](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#setHidden) thành `True` giữ hình dạng trong bộ sưu tập nhưng ngăn nó xuất hiện trong slide show bình thường. Chỉ mục, định dạng và nội dung của nó vẫn khả dụng cho mã, vì vậy ẩn phù hợp cho các yếu tố tùy chọn có thể được khôi phục sau.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    visible_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 160, 60)
    visible_shape.setName("VisibleLabel")

    optional_shape = slide.getShapes().addAutoShape(ShapeType.Moon, 240, 40, 100, 100)
    optional_shape.setName("OptionalDecoration")

    for shape in slide.getShapes():
        if shape.getName() == "OptionalDecoration":
            shape.setHidden(True)

    presentation.save("hidden-shape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ẩn không phải là xóa hay bảo mật. Đối tượng vẫn có thể được người dùng hoặc mã phát hiện và bỏ ẩn, và nó vẫn là một phần của tệp trình chiếu.

### **Thay Đổi Thứ Tự Z**

Các hình dạng chồng lên nhau được vẽ theo thứ tự trong bộ sưu tập. [reorder](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapecollection/#reorder) di chuyển một hình dạng hiện có đến một chỉ mục mục tiêu mà không sao chép. Chỉ mục `0` là phía sau; [size](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapecollection/#size) của bộ sưu tập trừ một là phía trước.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    blue_rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 220, 120)
    blue_rectangle.setName("BlueRectangle")
    blue_rectangle.getFillFormat().setFillType(FillType.Solid)
    blue_rectangle.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    orange_ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 180, 140, 220, 120)
    orange_ellipse.setName("OrangeEllipse")
    orange_ellipse.getFillFormat().setFillType(FillType.Solid)
    orange_ellipse.getFillFormat().getSolidFillColor().setColor(Color.ORANGE)

    slide.getShapes().reorder(slide.getShapes().size() - 1, blue_rectangle)
    presentation.save("reordered-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Hình chữ nhật được tạo đầu tiên và ban đầu nằm phía sau hình ellipse. Di chuyển nó tới chỉ mục cuối cùng đưa nó lên phía trước. Hoàn thiện thứ tự Z sau khi thêm hoặc sao chép tất cả các hình dạng liên quan, vì các thao tác đó thêm hoặc chèn mục mới vào bộ sưu tập và có thể thay đổi ngăn xếp dự định.

## **Kiểm Tra Hình Dạng Trên Slide Layout**

Các slide thông thường, slide layout và slide master có các bộ sưu tập hình dạng riêng biệt. Một hình dạng trong bộ sưu tập layout không phải là cùng một đối tượng với một hình dạng tương tự trên slide thông thường. Kiểm tra các hình dạng layout khi bạn cần hiểu hoặc thay đổi định dạng do layout cung cấp.

Ví dụ sau đọc [FillFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#getFillFormat) và [LineFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#getLineFormat) của mỗi hình dạng layout mà không giả định rằng mọi hình dạng đều là một [AutoShape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/autoshape/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    for layout_slide in presentation.getLayoutSlides():
        for shape in layout_slide.getShapes():
            fill_type = shape.getFillFormat().getFillType()
            line_width = shape.getLineFormat().getWidth()
            print(f"{layout_slide.getName()} / {shape.getName()}: fill={fill_type}, line width={line_width}")
finally:
    presentation.dispose()
```

Chỉnh sửa một layout có thể ảnh hưởng tới nhiều slide sử dụng nó. Trước khi thay đổi một hình dạng layout, xác định xem một slide thông thường có kế thừa đối tượng này hay chứa ghi đè cục bộ, và kiểm tra mọi slide sử dụng layout đó.

## **Xuất Hình Dạng Sang SVG**

Phương thức `writeAsSvg` của [Shape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/) ghi nội dung đã render của một hình dạng vào một luồng. Kết quả chứa hình dạng, không phải toàn bộ nền slide hay các hình dạng lân cận.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from pathlib import Path
from java.io import ByteArrayOutputStream

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    if slide.getShapes().size() == 0:
        print("Slide 1 does not contain a shape to export.")
    else:
        shape = slide.getShapes().get_Item(0)
        svg_stream = ByteArrayOutputStream()
        try:
            shape.writeAsSvg(svg_stream)
            svg_bytes = bytes(svg_stream.toByteArray())
            Path("shape.svg").write_bytes(svg_bytes)
        except OSError as exception:
            print(f"The SVG file could not be written: {exception}")
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

Giữ bản trình chiếu mở trong khi render. Đầu ra phụ thuộc vào định dạng của hình dạng và các tài nguyên như phông chữ và hình ảnh. Nếu bạn cần toàn bộ thành phần, hãy xuất slide chứ không phải một hình dạng riêng lẻ. Người gọi sở hữu luồng và phải đóng nó.

## **Căn Chỉnh Hình Dạng**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slideutil/#alignShapes) có các overload để căn chỉnh toàn bộ các hình dạng hoặc các chỉ mục bộ sưu tập được chọn. [ShapesAlignmentType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapesalignmenttype/) chỉ định cạnh, đường trung tâm, hoặc chế độ phân phối. Đặt `align_to_slide` thành `True` để sử dụng các cạnh slide; đặt thành `False` để căn chỉnh các hình dạng đã chọn tương đối với nhau.

Ví dụ này căn ba hình dạng tới cạnh trên của slide. Các tham chiếu hình dạng trả về được chuyển thành chỉ mục hiện tại ngay trước khi căn chỉnh.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType, ShapesAlignmentType, SlideUtil

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    first_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 60, 80, 120, 50)
    second_shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 240, 160, 120, 50)
    third_shape = slide.getShapes().addAutoShape(ShapeType.Triangle, 420, 240, 120, 50)
    first_shape.setName("FirstAlignedShape")
    second_shape.setName("SecondAlignedShape")
    third_shape.setName("ThirdAlignedShape")

    shape_indexes = jpype.JArray(jpype.JInt)([slide.getShapes().indexOf(first_shape), slide.getShapes().indexOf(second_shape), slide.getShapes().indexOf(third_shape)])

    SlideUtil.alignShapes(ShapesAlignmentType.AlignTop, True, slide, shape_indexes)
    presentation.save("aligned-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Căn chỉnh thay đổi vị trí, không phải thứ tự Z. Căn chỉnh tương đối thường cần ít nhất hai hình dạng, trong khi phân phối ngang hoặc dọc cần đủ hình dạng để xác định khoảng cách. Tính lại chỉ mục nếu bạn chỉnh sửa bộ sưu tập trước khi gọi phương thức.

## **Lật Một Hình Dạng**

Lớp [ShapeFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapeframe/) lưu trữ vị trí, kích thước, cài đặt lật ngang và dọc, và xoay. Các giá trị [getFlipH](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapeframe/#getFlipH) và [getFlipV](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapeframe/#getFlipV) sử dụng [NullableBool](https://reference.aspose.com/slides/vi/python-java/aspose.slides/nullablebool/): `True` bật lật, `False` tắt, và `NotDefined` giữ trạng thái không xác định/mặc định.

Bản trình chiếu đầu vào dưới đây chứa một hình dạng chưa được lật.

![Hình dạng trước khi lật](shape_to_be_flipped.png)

Ví dụ này giữ mọi giá trị khung khác và chỉ thay thế hai cài đặt lật. Điều này quan trọng vì gán một [Frame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#setFrame) mới sẽ thay thế toàn bộ khung.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat, ShapeFrame

presentation = Presentation("sample.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    frame = shape.getFrame()

    print(f"Horizontal flip before change: {frame.getFlipH()}")
    print(f"Vertical flip before change: {frame.getFlipV()}")

    flipped_frame = ShapeFrame(frame.getX(), frame.getY(), frame.getWidth(), frame.getHeight(), NullableBool.True_, NullableBool.True_, frame.getRotation())
    shape.setFrame(flipped_frame)

    presentation.save("flipped-shape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Hình dạng đã lưu được phản chiếu ngang và dọc trong khi giữ vị trí, kích thước và xoay.

![Hình dạng sau khi lật](flipped_shape.png)

## **FAQ**

**Should I use a collection index as a shape identifier?**

Chỉ cho các xử lý ngắn hạn khi bộ sưu tập sẽ không thay đổi trước khi chỉ mục được sử dụng. Ưu tiên một quy ước [Name](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#getName) hoặc [AlternativeText](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#getAlternativeText) đã được xác thực cho các mẫu được tạo, hoặc [OfficeInteropShapeId](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#getOfficeInteropShapeId) cho công việc interop có phạm vi slide.

**Does hiding a shape remove it from the z-order?**

Không. Một hình dạng ẩn vẫn còn trong bộ sưu tập với cùng chỉ mục. Nó có thể được tìm, sắp lại, chỉnh sửa, hoặc làm lại hiển thị.

**Why did a cloned shape appear in front of another shape?**

[addClone](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapecollection/#addClone) thêm bản sao vào cuối bộ sưu tập, đó là phía trước của thứ tự Z. Sử dụng [insertClone](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapecollection/#insertClone) để chọn chỉ mục ban đầu hoặc [reorder](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapecollection/#reorder) sau khi đã thêm tất cả các hình dạng.

**Can I use a fixed index to identify a preset shape adjustment?**

Chỉ sau khi xác thực preset và bố cục bộ sưu tập chính xác. Ưu tiên duyệt qua [GeometryShape.getAdjustments](https://reference.aspose.com/slides/vi/python-java/aspose.slides/geometryshape/#getAdjustments) và kiểm tra [AdjustValue.getType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/adjustvalue/#getType); sử dụng [AdjustValue.getName](https://reference.aspose.com/slides/vi/python-java/aspose.slides/adjustvalue/#getName) như thông tin bổ sung khi cùng một kiểu ngữ nghĩa xuất hiện hơn một lần.