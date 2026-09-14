---
title: ลบสไลด์จากงานนำเสนอใน Python
linktitle: ลบสไลด์
type: docs
weight: 30
url: /th/python-java/remove-slide-from-presentation/
keywords:
- ลบสไลด์
- ลบสไลด์
- ลบสไลด์ที่ไม่ได้ใช้
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Aspose.Slides
description: "ลบสไลด์จากงานนำเสนอ PowerPoint และ OpenDocument อย่างง่ายดายด้วย Aspose.Slides สำหรับ Python ผ่าน Java. รับตัวอย่างโค้ดที่ชัดเจนและเพิ่มประสิทธิภาพการทำงานของคุณ."
---
## **บทนำ**

หากสไลด์ (หรือเนื้อหาในสไลด์) กลายเป็นซ้ำซ้อน คุณสามารถลบออกได้ Aspose.Slides มีคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) ที่รวม [SlideCollection](https://reference.aspose.com/slides/th/python-java/aspose.slides/slidecollection/) ซึ่งเป็นคลังเก็บสไลด์ทั้งหมดในงานนำเสนอ โดยใช้การอ้างอิงหรือดัชนีของอ็อบเจ็กต์ [Slide](https://reference.aspose.com/slides/th/python-java/aspose.slides/slide/) ที่รู้จัก คุณสามารถระบุสไลด์ที่ต้องการลบได้

## **ลบสไลด์โดยใช้การอ้างอิง**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/)  
2. รับการอ้างอิงไปยังสไลด์ที่ต้องการลบโดยใช้ ID หรือดัชนีของมัน  
3. ลบสไลด์ที่อ้างอิงออกจากงานนำเสนอ  
4. บันทึกงานนำเสนอที่ปรับปรุงแล้ว  

โค้ด Python นี้แสดงวิธีลบสไลด์โดยใช้การอ้างอิง:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# สร้างอ็อบเจ็กต์ Presentation ที่แสดงไฟล์งานนำเสนอ
presentation = Presentation("demo.pptx")
try:
    # เข้าถึงสไลด์ผ่านดัชนีในคอลเลกชันสไลด์
    slide = presentation.getSlides().get_Item(0)

    # ลบสไลด์ผ่านการอ้างอิง
    presentation.getSlides().remove(slide)

    # บันทึกงานนำเสนอที่แก้ไขแล้ว
    presentation.save("modified.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ลบสไลด์โดยใช้ดัชนี**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/)  
2. ลบสไลด์จากงานนำเสนอโดยใช้ตำแหน่งดัชนีของมัน  
3. บันทึกงานนำเสนอที่ปรับปรุงแล้ว  

โค้ด Python นี้แสดงวิธีลบสไลด์โดยใช้ดัชนี:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# สร้างอ็อบเจ็กต์ Presentation ที่แสดงไฟล์งานนำเสนอ.
presentation = Presentation("demo.pptx")
try:
    # ลบสไลด์ผ่านดัชนีของมัน.
    presentation.getSlides().removeAt(0)

    # บันทึกงานนำเสนอที่แก้ไขแล้ว.
    presentation.save("modified.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ลบสไลด์ Layout ที่ไม่ได้ใช้**

Aspose.Slides มีเมธอด [removeUnusedLayoutSlides](https://reference.aspose.com/slides/th/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) (จากคลาส [Compress](https://reference.aspose.com/slides/th/python-java/aspose.slides/compress/)) เพื่อให้คุณลบสไลด์ Layout ที่ไม่ต้องการและไม่ได้ใช้ได้ โค้ด Python นี้แสดงวิธีลบสไลด์ Layout จากงานนำเสนอ PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    Compress.removeUnusedLayoutSlides(presentation)

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ลบสไลด์ Master ที่ไม่ได้ใช้**

Aspose.Slides มีเมธอด [removeUnusedMasterSlides](https://reference.aspose.com/slides/th/python-java/aspose.slides/compress/#removeUnusedMasterSlides) (จากคลาส [Compress](https://reference.aspose.com/slides/th/python-java/aspose.slides/compress/)) เพื่อให้คุณลบสไลด์ Master ที่ไม่ต้องการและไม่ได้ใช้ได้ โค้ด Python นี้แสดงวิธีลบสไลด์ Master จากงานนำเสนอ PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    Compress.removeUnusedMasterSlides(presentation)

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **คำถามที่พบบ่อย**

**เกิดอะไรขึ้นกับดัชนีสไลด์หลังจากที่ฉันลบสไลด์?**

หลังจากการลบ, [collection](https://reference.aspose.com/slides/th/python-java/aspose.slides/slidecollection/) จะทำการจัดเรียงดัชนีใหม่: สไลด์ต่อมาทั้งหมดจะเลื่อนตำแหน่งไปด้านซ้ายหนึ่งตำแหน่ง ดังนั้นหมายเลขดัชนีก่อนหน้าจะล้าสมัย หากคุณต้องการการอ้างอิงที่คงที่ ให้ใช้ ID คงที่ของแต่ละสไลด์แทนการใช้ดัชนี

**ID ของสไลด์แตกต่างจากดัชนีหรือไม่ และจะเปลี่ยนเมื่อสไลด์ข้างเคียงถูกลบหรือไม่?**

ใช่ ดัชนีคือตำแหน่งของสไลด์และจะเปลี่ยนเมื่อสไลด์ถูกเพิ่มหรือเอาออก ID ของสไลด์เป็นตัวระบุที่คงที่และจะไม่เปลี่ยนเมื่อสไลด์อื่นถูกลบ

**การลบสไลด์มีผลต่อส่วนของสไลด์อย่างไร?**

หากสไลด์เป็นส่วนหนึ่งของ Section Section นั้นจะเหลือสไลด์น้อยลงหนึ่งสไลด์ โครงสร้าง Section ยังคงอยู่; หาก Section กลายเป็นว่างเปล่า คุณสามารถ [ลบหรือจัดระเบียบส่วน](/slides/th/python-java/slide-section/) ตามต้องการ

**เกิดอะไรขึ้นกับโน้ตและคอมเมนต์ที่แนบกับสไลด์เมื่อสไลด์นั้นถูกลบ?**

[บันทึก](/slides/th/python-java/presentation-notes/) และ [คอมเมนต์](/slides/th/python-java/presentation-comments/) เชื่อมโยงกับสไลด์นั้นโดยเฉพาะและจะถูกลบพร้อมกับสไลด์นั้น เนื้อหาในสไลด์อื่นจะไม่ได้รับผลกระทบ

**การลบสไลด์ต่างจากการทำความสะอาด Layout/Master ที่ไม่ได้ใช้อย่างไร?**

การลบจะเอาสไลด์ปกติที่ระบุออกจากชุดสไลด์ ส่วนการทำความสะอาด Layout/Master ที่ไม่ได้ใช้จะลบสไลด์ Layout หรือ Master ที่ไม่มีอ็อบเจ็กต์อ้างอิงถึง เพื่อลดขนาดไฟล์โดยไม่กระทบเนื้อหาสไลด์ที่เหลือ การทำสองอย่างนี้เป็นการเสริมกัน: ปกติจะลบสไลด์ก่อน แล้วจึงทำความสะอาด Layout/Master.