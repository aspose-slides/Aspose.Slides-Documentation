---
title: Định dạng các hình PowerPoint trong Python
linktitle: Định dạng Hình
type: docs
weight: 20
url: /vi/python-net/shape-formatting/
keywords:
- định dạng hình
- định dạng đường
- hiệu ứng phác thảo
- đường hình phác thảo
- định dạng kiểu nối
- đổ màu gradient
- đổ màu họa tiết
- đổ màu hình ảnh
- đổ màu kết cấu
- đổ màu đơn
- độ trong suốt hình dạng
- hiển thị hình đen‑trắng
- hiển thị hình xám
- xoay hình
- hiệu ứng bờ nổi 3D
- hiệu ứng xoay 3D
- đặt lại định dạng
- PowerPoint
- bản trình chiếu
- Python
- Aspose.Slides
description: "Tìm hiểu cách định dạng các hình PowerPoint trong Python bằng Aspose.Slides—đặt các kiểu đổ màu, đường viền và hiệu ứng cho tệp PPT, PPTX và ODP một cách chính xác và kiểm soát toàn diện."
---
## **Giới thiệu**

Định dạng các hình dạng trong PowerPoint bằng cách điều chỉnh viền, màu nền và hiệu ứng. Aspose.Slides cho Python thông qua .NET cho phép bạn kiểm soát các thiết lập này bằng mã, bao gồm độ trong suốt, xoay và định dạng 3D.

![Các tùy chọn định dạng hình dạng trong PowerPoint](format-shape-powerpoint.png)

Aspose.Slides cho Python thông qua .NET cung cấp các lớp và thuộc tính cho phép bạn định dạng hình dạng bằng các tùy chọn có sẵn trong PowerPoint.

## **Định dạng Đường viền**

