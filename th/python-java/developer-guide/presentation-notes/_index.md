---
title: จัดการโน้ตงานนำเสนอใน Python ผ่าน Java
linktitle: โน้ตการนำเสนอ
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

Aspose.Slides รองรับการลบโน้ตสไลด์ออกจากงานนำเสนอ หัวข้อนี้แนะนำคุณลักษณะนี้ รวมถึงวิธีการลบโน้ตและวิธีการใช้สไตล์กับโน้ตสไลด์ในงานนำเสนอ Aspose.Slides ให้คุณลบโน้ตจากสไลด์ใดก็ได้และนำสไตล์ไปใช้กับโน้ตที่มีอยู่แล้ว นักพัฒนาสามารถลบโน้ตได้ด้วยวิธีต่อไปนี้:

- ลบโน้ตจากสไลด์เฉพาะในงานนำเสนอ
- ลบโน้ตจากสไลด์ทั้งหมดในงานนำเสนอ

เพื่ออ่านหรือเปลี่ยนขนาดหน้โน้ต, สวิตช์การวางแนว, และตรวจสอบพฤติกรรมการส่งออก ดูที่ [Notes Page Size](/slides/th/python-java/notes-size/).

## **ลบโน้ตจากสไลด์**

โน้ตจากสไลด์เฉพาะสามารถลบได้ตามตัวอย่างด้านล่าง:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# สร้างอ็อบเจกต์ Presentation ที่แสดงไฟล์งานนำเสนอ
presentation = Presentation("presWithNotes.pptx")
try:
    # ลบโน้ตจากสไลด์แรก
    notes_manager = presentation.getSlides().get_Item(0).getNotesSlideManager()
    notes_manager.removeNotesSlide()

    # บันทึกงานนำเสนอลงดิสก์
    presentation.save("test.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ลบโน้ตจากงานนำเสนอ**

โน้ตจากสไลด์ทั้งหมดในงานนำเสนอสามารถลบได้ตามตัวอย่างด้านล่าง:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# สร้างอ็อบเจกต์ Presentation ที่แสดงไฟล์งานนำเสนอ
presentation = Presentation("presWithNotes.pptx")
try:
    # ลบโน้ตจากสไลด์ทั้งหมด
    for i in range(presentation.getSlides().size()):
        notes_manager = presentation.getSlides().get_Item(i).getNotesSlideManager()
        notes_manager.removeNotesSlide()

    # บันทึกงานนำเสนอลงดิสก์
    presentation.save("test.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **เพิ่มสไตล์โน้ต**

เมธอด [getNotesStyle](https://reference.aspose.com/slides/th/python-java/aspose.slides/masternotesslide/#getNotesStyle) ของคลาส [MasterNotesSlide](https://reference.aspose.com/slides/th/python-java/aspose.slides/masternotesslide/) ให้การเข้าถึงสไตล์ของข้อความโน้ต การใช้งานจะแสดงในตัวอย่างด้านล่าง

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Presentation, SaveFormat

# สร้างอ็อบเจกต์ Presentation ที่แสดงไฟล์งานนำเสนอ
presentation = Presentation("demo.pptx")
try:
    notes_master = presentation.getMasterNotesSlideManager().getMasterNotesSlide()

    if notes_master is not None:
        # ดึงสไตล์ข้อความของสไลด์โน้ตหลัก
        notes_style = notes_master.getNotesStyle()

        # กำหนดสัญลักษณ์บูลเล็ทสำหรับย่อหน้าระดับแรก
        paragraph_format = notes_style.getLevel(0)
        paragraph_format.getBullet().setType(BulletType.Symbol)

    presentation.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**เอนทิตี API ใดที่ให้การเข้าถึงโน้ตของสไลด์เฉพาะ?**

โน้ตเข้าถึงผ่านผู้จัดการโน้ตของสไลด์: สไลด์มี [NotesSlideManager](https://reference.aspose.com/slides/th/python-java/aspose.slides/notesslidemanager/) และเมธอด [getNotesSlide](https://reference.aspose.com/slides/th/python-java/aspose.slides/notesslidemanager/#getNotesSlide) ที่คืนค่าอ็อบเจกต์โน้ต, หรือ `None` หากไม่มีโน้ต

**มีความแตกต่างในการสนับสนุนโน้ตระหว่างเวอร์ชัน PowerPoint ที่ไลบรารีทำงานด้วยหรือไม่?**

ไลบรารีรองรับรูปแบบ Microsoft PowerPoint ช่วงกว้าง (ตั้งแต่ 97 เป็นต้นไป) และ ODP; โน้ตได้รับการสนับสนุนในรูปแบบเหล่านี้โดยไม่ต้องพึ่งพาการติดตั้ง PowerPoint อยู่บนเครื่อง

---
title: จัดการโน้ตงานนำเสนอใน Python ผ่าน Java
linktitle: โน้ตการนำเสนอ
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