---
title: จัดการเซลล์ตารางในงานนำเสนอด้วย Python
linktitle: จัดการเซลล์
type: docs
weight: 30
url: /th/python-java/manage-cells/
keywords:
- เซลล์ตาราง
- ผสานเซลล์
- ลบขอบ
- แยกเซลล์
- รูปภาพในเซลล์
- สีพื้นหลัง
- PowerPoint
- งานนำเสนอ
- Python
- Aspose.Slides
description: "จัดการเซลล์ตาราง PowerPoint ด้วย Python: ระบุเซลล์ที่ผสาน, ลบขอบ, แยกเซลล์, และตั้งค่าสีพื้นหลังและรูปภาพด้วย Aspose.Slides สำหรับ Python ผ่าน Java."
---
## **ภาพรวม**

Aspose.Slides ให้คุณเข้าถึงและแก้ไขเซลล์ตารางในงานนำเสนอ PowerPoint บทความนี้อธิบายวิธีระบุเซลล์ตารางที่ผสาน, ลบขอบเซลล์, ทำงานกับการกำหนดหมายเลขเซลล์หลังจากการผสานหรือการแยกเซลล์, เปลี่ยนสีพื้นหลังของเซลล์, และเพิ่มรูปภาพภายในเซลล์ตาราง ตัวอย่างแสดงวิธีสร้างหรือเปิดงานนำเสนอ, ดึงตารางจากสไลด์, ปรับรูปแบบเซลล์ผ่านคุณสมบัติของเซลล์, และบันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

Aspose.Slides ใช้อินเด็กซ์เริ่มจากศูนย์ในการเข้าถึงเซลล์ตารางตามลำดับ `(column, row)`.

## **ระบุเซลล์ตารางที่ผสาน**

ตัวอย่างนี้เปิดงานนำเสนอที่มีอยู่และเข้าถึงรูปทรงแรกบนสไลด์แรกเป็นตาราง มันสมมติว่ามีสไลด์และรูปทรงอยู่และรูปทรงเป็นตาราง จากนั้นวนลูปผ่านแถวและคอลัมน์ทั้งหมดและใช้ [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) เพื่อระบุเซลล์ในพื้นที่ที่ผสาน สำหรับแต่ละผลการจับคู่ มันพิมพ์พิกัดเซลล์ในลำดับ `row;column`, [getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan), [getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan), และพิกัดเริ่มต้นของพื้นที่, [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) และ [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex).

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

## **ลบขอบเซลล์ตาราง**

สร้าง [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) และเพิ่มตารางไปยังสไลด์แรกด้วย [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable) ความกว้างของคอลัมน์, ความสูงของแถว, และตำแหน่งของตารางถูกกำหนดเป็นหน่วยจุด ตัวอย่างตั้งค่าขอบเซลล์สี่ด้านทั้งหมดเป็น [FillType.NoFill](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/), ทำให้มองไม่เห็น.

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

## **ผสานเซลล์ตาราง**