Use [Shape.line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) để kiểm soát viền của một hình dạng. Ví dụ này tạo một hình chữ nhật không nền với viền xanh, dạng gạch đứt. [LineFormat.style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/style/) chọn một đường hợp chất dày‑mỏng, trong khi [LineFormat.width](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/width/) đặt độ rộng của nó là 7 điểm và [LineFormat.dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/) chọn mẫu gạch.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.style = slides.LineStyle.THICK_THIN
    shape.line_format.width = 7
    shape.line_format.dash_style = slides.LineDashStyle.DASH
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    presentation.save("formatted_lines.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![Các đường viền đã định dạng trong bản trình chiếu](formatted-lines.png)

### **Đặt Mẫu Gạch Đường Tùy Chỉnh**

Use [LineFormat.custom_dash_pattern](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/custom_dash_pattern/) khi các kiểu đường dựng sẵn không cung cấp độ dài gạch và khoảng trống bạn cần, ví dụ cho các viền thương hiệu hoặc sơ đồ kỹ thuật. Gán một mẫu tự động đặt [LineFormat.dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/) thành [LineDashStyle.CUSTOM](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/).

Các mục danh sách xen kẽ giữa độ dài gạch và khoảng trống, bắt đầu bằng một gạch. Mỗi giá trị là bội số của độ rộng đường: `[4, 2]` với độ rộng 3 điểm tạo ra một gạch 12 điểm tiếp theo là khoảng trống 6 điểm. Sử dụng các cặp giá trị hữu hạn, không âm để định nghĩa các đoạn gạch‑khoảng trống hoàn chỉnh. Ví dụ sử dụng các giá trị dương để mọi gạch và khoảng trống đều nhìn thấy.

Ví dụ này tạo năm đường xanh có độ dài bằng nhau và đầu phẳng. Ba đường đầu tiên so sánh các mẫu với độ rộng 3 điểm. Đường thứ tư lặp lại mẫu đầu tiên với độ rộng gấp đôi, nhân đôi cả độ dài gạch và khoảng trống. Đường thứ năm chuyển từ mẫu tùy chỉnh sang đường liền.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(600, 300, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    patterns = [
        [4, 2],
        [1, 2],
        [6, 2, 1, 2],
        [4, 2],
        [4, 2]
    ]

    for i, pattern in enumerate(patterns):
        line = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 50 + i * 50, 500, 0)
        line.line_format.width = 6 if i == 3 else 3
        line.line_format.fill_format.fill_type = slides.FillType.SOLID
        line.line_format.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_BLUE
        line.line_format.cap_style = slides.LineCapStyle.FLAT
        line.line_format.begin_arrowhead_style = slides.LineArrowheadStyle.NONE
        line.line_format.end_arrowhead_style = slides.LineArrowheadStyle.NONE
        line.line_format.custom_dash_pattern = pattern

    # Trả về đường cuối cùng thành kiểu liền.
    slide.shapes[4].line_format.dash_style = slides.LineDashStyle.SOLID

    presentation.save("custom_dash_patterns.pptx", slides.export.SaveFormat.PPTX)
```

Để quay lại kiểu gạch dựng sẵn, gán [LineDashStyle.DASH](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/) cho [LineFormat.dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/). Kiểu đã chọn điều khiển hiển thị của đường.

Kết quả trong PowerPoint, từ trên xuống dưới: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; và **Solid, 3 pt**.

![Ba mẫu gạch tùy chỉnh, một đường rộng hơn sử dụng mẫu đầu tiên, và một đường liền trong PowerPoint](custom-dash-patterns.png)

### **Đặt Đầu Đường**

Use [LineFormat.cap_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/cap_style/) để đặt các đầu của một đường mở. Phân loại [LineCapStyle](https://reference.aspose.com/slides/python-net/aspose.slides/linecapstyle/) cung cấp ba kiểu đầu rõ ràng:

- `FLAT`: Đường nét dừng lại tại điểm cuối.
- `ROUND`: Đầu vòng bán tròn mở rộng ra ngoài điểm cuối một nửa độ rộng của đường.
- `SQUARE`: Đầu vuông mở rộng ra ngoài điểm cuối một nửa độ rộng của đường.

Phân loại cũng bao gồm `NOT_DEFINED`, có nghĩa là không có kiểu đầu nào được chỉ định rõ ràng.

Đầu khác với mũi tên, vốn thêm ký hiệu vào đầu đường, và các nối, vốn điều khiển các góc giữa các đoạn đường. Ví dụ này vô hiệu hoá mũi tên thông qua [LineFormat.begin_arrowhead_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/begin_arrowhead_style/) và [LineFormat.end_arrowhead_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/end_arrowhead_style/) để chỉ so sánh các hình dạng đầu.

Ví dụ sau tạo ba đường ngang hầu hết giống nhau, rộng 20 điểm. Từ trên xuống dưới, chúng dùng đầu phẳng, tròn và vuông. Các điểm cuối có cùng tọa độ ngang; đầu tròn và vuông mở rộng 10 điểm ra ngoài mỗi đầu.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(500, 240, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    cap_styles = [slides.LineCapStyle.FLAT, slides.LineCapStyle.ROUND, slides.LineCapStyle.SQUARE]

    for i, cap_style in enumerate(cap_styles):
        line = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 100, 50 + i * 70, 300, 0)
        line.line_format.width = 20
        line.line_format.fill_format.fill_type = slides.FillType.SOLID
        line.line_format.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_BLUE
        line.line_format.dash_style = slides.LineDashStyle.SOLID
        line.line_format.cap_style = cap_style
        line.line_format.begin_arrowhead_style = slides.LineArrowheadStyle.NONE
        line.line_format.end_arrowhead_style = slides.LineArrowheadStyle.NONE

    presentation.save("line_caps.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả trong PowerPoint, từ trên xuống dưới: **Flat**, **Round**, và **Square**.

![Đầu phẳng, tròn và vuông trên các đường dày giống nhau trong PowerPoint](line-caps.png)

## **Áp dụng Hiệu Ứng Phác Thảo cho Đường Hình**

Hiệu ứng phác thảo làm cho đường của hình trông như được vẽ tay. Dùng [Shape.line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) để truy cập cài đặt đường, [LineFormat.sketch_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/sketch_format/) để truy cập cài đặt phác thảo, và [SketchFormat.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/sketchformat/sketch_type/) để chọn giá trị từ phân loại [LineSketchType](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/).

Mã Python sau cho thấy cách áp dụng hiệu ứng [LineSketchType.CURVED](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/), đọc giá trị đã gán rõ ràng, và loại bỏ hiệu ứng bằng [LineSketchType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/):

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    sketch_format = shape.line_format.sketch_format
    sketch_format.sketch_type = slides.LineSketchType.CURVED
    explicit_sketch_type = sketch_format.sketch_type
    print(f"Explicit sketch type: {explicit_sketch_type}")
    sketch_format.sketch_type = slides.LineSketchType.NONE
```

Giá trị trả về bởi [SketchFormat.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/sketchformat/sketch_type/) đại diện cho cài đặt được gán trực tiếp cho hình. Nếu định dạng đường có thể được kế thừa từ chủ đề, slide master hoặc slide layout, dùng [LineFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/get_effective/), truy cập [ILineFormatEffectiveData.sketch_format](https://reference.aspose.com/slides/python-net/aspose.slides/ilineformateffectivedata/sketch_format/), và đọc [ISketchFormatEffectiveData.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/isketchformateffectivedata/sketch_type/). Giá trị hiệu quả phản ánh định dạng thực tế được áp dụng sau khi kế thừa được giải quyết. Ví dụ này yêu cầu một bản trình chiếu hiện có với ít nhất một hình trên slide đầu và in ra cả hai giá trị:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    line_format = shape.line_format
    explicit_sketch_type = line_format.sketch_format.sketch_type
    effective_line_format = line_format.get_effective()
    effective_sketch_type = effective_line_format.sketch_format.sketch_type

    print(f"Explicit sketch type: {explicit_sketch_type}")
    print(f"Effective sketch type: {effective_sketch_type}")
```

## **Định dạng Kiểu Nối**

Đây là ba tùy chọn kiểu nối:

* Round
* Miter
* Bevel

Kiểu nối điều khiển cách hai đoạn viền gặp nhau ở góc. Sử dụng **Round** cho các góc tròn, **Miter** cho các góc nhọn, hoặc **Bevel** cho các góc phẳng.

![Kiểu nối trong bản trình chiếu](join-style-powerpoint.png)

Ví dụ này tạo ba hình chữ nhật đen với viền xanh rộng 15 điểm. Nó đặt [LineFormat.join_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/join_style/) thành các giá trị miter, bevel và round của [LineJoinStyle](https://reference.aspose.com/slides/python-net/aspose.slides/linejoinstyle/) tương ứng, để so sánh cách vẽ các góc.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    miter_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 75)
    bevel_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 20, 150, 75)
    round_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 135, 150, 75)

    miter_shape.fill_format.fill_type = slides.FillType.SOLID
    miter_shape.fill_format.solid_fill_color.color = draw.Color.black
    bevel_shape.fill_format.fill_type = slides.FillType.SOLID
    bevel_shape.fill_format.solid_fill_color.color = draw.Color.black
    round_shape.fill_format.fill_type = slides.FillType.SOLID
    round_shape.fill_format.solid_fill_color.color = draw.Color.black

    miter_shape.line_format.width = 15
    bevel_shape.line_format.width = 15
    round_shape.line_format.width = 15

    miter_shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    miter_shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue
    bevel_shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    bevel_shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue
    round_shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    round_shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    miter_shape.line_format.join_style = slides.LineJoinStyle.MITER
    bevel_shape.line_format.join_style = slides.LineJoinStyle.BEVEL
    round_shape.line_format.join_style = slides.LineJoinStyle.ROUND

    miter_shape.text_frame.text = "Miter Join Style"
    bevel_shape.text_frame.text = "Bevel Join Style"
    round_shape.text_frame.text = "Round Join Style"

    presentation.save("join_styles.pptx", slides.export.SaveFormat.PPTX)
```

### **Giới hạn Nối Miter ở Các Góc Nhọn**

Use [LineFormat.miter_limit](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/miter_limit/) với [LineFormat.join_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/join_style/) được đặt thành [LineJoinStyle.MITER](https://reference.aspose.com/slides/python-net/aspose.slides/linejoinstyle/) để giới hạn độ dài góc nhọn.

Giới hạn là tỉ lệ giữa khoảng cách giữa góc trong và góc ngoài của nối so với độ rộng đường. Ví dụ, giá trị `8` cho phép độ dài miter lên tới tám lần độ rộng đường; nó không phải là đo bằng điểm. Nếu góc vượt quá giới hạn, PowerPoint sẽ dùng nối bevel ở góc đó. Giới hạn lớn hơn cho phép các điểm nhọn hơn. Cài đặt chỉ ảnh hưởng đến nối miter và không gây ảnh hưởng khi góc vẫn nằm trong giới hạn.

Ví dụ này tạo hai tam giác không nền, viền rộng 20 điểm. Tam giác trái dùng giới hạn `2`, còn bên phải dùng `8`. Mỗi tam giác rộng 80 điểm và cao 160 điểm, cho tỉ lệ độ dài miter‑độ rộng đường khoảng `4.12`. Do đó PowerPoint bevel góc trái và giữ nguyên góc phải.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(500, 320, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    miter_limits = [2.0, 8.0]

    for i, miter_limit in enumerate(miter_limits):
        triangle = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 90 + i * 240, 110, 80, 160)
        triangle.fill_format.fill_type = slides.FillType.NO_FILL
        triangle.line_format.width = 20
        triangle.line_format.fill_format.fill_type = slides.FillType.SOLID
        triangle.line_format.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_BLUE
        triangle.line_format.join_style = slides.LineJoinStyle.MITER
        triangle.line_format.miter_limit = miter_limit

    presentation.save("miter_limits.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả trong PowerPoint: **Miter limit 2** ở phía trái và **miter limit 8** ở phía phải.

![Đỉnh bị cắt mặt phẳng với giới hạn miter 2 và đỉnh nhọn với giới hạn miter 8 trong PowerPoint](miter-limits.png)

## **Đổ màu Gradient**

Gradient blend màu qua một hình. Ví dụ này đổ màu gradient tuyến tính cho một hình ellipse với góc 45 độ từ đỏ sang tím bằng [FillFormat.gradient_format](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/gradient_format/). Phương thức [GradientStopCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides/gradientstopcollection/add/) đặt các điểm dừng màu ở 0 và 1, đầu và cuối gradient. Xóa các điểm dừng hiện có đảm bảo chỉ hai màu này được dùng.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)
    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR
    shape.fill_format.gradient_format.linear_gradient_angle = 45
    shape.fill_format.gradient_format.gradient_stops.clear()
    shape.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shape.fill_format.gradient_format.gradient_stops.add(0.0, slides.PresetColor.RED)

    presentation.save("gradient_fill.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![Hình elip với màu gradient](gradient-fill.png)

Nếu gradient trông khác trong ảnh xuất khẩu so với trong PowerPoint, xem [Choose a Gradient Rendering Style](/slides/vi/python-net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Bạn có thể chọn kiểu kết xuất mà không thay đổi gradient được lưu trong bản trình chiếu.

### **Đặt Góc Gradient Tuyến Tính**

Use [GradientFormat.linear_gradient_angle](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/linear_gradient_angle/) để điều khiển hướng của một màu [GradientShape.LINEAR](https://reference.aspose.com/slides/python-net/aspose.slides/gradientshape/) . Góc tính bằng độ và tăng theo chiều kim đồng hồ: `0` chạy từ trái sang phải, `90` từ trên xuống dưới, `180` từ phải sang trái, và `270` từ dưới lên trên. Hỗ trợ góc thập phân. Các góc ngoài khoảng `[0, 360)` được chuẩn hoá thành một vòng quay; ví dụ, `-45` trở thành `315` và `360` trở thành `0`.

Ví dụ này tạo sáu hình chữ nhật với các điểm dừng màu đỏ, xanh lá và xanh dương giống nhau ở các vị trí `0`, `0.5`, và `1`. Tỷ lệ bị tắt để góc có thể so sánh độc lập với tỉ lệ hình chữ nhật. Các góc, từ trái sang phải, là `0`, `45`, và `90` ở hàng đầu, và `135`, `180`, và `270` ở hàng thứ hai.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 400, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    angles = [0, 45, 90, 135, 180, 270]

    for i, angle in enumerate(angles):
        x = 30 + (i % 3) * 230
        y = 30 + (i // 3) * 190

        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 200, 150)
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
        shape.fill_format.fill_type = slides.FillType.GRADIENT

        gradient = shape.fill_format.gradient_format
        gradient.gradient_shape = slides.GradientShape.LINEAR
        gradient.gradient_stops.clear()
        gradient.gradient_stops.add(0.0, slides.PresetColor.RED)
        gradient.gradient_stops.add(0.5, slides.PresetColor.LIME)
        gradient.gradient_stops.add(1.0, slides.PresetColor.BLUE)
        gradient.linear_gradient_scaled = slides.NullableBool.FALSE
        gradient.linear_gradient_angle = angle

    presentation.save("linear_gradient_angles.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả trong PowerPoint:

![Gradient tuyến tính ở các góc 0, 45 và 90 độ ở hàng trên, và 135, 180 và 270 độ ở hàng dưới](linear-gradient-angles.png)

### **Tỷ lệ Gradient Tuyến Tính với Hình**

[GradientFormat.linear_gradient_scaled](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/linear_gradient_scaled/) nhận một giá trị [NullableBool](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/). Đặt thành `FALSE` để giữ góc gradient hình học khi tỷ lệ hình thay đổi, hoặc `TRUE` để tỷ lệ gradient cùng với chiều rộng và chiều cao của hình. Khi bật tỷ lệ, góc hiển thị có thể khác góc đã chỉ định trên hình không vuông.

Ví dụ sau dùng góc `45` độ và các điểm dừng màu giống như so sánh góc. Cột trái dùng `FALSE`; cột phải dùng `TRUE`. Mỗi cột chứa một hình chữ nhật rộng trên một hình chữ nhật cao. Cả hai bắt đầu với cùng kích thước rộng; việc thay đổi chiều rộng và chiều cao của hình chữ nhật thứ hai cho thấy cách màu nền phản hồi khi thay đổi kích thước mà không thay đổi cài đặt gradient.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 460, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    scaling_options = [slides.NullableBool.FALSE, slides.NullableBool.TRUE]

    for column, scaling in enumerate(scaling_options):
        for row in range(2):
            x = 30 + column * 360
            y = 30 if row == 0 else 150

            shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 300, 90)
            shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
            shape.fill_format.fill_type = slides.FillType.GRADIENT

            gradient = shape.fill_format.gradient_format
            gradient.gradient_shape = slides.GradientShape.LINEAR
            gradient.gradient_stops.clear()
            gradient.gradient_stops.add(0.0, slides.PresetColor.RED)
            gradient.gradient_stops.add(0.5, slides.PresetColor.LIME)
            gradient.gradient_stops.add(1.0, slides.PresetColor.BLUE)
            gradient.linear_gradient_angle = 45
            gradient.linear_gradient_scaled = scaling

            if row == 1:
                shape.width = 90
                shape.height = 280

    presentation.save("linear_gradient_scaling.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả trong PowerPoint, với tỷ lệ tắt ở bên trái và bật ở bên phải:

![Các hình chữ nhật rộng và cao với gradient góc 45 độ, so sánh linear_gradient_scaled FALSE ở bên trái với TRUE ở bên phải](linear-gradient-scaling.png)

Với tỷ lệ tắt, các dải màu chéo giữ cùng hướng trong cả hai hình. Với tỷ lệ bật, các dải kéo dài theo tỉ lệ hình. Điều này giúp tái tạo gradient của một mẫu khi điều chỉnh hình sang kích thước khác. Trên hình vuông, bật tỷ lệ không thay đổi giao diện của gradient `45` độ.

Cả góc và cài đặt tỷ lệ đều áp dụng cho gradient tuyến tính. Chúng không điều khiển các màu [GradientShape.RADIAL hoặc GradientShape.RECTANGLE](https://reference.aspose.com/slides/python-net/aspose.slides/gradientshape/).

### **Kết hợp Góc với Hướng Gradient**

[GradientFormat.gradient_direction](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/gradient_direction/) chọn kiểu gradient từ phân loại [GradientDirection](https://reference.aspose.com/slides/python-net/aspose.slides/gradientdirection/); nó không phải là thay thế cho góc số. Đối với gradient tuyến tính, các kiểu góc có thể thay đổi khu vực phân phối màu mà không thay đổi [linear_gradient_angle](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/linear_gradient_angle/). Giữ hướng không đổi khi so sánh góc hoặc tỷ lệ.

Ví dụ sau áp dụng cùng cài đặt nhưng theo thứ tự ngược nhau. Hai hình chữ nhật cho cùng kết quả: đặt hướng trước hoặc sau góc không thay đổi kết quả.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    for i in range(2):
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30 + i * 140, 320, 100)
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
        shape.fill_format.fill_type = slides.FillType.GRADIENT

        gradient = shape.fill_format.gradient_format
        gradient.gradient_shape = slides.GradientShape.LINEAR
        gradient.gradient_stops.clear()
        gradient.gradient_stops.add(0.0, slides.PresetColor.RED)
        gradient.gradient_stops.add(0.5, slides.PresetColor.LIME)
        gradient.gradient_stops.add(1.0, slides.PresetColor.BLUE)
        gradient.linear_gradient_scaled = slides.NullableBool.TRUE

        if i == 0:
            gradient.gradient_direction = slides.GradientDirection.FROM_CORNER1
            gradient.linear_gradient_angle = 30
        else:
            gradient.linear_gradient_angle = 30
            gradient.gradient_direction = slides.GradientDirection.FROM_CORNER1

    presentation.save("linear_gradient_direction.pptx", slides.export.SaveFormat.PPTX)
```

## **Đổ màu Họa Tiết**

Đổ màu họa tiết áp dụng thiết kế hai màu, chẳng hạn chấm, sọc hoặc ô. Ví dụ này dùng [PatternFormat.pattern_style](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/pattern_style/) để chọn mẫu trellis. [PatternFormat.back_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/back_color/) cung cấp nền xám nhạt, và [PatternFormat.fore_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/fore_color/) cung cấp màu vàng cho mẫu.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    shape.fill_format.fill_type = slides.FillType.PATTERN
    shape.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS
    shape.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shape.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    presentation.save("pattern_fill.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![Hình chữ nhật với họa tiết](pattern-fill.png)

## **Đổ màu Hình Ảnh**

Đổ màu hình ảnh sử dụng một ảnh bên trong hình. Ví dụ này yêu cầu một ảnh cục bộ và dùng [Images.from_file](https://reference.aspose.com/slides/python-net/aspose.slides/images/from_file/) để tải vào bộ sưu tập ảnh của bản trình chiếu. Đặt [PictureFillFormat.picture_fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/) thành chế độ lát sẽ lặp lại ảnh trong hình chữ nhật. Ảnh nguồn được dùng ở đây được hiển thị bên dưới:

![Hình ảnh hoa sen](lotus.png)

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 255, 130)
    shape.fill_format.fill_type = slides.FillType.PICTURE
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    with slides.Images.from_file("lotus.png") as image:
        presentation_image = presentation.images.add_image(image)
    shape.fill_format.picture_fill_format.picture.image = presentation_image

    presentation.save("picture_fill.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![Hình dạng với đổ màu hình ảnh](picture-fill.png)

### **Lát Hình ảnh Thành Kết Cấu**

Nếu bạn muốn đặt một ảnh lát làm kết cấu và tùy chỉnh hành vi lát, có thể sử dụng các thuộc tính sau của lớp [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) :

- [picture_fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/): Đặt chế độ đổ ảnh—hoặc `TILE` hoặc `STRETCH`.
- [tile_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_alignment/): Xác định căn chỉnh các ô trong hình.
- [tile_flip](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_flip/): Kiểm soát việc lật ô theo chiều ngang, chiều dọc hoặc cả hai.
- [tile_offset_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_x/): Đặt độ lệch ngang của ô (điểm) từ gốc hình.
- [tile_offset_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_y/): Đặt độ lệch dọc của ô (điểm) từ gốc hình.
- [tile_scale_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_x/): Xác định tỷ lệ ngang của ô dưới dạng phần trăm.
- [tile_scale_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_y/): Xác định tỷ lệ dọc của ô dưới dạng phần trăm.

Ví dụ này yêu cầu một ảnh cục bộ và cấu hình [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) để lặp lại nó ở 50% kích thước gốc. Độ lệch `−32` điểm dịch các ô ngang và dọc; căn chỉnh góc dưới‑phải và lật cả hai hướng quyết định cách kết cấu lặp lại được sắp xếp.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]

    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)
    shape.fill_format.fill_type = slides.FillType.PICTURE

    with slides.Images.from_file("lotus.png") as source_image:
        presentation_image = presentation.images.add_image(source_image)

    picture_fill_format = shape.fill_format.picture_fill_format
    picture_fill_format.picture.image = presentation_image
    picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE
    picture_fill_format.tile_offset_x = -32
    picture_fill_format.tile_offset_y = -32
    picture_fill_format.tile_scale_x = 50
    picture_fill_format.tile_scale_y = 50
    picture_fill_format.tile_alignment = slides.RectangleAlignment.BOTTOM_RIGHT
    picture_fill_format.tile_flip = slides.TileFlip.FLIP_BOTH

    presentation.save("tile.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![Các tùy chọn lát](tile-options.png)

## **Đổ màu Đơn**

Đổ màu đơn cung cấp cho hình một màu duy nhất, đồng nhất. Ví dụ này đặt [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) thành chế độ đổ màu đơn và gán màu vàng qua [FillFormat.solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/), sau đó lưu hình chữ nhật trong bản trình chiếu.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    presentation.save("solid_color_fill.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![Hình dạng với đổ màu đơn](solid-color-fill.png)

### **Sao chép Màu trong Khi Giữ Tham chiếu Chủ đề**

Use [ColorFormat.copy_from](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/copy_from/) để sao chép định nghĩa màu, bao gồm loại màu, tham chiếu chủ đề và các biến đổi. Điều này hữu ích khi chuyển màu đổ giữa các hình mà vẫn muốn chúng tiếp tục theo chủ đề của bản trình chiếu. Phương thức chỉ sao chép màu: không sao chép kiểu đổ, viền hoặc các định dạng hình khác. Đặt [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) của đích một cách rõ ràng.

Ví dụ này tạo ba hình chữ nhật, từ trái sang phải: nguồn, bản sao nhận thức chủ đề, và bản sao RGB cố định. Nguồn dùng [ColorFormat.scheme_color](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/scheme_color/) để tham chiếu màu nhấn đầu tiên và thêm một độ sáng qua [ColorOperationCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides/coloroperationcollection/add/). Bản sao RGB dùng màu đổ hiệu quả của nguồn nên ba hình ban đầu trông giống nhau. Gán [ColorFormat.color](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/color/) đặt giá trị RGB cố định và xóa mọi biến đổi màu hiện có.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(660, 220, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    presentation.master_theme.color_scheme.accent1.color = draw.Color.royal_blue

    source = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 40, 180, 140)
    theme_copy = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 240, 40, 180, 140)
    rgb_copy = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 450, 40, 180, 140)

    for shape in (source, theme_copy, rgb_copy):
        shape.fill_format.fill_type = slides.FillType.SOLID
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    source_color = source.fill_format.solid_fill_color
    source_color.scheme_color = slides.SchemeColor.ACCENT1
    source_color.color_transform.add(slides.ColorTransformOperation.TINT, 0.75)

    theme_copy.fill_format.solid_fill_color.copy_from(source_color)
    rgb_copy.fill_format.solid_fill_color.color = source.fill_format.get_effective().solid_fill_color

    with slide.get_image(1.0, 1.0) as before:
        before.save("color-copy-before.png", slides.ImageFormat.PNG)

    # Các tham chiếu chủ đề sẽ theo màu nhấn mới; giá trị RGB cố định thì không.
    presentation.master_theme.color_scheme.accent1.color = draw.Color.orange_red

    with slide.get_image(1.0, 1.0) as after:
        after.save("color-copy-after.png", slides.ImageFormat.PNG)
    presentation.save("copied_colors.pptx", slides.export.SaveFormat.PPTX)
```

Trước khi thay đổi chủ đề, ba màu nền đều khớp:

![Nguồn, đích copy_from và đích RGB cố định với màu nền xanh giống nhau](color-copy-before.png)

Sau khi thay đổi chủ đề, nguồn và bản sao nhận thức chủ đề sẽ theo màu nhấn mới và giữ độ sáng. Bản sao RGB cố định vẫn giữ màu xanh:

![Nguồn và đích copy_from với màu cam, trong khi đích RGB cố định vẫn màu xanh](color-copy-after.png)

Định nghĩa đã sao chép độc lập với nguồn. Thay đổi tham chiếu chủ đề, gán màu khác, hoặc thêm/bớt biến đổi của nguồn sau này sẽ không ảnh hưởng tới đích. Thay đổi chủ đề vẫn ảnh hưởng tới cả hai hình vì mỗi hình đều tham chiếu riêng vào cùng một màu chủ đề.

Lưu và mở lại PPTX giữ nguyên [ColorFormat.color_type](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/color_type/), tham chiếu chủ đề và bộ sưu tập [ColorFormat.color_transform](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/color_transform/) ; không làm phẳng định nghĩa thành RGB.

Khi sao chép giữa các ngữ cảnh chủ đề khác nhau, chẳng hạn các bản trình chiếu có bảng màu nhấn khác nhau, tham chiếu đã sao chép sẽ được giải quyết dựa trên chủ đề của đích. Vì vậy cùng một tham chiếu và biến đổi có thể tạo ra màu hiển thị khác nhau. Xem [Presentation Theme](/slides/vi/python-net/presentation-theme/) để biết thêm về cấu hình màu chủ đề.

## **Sử dụng Nền Slide làm Đổ màu cho Hình dạng**

Dùng [AutoShape.use_background_fill](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/use_background_fill/) khi một hình dạng cần khớp với nền slide, ví dụ trong mẫu bản trình chiếu. Đặt [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) thành [FillType.NOT_DEFINED](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) trước để loại bỏ bất kỳ đổ màu nào được chỉ định. Với sự kết hợp này, hình dạng sẽ sử dụng nền slide thay vì đổ màu theo kiểu. Bật cờ này một mình không loại bỏ đổ màu được chỉ định sẵn.

Điều này khác với [FillType.NO_FILL](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/): đổ nền bao phủ các đối tượng phía sau hình dạng bằng khu vực nền slide tương ứng, trong khi không đổ để các đối tượng đó vẫn hiển thị. Gradient vẫn căn chỉnh với slide thay vì khởi động lại bên trong mỗi hình.

Ví dụ sau tạo một nền master được kế thừa bởi slide và đặt một dải màu hồng phía sau ba hình chữ nhật. Hình chữ nhật trái dùng nền, hình giữa không có đổ, và hình bên phải chuyển từ đổ nền sang đổ màu cam rõ ràng.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 400, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    # Kế thừa gradient từ master.
    slide.background.type = slides.BackgroundType.NOT_DEFINED
    slide.layout_slide.background.type = slides.BackgroundType.NOT_DEFINED
    background = slide.layout_slide.master_slide.background
    background.type = slides.BackgroundType.OWN_BACKGROUND
    background.fill_format.fill_type = slides.FillType.GRADIENT
    gradient = background.fill_format.gradient_format
    gradient.gradient_shape = slides.GradientShape.LINEAR
    gradient.linear_gradient_angle = 0
    gradient.gradient_stops.clear()
    gradient.gradient_stops.add(0, draw.Color.dark_blue)
    gradient.gradient_stops.add(1, draw.Color.light_sky_blue)

    # Thêm đối tượng này đầu tiên để nó xuất hiện phía sau các hình chữ nhật.
    band = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 25, 150, 670, 100)
    band.fill_format.fill_type = slides.FillType.SOLID
    band.fill_format.solid_fill_color.color = draw.Color.magenta
    band.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    background_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 100, 160, 200)
    background_shape.fill_format.fill_type = slides.FillType.NOT_DEFINED
    background_shape.use_background_fill = True

    no_fill_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 280, 100, 160, 200)
    no_fill_shape.fill_format.fill_type = slides.FillType.NO_FILL

    explicit_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 510, 100, 160, 200)
    explicit_shape.fill_format.fill_type = slides.FillType.NOT_DEFINED
    explicit_shape.use_background_fill = True

    # Tắt nền slide trước khi áp dụng màu đổ cụ thể.
    explicit_shape.use_background_fill = False
    explicit_shape.fill_format.fill_type = slides.FillType.SOLID
    explicit_shape.fill_format.solid_fill_color.color = draw.Color.orange

    presentation.save("background_fill.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả, từ trái sang phải: **background fill**, **no fill**, và **explicit fill**. Dải màu hồng bị ẩn bởi hình trái và phải nhưng vẫn hiện ra qua hình giữa.

![Đổ nền, không đổ, và đổ màu cam rõ ràng trên dải màu hồng](background-fill.png)

Hành vi này cũng áp dụng cho nền được định nghĩa trực tiếp trên slide hoặc được kế thừa từ layout. Hình dạng sử dụng nền đã được giải quyết của slide; ví dụ này để cả nền slide và layout không xác định để master cung cấp.

## **Đặt Độ trong Suốt**

Đối với đổ màu đơn, thành phần alpha của màu kiểm soát độ mờ: 0 là hoàn toàn trong suốt và 255 là hoàn toàn không trong suốt. Ví dụ này dùng giá trị alpha 128 cho một hình chữ nhật màu vàng, làm cho nó gần 50% trong suốt để hình phía dưới vẫn nhìn thấy. Màu được gán qua [FillFormat.solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/).

```python
import aspose.slides as slides
import aspose.pydrawing as draw

alpha = 128

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    solid_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    transparent_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 150, 75)
    transparent_shape.fill_format.fill_type = slides.FillType.SOLID
    transparent_shape.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.yellow)

    presentation.save("shape_transparency.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![Hình dạng trong suốt](shape-transparency.png)

## **Xoay Hình dạng**

Dùng [Shape.rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) để xoay một hình trong mặt phẳng slide. Góc tính bằng độ; ví dụ này xoay một hình chữ nhật 5 độ theo chiều kim đồng hồ và lưu bản trình chiếu.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    shape.rotation = 5

    presentation.save("shape_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![Xoay hình dạng](shape-rotation.png)

## **Thêm Hiệu Ứng Bờ Nổi 3D**

Dùng [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/) để cho hình có độ sâu và các cạnh bờ nổi. Ví dụ này tạo một ellipse xanh lá với viền orange, đặt [ThreeDFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/depth/) thành 4 điểm, và áp dụng bờ trên tròn với độ rộng và chiều cao 6 điểm qua [ThreeDFormat.bevel_top](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_top/). Camera trực giao phía trước và ánh sáng ba‑điểm làm cho bờ nổi rõ ràng.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.green
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.orange
    shape.line_format.width = 2.0
    shape.three_d_format.depth = 4
    shape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    shape.three_d_format.bevel_top.height = 6
    shape.three_d_format.bevel_top.width = 6
    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.THREE_PT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP

    presentation.save("3D_bevel_effect.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![Hiệu ứng bờ nổi 3D](3D-bevel-effect.png)

## **Thêm Hiệu Ứng Xoay 3D**

Góc nhìn 3D của một hình được kiểm soát bởi cài đặt camera. Ví dụ này dùng [Camera.set_rotation](https://reference.aspose.com/slides/python-net/aspose.slides/camera/set_rotation/) với góc vĩ độ, kinh độ và vòng quay lần lượt là 40, 35 và 20 độ. Nó chọn một camera isometric qua [Camera.camera_type](https://reference.aspose.com/slides/python-net/aspose.slides/camera/camera_type/) và ánh sáng cân bằng qua [LightRig.light_type](https://reference.aspose.com/slides/python-net/aspose.slides/lightrig/light_type/), sau đó lưu hình chữ nhật đã định dạng.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    auto_shape.text_frame.text = "Hello, Aspose!"
    auto_shape.three_d_format.camera.camera_type = slides.CameraPresetType.ISOMETRIC_LEFT_UP
    auto_shape.three_d_format.camera.set_rotation(40, 35, 20)
    auto_shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED

    presentation.save("3D_rotation_effect.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![Hiệu ứng xoay 3D](3D-rotation-effect.png)

## **Kiểm soát Định dạng Đen‑Trắng cho Hình dạng**

Thuộc tính [Shape.black_white_mode](https://reference.aspose.com/slides/python-net/aspose.slides/shape/black_white_mode/) chỉ định cách một hình riêng lẻ được render khi bản trình chiếu được xem hoặc xử lý ở chế độ đen‑trắng. Nó không tự động bật chế độ hiển thị đen‑trắng và không thay đổi màu nền, đường viền hoặc các định dạng khác trong chế độ màu bình thường.

Dùng một giá trị từ phân loại [BlackWhiteMode](https://reference.aspose.com/slides/python-net/aspose.slides/blackwhitemode/) để chọn hành vi mong muốn. Ví dụ, `AUTOMATIC` để ứng dụng render chọn cách chuyển đổi, `GRAY` và `LIGHT_GRAY` dùng màu xám, `BLACK_WHITE` chỉ dùng màu đen và trắng, `BLACK` và `WHITE` buộc một màu duy nhất, `COLOR` giữ màu bình thường, và `HIDDEN` bỏ qua hình trong chế độ đen‑trắng. `NOT_DEFINED` nghĩa là không có chế độ cấp riêng cho hình.

Ví dụ này tạo một hình chữ nhật orange và đặt [Shape.black_white_mode](https://reference.aspose.com/slides/python-net/aspose.slides/shape/black_white_mode/) thành `GRAY`. Hình đã lưu vẫn giữ màu orange ở chế độ màu bình thường và yêu cầu màu xám từ các ứng dụng tôn trọng thiết lập hiển thị đen‑trắng.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.orange
    shape.black_white_mode = slides.BlackWhiteMode.GRAY

    presentation.save("shape_black_white_mode.pptx", slides.export.SaveFormat.PPTX)
```

Trong chế độ màu bình thường, hình chữ nhật giữ màu orange. Trong quy trình hiển thị đen‑trắng, nó dùng màu xám vì chế độ được đặt thành `GRAY`. Điều này cho phép bạn giữ slide đầy màu trong khi định nghĩa một giao diện riêng cho in ấn, xem trước hoặc các quy trình khác tôn trọng thiết lập hiển thị đen‑trắng của bản trình chiếu.

## **Đặt lại Định dạng**

Dùng [Slide.reset](https://reference.aspose.com/slides/python-net/aspose.slides/slide/reset/) để khôi phục vị trí, kích thước và định dạng của các placeholder slide từ các placeholder layout tương ứng. Ví dụ này yêu cầu một bản trình chiếu hiện có với các placeholder liên kết layout và đặt lại mọi slide trước khi lưu. Các hình không có placeholder layout tương ứng sẽ không được đặt lại.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    for slide in presentation.slides:
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **Câu hỏi thường gặp**

**Định dạng hình dạng có ảnh hưởng đến kích thước cuối cùng của tệp bản trình chiếu không?**

Màu, kiểu đường và cài đặt hiệu ứng thường chỉ thêm một lượng dữ liệu nhỏ so với ảnh và phương tiện nhúng. Đổ màu hình ảnh có thể làm tăng kích thước tệp vì ảnh của chúng được lưu trong bản trình chiếu.

**Làm sao tôi có thể phát hiện các hình dạng trên một slide có cùng định dạng để tôi có thể nhóm chúng?**

So sánh các thuộc tính định dạng chính của mỗi hình — màu nền, đường viền và cài đặt hiệu ứng. Nếu tất cả các giá trị tương ứng trùng khớp, coi chúng là cùng một kiểu và nhóm logic các hình đó, giúp quản lý kiểu sau này dễ dàng hơn.

**Tôi có thể lưu một bộ các kiểu hình dạng tùy chỉnh vào một tệp riêng để tái sử dụng trong các bản trình chiếu khác không?**

Có. Lưu các hình mẫu với kiểu mong muốn trong một slide mẫu hoặc tệp .POTX. Khi tạo bản trình chiếu mới, mở mẫu, sao chép các hình đã định dạng bạn cần và áp dụng lại định dạng của chúng ở nơi cần.