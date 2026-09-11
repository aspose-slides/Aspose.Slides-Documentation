---
title: จัดการเซลล์ตารางในงานนำเสนอโดยใช้ Python
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
- งานนำเสนอ
- Python
- Aspose.Slides
description: "จัดการเซลล์ตารางใน PowerPoint อย่างง่ายดายด้วย Aspose.Slides สำหรับ Python ผ่าน Java. เชี่ยวชาญการเข้าถึง, แก้ไข, และจัดรูปแบบเซลล์อย่างรวดเร็วเพื่อการอัตโนมัติของสไลด์อย่างราบรื่น."
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณสามารถเข้าถึงและแก้ไขเซลล์ของตารางในงานนำเสนอ PowerPoint ได้ บทความนี้อธิบายวิธีการระบุเซลล์ตารางที่รวมกัน, ลบขอบเซลล์, ทำงานกับการจัดเลขลำดับของเซลล์หลังจากการรวมหรือแยกเซลล์, เปลี่ยนสีพื้นหลังของเซลล์, และเพิ่มรูปภาพภายในเซลล์ของตาราง ตัวอย่างจะแสดงวิธีสร้างหรือเปิดงานนำเสนอ, รับตารางจากสไลด์, ปรับรูปแบบเซลล์ผ่านคุณสมบัติของเซลล์, และบันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

## **ระบุเซลล์ตารางที่รวมกัน**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) 
2. ดึงตารางจากสไลด์แรก
3. วนซ้ำแถวและคอลัมน์ของตารางเพื่อค้นหาเซลล์ที่รวมกัน
4. พิมพ์ข้อความเมื่อพบเซลล์ที่รวมกัน

โค้ด Python นี้แสดงวิธีระบุเซลล์ตารางที่รวมกันในงานนำเสนอ:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Table

presentation = Presentation("SomePresentationWithTable.pptx")
try:
    # สมมติว่า shape แรกบนสไลด์แรกเป็นตาราง.
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

