---
title: จัดการโน้ตงานนำเสนอใน Python
linktitle: โน้ตงานนำเสนอ
type: docs
weight: 110
url: /th/python-net/presentation-notes/
keywords:
- โน้ต
- สไลด์โน้ต
- เพิ่มโน้ต
- ลบโน้ต
- รูปแบบโน้ต
- โน้ตหลัก
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Aspose.Slides
description: "ปรับแต่งโน้ตงานนำเสนอด้วย Aspose.Slides สำหรับ Python ผ่าน .NET ทำงานกับโน้ต PowerPoint และ OpenDocument อย่างราบรื่นเพื่อเพิ่มประสิทธิภาพการทำงานของคุณ."
---
## **ภาพรวม**

Aspose.Slides รองรับการลบสไลด์โน้ตจากงานนำเสนอ ในหัวข้อนี้ เราจะแนะนำคุณลักษณะนี้ รวมถึงวิธีลบโน้ตและวิธีปรับใช้สไตล์ให้กับสไลด์โน้ตในงานนำเสนอ Aspose.Slides ให้คุณลบโน้ตจากสไลด์ใดก็ได้และยังสามารถปรับสไตล์ให้กับโน้ตที่มีอยู่ได้ นักพัฒนาสามารถลบโน้ตได้ตามวิธีต่อไปนี้:

- ลบโน้ตจากสไลด์เฉพาะในงานนำเสนอ.
- ลบโน้ตจากสไลด์ทั้งหมดในงานนำเสนอ.

## **ลบโน้ตจากสไลด์**
โน้ตของสไลด์เฉพาะบางสไลด์สามารถลบได้ตามตัวอย่างด้านล่าง:

```py
import aspose.slides as slides

# สร้างอ็อบเจกต์ Presentation ที่แทนไฟล์งานนำเสนอ 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # ลบโน้ตของสไลด์แรก
    mgr = presentation.slides[0].notes_slide_manager
    mgr.remove_notes_slide()

    # บันทึกงานนำเสนอลงดิสก์
    presentation.save("RemoveNotesAtSpecificSlide_out.pptx", slides.export.SaveFormat.PPTX)
```

## **ลบโน้ตจากสไลด์ทั้งหมด**
โน้ตของสไลด์ทั้งหมดในงานนำเสนอสามารถลบได้ตามตัวอย่างด้านล่าง:

```py
import aspose.slides as slides

# สร้างอ็อบเจกต์ Presentation ที่แทนไฟล์งานนำเสนอ 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # ลบโน้ตของสไลด์ทั้งหมด
    for i in range(len(presentation.slides)):
        mgr = presentation.slides[i].notes_slide_manager
        mgr.remove_notes_slide()
    # บันทึกงานนำเสนอลงดิสก์
    presentation.save("RemoveNotesFromAllSlides_out.pptx", slides.export.SaveFormat.PPTX)
```

## **เพิ่ม NotesStyle**
คุณสมบัติ[notes_style](https://reference.aspose.com/slides/th/python-net/aspose.slides/masternotesslide/notes_style/)ถูกเพิ่มเข้าไปในคลาส[MasterNotesSlide](https://reference.aspose.com/slides/th/python-net/aspose.slides/masternotesslide/)นี้ ระบุรูปแบบของข้อความโน้ต การดำเนินการแสดงในตัวอย่างด้านล่าง

```py
import aspose.slides as slides

# สร้างคลาส Presentation ที่แทนไฟล์งานนำเสนอ
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    notesMaster = presentation.master_notes_slide_manager.master_notes_slide
    if notesMaster != None:
        # รับสไตล์ข้อความของ MasterNotesSlide
        notesStyle = notesMaster.notes_style

        #Set สัญลักษณ์ bullet สำหรับย่อหน้าอันดับแรก
        paragraphFormat = notesStyle.get_level(0)
        paragraphFormat.bullet.type = slides.BulletType.SYMBOL

    # บันทึกไฟล์ PPTX ลงดิสก์
    presentation.save("AddNotesSlideWithNotesStyle_out.pptx", slides.export.SaveFormat.PPTX)
```

## **คำถามที่พบบ่อย**

**API entity ใดที่ให้การเข้าถึงโน้ตของสไลด์เฉพาะ?**

โน้ตจะถูกเข้าถึงผ่านตัวจัดการโน้ตของสไลด์: สไลด์มี[NotesSlideManager](https://reference.aspose.com/slides/th/python-net/aspose.slides/notesslidemanager/)และ[property](https://reference.aspose.com/slides/th/python-net/aspose.slides/notesslidemanager/notes_slide/)ที่คืนค่าอ็อบเจกต์โน้ต, หรือ `None` หากไม่มีโน้ต.

**มีความแตกต่างในการสนับสนุนโน้ตระหว่างเวอร์ชัน PowerPoint ที่ไลบรารีรองรับหรือไม่?**

ไลบรารีมุ่งเป้าไปที่รูปแบบ Microsoft PowerPoint หลายประเภท (97–newer) และ ODP; โน้ตได้รับการสนับสนุนในรูปแบบเหล่านี้โดยไม่ต้องพึ่งพาการติดตั้ง PowerPoint.