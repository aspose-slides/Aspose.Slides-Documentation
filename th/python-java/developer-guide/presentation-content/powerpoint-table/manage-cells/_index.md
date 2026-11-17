---
title: จัดการเซลล์ตารางในงานนำเสนอด้วย Python
linktitle: จัดการเซลล์
type: docs
weight: 30
url: /th/python-java/manage-cells/
keywords:
- เซลล์ตาราง
- รวมเซลล์
- ลบขอบ
- แยกเซลล์
- รูปภาพในเซลล์
- สีพื้นหลัง
- PowerPoint
- การนำเสนอ
- Python
- Aspose.Slides
description: "จัดการเซลล์ตาราง PowerPoint ใน Python: ระบุเซลล์ที่รวมกัน, ลบขอบ, แยกเซลล์, และตั้งค่าสีพื้นหลังและรูปภาพด้วย Aspose.Slides สำหรับ Python ผ่าน Java."
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณเข้าถึงและแก้ไขเซลล์ตารางในงานนำเสนอ PowerPoint ได้ บทความนี้อธิบายวิธีระบุเซลล์ตารางที่รวมกัน, ลบเส้นขอบเซลล์, ทำงานกับการจัดหมายเลขเซลล์หลังจากการรวมหรือแยกเซลล์, เปลี่ยนสีพื้นหลังของเซลล์, และเพิ่มรูปภาพภายในเซลล์ตาราง ตัวอย่างแสดงวิธีสร้างหรือเปิดงานนำเสนอ, ดึงตารางจากสไลด์, ปรับการจัดรูปแบบเซลล์ผ่านคุณสมบัติของเซลล์, และบันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX  
Aspose.Slides ใช้ดัชนีเริ่มจากศูนย์เพื่อเข้าถึงเซลล์ตารางตามลำดับ `(column, row)`.

## **ระบุเซลล์ตารางที่รวมกัน**

ตัวอย่างเปิดการนำเสนอที่มีอยู่และเข้าถึงรูปร่างแรกบนสไลด์แรกในฐานะตาราง มันสมมติว่ามีสไลด์และรูปร่างอยู่และรูปร่างเป็นตาราง จากนั้นวนลูปผ่านแถวและคอลัมน์ทั้งหมดและใช้ [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) เพื่อระบุเซลล์ในเขตที่รวมกัน สำหรับแต่ละการจับคู่ มันพิมพ์พิกัดของเซลล์ในลำดับ `row;column`, [getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan), [getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan) และพิกัดเริ่มต้นของเขต, [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) และ [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex).

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

## **ลบเส้นขอบเซลล์ตาราง**

Create a [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) and add a table to its first slide with [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable). Column widths, row heights, and the table position are specified in points. The example sets all four cell borders to [FillType.NoFill](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/), making them invisible.

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

## **เพิ่มเส้นขอบเซลล์แบบทแยง**

Use [getBorderDiagonalDown](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderDiagonalDown) to draw a line from the top-left corner to the bottom-right, and [getBorderDiagonalUp](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderDiagonalUp) to draw a line from the bottom-left corner to the top-right. A diagonal can mark a corner header. Both diagonals can form an X to mark a cell as not applicable.  

Each diagonal is an [LineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/). In its [getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getFillFormat), use [setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) to select [FillType.Solid](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) and choose a color through [getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor). Set the line's width in points with [setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setWidth).  

The example creates three cells in one row: a red downward diagonal, a blue upward diagonal, and both diagonals. It leaves the top, bottom, left, and right cell borders unchanged.

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

A diagonal is a formatting property, not a cell split. Each cell retains a single text frame, accessed through [getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getTextFrame). The regions on either side of a diagonal cannot be edited independently.

The saved table, rendered in Microsoft PowerPoint:

![เซลล์ตารางสามเซลล์ที่แสดงเส้นทแยงสีแดงจากมุมบนซ้ายไปมุมล่างขวา, เส้นทแยงสีน้ำเงินจากมุมล่างซ้ายไปมุมบนขวา, และเส้นทแยงทั้งสองสร้างรูป X.](diagonal-cell-borders.png)

*จากซ้ายไปขวา: เส้นทแยงลง (สีแดง, 3 pt), เส้นทแยงขึ้น (สีน้ำเงิน, 5 pt) และเส้นทแยงทั้งสอง*

## **รวมเซลล์ตาราง**

