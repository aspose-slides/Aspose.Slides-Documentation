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

Aspose.Slides รองรับการลบสไลด์บันทึกจากการนำเสนอ ในหัวข้อนี้ เราจะอธิบายคุณลักษณะนี้ รวมถึงวิธีการลบบันทึกและวิธีการใช้สไตล์กับสไลด์บันทึกในงานนำเสนอ Aspose.Slides ให้คุณลบบันทึกจากสไลด์ใดก็ได้และยังสามารถกำหนดสไตล์ให้กับบันทึกที่มีอยู่ได้ นักพัฒนาสามารถลบบันทึกได้หลายวิธีดังนี้:

- ลบบันทึกจากสไลด์เฉพาะในงานนำเสนอ
- ลบบันทึกจากสไลด์ทั้งหมดในงานนำเสนอ

เพื่ออ่านหรือเปลี่ยนขนาดหน้าบันทึก, สลับแนวตั้ง/แนวนอน, และตรวจสอบพฤติกรรมการส่งออก ดูที่ [ขนาดหน้าบันทึก](/slides/th/net/notes-size/) 

## **ลบบันทึกจากสไลด์**
บันทึกของสไลด์บางสไลด์สามารถลบได้ตามตัวอย่างด้านล่าง:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// สร้างอ็อบเจกต์ Presentation ที่เป็นตัวแทนของไฟล์การนำเสนอ
Presentation presentation = new Presentation("AccessSlides.pptx");

// ลบบันทึกของสไลด์แรก
INotesSlideManager mgr = presentation.Slides[0].NotesSlideManager;
mgr.RemoveNotesSlide();

// บันทึกการนำเสนอลงดิสก์
presentation.Save("RemoveNotesAtSpecificSlide_out.pptx", SaveFormat.Pptx);
```

## **ลบบันทึกจากสไลด์ทั้งหมด**
บันทึกของสไลด์ทั้งหมดในงานนำเสนอสามารถลบได้ตามตัวอย่างด้านล่าง:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// สร้างอ็อบเจกต์ Presentation ที่เป็นตัวแทนของไฟล์การนำเสนอ
Presentation presentation = new Presentation("AccessSlides.pptx");

// ลบบันทึกของสไลด์ทั้งหมด
INotesSlideManager mgr = null;
for (int i = 0; i < presentation.Slides.Count; i++)
{
    mgr = presentation.Slides[i].NotesSlideManager;
    mgr.RemoveNotesSlide();
}
// บันทึกการนำเสนอลงดิสก์
presentation.Save("RemoveNotesFromAllSlides_out.pptx", SaveFormat.Pptx);
```

## **เพิ่มสไตล์บันทึก**
คุณสมบัติ NotesStyle ได้ถูกเพิ่มเข้าไปในอินเทอร์เฟซ [IMasterNotesSlide](https://reference.aspose.com/slides/th/net/aspose.slides/imasternotesslide) และคลาส [MasterNotesSlide](https://reference.aspose.com/slides/th/net/aspose.slides/masternotesslide) ตามลำดับ คุณสมบัตินี้ระบุสไตล์ของข้อความบันทึก ตัวอย่างการใช้งานแสดงในโค้ดด้านล่าง:

```c#
using Aspose.Slides;

// สร้างคลาส Presentation ที่เป็นตัวแทนของไฟล์การนำเสนอ
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    IMasterNotesSlide notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;

    if (notesMaster != null)
    {
        // ดึงสไตล์ข้อความของ MasterNotesSlide
        ITextStyle notesStyle = notesMaster.NotesStyle;

        //ตั้งสัญลักษณ์ bullet สำหรับย่อหน้าระดับแรก
        IParagraphFormat paragraphFormat = notesStyle.GetLevel(0);
        paragraphFormat.Bullet.Type = BulletType.Symbol;
    }

    // บันทึกไฟล์ PPTX ไปยังดิสก์
    presentation.Save("AddNotesSlideWithNotesStyle_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

}
```

## **FAQ**

### แหล่ง API ใดให้การเข้าถึงบันทึกของสไลด์เฉพาะ?
บันทึกเข้าถึงได้ผ่านผู้จัดการบันทึกของสไลด์: สไลด์มี [NotesSlideManager](https://reference.aspose.com/slides/th/net/aspose.slides/notesslidemanager/) และ [property](https://reference.aspose.com/slides/th/net/aspose.slides/notesslidemanager/notesslide/) ที่คืนค่าอ็อบเจ็กต์บันทึก หรือ `null` หากไม่มีบันทึก

### มีความแตกต่างในการรองรับบันทึกระหว่างเวอร์ชัน PowerPoint ที่ไลบรารีทำงานหรือไม่?
ไลบรารีรองรับรูปแบบ Microsoft PowerPoint ช่วงกว้าง (ตั้งแต่ 97‑จนถึงเวอร์ชันใหม่) และ ODP; บันทึกได้รับการสนับสนุนในรูปแบบเหล่านี้โดยไม่ต้องพึ่งพาติดตั้ง PowerPoint ในเครื่อง.