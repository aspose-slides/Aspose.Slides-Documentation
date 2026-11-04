---
title: Định dạng các hình PowerPoint trong Python qua Java
linktitle: Định dạng Hình
type: docs
weight: 20
url: /vi/python-java/shape-formatting/
keywords:
- định dạng hình
- định dạng đường
- hiệu ứng phác thảo
- đường hình phác thảo
- định dạng kiểu nối
- đổ màu gradient
- đổ màu hoa văn
- đổ hình ảnh
- đổ kết cấu
- đổ màu đồng nhất
- độ trong suốt hình
- hiển thị hình đen-trắng
- hiển thị hình thang độ xám
- xoay hình
- hiệu ứng bo 3D
- hiệu ứng xoay 3D
- đặt lại định dạng
- PowerPoint
- bản trình bày
- Python
- Java
- Aspose.Slides
description: "Tìm hiểu cách định dạng các hình PowerPoint trong Python qua Java bằng Aspose.Slides—đặt các kiểu đổ, đường và hiệu ứng cho tệp PPT và PPTX một cách chính xác và kiểm soát toàn diện."
---
## **Giới thiệu**

Định dạng các hình trong PowerPoint bằng cách điều chỉnh viền, nền và hiệu ứng. Aspose.Slides for Python via Java cho phép bạn kiểm soát các cài đặt này bằng chương trình, bao gồm độ trong suốt, xoay và định dạng 3D.

