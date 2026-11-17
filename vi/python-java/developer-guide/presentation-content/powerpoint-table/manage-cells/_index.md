---
title: Quản lý các ô bảng trong bản trình chiếu bằng Python
linktitle: Quản lý Ô
type: docs
weight: 30
url: /vi/python-java/manage-cells/
keywords:
- ô bảng
- hợp nhất ô
- xóa đường viền
- tách ô
- ảnh trong ô
- màu nền
- PowerPoint
- bản trình chiếu
- Python
- Aspose.Slides
description: "Quản lý các ô bảng PowerPoint trong Python: xác định ô đã hợp nhất, xóa đường viền, tách ô và đặt màu nền cùng ảnh bằng Aspose.Slides cho Python qua Java."
---
## **Tổng quan**

Aspose.Slides cho phép bạn truy cập và sửa đổi các ô bảng trong bản trình chiếu PowerPoint. Bài viết này giải thích cách xác định các ô bảng đã hợp nhất, xóa đường viền ô, làm việc với đánh số ô sau khi hợp nhất hoặc tách ô, thay đổi màu nền của ô, và thêm ảnh vào trong ô bảng. Các ví dụ cho thấy cách tạo hoặc mở một bản trình chiếu, lấy bảng từ một slide, cập nhật định dạng ô thông qua các thuộc tính ô, và lưu bản trình chiếu đã sửa đổi dưới dạng tệp PPTX.

Aspose.Slides sử dụng chỉ số bắt đầu từ 0 để truy cập các ô bảng theo thứ tự `(cột, hàng)`.

## **Xác định ô bảng đã hợp nhất**

Ví dụ mở một bản trình chiếu hiện có và truy cập hình dạng đầu tiên trên slide đầu tiên như một bảng. Nó giả định rằng slide và hình dạng tồn tại và hình dạng là một bảng. Sau đó, nó lặp qua tất cả các hàng và cột và sử dụng [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) để xác định các ô trong vùng đã hợp nhất. Đối với mỗi kết quả phù hợp, nó in ra tọa độ ô theo thứ tự `row;column`, [getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan), [getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan), và tọa độ bắt đầu của vùng, [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) và [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex).

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

## **Xóa đường viền ô bảng**

Tạo một [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) và thêm một bảng vào slide đầu tiên của nó bằng [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable). Độ rộng cột, chiều cao hàng và vị trí bảng được chỉ định bằng điểm. Ví dụ đặt tất cả bốn đường viền ô thành [FillType.NoFill](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/), làm chúng vô hình.

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

## **Thêm đường viền chéo cho ô**

Sử dụng [getBorderDiagonalDown](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderDiagonalDown) để vẽ một đường từ góc trên‑trái đến góc dưới‑phải, và [getBorderDiagonalUp](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderDiagonalUp) để vẽ một đường từ góc dưới‑trái đến góc trên‑phải. Đường chéo có thể đánh dấu tiêu đề góc. Cả hai đường chéo có thể tạo thành dạng X để đánh dấu ô là không áp dụng.

Mỗi đường chéo là một [LineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/). Trong [getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getFillFormat) của nó, sử dụng [setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) để chọn [FillType.Solid](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) và chọn màu qua [getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor). Đặt độ rộng của đường bằng điểm bằng [setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setWidth).

Ví dụ tạo ba ô trong một hàng: một đường chéo xuôi màu đỏ, một đường chéo ngược màu xanh lam, và cả hai đường chéo. Nó để nguyên các đường viền trên, dưới, trái và phải của ô.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color


def format_border(border, color, width):
    fill = border.getFillFormat()
    fill.setFillType(FillType.Solid)
    fill.getSolidFillColor().setColor(color)
    border.setWidth(width)


presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().addTable(45, 130, [210, 210, 210], [160])

    left_cell = table.get_Item(0, 0).getCellFormat()
    middle_cell = table.get_Item(1, 0).getCellFormat()
    right_cell = table.get_Item(2, 0).getCellFormat()
    format_border(left_cell.getBorderDiagonalDown(), Color.RED, 3)
    format_border(middle_cell.getBorderDiagonalUp(), Color.BLUE, 5)
    format_border(right_cell.getBorderDiagonalDown(), Color.RED, 3)
    format_border(right_cell.getBorderDiagonalUp(), Color.BLUE, 5)

    presentation.save("diagonal_cell_borders.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Đường chéo là một thuộc tính định dạng, không phải là việc tách ô. Mỗi ô giữ một khung văn bản duy nhất, được truy cập qua [getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getTextFrame). Các khu vực ở hai phía của đường chéo không thể chỉnh sửa độc lập.

Bảng đã lưu, được hiển thị trong Microsoft PowerPoint:

![Ba ô bảng hiển thị một đường chéo màu đỏ từ góc trên‑trái đến góc dưới‑phải, một đường chéo màu xanh lam từ góc dưới‑trái đến góc trên‑phải, và cả hai đường chéo tạo thành một chữ X.](diagonal-cell-borders.png)

*Trái sang phải: đường chéo xuôi (đỏ, 3 pt), đường chéo ngược (xanh lam, 5 pt), và cả hai đường chéo.*

## **Hợp nhất các ô bảng**

Sử dụng [mergeCells](https://reference.aspose.com/slides/python-java/aspose.slides/table/#mergeCells) để kết hợp một phạm vi hình chữ nhật các ô bảng thành một ô duy nhất. Xác định các ô ở góc trên‑trái và góc dưới‑phải của phạm vi. Tham số cuối cùng điều khiển việc hợp nhất có cho phép bao gồm các ô ngoài phạm vi đã chỉ định hay không; `False` giữ hợp nhất trong phạm vi đó.

Ví dụ tạo một bảng 4×4 với các cột và hàng có độ rộng/chiều cao 70 điểm, sau đó hợp nhất bốn ô trung tâm từ `(1, 1)` tới `(2, 2)`. Ô kết quả bao phủ hai cột và hai hàng, trong khi lưới cơ bản của bảng vẫn giữ bốn cột và bốn hàng. Để truy cập nội dung hoặc định dạng của ô đã hợp nhất, sử dụng vị trí góc trên‑trái của nó: `table.get_Item(1, 1)` trong ví dụ này. Các vị trí khác trong phạm vi hợp nhất vẫn là một phần của lưới bảng, vì vậy các chỉ mục của các ô ngoài phạm vi không thay đổi.

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

Việc hợp nhất các ô trong ví dụ trước giữ nguyên lưới của bảng. Tách một ô có thể tạo ra một cột lưới mới và thay đổi chỉ mục cột của các ô ở bên phải nó. Aspose.Slides tuân theo mô hình lưới bảng của PowerPoint.

Ví dụ này tạo một bảng 4×4 với các cột và hàng có độ rộng/chiều cao 70 điểm và gọi [splitByWidth](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByWidth) trên ô `(1, 1)`. Một nửa độ rộng 70 điểm của ô được dùng để tạo hai ô có độ rộng bằng nhau.

Sau khi tách, hai nửa được truy cập bằng `table.get_Item(1, 1)` và `table.get_Item(2, 1)`. Lưới bảng hiện có năm cột: các ô ban đầu ở cột 2 và 3 chuyển sang cột 3 và 4, tương ứng. Chỉ mục hàng vẫn không thay đổi. Sử dụng các chỉ mục cột đã cập nhật khi truy cập các ô sau khi tách.

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

<!-- visual-explanation:manage-cells:start -->
[![Một ô 70 điểm chưa hợp nhất được tách thành hai ô 35 điểm, thêm một cột lưới thứ năm và dịch các chỉ mục sang bên phải.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*Việc tách theo chiều rộng ảnh hưởng đến ô (1, 1), sử dụng chỉ số bắt đầu từ 0 (cột, hàng). Các hàng khác giữ một ô phủ cả hai vị trí cột mới.*
<!-- visual-explanation:manage-cells:end -->

### **Tách các ô đã hợp nhất theo phạm vi hàng hoặc cột**

Để chuẩn bị các ô mẫu đã hợp nhất cho việc điền dữ liệu, sử dụng [splitByRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByRowSpan) để tách dọc theo ranh giới hàng hiện có, hoặc [splitByColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByColSpan) để tách dọc theo ranh giới cột.

Tham số `index` đếm số hàng ở phần trên hoặc số cột ở phần trái của phần tách; nó được tính tương đối so với vùng đã hợp nhất:

- Tách hàng: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan).
- Tách cột: `0 < index <` [getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan).

Ví dụ yêu cầu bản trình chiếu có một bảng là hình dạng đầu tiên trên slide đầu tiên, với `(1, 2)` và `(1, 3)` được hợp nhất theo chiều dọc. Bắt đầu từ vị trí dưới, nó sử dụng [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex) và [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) để xác định nguồn gốc và kiểm tra cả hai phạm vi. `splitByRowSpan(1)` sau đó tách các hàng 2 và 3 cho tên sản phẩm. Đối với việc hợp nhất ngang hai cột, sử dụng `splitByColSpan(1)` thay thế.

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

Lưới bảng và các chỉ mục ô xung quanh vẫn không thay đổi. Lấy các ô kết quả bằng tọa độ của chúng; ở đây, cả hai đều có phạm vi 1 và [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) trả về `False`. Các vùng lớn hơn có thể vẫn còn phần nào được hợp nhất sau một lần tách.

Văn bản gốc và định dạng của nó vẫn giữ trong ô trên (hoặc trái); ô mới trống nhưng kế thừa định dạng ô như màu nền, đường viền và lề. Điền dữ liệu vào các ô sau khi tách và đặt bất kỳ định dạng văn bản nào cần thiết một cách rõ ràng.

Bản trình chiếu đã lưu chứa các ô riêng biệt "Product A" và "Product B" với định dạng ô của mẫu được giữ lại. Xem [Cell API Reference](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) để biết chi tiết.

### **Tách một ô theo chiều cao cụ thể**

[splitByHeight](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByHeight) nhận chiều cao của phần trên bằng điểm. [splitByRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByRowSpan) nhận số hàng lưới hiện có ở phần trên. Để căn giữa một ô 40 điểm trong cột phải, trừ 40 từ chiều cao thực tế của ô và chia phần không gian còn lại đều lên trên và dưới.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().addTable(50, 50, [160, 160], [140])
    table.get_Item(0, 0).getTextFrame().setText("Left")

    height = table.get_Item(1, 0).getHeight()
    margin = (height - 40) / 2
    
    table.get_Item(1, 0).splitByHeight(margin)
    table.get_Item(1, 1).splitByHeight(40)
    table.get_Item(1, 1).getTextFrame().setText("Middle")

    presentation.save("split_by_height.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Lần tách đầu tiên thêm một hàng lưới và để lại 90 điểm phía dưới trong ô `(1, 1)`. Lần tách thứ hai chia ô đó thành một ô trung tâm 40 điểm và một ô dưới 50 điểm. Cột phải hiện có ba ô với chiều cao lần lượt là 50, 40 và 50 điểm từ trên xuống dưới. Ô trái phủ ba hàng và giữ nguyên chiều cao ban đầu là 140 điểm.

![Ô trái phủ toàn bộ chiều cao bảng bên cạnh ba ô có chữ Middle ở giữa.](split-by-height.png)

## **Thay đổi màu nền của ô bảng**

Ví dụ này tạo một bảng với các cột 150 điểm và các hàng 50 điểm. Nó sử dụng [setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) để chọn màu nền đặc và đặt màu trả về bởi [getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor) thành màu đỏ cho ô `(2, 3)`, nằm ở cột thứ ba và hàng thứ tư.

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

## **Thêm ảnh vào trong ô bảng**

Đặt ảnh đầu vào trong thư mục làm việc trước khi chạy ví dụ này. Nó tải ảnh bằng [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile) và thêm nó vào bộ sưu tập ảnh của bản trình chiếu bằng [addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage). Sau đó, nó gán ảnh vào nền hình ảnh của ô `(0, 0)`, ô đầu tiên trong bảng.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/) kéo dài ảnh để lấp đầy ô, có thể làm thay đổi tỷ lệ hình ảnh. Độ rộng cột và chiều cao hàng được tính bằng điểm. Ảnh đã tải sẽ được giải phóng trong khối `finally` sau khi đã thêm vào bản trình chiếu.

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

## **Câu hỏi thường gặp**

**Tôi có thể đặt độ dày và kiểu đường khác nhau cho các mặt của một ô duy nhất không?**

Có. Các đường viền [trên](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderTop)/[dưới](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderBottom)/[trái](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderLeft)/[phải](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderRight) có các thuộc tính riêng, vì vậy độ dày và kiểu của mỗi mặt có thể khác nhau.

**Điều gì sẽ xảy ra với ảnh nếu tôi thay đổi kích thước cột/hàng sau khi đã đặt ảnh làm nền của ô?**

Hành vi phụ thuộc vào [fill mode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/). Khi kéo dài, ảnh sẽ điều chỉnh theo ô mới; khi gạch lát, các mảnh ảnh sẽ được tính lại.

**Tôi có thể gán siêu liên kết cho toàn bộ nội dung của một ô không?**

[Liên kết siêu văn bản](/slides/vi/python-java/manage-hyperlinks/) được đặt ở mức văn bản (phần) bên trong khung văn bản của ô hoặc ở mức toàn bộ bảng/hình dạng. Trong thực tế, bạn gán liên kết cho một phần hoặc cho toàn bộ văn bản trong ô.

**Tôi có thể đặt các phông chữ khác nhau trong một ô duy nhất không?**

Có. Khung văn bản của ô hỗ trợ [portions](https://reference.aspose.com/slides/python-java/aspose.slides/portion/) (các đoạn) với định dạng độc lập—gia đình phông, kiểu, kích thước và màu.