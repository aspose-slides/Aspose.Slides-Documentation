---
title: Thêm Hình chữ nhật vào Bản trình bày trong Python qua Java
linktitle: Hình chữ nhật
type: docs
weight: 80
url: /vi/python-java/rectangle/
keywords:
- thêm hình chữ nhật
- tạo hình chữ nhật
- hình dạng hình chữ nhật
- hình chữ nhật đơn giản
- hình chữ nhật đã định dạng
- PowerPoint
- bản trình bày
- Python
- Aspose.Slides
description: "Nâng cao các bản trình bày PowerPoint của bạn bằng cách thêm hình chữ nhật với Aspose.Slides cho Python qua Java—dễ dàng thiết kế và sửa đổi các hình dạng một cách lập trình."
---
## **Tổng quan**

Bài viết này cho thấy cách thêm các hình chữ nhật vào các slide PowerPoint bằng cách sử dụng Aspose.Slides. Nó bao gồm việc tạo một hình chữ nhật đơn giản, tạo một hình chữ nhật đã định dạng, và lưu bản trình bày đã cập nhật dưới dạng tệp PPTX.

Bạn cũng sẽ thấy cách áp dụng định dạng cơ bản cho hình chữ nhật, như màu nền đặc, màu viền và độ dày viền. Ngoài ra, phần Hỏi đáp của bài viết chỉ đến các tác vụ liên quan đến hình chữ nhật, bao gồm góc bo tròn, nền ảnh, hiệu ứng hình ảnh, siêu liên kết, khóa hình, các tùy chọn xuất và các thuộc tính hiệu quả.

## **Thêm một Hình chữ nhật vào Slide**

Để thêm một hình chữ nhật đơn giản vào slide được chọn của bản trình bày, hãy làm theo các bước sau:

- Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/).
- Lấy tham chiếu đến một slide bằng chỉ mục của nó.
- Thêm một [AutoShape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/autoshape/) loại hình chữ nhật bằng cách sử dụng phương thức [addAutoShape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapecollection/#addAutoShape) được cung cấp bởi đối tượng [ShapeCollection](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapecollection/).
- Ghi bản trình bày đã sửa đổi dưới dạng tệp PPTX.

Trong ví dụ dưới đây, chúng tôi đã thêm một hình chữ nhật đơn giản vào slide đầu tiên của bản trình bày.

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

    # Thêm một hình dạng hình chữ nhật.
    slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50)

    # Ghi tệp PPTX ra ổ đĩa.
    presentation.save("RecShp1.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Thêm một Hình chữ nhật Định dạng vào Slide**

Để thêm một hình chữ nhật đã định dạng vào slide, hãy làm theo các bước dưới đây:

- Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/).
- Lấy tham chiếu đến một slide bằng chỉ mục của nó.
- Thêm một [AutoShape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/autoshape/) loại hình chữ nhật bằng cách sử dụng phương thức [addAutoShape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapecollection/#addAutoShape) được cung cấp bởi đối tượng [ShapeCollection](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapecollection/).
- Đặt [fill type](https://reference.aspose.com/slides/vi/python-java/aspose.slides/filltype/) của hình chữ nhật thành đặc.
- Đặt màu của hình chữ nhật bằng phương thức [setColor](https://reference.aspose.com/slides/vi/python-java/aspose.slides/colorformat/#setColor) trên màu nền đặc của đối tượng [FillFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fillformat/) gắn với đối tượng [Shape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/).
- Đặt màu viền của hình chữ nhật.
- Đặt độ rộng viền của hình chữ nhật.
- Ghi bản trình bày đã sửa đổi dưới dạng tệp PPTX.

Các bước trên được thực hiện trong ví dụ dưới đây.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpate.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Khởi tạo lớp Presentation đại diện cho tệp PPTX.
presentation = Presentation()
try:
    # Lấy slide đầu tiên.
    slide = presentation.getSlides().get_Item(0)

    # Thêm một hình dạng hình chữ nhật.
    rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50)

    # Định dạng nền của hình chữ nhật.
    rectangle.getFillFormat().setFillType(FillType.Solid)
    rectangle.getFillFormat().getSolidFillColor().setColor(Color.GRAY)

    # Định dạng viền của hình chữ nhật.
    rectangle.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    rectangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    rectangle.getLineFormat().setWidth(5)

    # Ghi tệp PPTX ra ổ đĩa.
    presentation.save("RecShp2.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Câu hỏi thường gặp**

**How do I add a rectangle with rounded corners?**

Sử dụng [shape type](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapetype/) có các góc bo tròn và điều chỉnh bán kính góc trong thuộc tính của hình; việc bo tròn cũng có thể được áp dụng cho từng góc thông qua điều chỉnh hình học.

**How do I fill a rectangle with an image (texture)?**

Chọn [fill type](https://reference.aspose.com/slides/vi/python-java/aspose.slides/filltype/) cho ảnh, cung cấp nguồn hình ảnh, và cấu hình [stretching/tiling modes](https://reference.aspose.com/slides/vi/python-java/aspose.slides/picturefillmode/).

**Can a rectangle have shadow and glow?**

Có. [Outer/inner shadow, glow, and soft edges](/slides/vi/python-java/shape-effect/) có sẵn với các tham số có thể điều chỉnh.

**Can I turn a rectangle into a button with a hyperlink?**

Có. [Assign a hyperlink](/slides/vi/python-java/manage-hyperlinks/) cho hành động click vào hình (nhảy đến slide, tệp, địa chỉ web hoặc email).

**How can I protect a rectangle from moving and changes?**

[Use shape locks](/slides/vi/python-java/applying-protection-to-presentation/): bạn có thể ngăn không cho di chuyển, thay đổi kích thước, chọn, hoặc chỉnh sửa văn bản để bảo vệ bố cục.

**Can I convert a rectangle to a raster image or SVG?**

Có. Bạn có thể [render the shape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#getImage) thành hình ảnh với kích thước/tỷ lệ xác định hoặc [export it as SVG](/slides/vi/python-java/create-shape-thumbnails/) để sử dụng dạng vector.

**How do I quickly get the actual (effective) properties of a rectangle considering theme and inheritance?**

[Use the shape’s effective properties](/slides/vi/python-java/shape-effective-properties/): API trả về các giá trị đã tính toán, bao gồm các kiểu chủ đề, bố cục và cài đặt cục bộ, giúp đơn giản hoá việc phân tích định dạng.