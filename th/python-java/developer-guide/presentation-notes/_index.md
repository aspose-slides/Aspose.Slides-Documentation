---
title: จัดการโน้ตงานนำเสนอใน Python ผ่าน Java
linktitle: โน้ตงานนำเสนอ
type: docs
weight: 110
url: /th/python-java/presentation-notes/
keywords:
- โน้ต
- สไลด์โน้ต
- เพิ่มโน้ต
- ลบโน้ต
- สไตล์โน้ต
- โน้ตหลัก
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "ปรับแต่งโน้ตงานนำเสนอด้วย Aspose.Slides สำหรับ Python ผ่าน Java ทำงานกับโน้ต PowerPoint และ OpenDocument อย่างราบรื่นเพื่อเพิ่มประสิทธิภาพการทำงานของคุณ."
---
## **ภาพรวม**

Aspose.Slides รองรับการลบโน้ตสไลด์ออกจากงานนำเสนอ หัวข้อนี้แนะนำคุณลักษณะนี้ รวมถึงวิธีลบโน้ตและวิธีใช้สไตล์กับโน้ตสไลด์ในงานนำเสนอ Aspose.Slides ให้คุณลบโน้ตจากสไลด์ใดก็ได้และใช้สไตล์กับโนตที่มีอยู่ นักพัฒนาสามารถลบโน้ตได้ตามวิธีต่อไปนี้:
- ลบโน้ตจากสไลด์เฉพาะในงานนำเสนอ.
- ลบโน้ตจากสไลด์ทั้งหมดในงานนำเสนอ.

## **ลบโน้ตจากสไลด์**

สามารถลบโน้ตจากสไลด์เฉพาะได้ตามตัวอย่างด้านล่าง:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# สร้างอ็อบเจกต์ Presentation ที่แสดงถึงไฟล์งานนำเสนอ.
presentation = Presentation("presWithNotes.pptx")
try:
    # ลบโน้ตจากสไลด์แรก.
    notes_manager = presentation.getSlides().get_Item(0).getNotesSlideManager()
    notes_manager.removeNotesSlide()

    # บันทึกงานนำเสนอลงดิสก์.
    presentation.save("test.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ลบโน้ตจากงานนำเสนอ**

สามารถลบโน้ตจากสไลด์ทั้งหมดในงานนำเสนอได้ตามตัวอย่างด้านล่าง:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# สร้างอ็อบเจกต์ Presentation ที่แสดงถึงไฟล์งานนำเสนอ.
presentation = Presentation("presWithNotes.pptx")
try:
    # ลบโน้ตจากสไลด์ทั้งหมด.
    for i in range(presentation.getSlides().size()):
        notes_manager = presentation.getSlides().get_Item(i).getNotesSlideManager()
        notes_manager.removeNotesSlide()

    # บันทึกงานนำเสนอลงดิสก์.
    presentation.save("test.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **เพิ่มสไตล์โน้ต**

เมธอด [getNotesStyle](https://reference.aspose.com/slides/th/python-java/aspose.slides/masternotesslide/#getNotesStyle) ของคลาส [MasterNotesSlide](https://reference.aspose.com/slides/th/python-java/aspose.slides/masternotesslide/) ให้การเข้าถึงสไตล์ของข้อความโน้ต ตัวอย่างการใช้งานแสดงในโค้ดด้านล่าง.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Presentation, SaveFormat

# สร้างอ็อบเจกต์ Presentation ที่แสดงถึงไฟล์งานนำเสนอ.
presentation = Presentation("demo.pptx")
try:
    notes_master = presentation.getMasterNotesSlideManager().getMasterNotesSlide()

    if notes_master is not None:
        # รับสไตล์ข้อความของสไลด์โน้ตหลัก.
        notes_style = notes_master.getNotesStyle()

        # ตั้งสัญลักษณ์ bullet สำหรับย่อหน้าระดับแรก.
        paragraph_format = notes_style.getLevel(0)
        paragraph_format.getBullet().setType(BulletType.Symbol)

    presentation.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **คำถามที่พบบ่อย**

**ใครเป็นเอนทิตี้ API ที่ให้การเข้าถึงโน้ตของสไลด์เฉพาะ?**

โน้ตจะเข้าถึงผ่านผู้จัดการโน้ตของสไลด์: แต่ละสไลด์มี [NotesSlideManager](https://reference.aspose.com/slides/th/python-java/aspose.slides/notesslidemanager/) และเมธอด [getNotesSlide](https://reference.aspose.com/slides/th/python-java/aspose.slides/notesslidemanager/#getNotesSlide) ซึ่งจะคืนค่าออบเจ็กต์โน้ต หรือ `None` หากไม่มีโนต.

**มีความแตกต่างในการสนับสนุนโน้ตระหว่างเวอร์ชัน PowerPoint ที่ไลบรารีทำงานด้วยหรือไม่?**

ไลบรารีนี้รองรับรูปแบบไฟล์ Microsoft PowerPoint ช่วงกว้าง (ตั้งแต่เวอร์ชัน 97 เป็นต้นไป) รวมถึง ODP; โน้ตได้รับการสนับสนุนในรูปแบบเหล่านี้โดยไม่ต้องอิงกับการติดตั้ง PowerPoint อยู่แล้ว.