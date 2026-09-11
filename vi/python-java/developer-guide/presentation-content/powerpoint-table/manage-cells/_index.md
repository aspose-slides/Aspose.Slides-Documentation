---
title: Quản lý các ô bảng trong bản trình bày bằng Python
linktitle: Quản lý ô
type: docs
weight: 30
url: /vi/python-java/manage-cells/
keywords:
- ô bảng
- hợp nhất ô
- xóa đường viền
- tách ô
- hình ảnh trong ô
- màu nền
- PowerPoint
- bản trình bày
- Python
- Aspose.Slides
description: "Quản lý các ô bảng trong PowerPoint một cách dễ dàng với Aspose.Slides cho Python thông qua Java. Nắm vững cách truy cập, chỉnh sửa và tạo kiểu cho các ô nhanh chóng để tự động hoá slide một cách liền mạch."
---
## **Tổng quan**

Aspose.Slides cho phép bạn truy cập và chỉnh sửa các ô bảng trong bản trình bày PowerPoint. Bài viết này giải thích cách xác định các ô bảng đã hợp nhất, xóa đường viền của ô, làm việc với việc đánh số ô sau khi hợp nhất hoặc tách ô, thay đổi màu nền của ô và chèn hình ảnh vào bên trong một ô bảng. Các ví dụ cho thấy cách tạo hoặc mở một bản trình bày, lấy bảng từ một slide, cập nhật định dạng ô thông qua các thuộc tính của ô, và lưu bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

## **Xác định ô bảng đã hợp nhất**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) .
2. Lấy bảng từ slide đầu tiên.
3. Duyệt qua các hàng và cột của bảng để tìm các ô đã hợp nhất.
4. In ra thông báo khi phát hiện các ô đã hợp nhất.

Mã Python này cho bạn thấy cách xác định các ô bảng đã hợp nhất trong một bản trình bày:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Table