ใช้ [mergeCells](https://reference.aspose.com/slides/python-java/aspose.slides/table/#mergeCells) เพื่อรวมช่วงสี่เหลี่ยมของเซลล์ตารางให้เป็นเซลล์เดียว ระบุเซลล์ที่มุมซ้ายบนและมุมขวาล่างของช่วง อากิวเมนต์สุดท้ายควบคุมว่าการผสานอาจรวมถึงเซลล์นอกช่วงที่กำหนดหรือไม่; `False` ทำให้การผสานอยู่ภายในช่วงนั้น.

ตัวอย่างสร้างตาราง 4x4 ด้วยคอลัมน์และแถวขนาด 70 จุด แล้วผสานสี่เซลล์กึ่งกลางจาก `(1, 1)` ถึง `(2, 2)` เซลล์ที่ได้ครอบคลุมสองคอลัมน์และสองแถว ส่วนกริดฐานของตารางยังคงมีสี่คอลัมน์และสี่แถว เพื่อเข้าถึงเนื้อหา หรือรูปแบบของเซลล์ที่ผสาน ให้ใช้ตำแหน่งมุมซ้ายบน: `table.get_Item(1, 1)` ในตัวอย่างนี้ ตำแหน่งอื่นในช่วงที่ผสานยังคงเป็นส่วนหนึ่งของกริดตาราง ดังนั้นดัชนีของเซลล์นอกช่วงจะไม่เปลี่ยนแปลง.

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

การผสานเซลล์ในตัวอย่างก่อนหน้ารักษาโครงสร้างกริดของตาราง การแยกเซลล์อาจทำให้เกิดคอลัมน์กริดใหม่และเปลี่ยนดัชนีคอลัมน์ของเซลล์ทางขวา Aspose.Slides ปฏิบัติตามโมเดลกริดของตารางใน PowerPoint.

ตัวอย่างนี้สร้างตาราง 4x4 ด้วยคอลัมน์และแถวขนาด 70 จุดและเรียกใช้ [splitByWidth](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByWidth) บนเซลล์ `(1, 1)` ครึ่งหนึ่งของความกว้าง 70 จุดของเซลล์จะถูกส่งเพื่อสร้างเซลล์สองเซลล์ที่มีความกว้างเท่ากัน.

หลังจากการแยกนี้ ครึ่งสองส่วนจะเข้าถึงได้โดยใช้ `table.get_Item(1, 1)` และ `table.get_Item(2, 1)` ตารางกริดตอนนี้มีห้าคอลัมน์: เซลล์ที่อยู่เดิมในคอลัมน์ 2 และ 3 จะย้ายไปที่คอลัมน์ 3 และ 4 ตามลำดับ ดัชนีแถวคงเหมือนเดิม ใช้ดัชนีคอลัมน์ที่อัปเดตนี้เมื่อเข้าถึงเซลล์หลังจากการแยก.

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

### **แยกเซลล์ที่ผสานตามช่วงแถวหรือคอลัมน์**

เพื่อเตรียมเซลล์แม่แบบที่ผสานสำหรับการป้อนข้อมูล ใช้ [splitByRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByRowSpan) เพื่อแยกตามเส้นขอบแถวที่มีอยู่ หรือใช้ [splitByColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByColSpan) เพื่อแยกตามเส้นขอบคอลัมน์.

อากิวเมนต์ `index` จะนับแถวในส่วนบนหรือคอลัมน์ในส่วนซ้ายของการแยก; มันอ้างอิงต่อพื้นที่ที่ผสาน:
- การแยกแถว: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan).
- การแยกคอลัมน์: `0 < index <` [getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan).

ตัวอย่างคาดว่าการนำเสนอมีตารางเป็นรูปทรงแรกบนสไลด์แรก โดยมีเซลล์ `(1, 2)` และ `(1, 3)` ผสานแนวตั้ง เริ่มจากตำแหน่งด้านล่าง มันใช้ [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex) และ [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) เพื่อหาตำแหน่งเริ่มต้นและตรวจสอบทั้งสองช่วง `splitByRowSpan(1)` จากนั้นจะแยกแถว 2 และ 3 สำหรับชื่อสินค้า สำหรับการผสานแนวนอนสองคอลัมน์ ให้ใช้ `splitByColSpan(1)` แทน.

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

        # ดึงเซลล์ผลลัพธ์จากตารางหลังจากการแยก.
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

กริดของตารางและดัชนีเซลล์โดยรอบคงเดิม ดึงเซลล์ที่ได้โดยใช้พิกัดของมัน; ที่นี่ทั้งสองมีช่วงเป็น 1 และ [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) จะพิมพ์ `False`. พื้นที่ที่ใหญ่กว่าสามารถคงอยู่เป็นการผสานบางส่วนหลังจากการแยกหนึ่งครั้ง.

