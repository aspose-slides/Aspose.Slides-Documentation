---
title: Quản lý bảng trong bài thuyết trình bằng Python
linktitle: Quản lý bảng
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
- bài thuyết trình
- Python
- Aspose.Slides
description: "Tạo và chỉnh sửa bảng trong slide PowerPoint với Aspose.Slides cho Python thông qua Java. Khám phá các ví dụ mã đơn giản để tối ưu quy trình làm việc với bảng của bạn."
---
## **Giới thiệu**

Tables in PowerPoint organize information into rows and columns, making it easier to read and compare values.

Aspose.Slides provides the [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) and [Cell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) classes and other types to allow you to create, update, and manage tables in presentations.

## **Tạo bảng từ đầu**

Create a table by specifying its position, column widths, and row heights. After adding it to a slide, you can format cell borders, merge cells, and insert text.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class.
2. Get a reference to the slide by its index.
3. Define a list of column widths in points.
4. Define a list of row heights in points.
5. Add a [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) object to the slide through the [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable) method.
6. Iterate through each [Cell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) to apply formatting to the top, bottom, right, and left borders.
7. Merge the first two cells of the table's first row.
8. Access the merged cell through its [getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getTextFrame) method.
9. Set the text in the merged cell.
10. Save the modified presentation.

The example below creates a table with three columns and five rows at (100, 50) points. It applies red borders with a width of 5 points, merges the first two cells in the first row, and saves the result as `table.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

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

    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 0), False)
    table.get_Item(0, 0).getTextFrame().setText("Merged Cells")

    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Đánh số trong một bảng tiêu chuẩn**

In a standard table, cell indices are zero-based and use the order (column, row). The first cell is indexed as (0, 0).

For example, the cells in a table with 4 columns and 4 rows are numbered this way:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

This example creates the 4 × 4 table illustrated above, with column widths and row heights of 70 points and red cell borders with a width of 5 points. The coordinates illustrate cell indices; the example leaves the cells empty and saves the table as `StandardTables_out.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

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

    presentation.save("StandardTables_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Truy cập một bảng hiện có**

Tables are stored in a slide's shape collection. Iterate through the shapes to locate a table, then use the [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) class to read or update its cells.

1. Load the presentation using the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class.
2. Get a reference to the slide containing the table by its index.
3. Iterate through the [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) objects and stop when a table is found. If the slide contains several tables, use [getAlternativeText](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getAlternativeText) to identify the one you need.
4. Update the text in the target cell.
5. Save the modified presentation.

The example below opens `UpdateExistingTable.pptx` and finds the first table on the first slide. It sets the cell at column 0, row 1 to `New` and saves the result as `table1_out.pptx`. The input must contain at least one slide, and the first table on that slide must have at least one column and two rows.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("UpdateExistingTable.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = None

    for shape in slide.getShapes():
        if isinstance(shape, Table):
            table = shape
            break

    if table is not None:
        table.get_Item(0, 1).getTextFrame().setText("New")
        presentation.save("table1_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

To resize a row in an existing table and understand why its actual height can exceed the requested minimum, see [Kiểm soát chiều cao hàng](/slides/vi/python-java/manage-rows-and-columns/#control-row-height).

## **Tìm ô sở hữu Text Frame**

When generic text-processing code receives a [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) from a table, use the [TextFrame.getParentCell](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentCell) method to retrieve the owning [Cell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/). For a table-cell text frame, [TextFrame.getParentCell](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentCell) returns the owner and [TextFrame.getParentShape](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentShape) returns `None`, even though the table itself is a shape.

The cell coordinates are available through the read-only [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex) and [Cell.getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) methods. [TextFrame.getParentCell](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentCell) also provides read-only navigation: it returns the owner but does not change ownership. Always check the returned cell for `None` before using it.

For a complete example that identifies table-cell and shape owners, including shapes associated with SmartArt nodes, see [Tìm kiếm và Thay thế Văn bản](/slides/vi/python-java/search-and-replace-text/).

## **Căn chỉnh văn bản trong bảng**

You can control the vertical anchoring and text direction of individual table cells. The example in this section centers text within the first cell and rotates it by 270 degrees.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class.
2. Get a reference to the slide by its index.
3. Add a [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) object to the slide.
4. Access a [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) object from the table.
5. Access the first [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) and set its text and color.
6. Set the cell's vertical anchoring and text direction using [setTextAnchorType](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setTextAnchorType) and [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setTextVerticalType).
7. Save the modified presentation.

This example creates a 4 × 4 table with column widths of 120 points and row heights of 100 points. It formats the text in cell (0, 0), adds values to the remaining cells in the first row, and saves the result as `Vertical_Align_Text_out.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, TextAnchorType, TextVerticalType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [120, 120, 120, 120]
    row_heights = [100, 100, 100, 100]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)
    
    table.get_Item(1, 0).getTextFrame().setText("10")
    table.get_Item(2, 0).getTextFrame().setText("20")
    table.get_Item(3, 0).getTextFrame().setText("30")

    text_frame = table.get_Item(0, 0).getTextFrame()
    paragraph = text_frame.getParagraphs().get_Item(0)

    portion = paragraph.getPortions().get_Item(0)
    portion.setText("Text here")
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    cell = table.get_Item(0, 0)
    cell.setTextAnchorType(TextAnchorType.Center)
    cell.setTextVerticalType(TextVerticalType.Vertical270)

    presentation.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Đặt định dạng văn bản ở mức bảng**

Use [setTextFormat](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setTextFormat) to apply text formatting to all cells in a table. Its overloads accept portion, paragraph, and text frame formatting, so you can set these properties without iterating through individual cells.

1. Load the presentation using the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class.
2. Get a reference to the slide by its index.
3. Access a [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) object from the slide.
4. Set the font size using [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) for the text.
5. Set paragraph alignment and the right margin using [setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) and [setMarginRight](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginRight).
6. Set the text direction using [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType).
7. Save the modified presentation.

The example below opens `table.pptx`, which must contain at least one slide with a table as its first shape. It sets the font size to 25 points, right-aligns paragraphs with a right margin of 20 points, and makes the text vertical. The formatted presentation is saved as `result.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ParagraphFormat, PortionFormat, Presentation, SaveFormat, TextAlignment, TextFrameFormat, TextVerticalType, Table

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    portion_format = PortionFormat()
    portion_format.setFontHeight(25)
    table.setTextFormat(portion_format)

    paragraph_format = ParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Right)
    paragraph_format.setMarginRight(20)
    table.setTextFormat(paragraph_format)

    text_frame_format = TextFrameFormat()
    text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
    table.setTextFormat(text_frame_format)
    presentation.save("result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Lấy thuộc tính kiểu bảng**

Use [getStylePreset](https://reference.aspose.com/slides/python-java/aspose.slides/table/#getStylePreset) to read a table's preset style and [setStylePreset](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setStylePreset) to assign it. This example applies [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/python-java/aspose.slides/tablestylepreset/) to one table, prints the preset value, and assigns the same preset to a second table. Both tables are saved in `table-style.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = slide.getShapes().addTable(10, 10, column_widths, row_heights)
    table.setStylePreset(TableStylePreset.DarkStyle1)

    style_preset = table.getStylePreset()
    print("Table style preset: ", style_preset)

    another_table = slide.getShapes().addTable(10, 100, column_widths, row_heights)
    another_table.setStylePreset(style_preset)

    presentation.save("table-style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Khóa tỷ lệ khung hình của bảng**

A table's aspect ratio is the ratio of its width to its height. Use [setAspectRatioLocked](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobjectlock/#setAspectRatioLocked) to lock this ratio for a table.

The example below opens `pres.pptx`, which must contain at least one slide with a table as its first shape. It prints the current lock state, enables the aspect ratio lock, prints the updated state (`True`), and saves the result as `pres-out.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("pres.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())

    table.getGraphicalObjectLock().setAspectRatioLocked(True)
    print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Tôi có thể bật hướng đọc từ phải sang trái (RTL) cho toàn bộ bảng và văn bản trong các ô không?**

Yes. The table exposes a [setRightToLeft](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setRightToLeft) method, and paragraphs have [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setRightToLeft). Using both ensures the correct RTL order and rendering inside cells.

**Làm thế nào để ngăn người dùng di chuyển hoặc thay đổi kích thước bảng trong tệp cuối cùng?**

Use [shape locks](/slides/vi/python-java/applying-protection-to-presentation/) to disable moving, resizing, selection, etc. These locks apply to tables as well.

**Có hỗ trợ chèn hình ảnh vào trong ô làm nền không?**

Yes. You can set a [picture fill](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/) for a cell; the image will cover the cell area according to the chosen mode (stretch or tile).