![Các tùy chọn định dạng hình trong PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for Python via Java cung cấp các lớp và phương thức cho phép bạn định dạng các hình bằng các tùy chọn giống như trong PowerPoint.

## **Định dạng Đường viền**

Sử dụng [Shape.getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) để kiểm soát viền của một hình. Ví dụ này tạo một hình chữ nhật không nền với viền màu xanh, dạng gạch đứt. [LineFormat.setStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setStyle) chọn một đường hợp chất dày‑mỏng, trong khi [LineFormat.setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setWidth) đặt độ rộng của nó thành 7 điểm và [LineFormat.setDashStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setDashStyle) chọn mẫu gạch.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineDashStyle, LineStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().setStyle(LineStyle.ThickThin)
    shape.getLineFormat().setWidth(7)
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("formatted_lines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kết quả:

![Các đường được định dạng trong bản trình bày](formatted-lines.png)

### **Đặt Mẫu Gạch Đường Tùy Chỉnh**

Sử dụng [LineFormat.setCustomDashPattern](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setCustomDashPattern) khi các kiểu đường có sẵn không cung cấp độ dài gạch và khoảng trống cần thiết, ví dụ cho viền thương hiệu hoặc sơ đồ kỹ thuật. Gán một mẫu sẽ tự động thay đổi kiểu gạch của đường thành [LineDashStyle.Custom](https://reference.aspose.com/slides/python-java/aspose.slides/linedashstyle/).

Các mục trong mảng xen kẽ giữa độ dài gạch và khoảng trống, bắt đầu bằng một gạch. Mỗi giá trị là bội số của độ rộng đường: `[4, 2]` ở độ rộng 3 điểm tạo ra một gạch dài 12 điểm tiếp theo là khoảng trống 6 điểm. Sử dụng các cặp giá trị hữu hạn, không âm để xác định các đoạn gạch‑khoảng trống hoàn chỉnh. Ví dụ này sử dụng các giá trị dương để mọi gạch và khoảng trống đều hiển thị.

Ví dụ này tạo năm đường màu xanh dài bằng nhau và có đầu thẳng. Ba đường đầu tiên so sánh các mẫu ở độ rộng 3 điểm. Đường thứ tư lặp lại mẫu đầu tiên ở độ rộng gấp đôi, làm tăng gạ­ch và khoảng trống đồng thời. Đường thứ năm chuyển từ mẫu tùy chỉnh sang đường liền.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineArrowheadStyle, LineCapStyle, LineDashStyle, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(600, 300, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    patterns = [
        [4, 2],
        [1, 2],
        [6, 2, 1, 2],
        [4, 2],
        [4, 2]
    ]

    for i, pattern in enumerate(patterns):
        line = slide.getShapes().addAutoShape(ShapeType.Line, 50, 50 + i * 50, 500, 0)
        line.getLineFormat().setWidth(6 if i == 3 else 3)
        line.getLineFormat().getFillFormat().setFillType(FillType.Solid)
        color = Color(0, 0, 139)
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(color)
        line.getLineFormat().setCapStyle(LineCapStyle.Flat)
        line.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.None_)
        line.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.None_)
        line.getLineFormat().setCustomDashPattern(jpype.JArray(jpype.JFloat)(pattern))

    # Trả về dòng cuối cùng thành kiểu solid.
    slide.getShapes().get_Item(4).getLineFormat().setDashStyle(LineDashStyle.Solid)

    presentation.save("custom_dash_patterns.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Để quay lại kiểu gạch đã định sẵn, hãy truyền [LineDashStyle.Dash](https://reference.aspose.com/slides/python-java/aspose.slides/linedashstyle/) vào [LineFormat.setDashStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setDashStyle). Kiểu được chọn sẽ điều khiển cách hiển thị của đường.

Kết quả trong PowerPoint, từ trên xuống dưới: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; và **Solid, 3 pt**.

![Ba mẫu gạch tùy chỉnh, một đường rộng hơn sử dụng mẫu đầu tiên, và một đường liền trong PowerPoint](custom-dash-patterns.png)

### **Đặt Kiểu Đầu Đường**

Sử dụng [LineFormat.setCapStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setCapStyle) để đặt đầu cho một đường mở. Lớp [LineCapStyle](https://reference.aspose.com/slides/python-java/aspose.slides/linecapstyle/) cung cấp ba kiểu đầu rõ ràng:

- `Flat`: Đường dừng lại tại điểm cuối.
- `Round`: Một đầu vòng nửa tròn kéo dài ra ngoài điểm cuối một nửa độ rộng đường.
- `Square`: Một đầu vuông kéo dài ra ngoài điểm cuối một nửa độ rộng đường.

Lớp cũng bao gồm `NotDefined`, nghĩa là không có kiểu đầu nào được gán một cách rõ ràng.

Đầu khác với mũi tên, những ký hiệu được thêm vào đầu đường, và các mối nối, những yếu tố điều khiển góc giữa các đoạn đường. Ví dụ này tắt mũi tên qua [LineFormat.setBeginArrowheadStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setBeginArrowheadStyle) và [LineFormat.setEndArrowheadStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setEndArrowheadStyle) sao cho chỉ so sánh các hình dạng đầu.

Ví dụ sau tạo ba đường ngang hầu hết giống nhau, rộng 20 điểm. Từ trên xuống dưới, chúng sử dụng đầu thẳng, vòng và vuông. Các điểm cuối của chúng có cùng tọa độ ngang; các đầu vòng và vuông mở rộng 10 điểm ra ngoài mỗi điểm cuối.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineArrowheadStyle, LineCapStyle, LineDashStyle, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(500, 240, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    cap_styles = [LineCapStyle.Flat, LineCapStyle.Round, LineCapStyle.Square]

    for i, cap_style in enumerate(cap_styles):
        line = slide.getShapes().addAutoShape(ShapeType.Line, 100, 50 + i * 70, 300, 0)
        line.getLineFormat().setWidth(20)
        line.getLineFormat().getFillFormat().setFillType(FillType.Solid)
        color = Color(0, 0, 139)
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(color)
        line.getLineFormat().setDashStyle(LineDashStyle.Solid)
        line.getLineFormat().setCapStyle(cap_style)
        line.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.None_)
        line.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.None_)

    presentation.save("line_caps.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kết quả trong PowerPoint, từ trên xuống dưới: **Flat**, **Round**, và **Square**.

![Đầu thẳng, vòng và vuông trên các đường dày giống nhau trong PowerPoint](line-caps.png)

## **Áp dụng Hiệu Ứng Phác Thảo cho Đường Hình**

Hiệu ứng phác thảo khiến đường của hình trông như được vẽ tay. Sử dụng [Shape.getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) để truy cập cài đặt đường, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getSketchFormat) để truy cập cài đặt phác thảo, và [SketchFormat.setSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/sketchformat/#setSketchType) để chọn một giá trị từ lớp [LineSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/).

Đoạn mã Python dưới đây cho thấy cách áp dụng hiệu ứng [LineSketchType.Curved](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/), đọc giá trị được gán một cách rõ ràng, và loại bỏ hiệu ứng bằng [LineSketchType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LineSketchType, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100)

    sketch_format = shape.getLineFormat().getSketchFormat()
    sketch_format.setSketchType(LineSketchType.Curved)
    explicit_sketch_type = sketch_format.getSketchType()
    print("Explicit sketch type:", explicit_sketch_type)
    sketch_format.setSketchType(LineSketchType.None_)
finally:
    presentation.dispose()
```

Giá trị trả về bởi [SketchFormat.getSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/sketchformat/#getSketchType) đại diện cho cài đặt được gán trực tiếp cho hình. Nếu định dạng đường có thể được kế thừa từ một chủ đề, slide mẫu hoặc slide bố cục, hãy sử dụng [LineFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getEffective) và đọc kiểu phác thảo từ định dạng đường thực tế được trả về, như minh họa bên dưới. Giá trị thực tế phản ánh định dạng thực sự được áp dụng sau khi kế thừa được giải quyết. Ví dụ này yêu cầu một bản trình bày hiện có có ít nhất một hình trên slide đầu tiên và in ra cả hai giá trị:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    line_format = shape.getLineFormat()
    explicit_sketch_type = line_format.getSketchFormat().getSketchType()
    effective_line_format = line_format.getEffective()
    effective_sketch_type = effective_line_format.getSketchFormat().getSketchType()

    print("Explicit sketch type:", explicit_sketch_type)
    print("Effective sketch type:", effective_sketch_type)
finally:
    presentation.dispose()
```

## **Định dạng Kiểu Nối**

Ba tùy chọn kiểu nối:

* Round
* Miter
* Bevel

Kiểu nối điều khiển cách hai đoạn viền gặp nhau ở một góc. Sử dụng **Round** cho các góc tròn, **Miter** cho các góc nhọn, hoặc **Bevel** cho các góc đã bị bớt.

![Kiểu nối trong bản trình bày](join-style-powerpoint.png)

Ví dụ này tạo ba hình chữ nhật đen với viền xanh rộng 15 điểm. Nó sử dụng [LineFormat.setJoinStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setJoinStyle) để đặt các giá trị miter, bevel và round của [LineJoinStyle](https://reference.aspose.com/slides/python-java/aspose.slides/linejoinstyle/), tương ứng, để so sánh cách các góc được vẽ.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineJoinStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    miter_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75)
    bevel_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75)
    round_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75)

    miter_shape.getFillFormat().setFillType(FillType.Solid)
    miter_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    bevel_shape.getFillFormat().setFillType(FillType.Solid)
    bevel_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    round_shape.getFillFormat().setFillType(FillType.Solid)
    round_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    miter_shape.getLineFormat().setWidth(15)
    bevel_shape.getLineFormat().setWidth(15)
    round_shape.getLineFormat().setWidth(15)

    miter_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    miter_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    bevel_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    bevel_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    round_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    round_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    miter_shape.getLineFormat().setJoinStyle(LineJoinStyle.Miter)
    bevel_shape.getLineFormat().setJoinStyle(LineJoinStyle.Bevel)
    round_shape.getLineFormat().setJoinStyle(LineJoinStyle.Round)

    miter_shape.getTextFrame().setText("Miter Join Style")
    bevel_shape.getTextFrame().setText("Bevel Join Style")
    round_shape.getTextFrame().setText("Round Join Style")

    presentation.save("join_styles.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Giới Hạn Nối Miter ở Các Góc Nhọn**

Sử dụng [LineFormat.setMiterLimit](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setMiterLimit) cùng với [LineFormat.setJoinStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setJoinStyle) được đặt thành [LineJoinStyle.Miter](https://reference.aspose.com/slides/python-java/aspose.slides/linejoinstyle/) để giới hạn độ dài của một góc nhọn.

Giới hạn là tỷ lệ giữa khoảng cách giữa các góc trong và ngoài của nối so với độ rộng đường. Ví dụ, giá trị `8` cho phép độ dài miter lên tới tám lần độ rộng đường; nó không phải là một đo lường bằng điểm. Nếu góc vượt quá giới hạn, PowerPoint sẽ sử dụng nối bevel ở góc đó. Giới hạn lớn hơn cho phép các điểm nhọn hơn. Cài đặt chỉ ảnh hưởng đến các nối miter và không có ảnh hưởng nhìn thấy được khi góc vẫn nằm trong cả hai giới hạn.

Ví dụ này tạo hai tam giác không nền giống hệt nhau với viền rộng 20 điểm. Tam giác bên trái sử dụng giới hạn `2`, còn bên phải sử dụng `8`. Mỗi tam giác rộng 80 điểm và cao 160 điểm, cho tỷ lệ chiều dài miter‑so‑với‑độ‑rộng‑đường ở đỉnh trên khoảng `4.12`. Do đó, PowerPoint sẽ bevel đỉnh trái và giữ nguyên đỉnh phải.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineJoinStyle, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(500, 320, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    miter_limits = [2.0, 8.0]

    for i, miter_limit in enumerate(miter_limits):
        triangle = slide.getShapes().addAutoShape(ShapeType.Triangle, 90 + i * 240, 110, 80, 160)
        triangle.getFillFormat().setFillType(FillType.NoFill)
        triangle.getLineFormat().setWidth(20)
        triangle.getLineFormat().getFillFormat().setFillType(FillType.Solid)
        color = Color(0, 0, 139)
        triangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(color)
        triangle.getLineFormat().setJoinStyle(LineJoinStyle.Miter)
        triangle.getLineFormat().setMiterLimit(miter_limit)

    presentation.save("miter_limits.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kết quả trong PowerPoint: **Miter limit 2** ở bên trái và **miter limit 8** ở bên phải.

![Đỉnh bevel với giới hạn miter 2 và đỉnh nhọn với giới hạn miter 8 trong PowerPoint](miter-limits.png)

## **Đổ Màu Gradient**

Đổ màu gradient pha trộn các màu trên một hình. Ví dụ này đổ màu gradient tuyến tính cho một hình bầu dục với góc 45 độ, chuyển từ đỏ sang tím bằng cách sử dụng [FillFormat.getGradientFormat](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getGradientFormat). Phương thức [GradientStopCollection.addPresetColor](https://reference.aspose.com/slides/python-java/aspose.slides/gradientstopcollection/#addPresetColor) đặt các điểm dừng màu ở 0 và 1, tức là đầu và cuối của gradient. Xóa các điểm dừng hiện có đảm bảo chỉ hai màu này được sử dụng.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientShape, Presentation, PresetColor, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75)
    shape.getFillFormat().setFillType(FillType.Gradient)
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear)
    shape.getFillFormat().getGradientFormat().setLinearGradientAngle(45)
    shape.getFillFormat().getGradientFormat().getGradientStops().clear()
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, PresetColor.Purple)
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0.0, PresetColor.Red)

    presentation.save("gradient_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kết quả:

![Hình bầu dục với đổ gradient](gradient-fill.png)

Nếu một gradient trông khác trong ảnh xuất khẩu so với trong PowerPoint, hãy xem mục [Choose a Gradient Rendering Style](/slides/vi/python-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Bạn có thể chọn một kiểu hiển thị mà không thay đổi gradient được lưu trong bản trình bày.

### **Đặt Góc Gradient Tuyến Tính**

Sử dụng [GradientFormat.setLinearGradientAngle](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setLinearGradientAngle) để kiểm soát định hướng của một đổ [GradientShape.Linear](https://reference.aspose.com/slides/python-java/aspose.slides/gradientshape/). Góc được đo bằng độ và tăng theo chiều kim đồng hồ: `0` chạy từ trái sang phải, `90` từ trên xuống dưới, `180` từ phải sang trái, và `270` từ dưới lên trên. Các góc thập phân được hỗ trợ. Các góc hữu hạn ngoài `[0, 360)` sẽ được chuẩn hoá thành một vòng quay; ví dụ, `-45` thành `315` và `360` thành `0`.

Ví dụ này tạo sáu hình chữ nhật với các điểm dừng màu đỏ, xanh lá và xanh dương ở các vị trí `0`, `0.5` và `1`. Thuộc tính tỷ lệ bị tắt để góc có thể được so sánh độc lập với tỉ lệ hình chữ nhật. Các góc, từ trái sang phải, là `0`, `45`, và `90` ở hàng đầu, và `135`, `180`, và `270` ở hàng thứ hai.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientShape, NullableBool, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    angles = [0, 45, 90, 135, 180, 270]

    for i, angle in enumerate(angles):
        x = 30 + (i % 3) * 230
        y = 30 + (i // 3) * 190

        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 200, 150)
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
        shape.getFillFormat().setFillType(FillType.Gradient)

        gradient = shape.getFillFormat().getGradientFormat()
        gradient.setGradientShape(GradientShape.Linear)
        gradient.getGradientStops().clear()
        gradient.getGradientStops().add(0, Color.RED)
        gradient.getGradientStops().add(0.5, Color.GREEN)
        gradient.getGradientStops().add(1, Color.BLUE)
        gradient.setLinearGradientScaled(NullableBool.False_)
        gradient.setLinearGradientAngle(angle)

    presentation.save("linear_gradient_angles.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kết quả trong PowerPoint:

![Gradient tuyến tính ở các góc 0, 45 và 90 độ ở hàng trên, và 135, 180 và 270 độ ở hàng dưới](linear-gradient-angles.png)

### **Tỷ Lệ Gradient Tuyến Tính với Hình**

[GradientFormat.setLinearGradientScaled](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setLinearGradientScaled) nhận một giá trị [NullableBool](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/). Đặt nó thành `False_` để giữ góc gradient hình học khi tỷ lệ hình thay đổi, hoặc thành `True_` để tỷ lệ gradient cùng với chiều rộng và chiều cao của hình. Khi bật tỷ lệ, góc hiển thị có thể khác với góc đã chỉ định trên một hình không vuông.

Ví dụ sau dùng góc `45` độ và các điểm dừng màu giống như ví dụ so sánh góc. Cột bên trái sử dụng `False_`; cột bên phải sử dụng `True_`. Mỗi cột chứa một hình chữ nhật rộng ở trên và một hình chữ nhật cao ở dưới. Cả hai bắt đầu với cùng kích thước rộng; việc thay đổi chiều rộng và chiều cao của hình thứ hai cho thấy cách nền màu đáp ứng khi thay đổi kích thước mà không thay đổi cài đặt gradient.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientShape, NullableBool, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720, 460, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    scaling_options = [NullableBool.False_, NullableBool.True_]

    for column, scaled in enumerate(scaling_options):
        for row in range(2):
            x = 30 + column * 360
            y = 30 if row == 0 else 150

            shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 300, 90)
            shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
            shape.getFillFormat().setFillType(FillType.Gradient)

            gradient = shape.getFillFormat().getGradientFormat()
            gradient.setGradientShape(GradientShape.Linear)
            gradient.getGradientStops().clear()
            gradient.getGradientStops().add(0, Color.RED)
            gradient.getGradientStops().add(0.5, Color.GREEN)
            gradient.getGradientStops().add(1, Color.BLUE)
            gradient.setLinearGradientAngle(45)
            gradient.setLinearGradientScaled(scaled)

            if row == 1:
                shape.setWidth(90)
                shape.setHeight(280)

    presentation.save("linear_gradient_scaling.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kết quả trong PowerPoint, với tỷ lệ tắt ở bên trái và bật ở bên phải:

![Hình chữ nhật rộng và cao với gradient 45 độ, so sánh LinearGradientScaled False ở trái và True ở phải](linear-gradient-scaling.png)

Với tỷ lệ tắt, các dải màu chéo giữ cùng hướng trong cả hai hình. Với tỷ lệ bật, các dải kéo dài theo tỷ lệ của hình. Điều này giúp tái tạo gradient của mẫu khi điều chỉnh một hình thành kích thước khác. Trên một hình vuông, bật tỷ lệ không làm thay đổi ngoại hình của gradient `45` độ này.

Cả góc và cài đặt tỷ lệ chỉ áp dụng cho gradient tuyến tính. Chúng không điều khiển các loại đổ [GradientShape.Radial hoặc GradientShape.Rectangle](https://reference.aspose.com/slides/python-java/aspose.slides/gradientshape/).

### **Kết Hợp Góc với Hướng Gradient**

[GradientFormat.setGradientDirection](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setGradientDirection) chọn một kiểu gradient từ lớp [GradientDirection](https://reference.aspose.com/slides/python-java/aspose.slides/gradientdirection/); nó không phải là một thay thế cho góc số. Đối với gradient tuyến tính, các kiểu góc có thể thay đổi khu vực màu được phân bố mà không thay đổi góc được chỉ định qua [setLinearGradientAngle](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setLinearGradientAngle). Giữ hướng không đổi khi so sánh góc hoặc tỷ lệ.

Ví dụ sau áp dụng cùng một cài đặt nhưng theo thứ tự ngược nhau. Hai hình chữ nhật cho cùng một kết quả: việc gán hướng trước hoặc sau góc không làm thay đổi kết quả.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientDirection, GradientShape, NullableBool, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    for i in range(2):
        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30 + i * 140, 320, 100)
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
        shape.getFillFormat().setFillType(FillType.Gradient)

        gradient = shape.getFillFormat().getGradientFormat()
        gradient.setGradientShape(GradientShape.Linear)
        gradient.getGradientStops().clear()
        gradient.getGradientStops().add(0, Color.RED)
        gradient.getGradientStops().add(0.5, Color.GREEN)
        gradient.getGradientStops().add(1, Color.BLUE)
        gradient.setLinearGradientScaled(NullableBool.True_)

        if i == 0:
            gradient.setGradientDirection(GradientDirection.FromCorner1)
            gradient.setLinearGradientAngle(30)
        else:
            gradient.setLinearGradientAngle(30)
            gradient.setGradientDirection(GradientDirection.FromCorner1)

    presentation.save("linear_gradient_direction.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Đổ Màu Hoa Văn**

Đổ màu hoa văn áp dụng một thiết kế hai màu, chẳng hạn chấm, sọc hoặc cờ caro. Ví dụ này sử dụng [PatternFormat.setPatternStyle](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#setPatternStyle) để chọn một mẫu lưới. [PatternFormat.getBackColor](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#getBackColor) cung cấp nền xám nhạt, và [PatternFormat.getForeColor](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#getForeColor) cung cấp màu vàng cho mẫu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PatternStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    shape.getFillFormat().setFillType(FillType.Pattern)
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis)
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY)
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW)

    presentation.save("pattern_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kết quả:

![Hình chữ nhật với đổ hoa văn](pattern-fill.png)

## **Đổ Hình Ảnh**

Đổ hình ảnh sử dụng một ảnh bên trong một hình. Ví dụ này yêu cầu một ảnh cục bộ và sử dụng [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile) để tải nó vào bộ sưu tập ảnh của bản trình bày. Đặt [PictureFillFormat.setPictureFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setPictureFillMode) ở chế độ lát gạch sẽ lặp lại ảnh trong hình chữ nhật. Ảnh nguồn được sử dụng ở đây được hiển thị dưới đây:

![Ảnh lotus](lotus.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130)
    shape.getFillFormat().setFillType(FillType.Picture)
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile)

    image = Images.fromFile("lotus.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture)

    presentation.save("picture_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kết quả:

![Hình với đổ hình ảnh](picture-fill.png)

### **Lát Ảnh Thành Kết Cấu**

Nếu bạn muốn đặt một ảnh lát gạch làm kết cấu và tùy chỉnh hành vi lát gạch, có thể sử dụng các phương pháp sau của lớp [PictureFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setPictureFillMode): Đặt chế độ đổ ảnh—`Tile` hoặc `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileAlignment): Xác định căn chỉnh của các ô gạch trong hình.
- [setTileFlip](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileFlip): Kiểm soát việc lật ô gạch theo chiều ngang, dọc hoặc cả hai.
- [setTileOffsetX](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileOffsetX): Đặt độ dịch chuyển ngang của ô gạch (điểm) so với gốc của hình.
- [setTileOffsetY](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileOffsetY): Đặt độ dịch chuyển dọc của ô gạch (điểm) so với gốc của hình.
- [setTileScaleX](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileScaleX): Xác định tỷ lệ ngang của ô gạch theo phần trăm.
- [setTileScaleY](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileScaleY): Xác định tỷ lệ dọc của ô gạch theo phần trăm.

Ví dụ này yêu cầu một ảnh cục bộ và cấu hình [PictureFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/) để lặp lại ảnh ở 50% kích thước gốc. Độ dịch chuyển `−32` điểm di chuyển các ô gạch theo chiều ngang và dọc; căn chỉnh góc dưới‑phải và lật cả hai hướng quyết định cách bố trí kết cấu lặp lại.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, RectangleAlignment, SaveFormat, ShapeType, TileFlip

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)

    shape = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95)
    shape.getFillFormat().setFillType(FillType.Picture)

    source_image = Images.fromFile("lotus.png")
    try:
        presentation_image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_fill_format = shape.getFillFormat().getPictureFillFormat()
    picture_fill_format.getPicture().setImage(presentation_image)
    picture_fill_format.setPictureFillMode(PictureFillMode.Tile)
    picture_fill_format.setTileOffsetX(-32)
    picture_fill_format.setTileOffsetY(-32)
    picture_fill_format.setTileScaleX(50)
    picture_fill_format.setTileScaleY(50)
    picture_fill_format.setTileAlignment(RectangleAlignment.BottomRight)
    picture_fill_format.setTileFlip(TileFlip.FlipBoth)

    presentation.save("tile.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kết quả:

![Các tùy chọn lát gạch](tile-options.png)

## **Đổ Màu Đơn**

Đổ màu đơn cung cấp cho hình một màu duy nhất, đồng nhất. Ví dụ này sử dụng [FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) để đặt chế độ đổ màu đơn và gán màu vàng qua [FillFormat.getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor), sau đó lưu hình chữ nhật vào bản trình bày.

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

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW)

    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kết quả:

![Hình với đổ màu đơn](solid-color-fill.png)

## **Sử Dụng Nền Slide làm Đổ Hình**

Sử dụng [AutoShape.setUseBackgroundFill](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/#setUseBackgroundFill) khi một hình cần khớp với nền slide, ví dụ trong một mẫu bản trình bày. Đặt [FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) thành [FillType.NotDefined](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) trước để xóa bất kỳ đổ nào đã được xác định. Với sự kết hợp này, hình sẽ sử dụng nền slide thay vì đổ theo kiểu của nó. Chỉ bật cờ này không xóa một đổ đã tồn tại.

Điều này khác với [FillType.NoFill](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/): đổ nền phủ các đối tượng phía sau hình bằng khu vực tương ứng của nền slide, trong khi không đổ để các đối tượng đó vẫn hiển thị. Gradient vẫn được căn chỉnh với slide thay vì khởi động lại bên trong mỗi hình.

Ví dụ sau tạo một nền mẫu được slide kế thừa và đặt một dải màu hồng máu phía sau ba hình chữ nhật. Hình chữ nhật bên trái sử dụng nền, hình ở giữa không có đổ, và hình bên phải chuyển từ đổ nền sang một đổ màu cam xác định.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, GradientShape, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    # Kế thừa gradient từ master.
    slide.getBackground().setType(BackgroundType.NotDefined)
    slide.getLayoutSlide().getBackground().setType(BackgroundType.NotDefined)
    background = slide.getLayoutSlide().getMasterSlide().getBackground()
    background.setType(BackgroundType.OwnBackground)
    background.getFillFormat().setFillType(FillType.Gradient)
    gradient = background.getFillFormat().getGradientFormat()
    gradient.setGradientShape(GradientShape.Linear)
    gradient.setLinearGradientAngle(0)
    gradient.getGradientStops().clear()
    color = Color(0, 0, 139)
    gradient.getGradientStops().add(0, color)
    color = Color(135, 206, 250)
    gradient.getGradientStops().add(1, color)

    # Thêm đối tượng này trước để nó xuất hiện phía sau các hình chữ nhật.
    band = slide.getShapes().addAutoShape(ShapeType.Rectangle, 25, 150, 670, 100)
    band.getFillFormat().setFillType(FillType.Solid)
    band.getFillFormat().getSolidFillColor().setColor(Color.MAGENTA)
    band.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    background_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 100, 160, 200)
    background_shape.getFillFormat().setFillType(FillType.NotDefined)
    background_shape.setUseBackgroundFill(True)

    no_fill_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 280, 100, 160, 200)
    no_fill_shape.getFillFormat().setFillType(FillType.NoFill)

    explicit_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 510, 100, 160, 200)
    explicit_shape.getFillFormat().setFillType(FillType.NotDefined)
    explicit_shape.setUseBackgroundFill(True)

    # Tắt đổ nền trước khi áp dụng một đổ xác định.
    explicit_shape.setUseBackgroundFill(False)
    explicit_shape.getFillFormat().setFillType(FillType.Solid)
    color = Color(255, 165, 0)
    explicit_shape.getFillFormat().getSolidFillColor().setColor(color)

    presentation.save("background_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kết quả, từ trái sang phải: **đổ nền**, **không đổ**, và **đổ xác định**. Dải màu hồng máu bị ẩn bởi các hình bên trái và phải nhưng vẫn hiển thị qua hình ở giữa.

![Đổ nền, không đổ và đổ màu cam xác định trên dải màu hồng máu](background-fill.png)

Hành vi tương tự áp dụng cho nền được định nghĩa trực tiếp trên slide hoặc kế thừa từ bố cục. Hình sử dụng nền đã được giải quyết của slide; ví dụ để lại cả nền slide và bố cục không xác định để mẫu cung cấp nó.

## **Đặt Độ Trong Suốt**

Đối với đổ màu đơn, thành phần alpha của màu kiểm soát độ mờ: 0 là hoàn toàn trong suốt và 255 là hoàn toàn không trong suốt. Ví dụ này sử dụng giá trị alpha 128 cho một hình chữ nhật màu vàng, làm nó gần 50 % trong suốt để hình chữ nhật phía dưới vẫn nhìn thấy được. Màu được gán qua [FillFormat.getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor).

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

    solid_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    transparent_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75)
    transparent_shape.getFillFormat().setFillType(FillType.Solid)
    color = Color(255, 255, 0, 128)
    transparent_shape.getFillFormat().getSolidFillColor().setColor(color)

    presentation.save("shape_transparency.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kết quả:

![Hình trong suốt](shape-transparency.png)

## **Xoay Hình**

Sử dụng [Shape.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setRotation) để xoay một hình trong mặt phẳng slide. Góc được đo bằng độ; ví dụ này xoay một hình chữ nhật 5 độ theo chiều kim đồng hồ và lưu bản trình bày.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    shape.setRotation(5)

    presentation.save("shape_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kết quả:

![Xoay hình](shape-rotation.png)

## **Thêm Hiệu Ứng Bo 3D**

Sử dụng [Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat) để cho hình có độ sâu và các cạnh bo. Ví dụ này tạo một hình bầu dục màu xanh lá với viền màu cam, sử dụng [ThreeDFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setDepth) để đặt độ sâu 4 điểm, và áp dụng một bo đỉnh tròn với độ rộng và chiều cao 6 điểm qua [ThreeDFormat.getBevelTop](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getBevelTop). Một camera trực giao nhìn phía trước và ánh sáng ba‑điểm làm cho bo trở nên rõ ràng.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, FillType, LightRigPresetType, LightingDirection, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    color = Color(0, 128, 0)
    shape.getFillFormat().getSolidFillColor().setColor(color)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    color = Color(255, 165, 0)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(color)
    shape.getLineFormat().setWidth(2.0)
    shape.getThreeDFormat().setDepth(4)
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle)
    shape.getThreeDFormat().getBevelTop().setHeight(6)
    shape.getThreeDFormat().getBevelTop().setWidth(6)
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)

    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kết quả:

![Hiệu ứng bo 3D](3D-bevel-effect.png)

## **Thêm Hiệu Ứng Xoay 3D**

Góc nhìn 3D của một hình được điều khiển bởi các cài đặt camera. Ví dụ này sử dụng [Camera.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#setRotation) với các góc vĩ độ, kinh độ và quay vòng là 40, 35 và 20 độ tương ứng. Nó chọn một camera isometric qua [Camera.setCameraType](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#setCameraType) và ánh sáng cân bằng qua [LightRig.setLightType](https://reference.aspose.com/slides/python-java/aspose.slides/lightrig/#setLightType), sau đó lưu hình chữ nhật đã định dạng.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, LightRigPresetType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    auto_shape.getTextFrame().setText("Hello, Aspose!")
    auto_shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp)
    auto_shape.getThreeDFormat().getCamera().setRotation(40, 35, 20)
    auto_shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)

    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kết quả:

![Hiệu ứng xoay 3D](3D-rotation-effect.png)

## **Kiểm Soát Hiển Thị Đen‑Trắng cho Hình**

Phương thức [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setBlackWhiteMode) chỉ định cách một hình riêng lẻ được hiển thị khi một bản trình bày được xem hoặc xử lý ở chế độ đen‑trắng. Nó không kích hoạt chế độ hiển thị đen‑trắng tự mình, và không thay đổi đổ, viền hoặc các định dạng khác của hình trong chế độ màu bình thường.

Sử dụng một giá trị từ lớp [BlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/blackwhitemode/) để chọn hành vi mong muốn. Ví dụ, `Automatic` để ứng dụng hiển thị tự chọn cách chuyển đổi, `Gray` và `LightGray` dùng màu xám, `BlackWhite` chỉ dùng đen và trắng, `Black` và `White` buộc một màu duy nhất, `Color` giữ nguyên màu bình thường, và `Hidden` loại bỏ hình trong chế độ đen‑trắng. `NotDefined` nghĩa là không có chế độ cấp độ hình nào được gán.

Ví dụ này tạo một hình chữ nhật màu cam và sử dụng [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setBlackWhiteMode) để đặt chế độ thành xám. Hình đã lưu giữ màu đổ cam cho hiển thị màu bình thường và yêu cầu màu xám từ các ứng dụng tôn trọng cài đặt hiển thị đen‑trắng.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BlackWhiteMode, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    color = Color(255, 165, 0)
    shape.getFillFormat().getSolidFillColor().setColor(color)
    shape.setBlackWhiteMode(BlackWhiteMode.Gray)

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Trong chế độ màu bình thường, hình chữ nhật giữ màu đổ cam. Trong quy trình làm việc hiển thị đen‑trắng, nó sử dụng màu xám vì chế độ được đặt thành `Gray`. Điều này cho phép bạn giữ một slide màu đầy đủ trong khi định nghĩa một ngoại hình riêng cho việc in, xem trước hoặc các quy trình khác tôn trọng cài đặt hiển thị đen‑trắng của bản trình bày.

## **Đặt Lại Định Dạng**

Sử dụng [Slide.reset](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#reset) để khôi phục vị trí, kích thước và định dạng của các placeholder slide từ các placeholder bố cục tương ứng. Ví dụ này yêu cầu một bản trình bày hiện có có các placeholder liên kết bố cục và đặt lại mọi slide trước khi lưu. Các hình không có placeholder bố cục tương ứng sẽ không được đặt lại.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    for slide in presentation.getSlides():
        slide.reset()

    presentation.save("reset_formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Câu Hỏi Thường Gặp**

**Định dạng hình có ảnh hưởng đến kích thước cuối cùng của file bản trình bày không?**

Màu sắc, kiểu đường và cài đặt hiệu ứng thường chỉ thêm ít dữ liệu so với các ảnh và phương tiện đã nhúng. Đổ hình ảnh có thể làm tăng kích thước file vì ảnh của chúng được lưu trong bản trình bày.

**Làm sao tôi có thể phát hiện các hình trên một slide có cùng định dạng để nhóm chúng lại?**

So sánh các thuộc tính định dạng chính của mỗi hình—đổ, đường và cài đặt hiệu ứng. Nếu tất cả các giá trị tương ứng khớp nhau, coi các kiểu của chúng là giống nhau và nhóm các hình đó lại một cách logic, giúp việc quản lý kiểu sau này đơn giản hơn.

**Tôi có thể lưu một tập hợp các kiểu hình tùy chỉnh vào một file riêng để tái sử dụng trong các bản trình bày khác không?**

Có. Lưu các hình mẫu với kiểu mong muốn vào một slide mẫu hoặc file mẫu .POTX. Khi tạo một bản trình bày mới, mở mẫu, sao chép các hình đã định dạng bạn cần, và áp dụng lại định dạng của chúng ở bất kỳ nơi nào cần.