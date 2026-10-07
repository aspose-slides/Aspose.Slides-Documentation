---
title: Quản lý các ô bảng trong bản trình chiếu bằng Python
linktitle: Quản lý ô
type: docs
weight: 30
url: /vi/python-java/manage-cells/
keywords:
- ô bảng
- hợp nhất ô
- xóa viền
- tách ô
- hình ảnh trong ô
- màu nền
- PowerPoint
- bản trình chiếu
- Python
- Aspose.Slides
description: "Quản lý các ô bảng PowerPoint trong Python: xác định các ô đã hợp nhất, xóa viền, tách ô, và đặt màu nền và hình ảnh bằng Aspose.Slides cho Python thông qua Java."
---
## **Tổng quan**

Aspose.Slides cho phép bạn truy cập và chỉnh sửa các ô bảng trong bản trình chiếu PowerPoint. Bài viết này giải thích cách xác định các ô bảng đã hợp nhất, xóa viền ô, làm việc với việc đánh số ô sau khi hợp nhất hoặc tách ô, thay đổi màu nền của ô, và thêm hình ảnh vào bên trong một ô bảng. Các ví dụ hiển thị cách tạo hoặc mở một bản trình chiếu, lấy bảng từ một slide, cập nhật định dạng ô thông qua các thuộc tính của ô, và lưu bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX.

Aspose.Slides sử dụng chỉ mục bắt đầu từ 0 để truy cập các ô bảng theo thứ tự `(column, row)`.

## **Xác định ô bảng đã hợp nhất**

