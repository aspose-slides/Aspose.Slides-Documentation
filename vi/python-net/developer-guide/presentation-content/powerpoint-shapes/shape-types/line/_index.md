---
title: Tạo hình dạng đường trong bản trình chiếu với Python
linktitle: Đường
type: docs
weight: 50
url: /vi/python-net/line/
keywords:
- đường
- tạo đường
- thêm đường
- đường thẳng đơn giản
- cấu hình đường
- tùy chỉnh đường
- kiểu gạch
- đầu mũi tên
- PowerPoint
- OpenDocument
- bản trình chiếu
- Python
- Aspose.Slides
description: "Tìm hiểu cách thao tác định dạng đường trong các bản trình chiếu PowerPoint và OpenDocument với Aspose.Slides cho Python qua .NET. Khám phá các thuộc tính, phương thức và ví dụ."
---
## **Tổng quan**

Aspose.Slides for Python qua .NET hỗ trợ thêm các loại hình dạng khác nhau vào các slide. Trong chủ đề này, chúng ta sẽ bắt đầu làm việc với các hình dạng bằng cách thêm các đường vào các slide. Sử dụng Aspose.Slides, các nhà phát triển không chỉ có thể tạo các đường đơn giản, mà còn có thể vẽ một số đường phức tạp trên các slide.

## **Tạo Đường Thẳng Đơn Giản**

Sử dụng Aspose.Slides để thêm một đường thẳng đơn giản vào slide như một dấu phân cách hoặc kết nối. Để thêm một đường thẳng đơn giản vào slide được chọn trong bản trình chiếu, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) .
1. Lấy tham chiếu đến slide theo chỉ mục.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/) có loại `LINE` bằng cách sử dụng phương thức `add_auto_shape` trên đối tượng [ShapeCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shapecollection/) .
1. Lưu bản trình chiếu dưới dạng tệp PPTX.

Trong ví dụ bên dưới, một đường đã được thêm vào slide đầu tiên của bản trình chiếu.

```py
import aspose.slides as slides

# Tạo một thể hiện của lớp Presentation.
with slides.Presentation() as presentation:

    # Lấy slide đầu tiên.
    slide = presentation.slides[0]

    # Thêm một auto shape loại LINE.
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # Lưu bản trình chiếu dưới dạng tệp PPTX.
    presentation.save("line_shape.pptx", slides.export.SaveFormat.PPTX)
```

## **Tạo Đường Dạng Mũi Tên**

Aspose.Slides cho phép bạn cấu hình các thuộc tính của đường để chúng trở nên hấp dẫn hơn về mặt hình ảnh. Dưới đây, chúng tôi cấu hình một vài thuộc tính của đường để làm cho nó trông giống như một mũi tên. Thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) .
1. Lấy tham chiếu đến slide theo chỉ mục.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/) có loại `LINE` bằng cách sử dụng phương thức `add_auto_shape` trên đối tượng [ShapeCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shapecollection/) .
1. Đặt [line style](https://reference.aspose.com/slides/vi/python-net/aspose.slides/linestyle/) .
1. Đặt độ rộng của đường.
1. Đặt [dash style](https://reference.aspose.com/slides/vi/python-net/aspose.slides/linedashstyle/) cho đường.
1. Đặt [arrowhead style](https://reference.aspose.com/slides/vi/python-net/aspose.slides/linearrowheadstyle/) và độ dài cho điểm bắt đầu của đường.
1. Đặt [arrowhead style](https://reference.aspose.com/slides/vi/python-net/aspose.slides/linearrowheadstyle/) và độ dài cho điểm kết thúc của đường.
1. Lưu bản trình chiếu dưới dạng tệp PPTX.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Tạo một thể hiện của lớp Presentation đại diện cho tệp PPTX.
with slides.Presentation() as presentation:
    # Lấy slide đầu tiên.
    slide = presentation.slides[0]

    # Thêm một auto shape loại LINE.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # Áp dụng định dạng cho đường.
    shape.line_format.style = slides.LineStyle.THICK_BETWEEN_THIN
    shape.line_format.width = 10

    shape.line_format.dash_style = slides.LineDashStyle.DASH_DOT

    shape.line_format.begin_arrowhead_length = slides.LineArrowheadLength.SHORT
    shape.line_format.begin_arrowhead_style = slides.LineArrowheadStyle.OVAL

    shape.line_format.end_arrowhead_length = slides.LineArrowheadLength.LONG
    shape.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE

    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.maroon

    # Lưu bản trình chiếu dưới dạng tệp PPTX.
    presentation.save("line_shape_2.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Tôi có thể chuyển một đường thường thành kết nối để nó "bám" vào các hình dạng không?**

Không. Một đường thường (một [AutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/) có loại [LINE](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shapetype/)) không tự động trở thành một connector. Để làm cho nó bám vào các hình dạng, hãy sử dụng loại [Connector](https://reference.aspose.com/slides/vi/python-net/aspose.slides/connector/) chuyên dụng và các [corresponding APIs](/slides/vi/python-net/connector/) cho việc kết nối.

**Tôi nên làm gì nếu các thuộc tính của đường được kế thừa từ chủ đề và khó xác định giá trị cuối cùng?**

[Đọc các thuộc tính hiệu quả](/slides/vi/python-net/shape-effective-properties/) thông qua các lớp [ILineFormatEffectiveData](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ilinefillformateffectivedata/) — chúng đã tính đến việc kế thừa và kiểu chủ đề.

**Tôi có thể khóa một đường để ngăn chỉnh sửa (di chuyển, thay đổi kích thước) không?**

Có. Các hình dạng cung cấp [lock objects](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/auto_shape_lock/) cho phép bạn [disallow editing operations](/slides/vi/python-net/applying-protection-to-presentation/).