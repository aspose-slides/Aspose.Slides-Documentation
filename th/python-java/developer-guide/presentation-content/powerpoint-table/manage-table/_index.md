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
- อัตราส่วนภาพ
- จัดแนวข้อความ
- การจัดรูปแบบข้อความ
- สไตล์ตาราง
- PowerPoint
- การนำเสนอ
- Python
- Aspose.Slides
description: "สร้างและแก้ไขตารางในสไลด์ PowerPoint ด้วย Aspose.Slides สำหรับ Python ผ่าน Java. ค้นพบตัวอย่างโค้ดง่ายๆ เพื่อทำให้กระบวนการทำงานกับตารางของคุณคล่องขึ้น."
---
## **บทนำ**

ตารางใน PowerPoint เป็นวิธีที่มีประสิทธิภาพในการแสดงข้อมูล ข้อมูลในตารางของเซลล์ (จัดเรียงเป็นแถวและคอลัมน์) มีความชัดเจนและเข้าใจง่าย

Aspose.Slides มีคลาส [Table](https://reference.aspose.com/slides/th/python-java/aspose.slides/table/), [Cell](https://reference.aspose.com/slides/th/python-java/aspose.slides/cell/) และประเภทอื่น ๆ เพื่อให้คุณสร้าง, อัปเดต, และจัดการตารางในงานนำเสนอทุกประเภท

## **สร้างตารางจากศูนย์**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/).
2. รับการอ้างอิงไปยังสไลด์โดยใช้ดัชนีของมัน.
3. กำหนดรายการความกว้างของคอลัมน์.
4. กำหนดรายการความสูงของแถว.
5. เพิ่มอ็อบเจกต์ [Table](https://reference.aspose.com/slides/th/python-java/aspose.slides/table/) ไปยังสไลด์โดยใช้เมธอด [addTable](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapecollection/#addTable).
6. วนลูปผ่านแต่ละ [Cell](https://reference.aspose.com/slides/th/python-java/aspose.slides/cell/) เพื่อกำหนดรูปแบบให้กับเส้นขอบบน, ล่าง, ขวา, และซ้าย.
7. รวมสองเซลล์แรกของแถวแรกของตาราง.
8. เข้าถึง [Cell](https://reference.aspose.com/slides/th/python-java/aspose.slides/cell/)'s [TextFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframe/).
9. เพิ่มข้อความบางส่วนลงใน [TextFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframe/).
10. บันทึกงานนำเสนอที่แก้ไขแล้ว.

โค้ด Python นี้แสดงวิธีสร้างตารางในงานนำเสนอ:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

# สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PPTX
presentation = Presentation()
try:

    # เข้าถึงสไลด์แรก
    slide = presentation.getSlides().get_Item(0)

    # กำหนดคอลัมน์พร้อมความกว้างและแถวพร้อมความสูง
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # เพิ่มรูปร่างตารางลงในสไลด์
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # ตั้งค่ารูปแบบขอบสำหรับแต่ละเซลล์
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

    # รวมเซลล์ที่ 1 และ 2 ของแถวที่ 1
    table.mergeCells(table.getRows().get_Item(0).get_Item(0), table.getRows().get_Item(0).get_Item(1), False)

    # เพิ่มข้อความบางส่วนลงในเซลล์ที่รวมกัน
    table.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells")

    # บันทึกการนำเสนอลงดิสก์
    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **การจัดลำดับในตารางมาตรฐาน**

ในตารางมาตรฐาน การจัดลำดับของเซลล์เป็นเรื่องง่ายและเริ่มจากศูนย์ เซลล์แรกในตารางมีดัชนีเป็น 0,0 (คอลัมน์ 0, แถว 0).

เช่นเซลล์ในตารางที่มี 4 คอลัมน์และ 4 แถวจะถูกจัดลำดับตามนี้:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

โค้ด Python นี้แสดงวิธีสร้างตารางที่มีการจัดลำดับเซลล์ตามมาตรฐาน:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

# สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PPTX
presentation = Presentation()
try:

    # เข้าถึงสไลด์แรก
    slide = presentation.getSlides().get_Item(0)

    # กำหนดคอลัมน์พร้อมความกว้างและแถวพร้อมความสูง
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # เพิ่มรูปร่างตารางลงในสไลด์
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # ตั้งค่ารูปแบบขอบสำหรับแต่ละเซลล์
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

    # บันทึกการนำเสนอลงดิสก์
    presentation.save("StandardTables_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **การเข้าถึงตารางที่มีอยู่**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/).
2. รับการอ้างอิงไปยังสไลด์ที่มีตารางโดยใช้ดัชนีของสไลด์.
3. กำหนดค่าเริ่มต้นให้กับตัวแปรชนิดอ็อบเจกต์ [Table](https://reference.aspose.com/slides/th/python-java/aspose.slides/table/) และตั้งค่าเป็น `None`.
4. วนลูปผ่านทุกอ็อบเจกต์ [Shape](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/) จนกว่าจะพบตาราง.

   หากคุณสงสัยว่าสไลด์ที่คุณกำลังทำงานอยู่มีตารางเพียงหนึ่งตาราง คุณสามารถตรวจสอบทุก shape ที่สไลด์ประกอบได้โดยตรง เมื่อ shape ถูกระบุว่าเป็นตาราง คุณสามารถใช้เป็นอ็อบเจกต์ [Table](https://reference.aspose.com/slides/th/python-java/aspose.slides/table/) ได้ แต่หากสไลด์มีหลายตาราง คุณควรค้นหาตารางที่ต้องการผ่าน [getAlternativeText](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#getAlternativeText).
5. ใช้อ็อบเจกต์ [Table](https://reference.aspose.com/slides/th/python-java/aspose.slides/table/) เพื่อทำงานกับตาราง ตัวอย่างด้านล่างเราจะอัปเดตข้อความในคอลัมน์แรกของแถวที่สอง.
6. บันทึกงานนำเสนอที่แก้ไขแล้ว.

โค้ด Python นี้แสดงวิธีเข้าถึงและทำงานกับตารางที่มีอยู่:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

# สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PPTX
presentation = Presentation("UpdateExistingTable.pptx")
try:

    # เข้าถึงสไลด์แรก
    slide = presentation.getSlides().get_Item(0)

    # กำหนดค่าเริ่มต้นของตัวแปรอ้างอิงตาราง.
    table = None

    # วนลูปผ่าน shape ทั้งหมดและตั้งค่าตัวแปรอ้างอิงให้เป็นตารางที่พบ
    for shape in slide.getShapes():
        if isinstance(shape, Table):
            table = shape

            # ตั้งค่าข้อความสำหรับคอลัมน์แรกของแถวที่สอง
            table.get_Item(0, 1).getTextFrame().setText("New")

    # บันทึกการนำเสนอที่แก้ไขลงดิสก์
    presentation.save("table1_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ค้นหา Cell ที่เป็นเจ้าของ Text Frame**

เมื่อโค้ดประมวลผลข้อความทั่วไปได้รับ [TextFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframe/) จากตาราง ให้ใช้เมธอด [TextFrame.getParentCell](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframe/#getParentCell) เพื่อดึง [Cell](https://reference.aspose.com/slides/th/python-java/aspose.slides/cell/) ที่เป็นเจ้าของ สำหรับ TextFrame ของเซลล์ตาราง [TextFrame.getParentCell](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframe/#getParentCell) จะคืนค่าเจ้าของและ [TextFrame.getParentShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframe/#getParentShape) จะคืนค่า `None` แม้ว่าตารางเองเป็น shape

พิกัดของเซลล์สามารถเข้าถึงได้ผ่านเมธอดที่อ่านอย่างเดียว [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/th/python-java/aspose.slides/cell/#getFirstColumnIndex) และ [Cell.getFirstRowIndex](https://reference.aspose.com/slides/th/python-java/aspose.slides/cell/#getFirstRowIndex) [TextFrame.getParentCell](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframe/#getParentCell) ยังให้การนำทางแบบอ่านอย่างเดียว: มันคืนค่าเจ้าของแต่ไม่เปลี่ยนความเป็นเจ้าของ ตรวจสอบว่าเซลล์ที่คืนค่ามาไม่เป็น `None` ก่อนนำไปใช้เสมอ

สำหรับตัวอย่างที่สมบูรณ์ซึ่งระบุเจ้าของ table-cell และ shape รวมถึง shape ที่เชื่อมโยงกับโหนด SmartArt ดูที่ [Search and Replace Text](/slides/th/python-java/search-and-replace-text/).

## **จัดแนวข้อความในตาราง**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/).
2. รับการอ้างอิงไปยังสไลด์โดยใช้ดัชนีของมัน.
3. เพิ่มอ็อบเจกต์ [Table](https://reference.aspose.com/slides/th/python-java/aspose.slides/table/) ไปยังสไลด์.
4. เข้าถึงอ็อบเจกต์ [TextFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframe/) จากตาราง.
5. เข้าถึง [Paragraph](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraph/) ของ [TextFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframe/).
6. จัดแนวข้อความในแนวตั้ง.
7. บันทึกงานนำเสนอที่แก้ไขแล้ว.

โค้ด Python นี้แสดงวิธีจัดแนวข้อความในตาราง:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, TextAnchorType, TextVerticalType
from java.awt import Color

# สร้างอินสแตนซ์ของคลาส Presentation
presentation = Presentation()
try:

    # รับสไลด์แรก
    slide = presentation.getSlides().get_Item(0)

    # กำหนดคอลัมน์พร้อมความกว้างและแถวพร้อมความสูง
    column_widths = [120, 120, 120, 120]
    row_heights = [100, 100, 100, 100]

    # เพิ่มรูปร่างตารางลงในสไลด์
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)
    table.get_Item(1, 0).getTextFrame().setText("10")
    table.get_Item(2, 0).getTextFrame().setText("20")
    table.get_Item(3, 0).getTextFrame().setText("30")

    # เข้าถึง TextFrame
    text_frame = table.get_Item(0, 0).getTextFrame()

    # เข้าถึงย่อหน้าแรกใน TextFrame.
    paragraph = text_frame.getParagraphs().get_Item(0)

    # เข้าถึงส่วนแรกในย่อหน้า.
    portion = paragraph.getPortions().get_Item(0)
    portion.setText("Text here")
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    # จัดแนวข้อความในแนวตั้ง
    cell = table.get_Item(0, 0)
    cell.setTextAnchorType(TextAnchorType.Center)
    cell.setTextVerticalType(TextVerticalType.Vertical270)

    # บันทึกการนำเสนอลงดิสก์
    presentation.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ตั้งค่าการจัดรูปแบบข้อความในระดับตาราง**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/).
2. รับการอ้างอิงไปยังสไลด์โดยใช้ดัชนีของมัน.
3. เข้าถึงอ็อบเจกต์ [Table](https://reference.aspose.com/slides/th/python-java/aspose.slides/table/) จากสไลด์.
4. ตั้งค่าความสูงของฟอนต์ของข้อความด้วย [setFontHeight](https://reference.aspose.com/slides/th/python-java/aspose.slides/baseportionformat/#setFontHeight).
5. ตั้งค่าการจัดแนวและระยะขอบขวาด้วย [setAlignment](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraphformat/#setAlignment) และ [setMarginRight](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraphformat/#setMarginRight).
6. ตั้งค่าชนิดของข้อความแนวตั้งด้วย [setTextVerticalType](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframeformat/#setTextVerticalType).
7. บันทึกงานนำเสนอที่แก้ไขแล้ว.

โค้ด Python นี้แสดงวิธีใช้ตัวเลือกการจัดรูปแบบที่คุณต้องการกับข้อความในตาราง:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ParagraphFormat, PortionFormat, Presentation, SaveFormat, TextAlignment, TextFrameFormat, TextVerticalType, Table

# สร้างอินสแตนซ์ของคลาส Presentation
presentation = Presentation("simpletable.pptx")
try:

    # สมมติว่า shape แรกบนสไลด์แรกเป็นตาราง
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape

        # ตั้งค่าความสูงของฟอนต์สำหรับเซลล์ตาราง
        portion_format = PortionFormat()
        portion_format.setFontHeight(25)
        table.setTextFormat(portion_format)

        # ตั้งค่าการจัดแนวข้อความและระยะขอบด้านขวาของเซลล์ตารางในหนึ่งคำสั่ง
        paragraph_format = ParagraphFormat()
        paragraph_format.setAlignment(TextAlignment.Right)
        paragraph_format.setMarginRight(20)
        table.setTextFormat(paragraph_format)

        # ตั้งค่าชนิดการจัดแนวข้อความแนวตั้งของเซลล์ตาราง
        text_frame_format = TextFrameFormat()
        text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
        table.setTextFormat(text_frame_format)
        presentation.save("result.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **รับคุณสมบัติสไตล์ของตาราง**

Aspose.Slides ช่วยให้คุณดึงคุณสมบัติสไตล์ของตารางเพื่อใช้รายละเอียดเหล่านั้นกับตารางอื่นหรือที่อื่น โค้ด Python นี้แสดงวิธีดึงคุณสมบัติสไตล์จากสไตล์ตารางที่กำหนดไว้ล่วงหน้า:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    table = presentation.getSlides().get_Item(0).getShapes().addTable(10, 10, [100, 150], [5, 5, 5])
    table.setStylePreset(TableStylePreset.DarkStyle1)  # เปลี่ยนธีมพรีเซ็ตสไตล์เริ่มต้น

    # รับพรีเซ็ตสไตล์ของตาราง
    style_preset = table.getStylePreset()
    print("Table style preset: ", style_preset)

    # นำพรีเซ็ตสไตล์ที่ดึงมาไปใช้กับตารางอื่น
    another_table = presentation.getSlides().get_Item(0).getShapes().addTable(10, 100, [100, 150], [5, 5, 5])
    another_table.setStylePreset(style_preset)
    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ล็อคอัตราส่วนของตาราง**

อัตราส่วนของรูปร่างเรขาคณิตคืออัตราส่วนของขนาดในมิติที่ต่างกัน Aspose.Slides มีเมธอด [setAspectRatioLocked](https://reference.aspose.com/slides/th/python-java/aspose.slides/graphicalobjectlock/#setAspectRatioLocked) เพื่อให้คุณล็อคการตั้งค่าอัตราส่วนสำหรับตารางและรูปร่างอื่น ๆ

โค้ด Python นี้แสดงวิธีล็อคอัตราส่วนสำหรับตาราง:

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
        table.getGraphicalObjectLock().setAspectRatioLocked(not table.getGraphicalObjectLock().getAspectRatioLocked())  # กลับค่า
        print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())
        presentation.save("pres-out.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **FAQ**

**ฉันสามารถเปิดใช้งานทิศทางการอ่านจากขวาไปซ้าย (RTL) สำหรับตารางทั้งหมดและข้อความในเซลล์ได้หรือไม่?**

ใช่ ตารางมีเมธอด [setRightToLeft](https://reference.aspose.com/slides/th/python-java/aspose.slides/table/#setRightToLeft) และพารากราฟมี [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraphformat/#setRightToLeft) การใช้ทั้งสองวิธีทำให้ลำดับ RTL ถูกต้องและการแสดงผลภายในเซลล์เป็นไปอย่างเหมาะสม

**ฉันจะป้องกันไม่ให้ผู้ใช้ย้ายหรือปรับขนาดตารางในไฟล์ขั้นสุดท้ายได้อย่างไร?**

ใช้ [shape locks](/slides/th/python-java/applying-protection-to-presentation/) เพื่อปิดการย้าย, ปรับขนาด, การเลือก เป็นต้น การล็อคเหล่านี้ใช้กับตารางเช่นกัน

**การแทรกรูปภาพเป็นพื้นหลังภายในเซลล์ได้รับการสนับสนุนหรือไม่?**

ใช่ คุณสามารถตั้งค่า [picture fill](https://reference.aspose.com/slides/th/python-java/aspose.slides/picturefillformat/) สำหรับเซลล์ได้; รูปภาพจะคลุมพื้นที่เซลล์ตามโหมดที่เลือก (ขยายหรือเรียงต่อกัน).