## **ลบขอบเซลล์ของตาราง**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) 
2. ดึงอ้างอิงสไลด์ตามดัชนี
3. กำหนดรายการความกว้างของคอลัมน์
4. กำหนดรายการความสูงของแถว
5. เพิ่มตารางลงในสไลด์โดยใช้เมธอด [addTable](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapecollection/#addTable) 
6. วนซ้ำทุกเซลล์เพื่อลบขอบบน, ล่าง, ขวา, และซ้าย
7. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

โค้ด Python นี้แสดงวิธีลบขอบจากเซลล์ตาราง:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat

presentation = Presentation()
try:
    # เข้าถึงสไลด์แรก.
    slide = presentation.getSlides().get_Item(0)

    # กำหนดความกว้างของคอลัมน์และความสูงของแถว.
    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # เพิ่มตารางลงในสไลด์.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # ตั้งค่ารูปแบบขอบสำหรับแต่ละเซลล์.
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill)

    # บันทึกงานนำเสนอเป็นไฟล์ PPTX.
    presentation.save("table_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **การจัดเลขลำดับในเซลล์ที่รวมกัน**

หากเรารวมเซลล์สองคู่ คือ (1, 1) กับ (2, 1) และ (1, 2) กับ (2, 2) ตารางที่ได้จะยังคงรักษาการจัดเลขลำดับของเซลล์ไว้ โค้ด Python นี้สาธิตขั้นตอนดังกล่าว:

```python
import jpype
import asposeslides

if not jpase.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # เข้าถึงสไลด์แรก.
    slide = presentation.getSlides().get_Item(0)

    # กำหนดความกว้างของคอลัมน์และความสูงของแถว.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # เพิ่มตารางลงในสไลด์.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # ตั้งค่ารูปแบบขอบสำหรับแต่ละเซลล์.
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


    # รวมเซลล์ (1, 1) และ (2, 1).
    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 1), False)

    # รวมเซลล์ (1, 2) และ (2, 2).
    table.mergeCells(table.get_Item(1, 2), table.get_Item(2, 2), False)

    # บันทึกงานนำเสนอเป็นไฟล์ PPTX.
    presentation.save("MergeCells_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

จากนั้นเราจะรวมเซลล์ต่อไปโดยรวม (1, 1) กับ (1, 2) ผลลัพธ์คือ ตารางที่มีเซลล์ใหญ่ที่รวมกันอยู่ตรงกลาง:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # เข้าถึงสไลด์แรก.
    slide = presentation.getSlides().get_Item(0)

    # กำหนดความกว้างของคอลัมน์และความสูงของแถว.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # เพิ่มตารางลงในสไลด์.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # ตั้งค่ารูปแบบขอบสำหรับแต่ละเซลล์.
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


    # รวมเซลล์ (1, 1) และ (2, 1).
    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 1), False)

    # รวมเซลล์ (1, 2) และ (2, 2).
    table.mergeCells(table.get_Item(1, 2), table.get_Item(2, 2), False)

    # รวมเซลล์ (1, 1) และ (1, 2).
    table.mergeCells(table.get_Item(1, 1), table.get_Item(1, 2), True)

    # บันทึกงานนำเสนอเป็นไฟล์ PPTX.
    presentation.save("MergeCells_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **การจัดเลขลำดับในเซลล์ที่แยก**

ในตัวอย่างก่อนหน้า การรวมเซลล์ตารางไม่ได้เปลี่ยนการจัดเลขลำดับของเซลล์อื่น ๆ

ครั้งนี้ เราจะใช้ตารางปกติ (ตารางที่ไม่มีเซลล์รวม) แล้วลองแยกเซลล์ (1, 1) เพื่อให้ได้ตารางพิเศษ คุณอาจต้องใส่ใจการจัดเลขลำดับของตารางนี้ซึ่งอาจดูแปลก แต่เป็นวิธีที่ Microsoft PowerPoint จัดเลขลำดับเซลล์ตารางและ Aspose.Slides ทำเช่นเดียวกัน

โค้ด Python นี้แสดงกระบวนการที่อธิบายไว้:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # เข้าถึงสไลด์แรก.
    slide = presentation.getSlides().get_Item(0)

    # กำหนดความกว้างของคอลัมน์และความสูงของแถว.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # เพิ่มตารางลงในสไลด์.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # ตั้งค่ารูปแบบขอบสำหรับแต่ละเซลล์.
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


    # แบ่งเซลล์ (1, 1).
    table.get_Item(1, 1).splitByWidth(table.get_Item(2, 1).getWidth() / 2)

    # บันทึกงานนำเสนอเป็นไฟล์ PPTX.
    presentation.save("SplitCells_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **เปลี่ยนสีพื้นหลังของเซลล์ตาราง**

โค้ด Python นี้แสดงวิธีเปลี่ยนสีพื้นหลังของเซลล์ตาราง:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # เข้าถึงสไลด์แรก.
    slide = presentation.getSlides().get_Item(0)

    # กำหนดความกว้างของคอลัมน์และความสูงของแถว.
    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]

    # เพิ่มตารางลงในสไลด์.
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    # ตั้งค่าสีพื้นหลังให้กับเซลล์.
    cell = table.get_Item(2, 3)
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid)
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    # บันทึกงานนำเสนอเป็นไฟล์ PPTX.
    presentation.save("cell_background_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **เพิ่มรูปภาพภายในเซลล์ตาราง**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) 
2. ดึงอ้างอิงสไลด์ตามดัชนี
3. กำหนดรายการความกว้างของคอลัมน์
4. กำหนดรายการความสูงของแถว
5. เพิ่มตารางลงในสไลด์โดยใช้เมธอด [addTable](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapecollection/#addTable) 
6. โหลดไฟล์รูปภาพด้วยเมธอด [Images.fromFile](https://reference.aspose.com/slides/th/python-java/aspose.slides/images/#fromFile) 
7. เพิ่มรูปภาพลงในงานนำเสนอเพื่อสร้างอ็อบเจกต์ [PPImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/ppimage/) 
8. ตั้งค่า FillFormat ของเซลล์ตารางให้เป็น [FillType.Picture](https://reference.aspose.com/slides/th/python-java/aspose.slides/filltype/#Picture) 
9. เพิ่มรูปภาพลงในเซลล์แรกของตาราง
10. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

โค้ด Python นี้แสดงวิธีวางรูปภาพภายในเซลล์ตารางเมื่อสร้างตาราง:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Images, FillType, PictureFillMode, SaveFormat

presentation = Presentation()
try:
    # เข้าถึงสไลด์แรก.
    slide = presentation.getSlides().get_Item(0)

    # กำหนดความกว้างของคอลัมน์และความสูงของแถว.
    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100, 90]

    # เพิ่มตารางลงในสไลด์.
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    # สร้างภาพงานนำเสนอจากไฟล์ภาพ.
    image = Images.fromFile("image.jpg")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    # เพิ่มภาพลงในเซลล์แรกของตาราง.
    cell_format = table.get_Item(0, 0).getCellFormat()
    cell_format.getFillFormat().setFillType(FillType.Picture)
    cell_format.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
    cell_format.getFillFormat().getPictureFillFormat().getPicture().setImage(picture)

    # บันทึกงานนำเสนอเป็นไฟล์ PPTX.
    presentation.save("Image_In_TableCell_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**ฉันสามารถกำหนดความหนาและสไตล์ของเส้นขอบแยกต่างหากสำหรับแต่ละด้านของเซลล์เดียวได้หรือไม่?**

ได้. ขอบ [top](https://reference.aspose.com/slides/th/python-java/aspose.slides/cellformat/#getBorderTop)/[bottom](https://reference.aspose.com/slides/th/python-java/aspose.slides/cellformat/#getBorderBottom)/[left](https://reference.aspose.com/slides/th/python-java/aspose.slides/cellformat/#getBorderLeft)/[right](https://reference.aspose.com/slides/th/python-java/aspose.slides/cellformat/#getBorderRight) มีคุณสมบัติเสริมแยกกัน ทำให้ความหนาและสไตล์ของแต่ละด้านสามารถแตกต่างกันได้ ซึ่งสอดคล้องกับการควบคุมขอบแยกด้านของเซลล์ที่แสดงในบทความ

**ถ้าฉันเปลี่ยนขนาดคอลัมน์/แถวหลังจากตั้งรูปภาพเป็นพื้นหลังของเซลล์ จะเกิดอะไรขึ้นกับรูปภาพ?**

พฤติกรรมขึ้นกับ [fill mode](https://reference.aspose.com/slides/th/python-java/aspose.slides/picturefillmode/) (stretch/tile) หากเป็นการยืดรูปภาพจะปรับให้ตรงกับเซลล์ใหม่; หากเป็นแบบ tile รูปภาพจะถูกคำนวณใหม่ตามขนาดใหม่ บทความได้อธิบายโหมดการแสดงผลรูปภาพในเซลล์

**ฉันสามารถกำหนดไฮเปอร์ลิงก์ให้กับเนื้อหาทั้งหมดของเซลล์ได้หรือไม่?**

[Hyperlinks](/slides/th/python-java/manage-hyperlinks/) สามารถตั้งที่ระดับส่วนข้อความ (portion) ภายในกรอบข้อความของเซลล์ หรือที่ระดับตาราง/รูปร่างทั้งหมด ในทางปฏิบัติ คุณจะกำหนดลิงก์ให้กับส่วนหนึ่งหรือกับข้อความทั้งหมดในเซลล์

**ฉันสามารถกำหนดฟอนท์ที่แตกต่างกันภายในเซลล์เดียวได้หรือไม่?**

ได้. กรอบข้อความของเซลล์สนับสนุน [portions](https://reference.aspose.com/slides/th/python-java/aspose.slides/portion/) (run) ที่มีการจัดรูปแบบอิสระ ได้แก่ แบบอักษร, สไตล์, ขนาดและสี.