Ví dụ mở một bản trình chiếu đã tồn tại và truy cập hình dạng đầu tiên trên slide đầu tiên dưới dạng bảng. Nó giả định rằng slide và hình dạng tồn tại và hình dạng là một bảng. Sau đó, nó duyệt qua tất cả các hàng và cột và sử dụng [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) để xác định các ô trong vùng đã hợp nhất. Đối với mỗi kết quả khớp, nó in tọa độ ô theo thứ tự `row;column`, [getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan), [getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan), và tọa độ bắt đầu của vùng, [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) và [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation_with_table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    row_count = table.getRows().size()
    for row_index in range(row_count):
        column_count = table.getColumns().size()
        for column_index in range(column_count):
            cell = table.get_Item(column_index, row_index)
            if cell.isMergedCell():
                print(f"Cell {row_index};{column_index} belongs to a merged region with RowSpan={cell.getRowSpan()} and ColSpan={cell.getColSpan()} starting at {cell.getFirstRowIndex()};{cell.getFirstColumnIndex()}.")
finally:
    presentation.dispose()
```

## **Xóa viền ô bảng**

Tạo một [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) và thêm một bảng vào slide đầu tiên của nó bằng [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable). Chiều rộng cột, chiều cao hàng và vị trí bảng được chỉ định bằng điểm. Ví dụ đặt cả bốn viền ô thành [FillType.NoFill](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/), khiến chúng trở nên vô hình.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill)

    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Hợp nhất các ô bảng**

Sử dụng [mergeCells](https://reference.aspose.com/slides/python-java/aspose.slides/table/#mergeCells) để kết hợp một phạm vi hình chữ nhật các ô bảng thành một ô duy nhất. Xác định các ô ở góc trên‑trái và góc dưới‑phải của phạm vi. Tham số cuối cùng kiểm soát việc hợp nhất có thể bao gồm các ô nằm ngoài phạm vi đã chỉ định hay không; `False` giữ việc hợp nhất trong phạm vi đó.

Ví dụ tạo một bảng 4x4 với các cột và hàng có chiều rộng/chiều cao 70 điểm, sau đó hợp nhất bốn ô trung tâm từ `(1, 1)` đến `(2, 2)`. Ô kết quả bao phủ hai cột và hai hàng, trong khi lưới cơ bản của bảng vẫn giữ bốn cột và bốn hàng. Để truy cập nội dung hoặc định dạng của ô đã hợp nhất, sử dụng vị trí trên‑trái của nó: `table.get_Item(1, 1)` trong ví dụ này. Các vị trí khác trong phạm vi đã hợp nhất vẫn là một phần của lưới bảng, vì vậy chỉ mục của các ô nằm ngoài phạm vi không thay đổi.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 2), False)

    presentation.save("merged_cells.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Tách các ô bảng**

Việc hợp nhất các ô trong ví dụ trước giữ nguyên lưới của bảng. Tách một ô có thể tạo thêm một cột lưới mới và thay đổi chỉ mục cột của các ô nằm bên phải nó. Aspose.Slides tuân theo mô hình lưới bảng của PowerPoint.

Ví dụ này tạo một bảng 4x4 với các cột và hàng 70 điểm và gọi [splitByWidth](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByWidth) trên ô `(1, 1)`. Một nửa độ rộng 70 điểm của ô được truyền để tạo hai ô có độ rộng bằng nhau.

Sau khi tách, hai nửa được truy cập dưới dạng `table.get_Item(1, 1)` và `table.get_Item(2, 1)`. Lưới bảng hiện có năm cột: các ô ban đầu ở cột 2 và 3 chuyển sang cột 3 và 4 tương ứng. Chỉ mục hàng không thay đổi. Sử dụng các chỉ mục cột được cập nhật này khi truy cập các ô sau khi tách.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    table.get_Item(1, 1).splitByWidth(table.get_Item(1, 1).getWidth() / 2)

    presentation.save("split_cells.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Tách các ô đã hợp nhất theo chiều hàng hoặc cột**

Để chuẩn bị các ô mẫu đã hợp nhất cho việc điền dữ liệu, sử dụng [splitByRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByRowSpan) để tách dọc theo ranh giới hàng hiện có, hoặc [splitByColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByColSpan) để tách dọc theo ranh giới cột.

Tham số `index` đếm các hàng ở phần trên hoặc các cột ở phần trái của phép tách; nó tương đối với vùng đã hợp nhất:
- Tách hàng: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan).
- Tách cột: `0 < index <` [getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan).

Ví dụ yêu cầu bản trình chiếu có một bảng là hình dạng đầu tiên trên slide đầu tiên, với các ô `(1, 2)` và `(1, 3)` được hợp nhất dọc. Bắt đầu từ vị trí dưới, nó sử dụng [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex) và [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) để xác định nguồn gốc và kiểm tra cả hai phạm vi. `splitByRowSpan(1)` sau đó tách các hàng 2 và 3 cho tên sản phẩm. Đối với việc hợp nhất ngang hai cột, thay vào đó sử dụng `splitByColSpan(1)`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("table_template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    selected_cell = table.get_Item(1, 3)
    first_column_index = selected_cell.getFirstColumnIndex()
    first_row_index = selected_cell.getFirstRowIndex()
    merged_cell = table.get_Item(first_column_index, first_row_index)

    if merged_cell.isMergedCell() and merged_cell.getRowSpan() == 2 and merged_cell.getColSpan() == 1:
        merged_cell.splitByRowSpan(1)

        # Lấy các ô kết quả từ bảng sau khi tách.
        upper_cell = table.get_Item(first_column_index, first_row_index)
        lower_cell = table.get_Item(first_column_index, first_row_index + 1)
        print(f"Upper cell merged: {upper_cell.isMergedCell()}")
        print(f"Lower cell merged: {lower_cell.isMergedCell()}")

        upper_cell.getTextFrame().setText("Product A")
        lower_cell.getTextFrame().setText("Product B")

        presentation.save("split_template.pptx", SaveFormat.Pptx)
    else:
        print("Select a merged region spanning exactly two rows and one column.")
finally:
    presentation.dispose()
```

Lưới bảng và các chỉ mục ô xung quanh vẫn không thay đổi. Lấy các ô kết quả bằng tọa độ của chúng; ở đây, cả hai đều có phạm vi 1 và [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) in ra `False`. Các khu vực lớn hơn có thể vẫn còn một phần được hợp nhất sau một lần tách.

Văn bản gốc và định dạng của nó vẫn giữ trong ô trên (hoặc trái); ô mới trống nhưng kế thừa định dạng ô như nền, viền và lề. Điền dữ liệu vào các ô sau khi tách và đặt bất kỳ định dạng văn bản nào cần thiết một cách rõ ràng.

Bản trình chiếu đã lưu chứa các ô "Product A" và "Product B" riêng biệt với định dạng ô của mẫu được giữ lại. Xem [Cell API Reference](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) để biết chi tiết.

## **Thay đổi màu nền của ô bảng**

Ví dụ này tạo một bảng có các cột 150 điểm và các hàng 50 điểm. Nó sử dụng [setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) để chọn nền đặc và đặt màu được trả về bởi [getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor) thành màu đỏ cho ô `(2, 3)`, ở cột thứ ba và hàng thứ tư.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    cell = table.get_Item(2, 3)
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid)
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    presentation.save("cell_background_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Thêm hình ảnh vào bên trong ô bảng**

Đặt hình ảnh đầu vào trong thư mục làm việc trước khi chạy ví dụ này. Nó tải hình ảnh bằng [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile) và thêm nó vào bộ sưu tập hình ảnh của bản trình chiếu bằng [addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage). Sau đó nó gán hình ảnh cho nền hình ảnh của ô `(0, 0)`, ô đầu tiên trong bảng.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/) kéo dài hình ảnh để lấp đầy ô, có thể làm thay đổi tỷ lệ khung hình. Chiều rộng cột và chiều cao hàng được tính bằng điểm. Hình ảnh đã tải được giải phóng trong một khối `finally` sau khi nó được thêm vào bản trình chiếu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Images, FillType, PictureFillMode, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100, 90]
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    image = Images.fromFile("aspose_logo.jpg")
    try:
        presentation_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    table.get_Item(0, 0).getCellFormat().getFillFormat().setFillType(FillType.Picture)
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().getPicture().setImage(presentation_image)

    presentation.save("table_cell_with_image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Có thể đặt độ dày và kiểu đường viền khác nhau cho mỗi phía của một ô duy nhất không?**

Có. Các viền [top](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderTop)/[bottom](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderBottom)/[left](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderLeft)/[right](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderRight) có các thuộc tính riêng, do đó độ dày và kiểu của mỗi phía có thể khác nhau.

**Điều gì xảy ra với hình ảnh nếu tôi thay đổi kích thước cột/hàng sau khi đặt hình ảnh làm nền của ô?**

Hành vi phụ thuộc vào [fill mode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/). Khi kéo dài, hình ảnh sẽ điều chỉnh theo ô mới; khi lặp lại, các ô lặp sẽ được tính lại.

**Có thể gán một siêu liên kết cho toàn bộ nội dung của một ô không?**

[Hyperlinks](/slides/vi/python-java/manage-hyperlinks/) được đặt ở mức văn bản (phần) bên trong khung văn bản của ô hoặc ở mức toàn bộ bảng/hình dạng. Trong thực tế, bạn gán liên kết cho một phần hoặc cho toàn bộ văn bản trong ô.

**Có thể đặt các phông chữ khác nhau trong một ô duy nhất không?**

Có. Khung văn bản của ô hỗ trợ [portions](https://reference.aspose.com/slides/python-java/aspose.slides/portion/) (các đoạn) với định dạng độc lập—gia đình phông, kiểu, kích thước và màu.