ข้อความต้นฉบับและรูปแบบของมันคงอยู่ในเซลล์บน (หรือซ้าย); เซลล์ใหม่จะว่างเปล่าแต่สืบทอดรูปแบบเซลล์เช่น การเติม, ขอบ, และระยะขอบ. เติมข้อมูลในเซลล์หลังจากการแยกและตั้งค่าการจัดรูปแบบข้อความที่ต้องการอย่างชัดเจน.

การบันทึกงานนำเสนอจะมีเซลล์แยก "Product A" และ "Product B" พร้อมรูปแบบเซลล์จากแม่แบบที่คงไว้ ดูที่ [Cell API Reference](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) สำหรับรายละเอียด.

## **เปลี่ยนสีพื้นหลังของเซลล์ตาราง**

ตัวอย่างนี้สร้างตารางที่มีคอลัมน์ขนาด 150 จุดและแถวขนาด 50 จุด ใช้ [setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) เพื่อเลือกการเติมแบบทึบและตั้งค่าสีที่ได้จาก [getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor) เป็นสีแดงสำหรับเซลล์ `(2, 3)` ซึ่งอยู่ในคอลัมน์ที่สามและแถวที่สี่.

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

## **เพิ่มรูปภาพภายในเซลล์ตาราง**

วางรูปภาพต้นทางในไดเรกทอรีการทำงานก่อนรันตัวอย่างนี้ มันโหลดรูปภาพด้วย [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile) และเพิ่มลงในคอล렉ชันรูปภาพของงานนำเสนอด้วย [addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage) จากนั้นกำหนดรูปภาพให้กับการเติมภาพของเซลล์ `(0, 0)` ซึ่งเป็นเซลล์แรกในตาราง.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/) ยืดรูปภาพเพื่อเติมเซลล์ ซึ่งอาจทำให้สัดส่วนเปลี่ยนแปลง ความกว้างของคอลัมน์และความสูงของแถวเป็นหน่วยจุด รูปภาพที่โหลดจะถูกทำลายในบล็อก `finally` หลังจากที่เพิ่มลงในงานนำเสนอ.

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

**ฉันสามารถกำหนดความหนาและสไตล์ของเส้นที่แตกต่างกันสำหรับแต่ละด้านของเซลล์เดียวได้หรือไม่?**

ใช่. ขอบ [top](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderTop)/[bottom](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderBottom)/[left](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderLeft)/[right](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderRight) มีคุณสมบัติเสียแยกกัน ดังนั้นความหนาและสไตล์ของแต่ละด้านจึงสามารถแตกต่างกันได้.

**ภาพจะเกิดอะไรขึ้นหากฉันเปลี่ยนขนาดคอลัมน์/แถวหลังจากตั้งรูปภาพเป็นพื้นหลังของเซลล์?**

พฤติกรรมขึ้นอยู่กับ [fill mode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/) (stretch/tile) หากยืดรูปภาพจะปรับให้เข้ากับเซลล์ใหม่; หากเป็นการทำเป็นกระเบื้อง (tile) กระเบื้องจะถูกคำนวนใหม่.

**ฉันสามารถกำหนดไฮเปอร์ลิงก์ให้กับเนื้อหาทั้งหมดของเซลล์ได้หรือไม่?**

[Hyperlinks](/slides/th/python-java/manage-hyperlinks/) ถูกตั้งค่าที่ระดับข้อความ (portion) ภายในกรอบข้อความของเซลล์หรือที่ระดับของตาราง/รูปร่างทั้งหมด ในทางปฏิบัติ คุณกำหนดลิงก์ให้กับส่วนหนึ่งหรือกับข้อความทั้งหมดในเซลล์.

**ฉันสามารถกำหนดฟอนต์ที่แตกต่างกันภายในเซลล์เดียวได้หรือไม่?**

ใช่. กรอบข้อความของเซลล์รองรับ [portions](https://reference.aspose.com/slides/python-java/aspose.slides/portion/) (run) ที่มีการจัดรูปแบบอิสระ—ครอบครัวฟอนต์, สไตล์, ขนาด, และสี.