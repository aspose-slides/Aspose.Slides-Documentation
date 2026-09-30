---
title: จัดการตารางการนำเสนอใน Python
linktitle: จัดการตาราง
type: docs
weight: 10
url: /th/python-java/manage-table/
keywords:
- เพิ่มตาราง
- สร้างตาราง
- เข้าถึงตาราง
- อัตราส่วนรูปภาพ
- จัดตำแหน่งข้อความ
- การจัดรูปแบบข้อความ
- สไตล์ตาราง
- PowerPoint
- การนำเสนอ
- Python
- Aspose.Slides
description: "สร้างและแก้ไขตารางในสไลด์ PowerPoint ด้วย Aspose.Slides สำหรับ Python ผ่าน Java. ค้นหาตัวอย่างโค้ดง่ายๆ เพื่อทำให้กระบวนการทำงานกับตารางของคุณเป็นระเบียบมากขึ้น."
---
## **บทนำ**

ตารางใน PowerPoint จัดระเบียบข้อมูลเป็นแถวและคอลัมน์ ทำให้อ่านและเปรียบเทียบค่าต่างๆ ได้ง่ายขึ้น

Aspose.Slides มีคลาส [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) และ [Cell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) รวมถึงประเภทอื่นๆ ที่ให้คุณสร้าง, ปรับปรุง, และจัดการตารางในงานนำเสนอ

## **สร้างตารางตั้งแต่ต้น**

สร้างตารางโดยระบุตำแหน่ง, ความกว้างของคอลัมน์, และความสูงของแถว หลังจากเพิ่มลงในสไลด์แล้ว คุณสามารถจัดรูปแบบเส้นขอบของเซลล์, ผสานเซลล์, และแทรกข้อความได้

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) 
2. รับอ้างอิงถึงสไลด์ตามดัชนีของมัน
3. กำหนดรายการความกว้างของคอลัมน์เป็นจุด
4. กำหนดรายการความสูงของแถวเป็นจุด
5. เพิ่มอ็อบเจ็กต์ [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) ลงในสไลด์โดยใช้เมธอด [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable) 
6. วนผ่านแต่ละ [Cell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) เพื่อใช้การจัดรูปแบบกับเส้นขอบด้านบน, ด้านล่าง, ด้านขวา และด้านซ้าย
7. ผสานสองเซลล์แรกของแถวแรกของตาราง
8. เข้าถึงเซลล์ที่ผสานแล้วผ่านเมธอด [getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getTextFrame) 
9. ตั้งค่าข้อความในเซลล์ที่ผสาน
10. บันทึกงานนำเสนอที่แก้ไขแล้ว

ตัวอย่างด้านล่างสร้างตารางที่มีสามคอลัมน์และห้าแถวที่ตำแหน่ง (100, 50) จุด มันใช้เส้นขอบสีแดงความกว้าง 5 จุด, ผสานสองเซลล์แรกในแถวแรก, และบันทึกผลลัพธ์เป็น `table.pptx`

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

## **การนับลำดับในตารางมาตรฐาน**

ในตารางมาตรฐาน ดัชนีเซลล์เริ่มจากศูนย์และใช้ลำดับ (คอลัมน์, แถว) เซลล์แรกมีดัชนีเป็น (0, 0)

ตัวอย่างเช่น เซลล์ในตารางที่มี 4 คอลัมน์และ 4 แถวถูกจัดหมายเลขดังนี้:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

ตัวอย่างนี้สร้างตาราง 4 × 4 ตามที่แสดงด้านบน โดยมีความกว้างของคอลัมน์และความสูงของแถวเป็น 70 จุดและเส้นขอบเซลล์สีแดงความกว้าง 5 จุด พิกัดจะแสดงดัชนีเซลล์; ตัวอย่างจะปล่อยให้เซลล์ว่างไว้และบันทึกตารางเป็น `StandardTables_out.pptx`

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

## **เข้าถึงตารางที่มีอยู่แล้ว**

ตารางจะถูกจัดเก็บในคอลเลกชันรูปแบบของสไลด์ ให้วนผ่านรูปแบบต่างๆ เพื่อค้นหาตาราง แล้วใช้คลาส [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) เพื่ออ่านหรืออัปเดตเซลล์ของมัน