Use [mergeCells](https://reference.aspose.com/slides/python-java/aspose.slides/table/#mergeCells) to combine a rectangular range of table cells into one cell. Specify the cells at the top-left and bottom-right corners of the range. The final argument controls whether the merge may include cells outside the specified range; `False` keeps the merge within that range.  

The example creates a 4-by-4 table with 70-point columns and rows, then merges the four central cells from `(1, 1)` through `(2, 2)`. The resulting cell spans two columns and two rows, while the table's underlying grid retains four columns and four rows. To access the merged cell's content or formatting, use its top-left position: `table.get_Item(1, 1)` in this example. The other positions in the merged range remain part of the table grid, so the indices of cells outside the range do not change.

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

## **แยกเซลล์ตาราง**

Merging cells in the previous example preserves the table's grid. Splitting a cell can introduce a new grid column and change the column indices of cells to its right. Aspose.Slides follows PowerPoint's table grid model.  

This example creates a 4-by-4 table with 70-point columns and rows and calls [splitByWidth](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByWidth) on cell `(1, 1)`. Half of the cell's 70-point width is passed to create two equal-width cells.  

After this split, the two halves are accessed as `table.get_Item(1, 1)` and `table.get_Item(2, 1)`. The table grid now has five columns: cells originally in columns 2 and 3 move to columns 3 and 4, respectively. Row indices remain unchanged. Use these updated column indices when accessing cells after the split.

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
[![เซลล์ขนาด 70 จุดที่ไม่ได้รวมจะแบ่งเป็นสองเซลล์ขนาด 35 จุด, เพิ่มคอลัมน์กริดเป็นคอลัมน์ที่ห้าและเลื่อนดัชนีทางขวา.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*การแยกความกว้างส่งผลต่อเซลล์ (1, 1) โดยใช้ดัชนีเริ่มจากศูนย์ (คอลัมน์, แถว) แถวอื่นคงเซลล์ที่ครอบคลุมตำแหน่งคอลัมน์ใหม่ทั้งสอง*
<!-- visual-explanation:manage-cells:end -->

### **แยกเซลล์ที่รวมโดยการแยกแถวหรือคอลัมน์**

To prepare merged template cells for data population, use [splitByRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByRowSpan) to split along an existing row boundary, or [splitByColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByColSpan) to split along a column boundary.  

The `index` argument counts rows in the upper part or columns in the left part of the split; it is relative to the merged region:  

- การแยกแถว: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan).  
- การแยกคอลัมน์: `0 < index <` [getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan).  

The example expects a presentation to have a table as the first shape on the first slide, with `(1, 2)` and `(1, 3)` merged vertically. Starting from the lower position, it uses [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex) and [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) to locate the origin and checks both spans. `splitByRowSpan(1)` then separates rows 2 and 3 for product names. For a horizontal two-column merge, use `splitByColSpan(1)` instead.

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

        # ดึงเซลล์ที่ได้จากตารางหลังจากการแยก.
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

The table grid and surrounding cell indices stay unchanged. Retrieve the resulting cells by their coordinates; here, both have spans of 1 and [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) prints `False`. Larger regions can remain partly merged after one split.  

The original text and its formatting remain in the upper (or left) cell; the new cell is empty but inherits cell formatting such as fill, borders, and margins. Populate the cells after splitting and set any required text formatting explicitly.  

The saved presentation contains separate "Product A" and "Product B" cells with the template's cell formatting retained. See the [อ้างอิง Cell API](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) for details.

### **แยกเซลล์ตามความสูงที่กำหนด**

[splitByHeight](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByHeight) takes the height of the upper part in points. [splitByRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByRowSpan) takes the number of existing grid rows in the upper part. To center a 40-point cell in the right column, subtract 40 from the cell’s actual height and divide the remaining space equally above and below it.

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

The first split adds a grid row and leaves the lower 90 points in cell `(1, 1)`. The second split divides that cell into a 40-point middle cell and a 50-point bottom cell. The right column now has three cells with heights of 50, 40, and 50 points from top to bottom. The left cell spans all three rows and retains its original height of 140 points.

![เซลล์ด้านซ้ายครอบความสูงเต็มของตารางโดยอยู่ข้างสามเซลล์ที่มีข้อความ 'Middle' อยู่ตรงกลาง.](split-by-height.png)

## **เปลี่ยนสีพื้นหลังของเซลล์ตาราง**

This example creates a table with 150-point columns and 50-point rows. It uses [setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) to select a solid fill and sets the color returned by [getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor) to red for cell `(2, 3)`, in the third column and fourth row.

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

## **เพิ่มภาพภายในเซลล์ตาราง**

Place the input image in the working directory before running this example. It loads the image with [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile) and adds it to the presentation's image collection with [addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage). It then assigns the image to the picture fill of cell `(0, 0)`, the first cell in the table.  

[PictureFillMode.Stretch](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/) stretches the image to fill the cell, which may change its aspect ratio. Column widths and row heights are in points. The loaded image is disposed in a `finally` block after it is added to the presentation.

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

## **คำถามที่พบบ่อย**

**Can I set different line thicknesses and styles for different sides of a single cell?**

Yes. The [top](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderTop)/[bottom](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderBottom)/[left](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderLeft)/[right](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderRight) borders have separate properties, so the thickness and style of each side can differ.

**What happens to the image if I change the column/row size after setting a picture as the cell’s background?**

The behavior depends on the [fill mode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/). หากใช้การขยาย (stretch) ภาพจะปรับให้พอดีกับเซลล์ใหม่; หากใช้การซ้อน (tile) ไทล์จะถูกคำนวนใหม่.

**Can I assign a hyperlink to all the content of a cell?**

[ไฮเปอร์ลิงก์](/slides/th/python-java/manage-hyperlinks/) ถูกตั้งค่าที่ระดับข้อความ (portion) ภายในกรอบข้อความของเซลล์หรือที่ระดับของทั้งตาราง/รูปร่าง ในการปฏิบัติ คุณจะกำหนดลิงก์ให้กับส่วนหรือกับข้อความทั้งหมดในเซลล์.

**Can I set different fonts within a single cell?**

Yes. A cell’s text frame supports [portions](https://reference.aspose.com/slides/python-java/aspose.slides/portion/) (runs) ที่มีการจัดรูปแบบอิสระ เช่น แบบอักษร, สไตล์, ขนาด, และสี.