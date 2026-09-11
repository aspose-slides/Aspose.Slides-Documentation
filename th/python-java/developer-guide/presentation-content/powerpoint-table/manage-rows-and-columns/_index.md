---
title: จัดการแถวและคอลัมน์ในตาราง PowerPoint ด้วย Python
linktitle: แถวและคอลัมน์
type: docs
weight: 20
url: /th/python-java/manage-rows-and-columns/
keywords:
- แถวของตาราง
- คอลัมน์ของตาราง
- แถวแรก
- หัวตาราง
- คัดลอกแถว
- คัดลอกคอลัมน์
- คัดลอกแถว
- คัดลอกคอลัมน์
- ลบแถว
- ลบคอลัมน์
- การจัดรูปแบบข้อความของแถว
- การจัดรูปแบบข้อความของคอลัมน์
- สไตล์ของตาราง
- PowerPoint
- งานนำเสนอ
- Python
- Aspose.Slides
description: "จัดการแถวและคอลัมน์ของตารางใน PowerPoint ด้วย Aspose.Slides สำหรับ Python ผ่าน Java และเร่งการแก้ไขงานนำเสนอและการอัปเดตข้อมูลให้รวดเร็วขึ้น."
---
## **บทนำ**

เพื่อให้คุณสามารถจัดการแถวและคอลัมน์ของตารางในงานนำเสนอ PowerPoint, Aspose.Slides มีคลาส [Table](https://reference.aspose.com/slides/th/python-java/aspose.slides/table/) และหลายประเภทอื่น ๆ

## **ตั้งแถวแรกเป็นหัวเรื่อง**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) และโหลดงานนำเสนอ  
2. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน  
3. สร้างอ้างอิง [Table](https://reference.aspose.com/slides/th/python-java/aspose.slides/table/) และกำหนดค่าเป็น `None`  
4. วนรอบผ่านอ็อบเจ็กต์ [Shape](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/) ทั้งหมดเพื่อค้นหาตารางที่ต้องการ  
5. ตั้งค่าแถวแรกของตารางเป็นหัวเรื่อง  

โค้ด Python นี้แสดงวิธีการตั้งค่าแถวแรกของตารางเป็นหัวเรื่อง:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = None
    for shape in slide.getShapes():
        if isinstance(shape, Table):
            table = shape
            table.setFirstRow(True)
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ทำสำเนาแถวหรือคอลัมน์ของตาราง**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) และโหลดงานนำเสนอ  
2. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน  
3. กำหนดรายการความกว้างของคอลัมน์  
4. กำหนดรายการความสูงของแถว  
5. เพิ่มอ็อบเจ็กต์ [Table](https://reference.aspose.com/slides/th/python-java/aspose.slides/table/) ไปยังสไลด์โดยใช้เมธอด [addTable](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapecollection/#addTable)  
6. ทำสำเนาแถวของตาราง  
7. ทำสำเนาคอลัมน์ของตาราง  
8. บันทึกงานนำเสนอที่เปลี่ยนแปลงแล้ว  

โค้ด Python นี้แสดงวิธีการทำสำเนาแถวหรือคอลัมน์ของตาราง PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("Test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)
    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1")
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2")
    table.getRows().addClone(table.getRows().get_Item(0), False)
    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1")
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2")
    table.getRows().insertClone(3, table.getRows().get_Item(1), False)
    table.getColumns().addClone(table.getColumns().get_Item(0), False)
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), False)
    presentation.save("table_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ลบแถวหรือคอลัมน์จากตาราง**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/)  
2. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน  
3. กำหนดรายการความกว้างของคอลัมน์  
4. กำหนดรายการความสูงของแถว  
5. เพิ่มอ็อบเจ็กต์ [Table](https://reference.aspose.com/slides/th/python-java/aspose.slides/table/) ไปยังสไลด์โดยใช้เมธอด [addTable](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapecollection/#addTable)  
6. ลบแถวของตาราง  
7. ลบคอลัมน์ของตาราง  
8. บันทึกงานนำเสนอที่เปลี่ยนแปลงแล้ว  

โค้ด Python นี้แสดงวิธีการลบแถวหรือคอลัมน์จากตาราง:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    column_widths = [100, 50, 30]
    row_heights = [30, 50, 30]
    table = slide.getShapes().addTable(100, 100, column_widths, row_heights)
    table.getRows().removeAt(1, False)
    table.getColumns().removeAt(1, False)
    presentation.save("TestTable_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ตั้งค่าการจัดรูปแบบข้อความในระดับแถวของตาราง**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) และโหลดงานนำเสนอ  
2. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน  
3. เข้าถึงอ็อบเจ็กต์ [Table](https://reference.aspose.com/slides/th/python-java/aspose.slides/table/) ที่เกี่ยวข้องจากสไลด์  
4. ตั้งค่าความสูงของฟอนต์ของเซลล์ในแถวแรกโดยใช้ [setFontHeight](https://reference.aspose.com/slides/th/python-java/aspose.slides/baseportionformat/#setFontHeight)  
5. ตั้งค่าการจัดแนวข้อความและระยะขอบด้านขวาของเซลล์ในแถวแรกโดยใช้ [setAlignment](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraphformat/#setAlignment) และ [setMarginRight](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraphformat/#setMarginRight)  
6. ตั้งค่าชนิดของข้อความแนวตั้งของเซลล์ในแถวที่สองโดยใช้ [setTextVerticalType](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframeformat/#setTextVerticalType)  
7. บันทึกงานนำเสนอที่เปลี่ยนแปลงแล้ว  

โค้ด Python นี้สาธิตการทำงานดังกล่าว.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table, PortionFormat, ParagraphFormat, TextFrameFormat, TextAlignment, TextVerticalType

presentation = Presentation("table.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
        portion_format = PortionFormat()
        portion_format.setFontHeight(25)
        table.getRows().get_Item(0).setTextFormat(portion_format)
        paragraph_format = ParagraphFormat()
        paragraph_format.setAlignment(TextAlignment.Right)
        paragraph_format.setMarginRight(20)
        table.getRows().get_Item(0).setTextFormat(paragraph_format)
        text_frame_format = TextFrameFormat()
        text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
        table.getRows().get_Item(1).setTextFormat(text_frame_format)
        presentation.save("result.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **ตั้งค่าการจัดรูปแบบข้อความในระดับคอลัมน์ของตาราง**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) และโหลดงานนำเสนอ  
2. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน  
3. เข้าถึงอ็อบเจ็กต์ [Table](https://reference.aspose.com/slides/th/python-java/aspose.slides/table/) ที่เกี่ยวข้องจากสไลด์  
4. ตั้งค่าความสูงของฟอนต์ของเซลล์ในคอลัมน์แรกโดยใช้ [setFontHeight](https://reference.aspose.com/slides/th/python-java/aspose.slides/baseportionformat/#setFontHeight)  
5. ตั้งค่าการจัดแนวข้อความและระยะขอบด้านขวาของเซลล์ในคอลัมน์แรกโดยใช้ [setAlignment](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraphformat/#setAlignment) และ [setMarginRight](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraphformat/#setMarginRight)  
6. ตั้งค่าชนิดของข้อความแนวตั้งของเซลล์ในคอลัมน์ที่สองโดยใช้ [setTextVerticalType](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframeformat/#setTextVerticalType)  
7. บันทึกงานนำเสนอที่เปลี่ยนแปลงแล้ว  

โค้ด Python นี้สาธิตการทำงาน:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table, PortionFormat, ParagraphFormat, TextFrameFormat, TextAlignment, TextVerticalType

presentation = Presentation("table.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
        portion_format = PortionFormat()
        portion_format.setFontHeight(25)
        table.getColumns().get_Item(0).setTextFormat(portion_format)
        paragraph_format = ParagraphFormat()
        paragraph_format.setAlignment(TextAlignment.Right)
        paragraph_format.setMarginRight(20)
        table.getColumns().get_Item(0).setTextFormat(paragraph_format)
        text_frame_format = TextFrameFormat()
        text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
        table.getColumns().get_Item(1).setTextFormat(text_frame_format)
        presentation.save("result.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **รับคุณสมบัติสไตล์ของตาราง**

Aspose.Slides ช่วยให้คุณดึงคุณสมบัติสไตล์ของตารางออกมา เพื่อที่คุณจะได้นำรายละเอียดเหล่านั้นไปใช้กับตารางอื่นหรือที่อื่น โค้ด Python นี้แสดงวิธีการรับคุณสมบัติสไตล์จากสไตล์ที่ตั้งค่าล่วงหน้าของตาราง:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = presentation.getSlides().get_Item(0).getShapes().addTable(10, 10, column_widths, row_heights)
    table.setStylePreset(TableStylePreset.DarkStyle1)
    style_preset = table.getStylePreset()
    print(style_preset)
    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **คำถามที่พบบ่อย**

**ฉันสามารถใช้ธีมหรือสไตล์ของ PowerPoint กับตารางที่สร้างแล้วได้หรือไม่?**

ใช่ ตารางจะสืบทอดธีมของสไลด์/เลย์เอาต์/มาสเตอร์ และคุณยังสามารถเขียนทับสีเติม, ขอบ, และสีข้อความเหนือธีมนั้นได้

**ฉันสามารถจัดเรียงแถวของตารางแบบใน Excel ได้หรือไม่?**

ไม่, ตารางของ Aspose.Slides ไม่มีการจัดเรียงหรือฟิลเตอร์ในตัวให้ใช้ คุณต้องจัดเรียงข้อมูลในหน่วยความจำก่อน แล้วจึงเติมแถวของตารางใหม่ตามลำดับนั้น

**ฉันสามารถทำคอลัมน์แบบลายแถบ (striped) พร้อมรักษาสีที่กำหนดเองในเซลล์เฉพาะได้หรือไม่?**

ได้ เปิดการใช้งานคอลัมน์แบบแถบ แล้วเขียนทับเซลล์เฉพาะด้วยการจัดรูปแบบท้องถิ่น; การจัดรูปแบบระดับเซลล์จะมีลำดับความสำคัญเหนือสไตล์ของตาราง