1. โหลดงานนำเสนอโดยใช้คลาส [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) 
2. รับอ้างอิงถึงสไลด์ที่มีตารางตามดัชนีของมัน
3. วนผ่านอ็อบเจ็กต์ [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) และหยุดเมื่อพบตาราง หากสไลด์มีหลายตาราง ให้ใช้ [getAlternativeText](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getAlternativeText) เพื่อระบุตารางที่ต้องการ
4. อัปเดตข้อความในเซลล์เป้าหมาย
5. บันทึกงานนำเสนอที่แก้ไขแล้ว

ตัวอย่างด้านล่างเปิดไฟล์ `UpdateExistingTable.pptx` และค้นหาตารางแรกในสไลด์แรก มันตั้งค่าเซลล์ที่คอลัมน์ 0, แถว 1 เป็น `New` และบันทึกผลลัพธ์เป็น `table1_out.pptx` อินพุตต้องมีอย่างน้อยหนึ่งสไลด์ และตารางแรกในสไลด์นั้นต้องมีอย่างน้อยหนึ่งคอลัมน์และสองแถว

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

เพื่อปรับขนาดแถวในตารางที่มีอยู่และเข้าใจว่าทำไมความสูงจริงจึงอาจเกินค่าต่ำสุดที่ร้องขอ, ดูที่ [Control Row Height](/slides/th/python-java/manage-rows-and-columns/#control-row-height)

## **ค้นหาเซลล์ที่เป็นเจ้าของ Text Frame**

เมื่อโค้ดการประมวลผลข้อความทั่วไปได้รับอ็อบเจ็กต์ [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) จากตาราง ให้ใช้เมธอด [TextFrame.getParentCell](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentCell) เพื่อดึง [Cell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) ที่เป็นเจ้าของ สำหรับ TextFrame ของเซลล์ตาราง, [TextFrame.getParentCell](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentCell) จะคืนค่าเจ้าของและ [TextFrame.getParentShape](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentShape) จะคืนค่า `None` แม้ว่าตารางเองจะเป็นรูปแบบก็ตาม

พิกัดเซลล์สามารถเข้าถึงได้ผ่านเมธอดอ่านอย่างเดียว [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex) และ [Cell.getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex)  [TextFrame.getParentCell](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentCell) ยังให้การนำทางแบบอ่านอย่างเดียว: มันคืนค่าเจ้าของแต่ไม่เปลี่ยนแปลงความเป็นเจ้าของ ตรวจสอบว่าเซลล์ที่คืนค่ามาไม่ใช่ `None` ก่อนนำไปใช้เสมอ

สำหรับตัวอย่างครบที่ระบุเจ้าของเซลล์ตารางและรูปแบบรวมถึงรูปแบบที่เชื่อมกับโหนด SmartArt, ดูที่ [Search and Replace Text](/slides/th/python-java/search-and-replace-text/)

## **จัดตำแหน่งข้อความในตาราง**

คุณสามารถควบคุมการยึดแนวตั้งและทิศทางข้อความของแต่ละเซลล์ได้ ตัวอย่างในส่วนนี้จะจัดกึ่งกลางข้อความในเซลล์แรกและหมุนข้อความ 270 องศา

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) 
2. รับอ้างอิงถึงสไลด์ตามดัชนีของมัน
3. เพิ่มอ็อบเจ็กต์ [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) ลงในสไลด์
4. เข้าถึงอ็อบเจ็กต์ [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) จากตาราง
5. เข้าถึง [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) แรกและตั้งค่าข้อความและสีของมัน
6. ตั้งค่าการยึดแนวตั้งของเซลล์และทิศทางข้อความโดยใช้ [setTextAnchorType](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setTextAnchorType) และ [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setTextVerticalType) 
7. บันทึกงานนำเสนอที่แก้ไขแล้ว

ตัวอย่างนี้สร้างตาราง 4 × 4 ที่มีความกว้างของคอลัมน์ 120 จุด และความสูงของแถว 100 จุด มันจัดรูปแบบข้อความในเซลล์ (0, 0), เพิ่มค่าให้กับเซลล์ที่เหลือในแถวแรก, และบันทึกผลลัพธ์เป็น `Vertical_Align_Text_out.pptx`

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

## **ตั้งค่าการจัดรูปแบบข้อความในระดับตาราง**