presentation = Presentation("SomePresentationWithTable.pptx")
try:
    # Giả sử rằng hình dạng đầu tiên trên slide đầu tiên là một bảng.
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
        for i in range(table.getRows().size()):
            for j in range(table.getColumns().size()):
                current_cell = table.getRows().get_Item(i).get_Item(j)
                if current_cell.isMergedCell():
                    print(f"Cell {i};{j} is part of a merged cell with RowSpan={current_cell.getRowSpan()} and ColSpan={current_cell.getColSpan()} starting from Cell {current_cell.getFirstRowIndex()};{current_cell.getFirstColumnIndex()}.")
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **Xóa đường viền ô bảng**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) .
2. Lấy tham chiếu đến một slide theo chỉ mục của nó.
3. Định nghĩa một danh sách độ rộng cột.
4. Định nghĩa một danh sách chiều cao hàng.
5. Thêm một bảng vào slide thông qua phương thức [addTable](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapecollection/#addTable) .
6. Duyệt qua từng ô để xóa các đường viền trên, dưới, phải và trái.
7. Lưu bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

Mã Python này cho bạn thấy cách xóa đường viền khỏi các ô bảng:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat

presentation = Presentation()
try:
    # Truy cập slide đầu tiên.
    slide = presentation.getSlides().get_Item(0)

    # Định nghĩa độ rộng cột và chiều cao hàng.
    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Thêm một bảng vào slide.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Đặt định dạng đường viền cho mỗi ô.
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill)

    # Lưu bản trình bày dưới dạng tệp PPTX.
    presentation.save("table_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Đánh số trong các ô đã hợp nhất**

Nếu chúng ta hợp nhất hai cặp ô, (1, 1) và (2, 1), và (1, 2) và (2, 2), bảng kết quả vẫn giữ nguyên số thứ tự của các ô. Mã Python này minh họa quy trình:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Truy cập slide đầu tiên.
    slide = presentation.getSlides().get_Item(0)

    # Định nghĩa độ rộng cột và chiều cao hàng.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Thêm một bảng vào slide.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Đặt định dạng đường viền cho mỗi ô.
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderTop().setWidth(5)

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderBottom().setWidth(5)

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderLeft().setWidth(5)

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderRight().setWidth(5)


    # Hợp nhất các ô (1, 1) và (2, 1).
    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 1), False)

    # Hợp nhất các ô (1, 2) và (2, 2).
    table.mergeCells(table.get_Item(1, 2), table.get_Item(2, 2), False)

    # Lưu bản trình bày dưới dạng tệp PPTX.
    presentation.save("MergeCells_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Sau đó chúng ta tiếp tục hợp nhất các ô bằng cách hợp nhất (1, 1) và (1, 2). Kết quả là một bảng có một ô hợp nhất lớn ở giữa:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpase.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Truy cập slide đầu tiên.
    slide = presentation.getSlides().get_Item(0)

    # Định nghĩa độ rộng cột và chiều cao hàng.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Thêm một bảng vào slide.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Đặt định dạng đường viền cho mỗi ô.
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderTop().setWidth(5)

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderBottom().setWidth(5)

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderLeft().setWidth(5)

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderRight().setWidth(5)


    # Hợp nhất các ô (1, 1) và (2, 1).
    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 1), False)

    # Hợp nhất các ô (1, 2) và (2, 2).
    table.mergeCells(table.get_Item(1, 2), table.get_Item(2, 2), False)

    # Hợp nhất các ô (1, 1) và (1, 2).
    table.mergeCells(table.get_Item(1, 1), table.get_Item(1, 2), True)

    # Lưu bản trình bày dưới dạng tệp PPTX.
    presentation.save("MergeCells_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Đánh số trong ô được tách**

Trong các ví dụ trước, việc hợp nhất các ô bảng không thay đổi số thứ tự của các ô còn lại.

Lần này, chúng ta lấy một bảng thông thường (bảng không có ô nào đã hợp nhất) và sau đó cố gắng tách ô (1, 1) để tạo ra một bảng đặc biệt. Bạn có thể muốn chú ý đến cách đánh số của bảng này, có thể sẽ cảm thấy lạ. Tuy nhiên, đó là cách Microsoft PowerPoint đánh số các ô bảng và Aspose.Slides cũng làm tương tự.

Mã Python này minh họa quy trình chúng tôi mô tả:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Truy cập slide đầu tiên.
    slide = presentation.getSlides().get_Item(0)

    # Định nghĩa độ rộng cột và chiều cao hàng.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Thêm một bảng vào slide.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Đặt định dạng đường viền cho mỗi ô.
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderTop().setWidth(5)

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderBottom().setWidth(5)

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderLeft().setWidth(5)

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderRight().setWidth(5)


    # Tách ô (1, 1).
    table.get_Item(1, 1).splitByWidth(table.get_Item(2, 1).getWidth() / 2)

    # Lưu bản trình bày dưới dạng tệp PPTX.
    presentation.save("SplitCells_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Thay đổi màu nền của ô bảng**

Mã Python này cho bạn thấy cách thay đổi màu nền của một ô bảng:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Truy cập slide đầu tiên.
    slide = presentation.getSlides().get_Item(0)

    # Định nghĩa độ rộng cột và chiều cao hàng.
    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]

    # Thêm một bảng vào slide.
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    # Đặt màu nền cho một ô.
    cell = table.get_Item(2, 3)
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid)
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    # Lưu bản trình bày dưới dạng tệp PPTX.
    presentation.save("cell_background_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Thêm hình ảnh vào bên trong ô bảng**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) .
2. Lấy tham chiếu đến một slide theo chỉ mục của nó.
3. Định nghĩa một danh sách độ rộng cột.
4. Định nghĩa một danh sách chiều cao hàng.
5. Thêm một bảng vào slide thông qua phương thức [addTable](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapecollection/#addTable) .
6. Tải tệp hình ảnh bằng cách sử dụng [Images.fromFile](https://reference.aspose.com/slides/vi/python-java/aspose.slides/images/#fromFile) .
7. Thêm hình ảnh vào bản trình bày để tạo một đối tượng [PPImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/ppimage/) .
8. Đặt loại tô của [FillFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fillformat/) cho ô bảng thành [FillType.Picture](https://reference.aspose.com/slides/vi/python-java/aspose.slides/filltype/#Picture) .
9. Thêm hình ảnh vào ô đầu tiên của bảng.
10. Lưu bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

Mã Python này cho bạn thấy cách chèn hình ảnh vào bên trong một ô bảng khi tạo bảng:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Images, FillType, PictureFillMode, SaveFormat

presentation = Presentation()
try:
    # Truy cập slide đầu tiên.
    slide = presentation.getSlides().get_Item(0)

    # Định nghĩa độ rộng cột và chiều cao hàng.
    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100, 90]

    # Thêm một bảng vào slide.
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    # Tạo hình ảnh cho bản trình bày từ tệp hình ảnh.
    image = Images.fromFile("image.jpg")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    # Thêm hình ảnh vào ô bảng đầu tiên.
    cell_format = table.get_Item(0, 0).getCellFormat()
    cell_format.getFillFormat().setFillType(FillType.Picture)
    cell_format.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
    cell_format.getFillFormat().getPictureFillFormat().getPicture().setImage(picture)

    # Lưu bản trình bày dưới dạng tệp PPTX.
    presentation.save("Image_In_TableCell_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Câu hỏi thường gặp**

**Tôi có thể đặt độ dày và kiểu đường viền khác nhau cho các phía khác nhau của một ô duy nhất không?**

Có. Các đường viền [trên](https://reference.aspose.com/slides/vi/python-java/aspose.slides/cellformat/#getBorderTop)/[dưới](https://reference.aspose.com/slides/vi/python-java/aspose.slides/cellformat/#getBorderBottom)/[trái](https://reference.aspose.com/slides/vi/python-java/aspose.slides/cellformat/#getBorderLeft)/[phải](https://reference.aspose.com/slides/vi/python-java/aspose.slides/cellformat/#getBorderRight) có các thuộc tính riêng, vì vậy độ dày và kiểu của mỗi phía có thể khác nhau. Điều này hợp lý dựa trên việc kiểm soát đường viền từng phía cho một ô được trình bày trong bài viết.

**Điều gì xảy ra với hình ảnh nếu tôi thay đổi kích thước cột/hàng sau khi đã đặt hình ảnh làm nền cho ô?**

Hành vi phụ thuộc vào [chế độ tô](https://reference.aspose.com/slides/vi/python-java/aspose.slides/picturefillmode/) (kéo dãn/ghép mẫu). Khi kéo dãn, hình ảnh sẽ điều chỉnh theo ô mới; khi ghép mẫu, các mẫu sẽ được tính lại. Bài viết đề cập đến các chế độ hiển thị hình ảnh trong ô.

**Tôi có thể gán siêu liên kết cho toàn bộ nội dung của một ô không?**

[Hyperlinks](/slides/vi/python-java/manage-hyperlinks/) được đặt ở mức văn bản (phần) bên trong khung văn bản của ô hoặc ở mức toàn bộ bảng/hình dạng. Trong thực tế, bạn gán liên kết cho một phần hoặc cho toàn bộ văn bản trong ô.

**Tôi có thể đặt các phông chữ khác nhau trong một ô duy nhất không?**

Có. Khung văn bản của ô hỗ trợ [các phần](https://reference.aspose.com/slides/vi/python-java/aspose.slides/portion/) (runs) với định dạng độc lập—gia đình phông chữ, kiểu, kích thước và màu sắc.