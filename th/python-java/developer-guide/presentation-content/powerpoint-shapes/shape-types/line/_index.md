---
title: เพิ่มรูปทรงเส้นในพรีเซนเทชันด้วย Python ผ่าน Java
linktitle: เส้น
type: docs
weight: 50
url: /th/python-java/line/
keywords:
- เส้น
- สร้างเส้น
- เพิ่มเส้น
- เส้นธรรมดา
- กำหนดค่าเส้น
- ปรับแต่งเส้น
- สไตล์เส้นประ
- หัวลูกศร
- PowerPoint
- การนำเสนอ
- Python
- Aspose.Slides
description: "เรียนรู้การจัดรูปแบบเส้นในพรีเซนเทชัน PowerPoint ด้วย Aspose.Slides สำหรับ Python ผ่าน Java ค้นพบคุณสมบัติ วิธีการ และตัวอย่าง."
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณสามารถเพิ่มรูปทรงเส้นลงในสไลด์ PowerPoint ได้โดยโปรแกรมมิ่ง บทความนี้แสดงวิธีสร้างเส้นง่าย ๆ และวิธีกำหนดค่าเส้นให้เป็นลูกศร

คุณจะได้เรียนรู้วิธีเพิ่มรูปทรงเส้นลงในสไลด์ ปรับลักษณะที่ปรากฏของเส้น และบันทึกพรีเซนเทชันที่อัปเดต ตัวอย่างจะเน้นที่การตั้งค่าการจัดรูปแบบเส้นเชิงปฏิบัติ เช่น สไตล์ ความกว้าง รูปแบบการเส้นประ ตัวเลือกหัวลูกศร และสีเติม

## **สร้างเส้นธรรมดา**

เพื่อเพิ่มเส้นง่าย ๆ ไปยังสไลด์ที่เลือกในพรีเซนเทชัน ให้ทำตามขั้นตอนด้านล่าง:

- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) 
- รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของมัน
- เพิ่มรูปทรงเส้นโดยใช้เมธอด [addAutoShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapecollection/#addAutoShape) ของออบเจ็กต์ [ShapeCollection](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapecollection/)
- บันทึกพรีเซนเทชันที่แก้ไขเป็นไฟล์ PPTX

ตัวอย่างต่อไปนี้เพิ่มเส้นไปยังสไลด์แรกของพรีเซนเทชัน:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์ PPTX.
presentation = Presentation()
try:
    # ดึงสไลด์แรก.
    slide = presentation.getSlides().get_Item(0)

    # เพิ่มรูปทรงเส้น.
    slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0)

    # เขียนไฟล์ PPTX ลงดิสก์.
    presentation.save("LineShape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **สร้างเส้นรูปแบบลูกศร**

Aspose.Slides for Python via Java ยังอนุญาตให้นักพัฒนาตั้งค่าคุณสมบัติของเส้นเพื่อทำให้เส้นดูสวยงามยิ่งขึ้น เพื่อกำหนดค่าเส้นให้เป็นรูปแบบลูกศร ให้ทำตามขั้นตอนด้านล่าง:

- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) 
- รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของมัน
- เพิ่มรูปทรงเส้นโดยใช้เมธอด [addAutoShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapecollection/#addAutoShape) ของออบเจ็กต์ [ShapeCollection](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapecollection/)
- ตั้งค่า [line style](https://reference.aspose.com/slides/th/python-java/aspose.slides/linestyle/) ให้เป็นหนึ่งในสไตล์ที่ Aspose.Slides for Python via Java มีให้
- ตั้งค่าความกว้างของเส้น
- ตั้งค่า [dash style](https://reference.aspose.com/slides/th/python-java/aspose.slides/linedashstyle/) ให้เป็นหนึ่งในสไตล์ที่ Aspose.Slides for Python via Java มีให้
- ตั้งค่า [arrowhead style](https://reference.aspose.com/slides/th/python-java/aspose.slides/linearrowheadstyle/) และ [length](https://reference.aspose.com/slides/th/python-java/aspose.slides/linearrowheadlength/) ที่ส่วนเริ่มต้นของเส้น
- ตั้งค่า [arrowhead style](https://reference.aspose.com/slides/th/python-java/aspose.slides/linearrowheadstyle/) และ [length](https://reference.aspose.com/slides/th/python-java/aspose.slides/linearrowheadlength/) ที่ส่วนท้ายของเส้น
- บันทึกพรีเซนเทชันที่แก้ไขเป็นไฟล์ PPTX

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineArrowheadLength, LineArrowheadStyle, LineDashStyle, LineStyle, Presentation, PresetColor, SaveFormat, ShapeType

# สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์ PPTX.
presentation = Presentation()
try:
    # ดึงสไลด์แรก.
    slide = presentation.getSlides().get_Item(0)

    # เพิ่มรูปทรงเส้น.
    line = slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0)

    # ใช้การจัดรูปแบบกับเส้น.
    line_format = line.getLineFormat()
    line_format.setStyle(LineStyle.ThickBetweenThin)
    line_format.setWidth(10)

    line_format.setDashStyle(LineDashStyle.DashDot)

    line_format.setBeginArrowheadLength(LineArrowheadLength.Short)
    line_format.setBeginArrowheadStyle(LineArrowheadStyle.Oval)

    line_format.setEndArrowheadLength(LineArrowheadLength.Long)
    line_format.setEndArrowheadStyle(LineArrowheadStyle.Triangle)

    line_format.getFillFormat().setFillType(FillType.Solid)
    line_format.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.Maroon)

    # เขียนไฟล์ PPTX ลงดิสก์.
    presentation.save("LineShape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **คำถามที่พบบ่อย**

**Can I convert a regular line into a connector so it "snaps" to shapes?**

No. A regular line (an [AutoShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/autoshape/) of type [Line](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapetype/)) does not automatically become a connector. To make it snap to shapes, use the dedicated [Connector](https://reference.aspose.com/slides/th/python-java/aspose.slides/connector/) type and the [corresponding APIs](/slides/th/python-java/connector/) for connections.

**What should I do if a line’s properties are inherited from the theme and it’s hard to determine the final values?**

[Read the effective properties](/slides/th/python-java/shape-effective-properties/) of the line and its fill—these already account for inheritance and theme styles.

**Can I lock a line against editing (moving, resizing)?**

Yes. Shapes provide [lock objects](https://reference.aspose.com/slides/th/python-java/aspose.slides/autoshape/#getAutoShapeLock) that let you [disallow editing operations](/slides/th/python-java/applying-protection-to-presentation/).