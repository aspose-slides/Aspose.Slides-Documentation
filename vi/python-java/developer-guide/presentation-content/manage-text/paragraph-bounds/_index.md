---
title: Lấy Giới Hạn Đoạn Văn từ Bài Trình Bày trong Python thông qua Java
linktitle: Giới Hạn Đoạn Văn
type: docs
weight: 43
url: /vi/python-java/paragraph-bounds/
keywords:
- giới hạn đoạn văn
- tọa độ đoạn văn
- kích thước đoạn văn
- khung văn bản
- PowerPoint
- bài trình bày
- Python
- Java
- Aspose.Slides
description: "Tìm hiểu cách lấy giới hạn đoạn văn trong Aspose.Slides cho Python thông qua Java để tối ưu hoá vị trí văn bản trong các bài trình bày PowerPoint."
---
## **Tổng quan**

Bài viết này giải thích cách lấy giới hạn, kích thước và tọa độ của các đoạn văn trong Aspose.Slides. Nó cho thấy cách truy xuất hình chữ nhật của một đoạn văn từ [TextFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframe/) bằng cách sử dụng [Paragraph.getRect](https://reference.aspose.com/slides/vi/python-java/aspose.slides/paragraph/#getRect), cách lấy tọa độ đoạn văn bên trong khung văn bản của ô bảng, và làm nổi bật các chi tiết quan trọng như đơn vị đo, ảnh hưởng của việc gói văn bản lên giới hạn, chuyển đổi pixel, và các giá trị định dạng đoạn văn hiệu quả.

## **Lấy Tọa Độ Hình Chữ Nhật của Đoạn Văn**

Sử dụng [Paragraph.getRect](https://reference.aspose.com/slides/vi/python-java/aspose.slides/paragraph/#getRect) để lấy hình chữ nhật bao quanh của một đoạn văn.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Shapes.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)
    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    rectangle = paragraph.getRect()
finally:
    presentation.dispose()
```

## **Lấy Kích Thước của Đoạn Văn Bên trong Khung Văn Bản của Ô Bảng**

Để lấy kích thước và tọa độ của một [Paragraph](https://reference.aspose.com/slides/vi/python-java/aspose.slides/paragraph/) trong khung văn bản của ô bảng, hãy sử dụng [Paragraph.getRect](https://reference.aspose.com/slides/vi/python-java/aspose.slides/paragraph/#getRect). Hình chữ nhật được trả về tính tương đối so với khung văn bản của ô bảng, vì vậy hãy cộng vị trí bảng và độ dịch của ô khi bạn cần tọa độ ở mức slide.

Ví dụ sau lấy giới hạn của đoạn văn bên trong ô bảng và vẽ các hình chữ nhật trên slide để minh họa các giới hạn đó:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation("source.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)
    cell = table.getRows().get_Item(1).get_Item(1)

    cell_x = table.getX() + cell.getOffsetX()
    cell_y = table.getY() + cell.getOffsetY()

    for paragraph in cell.getTextFrame().getParagraphs():
        if not paragraph.getText():
            continue

        paragraph_rectangle = paragraph.getRect()
        paragraph_rectangle_x = paragraph_rectangle.x + cell_x
        paragraph_rectangle_y = paragraph_rectangle.y + cell_y

        paragraph_bounds_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, paragraph_rectangle_x, paragraph_rectangle_y, paragraph_rectangle.width, paragraph_rectangle.height)

        paragraph_bounds_shape.getFillFormat().setFillType(FillType.NoFill)
        paragraph_bounds_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW)
        paragraph_bounds_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Các tọa độ đoạn văn được đo bằng đơn vị nào?**

Chúng được đo bằng điểm (point), trong đó 1 inch bằng 72 điểm. Điều này áp dụng cho tất cả các tọa độ và kích thước trên slide.

**Việc ngắt từ có ảnh hưởng đến giới hạn của đoạn văn không?**

Có. Nếu [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframeformat/#setWrapText) được bật cho [TextFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframe/), văn bản sẽ ngắt để phù hợp với độ rộng khu vực, điều này sẽ làm thay đổi giới hạn thực tế của đoạn văn.

**Có thể ánh xạ đáng tin cậy các tọa độ đoạn văn sang pixel trong hình ảnh xuất khẩu không?**

Có. Chuyển đổi điểm sang pixel bằng công thức: pixel = điểm × (DPI / 72). Kết quả phụ thuộc vào DPI được chọn cho quá trình render hoặc xuất khẩu.

**Làm sao để lấy các tham số định dạng đoạn văn "hiệu quả", tính đến việc kế thừa kiểu dáng?**

Sử dụng [effective paragraph formatting data structure](/slides/vi/python-java/shape-effective-properties/); nó trả về các giá trị cuối cùng đã được hợp nhất cho thụt lề, khoảng cách, gói văn bản, RTL và các thiết lập khác.