ใช้เมธอด [setTextFormat](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setTextFormat) เพื่อนำการจัดรูปแบบข้อความไปใช้กับทุกเซลล์ในตาราง การโอเวอร์โหลดของเมธอดรับการจัดรูปแบบส่วน, ย่อหน้า, และ TextFrame ทำให้คุณตั้งค่าคุณสมบัติเหล่านี้ได้โดยไม่ต้องวนผ่านแต่ละเซลล์

1. โหลดงานนำเสนอโดยใช้คลาส [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) 
2. รับอ้างอิงถึงสไลด์ตามดัชนีของมัน
3. เข้าถึงอ็อบเจ็กต์ [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) จากสไลด์
4. ตั้งค่าขนาดฟอนต์โดยใช้ [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) สำหรับข้อความ
5. ตั้งค่าการจัดตำแหน่งย่อหน้าและระยะขอบขวาโดยใช้ [setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) และ [setMarginRight](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginRight) 
6. ตั้งค่าทิศทางของข้อความโดยใช้ [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType) 
7. บันทึกงานนำเสนอที่แก้ไขแล้ว

ตัวอย่างด้านล่างเปิดไฟล์ `table.pptx` ซึ่งต้องมีอย่างน้อยหนึ่งสไลด์ที่มีตารางเป็นรูปแบบแรก มันตั้งค่าขนาดฟอนต์เป็น 25 จุด, จัดย่อหน้าขวาโดยมีระยะขอบขวา 20 จุด, และทำให้ข้อความเป็นแนวตั้ง งานนำเสนอที่จัดรูปแบบแล้วบันทึกเป็น `result.pptx`

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

## **รับคุณสมบัติรูปแบบตาราง**

ใช้เมธอด [getStylePreset](https://reference.aspose.com/slides/python-java/aspose.slides/table/#getStylePreset) เพื่ออ่านสไตล์ตั้งล่วงหน้าของตารางและ [setStylePreset](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setStylePreset) เพื่อกำหนดค่า ตัวอย่างนี้ใช้ [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/python-java/aspose.slides/tablestylepreset/) กับตารางหนึ่ง, พิมพ์ค่าพรีเซ็ต, แล้วกำหนดพรีเซ็ตเดียวกันให้กับตารางที่สอง ทั้งสองตารางบันทึกใน `table-style.pptx`

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

## **ล็อคอัตราส่วนของตาราง**

อัตราส่วนของตารางคือสัดส่วนระหว่างความกว้างและความสูงของตาราง ใช้เมธอด [setAspectRatioLocked](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobjectlock/#setAspectRatioLocked) เพื่อล็อคสัดส่วนนี้สำหรับตาราง

ตัวอย่างด้านล่างเปิดไฟล์ `pres.pptx` ซึ่งต้องมีอย่างน้อยหนึ่งสไลด์ที่มีตารางเป็นรูปแบบแรก พิมพ์สถานะการล็อคปัจจุบัน, เปิดการล็อคอัตราส่วน, พิมพ์สถานะที่อัปเดต (`True`), แล้วบันทึกผลลัพธ์เป็น `pres-out.pptx`

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

**ฉันสามารถเปิดใช้งานการอ่านจากขวาไปซ้าย (RTL) สำหรับทั้งตารางและข้อความในเซลล์ได้หรือไม่?**

ใช่ ตารางมีเมธอด [setRightToLeft](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setRightToLeft) และย่อหน้ามี [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setRightToLeft) การใช้ทั้งสองวิธีจะทำให้ลำดับ RTL ถูกต้องและการแสดงผลภายในเซลล์เป็นไปตามที่คาดหวัง

**ฉันจะป้องกันไม่ให้ผู้ใช้ย้ายหรือปรับขนาดตารางในไฟล์ฉบับสุดท้ายได้อย่างไร?**

ใช้ [shape locks](/slides/th/python-java/applying-protection-to-presentation/) เพื่อปิดการย้าย, ปรับขนาด, การเลือก ฯลฯ การล็อคเหล่านี้ใช้กับตารางได้เช่นกัน

**การแทรกรูปภาพภายในเซลล์เป็นพื้นหลังได้รับการสนับสนุนหรือไม่?**

ใช่ คุณสามารถตั้งค่า [picture fill](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/) สำหรับเซลล์; รูปภาพจะครอบคลุมพื้นที่เซลล์ตามโหมดที่เลือก (ยืดหรือเรียงแบบกระเบื้อง)