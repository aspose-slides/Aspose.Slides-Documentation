---
title: จัดการบันทึกการพรีเซนเทชันใน Python
linktitle: บันทึกการพรีเซนเทชัน
type: docs
weight: 110
url: /th/python-net/presentation-notes/
keywords:
- บันทึก
- สไลด์บันทึก
- เพิ่มบันทึก
- ลบบันทึก
- สไตล์บันทึก
- บันทึกหลัก
- PowerPoint
- OpenDocument
- การพรีเซนเทชัน
- Python
- Aspose.Slides
description: "ปรับแต่งบันทึกการพรีเซนเทชันด้วย Aspose.Slides สำหรับ Python ผ่าน .NET ทำงานร่วมกับบันทึก PowerPoint และ OpenDocument อย่างราบรื่นเพื่อเพิ่มผลิตภาพของคุณ."
---
## **ภาพรวม**

Aspose.Slides รองรับการลบสไลด์บันทึกจากการพรีเซนเทชัน ในหัวข้อนี้เราจะอธิบายคุณลักษณะนี้ รวมถึงวิธีการลบบันทึกและวิธีการใช้สไตล์กับสไลด์บันทึกในพรีเซนเทชัน Aspose.Slides ให้คุณลบบันทึกจากสไลด์ใดก็ได้และยังสามารถปรับสไตล์ให้กับบันทึกที่มีอยู่ได้ นักพัฒนาสามารถลบบันทึกได้ตามวิธีต่อไปนี้:

- ลบบันทึกจากสไลด์เฉพาะในพรีเซนเทชัน
- ลบบันทึกจากสไลด์ทั้งหมดในพรีเซนเทชัน

เพื่ออ่านหรือเปลี่ยนขนาดหน้าบันทึก, เปลี่ยนทิศทาง, และตรวจสอบพฤติกรรมการส่งออก, ดูที่ [ขนาดหน้าบันทึก](/slides/th/python-net/notes-size/).

## **ลบบันทึกจากสไลด์**
บันทึกจากสไลด์เฉพาะสามารถลบได้ตามตัวอย่างด้านล่าง:

```py
import aspose.slides as slides

# สร้างอ็อบเจกต์ Presentation ที่แทนไฟล์พรีเซนเทชัน 
with slides.Presentation("AccessSlides.pptx") as presentation:
    # ลบบันทึกของสไลด์แรก
    mgr = presentation.slides[0].notes_slide_manager
    mgr.remove_notes_slide()

    # บันทึกพรีเซนเทชันลงดิสก์
    presentation.save("RemoveNotesAtSpecificSlide_out.pptx", slides.export.SaveFormat.PPTX)
```

## **ลบบันทึกจากสไลด์ทั้งหมด**
บันทึกจากสไลด์ทั้งหมดในพรีเซนเทชันสามารถลบได้ตามตัวอย่างด้านล่าง:

```py
import aspose.slides as slides

# สร้างอ็อบเจกต์ Presentation ที่แทนไฟล์พรีเซนเทชัน 
with slides.Presentation("AccessSlides.pptx") as presentation:
    # ลบบันทึกของสไลด์ทั้งหมด
    for i in range(len(presentation.slides)):
        mgr = presentation.slides[i].notes_slide_manager
        mgr.remove_notes_slide()
    # บันทึกพรีเซนเทชันลงดิสก์
    presentation.save("RemoveNotesFromAllSlides_out.pptx", slides.export.SaveFormat.PPTX)
```

## **ใช้สไตล์บันทึก**
คุณสมบัติ [notes_style](https://reference.aspose.com/slides/th/python-net/aspose.slides/masternotesslide/notes_style/) ได้ถูกเพิ่มเข้าไปในคลาส [MasterNotesSlide](https://reference.aspose.com/slides/th/python-net/aspose.slides/masternotesslide/)  คุณสมบัตินี้ระบุสไตล์ของข้อความบันทึก การใช้งานได้แสดงในตัวอย่างด้านล่าง.

```py
import aspose.slides as slides

# สร้างอ็อบเจกต์ Presentation ที่แทนไฟล์พรีเซนเทชัน
with slides.Presentation("AccessSlides.pptx") as presentation:
    notesMaster = presentation.master_notes_slide_manager.master_notes_slide
    if notesMaster != None:
        # ดึงสไตล์ข้อความของ MasterNotesSlide
        notesStyle = notesMaster.notes_style

        #ตั้งค่ารูปสัญลักษณ์ bullet สำหรับย่อหน้าระดับแรก
        paragraphFormat = notesStyle.get_level(0)
        paragraphFormat.bullet.type = slides.BulletType.SYMBOL

    # บันทึกไฟล์ PPTX ลงดิสก์
    presentation.save("AddNotesSlideWithNotesStyle_out.pptx", slides.export.SaveFormat.PPTX)
```

## **คำถามที่พบบ่อย**

**อะไรเป็นเอนทิตี API ที่ให้การเข้าถึงบันทึกของสไลด์เฉพาะ?**

บันทึกถูกเข้าถึงผ่านตัวจัดการบันทึกของสไลด์: สไลด์มี [NotesSlideManager](https://reference.aspose.com/slides/th/python-net/aspose.slides/notesslidemanager/) และ [property](https://reference.aspose.com/slides/th/python-net/aspose.slides/notesslidemanager/notes_slide/) ที่ส่งคืนวัตถุบันทึก, หรือ `None` หากไม่มีบันทึก.

**มีความแตกต่างในการสนับสนุนบันทึกระหว่างเวอร์ชัน PowerPoint ที่ไลบรารีทำงานกับหรือไม่?**

ไลบรารีนี้รองรับรูปแบบ Microsoft PowerPoint ช่วงกว้าง (ตั้งแต่ 97‑ใหม่กว่า) และ ODP; บันทึกได้รับการสนับสนุนในรูปแบบเหล่านี้โดยไม่ต้องพึ่งพาการติดตั้ง PowerPoint.