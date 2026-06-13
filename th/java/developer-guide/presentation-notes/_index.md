---
title: จัดการโน้ตการนำเสนอใน Java
linktitle: โน้ตการนำเสนอ
type: docs
weight: 110
url: /th/java/presentation-notes/
keywords:
- โน้ต
- สไลด์โน้ต
- เพิ่มโน้ต
- ลบโน้ต
- สไตล์โน้ต
- โน้ตหลัก
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "ปรับแต่งโน้ตการนำเสนอด้วย Aspose.Slides สำหรับ Java ทำงานกับโน้ต PowerPoint และ OpenDocument อย่างราบรื่นเพื่อเพิ่มประสิทธิภาพการทำงานของคุณ."
---
## **ภาพรวม**

Aspose.Slides รองรับการลบสไลด์โน้ตจากงานนำเสนอ ในหัวข้อนี้ เราจะอธิบายคุณลักษณะนี้ รวมถึงวิธีการลบโน้ตและวิธีการใช้สไตล์กับสไลด์โน้ตในงานนำเสนอ Aspose.Slides ให้คุณลบโน้ตจากสไลด์ใดก็ได้และยังสามารถนำสไตล์ไปใช้กับโน้ตที่มีอยู่แล้ว นักพัฒนาสามารถลบโน้ตได้ด้วยวิธีต่อไปนี้:

- ลบโน้ตจากสไลด์เฉพาะในงานนำเสนอ
- ลบโน้ตจากสไลด์ทั้งหมดในงานนำเสนอ

## **ลบโน้ตจากสไลด์**
โน้ตของสไลด์ที่ระบุสามารถลบได้ตามตัวอย่างด้านล่าง:

```java
// สร้างอ็อบเจ็กต์ Presentation ที่แทนไฟล์งานนำเสนอ
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // ลบโน้ตของสไลด์แรก
    INotesSlideManager mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();

    // บันทึกงานนำเสนอลงดิสก์
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ลบโน้ตจากการนำเสนอ**
โน้ตของสไลด์ทั้งหมดในงานนำเสนอสามารถลบได้ตามตัวอย่างด้านล่าง:

```java
// สร้างอ็อบเจ็กต์ Presentation ที่แทนไฟล์งานนำเสนอ
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // ลบโน้ตของสไลด์ทั้งหมด
    INotesSlideManager mgr = null;
    for (int i = 0; i < pres.getSlides().size(); i++) {
        mgr = pres.getSlides().get_Item(i).getNotesSlideManager();
        mgr.removeNotesSlide();
    }
    
    // บันทึกงานนำเสนอลงดิสก์
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **เพิ่มสไตล์โน้ต**
[getNotesStyle](https://reference.aspose.com/slides/th/java/com.aspose.slides/IMasterNotesSlide#getNotesStyle--) method ได้ถูกเพิ่มเข้าไปในอินเทอร์เฟซ [IMasterNotesSlide](https://reference.aspose.com/slides/th/java/com.aspose.slides/IMasterNotesSlide) และคลาส [MasterNotesSlide](https://reference.aspose.com/slides/th/java/com.aspose.slides/MasterNotesSlide) ตามลำดับ . พร็อพเพอร์ตี้นี้ระบุสไตล์ของข้อความโน้ต การใช้งานได้แสดงในตัวอย่างด้านล่าง.

```java
// สร้างอ็อบเจ็กต์ Presentation ที่แทนไฟล์งานนำเสนอ
Presentation pres = new Presentation("demo.pptx");
try {
    IMasterNotesSlide notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    
    if (notesMaster != null)
    {
        // รับสไตล์ข้อความของ MasterNotesSlide
        ITextStyle notesStyle = notesMaster.getNotesStyle();
    
        // กำหนดสัญลักษณ์ bullet สำหรับย่อหน้าในระดับแรก
        IParagraphFormat paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **คำถามที่พบบ่อย**

**API entity ใดที่ให้การเข้าถึงโน้ตของสไลด์เฉพาะ?**

โน้ตจะเข้าถึงผ่านตัวจัดการโน้ตของสไลด์: สไลด์มี [NotesSlideManager](https://reference.aspose.com/slides/th/java/com.aspose.slides/notesslidemanager/) และ [method](https://reference.aspose.com/slides/th/java/com.aspose.slides/notesslidemanager/#getNotesSlide--) ที่คืนค่าอ็อบเจ็กต์โน้ต หรือ `null` หากไม่มีโน้ต

**มีความแตกต่างในการสนับสนุนโน้ตระหว่างเวอร์ชัน PowerPoint ที่ไลบรารีทำงานหรือไม่?**

ไลบรารีรองรับรูปแบบไฟล์ Microsoft PowerPoint (97‑newer) และ ODP; โน้ตได้รับการสนับสนุนในรูปแบบเหล่านี้โดยไม่ต้องอิงกับการติดตั้ง PowerPoint.