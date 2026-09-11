---
title: Thêm Hình Dạng Đường vào Bản Trình Bày trong Python qua Java
linktitle: Đường
type: docs
weight: 50
url: /vi/python-java/line/
keywords:
- đường
- tạo đường
- thêm đường
- đường đơn
- cấu hình đường
- tùy chỉnh đường
- kiểu gạch
- đầu mũi tên
- PowerPoint
- bản trình bày
- Python
- Aspose.Slides
description: "Tìm hiểu cách thao tác định dạng đường trong bản trình bày PowerPoint bằng Aspose.Slides cho Python qua Java. Khám phá các thuộc tính, phương thức và ví dụ."
---
## **Tổng quan**

Aspose.Slides cho phép bạn thêm các hình dạng đường vào các slide PowerPoint bằng cách lập trình. Bài viết này chỉ ra cách tạo một đường đơn giản và cách tùy chỉnh một đường sao cho nó hiển thị dưới dạng mũi tên.

Bạn sẽ học cách thêm một hình dạng đường vào slide, điều chỉnh giao diện trực quan của nó và lưu bản trình bày đã cập nhật. Các ví dụ tập trung vào các thiết lập định dạng đường thực tế như kiểu dáng, độ rộng, mẫu gạch, tùy chọn đầu mũi tên và màu nền.

## **Tạo một Đường Đơn Giản**

Để thêm một đường đơn giản vào slide đã chọn của bản trình bày, hãy thực hiện các bước sau:

- Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) .
- Lấy tham chiếu tới một slide theo chỉ mục của nó.
- Thêm một hình dạng đường bằng cách sử dụng phương thức [addAutoShape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapecollection/#addAutoShape) của đối tượng [ShapeCollection](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapecollection/) .
- Ghi bản trình bày đã chỉnh sửa thành tệp PPTX.

Ví dụ sau thêm một đường vào slide đầu tiên của bản trình bày:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Khởi tạo lớp Presentation đại diện cho tệp PPTX.
presentation = Presentation()
try:
    # Lấy slide đầu tiên.
    slide = presentation.getSlides().get_Item(0)

    # Thêm hình dạng đường.
    slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0)

    # Ghi tệp PPTX vào đĩa.
    presentation.save("LineShape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Tạo một Đường Hình Mũi Tên**

Aspose.Slides for Python via Java cũng cho phép các nhà phát triển cấu hình các thuộc tính của đường để làm cho đường trông hấp dẫn hơn. Để cấu hình một đường sao cho nó giống như một mũi tên, hãy thực hiện các bước sau:

- Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) .
- Lấy tham chiếu tới một slide theo chỉ mục của nó.
- Thêm một hình dạng đường bằng cách sử dụng phương thức [addAutoShape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapecollection/#addAutoShape) của đối tượng [ShapeCollection](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapecollection/) .
- Đặt [line style](https://reference.aspose.com/slides/vi/python-java/aspose.slides/linestyle/) thành một trong các phong cách do Aspose.Slides for Python via Java cung cấp.
- Đặt độ rộng của đường.
- Đặt [dash style](https://reference.aspose.com/slides/vi/python-java/aspose.slides/linedashstyle/) thành một trong các phong cách do Aspose.Slides for Python via Java cung cấp.
- Đặt [arrowhead style](https://reference.aspose.com/slides/vi/python-java/aspose.slides/linearrowheadstyle/) và [length](https://reference.aspose.com/slides/vi/python-java/aspose.slides/linearrowheadlength/) ở đầu đường.
- Đặt [arrowhead style](https://reference.aspose.com/slides/vi/python-java/aspose.slides/linearrowheadstyle/) và [length](https://reference.aspose.com/slides/vi/python-java/aspose.slides/linearrowheadlength/) ở cuối đường.
- Ghi bản trình bày đã chỉnh sửa thành tệp PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineArrowheadLength, LineArrowheadStyle, LineDashStyle, LineStyle, Presentation, PresetColor, SaveFormat, ShapeType

# Khởi tạo lớp Presentation đại diện cho tệp PPTX.
presentation = Presentation()
try:
    # Lấy slide đầu tiên.
    slide = presentation.getSlides().get_Item(0)

    # Thêm hình dạng đường.
    line = slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0)

    # Áp dụng định dạng cho đường.
    line_format = line.getLineFormat()
    line_format.setStyle(LineStyle.ThickBetweenThin)
    line_format.setWidth(10)

    line_format.setDashStyle(LineDashStyle.DashDot)

    line_format.setBeginArrowheadLength(LineArrowheadLength.Short)
    line_format.setBeginArrowheadStyle(LineArrowheadStyle.Oval)

    line_format.setEndArrowheadLength(LineArrowheadLength.Long)
    line_format.setEndArrowheadStyle(LineArrowheadStyle.Triangle)

    line_format.getFillFormat().setFillType(FillType.Solid)
    line_format.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.Maroon)

    # Ghi tệp PPTX vào đĩa.
    presentation.save("LineShape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Câu hỏi thường gặp**

**Tôi có thể chuyển một đường thường thành kết nối để nó “bắt” vào các hình dạng không?**

Không. Một đường thường (một [AutoShape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/autoshape/) có loại là [Line](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapetype/)) sẽ không tự động trở thành một connector. Để làm cho nó bắt vào các hình dạng, hãy sử dụng loại [Connector](https://reference.aspose.com/slides/vi/python-java/aspose.slides/connector/) chuyên dụng và các [corresponding APIs](/slides/vi/python-java/connector/) để kết nối.

**Tôi nên làm gì nếu các thuộc tính của đường được kế thừa từ chủ đề và khó xác định giá trị cuối cùng?**

[Read the effective properties](/slides/vi/python-java/shape-effective-properties/) của đường và phần fill của nó — những thuộc tính này đã tính đến việc kế thừa và các kiểu chủ đề.

**Tôi có thể khóa một đường để ngăn chỉnh sửa (di chuyển, thay đổi kích thước) không?**

Có. Các hình dạng cung cấp [lock objects](https://reference.aspose.com/slides/vi/python-java/aspose.slides/autoshape/#getAutoShapeLock) cho phép bạn [disallow editing operations](/slides/vi/python-java/applying-protection-to-presentation/).