---
title: จัดการบันทึกการนำเสนอใน .NET
linktitle: บันทึกการนำเสนอ
type: docs
weight: 110
url: /th/net/presentation-notes/
keywords:
- บันทึก
- สไลด์บันทึก
- เพิ่มบันทึก
- ลบบันทึก
- สไตล์บันทึก
- บันทึกหลัก
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ปรับแต่งบันทึกการนำเสนอด้วย Aspose.Slides สำหรับ .NET ทำงานกับบันทึก PowerPoint และ OpenDocument อย่างราบรื่นเพื่อเพิ่มประสิทธิภาพการทำงานของคุณ."
---
## **ภาพรวม**

Aspose.Slides รองรับการลบสไลด์บันทึกจากงานนำเสนอ ในหัวข้อนี้ เราจะอธิบายฟีเจอร์นี้ รวมถึงวิธีการลบบันทึกและวิธีการใช้สไตล์กับสไลด์บันทึกในงานนำเสนอ Aspose.Slides ให้คุณลบบันทึกจากสไลด์ใดก็ได้และยังสามารถใช้การจัดรูปแบบกับบันทึกที่มีอยู่ได้ นักพัฒนาสามารถลบบันทึกได้ตามวิธีต่อไปนี้:

- ลบบันทึกจากสไลด์เฉพาะในงานนำเสนอ.
- ลบบันทึกจากสไลด์ทั้งหมดในงานนำเสนอ.

## **ลบบันทึกจากสไลด์**
บันทึกของสไลด์เฉพาะบางสไลด์สามารถลบได้ตามตัวอย่างด้านล่าง:

```c#
// สร้างอ็อบเจ็กต์ Presentation ที่แทนไฟล์งานนำเสนอ 
Presentation presentation = new Presentation(dataDir + "AccessSlides.pptx");

// ลบบันทึกของสไลด์แรก
INotesSlideManager mgr = presentation.Slides[0].NotesSlideManager;
mgr.RemoveNotesSlide();

// บันทึกงานนำเสนอลงดิสก์
presentation.Save(dataDir + "RemoveNotesAtSpecificSlide_out.pptx", SaveFormat.Pptx);
```

## **ลบบันทึกจากสไลด์ทั้งหมด**
บันทึกของสไลด์ทั้งหมดในงานนำเสนอสามารถลบได้ตามตัวอย่างด้านล่าง:

```c#
// สร้างอ็อบเจ็กต์ Presentation ที่แทนไฟล์งานนำเสนอ 
Presentation presentation = new Presentation("AccessSlides.pptx");

// ลบบันทึกของสไลด์ทั้งหมด
INotesSlideManager mgr = null;
for (int i = 0; i < presentation.Slides.Count; i++)
{
    mgr = presentation.Slides[i].NotesSlideManager;
    mgr.RemoveNotesSlide();
}
// บันทึกงานนำเสนอลงดิสก์
presentation.Save("RemoveNotesFromAllSlides_out.pptx", SaveFormat.Pptx);
```

## **เพิ่มสไตล์บันทึก**
คุณสมบัติ NotesStyle ถูกเพิ่มเข้าไปในอินเทอร์เฟซ[IMasterNotesSlide](https://reference.aspose.com/slides/th/net/aspose.slides/imasternotesslide)และคลาส[MasterNotesSlide](https://reference.aspose.com/slides/th/net/aspose.slides/masternotesslide)ตามลำดับ คุณสมบัตินี้ระบุสไตล์ของข้อความบันทึก การทำงานจะถูกแสดงในตัวอย่างด้านล่าง.

```c#
// สร้างอ็อบเจ็กต์ Presentation ที่แทนไฟล์งานนำเสนอ
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    IMasterNotesSlide notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;

    if (notesMaster != null)
    {
        // ดึงสไตล์ข้อความของ MasterNotesSlide
        ITextStyle notesStyle = notesMaster.NotesStyle;

        // ตั้งสัญลักษณ์ bullet ให้กับย่อหน้าระดับแรก
        IParagraphFormat paragraphFormat = notesStyle.GetLevel(0);
        paragraphFormat.Bullet.Type = BulletType.Symbol;
    }

    // บันทึกไฟล์ PPTX ลงดิสก์
    presentation.Save("AddNotesSlideWithNotesStyle_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

}
```

## **คำถามที่พบบ่อย**

**อะไรคือ API entity ที่ให้เข้าถึงบันทึกของสไลด์เฉพาะ?**

บันทึกจะเข้าถึงผ่านตัวจัดการบันทึกของสไลด์: สไลด์มี[NotesSlideManager](https://reference.aspose.com/slides/th/net/aspose.slides/notesslidemanager/)และ[property](https://reference.aspose.com/slides/th/net/aspose.slides/notesslidemanager/notesslide/)ที่คืนค่าอ็อบเจกต์บันทึก หรือ `null` หากไม่มีบันทึก.

**มีความแตกต่างในการสนับสนุนบันทึกระหว่างเวอร์ชัน PowerPoint ที่ไลบรารีทำงานกับหรือไม่?**

ไลบรารีนี้รองรับรูปแบบ Microsoft PowerPoint อย่างกว้างขวาง (ตั้งแต่ 97 จนถึงรุ่นใหม่) และ ODP; บันทึกได้รับการสนับสนุนในรูปแบบเหล่านี้โดยไม่ต้องพึ่งพาการติดตั้ง PowerPoint.