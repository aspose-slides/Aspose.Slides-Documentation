---
title: Quản lý Bảng trong Bản trình chiếu bằng Python
linktitle: Quản lý Bảng
type: docs
weight: 10
url: /vi/python-java/manage-table/
keywords:
- thêm bảng
- tạo bảng
- truy cập bảng
- tỷ lệ khung hình
- căn chỉnh văn bản
- định dạng văn bản
- kiểu bảng
- PowerPoint
- bản trình chiếu
- Python
- Aspose.Slides
description: "Tạo & chỉnh sửa bảng trong các slide PowerPoint với Aspose.Slides cho Python qua Java. Khám phá các ví dụ mã đơn giản để tối ưu hoá quy trình làm việc với bảng."
---
## **Giới thiệu**

Bảng trong PowerPoint là một cách hiệu quả để hiển thị thông tin. Thông tin trong lưới các ô (được sắp xếp thành hàng và cột) rất trực quan và dễ hiểu.

Aspose.Slides cung cấp lớp [Table](https://reference.aspose.com/slides/vi/python-java/aspose.slides/table/) và lớp [Cell](https://reference.aspose.com/slides/vi/python-java/aspose.slides/cell/) cùng các kiểu khác để cho phép bạn tạo, cập nhật và quản lý các bảng trong mọi loại bản trình chiếu.

## **Tạo bảng từ đầu**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) .
2. Lấy tham chiếu tới một slide dựa trên chỉ mục của nó.
3. Xác định danh sách chiều rộng cột.
4. Xác định danh sách chiều cao hàng.
5. Thêm một đối tượng [Table](https://reference.aspose.com/slides/vi/python-java/aspose.slides/table/) vào slide thông qua phương thức [addTable](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapecollection/#addTable) .
6. Lặp qua từng [Cell](https://reference.aspose.com/slides/vi/python-java/aspose.slides/cell/) để áp dụng định dạng cho các viền trên, dưới, phải và trái.
7. Hợp nhất hai ô đầu tiên của hàng đầu tiên trong bảng.
8. Truy cập tới [TextFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframe/) của một [Cell](https://reference.aspose.com/slides/vi/python-java/aspose.slides/cell/) .
9. Thêm một số văn bản vào [TextFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframe/) .
10. Lưu bản trình chiếu đã chỉnh sửa.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

# Khởi tạo một lớp Presentation đại diện cho tệp PPTX
presentation = Presentation()
try:

    # Truy cập slide đầu tiên
    slide = presentation.getSlides().get_Item(0)

    # Xác định các cột với độ rộng và các hàng với độ cao
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Thêm một shape bảng vào slide
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Đặt định dạng viền cho mỗi ô
    for row in table.getRows():
        for cell in row:
            cell_format = cell.getCellFormat()
            cell_format.getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderTop().setWidth(5)
            cell_format.getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderBottom().setWidth(5)
            cell_format.getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderLeft().setWidth(5)
            cell_format.getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderRight().setWidth(5)

    # Hợp nhất các ô 1 và 2 của hàng 1
    table.mergeCells(table.getRows().get_Item(0).get_Item(0), table.getRows().get_Item(0).get_Item(1), False)

    # Thêm một số văn bản vào ô đã hợp nhất
    table.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells")

    # Lưu bản trình chiếu vào Đĩa
    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Đánh số trong bảng tiêu chuẩn**

Trong một bảng tiêu chuẩn, việc đánh số các ô là đơn giản và bắt đầu từ 0. Ô đầu tiên trong bảng được đánh chỉ số là 0,0 (cột 0, hàng 0).

Ví dụ, các ô trong một bảng có 4 cột và 4 hàng được đánh số như sau:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Đoạn mã Python này cho bạn thấy cách tạo một bảng với việc đánh số ô tiêu chuẩn:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

# Khởi tạo một lớp Presentation đại diện cho tệp PPTX
presentation = Presentation()
try:

    # Truy cập slide đầu tiên
    slide = presentation.getSlides().get_Item(0)

    # Xác định các cột với độ rộng và các hàng với độ cao
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Thêm một shape bảng vào slide
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Đặt định dạng viền cho mỗi ô
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

    # Lưu bản trình chiếu vào đĩa
    presentation.save("StandardTables_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Truy cập bảng hiện có**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) .
2. Lấy tham chiếu đến slide chứa bảng thông qua chỉ mục của nó.
3. Khởi tạo một biến cho đối tượng [Table](https://reference.aspose.com/slides/vi/python-java/aspose.slides/table/) và gán giá trị `None` .
4. Lặp qua tất cả các đối tượng [Shape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/) cho đến khi tìm thấy bảng.

   Nếu bạn nghi ngờ slide đang làm việc chỉ chứa một bảng, bạn có thể đơn giản kiểm tra tất cả các shape mà nó chứa. Khi một shape được xác định là bảng, bạn có thể sử dụng nó như một đối tượng [Table](https://reference.aspose.com/slides/vi/python-java/aspose.slides/table/) . Nhưng nếu slide chứa nhiều bảng, thì bạn nên tìm kiếm bảng cần thiết thông qua thuộc tính [getAlternativeText](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#getAlternativeText) .

5. Sử dụng đối tượng [Table](https://reference.aspose.com/slides/vi/python-java/aspose.slides/table/) để làm việc với bảng. Trong ví dụ dưới đây, chúng tôi cập nhật văn bản ở cột đầu tiên của hàng thứ hai.
6. Lưu bản trình chiếu đã chỉnh sửa.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

# Khởi tạo lớp Presentation đại diện cho tệp PPTX
presentation = Presentation("UpdateExistingTable.pptx")
try:

    # Truy cập slide đầu tiên
    slide = presentation.getSlides().get_Item(0)

    # Khởi tạo tham chiếu đến bảng.
    table = None

    # Lặp qua các shape và đặt tham chiếu tới bảng được tìm thấy
    for shape in slide.getShapes():
        if isinstance(shape, Table):
            table = shape

            # Đặt văn bản cho cột đầu tiên của hàng thứ hai
            table.get_Item(0, 1).getTextFrame().setText("New")

    # Lưu bản trình chiếu đã chỉnh sửa vào đĩa
    presentation.save("table1_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Tìm ô sở hữu một Text Frame**

Khi mã xử lý văn bản chung nhận được một [TextFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframe/) từ một bảng, hãy sử dụng phương thức [TextFrame.getParentCell](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframe/#getParentCell) để lấy ô sở hữu [Cell](https://reference.aspose.com/slides/vi/python-java/aspose.slides/cell/) . Đối với TextFrame của ô bảng, [TextFrame.getParentCell](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframe/#getParentCell) trả về chủ sở hữu và [TextFrame.getParentShape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframe/#getParentShape) trả về `None`, mặc dù bảng tự nó là một shape.

Các tọa độ ô có sẵn thông qua các phương thức chỉ đọc [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/vi/python-java/aspose.slides/cell/#getFirstColumnIndex) và [Cell.getFirstRowIndex](https://reference.aspose.com/slides/vi/python-java/aspose.slides/cell/#getFirstRowIndex) . [TextFrame.getParentCell](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframe/#getParentCell) cũng cung cấp khả năng điều hướng chỉ đọc: nó trả về chủ sở hữu nhưng không thay đổi quyền sở hữu. Luôn kiểm tra xem ô trả về có `None` trước khi sử dụng.

Đối với một ví dụ đầy đủ xác định chủ sở hữu của ô bảng và shape, bao gồm các shape liên kết với nút SmartArt, xem phần [Search and Replace Text](/slides/vi/python-java/search-and-replace-text/) .

## **Căn chỉnh văn bản trong bảng**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) .
2. Lấy tham chiếu tới một slide dựa trên chỉ mục của nó.
3. Thêm một đối tượng [Table](https://reference.aspose.com/slides/vi/python-java/aspose.slides/table/) vào slide.
4. Truy cập một đối tượng [TextFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframe/) từ bảng.
5. Truy cập đến [Paragraph](https://reference.aspose.com/slides/vi/python-java/aspose.slides/paragraph/) của đối tượng [TextFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframe/) .
6. Căn chỉnh văn bản theo chiều dọc.
7. Lưu bản trình chiếu đã chỉnh sửa.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, TextAnchorType, TextVerticalType
from java.awt import Color

# Tạo một thể hiện của lớp Presentation
presentation = Presentation()
try:

    # Lấy slide đầu tiên
    slide = presentation.getSlides().get_Item(0)

    # Xác định các cột với độ rộng và các hàng với độ cao
    column_widths = [120, 120, 120, 120]
    row_heights = [100, 100, 100, 100]

    # Thêm shape bảng vào slide
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)
    table.get_Item(1, 0).getTextFrame().setText("10")
    table.get_Item(2, 0).getTextFrame().setText("20")
    table.get_Item(3, 0).getTextFrame().setText("30")

    # Truy cập vào TextFrame
    text_frame = table.get_Item(0, 0).getTextFrame()

    # Truy cập đoạn văn đầu tiên trong TextFrame.
    paragraph = text_frame.getParagraphs().get_Item(0)

    # Truy cập phần đầu tiên trong đoạn văn.
    portion = paragraph.getPortions().get_Item(0)
    portion.setText("Text here")
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    # Căn chỉnh văn bản theo chiều dọc
    cell = table.get_Item(0, 0)
    cell.setTextAnchorType(TextAnchorType.Center)
    cell.setTextVerticalType(TextVerticalType.Vertical270)

    # Lưu bản trình chiếu vào đĩa
    presentation.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Đặt định dạng văn bản ở mức bảng**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) .
2. Lấy tham chiếu tới một slide dựa trên chỉ mục của nó.
3. Truy cập một đối tượng [Table](https://reference.aspose.com/slides/vi/python-java/aspose.slides/table/) từ slide.
4. Đặt chiều cao phông chữ của văn bản bằng [setFontHeight](https://reference.aspose.com/slides/vi/python-java/aspose.slides/baseportionformat/#setFontHeight) .
5. Đặt căn chỉnh và lề phải bằng [setAlignment](https://reference.aspose.com/slides/vi/python-java/aspose.slides/paragraphformat/#setAlignment) và [setMarginRight](https://reference.aspose.com/slides/vi/python-java/aspose.slides/paragraphformat/#setMarginRight) .
6. Đặt kiểu văn bản dọc bằng [setTextVerticalType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframeformat/#setTextVerticalType) .
7. Lưu bản trình chiếu đã chỉnh sửa.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ParagraphFormat, PortionFormat, Presentation, SaveFormat, TextAlignment, TextFrameFormat, TextVerticalType, Table

# Tạo một thể hiện của lớp Presentation
presentation = Presentation("simpletable.pptx")
try:

    # Giả sử shape đầu tiên trên slide đầu tiên là một bảng
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape

        # Đặt chiều cao phông chữ cho các ô bảng
        portion_format = PortionFormat()
        portion_format.setFontHeight(25)
        table.setTextFormat(portion_format)

        # Đặt căn chỉnh văn bản và lề phải cho các ô bảng trong một lệnh
        paragraph_format = ParagraphFormat()
        paragraph_format.setAlignment(TextAlignment.Right)
        paragraph_format.setMarginRight(20)
        table.setTextFormat(paragraph_format)

        # Đặt kiểu văn bản dọc cho các ô bảng
        text_frame_format = TextFrameFormat()
        text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
        table.setTextFormat(text_frame_format)
        presentation.save("result.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **Lấy thuộc tính kiểu bảng**

Aspose.Slides cho phép bạn lấy các thuộc tính kiểu cho một bảng để bạn có thể sử dụng những chi tiết này cho bảng khác hoặc nơi khác. Đoạn mã Python này cho bạn thấy cách lấy các thuộc tính kiểu từ một kiểu bảng đã được cài đặt trước:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    table = presentation.getSlides().get_Item(0).getShapes().addTable(10, 10, [100, 150], [5, 5, 5])
    table.setStylePreset(TableStylePreset.DarkStyle1)  # thay đổi chủ đề preset kiểu mặc định

    # Lấy preset kiểu của bảng
    style_preset = table.getStylePreset()
    print("Table style preset: ", style_preset)

    # Áp dụng preset kiểu đã lấy cho bảng khác
    another_table = presentation.getSlides().get_Item(0).getShapes().addTable(10, 100, [100, 150], [5, 5, 5])
    another_table.setStylePreset(style_preset)
    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Khóa tỷ lệ khung hình của bảng**

Tỷ lệ khung hình của một hình dạng hình học là tỉ lệ kích thước của nó ở các chiều khác nhau. Aspose.Slides cung cấp phương thức [setAspectRatioLocked](https://reference.aspose.com/slides/vi/python-java/aspose.slides/graphicalobjectlock/#setAspectRatioLocked) cho phép bạn khóa cài đặt tỷ lệ khung hình cho các bảng và các shape khác.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("pres.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
        print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())
        table.getGraphicalObjectLock().setAspectRatioLocked(not table.getGraphicalObjectLock().getAspectRatioLocked())  # đảo ngược
        print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())
        presentation.save("pres-out.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **Câu hỏi thường gặp**

**Tôi có thể bật hướng đọc từ phải sang trái (RTL) cho toàn bộ bảng và văn bản trong các ô của nó không?**

Đúng. Bảng cung cấp phương thức [setRightToLeft](https://reference.aspose.com/slides/vi/python-java/aspose.slides/table/#setRightToLeft) , và các đoạn văn có [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/vi/python-java/aspose.slides/paragraphformat/#setRightToLeft) . Sử dụng cả hai đảm bảo thứ tự và hiển thị RTL đúng bên trong các ô.

**Làm sao tôi có thể ngăn người dùng di chuyển hoặc thay đổi kích thước bảng trong file cuối cùng?**

Sử dụng [shape locks](/slides/vi/python-java/applying-protection-to-presentation/) để vô hiệu hoá việc di chuyển, thay đổi kích thước, chọn, v.v. Các khóa này cũng áp dụng cho bảng.

**Việc chèn hình ảnh vào bên trong một ô làm nền có được hỗ trợ không?**

Đúng. Bạn có thể đặt một [picture fill](https://reference.aspose.com/slides/vi/python-java/aspose.slides/picturefillformat/) cho ô; hình ảnh sẽ phủ toàn bộ khu vực ô theo chế độ đã chọn (kéo dài hoặc lát gạch).